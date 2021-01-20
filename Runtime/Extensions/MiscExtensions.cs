namespace Hertzole.ALE
{
    public static partial class LevelEditorExtensions
    {
        public static bool HasChildren<T>(this IEditorTreeViewItem<T> x)
        {
            return x.Children != null && x.Children.Count > 0;
        }

        public static bool Equals<T>(this IEditorTreeViewItem<T> x, IEditorTreeViewItem<T> other)
        {
            return x.TreeID == other.TreeID && x.TreeDepth == other.TreeDepth;
        }

        public static bool HasChildren(this ILevelEditorObject x)
        {
            return x.Children != null && x.Children.Count > 0;
        }
    }
}
