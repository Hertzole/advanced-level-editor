using UnityEngine;

namespace Hertzole.ALE.Example
{
    public class Spawnpoint : MonoBehaviour, ILevelEditorGizmos
    {
        public void DrawLevelEditorGizmos(ILevelEditorGizmosDrawer drawer)
        {
            drawer.DrawWireCube(transform.position, Vector3.one, Color.green);
        }
    }
}
