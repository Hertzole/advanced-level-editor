namespace Hertzole.ALE
{
    public interface ILevelEditorInspector
    {
        void Initialize(ILevelEditorUI ui);

        void BindObject(ILevelEditorObject target);
    }
}
