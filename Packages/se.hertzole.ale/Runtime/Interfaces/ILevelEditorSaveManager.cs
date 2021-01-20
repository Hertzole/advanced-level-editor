namespace Hertzole.ALE
{
    public interface ILevelEditorSaveManager
    {
        void SaveLevel(string levelName);

        void SaveLevel(LevelEditorSaveData saveData);

        LevelEditorSaveData LoadLevel(string path);

        LevelEditorSaveData LoadLevel(LevelEditorSaveData data);

        LevelEditorSaveData GetLevelData(string levelName);

        string[] GetLevels();
    }
}
