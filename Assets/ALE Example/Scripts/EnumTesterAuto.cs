using UnityEngine;

public class EnumTesterAuto : MonoBehaviour
{
    public enum TestEnum { Test1, Test3, Consistency, No }

    [SerializeField]
    //[ExposeToLevelEditor(0)]
    private TestEnum enumTest = TestEnum.Test3;
    [SerializeField]
    //[ExposeToLevelEditor(1)]
    private TestEnum[] enumArrayTest = null;

    //[ExposeToLevelEditor(2)]
    public TestEnum EnumProperty { get; set; }
}
