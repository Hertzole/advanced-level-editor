using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
	public class ManipulationHandle : MonoBehaviour, ILevelEditorGizmos
	{
		public enum Axis
		{
			None,
			X,
			Y,
			Z,
			Any
		}

		public enum CenterTypes
		{
			All,
			Solo
		}

		public enum ScaleTypes
		{
			FromPoint,
			FromPointOffset
		}

		public enum TransformPivots
		{
			Pivot,
			Center
		}

		public enum TransformSpaces
		{
			Global,
			Local
		}

		public enum TransformTypes
		{
			Move,
			Rotate,
			Scale,
			All
		}

		[SerializeField]
		private Camera targetCamera = default;

		[Space]
		[SerializeField]
		private TransformSpaces space = TransformSpaces.Global;
		[SerializeField]
		private TransformTypes transformType = TransformTypes.Move;
		[SerializeField]
		private TransformPivots pivot = TransformPivots.Pivot;
		[SerializeField]
		private CenterTypes centerType = CenterTypes.All;
		[SerializeField]
		private ScaleTypes scaleType = ScaleTypes.FromPoint;

		[Header("Snapping")]
		[SerializeField]
		private float movementSnap = .25f;
		[SerializeField]
		private float rotationSnap = 15f;
		[SerializeField]
		private float scaleSnap = 1f;

		[Header("Input")]
		[SerializeField]
		private string selectInput = "Select";
		[SerializeField]
		private string dragInput = "Drag Handle";
		[SerializeField]
		private string snapInput = "Snap";

		[Header("Appearance")]
		[SerializeField]
		private Color xColor = new Color(1, 0, 0, 0.8f);
		[SerializeField]
		private Color yColor = new Color(0, 1, 0, 0.8f);
		[SerializeField]
		private Color zColor = new Color(0, 0, 1, 0.8f);
		[SerializeField]
		private Color allColor = new Color(.7f, .7f, .7f, 0.8f);
		[SerializeField]
		private Color selectedColor = new Color(1, 1, 0, 0.8f);
		[SerializeField]
		private Color hoverColor = new Color(1, .75f, 0, 0.8f);
		[SerializeField]
		private float planesOpacity = .5f;

		[SerializeField]
		private float handleScale = 1f;
		[SerializeField]
		private float handleLength = 1f;
		[SerializeField]
		private float handleWidth = 0.03f;
		[SerializeField]
		private float planeSize = 0.35f;
		[SerializeField]
		private float arrowSize = 0.3f;
		[SerializeField]
		private float boxSize = 0.3f;
		[SerializeField]
		private int circleDetail = 40;
		[SerializeField]
		private float allMoveHandleLengthMultiplier = 1f;
		[SerializeField]
		private float allRotateHandleLengthMultiplier = 1.4f;
		[SerializeField]
		private float allScaleHandleLengthMultiplier = 1.6f;
		[SerializeField]
		private float minSelectedDistanceCheck = .01f;
		[SerializeField]
		private float moveSpeedMultiplier = 1f;
		[SerializeField]
		private float scaleSpeedMultiplier = 1f;
		[SerializeField]
		private float rotateSpeedMultiplier = 1f;
		[SerializeField]
		private float allRotateSpeedMultiplier = 20f;

		[SerializeField]
		private bool useFirstSelectedAsMain = true;

		//If circularRotationMethod is true, when rotating you will need to move your mouse around the object as if turning a wheel.
		//If circularRotationMethod is false, when rotating you can just click and drag in a line to rotate.
		[SerializeField]
		private bool circularRotationMethod;

		//Mainly for if you want the pivot point to update correctly if selected objects are moving outside the transformgizmo.
		//Might be poor on performance if lots of objects are selected...
		[SerializeField]
		private bool forceUpdatePivotPointOnChange = true;

		private bool initialized = false;
		private bool subscribedToUndo = false;

		private AxisInfo axisInfo = new AxisInfo();
		private AxisVectors circlesLines = new AxisVectors();

		private AxisVectors handleLines = new AxisVectors();
		private AxisVectors handlePlanes = new AxisVectors();
		private AxisVectors handleSquares = new AxisVectors();
		private AxisVectors handleTriangles = new AxisVectors();

		private Coroutine forceUpdatePivotCoroutine;
		private readonly Dictionary<Transform, TargetInfo> targetRoots = new Dictionary<Transform, TargetInfo>();
		private readonly HashSet<Transform> children = new HashSet<Transform>();

		private ILevelEditorInput input;
		private ILevelEditorUndo undo;
		private readonly List<(Vector3 position, Vector3 rotation, Vector3 scale, ILevelEditorObject target)> startVectors = new List<(Vector3, Vector3, Vector3, ILevelEditorObject)>();

		private readonly List<Transform> childrenBuffer = new List<Transform>();

		//We use a HashSet and a List for targetRoots so that we get fast lookup with the hashset while also keeping track of the order with the list.
		private readonly List<Transform> targetRootsOrdered = new List<Transform>();
		private Vector3 totalCenterPivotPoint;

		private readonly WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

		public bool IsTransforming { get; private set; }
		public float TotalScaleAmount { get; private set; }
		public Quaternion TotalRotationAmount { get; private set; }
		public Axis TranslatingAxis { get; private set; } = Axis.None;
		public Axis TranslatingAxisPlane { get; private set; } = Axis.None;
		public bool HasTranslatingAxisPlane { get { return TranslatingAxisPlane != Axis.None && TranslatingAxisPlane != Axis.Any; } }
		public TransformTypes TransformingType { get; private set; }

		public Vector3 PivotPoint { get; private set; }

		public Transform MainTargetRoot { get { return GetMainRoot(); } }

		private float HandleWidth { get { return handleWidth * handleScale * 0.1f; } }
		private float PlaneSize { get { return planeSize * handleScale * 0.1f; } }
		private float ArrowSize { get { return arrowSize * handleScale * 0.1f; } }
		private float BoxSize { get { return boxSize * handleScale * 0.1f; } }

		public TransformTypes TransformType
		{
			get { return transformType; }
			set
			{
				if (transformType != value)
				{
					transformType = value;

					if (!IsTransforming)
					{
						TransformingType = transformType;
					}

					if (value == TransformTypes.Scale && pivot == TransformPivots.Pivot)
					{
						// FromPointOffset can be inaccurate and should only really be used in Center mode if desired.
						scaleType = ScaleTypes.FromPoint;
					}
				}
			}
		}

		public TransformPivots Pivot
		{
			get { return pivot; }
			set
			{
				if (pivot != value)
				{
					pivot = value;
					SetPivotPoint();
				}
			}
		}

		public CenterTypes CenterType
		{
			get { return centerType; }
			set
			{
				if (centerType != value)
				{
					centerType = value;
					SetPivotPoint();
				}
			}
		}

		public TransformSpaces Space { get { return space; } set { space = value; } }

		public ScaleTypes ScaleType { get { return scaleType; } set { scaleType = value; } }
		
		private bool CanDrag { get { return !input.IsMouseOverUI(); } }

		private void Update()
		{
			if (!CanDrag)
			{
				// If it isn't set back to None, the transform will be highlighted.
				TranslatingAxis = Axis.None;
				return;
			}
			
			SetNearAxis();

			if (MainTargetRoot == null)
			{
				return;
			}

			TransformSelected();
		}

		private void LateUpdate()
		{
			if (!CanDrag || MainTargetRoot == null)
			{
				return;
			}

			//We run this in lateupdate since coroutines run after update and we want our gizmos to have the updated target transform position after TransformSelected()
			SetAxisInfo();

			SetLines();
		}

		private void OnEnable()
		{
			forceUpdatePivotCoroutine = StartCoroutine(ForceUpdatePivotPointAtEndOfFrame());

			LevelEditorGLRenderer.Add(this);

			ListenToUndo(true);
		}

		private void OnDisable()
		{
			LevelEditorGLRenderer.Remove(this);

			ClearTargets(); //Just so things gets cleaned up, such as removing any materials we placed on objects.

			StopCoroutine(forceUpdatePivotCoroutine);

			ListenToUndo(false);
		}
		
		private Transform GetMainRoot()
		{
			if (targetRootsOrdered.Count > 0)
			{
				return useFirstSelectedAsMain ? targetRootsOrdered[0] : targetRootsOrdered[targetRootsOrdered.Count - 1];
			}

			return null;
		}

		public void Initialize(ILevelEditorInput newInput, ILevelEditorUndo newUndo = null)
		{
			input = newInput;
			undo = newUndo;

			initialized = true;

			ListenToUndo(true);
		}

		private void ListenToUndo(bool listen)
		{
			if (undo == null)
			{
				return;
			}

			if (listen && !subscribedToUndo)
			{
				undo.OnUndo += OnUndo;
				undo.OnRedo += OnRedo;
				subscribedToUndo = true;
			}
			else if (!listen && subscribedToUndo)
			{
				undo.OnUndo -= OnUndo;
				undo.OnRedo -= OnRedo;
				subscribedToUndo = false;
			}
		}

		private void OnUndo(IUndoAction undoAction)
		{
			SetPivotPoint();
		}
		
		private void OnRedo(IUndoAction undoAction)
		{
			SetPivotPoint();
		}

		private Color GetColor(TransformTypes type, Color normalColor, Color nearColor, bool forceUseNormal = false)
		{
			return GetColor(type, normalColor, nearColor, false, 1, forceUseNormal);
		}

		private Color GetColor(TransformTypes type, Color normalColor, Color nearColor, float alpha, bool forceUseNormal = false)
		{
			return GetColor(type, normalColor, nearColor, true, alpha, forceUseNormal);
		}

		private Color GetColor(TransformTypes type, Color normalColor, Color nearColor, bool setAlpha, float alpha, bool forceUseNormal = false)
		{
			Color color;
			if (!forceUseNormal && TranslatingTypeContains(type, false))
			{
				color = nearColor;
			}
			else
			{
				color = normalColor;
			}

			if (setAlpha)
			{
				color.a = alpha;
			}

			return color;
		}

		//We only support scaling in local space.
		public TransformSpaces GetProperTransformSpace()
		{
			return transformType == TransformTypes.Scale ? TransformSpaces.Local : space;
		}

		public bool TransformTypeContains(TransformTypes type)
		{
			return TransformTypeContains(transformType, type);
		}

		public bool TransformTypeContains(TransformTypes mainType, TransformTypes type)
		{
			return mainType.TransformTypeContains(type, GetProperTransformSpace());
		}

		public bool TranslatingTypeContains(TransformTypes type, bool checkIsTransforming = true)
		{
			TransformTypes transType = !checkIsTransforming || IsTransforming ? TransformingType : transformType;
			return TransformTypeContains(transType, type);
		}

		public float GetHandleLength(TransformTypes type, Axis axis = Axis.None, bool multiplyDistanceMultiplier = true)
		{
			float length = handleLength * handleScale * 0.25f;
			if (transformType == TransformTypes.All)
			{
				switch (type)
				{
					case TransformTypes.Move:
						length *= allMoveHandleLengthMultiplier;
						break;
					case TransformTypes.Rotate:
						length *= allRotateHandleLengthMultiplier;
						break;
					case TransformTypes.Scale:
						length *= allScaleHandleLengthMultiplier;
						break;
				}
			}

			if (multiplyDistanceMultiplier)
			{
				length *= GetDistanceMultiplier();
			}

			if (type == TransformTypes.Scale && IsTransforming && (TranslatingAxis == axis || TranslatingAxis == Axis.Any))
			{
				length += TotalScaleAmount;
			}

			return length;
		}

		private void TransformSelected()
		{
			if (MainTargetRoot != null && TranslatingAxis != Axis.None && input.GetButtonDown(selectInput))
			{
				StartCoroutine(TransformSelected(TransformingType));
			}
		}

		private IEnumerator TransformSelected(TransformTypes transType)
		{
			IsTransforming = true;
			TotalScaleAmount = 0;
			TotalRotationAmount = Quaternion.identity;

			Vector3 originalPivot = PivotPoint;

			Vector3 axis = GetNearAxisDirection(out Vector3 otherAxis1, out Vector3 otherAxis2);
			Vector3 planeNormal = HasTranslatingAxisPlane ? axis : (targetCamera.transform.position - originalPivot).normalized;
			Vector3 projectedAxis = Vector3.ProjectOnPlane(axis, planeNormal).normalized;
			Vector3 previousMousePosition = Vector3.zero;

			Vector3 currentSnapMovementAmount = Vector3.zero;
			float currentSnapRotationAmount = 0;
			float currentSnapScaleAmount = 0;

			if (undo != null)
			{
				startVectors.Clear();

				for (int i = 0; i < targetRootsOrdered.Count; i++)
				{
					if (targetRootsOrdered[i].TryGetComponent(out ILevelEditorObject obj))
					{
						startVectors.Add((targetRootsOrdered[i].position, targetRootsOrdered[i].eulerAngles, targetRootsOrdered[i].localScale, obj));
					}
				}
			}

			while (!input.GetButtonUp(selectInput))
			{
				Ray mouseRay = targetCamera.ScreenPointToRay(input.MousePosition);
				Vector3 mousePosition = Geometry.LinePlaneIntersect(mouseRay.origin, mouseRay.direction, originalPivot, planeNormal);
				bool isSnapping = input.GetButton(snapInput);

				if (previousMousePosition != Vector3.zero && mousePosition != Vector3.zero)
				{
					if (transType == TransformTypes.Move)
					{
						Vector3 movement;

						if (HasTranslatingAxisPlane)
						{
							movement = mousePosition - previousMousePosition;
						}
						else
						{
							float moveAmount = LevelEditorExtensions.MagnitudeInDirection(mousePosition - previousMousePosition, projectedAxis) * moveSpeedMultiplier;
							movement = axis * moveAmount;
						}

						if (isSnapping && movementSnap > 0)
						{
							currentSnapMovementAmount += movement;
							movement = Vector3.zero;

							if (HasTranslatingAxisPlane)
							{
								float amountInAxis1 = LevelEditorExtensions.MagnitudeInDirection(currentSnapMovementAmount, otherAxis1);
								float amountInAxis2 = LevelEditorExtensions.MagnitudeInDirection(currentSnapMovementAmount, otherAxis2);

								float snapAmount1 = CalculateSnapAmount(movementSnap, amountInAxis1, out float _);
								float snapAmount2 = CalculateSnapAmount(movementSnap, amountInAxis2, out float _);

								if (snapAmount1 != 0)
								{
									Vector3 snapMove = otherAxis1 * snapAmount1;
									movement += snapMove;
									currentSnapMovementAmount -= snapMove;
								}

								if (snapAmount2 != 0)
								{
									Vector3 snapMove = otherAxis2 * snapAmount2;
									movement += snapMove;
									currentSnapMovementAmount -= snapMove;
								}
							}
							else
							{
								float snapAmount = CalculateSnapAmount(movementSnap, currentSnapMovementAmount.magnitude, out float remainder);

								if (snapAmount != 0)
								{
									movement = currentSnapMovementAmount.normalized * snapAmount;
									currentSnapMovementAmount = currentSnapMovementAmount.normalized * remainder;
								}
							}
						}

						for (int i = 0; i < targetRootsOrdered.Count; i++)
						{
							Transform target = targetRootsOrdered[i];

							target.Translate(movement, UnityEngine.Space.World);
						}

						SetPivotPointOffset(movement);
					}
					else if (transType == TransformTypes.Scale)
					{
						Vector3 projected = TranslatingAxis == Axis.Any ? targetCamera.transform.right : projectedAxis;
						float scaleAmount = LevelEditorExtensions.MagnitudeInDirection(mousePosition - previousMousePosition, projected) * scaleSpeedMultiplier;

						if (isSnapping && scaleSnap > 0)
						{
							currentSnapScaleAmount += scaleAmount;
							scaleAmount = 0;

							float snapAmount = CalculateSnapAmount(scaleSnap, currentSnapScaleAmount, out float remainder);

							if (snapAmount != 0)
							{
								scaleAmount = snapAmount;
								currentSnapScaleAmount = remainder;
							}
						}

						//WARNING - There is a bug in unity 5.4 and 5.5 that causes InverseTransformDirection to be affected by scale which will break negative scaling. Not tested, but updating to 5.4.2 should fix it - https://issuetracker.unity3d.com/issues/transformdirection-and-inversetransformdirection-operations-are-affected-by-scale
						Vector3 localAxis = GetProperTransformSpace() == TransformSpaces.Local && TranslatingAxis != Axis.Any ? MainTargetRoot.InverseTransformDirection(axis) : axis;

						Vector3 targetScaleAmount;
						if (TranslatingAxis == Axis.Any)
						{
							targetScaleAmount = MainTargetRoot.localScale.normalized.Abs() * scaleAmount;
						}
						else
						{
							targetScaleAmount = localAxis * scaleAmount;
						}

						for (int i = 0; i < targetRootsOrdered.Count; i++)
						{
							Transform target = targetRootsOrdered[i];

							Vector3 targetScale = target.localScale + targetScaleAmount;

							if (pivot == TransformPivots.Pivot)
							{
								target.localScale = targetScale;
							}
							else if (pivot == TransformPivots.Center)
							{
								if (scaleType == ScaleTypes.FromPoint)
								{
									target.SetScaleFrom(originalPivot, targetScale);
								}
								else if (scaleType == ScaleTypes.FromPointOffset)
								{
									target.SetScaleFromOffset(originalPivot, targetScale);
								}
							}
						}

						TotalScaleAmount += scaleAmount;
					}
					else if (transType == TransformTypes.Rotate)
					{
						float rotateAmount;
						Vector3 rotationAxis = axis;

						if (TranslatingAxis == Axis.Any)
						{
							Vector2 drag = input.GetVector2(dragInput, true);
							Vector3 rotation = targetCamera.transform.TransformDirection(new Vector3(drag.x, -drag.y, 0));
							Quaternion.Euler(rotation).ToAngleAxis(out rotateAmount, out rotationAxis);
							rotateAmount *= allRotateSpeedMultiplier;
						}
						else
						{
							if (circularRotationMethod)
							{
								float angle = Vector3.SignedAngle(previousMousePosition - originalPivot, mousePosition - originalPivot, axis);
								rotateAmount = angle * rotateSpeedMultiplier;
							}
							else
							{
								Vector3 projected = TranslatingAxis == Axis.Any || LevelEditorExtensions.IsParallel(axis, planeNormal) ? planeNormal : Vector3.Cross(axis, planeNormal);
								rotateAmount = LevelEditorExtensions.MagnitudeInDirection(mousePosition - previousMousePosition, projected) * (rotateSpeedMultiplier * 100f) / GetDistanceMultiplier();
							}
						}

						if (isSnapping && rotationSnap > 0)
						{
							currentSnapRotationAmount += rotateAmount;
							rotateAmount = 0;

							float snapAmount = CalculateSnapAmount(rotationSnap, currentSnapRotationAmount, out float remainder);

							if (snapAmount != 0)
							{
								rotateAmount = snapAmount;
								currentSnapRotationAmount = remainder;
							}
						}

						for (int i = 0; i < targetRootsOrdered.Count; i++)
						{
							Transform target = targetRootsOrdered[i];

							if (pivot == TransformPivots.Pivot)
							{
								target.Rotate(rotationAxis, rotateAmount, UnityEngine.Space.World);
							}
							else if (pivot == TransformPivots.Center)
							{
								target.RotateAround(originalPivot, rotationAxis, rotateAmount);
							}
						}

						TotalRotationAmount *= Quaternion.Euler(rotationAxis * rotateAmount);
					}
				}

				previousMousePosition = mousePosition;

				yield return null;
			}

			if (undo != null)
			{
				// If there are multiple objects, store all the objects.
				// But if there's only one object, make a separate undo action for a single object and avoid creating
				// arrays, just so we save on some garbage.
				if (startVectors.Count > 1)
				{
					uint[] objects = new uint[startVectors.Count];
					Vector3[] fromPositions = new Vector3[startVectors.Count];
					Vector3[] fromRotations = new Vector3[startVectors.Count];
					Vector3[] fromScales = new Vector3[startVectors.Count];
					Vector3[] toPositions = new Vector3[startVectors.Count];
					Vector3[] toRotations = new Vector3[startVectors.Count];
					Vector3[] toScales = new Vector3[startVectors.Count];

					for (int i = 0; i < startVectors.Count; i++)
					{
						objects[i] = startVectors[i].target.InstanceID;

						fromPositions[i] = startVectors[i].position;
						fromRotations[i] = startVectors[i].rotation;
						fromScales[i] = startVectors[i].scale;

						Transform targetTransform = startVectors[i].target.MyGameObject.transform;
						toPositions[i] = targetTransform.position;
						toRotations[i] = targetTransform.eulerAngles;
						toScales[i] = targetTransform.localScale;
					}

					TransformObjectsUndoAction undoAction = new TransformObjectsUndoAction(objects, fromPositions, fromRotations, fromScales, toPositions, toRotations, toScales);
					undo.AddAction(undoAction);
				}
				else if (startVectors.Count == 1)
				{
					uint id = startVectors[0].target.InstanceID;

					Vector3 fromPosition = startVectors[0].position;
					Vector3 fromRotation = startVectors[0].rotation;
					Vector3 fromScale = startVectors[0].scale;

					Transform targetTransform = startVectors[0].target.MyGameObject.transform;
					Vector3 toPosition = targetTransform.position;
					Vector3 toRotation = targetTransform.eulerAngles;
					Vector3 toScale = targetTransform.localScale;

					TransformObjectUndoAction undoAction = new TransformObjectUndoAction(id, fromPosition, fromRotation, fromScale, toPosition, toRotation, toScale);
					undo.AddAction(undoAction);
				}
			}

			TotalRotationAmount = Quaternion.identity;
			TotalScaleAmount = 0;
			IsTransforming = false;
			SetTranslatingAxis(transformType, Axis.None);

			SetPivotPoint();
		}

		private float CalculateSnapAmount(float snapValue, float currentAmount, out float remainder)
		{
			remainder = 0;
			if (snapValue <= 0)
			{
				return currentAmount;
			}

			float currentAmountAbs = Mathf.Abs(currentAmount);
			if (currentAmountAbs > snapValue)
			{
				remainder = currentAmountAbs % snapValue;
				return snapValue * (Mathf.Sign(currentAmount) * Mathf.Floor(currentAmountAbs / snapValue));
			}

			return 0;
		}

		private Vector3 GetNearAxisDirection(out Vector3 otherAxis1, out Vector3 otherAxis2)
		{
			otherAxis1 = otherAxis2 = Vector3.zero;

			if (TranslatingAxis != Axis.None)
			{
				if (TranslatingAxis == Axis.X)
				{
					otherAxis1 = axisInfo.yDirection;
					otherAxis2 = axisInfo.zDirection;
					return axisInfo.xDirection;
				}

				if (TranslatingAxis == Axis.Y)
				{
					otherAxis1 = axisInfo.xDirection;
					otherAxis2 = axisInfo.zDirection;
					return axisInfo.yDirection;
				}

				if (TranslatingAxis == Axis.Z)
				{
					otherAxis1 = axisInfo.xDirection;
					otherAxis2 = axisInfo.yDirection;
					return axisInfo.zDirection;
				}

				if (TranslatingAxis == Axis.Any)
				{
					return Vector3.one;
				}
			}

			return Vector3.zero;
		}

		public void AddTarget(Transform target)
		{
			if (target != null)
			{
				if (targetRoots.ContainsKey(target))
				{
					return;
				}

				if (children.Contains(target))
				{
					return;
				}

				AddTargetRoot(target);

				SetPivotPoint();
			}
		}

		public void RemoveTarget(Transform target)
		{
			if (target != null)
			{
				if (!targetRoots.ContainsKey(target))
				{
					return;
				}

				RemoveTargetRoot(target);

				SetPivotPoint();
			}
		}

		public void ClearTargets()
		{
			targetRoots.Clear();
			targetRootsOrdered.Clear();
			children.Clear();
		}

		private void AddTargetRoot(Transform targetRoot)
		{
			targetRoots.Add(targetRoot, new TargetInfo());
			targetRootsOrdered.Add(targetRoot);

			AddAllChildren(targetRoot);
		}

		private void RemoveTargetRoot(Transform targetRoot)
		{
			if (targetRoots.Remove(targetRoot))
			{
				targetRootsOrdered.Remove(targetRoot);

				RemoveAllChildren(targetRoot);
			}
		}

		private void AddAllChildren(Transform target)
		{
			childrenBuffer.Clear();
			target.GetComponentsInChildren(true, childrenBuffer);
			childrenBuffer.Remove(target);

			for (int i = 0; i < childrenBuffer.Count; i++)
			{
				Transform child = childrenBuffer[i];
				children.Add(child);
				RemoveTargetRoot(child); //We do this in case we selected child first and then the parent.
			}

			childrenBuffer.Clear();
		}

		private void RemoveAllChildren(Transform target)
		{
			childrenBuffer.Clear();
			target.GetComponentsInChildren(true, childrenBuffer);
			childrenBuffer.Remove(target);

			for (int i = 0; i < childrenBuffer.Count; i++)
			{
				children.Remove(childrenBuffer[i]);
			}

			childrenBuffer.Clear();
		}

		public void SetPivotPoint()
		{
			if (MainTargetRoot != null)
			{
				switch (pivot)
				{
					case TransformPivots.Pivot:
						PivotPoint = MainTargetRoot.position;
						break;
					case TransformPivots.Center:
					{
						totalCenterPivotPoint = Vector3.zero;

						Dictionary<Transform, TargetInfo>.Enumerator targetsEnumerator = targetRoots.GetEnumerator(); //We avoid foreach to avoid garbage.
						while (targetsEnumerator.MoveNext())
						{
							Transform target = targetsEnumerator.Current.Key;
							TargetInfo info = targetsEnumerator.Current.Value;
							info.centerPivotPoint = target.GetCenter(centerType);

							totalCenterPivotPoint += info.centerPivotPoint;
						}

						targetsEnumerator.Dispose();

						totalCenterPivotPoint /= targetRoots.Count;

						if (centerType == CenterTypes.Solo)
						{
							PivotPoint = targetRoots[MainTargetRoot].centerPivotPoint;
						}
						else if (centerType == CenterTypes.All)
						{
							PivotPoint = totalCenterPivotPoint;
						}

						break;
					}
				}
			}
		}

		private void SetPivotPointOffset(Vector3 offset)
		{
			PivotPoint += offset;
			totalCenterPivotPoint += offset;
		}

		private IEnumerator ForceUpdatePivotPointAtEndOfFrame()
		{
			while (enabled)
			{
				ForceUpdatePivotPointOnChange();
				yield return waitForEndOfFrame;
			}
		}

		private void ForceUpdatePivotPointOnChange()
		{
			if (forceUpdatePivotPointOnChange && MainTargetRoot != null && !IsTransforming)
			{
				bool hasSet = false;
				Dictionary<Transform, TargetInfo>.Enumerator targets = targetRoots.GetEnumerator();
				while (targets.MoveNext())
				{
					if (!hasSet && targets.Current.Value.previousPosition != Vector3.zero && targets.Current.Key.position != targets.Current.Value.previousPosition)
					{
						SetPivotPoint();
						hasSet = true;
					}

					targets.Current.Value.previousPosition = targets.Current.Key.position;
				}

				targets.Dispose();
			}
		}

		public void SetTranslatingAxis(TransformTypes type, Axis axis, Axis planeAxis = Axis.None)
		{
			TransformingType = type;
			TranslatingAxis = axis;
			TranslatingAxisPlane = planeAxis;
		}

		public AxisInfo GetAxisInfo()
		{
			AxisInfo currentAxisInfo = axisInfo;

			if (IsTransforming && GetProperTransformSpace() == TransformSpaces.Global && TransformingType == TransformTypes.Rotate)
			{
				currentAxisInfo.xDirection = TotalRotationAmount * Vector3.right;
				currentAxisInfo.yDirection = TotalRotationAmount * Vector3.up;
				currentAxisInfo.zDirection = TotalRotationAmount * Vector3.forward;
			}

			return currentAxisInfo;
		}

		private void SetNearAxis()
		{
			if (IsTransforming)
			{
				return;
			}

			SetTranslatingAxis(transformType, Axis.None);

			if (MainTargetRoot == null)
			{
				return;
			}

			float distanceMultiplier = GetDistanceMultiplier();
			float handleMinSelectedDistanceCheck = (minSelectedDistanceCheck + HandleWidth) * distanceMultiplier;

			if (TranslatingAxis == Axis.None && (TransformTypeContains(TransformTypes.Move) || TransformTypeContains(TransformTypes.Scale)))
			{
				//Important to check scale lines before move lines since in TransformType.All the move planes would block the scales center scale all gizmo.
				if (TranslatingAxis == Axis.None && TransformTypeContains(TransformTypes.Scale))
				{
					float tipMinSelectedDistanceCheck = (minSelectedDistanceCheck + BoxSize) * distanceMultiplier;
					HandleNearestPlanes(TransformTypes.Scale, handleSquares, tipMinSelectedDistanceCheck);
				}

				if (TranslatingAxis == Axis.None && TransformTypeContains(TransformTypes.Move))
				{
					//Important to check the planes first before the handle tip since it makes selecting the planes easier.
					float planeMinSelectedDistanceCheck = (minSelectedDistanceCheck + PlaneSize) * distanceMultiplier;
					HandleNearestPlanes(TransformTypes.Move, handlePlanes, planeMinSelectedDistanceCheck);

					if (TranslatingAxis != Axis.None)
					{
						TranslatingAxisPlane = TranslatingAxis;
					}
					else
					{
						float tipMinSelectedDistanceCheck = (minSelectedDistanceCheck + ArrowSize) * distanceMultiplier;
						HandleNearestLines(TransformTypes.Move, handleTriangles, tipMinSelectedDistanceCheck);
					}
				}

				if (TranslatingAxis == Axis.None)
				{
					//Since Move and Scale share the same handle line, we give Move the priority.
					TransformTypes transType = transformType == TransformTypes.All ? TransformTypes.Move : transformType;
					HandleNearestLines(transType, handleLines, handleMinSelectedDistanceCheck);
				}
			}

			if (TranslatingAxis == Axis.None && TransformTypeContains(TransformTypes.Rotate))
			{
				HandleNearestLines(TransformTypes.Rotate, circlesLines, handleMinSelectedDistanceCheck);
			}
		}

		private void HandleNearestLines(TransformTypes type, AxisVectors axisVectors, float minSelectedDistanceCheck)
		{
			float xClosestDistance = ClosestDistanceFromMouseToLines(axisVectors.X);
			float yClosestDistance = ClosestDistanceFromMouseToLines(axisVectors.Y);
			float zClosestDistance = ClosestDistanceFromMouseToLines(axisVectors.Z);
			float allClosestDistance = ClosestDistanceFromMouseToLines(axisVectors.All);

			HandleNearest(type, xClosestDistance, yClosestDistance, zClosestDistance, allClosestDistance, minSelectedDistanceCheck);
		}

		private void HandleNearestPlanes(TransformTypes type, AxisVectors axisVectors, float minSelectedDistanceCheck)
		{
			float xClosestDistance = ClosestDistanceFromMouseToPlanes(axisVectors.X);
			float yClosestDistance = ClosestDistanceFromMouseToPlanes(axisVectors.Y);
			float zClosestDistance = ClosestDistanceFromMouseToPlanes(axisVectors.Z);
			float allClosestDistance = ClosestDistanceFromMouseToPlanes(axisVectors.All);

			HandleNearest(type, xClosestDistance, yClosestDistance, zClosestDistance, allClosestDistance, minSelectedDistanceCheck);
		}

		private void HandleNearest(TransformTypes type, float xClosestDistance, float yClosestDistance, float zClosestDistance, float allClosestDistance, float minSelectedDistanceCheck)
		{
			if (type == TransformTypes.Scale && allClosestDistance <= minSelectedDistanceCheck)
			{
				SetTranslatingAxis(type, Axis.Any);
			}
			else if (xClosestDistance <= minSelectedDistanceCheck && xClosestDistance <= yClosestDistance && xClosestDistance <= zClosestDistance)
			{
				SetTranslatingAxis(type, Axis.X);
			}
			else if (yClosestDistance <= minSelectedDistanceCheck && yClosestDistance <= xClosestDistance && yClosestDistance <= zClosestDistance)
			{
				SetTranslatingAxis(type, Axis.Y);
			}
			else if (zClosestDistance <= minSelectedDistanceCheck && zClosestDistance <= xClosestDistance && zClosestDistance <= yClosestDistance)
			{
				SetTranslatingAxis(type, Axis.Z);
			}
			else if (type == TransformTypes.Rotate && MainTargetRoot != null)
			{
				Ray mouseRay = targetCamera.ScreenPointToRay(input.MousePosition);
				Vector3 mousePlaneHit = Geometry.LinePlaneIntersect(mouseRay.origin, mouseRay.direction, PivotPoint, (targetCamera.transform.position - PivotPoint).normalized);
				if ((PivotPoint - mousePlaneHit).sqrMagnitude <= GetHandleLength(TransformTypes.Rotate).Squared())
				{
					SetTranslatingAxis(type, Axis.Any);
				}
			}
		}

		private float ClosestDistanceFromMouseToLines(List<Vector3> lines)
		{
			Ray mouseRay = targetCamera.ScreenPointToRay(input.MousePosition);

			float closestDistance = float.MaxValue;
			for (int i = 0; i + 1 < lines.Count; i++)
			{
				IntersectPoints points = Geometry.ClosestPointsOnSegmentToLine(lines[i], lines[i + 1], mouseRay.origin, mouseRay.direction);
				float distance = Vector3.Distance(points.first, points.second);
				if (distance < closestDistance)
				{
					closestDistance = distance;
				}
			}

			return closestDistance;
		}

		private float ClosestDistanceFromMouseToPlanes(List<Vector3> planePoints)
		{
			float closestDistance = float.MaxValue;

			if (planePoints.Count >= 4)
			{
				Ray mouseRay = targetCamera.ScreenPointToRay(input.MousePosition);

				for (int i = 0; i < planePoints.Count; i += 4)
				{
					Plane plane = new Plane(planePoints[i], planePoints[i + 1], planePoints[i + 2]);

					if (plane.Raycast(mouseRay, out float distanceToPlane))
					{
						Vector3 pointOnPlane = mouseRay.origin + mouseRay.direction * distanceToPlane;
						Vector3 planeCenter = (planePoints[0] + planePoints[1] + planePoints[2] + planePoints[3]) / 4f;

						float distance = Vector3.Distance(planeCenter, pointOnPlane);
						if (distance < closestDistance)
						{
							closestDistance = distance;
						}
					}
				}
			}

			return closestDistance;
		}

		private void SetAxisInfo()
		{
			if (MainTargetRoot != null)
			{
				axisInfo.Set(MainTargetRoot, PivotPoint, GetProperTransformSpace());
			}
		}

		//This helps keep the size consistent no matter how far we are from it.
		public float GetDistanceMultiplier()
		{
			if (MainTargetRoot == null)
			{
				return 0f;
			}

			if (targetCamera.orthographic)
			{
				return Mathf.Max(.01f, targetCamera.orthographicSize * 2f);
			}

			return Mathf.Max(.01f, Mathf.Abs(LevelEditorExtensions.MagnitudeInDirection(PivotPoint - targetCamera.transform.position, targetCamera.transform.forward)));
		}

		private void SetLines()
		{
			SetHandleLines();
			SetHandlePlanes();
			SetHandleTriangles();
			SetHandleSquares();
			SetCircles(GetAxisInfo(), circlesLines);
		}

		private void SetHandleLines()
		{
			handleLines.Clear();

			if (TranslatingTypeContains(TransformTypes.Move) || TranslatingTypeContains(TransformTypes.Scale))
			{
				float lineWidth = HandleWidth * GetDistanceMultiplier();

				float xLineLength = 0;
				float yLineLength = 0;
				float zLineLength = 0;
				if (TranslatingTypeContains(TransformTypes.Move))
				{
					xLineLength = yLineLength = zLineLength = GetHandleLength(TransformTypes.Move);
				}
				else if (TranslatingTypeContains(TransformTypes.Scale))
				{
					xLineLength = GetHandleLength(TransformTypes.Scale, Axis.X);
					yLineLength = GetHandleLength(TransformTypes.Scale, Axis.Y);
					zLineLength = GetHandleLength(TransformTypes.Scale, Axis.Z);
				}

				AddQuads(PivotPoint, axisInfo.xDirection, axisInfo.yDirection, axisInfo.zDirection, xLineLength, lineWidth, handleLines.X);
				AddQuads(PivotPoint, axisInfo.yDirection, axisInfo.xDirection, axisInfo.zDirection, yLineLength, lineWidth, handleLines.Y);
				AddQuads(PivotPoint, axisInfo.zDirection, axisInfo.xDirection, axisInfo.yDirection, zLineLength, lineWidth, handleLines.Z);
			}
		}

		private void SetHandlePlanes()
		{
			handlePlanes.Clear();

			if (TranslatingTypeContains(TransformTypes.Move))
			{
				Vector3 pivotToCamera = targetCamera.transform.position - PivotPoint;
				float cameraXSign = Mathf.Sign(Vector3.Dot(axisInfo.xDirection, pivotToCamera));
				float cameraYSign = Mathf.Sign(Vector3.Dot(axisInfo.yDirection, pivotToCamera));
				float cameraZSign = Mathf.Sign(Vector3.Dot(axisInfo.zDirection, pivotToCamera));

				float size = PlaneSize;
				if (transformType == TransformTypes.All)
				{
					size *= allMoveHandleLengthMultiplier;
				}

				size *= GetDistanceMultiplier();

				Vector3 xDirection = axisInfo.xDirection * (size * cameraXSign);
				Vector3 yDirection = axisInfo.yDirection * (size * cameraYSign);
				Vector3 zDirection = axisInfo.zDirection * (size * cameraZSign);

				Vector3 xPlaneCenter = PivotPoint + (yDirection + zDirection);
				Vector3 yPlaneCenter = PivotPoint + (xDirection + zDirection);
				Vector3 zPlaneCenter = PivotPoint + (xDirection + yDirection);

				AddQuad(xPlaneCenter, axisInfo.yDirection, axisInfo.zDirection, size, handlePlanes.X);
				AddQuad(yPlaneCenter, axisInfo.xDirection, axisInfo.zDirection, size, handlePlanes.Y);
				AddQuad(zPlaneCenter, axisInfo.xDirection, axisInfo.yDirection, size, handlePlanes.Z);
			}
		}

		private void SetHandleTriangles()
		{
			handleTriangles.Clear();

			if (TranslatingTypeContains(TransformTypes.Move))
			{
				float triangleLength = ArrowSize * GetDistanceMultiplier();
				AddTriangles(axisInfo.GetXAxisEnd(GetHandleLength(TransformTypes.Move)), axisInfo.xDirection, axisInfo.yDirection, axisInfo.zDirection, triangleLength, handleTriangles.X);
				AddTriangles(axisInfo.GetYAxisEnd(GetHandleLength(TransformTypes.Move)), axisInfo.yDirection, axisInfo.xDirection, axisInfo.zDirection, triangleLength, handleTriangles.Y);
				AddTriangles(axisInfo.GetZAxisEnd(GetHandleLength(TransformTypes.Move)), axisInfo.zDirection, axisInfo.yDirection, axisInfo.xDirection, triangleLength, handleTriangles.Z);
			}
		}

		private void AddTriangles(Vector3 axisEnd, Vector3 axisDirection, Vector3 axisOtherDirection1, Vector3 axisOtherDirection2, float size, List<Vector3> resultsBuffer)
		{
			Vector3 endPoint = axisEnd + axisDirection * (size * 2f);
			Square baseSquare = GetBaseSquare(axisEnd, axisOtherDirection1, axisOtherDirection2, size / 2f);

			resultsBuffer.Add(baseSquare.bottomLeft);
			resultsBuffer.Add(baseSquare.topLeft);
			resultsBuffer.Add(baseSquare.topRight);
			resultsBuffer.Add(baseSquare.topLeft);
			resultsBuffer.Add(baseSquare.bottomRight);
			resultsBuffer.Add(baseSquare.topRight);

			for (int i = 0; i < 4; i++)
			{
				resultsBuffer.Add(baseSquare[i]);
				resultsBuffer.Add(baseSquare[i + 1]);
				resultsBuffer.Add(endPoint);
			}
		}

		private void SetHandleSquares()
		{
			handleSquares.Clear();

			if (TranslatingTypeContains(TransformTypes.Scale))
			{
				float size = BoxSize * GetDistanceMultiplier();
				AddSquares(axisInfo.GetXAxisEnd(GetHandleLength(TransformTypes.Scale, Axis.X)), axisInfo.xDirection, axisInfo.yDirection, axisInfo.zDirection, size, handleSquares.X);
				AddSquares(axisInfo.GetYAxisEnd(GetHandleLength(TransformTypes.Scale, Axis.Y)), axisInfo.yDirection, axisInfo.xDirection, axisInfo.zDirection, size, handleSquares.Y);
				AddSquares(axisInfo.GetZAxisEnd(GetHandleLength(TransformTypes.Scale, Axis.Z)), axisInfo.zDirection, axisInfo.xDirection, axisInfo.yDirection, size, handleSquares.Z);
				AddSquares(PivotPoint - axisInfo.xDirection * (size * .5f), axisInfo.xDirection, axisInfo.yDirection, axisInfo.zDirection, size, handleSquares.All);
			}
		}

		private void AddSquares(Vector3 axisStart, Vector3 axisDirection, Vector3 axisOtherDirection1, Vector3 axisOtherDirection2, float size, List<Vector3> resultsBuffer)
		{
			AddQuads(axisStart, axisDirection, axisOtherDirection1, axisOtherDirection2, size, size * .5f, resultsBuffer);
		}

		private void AddQuads(Vector3 axisStart, Vector3 axisDirection, Vector3 axisOtherDirection1, Vector3 axisOtherDirection2, float length, float width, List<Vector3> resultsBuffer)
		{
			Vector3 axisEnd = axisStart + axisDirection * length;
			AddQuads(axisStart, axisEnd, axisOtherDirection1, axisOtherDirection2, width, resultsBuffer);
		}

		private static void AddQuads(Vector3 axisStart, Vector3 axisEnd, Vector3 axisOtherDirection1, Vector3 axisOtherDirection2, float width, List<Vector3> resultsBuffer)
		{
			Square baseRectangle = GetBaseSquare(axisStart, axisOtherDirection1, axisOtherDirection2, width);
			Square baseRectangleEnd = GetBaseSquare(axisEnd, axisOtherDirection1, axisOtherDirection2, width);

			resultsBuffer.Add(baseRectangle.bottomLeft);
			resultsBuffer.Add(baseRectangle.topLeft);
			resultsBuffer.Add(baseRectangle.topRight);
			resultsBuffer.Add(baseRectangle.bottomRight);

			resultsBuffer.Add(baseRectangleEnd.bottomLeft);
			resultsBuffer.Add(baseRectangleEnd.topLeft);
			resultsBuffer.Add(baseRectangleEnd.topRight);
			resultsBuffer.Add(baseRectangleEnd.bottomRight);

			for (int i = 0; i < 4; i++)
			{
				resultsBuffer.Add(baseRectangle[i]);
				resultsBuffer.Add(baseRectangleEnd[i]);
				resultsBuffer.Add(baseRectangleEnd[i + 1]);
				resultsBuffer.Add(baseRectangle[i + 1]);
			}
		}

		private static void AddQuad(Vector3 axisStart, Vector3 axisOtherDirection1, Vector3 axisOtherDirection2, float width, List<Vector3> resultsBuffer)
		{
			Square baseRectangle = GetBaseSquare(axisStart, axisOtherDirection1, axisOtherDirection2, width);

			resultsBuffer.Add(baseRectangle.bottomLeft);
			resultsBuffer.Add(baseRectangle.topLeft);
			resultsBuffer.Add(baseRectangle.topRight);
			resultsBuffer.Add(baseRectangle.bottomRight);
		}

		private static Square GetBaseSquare(Vector3 axisEnd, Vector3 axisOtherDirection1, Vector3 axisOtherDirection2, float size)
		{
			Square square;
			Vector3 offsetUp = axisOtherDirection1 * size + axisOtherDirection2 * size;
			Vector3 offsetDown = axisOtherDirection1 * size - axisOtherDirection2 * size;
			//These might not really be the proper directions, as in the bottomLeft might not really be at the bottom left...
			square.bottomLeft = axisEnd + offsetDown;
			square.topLeft = axisEnd + offsetUp;
			square.bottomRight = axisEnd - offsetUp;
			square.topRight = axisEnd - offsetDown;
			return square;
		}

		private void SetCircles(AxisInfo axis, AxisVectors axisVectors)
		{
			axisVectors.Clear();

			if (TranslatingTypeContains(TransformTypes.Rotate))
			{
				float circleLength = GetHandleLength(TransformTypes.Rotate);
				AddCircle(PivotPoint, axis.xDirection, circleLength, axisVectors.X);
				AddCircle(PivotPoint, axis.yDirection, circleLength, axisVectors.Y);
				AddCircle(PivotPoint, axis.zDirection, circleLength, axisVectors.Z);
				AddCircle(PivotPoint, (PivotPoint - targetCamera.transform.position).normalized, circleLength, axisVectors.All, false);
			}
		}

		private void AddCircle(Vector3 origin, Vector3 axisDirection, float size, List<Vector3> resultsBuffer, bool depthTest = true)
		{
			Vector3 up = axisDirection.normalized * size;
			Vector3 forward = Vector3.Slerp(up, -up, .5f);
			Vector3 right = Vector3.Cross(up, forward).normalized * size;

			Matrix4x4 matrix = new Matrix4x4
			{
				[0] = right.x,
				[1] = right.y,
				[2] = right.z,

				[4] = up.x,
				[5] = up.y,
				[6] = up.z,

				[8] = forward.x,
				[9] = forward.y,
				[10] = forward.z
			};

			Vector3 lastPoint = origin + matrix.MultiplyPoint3x4(new Vector3(Mathf.Cos(0), 0, Mathf.Sin(0)));
			Vector3 nextPoint = Vector3.zero;
			float multiplier = 360f / circleDetail;

			Plane plane = new Plane((targetCamera.transform.position - PivotPoint).normalized, PivotPoint);

			float circleHandleWidth = HandleWidth * GetDistanceMultiplier();

			for (int i = 0; i < circleDetail + 1; i++)
			{
				nextPoint.x = Mathf.Cos(i * multiplier * Mathf.Deg2Rad);
				nextPoint.z = Mathf.Sin(i * multiplier * Mathf.Deg2Rad);
				nextPoint.y = 0;

				nextPoint = origin + matrix.MultiplyPoint3x4(nextPoint);

				if (!depthTest || plane.GetSide(lastPoint))
				{
					Vector3 centerPoint = (lastPoint + nextPoint) * .5f;
					Vector3 upDirection = (centerPoint - origin).normalized;
					AddQuads(lastPoint, nextPoint, upDirection, axisDirection, circleHandleWidth, resultsBuffer);
				}

				lastPoint = nextPoint;
			}
		}

		private Color GetGizmoColor(Axis currentAxis, Axis axis, bool transforming, Color color)
		{
			if (currentAxis == axis)
			{
				return transforming ? selectedColor : hoverColor;
			}

			return color;
		}

		void ILevelEditorGizmos.DrawLevelEditorGizmos(ILevelEditorGizmosDrawer drawer)
		{
			if (MainTargetRoot == null)
			{
				return;
			}

			Color colorX = GetGizmoColor(TranslatingAxis, Axis.X, IsTransforming, xColor);
			Color colorY = GetGizmoColor(TranslatingAxis, Axis.Y, IsTransforming, yColor);
			Color colorZ = GetGizmoColor(TranslatingAxis, Axis.Z, IsTransforming, zColor);
			Color colorAll = GetGizmoColor(TranslatingAxis, Axis.Any, IsTransforming, allColor);

			// Note: The order of drawing the axis decides what gets drawn over what.

			TransformTypes moveOrScaleType = transformType == TransformTypes.Scale || IsTransforming && TransformingType == TransformTypes.Scale ? TransformTypes.Scale : TransformTypes.Move;
			drawer.DrawQuads(handleLines.Z, GetColor(moveOrScaleType, zColor, colorZ, HasTranslatingAxisPlane));
			drawer.DrawQuads(handleLines.X, GetColor(moveOrScaleType, xColor, colorX, HasTranslatingAxisPlane));
			drawer.DrawQuads(handleLines.Y, GetColor(moveOrScaleType, yColor, colorY, HasTranslatingAxisPlane));

			drawer.DrawTriangles(handleTriangles.X, GetColor(TransformTypes.Move, xColor, colorX, HasTranslatingAxisPlane));
			drawer.DrawTriangles(handleTriangles.Y, GetColor(TransformTypes.Move, yColor, colorY, HasTranslatingAxisPlane));
			drawer.DrawTriangles(handleTriangles.Z, GetColor(TransformTypes.Move, zColor, colorZ, HasTranslatingAxisPlane));

			drawer.DrawQuads(handlePlanes.Z, GetColor(TransformTypes.Move, zColor, colorZ, planesOpacity, !HasTranslatingAxisPlane));
			drawer.DrawQuads(handlePlanes.X, GetColor(TransformTypes.Move, xColor, colorX, planesOpacity, !HasTranslatingAxisPlane));
			drawer.DrawQuads(handlePlanes.Y, GetColor(TransformTypes.Move, yColor, colorY, planesOpacity, !HasTranslatingAxisPlane));

			drawer.DrawQuads(handleSquares.X, GetColor(TransformTypes.Scale, xColor, colorX));
			drawer.DrawQuads(handleSquares.Y, GetColor(TransformTypes.Scale, yColor, colorY));
			drawer.DrawQuads(handleSquares.Z, GetColor(TransformTypes.Scale, zColor, colorZ));
			drawer.DrawQuads(handleSquares.All, GetColor(TransformTypes.Scale, allColor, colorAll));

			drawer.DrawQuads(circlesLines.All, GetColor(TransformTypes.Rotate, allColor, colorAll));
			drawer.DrawQuads(circlesLines.X, GetColor(TransformTypes.Rotate, xColor, colorX));
			drawer.DrawQuads(circlesLines.Y, GetColor(TransformTypes.Rotate, yColor, colorY));
			drawer.DrawQuads(circlesLines.Z, GetColor(TransformTypes.Rotate, zColor, colorZ));
		}
	}
}