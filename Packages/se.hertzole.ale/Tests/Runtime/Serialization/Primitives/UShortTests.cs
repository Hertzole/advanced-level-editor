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
		public IEnumerator SaveUshortField()
		{
			yield return RunTest<UshortField1, ushort>(633);
			yield return RunTest<UshortField2, ushort>(11927);
		}

		[UnityTest]
		public IEnumerator SaveUshortFields()
		{
			yield return RunTest<UshortFields1, ushort>(11927, 633);
			yield return RunTest<UshortFields2, ushort>(633, 11927);
		}

		[UnityTest]
		public IEnumerator SaveUshortProperty()
		{
			yield return RunTest<UshortProperty1, ushort>(633);
			yield return RunTest<UshortProperty2, ushort>(11927);
		}

		[UnityTest]
		public IEnumerator SaveUshortProperties()
		{
			yield return RunTest<UshortProperties1, ushort>(11927, 633);
			yield return RunTest<UshortProperties2, ushort>(633, 11927);
		}

		[UnityTest]
		public IEnumerator SaveUshortNullableField()
		{
			yield return RunTest<UshortNullableField1, ushort?>(633);
			yield return RunTest<UshortNullableField2, ushort?>(11927);
			yield return RunTest<UshortNullableField1, ushort?>(null);
			yield return RunTest<UshortNullableField2, ushort?>(null);
		}

		[UnityTest]
		public IEnumerator SaveUshortNullableFields()
		{
			yield return RunTest<UshortNullableFields1, ushort?>(11927, 633);
			yield return RunTest<UshortNullableFields2, ushort?>(633, 11927);
			yield return RunTest<UshortNullableFields1, ushort?>(null, 633);
			yield return RunTest<UshortNullableFields2, ushort?>(633, null);
		}

		[UnityTest]
		public IEnumerator SaveUshortNullableProperty()
		{
			yield return RunTest<UshortNullableProperty1, ushort?>(633);
			yield return RunTest<UshortNullableProperty2, ushort?>(11927);
			yield return RunTest<UshortNullableProperty1, ushort?>(null);
			yield return RunTest<UshortNullableProperty2, ushort?>(null);
		}

		[UnityTest]
		public IEnumerator SaveUshortNullableProperties()
		{
			yield return RunTest<UshortNullableProperties1, ushort?>(11927, 633);
			yield return RunTest<UshortNullableProperties2, ushort?>(633, 11927);
			yield return RunTest<UshortNullableProperties1, ushort?>(null, 633);
			yield return RunTest<UshortNullableProperties2, ushort?>(633, null);
		}

		[UnityTest]
		public IEnumerator SaveUshortArrayField()
		{
			yield return RunTest<UshortArrayField1, ushort[]>(new ushort[] { 633, 11927 });
			yield return RunTest<UshortArrayField2, ushort[]>(new ushort[] { 11927, 633 });
		}

		[UnityTest]
		public IEnumerator SaveUshortArrayFields()
		{
			yield return RunTest<UshortArrayFields1, ushort[]>(new ushort[] { 633, 11927 }, new ushort[] { 24518, 62513 });
			yield return RunTest<UshortArrayFields2, ushort[]>(new ushort[] { 11927, 633 }, new ushort[] { 62513, 24518 });
		}

		[UnityTest]
		public IEnumerator SaveUshortArrayProperty()
		{
			yield return RunTest<UshortArrayProperty1, ushort[]>(new ushort[] { 633, 11927 });
			yield return RunTest<UshortArrayProperty2, ushort[]>(new ushort[] { 11927, 633 });
		}

		[UnityTest]
		public IEnumerator SaveUshortArrayProperties()
		{
			yield return RunTest<UshortArrayProperties1, ushort[]>(new ushort[] { 633, 11927 }, new ushort[] { 24518, 62513 });
			yield return RunTest<UshortArrayProperties2, ushort[]>(new ushort[] { 11927, 633 }, new ushort[] { 62513, 24518 });
		}

		[UnityTest]
		public IEnumerator SaveUshortArrayNullableField()
		{
			yield return RunTest<UshortArrayNullableField1, ushort?[]>(new ushort?[] { null, 11927 });
			yield return RunTest<UshortArrayNullableField2, ushort?[]>(new ushort?[] { 11927, null });
		}

		[UnityTest]
		public IEnumerator SaveUshortArrayNullableFields()
		{
			yield return RunTest<UshortArrayNullableFields1, ushort?[]>(new ushort?[] { null, 11927 }, new ushort?[] { 24518, null });
			yield return RunTest<UshortArrayNullableFields2, ushort?[]>(new ushort?[] { 11927, null }, new ushort?[] { null, 24518 });
		}

		[UnityTest]
		public IEnumerator SaveUshortArrayNullableProperty()
		{
			yield return RunTest<UshortArrayNullableProperty1, ushort?[]>(new ushort?[] { null, 11927 });
			yield return RunTest<UshortArrayNullableProperty2, ushort?[]>(new ushort?[] { 11927, null });
		}

		[UnityTest]
		public IEnumerator SaveUshortArrayNullableProperties()
		{
			yield return RunTest<UshortArrayNullableProperties1, ushort?[]>(new ushort?[] { 633, null }, new ushort?[] { null, 62513 });
			yield return RunTest<UshortArrayNullableProperties2, ushort?[]>(new ushort?[] { null, 633 }, new ushort?[] { 62513, null });
		}

		[UnityTest]
		public IEnumerator SaveUshortListField()
		{
			yield return RunTest<UshortListField1, List<ushort>>(new List<ushort> { 633, 11927 });
			yield return RunTest<UshortListField2, List<ushort>>(new List<ushort> { 11927, 633 });
		}

		[UnityTest]
		public IEnumerator SaveUshortListFields()
		{
			yield return RunTest<UshortListFields1, List<ushort>>(new List<ushort> { 633, 11927 }, new List<ushort> { 24518, 62513 });
			yield return RunTest<UshortListFields2, List<ushort>>(new List<ushort> { 11927, 633 }, new List<ushort> { 62513, 24518 });
		}

		[UnityTest]
		public IEnumerator SaveUshortListProperty()
		{
			yield return RunTest<UshortListProperty1, List<ushort>>(new List<ushort> { 633, 11927 });
			yield return RunTest<UshortListProperty2, List<ushort>>(new List<ushort> { 11927, 633 });
		}

		[UnityTest]
		public IEnumerator SaveUshortListProperties()
		{
			yield return RunTest<UshortListProperties1, List<ushort>>(new List<ushort> { 633, 11927 }, new List<ushort> { 24518, 62513 });
			yield return RunTest<UshortListProperties2, List<ushort>>(new List<ushort> { 11927, 633 }, new List<ushort> { 62513, 24518 });
		}

		[UnityTest]
		public IEnumerator SaveUshortListNullableField()
		{
			yield return RunTest<UshortListNullableField1, List<ushort?>>(new List<ushort?> { null, 11927 });
			yield return RunTest<UshortListNullableField2, List<ushort?>>(new List<ushort?> { 11927, null });
		}

		[UnityTest]
		public IEnumerator SaveUshortListNullableFields()
		{
			yield return RunTest<UshortListNullableFields1, List<ushort?>>(new List<ushort?> { null, 11927 }, new List<ushort?> { 24518, null });
			yield return RunTest<UshortListNullableFields2, List<ushort?>>(new List<ushort?> { 11927, null }, new List<ushort?> { null, 24518 });
		}

		[UnityTest]
		public IEnumerator SaveUshortListNullableProperty()
		{
			yield return RunTest<UshortListNullableProperty1, List<ushort?>>(new List<ushort?> { null, 11927 });
			yield return RunTest<UshortListNullableProperty2, List<ushort?>>(new List<ushort?> { 11927, null });
		}

		[UnityTest]
		public IEnumerator SaveUshortListNullableProperties()
		{
			yield return RunTest<UshortListNullableProperties1, List<ushort?>>(new List<ushort?> { 633, null }, new List<ushort?> { null, 62513 });
			yield return RunTest<UshortListNullableProperties2, List<ushort?>>(new List<ushort?> { null, 633 }, new List<ushort?> { 62513, null });
		}
	}
}