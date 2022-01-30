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
		public IEnumerator SaveBoolField()
		{
			yield return RunTest<BoolField1, bool>(false);
			yield return RunTest<BoolField2, bool>(false);
		}

		[UnityTest]
		public IEnumerator SaveBoolFields()
		{
			yield return RunTest<BoolFields1, bool>(false, false);
			yield return RunTest<BoolFields2, bool>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveBoolProperty()
		{
			yield return RunTest<BoolProperty1, bool>(false);
			yield return RunTest<BoolProperty2, bool>(false);
		}

		[UnityTest]
		public IEnumerator SaveBoolProperties()
		{
			yield return RunTest<BoolProperties1, bool>(false, false);
			yield return RunTest<BoolProperties2, bool>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveBoolNullableField()
		{
			yield return RunTest<BoolNullableField1, bool?>(false);
			yield return RunTest<BoolNullableField2, bool?>(false);
			yield return RunTest<BoolNullableField1, bool?>(null);
			yield return RunTest<BoolNullableField2, bool?>(null);
		}

		[UnityTest]
		public IEnumerator SaveBoolNullableFields()
		{
			yield return RunTest<BoolNullableFields1, bool?>(false, false);
			yield return RunTest<BoolNullableFields2, bool?>(false, false);
			yield return RunTest<BoolNullableFields1, bool?>(null, false);
			yield return RunTest<BoolNullableFields2, bool?>(false, null);
		}

		[UnityTest]
		public IEnumerator SaveBoolNullableProperty()
		{
			yield return RunTest<BoolNullableProperty1, bool?>(false);
			yield return RunTest<BoolNullableProperty2, bool?>(false);
			yield return RunTest<BoolNullableProperty1, bool?>(null);
			yield return RunTest<BoolNullableProperty2, bool?>(null);
		}

		[UnityTest]
		public IEnumerator SaveBoolNullableProperties()
		{
			yield return RunTest<BoolNullableProperties1, bool?>(false, false);
			yield return RunTest<BoolNullableProperties2, bool?>(false, false);
			yield return RunTest<BoolNullableProperties1, bool?>(null, false);
			yield return RunTest<BoolNullableProperties2, bool?>(false, null);
		}

		[UnityTest]
		public IEnumerator SaveBoolArrayField()
		{
			yield return RunTest<BoolArrayField1, bool[]>(new bool[] { false, false });
			yield return RunTest<BoolArrayField2, bool[]>(new bool[] { false, false });
		}

		[UnityTest]
		public IEnumerator SaveBoolArrayFields()
		{
			yield return RunTest<BoolArrayFields1, bool[]>(new bool[] { false, false }, new bool[] { false, true });
			yield return RunTest<BoolArrayFields2, bool[]>(new bool[] { false, false }, new bool[] { true, false });
		}

		[UnityTest]
		public IEnumerator SaveBoolArrayProperty()
		{
			yield return RunTest<BoolArrayProperty1, bool[]>(new bool[] { false, false });
			yield return RunTest<BoolArrayProperty2, bool[]>(new bool[] { false, false });
		}

		[UnityTest]
		public IEnumerator SaveBoolArrayProperties()
		{
			yield return RunTest<BoolArrayProperties1, bool[]>(new bool[] { false, false }, new bool[] { false, true });
			yield return RunTest<BoolArrayProperties2, bool[]>(new bool[] { false, false }, new bool[] { true, false });
		}

		[UnityTest]
		public IEnumerator SaveBoolArrayNullableField()
		{
			yield return RunTest<BoolArrayNullableField1, bool?[]>(new bool?[] { null, false });
			yield return RunTest<BoolArrayNullableField2, bool?[]>(new bool?[] { false, null });
		}

		[UnityTest]
		public IEnumerator SaveBoolArrayNullableFields()
		{
			yield return RunTest<BoolArrayNullableFields1, bool?[]>(new bool?[] { null, false }, new bool?[] { false, null });
			yield return RunTest<BoolArrayNullableFields2, bool?[]>(new bool?[] { false, null }, new bool?[] { null, false });
		}

		[UnityTest]
		public IEnumerator SaveBoolArrayNullableProperty()
		{
			yield return RunTest<BoolArrayNullableProperty1, bool?[]>(new bool?[] { null, false });
			yield return RunTest<BoolArrayNullableProperty2, bool?[]>(new bool?[] { false, null });
		}

		[UnityTest]
		public IEnumerator SaveBoolArrayNullableProperties()
		{
			yield return RunTest<BoolArrayNullableProperties1, bool?[]>(new bool?[] { false, null }, new bool?[] { null, true });
			yield return RunTest<BoolArrayNullableProperties2, bool?[]>(new bool?[] { null, false }, new bool?[] { true, null });
		}

		[UnityTest]
		public IEnumerator SaveBoolListField()
		{
			yield return RunTest<BoolListField1, List<bool>>(new List<bool> { false, false });
			yield return RunTest<BoolListField2, List<bool>>(new List<bool> { false, false });
		}

		[UnityTest]
		public IEnumerator SaveBoolListFields()
		{
			yield return RunTest<BoolListFields1, List<bool>>(new List<bool> { false, false }, new List<bool> { false, true });
			yield return RunTest<BoolListFields2, List<bool>>(new List<bool> { false, false }, new List<bool> { true, false });
		}

		[UnityTest]
		public IEnumerator SaveBoolListProperty()
		{
			yield return RunTest<BoolListProperty1, List<bool>>(new List<bool> { false, false });
			yield return RunTest<BoolListProperty2, List<bool>>(new List<bool> { false, false });
		}

		[UnityTest]
		public IEnumerator SaveBoolListProperties()
		{
			yield return RunTest<BoolListProperties1, List<bool>>(new List<bool> { false, false }, new List<bool> { false, true });
			yield return RunTest<BoolListProperties2, List<bool>>(new List<bool> { false, false }, new List<bool> { true, false });
		}

		[UnityTest]
		public IEnumerator SaveBoolListNullableField()
		{
			yield return RunTest<BoolListNullableField1, List<bool?>>(new List<bool?> { null, false });
			yield return RunTest<BoolListNullableField2, List<bool?>>(new List<bool?> { false, null });
		}

		[UnityTest]
		public IEnumerator SaveBoolListNullableFields()
		{
			yield return RunTest<BoolListNullableFields1, List<bool?>>(new List<bool?> { null, false }, new List<bool?> { false, null });
			yield return RunTest<BoolListNullableFields2, List<bool?>>(new List<bool?> { false, null }, new List<bool?> { null, false });
		}

		[UnityTest]
		public IEnumerator SaveBoolListNullableProperty()
		{
			yield return RunTest<BoolListNullableProperty1, List<bool?>>(new List<bool?> { null, false });
			yield return RunTest<BoolListNullableProperty2, List<bool?>>(new List<bool?> { false, null });
		}

		[UnityTest]
		public IEnumerator SaveBoolListNullableProperties()
		{
			yield return RunTest<BoolListNullableProperties1, List<bool?>>(new List<bool?> { false, null }, new List<bool?> { null, true });
			yield return RunTest<BoolListNullableProperties2, List<bool?>>(new List<bool?> { null, false }, new List<bool?> { true, null });
		}
	}
}