#if ALE_STRIP_UGUI
#define OBSOLETE
#endif

#if OBSOLETE && !UNITY_EDITOR
#define STRIP
#endif

#if !STRIP
namespace Hertzole.ALE
{
#if OBSOLETE
    [System.Obsolete("ILevelEditorResourceView has been stripped and will be removed on build.", true)]
#endif
    public interface ILevelEditorResourceView
    {
        event System.Action<string> OnClickAsset;
        event System.Action<int> OnClickFolder;

        void Initialize(ILevelEditorResource[] resources);
    }
}
#endif
