using System;

namespace Hertzole.ALE
{
    public class LevelEventArgs : EventArgs
    {
        public LevelEditorSaveData Data { get; private set; }

        public LevelEventArgs(LevelEditorSaveData data)
        {
            Data = data;
        }
    }

    public class LevelSavingLoadingArgs : LevelEventArgs
    {
        public string Location { get; private set; }

        public bool Cancel { get; set; }

        public LevelSavingLoadingArgs(LevelEditorSaveData data, string location) : base(data)
        {
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
