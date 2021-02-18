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

        /// <summary>
        /// Adds a resource to the list.
        /// </summary>
        /// <param name="resource">The new resource you want to add.</param>
        /// <exception cref="DuplicateIDException">If a resource with the same ID already exists.</exception>
        public void AddResource(LevelEditorResource resource)
        {
            for (int i = 0; i < resources.Count; i++)
            {
                if (resources[i].ID == resource.ID)
                {
                    throw new DuplicateIDException($"There's already a resource in the list with the ID '{resource.ID}'.");
                }
            }

            resources.Add(resource);
        }

        public bool RemoveResource(LevelEditorResource resource)
        {
            return resources.Remove(resource);
        }
    }
}
