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
		public IEnumerator SaveShortField()
		{
			yield return RunTest<ShortField1, short>(10675);
			yield return RunTest<ShortField2, short>(24817);
		}

		[UnityTest]
		public IEnumerator SaveShortFields()
		{
			yield return RunTest<ShortFields1, short>(24817, 10675);
			yield return RunTest<ShortFields2, short>(10675, 24817);
		}

		[UnityTest]
		public IEnumerator SaveShortProperty()
		{
			yield return RunTest<ShortProperty1, short>(10675);
			yield return RunTest<ShortProperty2, short>(24817);
		}

		[UnityTest]
		public IEnumerator SaveShortProperties()
		{
			yield return RunTest<ShortProperties1, short>(24817, 10675);
			yield return RunTest<ShortProperties2, short>(10675, 24817);
		}

		[UnityTest]
		public IEnumerator SaveShortNullableField()
		{
			yield return RunTest<ShortNullableField1, short?>(10675);
			yield return RunTest<ShortNullableField2, short?>(24817);
			yield return RunTest<ShortNullableField1, short?>(null);
			yield return RunTest<ShortNullableField2, short?>(null);
		}

		[UnityTest]
		public IEnumerator SaveShortNullableFields()
		{
			yield return RunTest<ShortNullableFields1, short?>(24817, 10675);
			yield return RunTest<ShortNullableFields2, short?>(10675, 24817);
			yield return RunTest<ShortNullableFields1, short?>(null, 10675);
			yield return RunTest<ShortNullableFields2, short?>(10675, null);
		}

		[UnityTest]
		public IEnumerator SaveShortNullableProperty()
		{
			yield return RunTest<ShortNullableProperty1, short?>(10675);
			yield return RunTest<ShortNullableProperty2, short?>(24817);
			yield return RunTest<ShortNullableProperty1, short?>(null);
			yield return RunTest<ShortNullableProperty2, short?>(null);
		}

		[UnityTest]
		public IEnumerator SaveShortNullableProperties()
		{
			yield return RunTest<ShortNullableProperties1, short?>(24817, 10675);
			yield return RunTest<ShortNullableProperties2, short?>(10675, 24817);
			yield return RunTest<ShortNullableProperties1, short?>(null, 10675);
			yield return RunTest<ShortNullableProperties2, short?>(10675, null);
		}

		[UnityTest]
		public IEnumerator SaveShortArrayField()
		{
			yield return RunTest<ShortArrayField1, short[]>(new short[] { 10675, 24817 });
			yield return RunTest<ShortArrayField2, short[]>(new short[] { 24817, 10675 });
		}

		[UnityTest]
		public IEnumerator SaveShortArrayFields()
		{
			yield return RunTest<ShortArrayFields1, short[]>(new short[] { 10675, 24817 }, new short[] { -11234, 19762 });
			yield return RunTest<ShortArrayFields2, short[]>(new short[] { 24817, 10675 }, new short[] { 19762, -11234 });
		}

		[UnityTest]
		public IEnumerator SaveShortArrayProperty()
		{
			yield return RunTest<ShortArrayProperty1, short[]>(new short[] { 10675, 24817 });
			yield return RunTest<ShortArrayProperty2, short[]>(new short[] { 24817, 10675 });
		}

		[UnityTest]
		public IEnumerator SaveShortArrayProperties()
		{
			yield return RunTest<ShortArrayProperties1, short[]>(new short[] { 10675, 24817 }, new short[] { -11234, 19762 });
			yield return RunTest<ShortArrayProperties2, short[]>(new short[] { 24817, 10675 }, new short[] { 19762, -11234 });
		}

		[UnityTest]
		public IEnumerator SaveShortArrayNullableField()
		{
			yield return RunTest<ShortArrayNullableField1, short?[]>(new short?[] { null, 24817 });
			yield return RunTest<ShortArrayNullableField2, short?[]>(new short?[] { 24817, null });
		}

		[UnityTest]
		public IEnumerator SaveShortArrayNullableFields()
		{
			yield return RunTest<ShortArrayNullableFields1, short?[]>(new short?[] { null, 24817 }, new short?[] { -11234, null });
			yield return RunTest<ShortArrayNullableFields2, short?[]>(new short?[] { 24817, null }, new short?[] { null, -11234 });
		}

		[UnityTest]
		public IEnumerator SaveShortArrayNullableProperty()
		{
			yield return RunTest<ShortArrayNullableProperty1, short?[]>(new short?[] { null, 24817 });
			yield return RunTest<ShortArrayNullableProperty2, short?[]>(new short?[] { 24817, null });
		}

		[UnityTest]
		public IEnumerator SaveShortArrayNullableProperties()
		{
			yield return RunTest<ShortArrayNullableProperties1, short?[]>(new short?[] { 10675, null }, new short?[] { null, 19762 });
			yield return RunTest<ShortArrayNullableProperties2, short?[]>(new short?[] { null, 10675 }, new short?[] { 19762, null });
		}

		[UnityTest]
		public IEnumerator SaveShortListField()
		{
			yield return RunTest<ShortListField1, List<short>>(new List<short> { 10675, 24817 });
			yield return RunTest<ShortListField2, List<short>>(new List<short> { 24817, 10675 });
		}

		[UnityTest]
		public IEnumerator SaveShortListFields()
		{
			yield return RunTest<ShortListFields1, List<short>>(new List<short> { 10675, 24817 }, new List<short> { -11234, 19762 });
			yield return RunTest<ShortListFields2, List<short>>(new List<short> { 24817, 10675 }, new List<short> { 19762, -11234 });
		}

		[UnityTest]
		public IEnumerator SaveShortListProperty()
		{
			yield return RunTest<ShortListProperty1, List<short>>(new List<short> { 10675, 24817 });
			yield return RunTest<ShortListProperty2, List<short>>(new List<short> { 24817, 10675 });
		}

		[UnityTest]
		public IEnumerator SaveShortListProperties()
		{
			yield return RunTest<ShortListProperties1, List<short>>(new List<short> { 10675, 24817 }, new List<short> { -11234, 19762 });
			yield return RunTest<ShortListProperties2, List<short>>(new List<short> { 24817, 10675 }, new List<short> { 19762, -11234 });
		}

		[UnityTest]
		public IEnumerator SaveShortListNullableField()
		{
			yield return RunTest<ShortListNullableField1, List<short?>>(new List<short?> { null, 24817 });
			yield return RunTest<ShortListNullableField2, List<short?>>(new List<short?> { 24817, null });
		}

		[UnityTest]
		public IEnumerator SaveShortListNullableFields()
		{
			yield return RunTest<ShortListNullableFields1, List<short?>>(new List<short?> { null, 24817 }, new List<short?> { -11234, null });
			yield return RunTest<ShortListNullableFields2, List<short?>>(new List<short?> { 24817, null }, new List<short?> { null, -11234 });
		}

		[UnityTest]
		public IEnumerator SaveShortListNullableProperty()
		{
			yield return RunTest<ShortListNullableProperty1, List<short?>>(new List<short?> { null, 24817 });
			yield return RunTest<ShortListNullableProperty2, List<short?>>(new List<short?> { 24817, null });
		}

		[UnityTest]
		public IEnumerator SaveShortListNullableProperties()
		{
			yield return RunTest<ShortListNullableProperties1, List<short?>>(new List<short?> { 10675, null }, new List<short?> { null, 19762 });
			yield return RunTest<ShortListNullableProperties2, List<short?>>(new List<short?> { null, 10675 }, new List<short?> { 19762, null });
		}
	}
}