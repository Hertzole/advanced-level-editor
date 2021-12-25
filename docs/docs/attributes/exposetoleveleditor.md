# Expose To Level Editor

`ExposeToLevelEditor` is one of the most important attributes in all of ALE. This attribute exposes your fields/properties
to the level editor so that they can be efficiently changed and serialized at runtime.

When assigning the attribute onto your target field/property, you must assign an ID. **The ID must be unique!** The
ID will be used by the serialization system to map your fields/properties. Changing/removing an ID can cause a loss
of data when deserializing.

Exposed fields/properties are gathered in a specific order. First it collects all the fields in the exposed class. 
Then it collects all the properties. The order of your fields/properties in your file matter as that is the order
they will be collected in. The order can, however, be overwritten with the order property mentioned below.

## Properties

`ExposeToLevelEditor` comes with a few extra properties you can set to modify the exposed field/property.

- `customName` Allows you to set a name that should be shown in the runtime inspector.
- `visible` Allows you to hide the field/property from the runtime inspector. This does not stop it from being serialized. 
- `order` Sets the order in the runtime inspector. Higher means lower down.

## Usage

```cs
using UnityEngine;
using Hertzole.ALE;

public class ExposedClass : MonoBehaviour
{
	[ExposeToLevelEditor(0)]
	public int intValue;
	[ExposeToLevelEditor(1, customName = "Text")] // Will show name as 'Text'
	private string stringValue;
	[ExposeToLevelEditor(2, visible = false)] // Will not show up in runtime inspector
	public float FloatValue { get; set; }
	[ExposeToLevelEditor(3, order = -10)] // Will be first in the runtime inspector
	public byte ByteValue { get; set; }
}
```