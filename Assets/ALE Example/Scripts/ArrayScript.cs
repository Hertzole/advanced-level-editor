using Hertzole.ALE;
using UnityEngine;

public class ArrayScript : MonoBehaviour
{
    [SerializeField]
    [ExposeToLevelEditor(0, visible = false)]
    private string[] stringTest = null;
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
}
