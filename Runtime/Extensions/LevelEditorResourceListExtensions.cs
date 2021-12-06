using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
    public static partial class LevelEditorExtensions
    {
        /// <summary>
        /// Gets the ID of a resource at a given index.
        /// </summary>
        /// <returns>The ID of the resource at the given index.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if your index is outside the bounds of the resources arrray.</exception>
        /// <exception cref="EmptyArrayException">Thrown if there are no resources.</exception>
        public static LevelEditorIdentifier GetItemID(this ILevelEditorResources x, int index)
        {
            IReadOnlyList<ILevelEditorResource> resources = x.GetResources();
            if (resources != null && resources.Count > 0)
            {
#if !ALE_STRIP_SAFETY || UNITY_EDITOR
                if (index < 0 || index >= resources.Count)
                {
                    throw new IndexOutOfRangeException($"Your index is out of range. You tried to get a resource at index {index} but there are only {resources.Count} resources.");
                }
#endif

                return resources[index].ID;
            }

            throw new EmptyArrayException("There are no resources to get.");
        }

        /// <summary>
        /// Gets the index of a resource with the provided ID.
        /// </summary>
        /// <returns>The index of a resource with the provided ID.</returns>
        /// <exception cref="ArgumentException">Thrown in there's no resource with the provided ID.</exception>
        /// <exception cref="EmptyArrayException">Thrown if there are no resources.</exception>
        public static int GetItemIndex(this ILevelEditorResources x, string id)
        {
            return GetItemIndex(x, new LevelEditorIdentifier(id));
        }

        public static int GetItemIndex(this ILevelEditorResources x, LevelEditorIdentifier identifier)
        {
            IReadOnlyList<ILevelEditorResource> resources = x.GetResources();
            if (resources != null && resources.Count > 0)
            {
                for (int i = 0; i < resources.Count; i++)
                {
                    if (resources[i].ID == identifier)
                    {
                        return i;
                    }
                }

                throw new ArgumentException($"There's no resource with the ID {identifier}.");
            }

            throw new EmptyArrayException("There are no resources to get.");
        }

        /// <summary>
        /// Gets the resource at the provided index.
        /// </summary>
        /// <returns>The resource at the provided index.</returns>
        /// <exception cref="ArgumentException">Thrown in there's no resource with the provided index.</exception>
        /// <exception cref="EmptyArrayException">Thrown if there are no resources.</exception>
        public static ILevelEditorResource GetResource(this ILevelEditorResources x, int index)
        {
            IReadOnlyList<ILevelEditorResource> resources = x.GetResources();
            if (resources != null && resources.Count > 0)
            {
#if !ALE_STRIP_SAFETY || UNITY_EDITOR
                if (index < 0 || index >= resources.Count)
                {
                    throw new IndexOutOfRangeException($"Your index is out of range. You tried to get a resource at index {index} but there are only {resources.Count} resources.");
                }
#endif

                return resources[index];
            }

            throw new EmptyArrayException("There are no resources to get.");
        }

        /// <summary>
        /// Gets the resource with the provided ID.
        /// </summary>
        /// <returns>The resource with the provided ID.</returns>
        /// <exception cref="ArgumentException">Thrown in there's no resource with the provided ID.</exception>
        /// <exception cref="EmptyArrayException">Thrown if there are no resources.</exception>
        public static ILevelEditorResource GetResource(this ILevelEditorResources x, string id)
        {
            return GetResource(x, new LevelEditorIdentifier(id));
        }

        public static ILevelEditorResource GetResource(this ILevelEditorResources x, LevelEditorIdentifier identifier)
        {
            IReadOnlyList<ILevelEditorResource> resources = x.GetResources();
            if (resources != null && resources.Count > 0)
            {
                for (int i = 0; i < resources.Count; i++)
                {
                    if (resources[i].ID == identifier)
                    {
                        return resources[i];
                    }
                }

                Debug.LogError($"There's no resource with the ID {identifier}.");
                return null;
            }

            throw new EmptyArrayException("There are no resources to get.");
        }
    }
}
