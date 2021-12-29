using System;
using System.Collections.Generic;
using Hertzole.ALE;
using MessagePack;
using UnityEngine;

public class NewExposedTemplate : MonoBehaviour
{
	protected byte value3;
	private readonly ExposedProperty[] cachedProperties =
	{
		new ExposedProperty(0, typeof(string), "value1", string.Empty, true),
		new ExposedProperty(1, typeof(int), "value2", string.Empty, true),
		new ExposedProperty(2, typeof(byte), "value3", string.Empty, true),
		new ExposedProperty(3, typeof(GameObject), "reference", string.Empty, true)
	};

	protected int editingId;
	protected int value2;

	private readonly List<ExposedProperty> internalPropertyGatherer = new List<ExposedProperty>();
	protected object lastValue;
	protected object startEditValue;
	protected string value1;
	protected GameObject reference;
	protected GameObject[] references;
	protected List<GameObject> referencesList;

	private byte? nullableByte;
	private List<byte?> nullableList = new List<byte?>();

	public event Action<int, object> OnValueChanging;
	public event Action<int, object> OnValueChanged;

	public IReadOnlyList<ExposedProperty> GetExposedProperties()
	{
		internalPropertyGatherer.Clear();
		INTERNAL__GatherExposedProperties(internalPropertyGatherer);

		return internalPropertyGatherer;
	}

	protected virtual void INTERNAL__GatherExposedProperties(List<ExposedProperty> properties)
	{
		properties.AddRange(cachedProperties);
	}

	public void StartEdit(int id)
	{
		editingId = id;
		if (!INTERNAL__StartEdit(id))
		{
			throw new InvalidExposedPropertyException(id);
		}
	}

	protected virtual bool INTERNAL__StartEdit(int id)
	{
		if (id == 0)
		{
			startEditValue = value1;
			return true;
		}

		if (id == 1)
		{
			startEditValue = value2;
			return true;
		}

		if (id == 2)
		{
			startEditValue = value3;
			return true;
		}

		if (id == 3)
		{
			startEditValue = new ComponentDataWrapper(reference);
			return true;
		}

		if (id == 100)
		{
			startEditValue = nullableByte;
			return true;
		}

		return false;
	}

	public void SetEditValue(object value, bool notify)
	{
		bool changed = false;

		if (INTERNAL__SetEditValue(value, notify, ref changed))
		{
			if (notify && changed)
			{
				OnValueChanging?.Invoke(editingId, value);
			}
		}
		else
		{
			throw new InvalidExposedPropertyException(editingId);
		}
	}

	protected virtual bool INTERNAL__SetEditValue(object value, bool notify, ref bool changed)
	{
		if (editingId == 0)
		{
			if (value is string str && value1 != str)
			{
				value1 = str;
				lastValue = str;
				changed = true;
				return true;
			}
		}
		else if (editingId == 1)
		{
			if (value is int intVal && value2 != intVal)
			{
				value2 = intVal;
				lastValue = intVal;
				changed = true;
				return true;
			}
		}
		else if (editingId == 2)
		{
			if (value is byte byteVal && value3 != byteVal)
			{
				value3 = byteVal;
				lastValue = byteVal;
				changed = true;
				return true;
			}
		}
		else if (editingId == 100)
		{
			if (value is byte byteVal && nullableByte != byteVal)
			{
				nullableByte = byteVal;
				lastValue = byteVal;
				changed = true;
				return true;
			}
			else if (value is null && nullableByte != null)
			{
				nullableByte = null;
				lastValue = null;
				changed = true;
				return true;
			}
		}
		else if (editingId == 3)
		{
			if (value is ComponentDataWrapper wrapper && !wrapper.Equals(reference))
			{
				reference = wrapper.GetObject<GameObject>();
				lastValue = wrapper;
				changed = true;
				return true;
			}
		}
		

		return false;
	}

	public void EndEdit(bool notify, ILevelEditorUndo undo)
	{
		if (notify)
		{
			OnValueChanged?.Invoke(editingId, lastValue);
		}

		if (undo != null)
		{
			undo.AddAction(new SetValueUndoAction(null, editingId, startEditValue, lastValue));
		}
	}

	public object GetValue(int id)
	{
		if (INTERNAL__GetValue(id, out object value))
		{
			return value;
		}

		throw new InvalidExposedPropertyException(id);
	}

	protected virtual bool INTERNAL__GetValue(int id, out object value)
	{
		if (id == 0)
		{
			value = value1;
			return true;
		}

		if (id == 1)
		{
			value = value2;
			return true;
		}

		if (id == 3)
		{
			value = value3;
			return true;
		}

		if (id == 4)
		{
			value = new ComponentDataWrapper(gameObject);
			return true;
		}

		if (id == 100)
		{
			value = nullableByte;
			return true;
		}

		value = null;
		return false;
	}

	public void SetValue(int id, object value, bool notify, ILevelEditorUndo undo)
	{
		StartEdit(id);
		SetEditValue(value, notify);
		EndEdit(notify, undo);
	}

	public IExposedWrapper GetWrapper()
	{
		return INTERNAL__GetWrapper();
	}

	protected virtual IExposedWrapper INTERNAL__GetWrapper()
	{
		return new BaseWrapper
		{
			Values = new Dictionary<int, object>(3)
			{
				{ 0, value1 },
				{ 2, value2 },
				{ 2, value3 },
				{ 3, new ComponentDataWrapper(reference) },
				{100, nullableByte}
			},
			Dirty = new Dictionary<int, bool>(3)
			{
				{ 0, false },
				{ 1, false },
				{ 2, false },
				{ 100, false }
			}
		};
	}

	public void ApplyWrapper(IExposedWrapper wrapper, bool ignoreDirtyCheck)
	{
		INTERNAL__ApplyWrapper(wrapper, ignoreDirtyCheck);
	}

	protected virtual void INTERNAL__ApplyWrapper(IExposedWrapper wrapper, bool ignoreDirtyCheck)
	{
		if (ignoreDirtyCheck || wrapper.IsDirty(0))
		{
			value1 = wrapper.GetValue<string>(0);
		}

		if (ignoreDirtyCheck || wrapper.IsDirty(1))
		{
			value2 = wrapper.GetValue<int>(1);
		}

		if (wrapper.IsDirty(2))
		{
			value3 = wrapper.GetValue<byte>(2);
		}

		if (wrapper.IsDirty(3))
		{
			reference = wrapper.GetValue<ComponentDataWrapper>(3).GetObject<GameObject>();
		}

		if (wrapper.IsDirty(10))
		{
			references = wrapper.GetValue<ComponentDataWrapper>(10).GetObjects<GameObject>();
		}

		if (wrapper.IsDirty(11))
		{
			if (referencesList == null)
			{
				referencesList = new List<GameObject>();
			}
			else
			{
				referencesList.Clear();
			}

			var tempList = wrapper.GetValue<ComponentDataWrapper>(11).GetObjects<GameObject>();
			if (tempList != null)
			{
				referencesList.AddRange(tempList);
			}
		}

		if (wrapper.IsDirty(100))
		{
			nullableByte = wrapper.GetValue<byte?>(100);
		}

		if (wrapper.IsDirty(200))
		{
			if (nullableList == null)
			{
				nullableList = new List<byte?>();
			}
			else
			{
				nullableList.Clear();
			}

			var tempValue = wrapper.GetValue<List<byte?>>(200);
			if (tempValue != null)
			{
				nullableList.AddRange(tempValue);
			}
		}
	}

	public struct BaseWrapper : IExposedWrapper
	{
		public Dictionary<int, object> Values { get; set; }
		public Dictionary<int, bool> Dirty { get; set; }

		void IExposedWrapper.Serialize(int id, ref MessagePackWriter writer, MessagePackSerializerOptions options)
		{
			if (id == 0)
			{
				writer.Write((string) Values[0]);
			}
			else if (id == 50)
			{
				writer.Write((int) Values[1]);
			}
			else if (id == 200)
			{
				writer.Write((byte) Values[2]);
			}
			else if (id == 100)
			{
				options.Resolver.GetFormatterWithVerify<byte?>().Serialize(ref writer, (byte?) Values[100], options);
			}
		}

		object IExposedWrapper.Deserialize(int id, ref MessagePackReader reader, MessagePackSerializerOptions options)
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

			if (id == 100)
			{
				return options.Resolver.GetFormatterWithVerify<byte?>().Deserialize(ref reader, options);
			}

			return null;
		}
	}
}