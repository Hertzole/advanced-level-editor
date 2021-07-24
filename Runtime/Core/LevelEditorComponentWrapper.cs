using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Hertzole.ALE
{
    public abstract class LevelEditorComponentWrapper : MonoBehaviour, IExposedToLevelEditor
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetStatics()
        {
            wrappers = new Dictionary<Type, Type>();
        }

        internal static Dictionary<Type, Type> wrappers;

        public static bool TryGetWrapper(Type type, out Type wrapper)
        {
            return wrappers.TryGetValue(type, out wrapper);
        }

        public static bool HasWrapper<T>()
        {
            return wrappers.ContainsKey(typeof(T));
        }

        public static void RegisterWrapper<TType, TWrapper>() where TType : Component where TWrapper : LevelEditorComponentWrapper
        {
            wrappers[typeof(TType)] = typeof(TWrapper);
        }

        public static void AddWrappers(GameObject target)
        {
            foreach (KeyValuePair<Type, Type> wrapper in wrappers)
            {
                if (target.GetComponent(wrapper.Key) != null)
                {
                    target.AddComponent(wrapper.Value);
                }
            }
        }

        public virtual string ComponentName { get { throw new NotImplementedException(); } }
        public virtual string TypeName { get { throw new NotImplementedException(); } }
        public virtual int Order { get { return 0; } }
        public virtual Type ComponentType { get { return null; } }
        public abstract bool HasVisibleFields { get; }

        public event Action<int, object> OnValueChanged;

        public abstract ReadOnlyCollection<ExposedProperty> GetProperties();
        public abstract object GetValue(int id);
        public abstract void SetValue(int id, object value, bool notify);
        public abstract IExposedWrapper GetWrapper();
        public abstract void ApplyWrapper(IExposedWrapper wrapper, bool ignoreDirtyMask = false);

        protected void InvokeOnValueChanged(int id, object value)
        {
            OnValueChanged?.Invoke(id, value);
        }
    }

    public abstract class LevelEditorComponentWrapper<T> : LevelEditorComponentWrapper where T : Component
    {
        private ILevelEditorObject levelEditorObject;
        protected ILevelEditorObject LevelEditorObject
        {
            get
            {
                if (levelEditorObject == null)
                {
                    levelEditorObject = GetComponent<LevelEditorObject>();
                }

                return levelEditorObject;
            }
        }

        private T target;
        protected T Target
        {
            get
            {
                if (target == null)
                {
                    target = GetComponent<T>();
                }

                return target;
            }
        }

        public override string ComponentName { get { return typeof(T).Name; } }
        public override string TypeName { get { return typeof(T).FullName; } }
        public override Type ComponentType { get { return typeof(T); } }
    }
}
