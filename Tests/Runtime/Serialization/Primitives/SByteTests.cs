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
		public IEnumerator SaveSbyteField()
		{
			yield return RunTest<SbyteField1, sbyte>(-76);
			yield return RunTest<SbyteField2, sbyte>(-91);
		}

		[UnityTest]
		public IEnumerator SaveSbyteFields()
		{
			yield return RunTest<SbyteFields1, sbyte>(-91, -76);
			yield return RunTest<SbyteFields2, sbyte>(-76, -91);
		}

		[UnityTest]
		public IEnumerator SaveSbyteProperty()
		{
			yield return RunTest<SbyteProperty1, sbyte>(-76);
			yield return RunTest<SbyteProperty2, sbyte>(-91);
		}

		[UnityTest]
		public IEnumerator SaveSbyteProperties()
		{
			yield return RunTest<SbyteProperties1, sbyte>(-91, -76);
			yield return RunTest<SbyteProperties2, sbyte>(-76, -91);
		}

		[UnityTest]
		public IEnumerator SaveSbyteNullableField()
		{
			yield return RunTest<SbyteNullableField1, sbyte?>(-76);
			yield return RunTest<SbyteNullableField2, sbyte?>(-91);
			yield return RunTest<SbyteNullableField1, sbyte?>(null);
			yield return RunTest<SbyteNullableField2, sbyte?>(null);
		}

		[UnityTest]
		public IEnumerator SaveSbyteNullableFields()
		{
			yield return RunTest<SbyteNullableFields1, sbyte?>(-91, -76);
			yield return RunTest<SbyteNullableFields2, sbyte?>(-76, -91);
			yield return RunTest<SbyteNullableFields1, sbyte?>(null, -76);
			yield return RunTest<SbyteNullableFields2, sbyte?>(-76, null);
		}

		[UnityTest]
		public IEnumerator SaveSbyteNullableProperty()
		{
			yield return RunTest<SbyteNullableProperty1, sbyte?>(-76);
			yield return RunTest<SbyteNullableProperty2, sbyte?>(-91);
			yield return RunTest<SbyteNullableProperty1, sbyte?>(null);
			yield return RunTest<SbyteNullableProperty2, sbyte?>(null);
		}

		[UnityTest]
		public IEnumerator SaveSbyteNullableProperties()
		{
			yield return RunTest<SbyteNullableProperties1, sbyte?>(-91, -76);
			yield return RunTest<SbyteNullableProperties2, sbyte?>(-76, -91);
			yield return RunTest<SbyteNullableProperties1, sbyte?>(null, -76);
			yield return RunTest<SbyteNullableProperties2, sbyte?>(-76, null);
		}

		[UnityTest]
		public IEnumerator SaveSbyteArrayField()
		{
			yield return RunTest<SbyteArrayField1, sbyte[]>(new sbyte[] { -76, -91 });
			yield return RunTest<SbyteArrayField2, sbyte[]>(new sbyte[] { -91, -76 });
		}

		[UnityTest]
		public IEnumerator SaveSbyteArrayFields()
		{
			yield return RunTest<SbyteArrayFields1, sbyte[]>(new sbyte[] { -76, -91 }, new sbyte[] { 11, -42 });
			yield return RunTest<SbyteArrayFields2, sbyte[]>(new sbyte[] { -91, -76 }, new sbyte[] { -42, 11 });
		}

		[UnityTest]
		public IEnumerator SaveSbyteArrayProperty()
		{
			yield return RunTest<SbyteArrayProperty1, sbyte[]>(new sbyte[] { -76, -91 });
			yield return RunTest<SbyteArrayProperty2, sbyte[]>(new sbyte[] { -91, -76 });
		}

		[UnityTest]
		public IEnumerator SaveSbyteArrayProperties()
		{
			yield return RunTest<SbyteArrayProperties1, sbyte[]>(new sbyte[] { -76, -91 }, new sbyte[] { 11, -42 });
			yield return RunTest<SbyteArrayProperties2, sbyte[]>(new sbyte[] { -91, -76 }, new sbyte[] { -42, 11 });
		}

		[UnityTest]
		public IEnumerator SaveSbyteArrayNullableField()
		{
			yield return RunTest<SbyteArrayNullableField1, sbyte?[]>(new sbyte?[] { null, -91 });
			yield return RunTest<SbyteArrayNullableField2, sbyte?[]>(new sbyte?[] { -91, null });
		}

		[UnityTest]
		public IEnumerator SaveSbyteArrayNullableFields()
		{
			yield return RunTest<SbyteArrayNullableFields1, sbyte?[]>(new sbyte?[] { null, -91 }, new sbyte?[] { 11, null });
			yield return RunTest<SbyteArrayNullableFields2, sbyte?[]>(new sbyte?[] { -91, null }, new sbyte?[] { null, 11 });
		}

		[UnityTest]
		public IEnumerator SaveSbyteArrayNullableProperty()
		{
			yield return RunTest<SbyteArrayNullableProperty1, sbyte?[]>(new sbyte?[] { null, -91 });
			yield return RunTest<SbyteArrayNullableProperty2, sbyte?[]>(new sbyte?[] { -91, null });
		}

		[UnityTest]
		public IEnumerator SaveSbyteArrayNullableProperties()
		{
			yield return RunTest<SbyteArrayNullableProperties1, sbyte?[]>(new sbyte?[] { -76, null }, new sbyte?[] { null, -42 });
			yield return RunTest<SbyteArrayNullableProperties2, sbyte?[]>(new sbyte?[] { null, -76 }, new sbyte?[] { -42, null });
		}

		[UnityTest]
		public IEnumerator SaveSbyteListField()
		{
			yield return RunTest<SbyteListField1, List<sbyte>>(new List<sbyte> { -76, -91 });
			yield return RunTest<SbyteListField2, List<sbyte>>(new List<sbyte> { -91, -76 });
		}

		[UnityTest]
		public IEnumerator SaveSbyteListFields()
		{
			yield return RunTest<SbyteListFields1, List<sbyte>>(new List<sbyte> { -76, -91 }, new List<sbyte> { 11, -42 });
			yield return RunTest<SbyteListFields2, List<sbyte>>(new List<sbyte> { -91, -76 }, new List<sbyte> { -42, 11 });
		}

		[UnityTest]
		public IEnumerator SaveSbyteListProperty()
		{
			yield return RunTest<SbyteListProperty1, List<sbyte>>(new List<sbyte> { -76, -91 });
			yield return RunTest<SbyteListProperty2, List<sbyte>>(new List<sbyte> { -91, -76 });
		}

		[UnityTest]
		public IEnumerator SaveSbyteListProperties()
		{
			yield return RunTest<SbyteListProperties1, List<sbyte>>(new List<sbyte> { -76, -91 }, new List<sbyte> { 11, -42 });
			yield return RunTest<SbyteListProperties2, List<sbyte>>(new List<sbyte> { -91, -76 }, new List<sbyte> { -42, 11 });
		}

		[UnityTest]
		public IEnumerator SaveSbyteListNullableField()
		{
			yield return RunTest<SbyteListNullableField1, List<sbyte?>>(new List<sbyte?> { null, -91 });
			yield return RunTest<SbyteListNullableField2, List<sbyte?>>(new List<sbyte?> { -91, null });
		}

		[UnityTest]
		public IEnumerator SaveSbyteListNullableFields()
		{
			yield return RunTest<SbyteListNullableFields1, List<sbyte?>>(new List<sbyte?> { null, -91 }, new List<sbyte?> { 11, null });
			yield return RunTest<SbyteListNullableFields2, List<sbyte?>>(new List<sbyte?> { -91, null }, new List<sbyte?> { null, 11 });
		}

		[UnityTest]
		public IEnumerator SaveSbyteListNullableProperty()
		{
			yield return RunTest<SbyteListNullableProperty1, List<sbyte?>>(new List<sbyte?> { null, -91 });
			yield return RunTest<SbyteListNullableProperty2, List<sbyte?>>(new List<sbyte?> { -91, null });
		}

		[UnityTest]
		public IEnumerator SaveSbyteListNullableProperties()
		{
			yield return RunTest<SbyteListNullableProperties1, List<sbyte?>>(new List<sbyte?> { -76, null }, new List<sbyte?> { null, -42 });
			yield return RunTest<SbyteListNullableProperties2, List<sbyte?>>(new List<sbyte?> { null, -76 }, new List<sbyte?> { -42, null });
		}
	}
}