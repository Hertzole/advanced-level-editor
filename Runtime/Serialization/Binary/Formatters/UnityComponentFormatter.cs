using System.IO;
using UnityEngine;

namespace Hertzole.ALE
{
    public class UnityComponentFormatter : BaseFormatter
    {
        public override string TypeName { get { return typeof(Component).FullName; } }

        public override void Serialize(object value, BinaryWriter writer)
        {
            if (value == null)
            {
                writer.Write(0);
                return;
            }

            if (value is Component comp && comp.TryGetComponent(out ILevelEditorObject obj))
            {
                writer.Write(obj.InstanceID);
            }
            else
            {
                Debug.LogError(value + " is not a valid Unity component to save. It needs to derive from UnityEngine.Component and have a ALE_Object component attached.");
            }
        }

        public override object DeserializeValue(BinaryReader reader)
        {
            return reader.ReadInt32();
        }
    }
}
