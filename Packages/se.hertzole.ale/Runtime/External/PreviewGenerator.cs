// Based on https://github.com/yasirkula/UnityRuntimePreviewGenerator
/*
MIT License

Copyright (c) 2017 Süleyman Yasir KULA

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */

using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Hertzole.ALE
{
    public static class RuntimePreviewGenerator
    {
        // Source: https://github.com/MattRix/UnityDecompiled/blob/master/UnityEngine/UnityEngine/Plane.cs
        private struct ProjectionPlane
        {
            private readonly Vector3 normal;
            private readonly float distance;

            public ProjectionPlane(Vector3 inNormal, Vector3 inPoint)
            {
                normal = Vector3.Normalize(inNormal);
                distance = -Vector3.Dot(inNormal, inPoint);
            }

            public Vector3 ClosestPointOnPlane(Vector3 point)
            {
                float d = Vector3.Dot(normal, point) + distance;
                return point - normal * d;
            }

            public float GetDistanceToPoint(Vector3 point)
            {
                float signedDistance = Vector3.Dot(normal, point) + distance;
                if (signedDistance < 0f)
                {
                    signedDistance = -signedDistance;
                }

                return signedDistance;
            }
        }

        private class CameraSetup
        {
            private Vector3 position;
            private Quaternion rotation;

            private RenderTexture targetTexture;

            private Color backgroundColor;
            private bool orthographic;
            private float orthographicSize;
            private float nearClipPlane;
            private float farClipPlane;
            private float aspect;
            private CameraClearFlags clearFlags;

            public void GetSetup(Camera camera)
            {
                position = camera.transform.position;
                rotation = camera.transform.rotation;

                targetTexture = camera.targetTexture;

                backgroundColor = camera.backgroundColor;
                orthographic = camera.orthographic;
                orthographicSize = camera.orthographicSize;
                nearClipPlane = camera.nearClipPlane;
                farClipPlane = camera.farClipPlane;
                aspect = camera.aspect;
                clearFlags = camera.clearFlags;
            }

            public void ApplySetup(Camera camera)
            {
                camera.transform.position = position;
                camera.transform.rotation = rotation;

                camera.targetTexture = targetTexture;

                camera.backgroundColor = backgroundColor;
                camera.orthographic = orthographic;
                camera.orthographicSize = orthographicSize;
                camera.nearClipPlane = nearClipPlane;
                camera.farClipPlane = farClipPlane;
                camera.aspect = aspect;
                camera.clearFlags = clearFlags;

                targetTexture = null;
            }
        }

        private const int PREVIEW_LAYER = 22;
        private static Vector3 previewPosition = new Vector3(-9245f, 9899f, -9356f);

        private static Camera renderCamera;
        private static CameraSetup cameraSetup = new CameraSetup();

        private static List<Renderer> renderersList = new List<Renderer>(64);
        private static List<int> layersList = new List<int>(64);

        private static float aspect;
        private static float minX, maxX, minY, maxY;
        private static float maxDistance;

        private static Vector3 boundsCenter;
        private static ProjectionPlane projectionPlaneHorizontal, projectionPlaneVertical;

#if DEBUG_BOUNDS
        private static List<Transform> boundsDebugCubes = new List<Transform>( 8 );
        private static Material boundsMaterial;
#endif

        private static Camera internalCamera = null;
        private static Camera InternalCamera
        {
            get
            {
                if (internalCamera == null)
                {
                    internalCamera = new GameObject("ModelPreviewGeneratorCamera").AddComponent<Camera>();
                    internalCamera.enabled = false;
                    internalCamera.nearClipPlane = 0.01f;
                    internalCamera.cullingMask = 1 << PREVIEW_LAYER;
                    internalCamera.gameObject.hideFlags = HideFlags.HideAndDontSave;
                }

                return internalCamera;
            }
        }

        private static Camera previewRenderCamera;
        public static Camera PreviewRenderCamera
        {
            get { return previewRenderCamera; }
            set { previewRenderCamera = value; }
        }

        private static Vector3 previewDirection;
        public static Vector3 PreviewDirection
        {
            get { return previewDirection; }
            set { previewDirection = value.normalized; }
        }

        private static float padding;
        public static float Padding
        {
            get { return padding; }
            set { padding = Mathf.Clamp(value, -0.25f, 0.25f); }
        }

        private static Color backgroundColor;
        public static Color BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }

        private static bool orthographicMode;
        public static bool OrthographicMode
        {
            get { return orthographicMode; }
            set { orthographicMode = value; }
        }

        private static bool markTextureNonReadable;
        public static bool MarkTextureNonReadable
        {
            get { return markTextureNonReadable; }
            set { markTextureNonReadable = value; }
        }

        static RuntimePreviewGenerator()
        {
            PreviewRenderCamera = null;
            PreviewDirection = new Vector3(-1f, -1f, -1f);
            Padding = 0f;
            BackgroundColor = new Color(0.3f, 0.3f, 0.3f, 1f);
            OrthographicMode = false;
            MarkTextureNonReadable = true;

#if DEBUG_BOUNDS
            boundsMaterial = new Material( Shader.Find( "Legacy Shaders/Diffuse" ) )
            {
                hideFlags = HideFlags.HideAndDontSave,
                color = new Color( 0f, 1f, 1f, 1f )
            };
#endif
        }

        public static Texture2D GenerateMaterialPreview(Material material, PrimitiveType previewObject, int width = 64, int height = 64)
        {
            return GenerateMaterialPreviewWithShader(material, previewObject, null, null, width, height);
        }

        public static Texture2D GenerateMaterialPreviewWithShader(Material material, PrimitiveType previewPrimitive, Shader shader, string replacementTag, int width = 64, int height = 64)
        {
            GameObject previewModel = GameObject.CreatePrimitive(previewPrimitive);
            previewModel.gameObject.hideFlags = HideFlags.HideAndDontSave;
            previewModel.GetComponent<Renderer>().sharedMaterial = material;

            try
            {
                return GenerateModelPreviewWithShader(previewModel.transform, shader, replacementTag, width, height, false);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            finally
            {
                Object.DestroyImmediate(previewModel);
            }

            return null;
        }

        public static Texture2D GenerateModelPreview(Transform model, int width = 64, int height = 64, bool shouldCloneModel = false)
        {
            return GenerateModelPreviewWithShader(model, null, null, width, height, shouldCloneModel);
        }

        public static Texture2D GenerateModelPreviewWithShader(Transform model, Shader shader, string replacementTag, int width = 64, int height = 64, bool shouldCloneModel = false)
        {
            if (!model)
            {
                return null;
            }

            Texture2D result = null;

            if (!model.gameObject.scene.IsValid() || !model.gameObject.scene.isLoaded)
            {
                shouldCloneModel = true;
            }

            Transform previewObject;
            if (shouldCloneModel)
            {
                previewObject = Object.Instantiate(model, null, false);
                previewObject.gameObject.hideFlags = HideFlags.HideAndDontSave;
            }
            else
            {
                previewObject = model;

                layersList.Clear();
                GetLayerRecursively(previewObject);
            }

            bool isStatic = IsStatic(model);
            bool wasActive = previewObject.gameObject.activeSelf;
            Vector3 prevPos = previewObject.position;
            Quaternion prevRot = previewObject.rotation;

            try
            {
                SetupCamera();
                SetLayerRecursively(previewObject);

                if (!isStatic)
                {
                    previewObject.position = previewPosition;
                    previewObject.rotation = Quaternion.identity;
                }

                if (!wasActive)
                {
                    previewObject.gameObject.SetActive(true);
                }

                Vector3 previewDir = previewObject.rotation * previewDirection;

                renderersList.Clear();
                previewObject.GetComponentsInChildren(renderersList);

                Bounds previewBounds = new Bounds();
                bool init = false;
                for (int i = 0; i < renderersList.Count; i++)
                {
                    if (!renderersList[i].enabled)
                    {
                        continue;
                    }

                    if (!init)
                    {
                        previewBounds = renderersList[i].bounds;
                        init = true;
                    }
                    else
                    {
                        previewBounds.Encapsulate(renderersList[i].bounds);
                    }
                }

                if (!init)
                {
                    return null;
                }

                boundsCenter = previewBounds.center;
                Vector3 boundsExtents = previewBounds.extents;
                Vector3 boundsSize = 2f * boundsExtents;

                aspect = (float)width / height;
                renderCamera.aspect = aspect;
                renderCamera.transform.rotation = Quaternion.LookRotation(previewDir, previewObject.up);

#if DEBUG_BOUNDS
            boundsDebugCubes.Clear();
#endif

                float distance;
                if (orthographicMode)
                {
                    renderCamera.transform.position = boundsCenter;

                    minX = minY = Mathf.Infinity;
                    maxX = maxY = Mathf.NegativeInfinity;

                    Vector3 point = boundsCenter + boundsExtents;
                    ProjectBoundingBoxMinMax(point);
                    point.x -= boundsSize.x;
                    ProjectBoundingBoxMinMax(point);
                    point.y -= boundsSize.y;
                    ProjectBoundingBoxMinMax(point);
                    point.x += boundsSize.x;
                    ProjectBoundingBoxMinMax(point);
                    point.z -= boundsSize.z;
                    ProjectBoundingBoxMinMax(point);
                    point.x -= boundsSize.x;
                    ProjectBoundingBoxMinMax(point);
                    point.y += boundsSize.y;
                    ProjectBoundingBoxMinMax(point);
                    point.x += boundsSize.x;
                    ProjectBoundingBoxMinMax(point);

                    distance = boundsExtents.magnitude + 1f;
                    renderCamera.orthographicSize = (1f + padding * 2f) * Mathf.Max(maxY - minY, (maxX - minX) / aspect) * 0.5f;
                }
                else
                {
                    projectionPlaneHorizontal = new ProjectionPlane(renderCamera.transform.up, boundsCenter);
                    projectionPlaneVertical = new ProjectionPlane(renderCamera.transform.right, boundsCenter);

                    maxDistance = Mathf.NegativeInfinity;

                    Vector3 point = boundsCenter + boundsExtents;
                    CalculateMaxDistance(point);
                    point.x -= boundsSize.x;
                    CalculateMaxDistance(point);
                    point.y -= boundsSize.y;
                    CalculateMaxDistance(point);
                    point.x += boundsSize.x;
                    CalculateMaxDistance(point);
                    point.z -= boundsSize.z;
                    CalculateMaxDistance(point);
                    point.x -= boundsSize.x;
                    CalculateMaxDistance(point);
                    point.y += boundsSize.y;
                    CalculateMaxDistance(point);
                    point.x += boundsSize.x;
                    CalculateMaxDistance(point);

                    distance = (1f + padding * 2f) * Mathf.Sqrt(maxDistance);
                }

                renderCamera.transform.position = boundsCenter - previewDir * distance;
                renderCamera.farClipPlane = distance * 4f;

                RenderTexture temp = RenderTexture.active;
                RenderTexture renderTex = RenderTexture.GetTemporary(width, height, 16);
                RenderTexture.active = renderTex;
                if (backgroundColor.a < 1f)
                {
                    GL.Clear(false, true, backgroundColor);
                }

                renderCamera.targetTexture = renderTex;

                if (shader == null)
                {
                    renderCamera.Render();
                }
                else
                {
                    renderCamera.RenderWithShader(shader, replacementTag == null ? string.Empty : replacementTag);
                }

                renderCamera.targetTexture = null;

                result = new Texture2D(width, height, backgroundColor.a < 1f ? TextureFormat.RGBA32 : TextureFormat.RGB24, false);
                result.ReadPixels(new Rect(0, 0, width, height), 0, 0, false);
                result.Apply(false, markTextureNonReadable);

                RenderTexture.active = temp;
                RenderTexture.ReleaseTemporary(renderTex);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            finally
            {
#if DEBUG_BOUNDS
                for( int i = 0; i < boundsDebugCubes.Count; i++ )
                    Object.DestroyImmediate( boundsDebugCubes[i].gameObject );

                boundsDebugCubes.Clear();
#endif

                if (shouldCloneModel)
                {
                    Object.DestroyImmediate(previewObject.gameObject);
                }
                else
                {
                    if (!wasActive)
                    {
                        previewObject.gameObject.SetActive(false);
                    }

                    if (!isStatic)
                    {
                        previewObject.position = prevPos;
                        previewObject.rotation = prevRot;
                    }

                    int index = 0;
                    SetLayerRecursively(previewObject, ref index);
                }

                if (renderCamera == previewRenderCamera)
                {
                    cameraSetup.ApplySetup(renderCamera);
                }
            }

            return result;
        }

        private static void SetupCamera()
        {
            if (previewRenderCamera)
            {
                cameraSetup.GetSetup(previewRenderCamera);

                renderCamera = previewRenderCamera;
                renderCamera.nearClipPlane = 0.01f;
            }
            else
            {
                renderCamera = InternalCamera;
            }

            renderCamera.backgroundColor = backgroundColor;
            renderCamera.orthographic = orthographicMode;
            renderCamera.clearFlags = backgroundColor.a < 1f ? CameraClearFlags.Depth : CameraClearFlags.Color;
        }

        private static void ProjectBoundingBoxMinMax(Vector3 point)
        {
#if DEBUG_BOUNDS
        CreateDebugCube( point, Vector3.zero, new Vector3( 0.5f, 0.5f, 0.5f ) );
#endif

            Vector3 localPoint = renderCamera.transform.InverseTransformPoint(point);
            if (localPoint.x < minX)
            {
                minX = localPoint.x;
            }

            if (localPoint.x > maxX)
            {
                maxX = localPoint.x;
            }

            if (localPoint.y < minY)
            {
                minY = localPoint.y;
            }

            if (localPoint.y > maxY)
            {
                maxY = localPoint.y;
            }
        }

        private static void CalculateMaxDistance(Vector3 point)
        {
#if DEBUG_BOUNDS
        CreateDebugCube( point, Vector3.zero, new Vector3( 0.5f, 0.5f, 0.5f ) );
#endif

            Vector3 intersectionPoint = projectionPlaneHorizontal.ClosestPointOnPlane(point);

            float horizontalDistance = projectionPlaneHorizontal.GetDistanceToPoint(point);
            float verticalDistance = projectionPlaneVertical.GetDistanceToPoint(point);

            // Credit: https://docs.unity3d.com/Manual/FrustumSizeAtDistance.html
            float halfFrustumHeight = Mathf.Max(verticalDistance, horizontalDistance / aspect);
            float distance = halfFrustumHeight / Mathf.Tan(renderCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);

            float distanceToCenter = (intersectionPoint - previewDirection * distance - boundsCenter).sqrMagnitude;
            if (distanceToCenter > maxDistance)
            {
                maxDistance = distanceToCenter;
            }
        }

        private static bool IsStatic(Transform obj)
        {
            if (obj.gameObject.isStatic)
            {
                return true;
            }

            for (int i = 0; i < obj.childCount; i++)
            {
                if (IsStatic(obj.GetChild(i)))
                {
                    return true;
                }
            }

            return false;
        }

        private static void SetLayerRecursively(Transform obj)
        {
            obj.gameObject.layer = PREVIEW_LAYER;
            for (int i = 0; i < obj.childCount; i++)
            {
                SetLayerRecursively(obj.GetChild(i));
            }
        }

        private static void GetLayerRecursively(Transform obj)
        {
            layersList.Add(obj.gameObject.layer);
            for (int i = 0; i < obj.childCount; i++)
            {
                GetLayerRecursively(obj.GetChild(i));
            }
        }

        private static void SetLayerRecursively(Transform obj, ref int index)
        {
            obj.gameObject.layer = layersList[index++];
            for (int i = 0; i < obj.childCount; i++)
            {
                SetLayerRecursively(obj.GetChild(i), ref index);
            }
        }

#if DEBUG_BOUNDS
        private static void CreateDebugCube( Vector3 position, Vector3 rotation, Vector3 scale )
        {
            Transform cube = GameObject.CreatePrimitive( PrimitiveType.Cube ).transform;
            cube.localPosition = position;
            cube.localEulerAngles = rotation;
            cube.localScale = scale;
            cube.gameObject.layer = PREVIEW_LAYER;
            cube.gameObject.hideFlags = HideFlags.HideAndDontSave;

            cube.GetComponent<Renderer>().sharedMaterial = boundsMaterial;

            boundsDebugCubes.Add( cube );
        }
#endif
    }
}
