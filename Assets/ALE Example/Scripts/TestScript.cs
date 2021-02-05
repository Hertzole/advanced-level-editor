#define temp

using Hertzole.ALE;
using System;
using UnityEngine;

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

    public event Action<int, object> OnValueChanged;

    public ExposedProperty[] GetProperties()
    {
        return new ExposedProperty[1]
        {
            new ExposedProperty(0, typeof(string), "str", null, true, false)
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
    [SerializeField]
    [ExposeToLevelEditor(21)]
    private string[] messages = null;
    [SerializeField]
    [ExposeToLevelEditor(33)]
    private MyCustomStruct[] structTestArray = null;
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
#pragma warning restore CS0414

#if temp
    // TestScript
    // Token: 0x0600001E RID: 30 RVA: 0x00002AE4 File Offset: 0x00000CE4
    void Template(int id, object value, bool notify)
    {
        bool flag = false;
        if (id == 16)
        {
            if (!charTest.Equals((char)value))
            {
                charTest = (char)value;
                flag = true;
            }
        }
        else if (id == 0)
        {
            if (!testString.Equals((string)value))
            {
                testString = (string)value;
                flag = true;
            }
        }
        else if (id == 1)
        {
            if (!testByte.Equals((byte)value))
            {
                testByte = (byte)value;
                flag = true;
            }
        }
        else if (id == 2)
        {
            if (!testSByte.Equals((sbyte)value))
            {
                testSByte = (sbyte)value;
                flag = true;
            }
        }
        else if (id == 3)
        {
            if (!testShort.Equals((short)value))
            {
                testShort = (short)value;
                flag = true;
            }
        }
        else if (id == 4)
        {
            if (!testUShort.Equals((ushort)value))
            {
                testUShort = (ushort)value;
                flag = true;
            }
        }
        else if (id == 5)
        {
            if (!testInt.Equals((int)value))
            {
                testInt = (int)value;
                flag = true;
            }
        }
        else if (id == 6)
        {
            if (!testUint.Equals((uint)value))
            {
                testUint = (uint)value;
                flag = true;
            }
        }
        else if (id == 7)
        {
            if (!testLong.Equals((long)value))
            {
                testLong = (long)value;
                flag = true;
            }
        }
        else if (id == 8)
        {
            if (!testULong.Equals((ulong)value))
            {
                testULong = (ulong)value;
                flag = true;
            }
        }
        else if (id == 9)
        {
            if (!floatTest.Equals((float)value))
            {
                floatTest = (float)value;
                flag = true;
            }
        }
        else if (id == 10)
        {
            if (!doubleTest.Equals((double)value))
            {
                doubleTest = (double)value;
                flag = true;
            }
        }
        else if (id == 11)
        {
            if (!decimalTest.Equals((decimal)value))
            {
                decimalTest = (decimal)value;
                flag = true;
            }
        }
        else if (id == 12)
        {
            if (!vector2Test.Equals((Vector2)value))
            {
                vector2Test = (Vector2)value;
                flag = true;
            }
        }
        else if (id == 13)
        {
            if (!vector2IntTest.Equals((Vector2Int)value))
            {
                vector2IntTest = (Vector2Int)value;
                flag = true;
            }
        }
        else if (id == 14)
        {
            if (!vector3Test.Equals((Vector3)value))
            {
                vector3Test = (Vector3)value;
                flag = true;
            }
        }
        else if (id == 15)
        {
            if (!vector3IntTest.Equals((Vector3Int)value))
            {
                vector3IntTest = (Vector3Int)value;
                flag = true;
            }
        }
        else if (id == 17)
        {
            if (!boolTest.Equals((bool)value))
            {
                boolTest = (bool)value;
                flag = true;
            }
        }
        else if (id == 18)
        {
            if (!colorField.Equals((Color)value))
            {
                colorField = (Color)value;
                flag = true;
            }
        }
        else if (id == 19)
        {
            if (color32Field != (Color)value)
            {
                color32Field = (Color)value;
                flag = true;
            }
        }
        else if (id == 20)
        {
            if (!otherObject.Equals((Transform)value))
            {
                otherObject = (Transform)value;
                flag = true;
            }
        }
        else if (id == 21)
        {
            string[] array = Array.ConvertAll<object, string>((object[])value, (object para0) => (string)para0);
            if (messages != array)
            {
                messages = array;
                flag = true;
            }
        }
        else if (id == 55)
        {
            MyCustomStruct[] array = Array.ConvertAll((object[])value, (object item) => (MyCustomStruct)item);
            if (structTestArray != array)
            {
                structTestArray = array;
                flag = true;
            }
        }
        else
        {
            if (id != 22)
            {
                throw new ArgumentException(string.Format("There's no exposed property with the ID '{0}'.", id));
            }
            if (!structTest.Equals((MyCustomStruct)value))
            {
                structTest = (MyCustomStruct)value;
                flag = true;
            }
        }
        if (notify && flag)
        {
            Debug.Log("Changed");
            //Action<int, object> ale_ExposedToLevelEditor_OnValueChanged = this.ALE_ExposedToLevelEditor_OnValueChanged;
            //if (ale_ExposedToLevelEditor_OnValueChanged == null)
            //{
            //    return;
            //}
            //ale_ExposedToLevelEditor_OnValueChanged(id, value);
        }
    }


    private void Test(int id, object value, bool notify)
    {
        bool changed = false;

        if (id == 0)
        {
            if (!charTest.Equals((char)value))
            {
                charTest = (char)value;
            }

            if (!vector3Test.Equals((Vector3)value))
            {
                vector3Test = (Vector3)value;
                changed = true;
            }
        }
        else if (id == 1)
        {
            if (color32Field != (Color)value)
            {
                color32Field = (Color)value;
                changed = true;
            }
        }
        else if (id == 2)
        {
            if (!structTest.Equals((MyCustomStruct)value))
            {
                structTest = (MyCustomStruct)value;
                changed = true;
            }
        }
        else if (id == 3)
        {
            if (otherObject != (Transform)value)
            {
                otherObject = (Transform)value;
                changed = true;
            }
        }
        else if (id == 4)
        {
            string[] newArray = Array.ConvertAll((object[])value, item => (string)item);
            if (messages != newArray)
            {
                messages = newArray;
                changed = true;
            }
        }
        else if (id == 5)
        {
            int[] newArray = Array.ConvertAll((object[])value, item => (int)item);
            if (ints != newArray)
            {
                ints = newArray;
                changed = true;
            }
        }
        else
        {
            throw new ArgumentException("lol");
        }

        if (changed)
        {
            Debug.Log("Changed!");
        }
    }

    private void Test2(int id, object value, bool notify)
    {
        bool changed = false;

        if (id == 0)
        {
            if (otherObject != (Transform)value)
            {
                otherObject = (Transform)value;
                changed = true;
            }
        }
        else if (id == 2)
        {
            Color32[] newArray = Array.ConvertAll((object[])value, item => (Color32)item);
            if (colors != newArray)
            {
                colors = newArray;
                changed = true;
            }
        }
        else if (id == 1)
        {
            int[] newArray = Array.ConvertAll((object[])value, item => (int)item);
            if (ints != newArray)
            {
                ints = newArray;
                changed = true;
            }
        }
        else if (id == 6)
        {
            int[] newArray = Array.ConvertAll((object[])value, item => (int)item);
            if (ints != newArray)
            {
                ints = newArray;
                changed = true;
            }
        }
        else
        {
            throw new ArgumentException("lol");
        }

        if (changed)
        {
            Debug.Log("Changed!");
        }
    }
#endif
}
