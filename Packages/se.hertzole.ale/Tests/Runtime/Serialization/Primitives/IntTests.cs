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
		public IEnumerator SaveIntField()
		{
			yield return RunTest<IntField1, int>(-1026373409);
			yield return RunTest<IntField2, int>(972229886);
		}

		[UnityTest]
		public IEnumerator SaveIntFields()
		{
			yield return RunTest<IntFields1, int>(972229886, -1026373409);
			yield return RunTest<IntFields2, int>(-1026373409, 972229886);
		}

		[UnityTest]
		public IEnumerator SaveIntProperty()
		{
			yield return RunTest<IntProperty1, int>(-1026373409);
			yield return RunTest<IntProperty2, int>(972229886);
		}

		[UnityTest]
		public IEnumerator SaveIntProperties()
		{
			yield return RunTest<IntProperties1, int>(972229886, -1026373409);
			yield return RunTest<IntProperties2, int>(-1026373409, 972229886);
		}

		[UnityTest]
		public IEnumerator SaveIntNullableField()
		{
			yield return RunTest<IntNullableField1, int?>(-1026373409);
			yield return RunTest<IntNullableField2, int?>(972229886);
			yield return RunTest<IntNullableField1, int?>(null);
			yield return RunTest<IntNullableField2, int?>(null);
		}

		[UnityTest]
		public IEnumerator SaveIntNullableFields()
		{
			yield return RunTest<IntNullableFields1, int?>(972229886, -1026373409);
			yield return RunTest<IntNullableFields2, int?>(-1026373409, 972229886);
			yield return RunTest<IntNullableFields1, int?>(null, -1026373409);
			yield return RunTest<IntNullableFields2, int?>(-1026373409, null);
		}

		[UnityTest]
		public IEnumerator SaveIntNullableProperty()
		{
			yield return RunTest<IntNullableProperty1, int?>(-1026373409);
			yield return RunTest<IntNullableProperty2, int?>(972229886);
			yield return RunTest<IntNullableProperty1, int?>(null);
			yield return RunTest<IntNullableProperty2, int?>(null);
		}

		[UnityTest]
		public IEnumerator SaveIntNullableProperties()
		{
			yield return RunTest<IntNullableProperties1, int?>(972229886, -1026373409);
			yield return RunTest<IntNullableProperties2, int?>(-1026373409, 972229886);
			yield return RunTest<IntNullableProperties1, int?>(null, -1026373409);
			yield return RunTest<IntNullableProperties2, int?>(-1026373409, null);
		}

		[UnityTest]
		public IEnumerator SaveIntArrayField()
		{
			yield return RunTest<IntArrayField1, int[]>(new int[] { -1026373409, 972229886 });
			yield return RunTest<IntArrayField2, int[]>(new int[] { 972229886, -1026373409 });
		}

		[UnityTest]
		public IEnumerator SaveIntArrayFields()
		{
			yield return RunTest<IntArrayFields1, int[]>(new int[] { -1026373409, 972229886 }, new int[] { -314859325, -669646805 });
			yield return RunTest<IntArrayFields2, int[]>(new int[] { 972229886, -1026373409 }, new int[] { -669646805, -314859325 });
		}

		[UnityTest]
		public IEnumerator SaveIntArrayProperty()
		{
			yield return RunTest<IntArrayProperty1, int[]>(new int[] { -1026373409, 972229886 });
			yield return RunTest<IntArrayProperty2, int[]>(new int[] { 972229886, -1026373409 });
		}

		[UnityTest]
		public IEnumerator SaveIntArrayProperties()
		{
			yield return RunTest<IntArrayProperties1, int[]>(new int[] { -1026373409, 972229886 }, new int[] { -314859325, -669646805 });
			yield return RunTest<IntArrayProperties2, int[]>(new int[] { 972229886, -1026373409 }, new int[] { -669646805, -314859325 });
		}

		[UnityTest]
		public IEnumerator SaveIntArrayNullableField()
		{
			yield return RunTest<IntArrayNullableField1, int?[]>(new int?[] { null, 972229886 });
			yield return RunTest<IntArrayNullableField2, int?[]>(new int?[] { 972229886, null });
		}

		[UnityTest]
		public IEnumerator SaveIntArrayNullableFields()
		{
			yield return RunTest<IntArrayNullableFields1, int?[]>(new int?[] { null, 972229886 }, new int?[] { -314859325, null });
			yield return RunTest<IntArrayNullableFields2, int?[]>(new int?[] { 972229886, null }, new int?[] { null, -314859325 });
		}

		[UnityTest]
		public IEnumerator SaveIntArrayNullableProperty()
		{
			yield return RunTest<IntArrayNullableProperty1, int?[]>(new int?[] { null, 972229886 });
			yield return RunTest<IntArrayNullableProperty2, int?[]>(new int?[] { 972229886, null });
		}

		[UnityTest]
		public IEnumerator SaveIntArrayNullableProperties()
		{
			yield return RunTest<IntArrayNullableProperties1, int?[]>(new int?[] { -1026373409, null }, new int?[] { null, -669646805 });
			yield return RunTest<IntArrayNullableProperties2, int?[]>(new int?[] { null, -1026373409 }, new int?[] { -669646805, null });
		}

		[UnityTest]
		public IEnumerator SaveIntListField()
		{
			yield return RunTest<IntListField1, List<int>>(new List<int> { -1026373409, 972229886 });
			yield return RunTest<IntListField2, List<int>>(new List<int> { 972229886, -1026373409 });
		}

		[UnityTest]
		public IEnumerator SaveIntListFields()
		{
			yield return RunTest<IntListFields1, List<int>>(new List<int> { -1026373409, 972229886 }, new List<int> { -314859325, -669646805 });
			yield return RunTest<IntListFields2, List<int>>(new List<int> { 972229886, -1026373409 }, new List<int> { -669646805, -314859325 });
		}

		[UnityTest]
		public IEnumerator SaveIntListProperty()
		{
			yield return RunTest<IntListProperty1, List<int>>(new List<int> { -1026373409, 972229886 });
			yield return RunTest<IntListProperty2, List<int>>(new List<int> { 972229886, -1026373409 });
		}

		[UnityTest]
		public IEnumerator SaveIntListProperties()
		{
			yield return RunTest<IntListProperties1, List<int>>(new List<int> { -1026373409, 972229886 }, new List<int> { -314859325, -669646805 });
			yield return RunTest<IntListProperties2, List<int>>(new List<int> { 972229886, -1026373409 }, new List<int> { -669646805, -314859325 });
		}

		[UnityTest]
		public IEnumerator SaveIntListNullableField()
		{
			yield return RunTest<IntListNullableField1, List<int?>>(new List<int?> { null, 972229886 });
			yield return RunTest<IntListNullableField2, List<int?>>(new List<int?> { 972229886, null });
		}

		[UnityTest]
		public IEnumerator SaveIntListNullableFields()
		{
			yield return RunTest<IntListNullableFields1, List<int?>>(new List<int?> { null, 972229886 }, new List<int?> { -314859325, null });
			yield return RunTest<IntListNullableFields2, List<int?>>(new List<int?> { 972229886, null }, new List<int?> { null, -314859325 });
		}

		[UnityTest]
		public IEnumerator SaveIntListNullableProperty()
		{
			yield return RunTest<IntListNullableProperty1, List<int?>>(new List<int?> { null, 972229886 });
			yield return RunTest<IntListNullableProperty2, List<int?>>(new List<int?> { 972229886, null });
		}

		[UnityTest]
		public IEnumerator SaveIntListNullableProperties()
		{
			yield return RunTest<IntListNullableProperties1, List<int?>>(new List<int?> { -1026373409, null }, new List<int?> { null, -669646805 });
			yield return RunTest<IntListNullableProperties2, List<int?>>(new List<int?> { null, -1026373409 }, new List<int?> { -669646805, null });
		}
	}
}