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
	public abstract partial class PrimitivesTest : SerializationTest
	{
		[UnityTest]
		public IEnumerator SaveLongField()
		{
			yield return RunTest<LongField1, long>(2162499953876419464);
			yield return RunTest<LongField2, long>(-8954702388043848012);
		}

		[UnityTest]
		public IEnumerator SaveLongFields()
		{
			yield return RunTest<LongFields1, long>(-8954702388043848012, 2162499953876419464);
			yield return RunTest<LongFields2, long>(2162499953876419464, -8954702388043848012);
		}

		[UnityTest]
		public IEnumerator SaveLongProperty()
		{
			yield return RunTest<LongProperty1, long>(2162499953876419464);
			yield return RunTest<LongProperty2, long>(-8954702388043848012);
		}

		[UnityTest]
		public IEnumerator SaveLongProperties()
		{
			yield return RunTest<LongProperties1, long>(-8954702388043848012, 2162499953876419464);
			yield return RunTest<LongProperties2, long>(2162499953876419464, -8954702388043848012);
		}

		[UnityTest]
		public IEnumerator SaveLongNullableField()
		{
			yield return RunTest<LongNullableField1, long?>(2162499953876419464);
			yield return RunTest<LongNullableField2, long?>(-8954702388043848012);
			yield return RunTest<LongNullableField1, long?>(null);
			yield return RunTest<LongNullableField2, long?>(null);
		}

		[UnityTest]
		public IEnumerator SaveLongNullableFields()
		{
			yield return RunTest<LongNullableFields1, long?>(-8954702388043848012, 2162499953876419464);
			yield return RunTest<LongNullableFields2, long?>(2162499953876419464, -8954702388043848012);
			yield return RunTest<LongNullableFields1, long?>(null, 2162499953876419464);
			yield return RunTest<LongNullableFields2, long?>(2162499953876419464, null);
		}

		[UnityTest]
		public IEnumerator SaveLongNullableProperty()
		{
			yield return RunTest<LongNullableProperty1, long?>(2162499953876419464);
			yield return RunTest<LongNullableProperty2, long?>(-8954702388043848012);
			yield return RunTest<LongNullableProperty1, long?>(null);
			yield return RunTest<LongNullableProperty2, long?>(null);
		}

		[UnityTest]
		public IEnumerator SaveLongNullableProperties()
		{
			yield return RunTest<LongNullableProperties1, long?>(-8954702388043848012, 2162499953876419464);
			yield return RunTest<LongNullableProperties2, long?>(2162499953876419464, -8954702388043848012);
			yield return RunTest<LongNullableProperties1, long?>(null, 2162499953876419464);
			yield return RunTest<LongNullableProperties2, long?>(2162499953876419464, null);
		}

		[UnityTest]
		public IEnumerator SaveLongArrayField()
		{
			yield return RunTest<LongArrayField1, long[]>(new long[] { 2162499953876419464, -8954702388043848012 });
			yield return RunTest<LongArrayField2, long[]>(new long[] { -8954702388043848012, 2162499953876419464 });
		}

		[UnityTest]
		public IEnumerator SaveLongArrayFields()
		{
			yield return RunTest<LongArrayFields1, long[]>(new long[] { 2162499953876419464, -8954702388043848012 }, new long[] { 8681853928120073056, 7564779547598229612 });
			yield return RunTest<LongArrayFields2, long[]>(new long[] { -8954702388043848012, 2162499953876419464 }, new long[] { 7564779547598229612, 8681853928120073056 });
		}

		[UnityTest]
		public IEnumerator SaveLongArrayProperty()
		{
			yield return RunTest<LongArrayProperty1, long[]>(new long[] { 2162499953876419464, -8954702388043848012 });
			yield return RunTest<LongArrayProperty2, long[]>(new long[] { -8954702388043848012, 2162499953876419464 });
		}

		[UnityTest]
		public IEnumerator SaveLongArrayProperties()
		{
			yield return RunTest<LongArrayProperties1, long[]>(new long[] { 2162499953876419464, -8954702388043848012 }, new long[] { 8681853928120073056, 7564779547598229612 });
			yield return RunTest<LongArrayProperties2, long[]>(new long[] { -8954702388043848012, 2162499953876419464 }, new long[] { 7564779547598229612, 8681853928120073056 });
		}

		[UnityTest]
		public IEnumerator SaveLongArrayNullableField()
		{
			yield return RunTest<LongArrayNullableField1, long?[]>(new long?[] { null, -8954702388043848012 });
			yield return RunTest<LongArrayNullableField2, long?[]>(new long?[] { -8954702388043848012, null });
		}

		[UnityTest]
		public IEnumerator SaveLongArrayNullableFields()
		{
			yield return RunTest<LongArrayNullableFields1, long?[]>(new long?[] { null, -8954702388043848012 }, new long?[] { 8681853928120073056, null });
			yield return RunTest<LongArrayNullableFields2, long?[]>(new long?[] { -8954702388043848012, null }, new long?[] { null, 8681853928120073056 });
		}

		[UnityTest]
		public IEnumerator SaveLongArrayNullableProperty()
		{
			yield return RunTest<LongArrayNullableProperty1, long?[]>(new long?[] { null, -8954702388043848012 });
			yield return RunTest<LongArrayNullableProperty2, long?[]>(new long?[] { -8954702388043848012, null });
		}

		[UnityTest]
		public IEnumerator SaveLongArrayNullableProperties()
		{
			yield return RunTest<LongArrayNullableProperties1, long?[]>(new long?[] { 2162499953876419464, null }, new long?[] { null, 7564779547598229612 });
			yield return RunTest<LongArrayNullableProperties2, long?[]>(new long?[] { null, 2162499953876419464 }, new long?[] { 7564779547598229612, null });
		}

		[UnityTest]
		public IEnumerator SaveLongListField()
		{
			yield return RunTest<LongListField1, List<long>>(new List<long> { 2162499953876419464, -8954702388043848012 });
			yield return RunTest<LongListField2, List<long>>(new List<long> { -8954702388043848012, 2162499953876419464 });
		}

		[UnityTest]
		public IEnumerator SaveLongListFields()
		{
			yield return RunTest<LongListFields1, List<long>>(new List<long> { 2162499953876419464, -8954702388043848012 }, new List<long> { 8681853928120073056, 7564779547598229612 });
			yield return RunTest<LongListFields2, List<long>>(new List<long> { -8954702388043848012, 2162499953876419464 }, new List<long> { 7564779547598229612, 8681853928120073056 });
		}

		[UnityTest]
		public IEnumerator SaveLongListProperty()
		{
			yield return RunTest<LongListProperty1, List<long>>(new List<long> { 2162499953876419464, -8954702388043848012 });
			yield return RunTest<LongListProperty2, List<long>>(new List<long> { -8954702388043848012, 2162499953876419464 });
		}

		[UnityTest]
		public IEnumerator SaveLongListProperties()
		{
			yield return RunTest<LongListProperties1, List<long>>(new List<long> { 2162499953876419464, -8954702388043848012 }, new List<long> { 8681853928120073056, 7564779547598229612 });
			yield return RunTest<LongListProperties2, List<long>>(new List<long> { -8954702388043848012, 2162499953876419464 }, new List<long> { 7564779547598229612, 8681853928120073056 });
		}

		[UnityTest]
		public IEnumerator SaveLongListNullableField()
		{
			yield return RunTest<LongListNullableField1, List<long?>>(new List<long?> { null, -8954702388043848012 });
			yield return RunTest<LongListNullableField2, List<long?>>(new List<long?> { -8954702388043848012, null });
		}

		[UnityTest]
		public IEnumerator SaveLongListNullableFields()
		{
			yield return RunTest<LongListNullableFields1, List<long?>>(new List<long?> { null, -8954702388043848012 }, new List<long?> { 8681853928120073056, null });
			yield return RunTest<LongListNullableFields2, List<long?>>(new List<long?> { -8954702388043848012, null }, new List<long?> { null, 8681853928120073056 });
		}

		[UnityTest]
		public IEnumerator SaveLongListNullableProperty()
		{
			yield return RunTest<LongListNullableProperty1, List<long?>>(new List<long?> { null, -8954702388043848012 });
			yield return RunTest<LongListNullableProperty2, List<long?>>(new List<long?> { -8954702388043848012, null });
		}

		[UnityTest]
		public IEnumerator SaveLongListNullableProperties()
		{
			yield return RunTest<LongListNullableProperties1, List<long?>>(new List<long?> { 2162499953876419464, null }, new List<long?> { null, 7564779547598229612 });
			yield return RunTest<LongListNullableProperties2, List<long?>>(new List<long?> { null, 2162499953876419464 }, new List<long?> { 7564779547598229612, null });
		}
	}
}