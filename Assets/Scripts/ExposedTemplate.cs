using System;
using System.Collections.Generic;
using System.Linq;
using Hertzole.ALE;
using UnityEngine;

public class ExposedTemplate : MonoBehaviour, IExposedToLevelEditor
{
	private string value1;
	private int value2;
	private byte value3;
	private Vector3 value4;
	private GameObject goReference;
	private Transform trsReference;
	private List<Transform> transformList = new List<Transform>();
	private GameObject[] goArray;

	private int ALE__GENERATED__editingId;

	private object ALE__GENERATED__startEditValue;
	private object ALE__GENERATED__lastModifyValue;

	private event Action<int, object> ALE__GENERATED__OnValueChanging; 
	private event Action<int, object> ALE__GENERATED__OnValueChanged; 
	
	string IExposedToLevelEditor.ComponentName { get { return "ExposedTemplate"; } }
	string IExposedToLevelEditor.TypeName { get { return "ExposedTemplate"; } }
	Type IExposedToLevelEditor.ComponentType { get { return typeof(ExposedTemplate); } }
	bool IExposedToLevelEditor.HasVisibleFields { get { return true; } }
	int IExposedToLevelEditor.Order { get { return 0; } }
	
	event Action<int, object> IExposedToLevelEditor.OnValueChanging { add { ALE__GENERATED__OnValueChanging += value; } remove { ALE__GENERATED__OnValueChanging -= value; } }
	event Action<int, object> IExposedToLevelEditor.OnValueChanged { add { ALE__GENERATED__OnValueChanged += value; } remove { ALE__GENERATED__OnValueChanged -= value; } }

	private readonly List<ExposedField> ALE__GENERATED__propertiesList = new List<ExposedField>(3);
	
	private readonly ExposedField[] ALE__GENERATED__cachedProperties = new ExposedField[]
	{
		new ExposedProperty(0, typeof(string), "value1", null, true),
		new ExposedProperty(1, typeof(int), "value2", null, true),
		new ExposedProperty(2, typeof(byte), "value3", null, true),
	};

	private void Start()
	{
		Debug.Log(((IExposedToLevelEditor) this).GetValue(11));
	}

	IReadOnlyList<ExposedField> IExposedToLevelEditor.GetProperties()
	{
		ALE__GENERATED__propertiesList.Clear();
		ALE__GENERATED__GetProperties(ALE__GENERATED__propertiesList);

		return ALE__GENERATED__propertiesList;
	}

	protected virtual void ALE__GENERATED__GetProperties(List<ExposedField> list)
	{
		list.AddRange(ALE__GENERATED__cachedProperties);
	}

	object IExposedToLevelEditor.GetValue(int id)
	{
		if (ALE__GENERATED__GetValue(id, out object value))
		{
			return value;
		}

		throw new InvalidExposedPropertyException(id);
	}
	
	protected virtual bool ALE__GENERATED__GetValue(int id, out object value)
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

		if (id == 10)
		{
			value = new ComponentDataWrapper(goReference);
			return true;
		}

		if (id == 11)
		{
			value = new ComponentDataWrapper(trsReference);
			return true;
		}

		value = null;
		return false;
	}

	void IExposedToLevelEditor.BeginEdit(int id)
	{
		ALE__GENERATED__editingId = id;
		if (!ALE__GENERATED__BeginEdit(id))
		{
			throw new InvalidExposedPropertyException(id);
		}
	}
	
	protected virtual bool ALE__GENERATED__BeginEdit(int id)
	{
		if (id == 5)
		{
			ALE__GENERATED__startEditValue = value1;
			return true;
		}

		if (id == 1)
		{
			ALE__GENERATED__startEditValue = value2;
			return true;
		}

		if (id == 2)
		{
			ALE__GENERATED__startEditValue = value3;
			return true;
		}

		if (id == 10)
		{
			ALE__GENERATED__startEditValue = new ComponentDataWrapper(goReference);
			return true;
		}

		if (id == 11)
		{
			ALE__GENERATED__startEditValue = new ComponentDataWrapper(trsReference);
			return true;
		}

		if (id == 12)
		{
			ALE__GENERATED__startEditValue = new ComponentDataWrapper(transformList);
			return true;
		}

		if (id == 13)
		{
			ALE__GENERATED__startEditValue = new ComponentDataWrapper(goArray);
			return true;
		}

		return false;
	}

	void IExposedToLevelEditor.ModifyValue(object value, bool notify)
	{
		bool changed = false;

		if (ALE__GENERATED__ModifyValue(value, ref changed))
		{
			if (notify && changed)
			{
				ALE__GENERATED__OnValueChanging?.Invoke(ALE__GENERATED__editingId, value);
			}
		}
		else
		{
			throw new InvalidExposedPropertyException(ALE__GENERATED__editingId);
		}
	}

	protected virtual bool ALE__GENERATED__ModifyValue(object value, ref bool changed)
	{
		if (ALE__GENERATED__editingId == 0)
		{
			if (value is string str && value1 != str)
			{
				value1 = str;
				ALE__GENERATED__lastModifyValue = str;
				changed = true;
				return true;
			}
		}
		else if (ALE__GENERATED__editingId == 1)
		{
			if (value is int intVal && value2 != intVal)
			{
				value2 = intVal;
				ALE__GENERATED__lastModifyValue = intVal;
				changed = true;
				return true;
			}
		}
		else if (ALE__GENERATED__editingId == 2)
		{
			if (value is byte byteVal && value3 != byteVal)
			{
				value3 = byteVal;
				ALE__GENERATED__lastModifyValue = byteVal;
				changed = true;
				return true;
			}
		}
		else if (ALE__GENERATED__editingId == 3)
		{
			if (value is Vector3 vectorValue && value4 != vectorValue)
			{
				value4 = vectorValue;
				ALE__GENERATED__lastModifyValue = vectorValue;
				changed = true;
				return true;
			}
		}
		else if (ALE__GENERATED__editingId == 11)
		{
			if (value is ComponentDataWrapper wrapper && !wrapper.Equals(trsReference))
			{
				trsReference = wrapper.GetObject<Transform>();
				ALE__GENERATED__lastModifyValue = wrapper;
				changed = true;
				return true;
			}
		}
		else if (ALE__GENERATED__editingId == 12)
		{
			if (value is ComponentDataWrapper wrapper && !wrapper.Equals(transformList))
			{
				if (transformList == null)
				{
					transformList = new List<Transform>();
				}
				else
				{
					transformList.Clear();
				}
				transformList.AddRange(wrapper.GetObjects<Transform>());
				ALE__GENERATED__lastModifyValue = wrapper;
				changed = true;
				return true;
			}
		}
		else if (ALE__GENERATED__editingId == 13)
		{
			if (value is ComponentDataWrapper wrapper && !wrapper.Equals(goArray))
			{
				goArray = wrapper.GetObjects<GameObject>();
				ALE__GENERATED__lastModifyValue = wrapper;
				changed = true;
				return true;
			}
		}

		return false;
	}

	void IExposedToLevelEditor.EndEdit(bool notify, ILevelEditorUndo undo)
	{
		if (notify)
		{
			ALE__GENERATED__OnValueChanged?.Invoke(ALE__GENERATED__editingId, ALE__GENERATED__lastModifyValue);
		}

		if (undo != null)
		{
			undo.AddAction(new SetValueUndoAction(this, ALE__GENERATED__editingId, ALE__GENERATED__startEditValue, ALE__GENERATED__lastModifyValue));
		}
	}

	IExposedWrapper IExposedToLevelEditor.GetWrapper()
	{
		throw new NotImplementedException();
	}

	void IExposedToLevelEditor.ApplyWrapper(IExposedWrapper wrapper, bool ignoreDirtyMask)
	{
		throw new NotImplementedException();
	}
}