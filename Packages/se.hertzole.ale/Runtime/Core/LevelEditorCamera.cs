using UnityEngine;

namespace Hertzole.ALE
{
    public class LevelEditorCamera : MonoBehaviour, ILevelEditorCamera
    {
        public Camera CameraComponent
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public ViewTool CameraState
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
