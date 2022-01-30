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
		public IEnumerator SaveTransformField()
		{
			yield return RunReferenceTest<TransformField1, Transform>(false);
			yield return RunReferenceTest<TransformField2, Transform>(false);
		}

		[UnityTest]
		public IEnumerator SaveTransformFields()
		{
			yield return RunReferenceTest<TransformFields1, Transform>(false, false);
			yield return RunReferenceTest<TransformFields2, Transform>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveTransformProperty()
		{
			yield return RunReferenceTest<TransformProperty1, Transform>(false);
			yield return RunReferenceTest<TransformProperty2, Transform>(false);
		}

		[UnityTest]
		public IEnumerator SaveTransformProperties()
		{
			yield return RunReferenceTest<TransformProperties1, Transform>(false, false);
			yield return RunReferenceTest<TransformProperties2, Transform>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveTransformNullableField()
		{
			yield return RunReferenceTest<TransformNullableField1, Transform?>(false);
			yield return RunReferenceTest<TransformNullableField2, Transform?>(false);
			yield return RunReferenceTest<TransformNullableField1, Transform?>(true);
			yield return RunReferenceTest<TransformNullableField2, Transform?>(true);
		}

		[UnityTest]
		public IEnumerator SaveTransformNullableFields()
		{
			yield return RunReferenceTest<TransformNullableFields1, Transform?>(false, false);
			yield return RunReferenceTest<TransformNullableFields2, Transform?>(false, false);
			yield return RunReferenceTest<TransformNullableFields1, Transform?>(true, false);
			yield return RunReferenceTest<TransformNullableFields2, Transform?>(false, true);
		}

		[UnityTest]
		public IEnumerator SaveTransformNullableProperty()
		{
			yield return RunReferenceTest<TransformNullableProperty1, Transform?>(false);
			yield return RunReferenceTest<TransformNullableProperty2, Transform?>(false);
			yield return RunReferenceTest<TransformNullableProperty1, Transform?>(true);
			yield return RunReferenceTest<TransformNullableProperty2, Transform?>(true);
		}

		[UnityTest]
		public IEnumerator SaveTransformNullableProperties()
		{
			yield return RunReferenceTest<TransformNullableProperties1, Transform?>(false, false);
			yield return RunReferenceTest<TransformNullableProperties2, Transform?>(false, false);
			yield return RunReferenceTest<TransformNullableProperties1, Transform?>(true, false);
			yield return RunReferenceTest<TransformNullableProperties2, Transform?>(false, true);
		}

		[UnityTest]
		public IEnumerator SaveTransformArrayField()
		{
			yield return RunReferenceCollectionTest<TransformArrayField1, Transform[]>(false, false);
			yield return RunReferenceCollectionTest<TransformArrayField2, Transform[]>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveTransformArrayFields()
		{
			yield return RunReferenceCollectionTest<TransformArrayFields1, Transform[]>(false, false, false, false);
			yield return RunReferenceCollectionTest<TransformArrayFields2, Transform[]>(false, false, false, false);
		}

		[UnityTest]
		public IEnumerator SaveTransformArrayProperty()
		{
			yield return RunReferenceCollectionTest<TransformArrayProperty1, Transform[]>(false, false);
			yield return RunReferenceCollectionTest<TransformArrayProperty2, Transform[]>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveTransformArrayProperties()
		{
			yield return RunReferenceCollectionTest<TransformArrayProperties1, Transform[]>(false, false, false, false);
			yield return RunReferenceCollectionTest<TransformArrayProperties2, Transform[]>(false, false, false, false);
		}

		[UnityTest]
		public IEnumerator SaveTransformArrayNullableField()
		{
			yield return RunReferenceCollectionTest<TransformArrayNullableField1, Transform?[]>(true, false);
			yield return RunReferenceCollectionTest<TransformArrayNullableField2, Transform?[]>(false, true);
		}

		[UnityTest]
		public IEnumerator SaveTransformArrayNullableFields()
		{
			yield return RunReferenceCollectionTest<TransformArrayNullableFields1, Transform?[]>(true, false, false, true);
			yield return RunReferenceCollectionTest<TransformArrayNullableFields2, Transform?[]>(false, true, true, false);
		}

		[UnityTest]
		public IEnumerator SaveTransformArrayNullableProperty()
		{
			yield return RunReferenceCollectionTest<TransformArrayNullableProperty1, Transform?[]>(true, false);
			yield return RunReferenceCollectionTest<TransformArrayNullableProperty2, Transform?[]>(false, true);
		}

		[UnityTest]
		public IEnumerator SaveTransformArrayNullableProperties()
		{
			yield return RunReferenceCollectionTest<TransformArrayNullableProperties1, Transform?[]>(false, true, true, false);
			yield return RunReferenceCollectionTest<TransformArrayNullableProperties2, Transform?[]>(true, false, false, true);
		}

		[UnityTest]
		public IEnumerator SaveTransformListField()
		{
			yield return RunReferenceCollectionTest<TransformListField1, List<Transform>>(false, false);
			yield return RunReferenceCollectionTest<TransformListField2, List<Transform>>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveTransformListFields()
		{
			yield return RunReferenceCollectionTest<TransformListFields1, List<Transform>>(false, false, false, false);
			yield return RunReferenceCollectionTest<TransformListFields2, List<Transform>>(false, false, false, false);
		}

		[UnityTest]
		public IEnumerator SaveTransformListProperty()
		{
			yield return RunReferenceCollectionTest<TransformListProperty1, List<Transform>>(false, false);
			yield return RunReferenceCollectionTest<TransformListProperty2, List<Transform>>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveTransformListProperties()
		{
			yield return RunReferenceCollectionTest<TransformListProperties1, List<Transform>>(false, false, false, false);
			yield return RunReferenceCollectionTest<TransformListProperties2, List<Transform>>(false, false, false, false);
		}

		[UnityTest]
		public IEnumerator SaveTransformListNullableField()
		{
			yield return RunReferenceCollectionTest<TransformListNullableField1, List<Transform?>>(true, false);
			yield return RunReferenceCollectionTest<TransformListNullableField2, List<Transform?>>(false, true);
		}

		[UnityTest]
		public IEnumerator SaveTransformListNullableFields()
		{
			yield return RunReferenceCollectionTest<TransformListNullableFields1, List<Transform?>>(true, false, false, true);
			yield return RunReferenceCollectionTest<TransformListNullableFields2, List<Transform?>>(false, true, true, false);
		}

		[UnityTest]
		public IEnumerator SaveTransformListNullableProperty()
		{
			yield return RunReferenceCollectionTest<TransformListNullableProperty1, List<Transform?>>(true, false);
			yield return RunReferenceCollectionTest<TransformListNullableProperty2, List<Transform?>>(false, true);
		}

		[UnityTest]
		public IEnumerator SaveTransformListNullableProperties()
		{
			yield return RunReferenceCollectionTest<TransformListNullableProperties1, List<Transform?>>(false, true, true, false);
			yield return RunReferenceCollectionTest<TransformListNullableProperties2, List<Transform?>>(true, false, false, true);
		}
	}
}