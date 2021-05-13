#pragma warning disable CS0414
#pragma warning disable CS0067
#define temp

using Hertzole.ALE;
using MessagePack;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[MessagePackObject]
public struct MyCustomStruct
{
    [Key("str")]
    public string str;
    [Key("vec")]
    public Vector3 vec;
}

[Serializable]
public struct MyGooderStruct : IEquatable<MyGooderStruct>
{
    public string str;
    public Vector3 vec;

    public override bool Equals(object obj)
    {
        return obj is MyGooderStruct @struct && Equals(@struct);
    }

    public bool Equals(MyGooderStruct other)
    {
        return str == other.str &&
               vec.Equals(other.vec);
    }

    public override int GetHashCode()
    {
        int hashCode = 582594805;
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(str);
        hashCode = hashCode * -1521134295 + vec.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(MyGooderStruct left, MyGooderStruct right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(MyGooderStruct left, MyGooderStruct right)
    {
        return !(left == right);
    }
}

public class TestScript : MonoBehaviour, ILevelEditorGizmos
{
    public struct WrapperTemplate : IExposedWrapper
	{
		// Token: 0x06000077 RID: 119 RVA: 0x00004968 File Offset: 0x00002B68
		public WrapperTemplate(char A_1, string A_2, byte A_3, sbyte A_4, short A_5, ushort A_6, int A_7, uint A_8, long A_9, ulong A_10, float A_11, double A_12, decimal A_13, Vector2 A_14, Vector2Int A_15, Vector3 A_16, Vector3Int A_17, bool A_18, Color A_19, Color32 A_20, ComponentDataWrapper A_21, string[] A_22, global::MyCustomStruct A_23, Vector2 A_24, Vector2 A_25, Vector2 A_26, ComponentDataWrapper A_27, global::MyGooderStruct A_28, global::TestScript.TestEnum A_29, ComponentDataWrapper A_30)
		{
			this.charTest = new ValueTuple<int, char>(16, A_1);
			this.testString = new ValueTuple<int, string>(0, A_2);
			this.testByte = new ValueTuple<int, byte>(1, A_3);
			this.testSByte = new ValueTuple<int, sbyte>(2, A_4);
			this.testShort = new ValueTuple<int, short>(3, A_5);
			this.testUShort = new ValueTuple<int, ushort>(4, A_6);
			this.testInt = new ValueTuple<int, int>(5, A_7);
			this.testUint = new ValueTuple<int, uint>(6, A_8);
			this.testLong = new ValueTuple<int, long>(7, A_9);
			this.testULong = new ValueTuple<int, ulong>(8, A_10);
			this.floatTest = new ValueTuple<int, float>(9, A_11);
			this.doubleTest = new ValueTuple<int, double>(10, A_12);
			this.decimalTest = new ValueTuple<int, decimal>(11, A_13);
			this.vector2Test = new ValueTuple<int, Vector2>(12, A_14);
			this.vector2IntTest = new ValueTuple<int, Vector2Int>(13, A_15);
			this.vector3Test = new ValueTuple<int, Vector3>(14, A_16);
			this.vector3IntTest = new ValueTuple<int, Vector3Int>(15, A_17);
			this.boolTest = new ValueTuple<int, bool>(17, A_18);
			this.colorField = new ValueTuple<int, Color>(18, A_19);
			this.color32Field = new ValueTuple<int, Color32>(19, A_20);
			this.otherObject = new ValueTuple<int, ComponentDataWrapper>(20, A_21);
			this.messages = new ValueTuple<int, string[]>(21, A_22);
			this.structTest = new ValueTuple<int, global::MyCustomStruct>(22, A_23);
			this.secondVector3 = new ValueTuple<int, Vector2>(23, A_24);
			this.secondVector4 = new ValueTuple<int, Vector2>(24, A_25);
			this.secondVector5 = new ValueTuple<int, Vector2>(25, A_26);
			this.transformArray = new ValueTuple<int, ComponentDataWrapper>(26, A_27);
			this.gooderStruct = new ValueTuple<int, global::MyGooderStruct>(27, A_28);
			this.enumTest = new ValueTuple<int, global::TestScript.TestEnum>(28, A_29);
			this.gameObjectField = new ValueTuple<int, ComponentDataWrapper>(29, A_30);
		}

		// Token: 0x04000067 RID: 103
		public ValueTuple<int, char> charTest;

		// Token: 0x04000068 RID: 104
		public ValueTuple<int, string> testString;

		// Token: 0x04000069 RID: 105
		public ValueTuple<int, byte> testByte;

		// Token: 0x0400006A RID: 106
		public ValueTuple<int, sbyte> testSByte;

		// Token: 0x0400006B RID: 107
		public ValueTuple<int, short> testShort;

		// Token: 0x0400006C RID: 108
		public ValueTuple<int, ushort> testUShort;

		// Token: 0x0400006D RID: 109
		public ValueTuple<int, int> testInt;

		// Token: 0x0400006E RID: 110
		public ValueTuple<int, uint> testUint;

		// Token: 0x0400006F RID: 111
		public ValueTuple<int, long> testLong;

		// Token: 0x04000070 RID: 112
		public ValueTuple<int, ulong> testULong;

		// Token: 0x04000071 RID: 113
		public ValueTuple<int, float> floatTest;

		// Token: 0x04000072 RID: 114
		public ValueTuple<int, double> doubleTest;

		// Token: 0x04000073 RID: 115
		public ValueTuple<int, decimal> decimalTest;

		// Token: 0x04000074 RID: 116
		public ValueTuple<int, Vector2> vector2Test;

		// Token: 0x04000075 RID: 117
		public ValueTuple<int, Vector2Int> vector2IntTest;

		// Token: 0x04000076 RID: 118
		public ValueTuple<int, Vector3> vector3Test;

		// Token: 0x04000077 RID: 119
		public ValueTuple<int, Vector3Int> vector3IntTest;

		// Token: 0x04000078 RID: 120
		public ValueTuple<int, bool> boolTest;

		// Token: 0x04000079 RID: 121
		public ValueTuple<int, Color> colorField;

		// Token: 0x0400007A RID: 122
		public ValueTuple<int, Color32> color32Field;

		// Token: 0x0400007B RID: 123
		public ValueTuple<int, ComponentDataWrapper> otherObject;

		// Token: 0x0400007C RID: 124
		public ValueTuple<int, string[]> messages;

		// Token: 0x0400007D RID: 125
		public ValueTuple<int, global::MyCustomStruct> structTest;

		// Token: 0x0400007E RID: 126
		public ValueTuple<int, Vector2> secondVector3;

		// Token: 0x0400007F RID: 127
		public ValueTuple<int, Vector2> secondVector4;

		// Token: 0x04000080 RID: 128
		public ValueTuple<int, Vector2> secondVector5;

		// Token: 0x04000081 RID: 129
		public ValueTuple<int, ComponentDataWrapper> transformArray;

		// Token: 0x04000082 RID: 130
		public ValueTuple<int, global::MyGooderStruct> gooderStruct;

		// Token: 0x04000083 RID: 131
		public ValueTuple<int, global::TestScript.TestEnum> enumTest;

		// Token: 0x04000084 RID: 132
		public ValueTuple<int, ComponentDataWrapper> gameObjectField;
	}
    
    public enum TestEnum { Test1 = -10, Test3 = 66, Consistency = 520, No = 1 }

    [SerializeField]
    [ExposeToLevelEditor(0)]
    private string testString = null;
    [SerializeField]
    [ExposeToLevelEditor(1)]
    private byte testByte = 0;
    [SerializeField]
    [ExposeToLevelEditor(2)]
    private sbyte testSByte = 0;
    [SerializeField]
    [ExposeToLevelEditor(3)]
    private short testShort = 0;
    [SerializeField]
    [ExposeToLevelEditor(4)]
    private ushort testUShort = 0;
    [SerializeField]
    [ExposeToLevelEditor(5)]
    private int testInt = 0;
    [SerializeField]
    [ExposeToLevelEditor(6)]
    private uint testUint = 0;
    [SerializeField]
    [ExposeToLevelEditor(7)]
    private long testLong = 0;
    [SerializeField]
    [ExposeToLevelEditor(8)]
    private ulong testULong = 0;
    [SerializeField]
    [ExposeToLevelEditor(9)]
    private float floatTest = 0;
    [SerializeField]
    [ExposeToLevelEditor(10)]
    private double doubleTest = 0;
    [SerializeField]
    [ExposeToLevelEditor(11)]
    private decimal decimalTest = 0;

    [SerializeField]
    [ExposeToLevelEditor(12)]
    private Vector2 vector2Test = Vector2.zero;
    [SerializeField]
    [ExposeToLevelEditor(13)]
    private Vector2Int vector2IntTest = Vector2Int.zero;
    [SerializeField]
    [ExposeToLevelEditor(14)]
    private Vector3 vector3Test = Vector3.zero;
    [SerializeField]
    [ExposeToLevelEditor(15)]
    private Vector3Int vector3IntTest = Vector3Int.zero;

    [SerializeField]
    [ExposeToLevelEditor(16, order = -1000, customName = "FAAAA", visible = false)]
    private char charTest = 'A';

    [SerializeField]
    [ExposeToLevelEditor(17)]
    private bool boolTest = true;

    [SerializeField]
    [ExposeToLevelEditor(18)]
    private Color colorField = Color.red;
    [SerializeField]
    [ExposeToLevelEditor(19)]
    private Color32 color32Field;
    [SerializeField]
    [ExposeToLevelEditor(20)]
    private Transform otherObject = null;
    [SerializeField]
    [ExposeToLevelEditor(21)]
    private string[] messages = null;
    //[SerializeField]
    //[ExposeToLevelEditor(33)]
    //private MyCustomStruct[] structTestArray = null;
    [SerializeField]
    [ExposeToLevelEditor(22)]
    private MyCustomStruct structTest = new MyCustomStruct();
    [SerializeField]
    [ExposeToLevelEditor(23)]
    private Vector2 secondVector3 = Vector2.zero;
    [SerializeField]
    [ExposeToLevelEditor(24)]
    private Vector2 secondVector4 = Vector2.zero;
    [SerializeField]
    [ExposeToLevelEditor(25)]
    private Vector2 secondVector5 = Vector2.zero;
    [SerializeField]
    [ExposeToLevelEditor(26)]
    private Transform[] transformArray = null;
    [ExposeToLevelEditor(27)]
    [SerializeField]
    private MyGooderStruct gooderStruct = new MyGooderStruct();
    [SerializeField]
    [ExposeToLevelEditor(28)]
    private TestEnum enumTest = TestEnum.Test3;
    [SerializeField]
    [ExposeToLevelEditor(29)]
    private GameObject gameObjectField = null;

    private int[] ints = null;
    private Color32[] colors = null;

    public void DrawLevelEditorGizmos()
    {
        LevelEditorGizmos.DrawWireCube(transform.position, Vector3.one, transform.rotation, Color.green);

        LevelEditorGizmos.DrawSquare(transform.position + transform.forward * 2, Vector2.one, transform.rotation, Color.blue);

        if (otherObject != null)
        {
            LevelEditorGizmos.DrawLine(transform.position, otherObject.position, Color.red);
        }
    }

    private void Template(int id, object value)
    {
        if (id == 22)
        {
            if (structTest.Equals((MyCustomStruct)value))
            {
                structTest = (MyCustomStruct)value;
            }
        }
        else if (id == 23)
        {
            if (gooderStruct == (MyGooderStruct)value)
            {
                gooderStruct = (MyGooderStruct)value;
            }
        }
    }
#pragma warning restore CS0414
#pragma warning restore CS0067
}
