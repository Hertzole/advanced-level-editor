using Hertzole.ALE;
using System;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [ExposeToLevelEditor(0, order = 10, visible = false)]
    public int FirstTestButLast { get; set; }
    [ExposeToLevelEditor(1)]
    public string Test { get; set; }

    [ExposeToLevelEditor(2)]
    private float floatTest;
    [ExposeToLevelEditor(3)]
    private Vector3 VecTester { get; set; }

    public event Action<int, object> OnValueChanged;

    private object Temp(int id)
    {
        if (id == 1)
        {
            return FirstTestButLast;
        }
        else if (id == 1)
        {
            return Test;
        }
        else if (id == 2)
        {
            return FirstTestButLast + 10;
        }
        else if (id == 0)
        {
            return FirstTestButLast + 20;
        }
        throw new ArgumentException("No");
    }

    public void SetValueTest(int id, object value, bool notify)
    {
        bool changed = false;
        if (id == 0)
        {
            if (FirstTestButLast != (int)value)
            {
                FirstTestButLast = (int)value;
                changed = true;
            }
        }
        else if (id == 1)
        {
            if (Test != (string)value)
            {
                Test = (string)value;
                changed = true;
            }
        }
        else
        {
            throw new ArgumentException("No");
        }

        if (notify && changed)
        {
            OnValueChanged?.Invoke(id, value);
        }
    }

    private string SwitchTest()
    {
        int temp = 0;

        switch (temp)
        {
            case 0:
                return "One";
            case 1:
                return "Two";
            case 2:
                return "Three";
            case 3:
                return "Four";
            case 4:
                return "Five";
            case 5:
                return "Six";
            case 6:
                return "Seven";
            case 7:
                return "Eight";
            case 8:
                return "Nine";
            case 10:
                return "Ten";
            case 20:
                return "Eleven";
            case 30:
                return "Twelve";
            case 40:
                return "Thirteen";
            case 50:
                return "Fourteen";
            case 60:
                return "Fifteen";
            case 70:
                return "Sixteen";
            case 80:
                return "Seventeen";
            case 90:
                return "Eighteen";
            case 100:
                return "Nineteen";
            case 110:
                return "Twenty";
            case 120:
                return "Twentyone";
            case 130:
                return "Twentytwo";
            default:
                return "Unnown";
        }
    }
}
