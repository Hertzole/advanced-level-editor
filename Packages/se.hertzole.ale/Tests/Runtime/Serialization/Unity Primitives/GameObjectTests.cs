// DO NOT MODIFY! THIS IS A GENERATED FILE!

#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using Hertzole.ALE.Tests.TestScripts;
using UnityEngine;
using UnityEngine.TestTools;

namespace Hertzole.ALE.Tests
{
	public abstract partial class UnityPrimitives : SerializationTest
	{
		[UnityTest]
		public IEnumerator SaveGameObjectField()
		{
			yield return RunReferenceTest<GameObjectField1, GameObject>(false);
			yield return RunReferenceTest<GameObjectField2, GameObject>(false);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectFields()
		{
			yield return RunReferenceTest<GameObjectFields1, GameObject>(false, false);
			yield return RunReferenceTest<GameObjectFields2, GameObject>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectProperty()
		{
			yield return RunReferenceTest<GameObjectProperty1, GameObject>(false);
			yield return RunReferenceTest<GameObjectProperty2, GameObject>(false);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectProperties()
		{
			yield return RunReferenceTest<GameObjectProperties1, GameObject>(false, false);
			yield return RunReferenceTest<GameObjectProperties2, GameObject>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectNullableField()
		{
			yield return RunReferenceTest<GameObjectNullableField1, GameObject?>(false);
			yield return RunReferenceTest<GameObjectNullableField2, GameObject?>(false);
			yield return RunReferenceTest<GameObjectNullableField1, GameObject?>(true);
			yield return RunReferenceTest<GameObjectNullableField2, GameObject?>(true);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectNullableFields()
		{
			yield return RunReferenceTest<GameObjectNullableFields1, GameObject?>(false, false);
			yield return RunReferenceTest<GameObjectNullableFields2, GameObject?>(false, false);
			yield return RunReferenceTest<GameObjectNullableFields1, GameObject?>(true, false);
			yield return RunReferenceTest<GameObjectNullableFields2, GameObject?>(false, true);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectNullableProperty()
		{
			yield return RunReferenceTest<GameObjectNullableProperty1, GameObject?>(false);
			yield return RunReferenceTest<GameObjectNullableProperty2, GameObject?>(false);
			yield return RunReferenceTest<GameObjectNullableProperty1, GameObject?>(true);
			yield return RunReferenceTest<GameObjectNullableProperty2, GameObject?>(true);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectNullableProperties()
		{
			yield return RunReferenceTest<GameObjectNullableProperties1, GameObject?>(false, false);
			yield return RunReferenceTest<GameObjectNullableProperties2, GameObject?>(false, false);
			yield return RunReferenceTest<GameObjectNullableProperties1, GameObject?>(true, false);
			yield return RunReferenceTest<GameObjectNullableProperties2, GameObject?>(false, true);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectArrayField()
		{
			yield return RunReferenceCollectionTest<GameObjectArrayField1, GameObject[]>(false, false);
			yield return RunReferenceCollectionTest<GameObjectArrayField2, GameObject[]>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectArrayFields()
		{
			yield return RunReferenceCollectionTest<GameObjectArrayFields1, GameObject[]>(false, false, false, false);
			yield return RunReferenceCollectionTest<GameObjectArrayFields2, GameObject[]>(false, false, false, false);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectArrayProperty()
		{
			yield return RunReferenceCollectionTest<GameObjectArrayProperty1, GameObject[]>(false, false);
			yield return RunReferenceCollectionTest<GameObjectArrayProperty2, GameObject[]>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectArrayProperties()
		{
			yield return RunReferenceCollectionTest<GameObjectArrayProperties1, GameObject[]>(false, false, false, false);
			yield return RunReferenceCollectionTest<GameObjectArrayProperties2, GameObject[]>(false, false, false, false);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectArrayNullableField()
		{
			yield return RunReferenceCollectionTest<GameObjectArrayNullableField1, GameObject?[]>(true, false);
			yield return RunReferenceCollectionTest<GameObjectArrayNullableField2, GameObject?[]>(false, true);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectArrayNullableFields()
		{
			yield return RunReferenceCollectionTest<GameObjectArrayNullableFields1, GameObject?[]>(true, false, false, true);
			yield return RunReferenceCollectionTest<GameObjectArrayNullableFields2, GameObject?[]>(false, true, true, false);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectArrayNullableProperty()
		{
			yield return RunReferenceCollectionTest<GameObjectArrayNullableProperty1, GameObject?[]>(true, false);
			yield return RunReferenceCollectionTest<GameObjectArrayNullableProperty2, GameObject?[]>(false, true);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectArrayNullableProperties()
		{
			yield return RunReferenceCollectionTest<GameObjectArrayNullableProperties1, GameObject?[]>(false, true, true, false);
			yield return RunReferenceCollectionTest<GameObjectArrayNullableProperties2, GameObject?[]>(true, false, false, true);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectListField()
		{
			yield return RunReferenceCollectionTest<GameObjectListField1, List<GameObject>>(false, false);
			yield return RunReferenceCollectionTest<GameObjectListField2, List<GameObject>>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectListFields()
		{
			yield return RunReferenceCollectionTest<GameObjectListFields1, List<GameObject>>(false, false, false, false);
			yield return RunReferenceCollectionTest<GameObjectListFields2, List<GameObject>>(false, false, false, false);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectListProperty()
		{
			yield return RunReferenceCollectionTest<GameObjectListProperty1, List<GameObject>>(false, false);
			yield return RunReferenceCollectionTest<GameObjectListProperty2, List<GameObject>>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectListProperties()
		{
			yield return RunReferenceCollectionTest<GameObjectListProperties1, List<GameObject>>(false, false, false, false);
			yield return RunReferenceCollectionTest<GameObjectListProperties2, List<GameObject>>(false, false, false, false);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectListNullableField()
		{
			yield return RunReferenceCollectionTest<GameObjectListNullableField1, List<GameObject?>>(true, false);
			yield return RunReferenceCollectionTest<GameObjectListNullableField2, List<GameObject?>>(false, true);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectListNullableFields()
		{
			yield return RunReferenceCollectionTest<GameObjectListNullableFields1, List<GameObject?>>(true, false, false, true);
			yield return RunReferenceCollectionTest<GameObjectListNullableFields2, List<GameObject?>>(false, true, true, false);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectListNullableProperty()
		{
			yield return RunReferenceCollectionTest<GameObjectListNullableProperty1, List<GameObject?>>(true, false);
			yield return RunReferenceCollectionTest<GameObjectListNullableProperty2, List<GameObject?>>(false, true);
		}

		[UnityTest]
		public IEnumerator SaveGameObjectListNullableProperties()
		{
			yield return RunReferenceCollectionTest<GameObjectListNullableProperties1, List<GameObject?>>(false, true, true, false);
			yield return RunReferenceCollectionTest<GameObjectListNullableProperties2, List<GameObject?>>(true, false, false, true);
		}
	}
}