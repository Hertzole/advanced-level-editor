using Hertzole.ALE;
using System;
using UnityEngine;

public class TilemapTest : MonoBehaviour
{
    private int orderInLayer;

    private Vector3 vecTest;

    private string test2 = "";

    [ExposeToLevelEditor(0)]
    public int OrderInLayer
    {
        get
        {
            return orderInLayer;
        }

        set
        {
            orderInLayer = value;
        }
    }

    [ExposeToLevelEditor(1)]
    public string Test1 { get; set; } = "";

    [ExposeToLevelEditor(2)]
    public string Test2 { get { return test2; } set { test2 = value; } }

    [ExposeToLevelEditor(3)]
    public Vector3 VecTest { get { return vecTest; } set { vecTest = value; } }

    [ExposeToLevelEditor(4)]
    public Vector3 VecTest2 { get; set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Template(int id, object value, bool notify)
    {
        bool flag = false;
        if (id == 0)
        {
            if (!OrderInLayer.Equals((int)value))
            {
                OrderInLayer = (int)value;
                flag = true;
            }
        }
        else if (id == 1)
        {
            if (Test1 != (string)value)
            {
                Test1 = (string)value;
                flag = true;
            }
        }
        else if (id == 2)
        {
            if (Test2 != (string)value)
            {
                Test2 = (string)value;
                flag = true;
            }
        }
        else if (id == 3)
        {
            Vector3 vector = VecTest;
            if (vector != (Vector3)value)
            {
                VecTest = (Vector3)value;
                flag = true;
            }
        }
        else
        {
            if (id != 4)
            {
                throw new ArgumentException(string.Format("There's no exposed property with the ID '{0}'.", id));
            }
            Vector3 vecTest = VecTest2;
            if (vecTest != (Vector3)value)
            {
                VecTest2 = (Vector3)value;
                flag = true;
            }
        }
        if (notify && flag)
        {
            Debug.Log("Changed");
        }
    }
}
