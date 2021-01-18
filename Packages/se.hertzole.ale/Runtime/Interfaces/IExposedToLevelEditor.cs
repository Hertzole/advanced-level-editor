using System;

namespace Hertzole.ALE
{
    public interface IExposedToLevelEditor
    {
        string ComponentName { get; }
        string TypeName { get; }

        int Order { get; }

        event Action<string, object> OnValueChanged;

        ExposedProperty[] GetProperties();

        object GetValue(string valueName);

        void SetValue(string valueName, object value, bool notify);

        Type GetValueType(string valueName);
    }
}
