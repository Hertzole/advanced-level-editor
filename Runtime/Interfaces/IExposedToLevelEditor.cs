using System;

namespace Hertzole.ALE
{
    public interface IExposedToLevelEditor
    {
        string ComponentName { get; }
        string TypeName { get; }

        int Order { get; }

        event Action<int, object> OnValueChanged;

        ExposedProperty[] GetProperties();

        object GetValue(int id);

        void SetValue(int id, object value, bool notify);

        Type GetValueType(int id);
    }
}
