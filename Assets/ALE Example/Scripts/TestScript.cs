#define temp

using Hertzole.ALE;
using MessagePack;
using System;
using UnityEngine;
using UnityEngine.Scripting;

[Serializable]
public class MyCustomStruct : IExposedToLevelEditor
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void AddToJson()
    {
        LevelEditorJsonSerializer.AddType<MyCustomStruct>();
    }

    public string str;
    public Vector3 vec;

    public string ComponentName { get { return "My Custom Struct"; } }

    public string TypeName { get { return typeof(MyCustomStruct).FullName; } }

    public int Order { get { return 0; } }

    public Type ComponentType { get { return typeof(MyCustomStruct); } }

    public event Action<int, object> OnValueChanged;

    public ExposedProperty[] GetProperties()
    {
        return new ExposedProperty[1]
        {
            new ExposedProperty(0, typeof(string), "str", null, true)
        };
    }

    public object GetValue(int id)
    {
        if (id == 0)
        {
            return str;
        }
        else
        {
            throw new ArgumentException("no");
        }
    }

    public Type GetValueType(int id)
    {
        if (id == 0)
        {
            return typeof(string);
        }
        else
        {
            throw new ArgumentException("no");
        }
    }

    public void SetValue(int id, object value, bool notify)
    {
        if (id == 0)
        {
            str = (string)value;
        }
    }
}

public class TestScript : MonoBehaviour, ILevelEditorGizmos
{

#pragma warning disable CS0414
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
    //[SerializeField]
    //[ExposeToLevelEditor(21)]
    //private string[] messages = null;
    //[SerializeField]
    //[ExposeToLevelEditor(33)]
    //private MyCustomStruct[] structTestArray = null;
    [SerializeField]
    [ExposeToLevelEditor(22)]
    private MyCustomStruct structTest = new MyCustomStruct();


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

    [Preserve]
    private static void AoTTest()
    {
        MessagePackSerializerOptions.Standard.Resolver.GetFormatter<decimal>();
    }
#pragma warning restore CS0414
}
