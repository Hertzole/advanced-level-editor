using Hertzole.ALE;
using UnityEngine;

public class GridDrawTest : MonoBehaviour, ILevelEditorGizmos
{
    [SerializeField]
    [ExposeToLevelEditor(0)]
    private Vector2Int size = new Vector2Int(10, 10);
    [SerializeField]
    [ExposeToLevelEditor(1)]
    private Vector2 spacing = Vector2.one;
    [SerializeField]
    [ExposeToLevelEditor(2)]
    private Color gridColor = Color.white;

    public void DrawLevelEditorGizmos()
    {
        LevelEditorGizmos.Draw2DGrid(transform.position, size, spacing, transform.rotation, gridColor);
    }
}
