using MessagePack;

namespace Hertzole.ALE
{
    public static class LevelEditorBinarySerializer
    {
        public static byte[] Serialize<T>(T data)
        {
            return MessagePackSerializer.Serialize(data);
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            return MessagePackSerializer.Deserialize<T>(bytes);
        }
    }
}
