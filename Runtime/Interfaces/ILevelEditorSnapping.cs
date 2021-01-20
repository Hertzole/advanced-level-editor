namespace Hertzole.ALE
{
    public interface ILevelEditorSnapping
    {
        bool EnableMoveSnap { get; set; }
        float MoveSnapX { get; set; }
        float MoveSnapY { get; set; }
        float MoveSnapZ { get; set; }

        bool EnableRotateSnap { get; set; }
        float RotateSnapX { get; set; }
        float RotateSnapY { get; set; }
        float RotateSnapZ { get; set; }

        bool EnableScaleSnap { get; set; }
        float ScaleSnapX { get; set; }
        float ScaleSnapY { get; set; }
        float ScaleSnapZ { get; set; }

        float Snap(float value, float increment);
    }
}
