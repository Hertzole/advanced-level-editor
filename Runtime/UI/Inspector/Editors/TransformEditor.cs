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
            if (TryGetField<Vector3>(GetProperty(0), out LevelEditorInspectorField positionField))
            {

            }

            if (TryGetField<Vector3>(GetProperty(1), out LevelEditorInspectorField rotationField))
            {

            }

            if (TryGetField<Vector3>(GetProperty(2), out LevelEditorInspectorField scaleField))
            {

            }
        }
    }
}
