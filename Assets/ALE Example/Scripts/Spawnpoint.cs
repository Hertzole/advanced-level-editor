using UnityEngine;

namespace Hertzole.ALE.Example
{
    public class Spawnpoint : MonoBehaviour, ILevelEditorGizmos
    {
        [SerializeField] 
        [ExposeToLevelEditor(0)]
        private Vector3 offset = default;
        
        public void DrawLevelEditorGizmos(ILevelEditorGizmosDrawer drawer)
        {
            drawer.DrawWireCube(transform.position + offset, Vector3.one, Color.green);
        }
    }
}
