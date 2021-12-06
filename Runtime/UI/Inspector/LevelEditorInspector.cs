#if ALE_STRIP_UGUI
#define OBSOLETE
#endif

#if OBSOLETE && !UNITY_EDITOR
#define STRIP
#endif

#if !STRIP
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
#if ALE_LOCALIZATION
using UnityEngine.Localization;
#endif

namespace Hertzole.ALE
{
#if UNITY_EDITOR
	[DisallowMultipleComponent]
#if !OBSOLETE
	[AddComponentMenu("ALE/UI/uGUI/Inspector", 10)]
#else
    [System.Obsolete("LevelEditorInspector will be stripped on build.", true)]
#endif
#endif
	public class LevelEditorInspector : MonoBehaviour, ILevelEditorInspector
	{
		private readonly struct TypeAndArray : IEquatable<TypeAndArray>
		{
			public readonly Type type;
			public readonly bool isArray;

			public TypeAndArray(Type type, bool isArray)
			{
				this.type = type;
				this.isArray = isArray;
			}

			public override bool Equals(object obj)
			{
				return obj is TypeAndArray array && Equals(array);
			}

			public bool Equals(TypeAndArray other)
			{
				return isArray == other.isArray && type == other.type;
			}

			public override int GetHashCode()
			{
				int hashCode = -2098479445;
				hashCode = hashCode * -1521134295 + EqualityComparer<Type>.Default.GetHashCode(type);
				hashCode = hashCode * -1521134295 + isArray.GetHashCode();
				return hashCode;
			}
		}

		[Header("References")]
		[SerializeField]
		private GameObject levelEditor;

		[Space]
		[SerializeField]
		private GameObject objectInfoHolder;
		[SerializeField]
		private Toggle objectActiveToggle;
		[SerializeField]
		private TMP_InputField objectNameField;

		[Space]
		[SerializeField]
		private RectTransform content;
		[SerializeField]
		private LevelEditorComponentUI componentPrefab;
		[SerializeField]
		private LevelEditorInspectorField[] fieldPrefabs;

		[Header("Settings")]
		[SerializeField]
		private bool includeTransform = true;

#if ALE_LOCALIZATION
		[Header("Localization")]
		[SerializeField]
		private LocalizedInspectorField[] localizedInspectorFields;
#endif

		private ILevelEditorObject boundItem;
		
		public ILevelEditor LevelEditor { get; private set; }

		private readonly List<LevelEditorComponentUI> activeComponents = new List<LevelEditorComponentUI>();
		private readonly Stack<LevelEditorComponentUI> pooledComponents = new Stack<LevelEditorComponentUI>();

		private readonly Dictionary<TypeAndArray, int> fields = new Dictionary<TypeAndArray, int>();
		private readonly Dictionary<int, Stack<LevelEditorInspectorField>> pooledFields = new Dictionary<int, Stack<LevelEditorInspectorField>>();
		//private Dictionary<int, List<LevelEditorInspectorField>> activeFields = new Dictionary<int, List<LevelEditorInspectorField>>();
		private readonly List<LevelEditorInspectorField> activeFields = new List<LevelEditorInspectorField>();

		GameObject ILevelEditorPanel.MyGameObject { get { return gameObject; } }

		protected virtual void Awake()
		{
#if OBSOLETE
            Debug.LogError($"{gameObject.name} is still using {nameof(LevelEditorInspector)} and it will be stripped on build. Remove it.");
#endif
			if (objectNameField != null)
			{
				objectNameField.onValueChanged.AddListener(OnObjectNameFieldChanged);
			}

			if (objectActiveToggle != null)
			{
				objectActiveToggle.onValueChanged.AddListener(OnObjectActiveToggleChanged);
			}

			if (objectInfoHolder != null)
			{
				objectInfoHolder.SetActive(false);
			}

			if (levelEditor != null)
			{
				LevelEditor = levelEditor.NeedComponent<ILevelEditor>();
			}
		}

		private void OnObjectNameFieldChanged(string newName)
		{
			if (boundItem != null)
			{
				boundItem.Name = newName;
			}
		}

		private void OnObjectActiveToggleChanged(bool isActive)
		{
			if (boundItem != null)
			{
				boundItem.IsActive = isActive;
			}
		}

		public void BindObject(ILevelEditorObject target)
		{
			boundItem = target;

			for (int i = activeFields.Count - 1; i >= 0; i--)
			{
				PoolField(activeFields[i]);
			}

			for (int i = 0; i < activeComponents.Count; i++)
			{
				pooledComponents.Push(activeComponents[i]);
				activeComponents[i].gameObject.SetActive(false);
			}

			activeComponents.Clear();

			if (objectInfoHolder != null)
			{
				objectInfoHolder.SetActive(target != null);
			}

			if (target != null)
			{
				if (objectActiveToggle != null)
				{
					objectActiveToggle.SetIsOnWithoutNotify(target.MyGameObject.activeSelf);
				}

				if (objectNameField != null)
				{
					objectNameField.SetTextWithoutNotify(target.MyGameObject.name);
				}

				IExposedToLevelEditor[] components = target.GetExposedComponents();
				for (int i = 0; i < components.Length; i++)
				{
					if (!components[i].HasVisibleFields)
					{
						continue;
					}

					if (!includeTransform && components[i].ComponentType == typeof(Transform))
					{
						continue;
					}

					LevelEditorComponentUI compUI = GetComponentUI();
					compUI.Title = components[i].ComponentName;

					if (LevelEditorComponentEditor.TryGetEditor(components[i].ComponentType, out LevelEditorComponentEditor editor))
					{
						editor.Initialize(this, (Component) components[i], components[i], compUI.FieldHolder);
						editor.BuildUI();
					}
					else
					{
						IReadOnlyList<ExposedField> properties = components[i].GetProperties();
						for (int j = 0; j < properties.Count; j++)
						{
							if (!properties[j].IsVisible)
							{
								continue;
							}

							if (!HasField(properties[j].Type))
							{
								continue;
							}

							LevelEditorInspectorField field = GetField(properties[j].Type, compUI.FieldHolder);
							field.Depth = 0;
							field.Bind(properties[j], components[i]);
						}
					}
				}
			}
		}

		private LevelEditorComponentUI GetComponentUI()
		{
			LevelEditorComponentUI result = pooledComponents.Count > 0 ? pooledComponents.Pop() : Instantiate(componentPrefab, content);

			result.transform.SetAsLastSibling();
			result.gameObject.SetActive(true);

			activeComponents.Add(result);

			return result;
		}

		public LevelEditorInspectorField GetField(Type fieldType, Transform parent)
		{
			LevelEditorInspectorField result = null;

			TypeAndArray type = new TypeAndArray(fieldType, fieldType.IsArray);

			if (fields.TryGetValue(type, out int fieldIndex))
			{
				if (pooledFields[fieldIndex].Count > 0)
				{
					result = pooledFields[fieldIndex].Pop();
					result.transform.SetParent(parent);
				}
				else
				{
					result = Instantiate(fieldPrefabs[fieldIndex], parent);
					result.UI = LevelEditor.UI;
					result.Index = fieldIndex;
				}
			}
			else
			{
				int selectedIndex = -1;

				for (int i = 0; i < fieldPrefabs.Length; i++)
				{
					if (fieldPrefabs[i].SupportsTypeDirect(fieldType))
					{
						selectedIndex = i;
						break;
					}

					if (fieldPrefabs[i].SupportsType(fieldType, fieldType.IsArray))
					{
						selectedIndex = i;
					}
				}

				if (selectedIndex >= 0)
				{
					fields.Add(type, selectedIndex);
					if (!pooledFields.ContainsKey(selectedIndex))
					{
						pooledFields.Add(selectedIndex, new Stack<LevelEditorInspectorField>());
					}

					result = Instantiate(fieldPrefabs[selectedIndex], parent);
					result.Index = selectedIndex;
				}
			}

			if (result == null)
			{
				Debug.LogWarning("No field that supports " + fieldType.FullName);
				return null;
			}

			activeFields.Add(result);

			result.gameObject.SetActive(true);
			result.transform.SetAsLastSibling();
			return result;
		}

		public void PoolField(LevelEditorInspectorField field)
		{
			field.Unbind();

			pooledFields[field.Index].Push(field);
			activeFields.Remove(field);

			field.gameObject.SetActive(false);
		}

		public bool HasField(Type type)
		{
			TypeAndArray typeAndArray = new TypeAndArray(type, type.IsArray);

			if (fields.ContainsKey(typeAndArray))
			{
				return true;
			}

			int foundIndex = -1;

			for (int i = 0; i < fieldPrefabs.Length; i++)
			{
#if !ALE_STRIP_SAFETY || UNITY_EDITOR
				if (fieldPrefabs[i] == null)
				{
					throw new UnassignedReferenceException($"Field {i} has not been assigned on the level editor inspector.");
				}
#endif

				if (fieldPrefabs[i].SupportsTypeDirect(type))
				{
					foundIndex = i;
					break;
				}

				if (fieldPrefabs[i].SupportsType(type, type.IsArray))
				{
					foundIndex = i;
				}
			}

			if (foundIndex >= 0)
			{
				fields.Add(typeAndArray, foundIndex);
				if (!pooledFields.ContainsKey(foundIndex))
				{
					pooledFields.Add(foundIndex, new Stack<LevelEditorInspectorField>());
				}

				return true;
			}

			Debug.LogWarning("No field that supports " + type.FullName);

			return false;
		}

#if ALE_LOCALIZATION
		public virtual LocalizedString GetLocalizedInspectorField(string key)
		{
			for (int i = 0; i < localizedInspectorFields.Length; i++)
			{
				if (localizedInspectorFields[i].key == key)
				{
					return localizedInspectorFields[i].value;
				}
			}

			Debug.LogWarning($"No localized string for {key}");
			return null;
		}
#endif
	}
}
#endif