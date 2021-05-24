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
        return other != null && value == other.value;
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

    public static implicit operator SimpleStruct(AdvancedStruct x)
    {
        return new SimpleStruct() { value = x.value };
    }

    public static implicit operator Vector3(AdvancedStruct x)
    {
        return Vector3.one;
    }
}

public class TypesTest : MonoBehaviour
{
    public enum TestEnum { Test1 = -10, Test3 = 66, Consistency = 520, No = 1 }

    [ExposeToLevelEditor(100)]
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
    // [ExposeToLevelEditor(6)]
    // [SerializeField]
    // private SimpleClass simpleClass;
    // [ExposeToLevelEditor(7)]
    // [SerializeField]
    // private AdvancedClass advancedClass;
    [ExposeToLevelEditor(8)]
    [SerializeField]
    private SimpleStruct simpleStruct;
    [ExposeToLevelEditor(9)]
    [SerializeField]
    private AdvancedStruct advancedStruct;
    // [ExposeToLevelEditor(10)]
    // [SerializeField]
    // private SimpleClass[] classArray;
    [ExposeToLevelEditor(11)]
    [SerializeField]
    private SimpleStruct[] structArray;
    [ExposeToLevelEditor(12)]
    [SerializeField]
    private List<AdvancedClass> advancedList = new List<AdvancedClass>();
    [ExposeToLevelEditor(13)]
    private Dictionary<string, int> dic = new Dictionary<string, int>();

    [ExposeToLevelEditor(14)]
    public string StringTest { get { return stringTest; } set { stringTest = value; } }
    [ExposeToLevelEditor(15)]
    public int IntTest { get { return intTest; } set { intTest = value; } }
    [ExposeToLevelEditor(16)]
    public Color ColorTest { get { return colorTest; } set { colorTest = value; } }
    [ExposeToLevelEditor(17)]
    public Color32 Color32Test { get { return color32Test; } set { color32Test = value; } }
    [ExposeToLevelEditor(18)]
    public Vector3 VectorTest { get { return vectorTest; } set { vectorTest = value; } }
    [ExposeToLevelEditor(19)]
    public Transform ReferenceTest { get { return referenceTest; } set { referenceTest = value; } }
    // [ExposeToLevelEditor(20)]
    // public SimpleClass SimpleClass { get { return simpleClass; } set { simpleClass = value; } }
    // [ExposeToLevelEditor(21)]
    // public AdvancedClass AdvancedClass { get { return advancedClass; } set { advancedClass = value; } }
    [ExposeToLevelEditor(22)]
    public SimpleStruct SimpleStruct { get { return simpleStruct; } set { simpleStruct = value; } }
    [ExposeToLevelEditor(23)]
    public AdvancedStruct AdvancedStruct { get { return advancedStruct; } set { advancedStruct = value; } }
    // [ExposeToLevelEditor(24)]
    // public SimpleClass[] ClassArray { get { return classArray; } set { classArray = value; } }
    [ExposeToLevelEditor(25)]
    public SimpleStruct[] StructArray { get { return structArray; } set { structArray = value; } }
    [ExposeToLevelEditor(26)]
    public List<AdvancedClass> AdvancedList { get { return advancedList; } set { advancedList = value; } }
    [ExposeToLevelEditor(27)]
    public Dictionary<string, int> Dic { get { return dic; } set { dic = value; } }

    [SerializeField]
    [ExposeToLevelEditor(28)]
    private TestEnum enumTest = TestEnum.No;

    [ExposeToLevelEditor(29)]
    public TestEnum EnumTest { get { return enumTest; } set { enumTest = value; } }
    
    [SerializeField] 
    [ExposeToLevelEditor(30)]
    private Transform[] referenceArray = null;
    [SerializeField] 
    [ExposeToLevelEditor(31)]
    private List<GameObject> referenceList = new List<GameObject>();

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
            if (!((IExposedToLevelEditor)this).ClassEquals<string>(value, stringTest, out string value_0))
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
            else if (value is Vector4 value_2_vec4 && !colorTest.Equals(value_2_vec4))
            {
                colorTest = value_2_vec4;
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
            if (value is ComponentDataWrapper wrapper && !wrapper.Equals(referenceTest))
            {
                referenceTest = wrapper.GetObject<Transform>();
                changed = true;
            }
        }
        // else if (id == 6)
        // {
        //     if (value is SimpleClass value_6 && simpleClass != value_6)
        //     {
        //         simpleClass = value_6;
        //         changed = true;
        //     }
        // }
        // else if (id == 7)
        // {
        //     if (((IExposedToLevelEditor)this).ClassEquals(value, advancedClass, out AdvancedClass value_7))
        //     {
        //         advancedClass = value_7;
        //         changed = true;
        //     }
        // }
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
        // else if (id == 10)
        // {
        //     if (!((IExposedToLevelEditor)this).CollectionEquals(value, classArray, out SimpleClass[] value_10))
        //     {
        //         classArray = value_10;
        //         changed = true;
        //     }
        // }
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
        // else if (id == 24)
        // {
        //     if (value is SimpleClass[] value_24 && !ClassArray.IsSameAs(value_24))
        //     {
        //         ClassArray = value_24;
        //         changed = true;
        //     }
        // }
        else if (id == 101)
        {
            if (value is int value_101 && !intTest.Equals(value_101))
            {
                intTest = value_101;
                changed = true;
            }
        }
        else if (id == 29)
        {
            if (value is ComponentDataWrapper value_29 && !value_29.Equals(referenceArray))
            {
                referenceArray = value_29.GetObjects<Transform>();
                changed = true;
            }
        }
        else if (id == 30)
        {
            if (value is ComponentDataWrapper value_30 && !value_30.Equals(referenceList))
            {
                referenceList.Clear();
                referenceList.AddRange(value_30.GetObjects<GameObject>());
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
    
    IExposedWrapper GetWrapper()
    {
        return new global::TypesTest.Wrapper(this.stringTest, this.intTest, this.colorTest, this.color32Test,
            this.vectorTest, new ComponentDataWrapper(this.referenceTest), null, null,
            this.simpleStruct, this.advancedStruct, null, this.structArray, this.advancedList, this.dic, 
            this.enumTest, new ComponentDataWrapper(this.referenceArray), new ComponentDataWrapper(this.referenceList), 
            this.StringTest, this.IntTest, this.ColorTest, this.Color32Test, 
            this.VectorTest, new ComponentDataWrapper(this.ReferenceTest), null, null, 
            this.SimpleStruct, this.AdvancedStruct, null, this.StructArray, this.AdvancedList, 
            this.Dic, this.EnumTest);
    }

    public struct Wrapper : IExposedWrapper
	{
		// Token: 0x060000DD RID: 221 RVA: 0x000072FC File Offset: 0x000054FC
		public Wrapper(string A_1, int A_2, Color A_3, Color32 A_4, Vector3 A_5, ComponentDataWrapper A_6, global::SimpleClass A_7, global::AdvancedClass A_8, global::SimpleStruct A_9, global::AdvancedStruct A_10, global::SimpleClass[] A_11, global::SimpleStruct[] A_12, List<global::AdvancedClass> A_13, Dictionary<string, int> A_14, global::TypesTest.TestEnum A_15, ComponentDataWrapper A_16, ComponentDataWrapper A_17, string A_18, int A_19, Color A_20, Color32 A_21, Vector3 A_22, ComponentDataWrapper A_23, global::SimpleClass A_24, global::AdvancedClass A_25, global::SimpleStruct A_26, global::AdvancedStruct A_27, global::SimpleClass[] A_28, global::SimpleStruct[] A_29, List<global::AdvancedClass> A_30, Dictionary<string, int> A_31, global::TypesTest.TestEnum A_32)
		{
			this.stringTest = new ValueTuple<int, string>(100, A_1);
			this.intTest = new ValueTuple<int, int>(1, A_2);
			this.colorTest = new ValueTuple<int, Color>(2, A_3);
			this.color32Test = new ValueTuple<int, Color32>(3, A_4);
			this.vectorTest = new ValueTuple<int, Vector3>(4, A_5);
			this.referenceTest = new ValueTuple<int, ComponentDataWrapper>(5, A_6);
			this.simpleClass = new ValueTuple<int, global::SimpleClass>(6, A_7);
			this.advancedClass = new ValueTuple<int, global::AdvancedClass>(7, A_8);
			this.simpleStruct = new ValueTuple<int, global::SimpleStruct>(8, A_9);
			this.advancedStruct = new ValueTuple<int, global::AdvancedStruct>(9, A_10);
			this.classArray = new ValueTuple<int, global::SimpleClass[]>(10, A_11);
			this.structArray = new ValueTuple<int, global::SimpleStruct[]>(11, A_12);
			this.advancedList = new ValueTuple<int, List<global::AdvancedClass>>(12, A_13);
			this.dic = new ValueTuple<int, Dictionary<string, int>>(13, A_14);
			this.enumTest = new ValueTuple<int, global::TypesTest.TestEnum>(28, A_15);
			this.referenceArray = new ValueTuple<int, ComponentDataWrapper>(30, A_16);
			this.referenceList = new ValueTuple<int, ComponentDataWrapper>(31, A_17);
			this.StringTest = new ValueTuple<int, string>(14, A_18);
			this.IntTest = new ValueTuple<int, int>(15, A_19);
			this.ColorTest = new ValueTuple<int, Color>(16, A_20);
			this.Color32Test = new ValueTuple<int, Color32>(17, A_21);
			this.VectorTest = new ValueTuple<int, Vector3>(18, A_22);
			this.ReferenceTest = new ValueTuple<int, ComponentDataWrapper>(19, A_23);
			this.SimpleClass = new ValueTuple<int, global::SimpleClass>(20, A_24);
			this.AdvancedClass = new ValueTuple<int, global::AdvancedClass>(21, A_25);
			this.SimpleStruct = new ValueTuple<int, global::SimpleStruct>(22, A_26);
			this.AdvancedStruct = new ValueTuple<int, global::AdvancedStruct>(23, A_27);
			this.ClassArray = new ValueTuple<int, global::SimpleClass[]>(24, A_28);
			this.StructArray = new ValueTuple<int, global::SimpleStruct[]>(25, A_29);
			this.AdvancedList = new ValueTuple<int, List<global::AdvancedClass>>(26, A_30);
			this.Dic = new ValueTuple<int, Dictionary<string, int>>(27, A_31);
			this.EnumTest = new ValueTuple<int, global::TypesTest.TestEnum>(29, A_32);
		}

		// Token: 0x040000CA RID: 202
		public ValueTuple<int, string> stringTest;

		// Token: 0x040000CB RID: 203
		public ValueTuple<int, int> intTest;

		// Token: 0x040000CC RID: 204
		public ValueTuple<int, Color> colorTest;

		// Token: 0x040000CD RID: 205
		public ValueTuple<int, Color32> color32Test;

		// Token: 0x040000CE RID: 206
		public ValueTuple<int, Vector3> vectorTest;

		// Token: 0x040000CF RID: 207
		public ValueTuple<int, ComponentDataWrapper> referenceTest;

		// Token: 0x040000D0 RID: 208
		public ValueTuple<int, global::SimpleClass> simpleClass;

		// Token: 0x040000D1 RID: 209
		public ValueTuple<int, global::AdvancedClass> advancedClass;

		// Token: 0x040000D2 RID: 210
		public ValueTuple<int, global::SimpleStruct> simpleStruct;

		// Token: 0x040000D3 RID: 211
		public ValueTuple<int, global::AdvancedStruct> advancedStruct;

		// Token: 0x040000D4 RID: 212
		public ValueTuple<int, global::SimpleClass[]> classArray;

		// Token: 0x040000D5 RID: 213
		public ValueTuple<int, global::SimpleStruct[]> structArray;

		// Token: 0x040000D6 RID: 214
		public ValueTuple<int, List<global::AdvancedClass>> advancedList;

		// Token: 0x040000D7 RID: 215
		public ValueTuple<int, Dictionary<string, int>> dic;

		// Token: 0x040000D8 RID: 216
		public ValueTuple<int, global::TypesTest.TestEnum> enumTest;

		// Token: 0x040000D9 RID: 217
		public ValueTuple<int, ComponentDataWrapper> referenceArray;

		// Token: 0x040000DA RID: 218
		public ValueTuple<int, ComponentDataWrapper> referenceList;

		// Token: 0x040000DB RID: 219
		public ValueTuple<int, string> StringTest;

		// Token: 0x040000DC RID: 220
		public ValueTuple<int, int> IntTest;

		// Token: 0x040000DD RID: 221
		public ValueTuple<int, Color> ColorTest;

		// Token: 0x040000DE RID: 222
		public ValueTuple<int, Color32> Color32Test;

		// Token: 0x040000DF RID: 223
		public ValueTuple<int, Vector3> VectorTest;

		// Token: 0x040000E0 RID: 224
		public ValueTuple<int, ComponentDataWrapper> ReferenceTest;

		// Token: 0x040000E1 RID: 225
		public ValueTuple<int, global::SimpleClass> SimpleClass;

		// Token: 0x040000E2 RID: 226
		public ValueTuple<int, global::AdvancedClass> AdvancedClass;

		// Token: 0x040000E3 RID: 227
		public ValueTuple<int, global::SimpleStruct> SimpleStruct;

		// Token: 0x040000E4 RID: 228
		public ValueTuple<int, global::AdvancedStruct> AdvancedStruct;

		// Token: 0x040000E5 RID: 229
		public ValueTuple<int, global::SimpleClass[]> ClassArray;

		// Token: 0x040000E6 RID: 230
		public ValueTuple<int, global::SimpleStruct[]> StructArray;

		// Token: 0x040000E7 RID: 231
		public ValueTuple<int, List<global::AdvancedClass>> AdvancedList;

		// Token: 0x040000E8 RID: 232
		public ValueTuple<int, Dictionary<string, int>> Dic;

		// Token: 0x040000E9 RID: 233
		public ValueTuple<int, global::TypesTest.TestEnum> EnumTest;
	}
}
