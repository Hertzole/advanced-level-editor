using System.Collections.Generic;
using Hertzole.ALE;
using UnityEngine;

public class NewExposedTemplateChild : NewExposedTemplate
{
	private readonly ExposedProperty[] newExposedTemplateChild__cachedProperties =
	{
		new ExposedProperty(4, typeof(Vector3), "value4", string.Empty, true),
		new ExposedProperty(5, typeof(float), "value5", string.Empty, true)
	};

	private Vector3 value4;
	private float value5;

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
}