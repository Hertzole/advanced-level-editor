#if ALE_JSON
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Hertzole.ALE
{
    public static partial class LevelEditorExtensions
    {
        public static T GetValue<T>(this JToken token, string name, T defaultValue)
        {
            return token[name] != null ? token[name].ToObject<T>() : defaultValue;
        }

        public static T GetValue<T>(this JToken token, string name, T defaultValue, JsonSerializer serializer)
        {
            return token[name] != null ? token[name].ToObject<T>(serializer) : defaultValue;
        }

        public static object GetValue(this JToken token, Type type, string name, object defaultValue)
        {
            return token[name] != null ? token[name].ToObject(type) : defaultValue;
        }

        public static object GetValue(this JToken token, Type type, string name, object defaultValue, JsonSerializer serializer)
        {
            return token[name] != null ? token[name].ToObject(type, serializer) : defaultValue;
        }
    }
}
#endif
