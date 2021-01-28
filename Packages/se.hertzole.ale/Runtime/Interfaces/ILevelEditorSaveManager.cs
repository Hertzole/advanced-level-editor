using System;

namespace Hertzole.ALE
{
    public class LevelEventArgs : EventArgs { }

    public class LevelSavingLoadingArgs : LevelEventArgs
    {
        public LevelEditorSaveData Data { get; private set; }
        public string Location { get; private set; }

        public bool Cancel { get; set; }

        public LevelSavingLoadingArgs(LevelEditorSaveData data, string location)
        {
            Data = data;
            Location = location;
        }
    }

    public interface ILevelEditorSaveManager
    {
        event EventHandler<LevelSavingLoadingArgs> OnLevelSaving;
        event EventHandler<LevelSavingLoadingArgs> OnLevelLoading;

        event EventHandler<LevelEventArgs> OnLevelSaved;
        event EventHandler<LevelEventArgs> OnLevelLoaded;

        void SaveLevel(string levelName);

        void SaveLevel(LevelEditorSaveData saveData);

        LevelEditorSaveData LoadLevel(string path);

        LevelEditorSaveData LoadLevel(LevelEditorSaveData data);

        LevelEditorSaveData GetLevelData(string levelName);

        string[] GetLevels();
    }
}
