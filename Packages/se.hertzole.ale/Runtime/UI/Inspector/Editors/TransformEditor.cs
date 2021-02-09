using UnityEngine;

namespace Hertzole.ALE
{
    public class TransformEditor : LevelEditorComponentEditor<Transform>
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void RegisterEditor()
        {
            AddEditor<Transform, TransformEditor>();
        }

        public override void BuildUI()
        {
            //TODO: Snapping
            //TODO: Make into 2D if 2D is enabled.
            if (TryGetField<Vector3>(GetProperty("position"), out LevelEditorInspectorField positionField))
            {

            }

            if (TryGetField<Vector3>(GetProperty("rotation"), out LevelEditorInspectorField rotationField))
            {

            }

            if (TryGetField<Vector3>(GetProperty("scale"), out LevelEditorInspectorField scaleField))
            {

            }
        }
    }
}
