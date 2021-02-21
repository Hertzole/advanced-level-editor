using MessagePack;
using MessagePack.Resolvers;
using MessagePack.Unity;
using MessagePack.Unity.Extension;
using UnityEngine;

namespace Hertzole.ALE
{
    public static class BinaryResolver
    {
        private static bool serializerRegistered = false;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void ResetStatics()
        {
            if (serializerRegistered)
            {
                return;
            }

            StaticCompositeResolver.Instance.Register(UnityResolver.Instance, UnityBlitResolver.Instance, StandardResolver.Instance);
            MessagePackSerializer.DefaultOptions = MessagePackSerializerOptions.Standard.WithResolver(StaticCompositeResolver.Instance);

            serializerRegistered = true;
        }
    }
}
