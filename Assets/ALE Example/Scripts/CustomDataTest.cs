using Hertzole.ALE;
using UnityEngine;

public class CustomDataTest : MonoBehaviour
{
    [SerializeField]
    private LevelEditorSaveManager saveManager = null;

    // Start is called before the first frame update
    void Start()
    {
        saveManager.OnLevelSaving += OnLevelSaving;
        saveManager.OnLevelLoaded += OnLevelLoaded;
    }

    private void OnLevelLoaded(object sender, LevelEventArgs e)
    {
        if (e.TryGetCustomData("test", out int intValue))
        {
            Debug.Log(intValue);
        }

        //if (e.TryGetCustomData("messages", out string[] messages))
        //{
        //    foreach (string m in messages)
        //    {
        //        Debug.Log(m);
        //    }
        //}
    }

    private void OnLevelSaving(object sender, LevelSavingLoadingArgs e)
    {
        e.AddCustomData("test", 32);
        //e.AddCustomData("messages", new string[] { "hello", "world" });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
