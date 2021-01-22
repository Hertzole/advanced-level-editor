using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorSaveManager : MonoBehaviour, ILevelEditorSaveManager
    {
        public LevelEditorSaveData GetLevelData(string levelName)
        {
            throw new System.NotImplementedException();
        }

        public string[] GetLevels()
        {
            throw new System.NotImplementedException();
        }

        public LevelEditorSaveData LoadLevel(string path)
        {
            throw new System.NotImplementedException();
        }

        public LevelEditorSaveData LoadLevel(LevelEditorSaveData data)
        {
            throw new System.NotImplementedException();
        }

        public void SaveLevel(string levelName)
        {
            throw new System.NotImplementedException();
        }

        public void SaveLevel(LevelEditorSaveData saveData)
        {
            throw new System.NotImplementedException();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
