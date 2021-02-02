using Newtonsoft.Json;
using System;
using UnityEngine;

namespace Hertzole.ALE
{
    public class ComponentConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Component) || objectType.IsSubclassOf(typeof(Component));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            int? value = reader.ReadAsInt32();
            return value == null ? 0 : (object)(int)value;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            if (value is Component comp)
            {
                if (comp == null)
                {
                    writer.WriteNull();
                }
                else if (comp.TryGetComponent(out ILevelEditorObject aleObj))
                {
                    writer.WriteValue(aleObj.InstanceID);
                }
            }
            else
            {
                writer.WriteNull();
            }
        }
    }
}
