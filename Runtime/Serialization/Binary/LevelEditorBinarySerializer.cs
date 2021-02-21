using MessagePack;
using System.Collections.Generic;

namespace Hertzole.ALE
{
    public static class LevelEditorBinarySerializer
    {
        public static byte[] Serialize(LevelEditorSaveData data)
        {
            Dictionary<string, int> objectPalette = SerializationHelper.GetObjectPalette(data);
            Dictionary<string, int> typePalette = SerializationHelper.GetTypePalette(data);

            SerializedLevelData levelData = new SerializedLevelData()
            {
                ObjectPalette = objectPalette,
                TypePalette = typePalette,
                Data = data
            };

            return MessagePackSerializer.Serialize(levelData);
        }
    }
}
