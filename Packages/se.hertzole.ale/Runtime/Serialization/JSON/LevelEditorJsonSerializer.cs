using Hertzole.ALE.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
    public static class LevelEditorJsonSerializer
    {
#if UNITY_2019_3_OR_NEWER
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetStatics()
        {
            typeMap = new Dictionary<string, Type>();
            converters = new List<JsonConverter>();
        }
#endif

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void InitializeTypes()
        {
            AddType<bool>();
            AddType<byte>();
            AddType<sbyte>();
            AddType<short>();
            AddType<ushort>();
            AddType<int>();
            AddType<uint>();
            AddType<long>();
            AddType<ulong>();
            AddType<float>();
            AddType<double>();
            AddType<decimal>();
            AddType<char>();
            AddType<string>();
            AddType<Vector2>();
            AddType<Vector2Int>();
            AddType<Vector3>();
            AddType<Vector3Int>();
            AddType<Vector4>();
            AddType<Quaternion>();
            AddType<Color>();
            AddType<Color32>();
            AddType<Rect>();
            AddType<Component>();

            AddConverter(new Vector2Converter());
            AddConverter(new Vector2IntConverter());
            AddConverter(new Vector3Converter());
            AddConverter(new Vector3IntConverter());
            AddConverter(new Vector4Converter());
            AddConverter(new QuaternionConverter());
            AddConverter(new RectConverter());
            AddConverter(new ColorConverter());
            AddConverter(new Color32Converter());
            AddConverter(new ComponentConverter());
        }

        private static List<JsonConverter> converters;

        private static Dictionary<string, Type> typeMap;

        public static void AddConverter(JsonConverter converter)
        {
            converters.Add(converter);
        }

        public static void AddType<T>()
        {
            typeMap.Add(typeof(T).FullName, typeof(T));
        }

        public static Type GetTypeFromString(string typeName)
        {
            if (!typeMap.TryGetValue(typeName, out Type type))
            {
                Debug.LogError($"There's no type in type map called '{typeName}'.");
                return null;
            }

            return type;
        }

        public static string SerializeJson(LevelEditorSaveData data, bool prettyPrint = false)
        {
            Dictionary<string, int> objectPalette = SerializationHelper.GetObjectPalette(data);
            Dictionary<string, int> typePalette = SerializationHelper.GetTypePalette(data);

            SerializedLevelData levelData = new SerializedLevelData
            {
                ObjectPalette = objectPalette,
                TypePalette = typePalette,
                Data = data
            };

            List<JsonConverter> newConverters = new List<JsonConverter>
            {
                new SaveDataConverter(objectPalette, typePalette),
                new ObjectDataConverter(objectPalette),
                new ComponentDataConverter(typePalette),
                new PropertyDataConverter(typePalette),
                new CustomDataConverter(typePalette)
            };
            newConverters.AddRange(converters);

            return JsonConvert.SerializeObject(levelData, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Converters = newConverters,
                Formatting = prettyPrint ? Formatting.Indented : Formatting.None
            });
        }

        public static LevelEditorSaveData DeserializeJson(string json)
        {
            Dictionary<int, string> typePalette = new Dictionary<int, string>();
            Dictionary<int, string> objectPalette = new Dictionary<int, string>();

            List<JsonConverter> newConverters = new List<JsonConverter>
            {
                new SaveDataConverter(objectPalette, typePalette),
                new ObjectDataConverter(objectPalette),
                new ComponentDataConverter(typePalette),
                new PropertyDataConverter(typePalette),
                new CustomDataConverter(typePalette)
            };
            newConverters.AddRange(converters);

            SerializedLevelData levelData = JsonConvert.DeserializeObject<SerializedLevelData>(json, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Converters = newConverters,
                Formatting = Formatting.Indented
            });

            return levelData.Data;
        }
    }
}
