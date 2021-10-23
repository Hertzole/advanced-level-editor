using System;
using System.Collections;
using System.Collections.Generic;
using Hertzole.ALE;
using MessagePack;
using UnityEngine;

public class ResolverTemplate : MonoBehaviour
{
    public bool DeserializeWrapperTemplate(Type type, ref MessagePackReader reader, MessagePackSerializerOptions options, out IExposedWrapper wrapper)
    {
        wrapper = null;
        return false;
    }
    public bool SerializeWrapperTemplate(ref MessagePackWriter writer, IExposedWrapper wrapper, MessagePackSerializerOptions options)
    {
        return false;
    }
}
