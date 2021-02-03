namespace Hertzole.ALE
{
    public class HierarchyTree : TreeControl<HierarchyItem, ILevelEditorObject>
    {
        private void OnEnable()
        {
            OnReparenting += OnTreeReparenting;
        }

        private void OnDisable()
        {
            OnReparenting -= OnTreeReparenting;
        }

        private void OnTreeReparenting(object sender, TreeReparentingEventArgs<ILevelEditorObject> e)
        {
            if (e.DraggingItem.MyGameObject.TryGetComponent(out LevelEditorObjectSettings settings))
            {
                if (!settings.CanReparent)
                {
                    if (e.Action == ItemDropAction.SetLastChild)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        if (e.DraggingItem.MyGameObject.transform.parent != e.Target.MyGameObject.transform.parent)
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }
        }
    }
}
