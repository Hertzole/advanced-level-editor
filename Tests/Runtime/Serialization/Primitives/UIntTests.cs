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
		public IEnumerator SaveUintField()
		{
			yield return RunTest<UintField1, uint>(3026338874);
			yield return RunTest<UintField2, uint>(1489495558);
		}

		[UnityTest]
		public IEnumerator SaveUintFields()
		{
			yield return RunTest<UintFields1, uint>(1489495558, 3026338874);
			yield return RunTest<UintFields2, uint>(3026338874, 1489495558);
		}

		[UnityTest]
		public IEnumerator SaveUintProperty()
		{
			yield return RunTest<UintProperty1, uint>(3026338874);
			yield return RunTest<UintProperty2, uint>(1489495558);
		}

		[UnityTest]
		public IEnumerator SaveUintProperties()
		{
			yield return RunTest<UintProperties1, uint>(1489495558, 3026338874);
			yield return RunTest<UintProperties2, uint>(3026338874, 1489495558);
		}

		[UnityTest]
		public IEnumerator SaveUintNullableField()
		{
			yield return RunTest<UintNullableField1, uint?>(3026338874);
			yield return RunTest<UintNullableField2, uint?>(1489495558);
			yield return RunTest<UintNullableField1, uint?>(null);
			yield return RunTest<UintNullableField2, uint?>(null);
		}

		[UnityTest]
		public IEnumerator SaveUintNullableFields()
		{
			yield return RunTest<UintNullableFields1, uint?>(1489495558, 3026338874);
			yield return RunTest<UintNullableFields2, uint?>(3026338874, 1489495558);
			yield return RunTest<UintNullableFields1, uint?>(null, 3026338874);
			yield return RunTest<UintNullableFields2, uint?>(3026338874, null);
		}

		[UnityTest]
		public IEnumerator SaveUintNullableProperty()
		{
			yield return RunTest<UintNullableProperty1, uint?>(3026338874);
			yield return RunTest<UintNullableProperty2, uint?>(1489495558);
			yield return RunTest<UintNullableProperty1, uint?>(null);
			yield return RunTest<UintNullableProperty2, uint?>(null);
		}

		[UnityTest]
		public IEnumerator SaveUintNullableProperties()
		{
			yield return RunTest<UintNullableProperties1, uint?>(1489495558, 3026338874);
			yield return RunTest<UintNullableProperties2, uint?>(3026338874, 1489495558);
			yield return RunTest<UintNullableProperties1, uint?>(null, 3026338874);
			yield return RunTest<UintNullableProperties2, uint?>(3026338874, null);
		}

		[UnityTest]
		public IEnumerator SaveUintArrayField()
		{
			yield return RunTest<UintArrayField1, uint[]>(new uint[] { 3026338874, 1489495558 });
			yield return RunTest<UintArrayField2, uint[]>(new uint[] { 1489495558, 3026338874 });
		}

		[UnityTest]
		public IEnumerator SaveUintArrayFields()
		{
			yield return RunTest<UintArrayFields1, uint[]>(new uint[] { 3026338874, 1489495558 }, new uint[] { 4262133984, 403425789 });
			yield return RunTest<UintArrayFields2, uint[]>(new uint[] { 1489495558, 3026338874 }, new uint[] { 403425789, 4262133984 });
		}

		[UnityTest]
		public IEnumerator SaveUintArrayProperty()
		{
			yield return RunTest<UintArrayProperty1, uint[]>(new uint[] { 3026338874, 1489495558 });
			yield return RunTest<UintArrayProperty2, uint[]>(new uint[] { 1489495558, 3026338874 });
		}

		[UnityTest]
		public IEnumerator SaveUintArrayProperties()
		{
			yield return RunTest<UintArrayProperties1, uint[]>(new uint[] { 3026338874, 1489495558 }, new uint[] { 4262133984, 403425789 });
			yield return RunTest<UintArrayProperties2, uint[]>(new uint[] { 1489495558, 3026338874 }, new uint[] { 403425789, 4262133984 });
		}

		[UnityTest]
		public IEnumerator SaveUintArrayNullableField()
		{
			yield return RunTest<UintArrayNullableField1, uint?[]>(new uint?[] { null, 1489495558 });
			yield return RunTest<UintArrayNullableField2, uint?[]>(new uint?[] { 1489495558, null });
		}

		[UnityTest]
		public IEnumerator SaveUintArrayNullableFields()
		{
			yield return RunTest<UintArrayNullableFields1, uint?[]>(new uint?[] { null, 1489495558 }, new uint?[] { 4262133984, null });
			yield return RunTest<UintArrayNullableFields2, uint?[]>(new uint?[] { 1489495558, null }, new uint?[] { null, 4262133984 });
		}

		[UnityTest]
		public IEnumerator SaveUintArrayNullableProperty()
		{
			yield return RunTest<UintArrayNullableProperty1, uint?[]>(new uint?[] { null, 1489495558 });
			yield return RunTest<UintArrayNullableProperty2, uint?[]>(new uint?[] { 1489495558, null });
		}

		[UnityTest]
		public IEnumerator SaveUintArrayNullableProperties()
		{
			yield return RunTest<UintArrayNullableProperties1, uint?[]>(new uint?[] { 3026338874, null }, new uint?[] { null, 403425789 });
			yield return RunTest<UintArrayNullableProperties2, uint?[]>(new uint?[] { null, 3026338874 }, new uint?[] { 403425789, null });
		}

		[UnityTest]
		public IEnumerator SaveUintListField()
		{
			yield return RunTest<UintListField1, List<uint>>(new List<uint> { 3026338874, 1489495558 });
			yield return RunTest<UintListField2, List<uint>>(new List<uint> { 1489495558, 3026338874 });
		}

		[UnityTest]
		public IEnumerator SaveUintListFields()
		{
			yield return RunTest<UintListFields1, List<uint>>(new List<uint> { 3026338874, 1489495558 }, new List<uint> { 4262133984, 403425789 });
			yield return RunTest<UintListFields2, List<uint>>(new List<uint> { 1489495558, 3026338874 }, new List<uint> { 403425789, 4262133984 });
		}

		[UnityTest]
		public IEnumerator SaveUintListProperty()
		{
			yield return RunTest<UintListProperty1, List<uint>>(new List<uint> { 3026338874, 1489495558 });
			yield return RunTest<UintListProperty2, List<uint>>(new List<uint> { 1489495558, 3026338874 });
		}

		[UnityTest]
		public IEnumerator SaveUintListProperties()
		{
			yield return RunTest<UintListProperties1, List<uint>>(new List<uint> { 3026338874, 1489495558 }, new List<uint> { 4262133984, 403425789 });
			yield return RunTest<UintListProperties2, List<uint>>(new List<uint> { 1489495558, 3026338874 }, new List<uint> { 403425789, 4262133984 });
		}

		[UnityTest]
		public IEnumerator SaveUintListNullableField()
		{
			yield return RunTest<UintListNullableField1, List<uint?>>(new List<uint?> { null, 1489495558 });
			yield return RunTest<UintListNullableField2, List<uint?>>(new List<uint?> { 1489495558, null });
		}

		[UnityTest]
		public IEnumerator SaveUintListNullableFields()
		{
			yield return RunTest<UintListNullableFields1, List<uint?>>(new List<uint?> { null, 1489495558 }, new List<uint?> { 4262133984, null });
			yield return RunTest<UintListNullableFields2, List<uint?>>(new List<uint?> { 1489495558, null }, new List<uint?> { null, 4262133984 });
		}

		[UnityTest]
		public IEnumerator SaveUintListNullableProperty()
		{
			yield return RunTest<UintListNullableProperty1, List<uint?>>(new List<uint?> { null, 1489495558 });
			yield return RunTest<UintListNullableProperty2, List<uint?>>(new List<uint?> { 1489495558, null });
		}

		[UnityTest]
		public IEnumerator SaveUintListNullableProperties()
		{
			yield return RunTest<UintListNullableProperties1, List<uint?>>(new List<uint?> { 3026338874, null }, new List<uint?> { null, 403425789 });
			yield return RunTest<UintListNullableProperties2, List<uint?>>(new List<uint?> { null, 3026338874 }, new List<uint?> { 403425789, null });
		}
	}
}