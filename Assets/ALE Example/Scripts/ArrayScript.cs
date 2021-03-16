#pragma warning disable CS0414
using Hertzole.ALE;
using System.Collections.Generic;
using UnityEngine;

public class ArrayScript : MonoBehaviour
{
#if UNITY_2019_3_OR_NEWER
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void ResetStatics()
    {
        LevelEditorSerializer.RegisterType<string[]>();
        LevelEditorSerializer.RegisterType<List<int>>();
    }
#endif

    [SerializeField]
    [ExposeToLevelEditor(0, visible = false)]
    private string[] stringTest = null;
    [SerializeField]
    [ExposeToLevelEditor(1, visible = false)]
    private List<int> listTest = null;
    //[SerializeField]
    //[ExposeToLevelEditor(2)]
    //private MyCustomStruct[] testArray = null;
    //[SerializeField]
    //[ExposeToLevelEditor(1)]
    //private MyCustomStruct structTest = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetValueTemplate(int id, object value)
    {
        if (id == 0)
        {
            listTest = (List<int>)value;
        }
    }
}
#pragma warning restore CS0414
