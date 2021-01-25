using UnityEngine;

namespace Hertzole.ALE
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Camera))]
    public class LevelEditorCamera : MonoBehaviour, ILevelEditorCamera
    {
        [SerializeField]
        private float moveSpeed = 15f;
        [SerializeField]
        private float lookSpeed = 5f;
        [SerializeField]
        private float orbitSpeed = 7f;
        [SerializeField]
        private float scrollModifier = 100f;
        [SerializeField]
        private float zoomSpeed = 0.1f;

        [Space]

        [SerializeField]
        private bool canFly = true;
        [SerializeField]
        private bool canElevate = true;
        [SerializeField]
        private bool canZoom = true;
        [SerializeField]
        private bool canDolly = true;
        [SerializeField]
        private bool canPan = true;
        [SerializeField]
        private bool canOrbit = true;

        [Header("Input")]
        [SerializeField]
        private string altModifier = "Alt Modifier";
        [SerializeField]
        private string cameraZoom = "Camera Zoom";
        [SerializeField]
        private string cameraFly = "Camera Fly";
        [SerializeField]
        private string cameraMove = "Camera Move";
        [SerializeField]
        private string cameraLook = "Camera Look";
        [SerializeField]
        private string cameraElevate = "Camera Elevate";
        [SerializeField]
        private string cameraOrbit = "Camera Orbit";
        [SerializeField]
        private string cameraPan = "Camera Pan";

        [Header("References")]
        [SerializeField]
        [RequireType(typeof(ILevelEditorInput))]
        private GameObject input = null;

        [SerializeField]
        [HideInInspector]
        private Camera cam = null;

        private bool eatMouse = false;
        private bool currentActionValid = false;
        private bool zooming = false;

        private float distanceToCamera = 10f;
        private float zoomProgress = 0f;
        private float rotationX = 0f;
        private float rotationY = 0;

        private const float MIN_CAM_DISTANCE = 1f;
        private const float MAX_CAM_DISTANCE = 100f;

        private Vector2 previousMousePosition;

        private Vector3 pivot = Vector3.zero;
        private Vector3 previousPosition = Vector3.zero;
        private Vector3 targetPosition = Vector3.zero;

        private ViewTool cameraState;

        private ILevelEditorInput realInput;

        public Camera CameraComponent { get { return cam; } }

        public ViewTool CameraState { get { return cameraState; } }

        private void Awake()
        {
            realInput = input.NeedComponent<ILevelEditorInput>();

            rotationX = transform.eulerAngles.y;
            rotationY = -transform.eulerAngles.x;

            previousPosition = transform.position;
        }

        private void Start()
        {
            distanceToCamera = Vector3.Distance(pivot, transform.position);
        }

        private void LateUpdate()
        {
            if (realInput.GetButtonUp(cameraOrbit) || realInput.GetButtonUp(cameraFly) || realInput.GetButtonUp(cameraPan))
            {
                currentActionValid = true;
                eatMouse = false;
            }
            else if (realInput.GetButtonDown(cameraOrbit) || realInput.GetButtonDown(cameraFly) || realInput.GetButtonDown(cameraPan))
            {
                currentActionValid = !realInput.IsMouseOverUI();
            }

            cameraState = ViewTool.None;

            if (zooming)
            {
                transform.position = Vector3.Lerp(previousPosition, targetPosition, (zoomProgress += Time.unscaledDeltaTime) / zoomSpeed);
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    zooming = false;
                }
            }

            if (((realInput.GetAxis(cameraZoom, false) != 0f && canZoom) || (realInput.GetButton(cameraFly) && realInput.GetButton(altModifier) && canDolly)) && !realInput.IsMouseOverUI())
            {
                float delta = realInput.GetAxis(cameraZoom, false);

                if (Mathf.Approximately(delta, 0f))
                {
                    cameraState = ViewTool.Dolly;
                    delta = CalcSignedMouseDelta(realInput.MousePosition, previousMousePosition);
                }

                distanceToCamera -= delta * (distanceToCamera / MAX_CAM_DISTANCE) * scrollModifier;
                distanceToCamera = Mathf.Clamp(distanceToCamera, MIN_CAM_DISTANCE, MAX_CAM_DISTANCE);
                transform.position = transform.localRotation * (Vector3.forward * -distanceToCamera) + pivot;
            }

            if (!currentActionValid)
            {
                Rect screen = new Rect(0, 0, Screen.width, Screen.height);
                if (screen.Contains(realInput.MousePosition))
                {
                    previousMousePosition = realInput.MousePosition;
                }

                return;
            }

            // WASD camera flying.
            if (realInput.GetButton(cameraFly) && !realInput.GetButton(altModifier) && canFly)
            {
                cameraState = ViewTool.Look;
                eatMouse = true;

                Vector2 lookInput = realInput.GetVector2(cameraLook, false);
                rotationX += lookInput.x * lookSpeed;
                rotationY += lookInput.y * lookSpeed;

                transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
                transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

                Vector2 moveInput = realInput.GetVector2(cameraMove, true);

                float speed = moveSpeed * Time.unscaledDeltaTime;
                transform.position += transform.forward * speed * moveInput.y;
                transform.position += transform.right * speed * moveInput.x;

                if (canElevate)
                {
                    transform.position += (transform.up * realInput.GetAxis(cameraElevate, true)) * speed;
                }

                pivot = transform.position + transform.forward * distanceToCamera;
            }
            else if (realInput.GetButton(altModifier) && realInput.GetButton(cameraOrbit) && canOrbit) // Orbit
            {
                cameraState = ViewTool.Orbit;
                eatMouse = true;

                Vector2 lookInput = realInput.GetVector2(cameraLook, false);
                rotationX += lookInput.x * orbitSpeed;
                rotationY += lookInput.y * orbitSpeed;

                transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
                transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
                transform.position = CalculateCameraPosition(pivot);
            }
            else if (realInput.GetButton(cameraPan) && canPan) // Pan
            {
                cameraState = ViewTool.Pan;

                Vector2 delta = realInput.MousePosition - previousMousePosition;

                delta.x = ScreenToWorldDistance(delta.x, distanceToCamera);
                delta.y = ScreenToWorldDistance(delta.y, distanceToCamera);

                transform.position -= transform.right * delta.x;
                transform.position -= transform.up * delta.y;

                pivot = transform.position + transform.forward * distanceToCamera;
            }

            previousMousePosition = realInput.MousePosition;
        }

        public bool IsUsingMouse()
        {
            return cameraState != ViewTool.None || eatMouse || realInput.GetButton(altModifier);
        }

        private Vector3 CalculateCameraPosition(Vector3 target)
        {
            return transform.localRotation * (Vector3.forward * -distanceToCamera) + target;
        }

        private float ScreenToWorldDistance(float screenDistance, float distanceFromCamera)
        {
            Vector3 start = cam.ScreenToWorldPoint(Vector3.forward * distanceFromCamera);
            Vector3 end = cam.ScreenToWorldPoint(new Vector3(screenDistance, 0f, distanceFromCamera));
            return CopySign(Vector3.Distance(start, end), screenDistance);
        }

        private float CalcSignedMouseDelta(Vector2 lhs, Vector2 rhs)
        {
            float delta = Vector2.Distance(lhs, rhs);
            float scale = 1f / Mathf.Min(Screen.width, Screen.height);

            // If horizontal movement is greater than vertical movement, use the X axis for sign.
            return Mathf.Abs(lhs.x - rhs.x) > Mathf.Abs(lhs.y - rhs.y)
                ? delta * scale * ((lhs.x - rhs.x) > 0f ? 1f : -1f)
                : delta * scale * ((lhs.y - rhs.y) > 0f ? 1f : -1f);
        }

        private float CopySign(float x, float y)
        {
            if (x < 0f && y < 0f || x > 0f && y > 0f || x == 0f || y == 0f)
            {
                return x;
            }
            else
            {
                return -x;
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
            if (cam == null)
            {
                cam = GetComponent<Camera>();
            }
        }
#endif
    }
}
