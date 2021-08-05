using System;
using System.Collections.Generic;
using Hertzole.ALE;
using UnityEngine;

public class NewExposedTemplate : MonoBehaviour
{
	private readonly ExposedProperty[] cachedProperties =
	{
		new ExposedProperty(0, typeof(string), "value1", string.Empty, true),
		new ExposedProperty(1, typeof(int), "value2", string.Empty, true),
		new ExposedProperty(2, typeof(byte), "value3", string.Empty, true)
	};

	private readonly List<ExposedProperty> internalPropertyGatherer = new List<ExposedProperty>();

	protected int editingId;
	protected object lastValue;
	protected object startEditValue;
	private string value1;
	private int value2;
	private byte value3;

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
			}
		}
		else if (editingId == 1)
		{
			if (value is int intVal && value2 != intVal)
			{
				value2 = intVal;
				lastValue = intVal;
				changed = true;
			}
		}
		else if (editingId == 2)
		{
			if (value is byte byteVal && value3 != byteVal)
			{
				value3 = byteVal;
				lastValue = byteVal;
				changed = true;
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

		value = null;
		return false;
	}

	public void SetValue(int id, object value, bool notify, ILevelEditorUndo undo)
	{
		StartEdit(id);
		SetEditValue(value, notify);
		EndEdit(notify, undo);
	}
}