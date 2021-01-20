using System;

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
        public static string GetItemID(this ILevelEditorResources x, int index)
        {
            ILevelEditorResource[] resources = x.GetResources();
            if (resources != null && resources.Length > 0)
            {
#if !ALE_STRIP_SAFETY || UNITY_EDITOR
                if (index < 0 || index >= resources.Length)
                {
                    throw new IndexOutOfRangeException($"Your index is out of range. You tried to get a resource at index {index} but there are only {resources.Length} resources.");
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
            ILevelEditorResource[] resources = x.GetResources();
            if (resources != null && resources.Length > 0)
            {
                for (int i = 0; i < resources.Length; i++)
                {
                    if (resources[i].ID == id)
                    {
                        return i;
                    }
                }

                throw new ArgumentException($"There's no resource with the ID {id}.");
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
            ILevelEditorResource[] resources = x.GetResources();
            if (resources != null && resources.Length > 0)
            {
#if !ALE_STRIP_SAFETY || UNITY_EDITOR
                if (index < 0 || index >= resources.Length)
                {
                    throw new IndexOutOfRangeException($"Your index is out of range. You tried to get a resource at index {index} but there are only {resources.Length} resources.");
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
            ILevelEditorResource[] resources = x.GetResources();
            if (resources != null && resources.Length > 0)
            {
                for (int i = 0; i < resources.Length; i++)
                {
                    if (resources[i].ID == id)
                    {
                        return resources[i];
                    }
                }

                throw new ArgumentException($"There's no resource with the ID {id}.");
            }

            throw new EmptyArrayException("There are no resources to get.");
        }
    }
}
