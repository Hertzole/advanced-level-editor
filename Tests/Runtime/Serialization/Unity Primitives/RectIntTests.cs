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
		public IEnumerator SaveRectIntField()
		{
			yield return RunTest<RectIntField1, RectInt>(new RectInt(13, 3, 13, 5));
			yield return RunTest<RectIntField2, RectInt>(new RectInt(13, 0, 9, 19));
		}

		[UnityTest]
		public IEnumerator SaveRectIntFields()
		{
			yield return RunTest<RectIntFields1, RectInt>(new RectInt(13, 0, 9, 19), new RectInt(13, 3, 13, 5));
			yield return RunTest<RectIntFields2, RectInt>(new RectInt(13, 3, 13, 5), new RectInt(13, 0, 9, 19));
		}

		[UnityTest]
		public IEnumerator SaveRectIntProperty()
		{
			yield return RunTest<RectIntProperty1, RectInt>(new RectInt(13, 3, 13, 5));
			yield return RunTest<RectIntProperty2, RectInt>(new RectInt(13, 0, 9, 19));
		}

		[UnityTest]
		public IEnumerator SaveRectIntProperties()
		{
			yield return RunTest<RectIntProperties1, RectInt>(new RectInt(13, 0, 9, 19), new RectInt(13, 3, 13, 5));
			yield return RunTest<RectIntProperties2, RectInt>(new RectInt(13, 3, 13, 5), new RectInt(13, 0, 9, 19));
		}

		[UnityTest]
		public IEnumerator SaveRectIntNullableField()
		{
			yield return RunTest<RectIntNullableField1, RectInt?>(new RectInt(13, 3, 13, 5));
			yield return RunTest<RectIntNullableField2, RectInt?>(new RectInt(13, 0, 9, 19));
			yield return RunTest<RectIntNullableField1, RectInt?>(null);
			yield return RunTest<RectIntNullableField2, RectInt?>(null);
		}

		[UnityTest]
		public IEnumerator SaveRectIntNullableFields()
		{
			yield return RunTest<RectIntNullableFields1, RectInt?>(new RectInt(13, 0, 9, 19), new RectInt(13, 3, 13, 5));
			yield return RunTest<RectIntNullableFields2, RectInt?>(new RectInt(13, 3, 13, 5), new RectInt(13, 0, 9, 19));
			yield return RunTest<RectIntNullableFields1, RectInt?>(null, new RectInt(13, 3, 13, 5));
			yield return RunTest<RectIntNullableFields2, RectInt?>(new RectInt(13, 3, 13, 5), null);
		}

		[UnityTest]
		public IEnumerator SaveRectIntNullableProperty()
		{
			yield return RunTest<RectIntNullableProperty1, RectInt?>(new RectInt(13, 3, 13, 5));
			yield return RunTest<RectIntNullableProperty2, RectInt?>(new RectInt(13, 0, 9, 19));
			yield return RunTest<RectIntNullableProperty1, RectInt?>(null);
			yield return RunTest<RectIntNullableProperty2, RectInt?>(null);
		}

		[UnityTest]
		public IEnumerator SaveRectIntNullableProperties()
		{
			yield return RunTest<RectIntNullableProperties1, RectInt?>(new RectInt(13, 0, 9, 19), new RectInt(13, 3, 13, 5));
			yield return RunTest<RectIntNullableProperties2, RectInt?>(new RectInt(13, 3, 13, 5), new RectInt(13, 0, 9, 19));
			yield return RunTest<RectIntNullableProperties1, RectInt?>(null, new RectInt(13, 3, 13, 5));
			yield return RunTest<RectIntNullableProperties2, RectInt?>(new RectInt(13, 3, 13, 5), null);
		}

		[UnityTest]
		public IEnumerator SaveRectIntArrayField()
		{
			yield return RunTest<RectIntArrayField1, RectInt[]>(new RectInt[] { new RectInt(13, 3, 13, 5), new RectInt(13, 0, 9, 19) });
			yield return RunTest<RectIntArrayField2, RectInt[]>(new RectInt[] { new RectInt(13, 0, 9, 19), new RectInt(13, 3, 13, 5) });
		}

		[UnityTest]
		public IEnumerator SaveRectIntArrayFields()
		{
			yield return RunTest<RectIntArrayFields1, RectInt[]>(new RectInt[] { new RectInt(13, 3, 13, 5), new RectInt(13, 0, 9, 19) }, new RectInt[] { new RectInt(5, 15, 1, 5), new RectInt(19, 17, 6, 9) });
			yield return RunTest<RectIntArrayFields2, RectInt[]>(new RectInt[] { new RectInt(13, 0, 9, 19), new RectInt(13, 3, 13, 5) }, new RectInt[] { new RectInt(19, 17, 6, 9), new RectInt(5, 15, 1, 5) });
		}

		[UnityTest]
		public IEnumerator SaveRectIntArrayProperty()
		{
			yield return RunTest<RectIntArrayProperty1, RectInt[]>(new RectInt[] { new RectInt(13, 3, 13, 5), new RectInt(13, 0, 9, 19) });
			yield return RunTest<RectIntArrayProperty2, RectInt[]>(new RectInt[] { new RectInt(13, 0, 9, 19), new RectInt(13, 3, 13, 5) });
		}

		[UnityTest]
		public IEnumerator SaveRectIntArrayProperties()
		{
			yield return RunTest<RectIntArrayProperties1, RectInt[]>(new RectInt[] { new RectInt(13, 3, 13, 5), new RectInt(13, 0, 9, 19) }, new RectInt[] { new RectInt(5, 15, 1, 5), new RectInt(19, 17, 6, 9) });
			yield return RunTest<RectIntArrayProperties2, RectInt[]>(new RectInt[] { new RectInt(13, 0, 9, 19), new RectInt(13, 3, 13, 5) }, new RectInt[] { new RectInt(19, 17, 6, 9), new RectInt(5, 15, 1, 5) });
		}

		[UnityTest]
		public IEnumerator SaveRectIntArrayNullableField()
		{
			yield return RunTest<RectIntArrayNullableField1, RectInt?[]>(new RectInt?[] { null, new RectInt(13, 0, 9, 19) });
			yield return RunTest<RectIntArrayNullableField2, RectInt?[]>(new RectInt?[] { new RectInt(13, 0, 9, 19), null });
		}

		[UnityTest]
		public IEnumerator SaveRectIntArrayNullableFields()
		{
			yield return RunTest<RectIntArrayNullableFields1, RectInt?[]>(new RectInt?[] { null, new RectInt(13, 0, 9, 19) }, new RectInt?[] { new RectInt(5, 15, 1, 5), null });
			yield return RunTest<RectIntArrayNullableFields2, RectInt?[]>(new RectInt?[] { new RectInt(13, 0, 9, 19), null }, new RectInt?[] { null, new RectInt(5, 15, 1, 5) });
		}

		[UnityTest]
		public IEnumerator SaveRectIntArrayNullableProperty()
		{
			yield return RunTest<RectIntArrayNullableProperty1, RectInt?[]>(new RectInt?[] { null, new RectInt(13, 0, 9, 19) });
			yield return RunTest<RectIntArrayNullableProperty2, RectInt?[]>(new RectInt?[] { new RectInt(13, 0, 9, 19), null });
		}

		[UnityTest]
		public IEnumerator SaveRectIntArrayNullableProperties()
		{
			yield return RunTest<RectIntArrayNullableProperties1, RectInt?[]>(new RectInt?[] { new RectInt(13, 3, 13, 5), null }, new RectInt?[] { null, new RectInt(19, 17, 6, 9) });
			yield return RunTest<RectIntArrayNullableProperties2, RectInt?[]>(new RectInt?[] { null, new RectInt(13, 3, 13, 5) }, new RectInt?[] { new RectInt(19, 17, 6, 9), null });
		}

		[UnityTest]
		public IEnumerator SaveRectIntListField()
		{
			yield return RunTest<RectIntListField1, List<RectInt>>(new List<RectInt> { new RectInt(13, 3, 13, 5), new RectInt(13, 0, 9, 19) });
			yield return RunTest<RectIntListField2, List<RectInt>>(new List<RectInt> { new RectInt(13, 0, 9, 19), new RectInt(13, 3, 13, 5) });
		}

		[UnityTest]
		public IEnumerator SaveRectIntListFields()
		{
			yield return RunTest<RectIntListFields1, List<RectInt>>(new List<RectInt> { new RectInt(13, 3, 13, 5), new RectInt(13, 0, 9, 19) }, new List<RectInt> { new RectInt(5, 15, 1, 5), new RectInt(19, 17, 6, 9) });
			yield return RunTest<RectIntListFields2, List<RectInt>>(new List<RectInt> { new RectInt(13, 0, 9, 19), new RectInt(13, 3, 13, 5) }, new List<RectInt> { new RectInt(19, 17, 6, 9), new RectInt(5, 15, 1, 5) });
		}

		[UnityTest]
		public IEnumerator SaveRectIntListProperty()
		{
			yield return RunTest<RectIntListProperty1, List<RectInt>>(new List<RectInt> { new RectInt(13, 3, 13, 5), new RectInt(13, 0, 9, 19) });
			yield return RunTest<RectIntListProperty2, List<RectInt>>(new List<RectInt> { new RectInt(13, 0, 9, 19), new RectInt(13, 3, 13, 5) });
		}

		[UnityTest]
		public IEnumerator SaveRectIntListProperties()
		{
			yield return RunTest<RectIntListProperties1, List<RectInt>>(new List<RectInt> { new RectInt(13, 3, 13, 5), new RectInt(13, 0, 9, 19) }, new List<RectInt> { new RectInt(5, 15, 1, 5), new RectInt(19, 17, 6, 9) });
			yield return RunTest<RectIntListProperties2, List<RectInt>>(new List<RectInt> { new RectInt(13, 0, 9, 19), new RectInt(13, 3, 13, 5) }, new List<RectInt> { new RectInt(19, 17, 6, 9), new RectInt(5, 15, 1, 5) });
		}

		[UnityTest]
		public IEnumerator SaveRectIntListNullableField()
		{
			yield return RunTest<RectIntListNullableField1, List<RectInt?>>(new List<RectInt?> { null, new RectInt(13, 0, 9, 19) });
			yield return RunTest<RectIntListNullableField2, List<RectInt?>>(new List<RectInt?> { new RectInt(13, 0, 9, 19), null });
		}

		[UnityTest]
		public IEnumerator SaveRectIntListNullableFields()
		{
			yield return RunTest<RectIntListNullableFields1, List<RectInt?>>(new List<RectInt?> { null, new RectInt(13, 0, 9, 19) }, new List<RectInt?> { new RectInt(5, 15, 1, 5), null });
			yield return RunTest<RectIntListNullableFields2, List<RectInt?>>(new List<RectInt?> { new RectInt(13, 0, 9, 19), null }, new List<RectInt?> { null, new RectInt(5, 15, 1, 5) });
		}

		[UnityTest]
		public IEnumerator SaveRectIntListNullableProperty()
		{
			yield return RunTest<RectIntListNullableProperty1, List<RectInt?>>(new List<RectInt?> { null, new RectInt(13, 0, 9, 19) });
			yield return RunTest<RectIntListNullableProperty2, List<RectInt?>>(new List<RectInt?> { new RectInt(13, 0, 9, 19), null });
		}

		[UnityTest]
		public IEnumerator SaveRectIntListNullableProperties()
		{
			yield return RunTest<RectIntListNullableProperties1, List<RectInt?>>(new List<RectInt?> { new RectInt(13, 3, 13, 5), null }, new List<RectInt?> { null, new RectInt(19, 17, 6, 9) });
			yield return RunTest<RectIntListNullableProperties2, List<RectInt?>>(new List<RectInt?> { null, new RectInt(13, 3, 13, 5) }, new List<RectInt?> { new RectInt(19, 17, 6, 9), null });
		}
	}
}