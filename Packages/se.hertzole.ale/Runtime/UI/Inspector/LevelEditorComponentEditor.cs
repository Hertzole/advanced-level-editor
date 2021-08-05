using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Hertzole.ALE
{
    public abstract class LevelEditorComponentEditor
    {
#if UNITY_EDITOR
        public ILevelEditorInspector Inspector { get; set; }
#else
        [NonSerialized]
        public ILevelEditorInspector Inspector;
#endif

        private IReadOnlyList<ExposedField> exposedProperties;
        private RectTransform content;

        protected Component TargetComponent { get; private set; }
        protected IExposedToLevelEditor Exposed { get; private set; }

        private readonly static Dictionary<Type, LevelEditorComponentEditor> editors = new Dictionary<Type, LevelEditorComponentEditor>();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetStatics()
        {
            editors.Clear();
        }

        public static bool TryGetEditor(Type type, out LevelEditorComponentEditor editor)
        {
            return editors.TryGetValue(type, out editor);
        }

        public static void AddEditor<TType, TEditor>() where TType : Component where TEditor : LevelEditorComponentEditor
        {
            editors.Add(typeof(TType), Activator.CreateInstance<TEditor>());
        }

        public void Initialize(ILevelEditorInspector inspector, Component target, IExposedToLevelEditor exposed, RectTransform content)
        {
            Inspector = inspector;
            TargetComponent = target;
            Exposed = exposed;
            this.content = content;

            exposedProperties = exposed.GetProperties();
        }

        public virtual bool SupportsType(Type type)
        {
            return false;
        }

        protected ExposedField GetProperty(string name)
        {
            for (int i = 0; i < exposedProperties.Count; i++)
            {
                if (exposedProperties[i].Name == name)
                {
                    return exposedProperties[i];
                }
            }

            throw new ArgumentException($"There's no property with the name '{name}'.", nameof(name));
        }

        protected ExposedField GetProperty(int id)
        {
            for (int i = 0; i < exposedProperties.Count; i++)
            {
                if (exposedProperties[i].ID == id)
                {
                    return exposedProperties[i];
                }
            }

            throw new ArgumentException($"There's no property with the ID '{id}'.", nameof(id));
        }

        protected bool TryGetField<T>(ExposedField property, out LevelEditorInspectorField field)
        {
            if (Inspector.HasField(typeof(T)))
            {
                field = Inspector.GetField(typeof(T), content);
                field.Bind(property, Exposed);
                return true;
            }
            else
            {
                field = null;
                return false;
            }
        }

        protected bool TryGetField<T>(ExposedProperty property, string label, out LevelEditorInspectorField field)
        {
            if (TryGetField<T>(property, out field))
            {
                field.Label = label;
                return true;
            }
            else
            {
                return false;
            }
        }

        protected LevelEditorInspectorField GetField<T>(ExposedProperty property)
        {
            if (TryGetField<T>(property, out LevelEditorInspectorField field))
            {
                return field;
            }

            throw new ArgumentException($"There's no InspectorField that supports type '{typeof(T).FullName}'.");
        }

        protected LevelEditorInspectorField GetField<T>(ExposedProperty property, string label)
        {
            LevelEditorInspectorField field = GetField<T>(property);
            field.Label = label;

            return field;
        }

        protected void AddField<T>(ExposedProperty property)
        {
            GetField<T>(property);
        }

        protected void AddField<T>(ExposedProperty property, string label)
        {
            GetField<T>(property, label);
        }

        protected bool TryAddField<T>(ExposedProperty property)
        {
            return TryGetField<T>(property, out _);
        }

        protected bool TryAddField<T>(ExposedProperty property, string label)
        {
            return TryGetField<T>(property, label, out _);
        }

        public abstract void BuildUI();
    }

    public abstract class LevelEditorComponentEditor<T> : LevelEditorComponentEditor where T : Component
    {
        public T Target { get { return (T)TargetComponent; } }

        protected virtual bool InheritEditor { get { return false; } }

        public override bool SupportsType(Type type)
        {
            return InheritEditor ? type == typeof(T) || type.IsSubclassOf(typeof(T)) : type == typeof(T);
        }
    }
}
