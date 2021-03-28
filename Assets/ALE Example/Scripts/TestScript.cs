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
