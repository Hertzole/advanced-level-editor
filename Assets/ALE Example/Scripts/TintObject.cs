using System;
using Hertzole.ALE;
using UnityEngine;

public class TintObject : MonoBehaviour
{
    public struct WrapperTemplate : IExposedWrapper
    {
        public WrapperTemplate(Color32 color)
        {
            Color = (0, color);
            myStruct = (1, new MyCustomStruct());
        }

        public readonly ValueTuple<int, Color32> Color;
        public readonly ValueTuple<int, MyCustomStruct> myStruct;
    }
    
    [SerializeField]
    [HideInInspector]
    private Renderer ren = null;

    [ExposeToLevelEditor(0)]
    public Color32 Color { get { return ren.material.color; } set { ren.material.color = value; } }
    [SerializeField] 
    [ExposeToLevelEditor(1)]
    private MyCustomStruct myStruct = default;

    public void ApplyWrapperTemplate(IExposedWrapper wrapper)
    {
        if (wrapper is WrapperTemplate w)
        {
            myStruct = w.myStruct.Item2;
            Color = w.Color.Item2;
        }
    }
    
    // TintObject
    // Token: 0x06000080 RID: 128 RVA: 0x000044D8 File Offset: 0x000026D8
    void SetValueTemplate(int id, object value, bool notify)
    {
        bool flag = false;
        if (id == 0)
        {
            if (value is Color32 color)
            {
                if (!Color.Equals(color))
                {
                    Color = color;
                    flag = true;
                }
            }
        }
        else
        {
            Debug.LogWarning(string.Format("There's no exposed property with the ID '{0}'.", id));
        }
        if (notify && flag)
        {
            Debug.Log("It changed");
        }
    }


#if UNITY_EDITOR
    private void OnValidate()
    {
        GetStandardComponents();
    }

    private void Reset()
    {
        GetStandardComponents();
    }

    private void GetStandardComponents()
    {
        if (ren == null)
        {
            ren = GetComponent<Renderer>();
        }
    }
#endif
}
