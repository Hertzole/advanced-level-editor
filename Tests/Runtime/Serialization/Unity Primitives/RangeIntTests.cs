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
		public IEnumerator SaveRangeIntField()
		{
			yield return RunTest<RangeIntField1, RangeInt>(new RangeInt(344, 1304));
			yield return RunTest<RangeIntField2, RangeInt>(new RangeInt(555, 1776));
		}

		[UnityTest]
		public IEnumerator SaveRangeIntFields()
		{
			yield return RunTest<RangeIntFields1, RangeInt>(new RangeInt(555, 1776), new RangeInt(344, 1304));
			yield return RunTest<RangeIntFields2, RangeInt>(new RangeInt(344, 1304), new RangeInt(555, 1776));
		}

		[UnityTest]
		public IEnumerator SaveRangeIntProperty()
		{
			yield return RunTest<RangeIntProperty1, RangeInt>(new RangeInt(344, 1304));
			yield return RunTest<RangeIntProperty2, RangeInt>(new RangeInt(555, 1776));
		}

		[UnityTest]
		public IEnumerator SaveRangeIntProperties()
		{
			yield return RunTest<RangeIntProperties1, RangeInt>(new RangeInt(555, 1776), new RangeInt(344, 1304));
			yield return RunTest<RangeIntProperties2, RangeInt>(new RangeInt(344, 1304), new RangeInt(555, 1776));
		}

		[UnityTest]
		public IEnumerator SaveRangeIntNullableField()
		{
			yield return RunTest<RangeIntNullableField1, RangeInt?>(new RangeInt(344, 1304));
			yield return RunTest<RangeIntNullableField2, RangeInt?>(new RangeInt(555, 1776));
			yield return RunTest<RangeIntNullableField1, RangeInt?>(null);
			yield return RunTest<RangeIntNullableField2, RangeInt?>(null);
		}

		[UnityTest]
		public IEnumerator SaveRangeIntNullableFields()
		{
			yield return RunTest<RangeIntNullableFields1, RangeInt?>(new RangeInt(555, 1776), new RangeInt(344, 1304));
			yield return RunTest<RangeIntNullableFields2, RangeInt?>(new RangeInt(344, 1304), new RangeInt(555, 1776));
			yield return RunTest<RangeIntNullableFields1, RangeInt?>(null, new RangeInt(344, 1304));
			yield return RunTest<RangeIntNullableFields2, RangeInt?>(new RangeInt(344, 1304), null);
		}

		[UnityTest]
		public IEnumerator SaveRangeIntNullableProperty()
		{
			yield return RunTest<RangeIntNullableProperty1, RangeInt?>(new RangeInt(344, 1304));
			yield return RunTest<RangeIntNullableProperty2, RangeInt?>(new RangeInt(555, 1776));
			yield return RunTest<RangeIntNullableProperty1, RangeInt?>(null);
			yield return RunTest<RangeIntNullableProperty2, RangeInt?>(null);
		}

		[UnityTest]
		public IEnumerator SaveRangeIntNullableProperties()
		{
			yield return RunTest<RangeIntNullableProperties1, RangeInt?>(new RangeInt(555, 1776), new RangeInt(344, 1304));
			yield return RunTest<RangeIntNullableProperties2, RangeInt?>(new RangeInt(344, 1304), new RangeInt(555, 1776));
			yield return RunTest<RangeIntNullableProperties1, RangeInt?>(null, new RangeInt(344, 1304));
			yield return RunTest<RangeIntNullableProperties2, RangeInt?>(new RangeInt(344, 1304), null);
		}

		[UnityTest]
		public IEnumerator SaveRangeIntArrayField()
		{
			yield return RunTest<RangeIntArrayField1, RangeInt[]>(new RangeInt[] { new RangeInt(344, 1304), new RangeInt(555, 1776) });
			yield return RunTest<RangeIntArrayField2, RangeInt[]>(new RangeInt[] { new RangeInt(555, 1776), new RangeInt(344, 1304) });
		}

		[UnityTest]
		public IEnumerator SaveRangeIntArrayFields()
		{
			yield return RunTest<RangeIntArrayFields1, RangeInt[]>(new RangeInt[] { new RangeInt(344, 1304), new RangeInt(555, 1776) }, new RangeInt[] { new RangeInt(183, 1062), new RangeInt(756, 1063) });
			yield return RunTest<RangeIntArrayFields2, RangeInt[]>(new RangeInt[] { new RangeInt(555, 1776), new RangeInt(344, 1304) }, new RangeInt[] { new RangeInt(756, 1063), new RangeInt(183, 1062) });
		}

		[UnityTest]
		public IEnumerator SaveRangeIntArrayProperty()
		{
			yield return RunTest<RangeIntArrayProperty1, RangeInt[]>(new RangeInt[] { new RangeInt(344, 1304), new RangeInt(555, 1776) });
			yield return RunTest<RangeIntArrayProperty2, RangeInt[]>(new RangeInt[] { new RangeInt(555, 1776), new RangeInt(344, 1304) });
		}

		[UnityTest]
		public IEnumerator SaveRangeIntArrayProperties()
		{
			yield return RunTest<RangeIntArrayProperties1, RangeInt[]>(new RangeInt[] { new RangeInt(344, 1304), new RangeInt(555, 1776) }, new RangeInt[] { new RangeInt(183, 1062), new RangeInt(756, 1063) });
			yield return RunTest<RangeIntArrayProperties2, RangeInt[]>(new RangeInt[] { new RangeInt(555, 1776), new RangeInt(344, 1304) }, new RangeInt[] { new RangeInt(756, 1063), new RangeInt(183, 1062) });
		}

		[UnityTest]
		public IEnumerator SaveRangeIntArrayNullableField()
		{
			yield return RunTest<RangeIntArrayNullableField1, RangeInt?[]>(new RangeInt?[] { null, new RangeInt(555, 1776) });
			yield return RunTest<RangeIntArrayNullableField2, RangeInt?[]>(new RangeInt?[] { new RangeInt(555, 1776), null });
		}

		[UnityTest]
		public IEnumerator SaveRangeIntArrayNullableFields()
		{
			yield return RunTest<RangeIntArrayNullableFields1, RangeInt?[]>(new RangeInt?[] { null, new RangeInt(555, 1776) }, new RangeInt?[] { new RangeInt(183, 1062), null });
			yield return RunTest<RangeIntArrayNullableFields2, RangeInt?[]>(new RangeInt?[] { new RangeInt(555, 1776), null }, new RangeInt?[] { null, new RangeInt(183, 1062) });
		}

		[UnityTest]
		public IEnumerator SaveRangeIntArrayNullableProperty()
		{
			yield return RunTest<RangeIntArrayNullableProperty1, RangeInt?[]>(new RangeInt?[] { null, new RangeInt(555, 1776) });
			yield return RunTest<RangeIntArrayNullableProperty2, RangeInt?[]>(new RangeInt?[] { new RangeInt(555, 1776), null });
		}

		[UnityTest]
		public IEnumerator SaveRangeIntArrayNullableProperties()
		{
			yield return RunTest<RangeIntArrayNullableProperties1, RangeInt?[]>(new RangeInt?[] { new RangeInt(344, 1304), null }, new RangeInt?[] { null, new RangeInt(756, 1063) });
			yield return RunTest<RangeIntArrayNullableProperties2, RangeInt?[]>(new RangeInt?[] { null, new RangeInt(344, 1304) }, new RangeInt?[] { new RangeInt(756, 1063), null });
		}

		[UnityTest]
		public IEnumerator SaveRangeIntListField()
		{
			yield return RunTest<RangeIntListField1, List<RangeInt>>(new List<RangeInt> { new RangeInt(344, 1304), new RangeInt(555, 1776) });
			yield return RunTest<RangeIntListField2, List<RangeInt>>(new List<RangeInt> { new RangeInt(555, 1776), new RangeInt(344, 1304) });
		}

		[UnityTest]
		public IEnumerator SaveRangeIntListFields()
		{
			yield return RunTest<RangeIntListFields1, List<RangeInt>>(new List<RangeInt> { new RangeInt(344, 1304), new RangeInt(555, 1776) }, new List<RangeInt> { new RangeInt(183, 1062), new RangeInt(756, 1063) });
			yield return RunTest<RangeIntListFields2, List<RangeInt>>(new List<RangeInt> { new RangeInt(555, 1776), new RangeInt(344, 1304) }, new List<RangeInt> { new RangeInt(756, 1063), new RangeInt(183, 1062) });
		}

		[UnityTest]
		public IEnumerator SaveRangeIntListProperty()
		{
			yield return RunTest<RangeIntListProperty1, List<RangeInt>>(new List<RangeInt> { new RangeInt(344, 1304), new RangeInt(555, 1776) });
			yield return RunTest<RangeIntListProperty2, List<RangeInt>>(new List<RangeInt> { new RangeInt(555, 1776), new RangeInt(344, 1304) });
		}

		[UnityTest]
		public IEnumerator SaveRangeIntListProperties()
		{
			yield return RunTest<RangeIntListProperties1, List<RangeInt>>(new List<RangeInt> { new RangeInt(344, 1304), new RangeInt(555, 1776) }, new List<RangeInt> { new RangeInt(183, 1062), new RangeInt(756, 1063) });
			yield return RunTest<RangeIntListProperties2, List<RangeInt>>(new List<RangeInt> { new RangeInt(555, 1776), new RangeInt(344, 1304) }, new List<RangeInt> { new RangeInt(756, 1063), new RangeInt(183, 1062) });
		}

		[UnityTest]
		public IEnumerator SaveRangeIntListNullableField()
		{
			yield return RunTest<RangeIntListNullableField1, List<RangeInt?>>(new List<RangeInt?> { null, new RangeInt(555, 1776) });
			yield return RunTest<RangeIntListNullableField2, List<RangeInt?>>(new List<RangeInt?> { new RangeInt(555, 1776), null });
		}

		[UnityTest]
		public IEnumerator SaveRangeIntListNullableFields()
		{
			yield return RunTest<RangeIntListNullableFields1, List<RangeInt?>>(new List<RangeInt?> { null, new RangeInt(555, 1776) }, new List<RangeInt?> { new RangeInt(183, 1062), null });
			yield return RunTest<RangeIntListNullableFields2, List<RangeInt?>>(new List<RangeInt?> { new RangeInt(555, 1776), null }, new List<RangeInt?> { null, new RangeInt(183, 1062) });
		}

		[UnityTest]
		public IEnumerator SaveRangeIntListNullableProperty()
		{
			yield return RunTest<RangeIntListNullableProperty1, List<RangeInt?>>(new List<RangeInt?> { null, new RangeInt(555, 1776) });
			yield return RunTest<RangeIntListNullableProperty2, List<RangeInt?>>(new List<RangeInt?> { new RangeInt(555, 1776), null });
		}

		[UnityTest]
		public IEnumerator SaveRangeIntListNullableProperties()
		{
			yield return RunTest<RangeIntListNullableProperties1, List<RangeInt?>>(new List<RangeInt?> { new RangeInt(344, 1304), null }, new List<RangeInt?> { null, new RangeInt(756, 1063) });
			yield return RunTest<RangeIntListNullableProperties2, List<RangeInt?>>(new List<RangeInt?> { null, new RangeInt(344, 1304) }, new List<RangeInt?> { new RangeInt(756, 1063), null });
		}
	}
}