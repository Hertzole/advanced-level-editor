using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Object = UnityEngine.Object;

namespace Hertzole.ALE
{
	/// <summary>
	/// Only used to keep track of level editor objects. Does not actually delete or create any objects.
	/// </summary>
	public static class LevelEditorWorld
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void ResetStatics()
		{
			objects.Clear();
			getObjectsList.Clear();
		}
		
		private static readonly List<ILevelEditorObject> objects = new List<ILevelEditorObject>();
		private static readonly List<ILevelEditorObject> getObjectsList = new List<ILevelEditorObject>();

		public static void AddObject(ILevelEditorObject value)
		{
			LevelEditorLogger.Log($"Add object to world: {value}");
			Assert.IsFalse(objects.Contains(value), "This object has already been added to the world.");

			objects.Add(value);
		}

		public static bool RemoveObject(ILevelEditorObject value)
		{
			LevelEditorLogger.Log($"Remove objects from world: {value}");
			return objects.Remove(value);
		}

		public static bool RemoveObject(uint instanceId)
		{
			LevelEditorLogger.Log($"Remove object from world using instance ID: {instanceId}");
			return TryGetObject(instanceId, out ILevelEditorObject value) && RemoveObject(value);
		}

		public static bool TryGetObject(uint instanceId, out ILevelEditorObject value)
		{
			bool result = TryGetObjects(new uint[1] { instanceId }, out ILevelEditorObject[] values);
			if (values != null && values.Length == 1)
			{
				value = values[0];
			}
			else
			{
				value = null;
			}

			return result;
		}
		
		public static bool TryGetObjects(uint[] ids, out ILevelEditorObject[] value)
		{
			if (objects == null || objects.Count == 0)
			{
				value = Array.Empty<ILevelEditorObject>();
				return false;
			}
			
			getObjectsList.Clear();

			for (int i = 0; i < ids.Length; i++)
			{
				for (int j = 0; j < objects.Count; j++)
				{
					if (objects[j].InstanceID == ids[i])
					{
						getObjectsList.Add(objects[j]);
						break;
					}
				}
			}

			value = getObjectsList.ToArray();
			return value.Length > 0;
		}

		public static bool TryGetObject<T>(uint instanceId, out T value) where T : Object
		{
			if (TryGetObject(instanceId, typeof(T), out Object val))
			{
				value = (T) val;
				return true;
			}

			value = null;
			return false;
		}

		public static bool TryGetObject(uint instanceId, Type type, out Object value)
		{
			bool result = TryGetObjects(new uint[1] { instanceId }, type, out Object[] values);
			if (values != null && values.Length == 1)
			{
				value = values[0];
			}
			else
			{
				value = null;
			}

			return result;
		}
		
		public static bool TryGetObjects<T>(uint[] ids, out T[] value) where T : Object
		{
			if (objects == null || objects.Count == 0)
			{
				value = Array.Empty<T>();
				return false;
			}

			List<T> values = new List<T>();

			for (int i = 0; i < ids.Length; i++)
			{
				bool found = false;
				for (int j = 0; j < objects.Count; j++)
				{
					if (objects[j].InstanceID == ids[i])
					{
						if (typeof(T) == typeof(GameObject))
						{
							values.Add(objects[j].MyGameObject as T);
							found = true;
							break;
						}

						if (typeof(T) == typeof(Transform))
						{
							values.Add(objects[j].MyGameObject.transform as T);
							found = true;
							break;
						}
					
						if (objects[j].MyGameObject.TryGetComponent(out T val))
						{
							values.Add(val);
							found = true;
							break;
						}
					}
				}

				// If nothing was found, just add null.
				if (!found)
				{
					values.Add(null);
				}
			}
			
			value = values.ToArray();
			return values.Count > 0;
		}
		
		public static bool TryGetObjects(uint[] ids, Type type, out Object[] value)
		{
			if (objects == null || objects.Count == 0)
			{
				value = null;
				return false;
			}

			List<Object> values = new List<Object>();

			for (int i = 0; i < ids.Length; i++)
			{
				for (int j = 0; j < objects.Count; j++)
				{
					if (objects[j].InstanceID == ids[i])
					{
						if (type == typeof(GameObject))
						{
							values.Add(objects[j].MyGameObject);
							break;
						}

						if (type == typeof(Transform))
						{
							values.Add(objects[j].MyGameObject.transform);
							break;
						}
					
						if (objects[j].MyGameObject.TryGetComponent(type, out Component val))
						{
							values.Add(val);
							break;
						}
					}
				}
			}

			value = values.ToArray();
			return values.Count > 0;
		}

		public static T[] GetObjects<T>() where T : Object
		{
			if (objects == null || objects.Count == 0)
			{
				return Array.Empty<T>();
			}
			
			return (T[])GetObjects(typeof(T));
		}
		
		public static Object[] GetObjects(Type type)
		{
			if (objects == null || objects.Count == 0)
			{
				return Array.Empty<Object>();
			}

			// If the type is GameObject we can just return all objects.
			if (type == typeof(GameObject))
			{
				Object[] goResult = new Object[objects.Count];
				for (int i = 0; i < objects.Count; i++)
				{
					goResult[i] = objects[i].MyGameObject;
				}

				return goResult;
			}

			// If the type is Transform we can just return all objects.
			if (type == typeof(Transform))
			{
				Object[] transformResult = new Object[objects.Count];
				for (int i = 0; i < objects.Count; i++)
				{
					transformResult[i] = objects[i].MyGameObject.transform;
				}

				return transformResult;
			}

			List<Object> result = new List<Object>();
			for (int i = 0; i < objects.Count; i++)
			{
				if (objects[i].MyGameObject.TryGetComponent(type, out Component value))
				{
					result.Add(value);
				}
			}

			return result.ToArray();
		}

		// Taken from https://github.com/Unity-Technologies/giles/blob/46779d9f27ba4dfbd0b5d50b887b64ee180db2c4/Assets/GILES/Code/Classes/pb_HandleUtility.cs#L176
		public static GameObject Raycast(Ray ray)
		{
			float best = Mathf.Infinity;
			GameObject result = null;
			Bounds bounds = new Bounds(Vector3.zero, Vector3.one);

			for (int i = 0; i < objects.Count; i++)
			{
				GameObject go = objects[i].MyGameObject;
				Ray localRay = TransformRay(ray, go.transform);

				Renderer renderer = go.GetComponent<Renderer>();

				float distance;
				if (renderer != null)
				{
					if (renderer.bounds.IntersectRay(ray, out distance))
					{
						MeshFilter mf = go.GetComponent<MeshFilter>();

						if (mf != null && mf.sharedMesh != null && MeshRaycast(mf.sharedMesh, localRay, out LevelEditorRaycastHit hit) && hit.distance < best)
						{
							best = hit.distance;
							result = go;
						}
					}
				}
				else
				{
					bounds.center = go.transform.position;

					if (bounds.IntersectRay(ray, out distance) && distance < best)
					{
						best = distance;
						result = go;
					}
				}
			}

			return result;
		}
		
		private static Ray TransformRay(Ray ray, Transform transform)
		{
			Matrix4x4 m = transform.worldToLocalMatrix;
			Ray local = new Ray(m.MultiplyPoint(ray.origin), m.MultiplyVector(ray.direction));

			return local;
		}

		private static bool MeshRaycast(Mesh mesh, Ray ray, out LevelEditorRaycastHit hit)
		{
			Vector3[] vertices = mesh.vertices;
			int[] triangles = mesh.triangles;

			for (int i = 0; i < triangles.Length; i += 3)
			{
				Vector3 a = vertices[triangles[i + 0]];
				Vector3 b = vertices[triangles[i + 1]];
				Vector3 c = vertices[triangles[i + 2]];

				if (RayIntersectsTriangle(ray, a, b, c, Culling.Front, out float _, out Vector3 point))
				{
					hit = new LevelEditorRaycastHit()
					{
						distance = Vector3.Distance(point, ray.origin),
						normal = Vector3.Cross(b - a, c - a),
						point = point,
						triangle = new int[] { triangles[i], triangles[i + 1], triangles[1 + 2] }
					};

					return true;
				}
			}

			hit = new LevelEditorRaycastHit();
			return false;
		}
		
		/**
		 * Returns true if a raycast intersects a triangle.
		 * http://en.wikipedia.org/wiki/M%C3%B6ller%E2%80%93Trumbore_intersection_algorithm
		 * http://www.cs.virginia.edu/~gfx/Courses/2003/ImageSynthesis/papers/Acceleration/Fast%20MinimumStorage%20RayTriangle%20Intersection.pdf
		 */
		private static bool RayIntersectsTriangle(Ray ray, Vector3 triangleA, Vector3 triangleB, Vector3 triangleC, Culling cull, out float distance, out Vector3 point)
		{
			distance = 0f;
			point = Vector3.zero;
			
			Vector3 e1, e2;  //Edge1, Edge2
			Vector3 P, Q, T;
			float det, inv_det, u, v;
			float t;

			//Find vectors for two edges sharing V1
			e1 = triangleB - triangleA;
			e2 = triangleC - triangleA;

			//Begin calculating determinant - also used to calculate `u` parameter
			P = Vector3.Cross(ray.direction, e2);
			
			//if determinant is near zero, ray lies in plane of triangle
			det = Vector3.Dot(e1, P);

			// NON-CULLING
			if( (cull == Culling.Front && det < Mathf.Epsilon) || (det > -Mathf.Epsilon && det < Mathf.Epsilon) )
				return false;

			inv_det = 1f / det;

			//calculate distance from V1 to ray origin
			T = ray.origin - triangleA;

			// Calculate u parameter and test bound
			u = Vector3.Dot(T, P) * inv_det;

			//The intersection lies outside of the triangle
			if(u < 0f || u > 1f)
				return false;

			//Prepare to test v parameter
			Q = Vector3.Cross(T, e1);

			//Calculate V parameter and test bound
			v = Vector3.Dot(ray.direction, Q) * inv_det;

			//The intersection lies outside of the triangle
			if(v < 0f || u + v  > 1f)
				return false;

			t = Vector3.Dot(e2, Q) * inv_det;

			if(t > Mathf.Epsilon)
			{ 
				//ray intersection
				distance = t;

				point.x = (u * triangleB.x + v * triangleC.x + (1-(u+v)) * triangleA.x);
				point.y = (u * triangleB.y + v * triangleC.y + (1-(u+v)) * triangleA.y);
				point.z = (u * triangleB.z + v * triangleC.z + (1-(u+v)) * triangleA.z);

				return true;
			}

			return false;
		}

		private struct LevelEditorRaycastHit
		{
			public Vector3 point;
			public float distance;
			public Vector3 normal;
			public int[] triangle;
		}
		
		public enum Culling
		{
			Back = 0x1,
			Front = 0x2,
			FrontBack = 0x4
		}
	}
}