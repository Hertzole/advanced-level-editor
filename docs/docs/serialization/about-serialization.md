---
sidebar_position: 1
---

# About Serialization

ALE will attempt to serialize all your exposed components and custom fields. 
The serialization backend is provided by [MessagePack for C#](https://github.com/neuecc/MessagePack-CSharp)
to enable fast and performant serialization both to Binary and JSON ([see JSON note](/docs/serialization/json-serialization)).

## Exposed Components

ALE will serialize all components that have been exposed to the level editor. 
(See [Expose To Level Editor attribute](/docs/attributes/exposetoleveleditor)) It can serialize all the standard 
[C# primitives](/docs/serialization/c-primitives), [Unity primitives](/docs/serialization/unity-primitives), and some 
[custom types](/docs/serialization/custom-types).

<details><summary>Generated Code</summary>
<p>

This is the code that it will generate a wrapper and formatter from.

```cs
using UnityEngine;
using Hertzole.ALE;

public class ExposedClass : MonoBehaviour
{
	[ExposeToLevelEditor(0)]
	public int intValue;
	[ExposeToLevelEditor(1)]
	public string stringValue;
}
```

First it creates a wrapper inside ExposeClass.

```cs
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Hertzole.ALE;
using MessagePack;

public struct ALE__GENERATED__ExposedClassComponentWrapper : IExposedWrapper
{
	public Dictionary<int, object> Values { get; set; }
	public Dictionary<int, bool> Dirty { get; set; }

	public void Serialize(int id, ref MessagePackWriter writer, MessagePackSerializerOptions options)
	{
		switch (id)
		{
			case 0:
				writer.WriteInt32((int)Values[0]);
				break;
			case 1:
				options.Resolver.GetFormatterWithVerify<string>().Serialize(ref writer, (string)Values[1], options);
				break;
		}
	}

	public object Deserialize(int id, ref MessagePackReader reader, MessagePackSerializerOptions options)
	{
		switch (id)
		{
			case 0:
				return reader.ReadInt32();
			case 1:
				return reader.ReadString();
			default:
				return null;
		}
	}
}
```

Then lastly it creates the formatter.

```cs
using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;

public class ExposedClass_Formatter : IMessagePackFormatter<ExposedClass.ALE__GENERATED__ExposedClassComponentWrapper>, IMessagePackFormatter
{
	public void Serialize(ref MessagePackWriter writer, ExposedClass.ALE__GENERATED__ExposedClassComponentWrapper wrapper, MessagePackSerializerOptions options)
	{
		writer.WriteArrayHeader(4);
		writer.WriteInt32(0);
		wrapper.Serialize(0, ref writer, options);
		writer.WriteInt32(1);
		wrapper.Serialize(1, ref writer, options);
	}

	public ExposedClass.ALE__GENERATED__ExposedClassComponentWrapper Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
	{
		if (reader.TryReadNil())
		{
			throw new InvalidOperationException();
		}
		options.Security.DepthStep(ref reader);
		int num = reader.ReadArrayHeader();
		ExposedClass.ALE__GENERATED__ExposedClassComponentWrapper wrapper = default(ExposedClass.ALE__GENERATED__ExposedClassComponentWrapper);
		wrapper.Values = new Dictionary<int, object>(2);
		wrapper.Dirty = new Dictionary<int, bool>(2);
		for (int i = 0; i < num / 2; i++)
		{
			switch (reader.ReadInt32())
			{
				case 0:
					wrapper.Values[0] = wrapper.Deserialize(0, ref reader, options);
					wrapper.Dirty[0] = true;
					break;
				case 1:
					wrapper.Values[1] = wrapper.Deserialize(1, ref reader, options);
					wrapper.Dirty[1] = true;
					break;
			}
		}
		reader.Depth--;
		return wrapper;
	}
}
```

</p>
</details>

## Custom Data

Custom data is, as the name implies, custom data being saved with the level data when saving.
You can save the standard [C# primitives](/docs/serialization/c-primitives), [Unity primitives](/docs/serialization/unity-primitives), 
and some [custom types](/docs/serialization/custom-types) in custom data and retrieve it later when loading a level. 
See [save manager](/docs/components/save-manager) for more info about actually using custom data. 

## Serialization Rules

There are some rules that the weaver follows to create formatters for your exposed components and custom types. 
They can be really helpful in order to get the most reliable output from your data.

#### When serializing exposed components:
- Unity object/component references *ARE* allowed
- Only specified fields and properties are serialized
- Exposed properties are mapped to their ID
- Private, protected, and public fields/properties can be serialized

#### When serializing custom types:
- Unity object/component references *ARE NOT* allowed
- Only structs can be serialized
- Only fields are serialized
- All fields are serialized
- Fields can be ignored with the `NonSerializable` attribute
- Fields are mapped to their names
- Only public fields are serialized

## Custom Formatters

⚠ **Custom formatters are not yet supported.** ⚠

Custom formatters give you the ability to easily create your own formatter that will be hooked into the level editor
so you can customize the serialization behavior of your custom types.