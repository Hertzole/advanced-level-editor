using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
#if UNITY_EDITOR
    [CreateAssetMenu(fileName = "New Resource List", menuName = "ALE/Resource List")]
#endif
    public class LevelEditorResourceList : ScriptableObject, ILevelEditorResources
    {
        [SerializeField]
        private List<LevelEditorResource> resources = null;

        private void OnEnable()
        {
            if (resources == null || resources.Count == 0)
            {
                resources = new List<LevelEditorResource>(GenerateRoot());
            }
        }

        private LevelEditorResource[] GenerateRoot()
        {
            return new LevelEditorResource[1]
            {
                new LevelEditorResource()
                {
                    Name = "Root",
                    ID = "ale_tree_view_root",
                    Hidden = false,
                    Limit = 0,
                    Asset = null,
                    TreeDepth = -1,
                    TreeID = 0
                }
            };
        }

        public ILevelEditorResource[] GetResources()
        {
            return resources.ToArray();
        }

        public List<LevelEditorResource> GetResourcesList()
        {
            return resources;
        }

        public void AddResource(LevelEditorResource resource)
        {
            resources.Add(resource);
        }
    }
}
