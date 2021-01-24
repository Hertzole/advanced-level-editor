#if ALE_STRIP_UGUI
#define OBSOLETE
#endif

#if OBSOLETE && !UNITY_EDITOR
#define STRIP
#endif

#if !STRIP
using System;

namespace Hertzole.ALE
{
    public class AssetClickEventArgs : EventArgs
    {
        public ILevelEditorResource Resource { get; private set; }
        public bool IsFolder { get; private set; }

        public AssetClickEventArgs(ILevelEditorResource resource, bool isFolder)
        {
            Resource = resource;
            IsFolder = isFolder;
        }
    }

#if OBSOLETE
    [System.Obsolete("ILevelEditorResourceView has been stripped and will be removed on build.", true)]
#endif
    public interface ILevelEditorResourceView
    {
        event EventHandler<AssetClickEventArgs> OnClickAsset;
        event EventHandler<AssetClickEventArgs> OnClickFolder;

        void Initialize(ILevelEditorResource[] resources);
    }
}
#endif
