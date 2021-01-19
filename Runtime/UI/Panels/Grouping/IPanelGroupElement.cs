using UnityEngine;

namespace Hertzole.ALE
{
    public interface IPanelGroupElement
    {
        PanelCanvas Canvas { get; }
        PanelGroup Group { get; }

        Vector2 Position { get; }
        Vector2 Size { get; }
        Vector2 MinSize { get; }

        void ResizeTo(Vector2 newSize, PanelDirection horizontalDir = PanelDirection.Right, PanelDirection verticalDir = PanelDirection.Bottom);

        void DockToRoot(PanelDirection direction);
        void DockToPanel(IPanelGroupElement anchor, PanelDirection direction);

        IPanelGroupElement GetSurroundingElement(PanelDirection direction);
    }
}
