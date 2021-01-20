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
        private struct TypeAndArray : IEquatable<TypeAndArray>
        {
            public Type type;
            public bool isArray;

            public TypeAndArray(ExposedProperty property)
            {
                type = property.type;
                isArray = property.isArray;
            }

            public override bool Equals(object obj)
            {
                return obj is TypeAndArray array && Equals(array);
            }

            public bool Equals(TypeAndArray other)
            {
                return isArray == other.isArray && type.Equals(other.type);
            }

            public override int GetHashCode()
            {
                int hashCode = -2098479445;
                hashCode = hashCode * -1521134295 + EqualityComparer<Type>.Default.GetHashCode(type);
                hashCode = hashCode * -1521134295 + isArray.GetHashCode();
                return hashCode;
            }
        }

        [SerializeField]
        private GameObject objectInfoHolder = null;
        [SerializeField]
        private Toggle objectActiveToggle = null;
        [SerializeField]
        private TMP_InputField objectNameField = null;

        [Space]

        [SerializeField]
        private RectTransform content = null;
        [SerializeField]
        private LevelEditorComponentUI componentPrefab = null;
        [SerializeField]
        private LevelEditorInspectorField[] fieldPrefabs = null;

        private ILevelEditorObject boundItem;

        private List<LevelEditorComponentUI> activeComponents = new List<LevelEditorComponentUI>();
        private Stack<LevelEditorComponentUI> pooledComponents = new Stack<LevelEditorComponentUI>();

        private Dictionary<TypeAndArray, int> fields = new Dictionary<TypeAndArray, int>();
        private Dictionary<int, Stack<LevelEditorInspectorField>> pooledFields = new Dictionary<int, Stack<LevelEditorInspectorField>>();
        //private Dictionary<int, List<LevelEditorInspectorField>> activeFields = new Dictionary<int, List<LevelEditorInspectorField>>();
        private List<LevelEditorInspectorField> activeFields = new List<LevelEditorInspectorField>();

        protected virtual void Awake()
        {
#if OBSOLETE
            Debug.LogError($"{gameObject.name} is still using {nameof(LevelEditorInspector)} and it will be stripped on build. Remove it.");
#endif
            objectNameField.onValueChanged.AddListener(OnObjectNameFieldChanged);
            objectActiveToggle.onValueChanged.AddListener(OnObjectActiveToggleChanged);
            objectInfoHolder.SetActive(false);
        }

        public void Initialize()
        {

        }

        private void OnObjectNameFieldChanged(string newName)
        {
            if (boundItem != null)
            {
                boundItem.MyGameObject.name = newName;
            }
        }

        private void OnObjectActiveToggleChanged(bool isActive)
        {
            if (boundItem != null)
            {
                boundItem.MyGameObject.SetActive(isActive);
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

            objectInfoHolder.SetActive(target != null);

            if (target != null)
            {
                objectActiveToggle.SetIsOnWithoutNotify(target.MyGameObject.activeSelf);
                objectNameField.SetTextWithoutNotify(target.MyGameObject.name);
                IExposedToLevelEditor[] components = target.GetExposedComponents();
                for (int i = 0; i < components.Length; i++)
                {
                    LevelEditorComponentUI compUI = GetComponentUI();
                    compUI.Title = components[i].ComponentName;

                    ExposedProperty[] properties = components[i].GetProperties();
                    for (int j = 0; j < properties.Length; j++)
                    {
                        if (!properties[j].visible)
                        {
                            continue;
                        }

                        if (!HasField(properties[j]))
                        {
                            continue;
                        }

                        LevelEditorInspectorField field = GetField(properties[j], compUI.FieldHolder);
                        field.Bind(properties[j], components[i]);
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

        public LevelEditorInspectorField GetField(ExposedProperty property, Transform parent)
        {
            LevelEditorInspectorField result = null;

            TypeAndArray type = new TypeAndArray(property);

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
                    result.Index = fieldIndex;
                }
            }
            else
            {
                for (int i = 0; i < fieldPrefabs.Length; i++)
                {
                    if (fieldPrefabs[i].SupportsType(property))
                    {
                        fields.Add(type, i);
                        if (!pooledFields.ContainsKey(i))
                        {
                            pooledFields.Add(i, new Stack<LevelEditorInspectorField>());
                        }

                        result = Instantiate(fieldPrefabs[i], parent);
                        result.Index = i;
                        break;
                    }
                }
            }

            if (result == null)
            {
                Debug.LogWarning("No field that supports " + property.type.FullName + (property.isArray ? "[]" : ""));
                return null;
            }

            activeFields.Add(result);

            result.gameObject.SetActive(true);
            result.transform.SetAsLastSibling();
            return result;
        }

        public void PoolField(LevelEditorInspectorField field)
        {
            pooledFields[field.Index].Push(field);
            activeFields.Remove(field);

            field.gameObject.SetActive(false);
        }

        public bool HasField(ExposedProperty property)
        {
            TypeAndArray type = new TypeAndArray(property);

            if (fields.ContainsKey(type))
            {
                return true;
            }
            else
            {
                for (int i = 0; i < fieldPrefabs.Length; i++)
                {
                    if (fieldPrefabs[i].SupportsType(property))
                    {
                        fields.Add(type, i);
                        if (!pooledFields.ContainsKey(i))
                        {
                            pooledFields.Add(i, new Stack<LevelEditorInspectorField>());
                        }

                        return true;
                    }
                }
            }

            Debug.LogWarning("No field that supports " + property.type.FullName + (property.isArray ? "[]" : ""));

            return false;
        }
    }
}
#endif
