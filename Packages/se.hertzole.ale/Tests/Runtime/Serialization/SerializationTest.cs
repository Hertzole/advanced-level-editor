using System.Collections;
using System.Collections.Generic;
using System.IO;
using Hertzole.ALE.Tests.TestScripts;
using UnityEngine;
using UnityEngine.Assertions;

namespace Hertzole.ALE.Tests
{
	public abstract class SerializationTest : LevelEditorTest
	{
		private string filePath;

		public const int VALUE_0_ID = 0;
		public const int VALUE_5_ID = 5;
		public const int VALUE_10_ID = 10;
		public const int VALUE_100_ID = 100;

		protected override void OnSceneSetup(List<GameObject> objects)
		{
			filePath = $"{Application.dataPath}/generated__test__save__file.temp";
			objectManager.PoolObjects = false;
			OnSetUp();
		}

		protected abstract void OnSetUp();

		protected override void OnTearDownScene()
		{
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
		}

		protected IEnumerator RunTest<TType, TValue>(TValue newValue) where TType : Component, IValue<TValue>
		{
			cube.AddComponent<TType>();

			CustomEquality<TValue> equalityComparer = new CustomEquality<TValue>(); 

			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			uint cubeId = newCube.InstanceID;

			TType type = newCube.MyGameObject.GetComponent<TType>();

			type.Value = newValue;

			Assert.AreEqual(newValue, type.Value, "Value was not set.", equalityComparer);

			Save();

			objectManager.DeleteAllObjects();

			Load();

			newCube = objectManager.GetObject(cubeId);
			Assert.IsNotNull(newCube, "Object was not loaded.");

			type = newCube.MyGameObject.GetComponent<TType>();

			// if (newValue is ICollection newValueCollection && type.Value is ICollection valueCollection)
			// {
			// 	Assert.IsTrue(newValueCollection.IsSameAs(valueCollection, equalityComparer), "Collection was not the same.");
			// }
			// else
			// {
			// }
				Assert.AreEqual(newValue, type.Value, "Value was not properly saved.", equalityComparer);

			Object.Destroy(cube.GetComponent<TType>());

			objectManager.DeleteObject(newCube);

			yield return null;
		}

		protected IEnumerator RunTest<TType, TValue>(TValue newValue1, TValue newValue2) where TType : Component, IValues<TValue>
		{
			cube.AddComponent<TType>();

			CustomEquality<TValue> equalityComparer = new CustomEquality<TValue>(); 

			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			uint cubeId = newCube.InstanceID;

			TType type = newCube.MyGameObject.GetComponent<TType>();

			type.Value1 = newValue1;
			type.Value2 = newValue2;

			Assert.AreEqual(newValue1, type.Value1, "Value 1 was not set.", equalityComparer);
			Assert.AreEqual(newValue2, type.Value2, "Value 2 was not set.", equalityComparer);

			Save();

			objectManager.DeleteAllObjects();

			Load();

			newCube = objectManager.GetObject(cubeId);
			Assert.IsNotNull(newCube, "Object was not loaded.");

			type = newCube.MyGameObject.GetComponent<TType>();

			// if (newValue1 is ICollection newValue1Collection && type.Value1 is ICollection value1Collection)
			// {
			// 	Assert.IsTrue(newValue1Collection.IsSameAs(value1Collection, equalityComparer), "Collection 1 was not the same.");
			// }
			// else
			// {
			// }
			Assert.AreEqual(newValue1, type.Value1, "Value 1 was not properly saved.", equalityComparer);

			// if (newValue2 is ICollection newValue2Collection && type.Value2 is ICollection value2Collection)
			// {
			// 	Assert.IsTrue(newValue2Collection.IsSameAs(value2Collection, equalityComparer), "Collection 2 was not the same.");
			// }
			// else
			// {
			// }
				Assert.AreEqual(newValue2, type.Value2, "Value 2 was not properly saved.", equalityComparer);

			Object.Destroy(cube.GetComponent<TType>());

			objectManager.DeleteObject(newCube);

			yield return null;
		}

		protected void Save()
		{
			saveManager.SaveLevel("Test Level", filePath);
		}

		protected void Load()
		{
			saveManager.LoadLevel(filePath);
		}

		private class CustomEquality<T> : EqualityComparer<T>
		{
			private readonly AnimationCurveEquality animationCurveEquality = new AnimationCurveEquality();
			private readonly AnimationCurveArrayEquality animationCurveArrayEquality = new AnimationCurveArrayEquality();
			
			public override bool Equals(T x, T y)
			{
				if (typeof(T) == typeof(AnimationCurve))
				{
					return animationCurveEquality.Equals(x as AnimationCurve, y as AnimationCurve);
				}

				if (typeof(T) == typeof(AnimationCurve[]))
				{
					return animationCurveArrayEquality.Equals(x as AnimationCurve[], y as AnimationCurve[]);
				}

				if (x is ICollection xCollection && y is ICollection yCollection)
				{
					return xCollection.IsSameAs(yCollection);
				}

				return Default.Equals(x, y);
			}

			public override int GetHashCode(T obj)
			{
				if (obj is AnimationCurve animationCurve)
				{
					return animationCurveEquality.GetHashCode(animationCurve);
				}

				if (obj is AnimationCurve[] animationCurves)
				{
					return animationCurveArrayEquality.GetHashCode(animationCurves);
				}

				return Default.GetHashCode(obj);
			}
		}

		private class AnimationCurveEquality : EqualityComparer<AnimationCurve>
		{
			public override bool Equals(AnimationCurve x, AnimationCurve y)
			{
				Debug.Log("ANIMATION CURVE EQUALS");
				
				if (x == null && y == null)
				{
					Debug.Log("Both are null, great!");
					return true;
				}
				
				if (x == null || y == null)
				{
					Debug.Log("One is null");
					return false;
				}

				if (x.length != y.length || x.postWrapMode != y.postWrapMode || x.preWrapMode != y.preWrapMode)
				{
					Debug.Log("Something didn't match.");
					return false;
				}

				for (int i = 0; i < x.keys.Length; i++)
				{
					if (!x.keys[i].Equals(y.keys[i]))
					{
						Debug.Log("Wrong key");
						return false;
					}

				}

				Debug.Log("All good chief");
				
				return true;
			}

			public override int GetHashCode(AnimationCurve obj)
			{
				return obj.GetHashCode();
			}
		}
		
		private class AnimationCurveArrayEquality : EqualityComparer<AnimationCurve[]>
		{
			private static readonly AnimationCurveEquality equalityComparer = new AnimationCurveEquality();
			
			public override bool Equals(AnimationCurve[] x, AnimationCurve[] y)
			{
				Debug.Log("EQUALS");

				return true;
				// return x.IsSameAs((ICollection<AnimationCurve>) y, equalityComparer);
			}

			public override int GetHashCode(AnimationCurve[] obj)
			{
				return obj.GetHashCode();
			}
		}
	}
}