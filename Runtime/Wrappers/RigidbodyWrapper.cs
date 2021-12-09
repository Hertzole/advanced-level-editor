using System;
using System.Collections.Generic;
using MessagePack;
using UnityEngine;

namespace Hertzole.ALE
{
	public class RigidbodyWrapper : LevelEditorComponentWrapper<Rigidbody>, ILevelEditorPlayModeObject
	{
		private bool isKinematic;

		private bool useGravity;

		private readonly ExposedField[] cachedProperties =
		{
			new ExposedProperty(MASS_ID, typeof(float), "mass", null, true),
			new ExposedProperty(DRAG_ID, typeof(float), "drag", null, true),
			new ExposedProperty(ANGULAR_DRAG_ID, typeof(float), "angularDrag", null, true),
			new ExposedProperty(USE_GRAVITY_ID, typeof(bool), "useGravity", null, true),
			new ExposedProperty(IS_KINEMATIC_ID, typeof(bool), "isKinematic", null, true)
		};

		private int editingId;

		private object beginEditValue;
		private object lastEditValue;

		public override bool HasVisibleFields { get { return true; } }

		private const int MASS_ID = 0;
		private const int DRAG_ID = 1;
		private const int ANGULAR_DRAG_ID = 2;
		private const int USE_GRAVITY_ID = 3;
		private const int IS_KINEMATIC_ID = 4;

		private void Awake()
		{
			useGravity = Target.useGravity;
			isKinematic = Target.isKinematic;

			Target.useGravity = false;
			Target.isKinematic = true;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void RegisterRigidbodyWrapper()
		{
			LevelEditorSerializer.RegisterType<Rigidbody>();

			if (ALESettings.Get().ApplyRigidbodyWrapper)
			{
				RegisterWrapper<Rigidbody, RigidbodyWrapper>();
			}
		}

		public override IReadOnlyList<ExposedField> GetProperties()
		{
			return cachedProperties;
		}

		public override object GetValue(int id)
		{
			switch (id)
			{
				case MASS_ID:
					return Target.mass;
				case DRAG_ID:
					return Target.drag;
				case ANGULAR_DRAG_ID:
					return Target.angularDrag;
				case USE_GRAVITY_ID:
					return useGravity;
				case IS_KINEMATIC_ID:
					return isKinematic;
				default:
					throw new ArgumentException($"There's no exposed field with the ID '{id}'.");
			}
		}

		public override void BeginEdit(int id)
		{
			editingId = id;
			switch (id)
			{
				case MASS_ID:
					beginEditValue = Target.mass;
					break;
				case DRAG_ID:
					beginEditValue = Target.drag;
					break;
				case ANGULAR_DRAG_ID:
					beginEditValue = Target.angularDrag;
					break;
				case USE_GRAVITY_ID:
					beginEditValue = useGravity;
					break;
				case IS_KINEMATIC_ID:
					beginEditValue = isKinematic;
					break;
				default:
					throw new InvalidExposedPropertyException(id);
			}
		}

		public override void ModifyValue(object value, bool notify)
		{
			bool changed = false;

			switch (editingId)
			{
				case MASS_ID:
					if (Mathf.Abs((float) value - Target.mass) > 0.0001f)
					{
						Target.mass = (float) value;
						changed = true;
						lastEditValue = Target.mass;
					}

					break;
				case DRAG_ID:
					if (Mathf.Abs((float) value - Target.drag) > 0.0001f)
					{
						Target.drag = (float) value;
						changed = true;
						lastEditValue = Target.drag;
					}

					break;
				case ANGULAR_DRAG_ID:
					if (Mathf.Abs((float) value - Target.angularDrag) > 0.0001f)
					{
						Target.angularDrag = (float) value;
						changed = true;
						lastEditValue = Target.angularDrag;
					}

					break;
				case USE_GRAVITY_ID:
					if ((bool) value != useGravity)
					{
						useGravity = (bool) value;
						changed = true;
						lastEditValue = useGravity;
					}

					break;
				case IS_KINEMATIC_ID:
					if ((bool) value != isKinematic)
					{
						isKinematic = (bool) value;
						changed = true;
						lastEditValue = isKinematic;
					}

					break;
				default:
					throw new InvalidExposedPropertyException(editingId);
			}

			if (notify && changed)
			{
				InvokeOnValueChanging(editingId, value);
			}
		}

		public override void EndEdit(bool notify, ILevelEditorUndo undo)
		{
			if (notify)
			{
				InvokeOnValueChanged(editingId, lastEditValue);
			}

			if (undo != null)
			{
				undo.AddAction(new SetValueUndoAction(this, editingId, beginEditValue, lastEditValue));
			}
		}

		public override IExposedWrapper GetWrapper()
		{
			return new Wrapper(Target.mass, Target.drag, Target.angularDrag, Target.useGravity, Target.isKinematic, false);
		}

		public override void ApplyWrapper(IExposedWrapper wrapper, bool ignoreDirtyMask = false)
		{
			if (wrapper is Wrapper w)
			{
				if (ignoreDirtyMask || w.IsDirty(MASS_ID))
				{
					Target.mass = w.GetValue<float>(MASS_ID);
				}

				if (ignoreDirtyMask || w.IsDirty(DRAG_ID))
				{
					Target.drag = w.GetValue<float>(DRAG_ID);
				}

				if (ignoreDirtyMask || w.IsDirty(ANGULAR_DRAG_ID))
				{
					Target.angularDrag = w.GetValue<float>(ANGULAR_DRAG_ID);
				}

				if (ignoreDirtyMask || w.IsDirty(USE_GRAVITY_ID))
				{
					Target.useGravity = w.GetValue<bool>(USE_GRAVITY_ID);
				}

				if (ignoreDirtyMask || w.IsDirty(IS_KINEMATIC_ID))
				{
					Target.isKinematic = w.GetValue<bool>(IS_KINEMATIC_ID);
				}
			}
		}

		void ILevelEditorPlayModeObject.OnStartPlayMode()
		{
			Target.useGravity = useGravity;
			Target.isKinematic = isKinematic;
		}

		void ILevelEditorPlayModeObject.OnStopPlayMode()
		{
			Target.useGravity = false;
			Target.isKinematic = true;
		}

		public struct Wrapper : IExposedWrapper, IEquatable<Wrapper>
		{
			public Dictionary<int, object> Values { get; set; }
			public Dictionary<int, bool> Dirty { get; set; }

			public Wrapper(float mass, float drag, float angularDrag, bool useGravity, bool isKinematic, bool isDirty)
			{
				Values = new Dictionary<int, object>(5)
				{
					{ MASS_ID, mass },
					{ DRAG_ID, drag },
					{ ANGULAR_DRAG_ID, angularDrag },
					{ USE_GRAVITY_ID, useGravity },
					{ IS_KINEMATIC_ID, isKinematic }
				};

				Dirty = new Dictionary<int, bool>(5)
				{
					{ MASS_ID, isDirty },
					{ DRAG_ID, isDirty },
					{ ANGULAR_DRAG_ID, isDirty },
					{ USE_GRAVITY_ID, isDirty },
					{ IS_KINEMATIC_ID, isDirty }
				};
			}

			public bool Equals(Wrapper other)
			{
				return Values.DictionaryEquals(other.Values);
			}

			public override bool Equals(object obj)
			{
				return obj is Wrapper other && Equals(other);
			}

			public override int GetHashCode()
			{
				return Values.GetHashCode();
			}

			public static bool operator ==(Wrapper left, Wrapper right)
			{
				return left.Equals(right);
			}

			public static bool operator !=(Wrapper left, Wrapper right)
			{
				return !left.Equals(right);
			}

			public void Serialize(int id, ref MessagePackWriter writer, MessagePackSerializerOptions options)
			{
				switch (id)
				{
					case MASS_ID:
						writer.Write((float) Values[MASS_ID]);
						break;
					case DRAG_ID:
						writer.Write((float) Values[DRAG_ID]);
						break;
					case ANGULAR_DRAG_ID:
						writer.Write((float) Values[ANGULAR_DRAG_ID]);
						break;
					case USE_GRAVITY_ID:
						writer.Write((bool) Values[USE_GRAVITY_ID]);
						break;
					case IS_KINEMATIC_ID:
						writer.Write((bool) Values[IS_KINEMATIC_ID]);
						break;
				}
			}

			public object Deserialize(int id, ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				switch (id)
				{
					case MASS_ID:
						return reader.ReadSingle();
					case DRAG_ID:
						return reader.ReadSingle();
					case ANGULAR_DRAG_ID:
						return reader.ReadSingle();
					case USE_GRAVITY_ID:
						return reader.ReadBoolean();
					case IS_KINEMATIC_ID:
						return reader.ReadBoolean();
				}

				return default;
			}
		}
	}
}