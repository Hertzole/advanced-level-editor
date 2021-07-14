#if UNITY_2019_1_OR_NEWER && ALE_URP
#define URP
#endif

using System.Collections.Generic;
using UnityEngine;
#if URP
using UnityEngine.Rendering;
#endif

namespace Hertzole.ALE
{
#if UNITY_EDITOR
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("ALE/GL Renderer", 2)]
#endif
    [DefaultExecutionOrder(-10000)]
    public class LevelEditorGLRenderer : MonoBehaviour
    {
        [SerializeField]
        private Shader lineShader = null;

#if !URP
        [SerializeField]
        [HideInInspector]
        private Camera cam = null;
#endif

        protected ILevelEditorGizmosDrawer drawer;
        
        protected readonly List<ILevelEditorGizmos> renderObjects = new List<ILevelEditorGizmos>(32);
        protected readonly List<ILevelEditorSelectedGizmos> selectedRenderObjects = new List<ILevelEditorSelectedGizmos>(32);

        private static LevelEditorGLRenderer instance;

        public Shader LineShader { get { return lineShader; } }

#if UNITY_2019_3_OR_NEWER
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void ResetStatics()
        {
            instance = null;
        }
#endif

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;

                drawer = SetupDrawer();
            }
        }

        protected virtual ILevelEditorGizmosDrawer SetupDrawer()
        {
            return new LevelEditorGLDrawer(lineShader);
        }

        private void OnEnable()
        {
            if (instance == null)
            {
                instance = this;
            }

#if URP
            RenderPipelineManager.endCameraRendering += OnEndCameraRendering;
#endif
        }

#if URP
        private void OnDisable()
        {
            RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
        }
#endif

        public static void Add(ILevelEditorGizmos gizmos)
        {
            if (instance != null)
            {
                instance.renderObjects.Add(gizmos);
            }
        }

        public static void Add(ILevelEditorSelectedGizmos gizmos)
        {
            if (instance != null)
            {
                instance.selectedRenderObjects.Add(gizmos);
            }
        }

        public static void Remove(ILevelEditorGizmos gizmos)
        {
            if (instance != null)
            {
                instance.renderObjects.Remove(gizmos);
            }
        }

        public static void Remove(ILevelEditorSelectedGizmos gizmos)
        {
            if (instance != null)
            {
                instance.selectedRenderObjects.Remove(gizmos);
            }
        }

#if !URP
        private void OnPostRender()
        {
            Draw(cam);
        }
#else
        private void OnEndCameraRendering(ScriptableRenderContext context, Camera renderCamera)
        {
            Draw(renderCamera);
        }
#endif

        protected virtual void Draw(Camera renderCamera)
        {
            if (renderObjects == null || drawer == null)
            {
                return;
            }

            GL.PushMatrix();
            try
            {
                GL.LoadProjectionMatrix(GL.GetGPUProjectionMatrix(renderCamera.projectionMatrix, false));

                for (int i = 0; i < renderObjects.Count; i++)
                {
                    renderObjects[i].DrawLevelEditorGizmos(drawer);
                }

                for (int i = 0; i < selectedRenderObjects.Count; i++)
                {
                    selectedRenderObjects[i].DrawLevelEditorGizmosSelected(drawer);
                }
            }
            finally
            {
                GL.PopMatrix();
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            GetStandardComponents();
        }

        private void Reset()
        {
            GetStandardComponents();
        }

        private void GetStandardComponents()
        {
#if !URP
            if (cam == null)
            {
                cam = GetComponent<Camera>();
            }
#endif

            if (lineShader == null)
            {
                lineShader = Shader.Find("Hertzole/ALE/Unlit Line");
            }
        }
#endif
    }
}