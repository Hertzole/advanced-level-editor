using System;
using System.Collections.ObjectModel;

namespace Hertzole.ALE
{
    public interface IExposedToLevelEditor
    {
        string ComponentName { get; }
        string TypeName { get; }
        Type ComponentType { get; }
        bool HasVisibleFields { get; }

        int Order { get; }

        event Action<int, object> OnValueChanged;

        ReadOnlyCollection<ExposedProperty> GetProperties();

        object GetValue(int id);

        void SetValue(int id, object value, bool notify);

        Type GetValueType(int id);

        IExposedWrapper GetWrapper();
    }
}
