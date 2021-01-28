#define temp

using Hertzole.ALE;
using UnityEngine;
#if temp
using System;
#endif

public class TestScript : MonoBehaviour
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

    private int[] ints = null;
    private Color32[] colors = null;
#pragma warning restore CS0414

#if temp
    private void Test(int id, object value, bool notify)
    {
        bool changed = false;

        if (id == 3)
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
