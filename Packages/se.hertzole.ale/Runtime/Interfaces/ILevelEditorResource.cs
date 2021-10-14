using UnityEngine;

namespace Hertzole.ALE
{
    public interface ILevelEditorResource
    {
        string Name { get; }
        LevelEditorIdentifier ID { get; }
        int Limit { get; }
        bool Hidden { get; }
        bool CustomIcon { get; }
        Sprite Icon { get; }
        Object Asset { get; }
    }
}
