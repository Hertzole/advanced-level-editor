namespace Hertzole.ALE
{
    public interface ILevelEditorMode
    {
        void OnModeEnable();

        void OnModeDisable();

        void OnModeUpdate();

        void OnModeLateUpdate();
    }
}
