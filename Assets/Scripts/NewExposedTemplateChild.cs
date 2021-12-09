using System;
using System.Collections.Generic;
using Hertzole.ALE;
using MessagePack;
using UnityEngine;

public class NewExposedTemplateChild : NewExposedTemplate
{
	private readonly ExposedProperty[] newExposedTemplateChild__cachedProperties =
	{
		new ExposedProperty(4, typeof(Vector3), "value4", string.Empty, true),
		new ExposedProperty(5, typeof(float), "value5", string.Empty, true)
	};
	private float value5;

	private Vector3 value4;

	private List<Vector3> vectorList;

	protected override void INTERNAL__GatherExposedProperties(List<ExposedProperty> properties)
	{
		base.INTERNAL__GatherExposedProperties(properties);

		properties.AddRange(newExposedTemplateChild__cachedProperties);
	}

	protected override bool INTERNAL__StartEdit(int id)
	{
		if (id == 4)
		{
			startEditValue = value4;
			return true;
		}

		if (id == 5)
		{
			startEditValue = value5;
			return true;
		}

		return base.INTERNAL__StartEdit(id);
	}

	protected override bool INTERNAL__SetEditValue(object value, bool notify, ref bool changed)
	{
		if (editingId == 4)
		{
			if (value is Vector3 vecValue && value4 != vecValue)
			{
				value4 = vecValue;
				lastValue = vecValue;
				changed = true;
			}
		}
		else if (editingId == 5)
		{
			if (value is float floatValue && value5 != floatValue)
			{
				value5 = floatValue;
				lastValue = floatValue;
				changed = true;
			}
		}

		return base.INTERNAL__SetEditValue(value, notify, ref changed);
	}

	protected override bool INTERNAL__GetValue(int id, out object value)
	{
		if (id == 4)
		{
			value = value4;
			return true;
		}

		if (id == 5)
		{
			value = value5;
			return true;
		}

		return base.INTERNAL__GetValue(id, out value);
	}

	protected override IExposedWrapper INTERNAL__GetWrapper()
	{
		return new ChildWrapper
		{
			Values = new Dictionary<int, object>(5)
			{
				{ 0, value1 },
				{ 1, value2 },
				{ 2, value2 },
				{ 4, value4 },
				{ 5, value5 }
			},
			Dirty = new Dictionary<int, bool>(5)
			{
				{ 0, false },
				{ 1, false },
				{ 2, false },
				{ 4, false },
				{ 5, false }
			}
		};
	}

	protected override void INTERNAL__ApplyWrapper(IExposedWrapper wrapper, bool ignoreDirtyCheck)
	{
		base.INTERNAL__ApplyWrapper(wrapper, ignoreDirtyCheck);

		if (wrapper.IsDirty(4))
		{
			value4 = wrapper.GetValue<Vector3>(4);
		}

		if (wrapper.IsDirty(5))
		{
			value5 = wrapper.GetValue<float>(5);
		}

		if (ignoreDirtyCheck || wrapper.IsDirty(10))
		{
			if (vectorList == null)
			{
				vectorList = new List<Vector3>();
			}
			else
			{
				vectorList.Clear();
			}
			
			vectorList.AddRange(wrapper.GetValue<List<Vector3>>(10));
		}
	}

	public struct ChildWrapper : IExposedWrapper
	{
		public Dictionary<int, object> Values { get; set; }
		public Dictionary<int, bool> Dirty { get; set; }

		public void Serialize(int id, ref MessagePackWriter writer, MessagePackSerializerOptions options)
		{
			if (id == 0)
			{
				writer.Write((string) Values[0]);
			}
			else if (id == 1)
			{
				writer.Write((int) Values[1]);
			}
			else if (id == 2)
			{
				writer.Write((byte) Values[2]);
			}
			else if (id == 4)
			{
				options.Resolver.GetFormatterWithVerify<Vector3>().Serialize(ref writer, (Vector3) Values[4], options);
			}
			else if (id == 5)
			{
				writer.Write((float) Values[5]);
			}
		}

		public object Deserialize(int id, ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (id == 0)
			{
				return reader.ReadString();
			}

			if (id == 1)
			{
				return reader.ReadInt32();
			}

			if (id == 2)
			{
				return reader.ReadByte();
			}

			if (id == 4)
			{
				return options.Resolver.GetFormatterWithVerify<Vector3>().Deserialize(ref reader, options);
			}

			if (id == 5)
			{
				return reader.ReadSingle();
			}

			return null;
		}
	}
}