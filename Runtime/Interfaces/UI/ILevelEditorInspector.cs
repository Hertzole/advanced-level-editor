namespace Hertzole.ALE
{
    public interface ILevelEditorInspector
    {
        void Initialize();

        void BindObject(ILevelEditorObject target);
    }
}
