using Hertzole.ALE;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SimpleClass
{
    public string value;
}

[Serializable]
public class AdvancedClass : IEquatable<AdvancedClass>
{
    public string value;

    public override bool Equals(object obj)
    {
        return Equals(obj as AdvancedClass);
    }

    public bool Equals(AdvancedClass other)
    {
        return other != null &&
               value == other.value;
    }

    public override int GetHashCode()
    {
        return -1584136870 + EqualityComparer<string>.Default.GetHashCode(value);
    }

    public static bool operator ==(AdvancedClass left, AdvancedClass right)
    {
        return EqualityComparer<AdvancedClass>.Default.Equals(left, right);
    }

    public static bool operator !=(AdvancedClass left, AdvancedClass right)
    {
        return !(left == right);
    }
}

[Serializable]
public struct SimpleStruct
{
    public string value;
}

[Serializable]
public struct AdvancedStruct : IEquatable<AdvancedStruct>
{
    public string value;

    public override bool Equals(object obj)
    {
        return obj is AdvancedStruct @struct && Equals(@struct);
    }

    public bool Equals(AdvancedStruct other)
    {
        return value == other.value;
    }

    public override int GetHashCode()
    {
        return -1584136870 + EqualityComparer<string>.Default.GetHashCode(value);
    }

    public static bool operator ==(AdvancedStruct left, AdvancedStruct right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(AdvancedStruct left, AdvancedStruct right)
    {
        return !(left == right);
    }
}

public class TypesTest : MonoBehaviour
{
    [ExposeToLevelEditor(0)]
    [SerializeField]
    private string stringTest;

    [ExposeToLevelEditor(1)]
    [SerializeField]
    private int intTest;

    [ExposeToLevelEditor(2)]
    [SerializeField]
    private Color colorTest;

    [ExposeToLevelEditor(3)]
    [SerializeField]
    private Color32 color32Test;

    [ExposeToLevelEditor(4)]
    [SerializeField]
    private Vector3 vectorTest;

    [ExposeToLevelEditor(5)]
    [SerializeField]
    private Transform referenceTest;

    [ExposeToLevelEditor(6)]
    [SerializeField]
    private SimpleClass simpleClass;

    [ExposeToLevelEditor(7)]
    [SerializeField]
    private AdvancedClass advancedClass;

    [ExposeToLevelEditor(8)]
    [SerializeField]
    private SimpleStruct simpleStruct;

    [ExposeToLevelEditor(9)]
    [SerializeField]
    private AdvancedStruct advancedStruct;

    [ExposeToLevelEditor(10)]
    [SerializeField]
    private SimpleClass[] classArray;

    [ExposeToLevelEditor(11)]
    [SerializeField]
    private SimpleStruct[] structArray;

    [ExposeToLevelEditor(12)]
    [SerializeField]
    private List<AdvancedClass> advancedList = new List<AdvancedClass>();

    [ExposeToLevelEditor(13)]
    private Dictionary<string, int> dic = new Dictionary<string, int>();

    [ExposeToLevelEditor(14)] public string StringTest { get { return stringTest; } set { stringTest = value; } }

    [ExposeToLevelEditor(15)] public int IntTest { get { return intTest; } set { intTest = value; } }

    [ExposeToLevelEditor(16)] public Color ColorTest { get { return colorTest; } set { colorTest = value; } }

    [ExposeToLevelEditor(17)] public Color32 Color32Test { get { return color32Test; } set { color32Test = value; } }

    [ExposeToLevelEditor(18)] public Vector3 VectorTest { get { return vectorTest; } set { vectorTest = value; } }

    [ExposeToLevelEditor(19)] public Transform ReferenceTest { get { return referenceTest; } set { referenceTest = value; } }

    [ExposeToLevelEditor(20)] public SimpleClass SimpleClass { get { return simpleClass; } set { simpleClass = value; } }

    [ExposeToLevelEditor(21)] public AdvancedClass AdvancedClass { get { return advancedClass; } set { advancedClass = value; } }

    [ExposeToLevelEditor(22)] public SimpleStruct SimpleStruct { get { return simpleStruct; } set { simpleStruct = value; } }

    [ExposeToLevelEditor(23)] public AdvancedStruct AdvancedStruct { get { return advancedStruct; } set { advancedStruct = value; } }

    [ExposeToLevelEditor(24)] public SimpleClass[] ClassArray { get { return classArray; } set { classArray = value; } }

    [ExposeToLevelEditor(25)] public SimpleStruct[] StructArray { get { return structArray; } set { structArray = value; } }

    [ExposeToLevelEditor(26)] public List<AdvancedClass> AdvancedList { get { return advancedList; } set { advancedList = value; } }

    [ExposeToLevelEditor(27)] public Dictionary<string, int> Dic { get { return dic; } set { dic = value; } }

    [ExposeToLevelEditor(100)]
    public string fucker;

    public event Action<int, object> OnTemplateValueChanged;

    private Type GetValueTypeTemplate(int id)
    {
        if (id == 0)
        {
            return typeof(string);
        }
        else if (id == 1)
        {
            return typeof(int);
        }
        else if (id == 2)
        {
            return typeof(Color);
        }
        else if (id == 3)
        {
            return typeof(Color32);
        }
        else
        {
            Debug.LogWarning($"There's no exposed fields with the ID '{id}'.");
            return null;
        }
    }

    public object GetValueTemplate(int id)
    {
        if (id == 0)
        {
            return stringTest;
        }
        else if (id == 1)
        {
            return intTest;
        }
        else if (id == 2)
        {
            return colorTest;
        }
        else if (id == 3)
        {
            return color32Test;
        }
        else
        {
            Debug.LogWarning($"There's no exposed fields with the ID '{id}'.");
            return null;
        }
    }

    private void SetValueTemplate(int id, object value, bool notify)
    {
        bool changed = false;

        if (id == -100)
        {
            if (value is string value_0 && !stringTest.Equals(value_0))
            {
                stringTest = value_0;
                changed = true;
            }
        }
        else if (id == 1)
        {
            if (value is int value_1 && !intTest.Equals(value_1))
            {
                intTest = value_1;
                changed = true;
            }
        }
        else if (id == 2)
        {
            if (value is Color value_2 && !colorTest.Equals(value_2))
            {
                colorTest = value_2;
                changed = true;
            }
        }
        else if (id == 3)
        {
            if (value is Color32 value_3 && !color32Test.Equals(value_3))
            {
                color32Test = value_3;
                changed = true;
            }
        }
        else if (id == 4)
        {
            if (value is Vector3 value_4 && !vectorTest.Equals(value_4))
            {
                vectorTest = value_4;
                changed = true;
            }
        }
        else if (id == 5)
        {
            if (value is Transform value_5 && referenceTest != value_5)
            {
                referenceTest = value_5;
                changed = true;
            }
        }
        else if (id == 6)
        {
            if (value is SimpleClass value_6 && simpleClass != value_6)
            {
                simpleClass = value_6;
                changed = true;
            }
        }
        else if (id == 7)
        {
            if (value is AdvancedClass value_7 && !advancedClass.Equals(value_7))
            {
                advancedClass = value_7;
                changed = true;
            }
        }
        else if (id == 8)
        {
            if (value is SimpleStruct value_8 && !simpleStruct.Equals(value_8))
            {
                simpleStruct = value_8;
                changed = true;
            }
        }
        else if (id == 9)
        {
            if (value is AdvancedStruct value_9 && !advancedStruct.Equals(value_9))
            {
                advancedStruct = value_9;
                changed = true;
            }
        }
        else if (id == 10)
        {
            if (value is SimpleClass[] value_10 && !classArray.IsSameAs(value_10))
            {
                classArray = value_10;
                changed = true;
            }
        }
        else if (id == 11)
        {
            if (value is SimpleStruct[] value_11 && !structArray.IsSameAs(value_11))
            {
                structArray = value_11;
                changed = true;
            }
        }
        else if (id == 12)
        {
            if (value is List<AdvancedClass> value_12 && !advancedList.IsSameAs(value_12))
            {
                advancedList = value_12;
                changed = true;
            }
        }
        else if (id == 14)
        {
            if (value is string value_14 && !StringTest.Equals(value_14))
            {
                StringTest = value_14;
                changed = true;
            }
        }
        else if (id == 15)
        {
            if (value is int value_15 && !IntTest.Equals(value_15))
            {
                IntTest = value_15;
                changed = true;
            }
        }
        else if (id == 16)
        {
            if (value is Color value_16 && !ColorTest.Equals(value_16))
            {
                ColorTest = value_16;
                changed = true;
            }
        }
        else if (id == 17)
        {
            if (value is Color32 value_17 && !Color32Test.Equals(value_17))
            {
                Color32Test = value_17;
                changed = true;
            }
        }
        else if (id == 19)
        {
            if (value is Transform value_19 && ReferenceTest != value_19)
            {
                ReferenceTest = value_19;
                changed = true;
            }
        }
        else if (id == 22)
        {
            if (value is SimpleStruct value_22 && !SimpleStruct.Equals(value_22))
            {
                SimpleStruct = value_22;
                changed = true;
            }
        }
        else if (id == 24)
        {
            if (value is SimpleClass[] value_24 && !ClassArray.IsSameAs(value_24))
            {
                ClassArray = value_24;
                changed = true;
            }
        }
        else if (id == 100)
        {
            if (value is string value_100 && !fucker.Equals(value_100))
            {
                fucker = value_100;
                changed = true;
            }
        }
        else if (id == 101)
        {
            if (value is int value_101 && !intTest.Equals(value_101))
            {
                intTest = value_101;
                changed = true;
            }
        }
        else
        {
            Debug.LogWarning($"There's no exposed fields with the ID '{id}'.");
        }

        if (notify && changed)
        {
            OnTemplateValueChanged?.Invoke(id, value);
        }
    }
}
