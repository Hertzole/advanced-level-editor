using System;
using System.Collections.Generic;

namespace Hertzole.ALE
{
    public interface IExposedToLevelEditor
    {
        string ComponentName { get; }
        string TypeName { get; }
        Type ComponentType { get; }
        bool HasVisibleFields { get; }

        int Order { get; }

        event Action<int, object> OnValueChanging;
        event Action<int, object> OnValueChanged;

        IReadOnlyList<ExposedField> GetProperties();

        object GetValue(int id);

        void BeginEdit(int id);

        void ModifyValue(object value, bool notify);

        void EndEdit(bool notify, ILevelEditorUndo undo);

        IExposedWrapper GetWrapper();

        void ApplyWrapper(IExposedWrapper wrapper, bool ignoreDirtyMask = false);
    }
}
