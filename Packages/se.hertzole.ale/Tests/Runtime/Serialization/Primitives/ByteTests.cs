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
		public IEnumerator SaveByteField()
		{
			yield return RunTest<ByteField1, byte>(232);
			yield return RunTest<ByteField2, byte>(194);
		}

		[UnityTest]
		public IEnumerator SaveByteFields()
		{
			yield return RunTest<ByteFields1, byte>(194, 232);
			yield return RunTest<ByteFields2, byte>(232, 194);
		}

		[UnityTest]
		public IEnumerator SaveByteProperty()
		{
			yield return RunTest<ByteProperty1, byte>(232);
			yield return RunTest<ByteProperty2, byte>(194);
		}

		[UnityTest]
		public IEnumerator SaveByteProperties()
		{
			yield return RunTest<ByteProperties1, byte>(194, 232);
			yield return RunTest<ByteProperties2, byte>(232, 194);
		}

		[UnityTest]
		public IEnumerator SaveByteNullableField()
		{
			yield return RunTest<ByteNullableField1, byte?>(232);
			yield return RunTest<ByteNullableField2, byte?>(194);
			yield return RunTest<ByteNullableField1, byte?>(null);
			yield return RunTest<ByteNullableField2, byte?>(null);
		}

		[UnityTest]
		public IEnumerator SaveByteNullableFields()
		{
			yield return RunTest<ByteNullableFields1, byte?>(194, 232);
			yield return RunTest<ByteNullableFields2, byte?>(232, 194);
			yield return RunTest<ByteNullableFields1, byte?>(null, 232);
			yield return RunTest<ByteNullableFields2, byte?>(232, null);
		}

		[UnityTest]
		public IEnumerator SaveByteNullableProperty()
		{
			yield return RunTest<ByteNullableProperty1, byte?>(232);
			yield return RunTest<ByteNullableProperty2, byte?>(194);
			yield return RunTest<ByteNullableProperty1, byte?>(null);
			yield return RunTest<ByteNullableProperty2, byte?>(null);
		}

		[UnityTest]
		public IEnumerator SaveByteNullableProperties()
		{
			yield return RunTest<ByteNullableProperties1, byte?>(194, 232);
			yield return RunTest<ByteNullableProperties2, byte?>(232, 194);
			yield return RunTest<ByteNullableProperties1, byte?>(null, 232);
			yield return RunTest<ByteNullableProperties2, byte?>(232, null);
		}

		[UnityTest]
		public IEnumerator SaveByteArrayField()
		{
			yield return RunTest<ByteArrayField1, byte[]>(new byte[] { 232, 194 });
			yield return RunTest<ByteArrayField2, byte[]>(new byte[] { 194, 232 });
		}

		[UnityTest]
		public IEnumerator SaveByteArrayFields()
		{
			yield return RunTest<ByteArrayFields1, byte[]>(new byte[] { 232, 194 }, new byte[] { 155, 254 });
			yield return RunTest<ByteArrayFields2, byte[]>(new byte[] { 194, 232 }, new byte[] { 254, 155 });
		}

		[UnityTest]
		public IEnumerator SaveByteArrayProperty()
		{
			yield return RunTest<ByteArrayProperty1, byte[]>(new byte[] { 232, 194 });
			yield return RunTest<ByteArrayProperty2, byte[]>(new byte[] { 194, 232 });
		}

		[UnityTest]
		public IEnumerator SaveByteArrayProperties()
		{
			yield return RunTest<ByteArrayProperties1, byte[]>(new byte[] { 232, 194 }, new byte[] { 155, 254 });
			yield return RunTest<ByteArrayProperties2, byte[]>(new byte[] { 194, 232 }, new byte[] { 254, 155 });
		}

		[UnityTest]
		public IEnumerator SaveByteArrayNullableField()
		{
			yield return RunTest<ByteArrayNullableField1, byte?[]>(new byte?[] { null, 194 });
			yield return RunTest<ByteArrayNullableField2, byte?[]>(new byte?[] { 194, null });
		}

		[UnityTest]
		public IEnumerator SaveByteArrayNullableFields()
		{
			yield return RunTest<ByteArrayNullableFields1, byte?[]>(new byte?[] { null, 194 }, new byte?[] { 155, null });
			yield return RunTest<ByteArrayNullableFields2, byte?[]>(new byte?[] { 194, null }, new byte?[] { null, 155 });
		}

		[UnityTest]
		public IEnumerator SaveByteArrayNullableProperty()
		{
			yield return RunTest<ByteArrayNullableProperty1, byte?[]>(new byte?[] { null, 194 });
			yield return RunTest<ByteArrayNullableProperty2, byte?[]>(new byte?[] { 194, null });
		}

		[UnityTest]
		public IEnumerator SaveByteArrayNullableProperties()
		{
			yield return RunTest<ByteArrayNullableProperties1, byte?[]>(new byte?[] { 232, null }, new byte?[] { null, 254 });
			yield return RunTest<ByteArrayNullableProperties2, byte?[]>(new byte?[] { null, 232 }, new byte?[] { 254, null });
		}

		[UnityTest]
		public IEnumerator SaveByteListField()
		{
			yield return RunTest<ByteListField1, List<byte>>(new List<byte> { 232, 194 });
			yield return RunTest<ByteListField2, List<byte>>(new List<byte> { 194, 232 });
		}

		[UnityTest]
		public IEnumerator SaveByteListFields()
		{
			yield return RunTest<ByteListFields1, List<byte>>(new List<byte> { 232, 194 }, new List<byte> { 155, 254 });
			yield return RunTest<ByteListFields2, List<byte>>(new List<byte> { 194, 232 }, new List<byte> { 254, 155 });
		}

		[UnityTest]
		public IEnumerator SaveByteListProperty()
		{
			yield return RunTest<ByteListProperty1, List<byte>>(new List<byte> { 232, 194 });
			yield return RunTest<ByteListProperty2, List<byte>>(new List<byte> { 194, 232 });
		}

		[UnityTest]
		public IEnumerator SaveByteListProperties()
		{
			yield return RunTest<ByteListProperties1, List<byte>>(new List<byte> { 232, 194 }, new List<byte> { 155, 254 });
			yield return RunTest<ByteListProperties2, List<byte>>(new List<byte> { 194, 232 }, new List<byte> { 254, 155 });
		}

		[UnityTest]
		public IEnumerator SaveByteListNullableField()
		{
			yield return RunTest<ByteListNullableField1, List<byte?>>(new List<byte?> { null, 194 });
			yield return RunTest<ByteListNullableField2, List<byte?>>(new List<byte?> { 194, null });
		}

		[UnityTest]
		public IEnumerator SaveByteListNullableFields()
		{
			yield return RunTest<ByteListNullableFields1, List<byte?>>(new List<byte?> { null, 194 }, new List<byte?> { 155, null });
			yield return RunTest<ByteListNullableFields2, List<byte?>>(new List<byte?> { 194, null }, new List<byte?> { null, 155 });
		}

		[UnityTest]
		public IEnumerator SaveByteListNullableProperty()
		{
			yield return RunTest<ByteListNullableProperty1, List<byte?>>(new List<byte?> { null, 194 });
			yield return RunTest<ByteListNullableProperty2, List<byte?>>(new List<byte?> { 194, null });
		}

		[UnityTest]
		public IEnumerator SaveByteListNullableProperties()
		{
			yield return RunTest<ByteListNullableProperties1, List<byte?>>(new List<byte?> { 232, null }, new List<byte?> { null, 254 });
			yield return RunTest<ByteListNullableProperties2, List<byte?>>(new List<byte?> { null, 232 }, new List<byte?> { 254, null });
		}
	}
}