using System;
using System.Collections;
using System.Collections.Generic;
using Hertzole.ALE.Tests.TestScripts;
using UnityEngine.TestTools;

namespace Hertzole.ALE.Tests
{
	public abstract class PrimitivesTest : SerializationTest
	{
		#region Byte
		[UnityTest]
		public IEnumerator SaveByteField()
		{
			yield return RunTest<ByteField1, byte>(69);
			yield return RunTest<ByteField2, byte>(42);
		}

		[UnityTest]
		public IEnumerator SaveByteFields()
		{
			yield return RunTest<ByteFields1, byte>(42, 69);
			yield return RunTest<ByteFields2, byte>(69, 42);
		}

		[UnityTest]
		public IEnumerator SaveByteProperty()
		{
			yield return RunTest<ByteProperty1, byte>(69);
			yield return RunTest<ByteProperty2, byte>(42);
		}

		[UnityTest]
		public IEnumerator SaveByteProperties()
		{
			yield return RunTest<ByteProperties1, byte>(42, 69);
			yield return RunTest<ByteProperties2, byte>(69, 42);
		}

		[UnityTest]
		public IEnumerator SaveByteNullableField()
		{
			yield return RunTest<ByteNullableField1, byte?>(69);
			yield return RunTest<ByteNullableField2, byte?>(42);
			yield return RunTest<ByteNullableField1, byte?>(null);
			yield return RunTest<ByteNullableField2, byte?>(null);
		}

		[UnityTest]
		public IEnumerator SaveByteNullableFields()
		{
			yield return RunTest<ByteNullableFields1, byte?>(42, 69);
			yield return RunTest<ByteNullableFields2, byte?>(69, 42);
			yield return RunTest<ByteNullableFields1, byte?>(null, 69);
			yield return RunTest<ByteNullableFields2, byte?>(69, null);
		}

		[UnityTest]
		public IEnumerator SaveByteNullableProperty()
		{
			yield return RunTest<ByteNullableProperty1, byte?>(69);
			yield return RunTest<ByteNullableProperty2, byte?>(42);
			yield return RunTest<ByteNullableProperty1, byte?>(null);
			yield return RunTest<ByteNullableProperty2, byte?>(null);
		}

		[UnityTest]
		public IEnumerator SaveByteNullableProperties()
		{
			yield return RunTest<ByteNullableProperties1, byte?>(null, 69);
			yield return RunTest<ByteNullableProperties2, byte?>(69, null);
		}

		// Works in binary but not JSON due to special treatment from MessagePack.
		// [UnityTest]
		// public IEnumerator SaveByteArrayField()
		// {
		// 	yield return RunTest<ByteArrayField1, byte[]>(new byte[] { 69, 42 });
		// 	yield return RunTest<ByteArrayField2, byte[]>(new byte[] { 42, 69 });
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveByteArrayFields()
		// {
		// 	yield return RunTest<ByteArrayFields1, byte[]>(new byte[] { 69, 42 }, new byte[] { 10, 20 });
		// 	yield return RunTest<ByteArrayFields2, byte[]>(new byte[] { 42, 69 }, new byte[] { 20, 10 });
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveByteArrayProperty()
		// {
		// 	yield return RunTest<ByteArrayProperty1, byte[]>(new byte[] { 69, 42 });
		// 	yield return RunTest<ByteArrayProperty2, byte[]>(new byte[] { 42, 69 });
		// }
		//
		// [UnityTest]
		// public IEnumerator SaveByteArrayProperties()
		// {
		// 	yield return RunTest<ByteArrayProperties1, byte[]>(new byte[] { 69, 42 }, new byte[] { 10, 20 });
		// 	yield return RunTest<ByteArrayProperties2, byte[]>(new byte[] { 42, 69 }, new byte[] { 20, 10 });
		// }

		[UnityTest]
		public IEnumerator SaveByteArrayNullableField()
		{
			yield return RunTest<ByteArrayNullableField1, byte?[]>(new byte?[] { null, 42 });
			yield return RunTest<ByteArrayNullableField2, byte?[]>(new byte?[] { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveByteArrayNullableFields()
		{
			yield return RunTest<ByteArrayNullableFields1, byte?[]>(new byte?[] { null, 42 }, new byte?[] { 10, null });
			yield return RunTest<ByteArrayNullableFields2, byte?[]>(new byte?[] { 42, null }, new byte?[] { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveByteArrayNullableProperty()
		{
			yield return RunTest<ByteArrayNullableProperty1, byte?[]>(new byte?[] { null, 42 });
			yield return RunTest<ByteArrayNullableProperty2, byte?[]>(new byte?[] { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveByteArrayNullableProperties()
		{
			yield return RunTest<ByteArrayNullableProperties1, byte?[]>(new byte?[] { 69, null }, new byte?[] { null, 20 });
			yield return RunTest<ByteArrayNullableProperties2, byte?[]>(new byte?[] { null, 69 }, new byte?[] { 20, null });
		}

		[UnityTest]
		public IEnumerator SaveByteListField()
		{
			yield return RunTest<ByteListField1, List<byte>>(new List<byte> { 69, 42 });
			yield return RunTest<ByteListField2, List<byte>>(new List<byte> { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveByteListFields()
		{
			yield return RunTest<ByteListFields1, List<byte>>(new List<byte> { 69, 42 }, new List<byte> { 10, 20 });
			yield return RunTest<ByteListFields2, List<byte>>(new List<byte> { 42, 69 }, new List<byte> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveByteListProperty()
		{
			yield return RunTest<ByteListProperty1, List<byte>>(new List<byte> { 69, 42 });
			yield return RunTest<ByteListProperty2, List<byte>>(new List<byte> { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveByteListProperties()
		{
			yield return RunTest<ByteListProperties1, List<byte>>(new List<byte> { 69, 42 }, new List<byte> { 10, 20 });
			yield return RunTest<ByteListProperties2, List<byte>>(new List<byte> { 42, 69 }, new List<byte> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveByteListNullableField()
		{
			yield return RunTest<ByteListNullableField1, List<byte?>>(new List<byte?> { null, 42 });
			yield return RunTest<ByteListNullableField2, List<byte?>>(new List<byte?> { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveByteListNullableFields()
		{
			yield return RunTest<ByteListNullableFields1, List<byte?>>(new List<byte?> { null, 42 }, new List<byte?> { 10, null });
			yield return RunTest<ByteListNullableFields2, List<byte?>>(new List<byte?> { 42, null }, new List<byte?> { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveByteListNullableProperty()
		{
			yield return RunTest<ByteListNullableProperty1, List<byte?>>(new List<byte?> { null, 42 });
			yield return RunTest<ByteListNullableProperty2, List<byte?>>(new List<byte?> { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveByteListNullableProperties()
		{
			yield return RunTest<ByteListNullableProperties1, List<byte?>>(new List<byte?> { 69, null }, new List<byte?> { null, 20 });
			yield return RunTest<ByteListNullableProperties2, List<byte?>>(new List<byte?> { null, 69 }, new List<byte?> { 20, null });
		}
		#endregion

		#region SByte
		[UnityTest]
		public IEnumerator SaveSByteField()
		{
			yield return RunTest<SByteField1, sbyte>(69);
			yield return RunTest<SByteField2, sbyte>(42);
		}

		[UnityTest]
		public IEnumerator SaveSByteFields()
		{
			yield return RunTest<SByteFields1, sbyte>(42, 69);
			yield return RunTest<SByteFields2, sbyte>(69, 42);
		}

		[UnityTest]
		public IEnumerator SaveSByteProperty()
		{
			yield return RunTest<SByteProperty1, sbyte>(69);
			yield return RunTest<SByteProperty2, sbyte>(42);
		}

		[UnityTest]
		public IEnumerator SaveSByteProperties()
		{
			yield return RunTest<SByteProperties1, sbyte>(42, 69);
			yield return RunTest<SByteProperties2, sbyte>(69, 42);
		}

		[UnityTest]
		public IEnumerator SaveSByteNullableField()
		{
			yield return RunTest<SByteNullableField1, sbyte?>(69);
			yield return RunTest<SByteNullableField2, sbyte?>(42);
			yield return RunTest<SByteNullableField1, sbyte?>(null);
			yield return RunTest<SByteNullableField2, sbyte?>(null);
		}

		[UnityTest]
		public IEnumerator SaveSByteNullableFields()
		{
			yield return RunTest<SByteNullableFields1, sbyte?>(42, 69);
			yield return RunTest<SByteNullableFields2, sbyte?>(69, 42);
			yield return RunTest<SByteNullableFields1, sbyte?>(null, 69);
			yield return RunTest<SByteNullableFields2, sbyte?>(69, null);
		}

		[UnityTest]
		public IEnumerator SaveSByteNullableProperty()
		{
			yield return RunTest<SByteNullableProperty1, sbyte?>(69);
			yield return RunTest<SByteNullableProperty2, sbyte?>(42);
			yield return RunTest<SByteNullableProperty1, sbyte?>(null);
			yield return RunTest<SByteNullableProperty2, sbyte?>(null);
		}

		[UnityTest]
		public IEnumerator SaveSByteNullableProperties()
		{
			yield return RunTest<SByteNullableProperties1, sbyte?>(null, 69);
			yield return RunTest<SByteNullableProperties2, sbyte?>(69, null);
		}

		[UnityTest]
		public IEnumerator SaveSByteArrayField()
		{
			yield return RunTest<SByteArrayField1, sbyte[]>(new sbyte[] { 69, 42 });
			yield return RunTest<SByteArrayField2, sbyte[]>(new sbyte[] { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveSByteArrayFields()
		{
			yield return RunTest<SByteArrayFields1, sbyte[]>(new sbyte[] { 69, 42 }, new sbyte[] { 10, 20 });
			yield return RunTest<SByteArrayFields2, sbyte[]>(new sbyte[] { 42, 69 }, new sbyte[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveSByteArrayProperty()
		{
			yield return RunTest<SByteArrayProperty1, sbyte[]>(new sbyte[] { 69, 42 });
			yield return RunTest<SByteArrayProperty2, sbyte[]>(new sbyte[] { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveSByteArrayProperties()
		{
			yield return RunTest<SByteArrayProperties1, sbyte[]>(new sbyte[] { 69, 42 }, new sbyte[] { 10, 20 });
			yield return RunTest<SByteArrayProperties2, sbyte[]>(new sbyte[] { 42, 69 }, new sbyte[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveSByteArrayNullableField()
		{
			yield return RunTest<SByteArrayNullableField1, sbyte?[]>(new sbyte?[] { null, 42 });
			yield return RunTest<SByteArrayNullableField2, sbyte?[]>(new sbyte?[] { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveSByteArrayNullableFields()
		{
			yield return RunTest<SByteArrayNullableFields1, sbyte?[]>(new sbyte?[] { null, 42 }, new sbyte?[] { 10, null });
			yield return RunTest<SByteArrayNullableFields2, sbyte?[]>(new sbyte?[] { 42, null }, new sbyte?[] { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveSByteArrayNullableProperty()
		{
			yield return RunTest<SByteArrayNullableProperty1, sbyte?[]>(new sbyte?[] { null, 42 });
			yield return RunTest<SByteArrayNullableProperty2, sbyte?[]>(new sbyte?[] { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveSByteArrayNullableProperties()
		{
			yield return RunTest<SByteArrayNullableProperties1, sbyte?[]>(new sbyte?[] { 69, null }, new sbyte?[] { null, 20 });
			yield return RunTest<SByteArrayNullableProperties2, sbyte?[]>(new sbyte?[] { null, 69 }, new sbyte?[] { 20, null });
		}

		[UnityTest]
		public IEnumerator SaveSByteListField()
		{
			yield return RunTest<SByteListField1, List<sbyte>>(new List<sbyte> { 69, 42 });
			yield return RunTest<SByteListField2, List<sbyte>>(new List<sbyte> { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveSByteListFields()
		{
			yield return RunTest<SByteListFields1, List<sbyte>>(new List<sbyte> { 69, 42 }, new List<sbyte> { 10, 20 });
			yield return RunTest<SByteListFields2, List<sbyte>>(new List<sbyte> { 42, 69 }, new List<sbyte> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveSByteListProperty()
		{
			yield return RunTest<SByteListProperty1, List<sbyte>>(new List<sbyte> { 69, 42 });
			yield return RunTest<SByteListProperty2, List<sbyte>>(new List<sbyte> { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveSByteListProperties()
		{
			yield return RunTest<SByteListProperties1, List<sbyte>>(new List<sbyte> { 69, 42 }, new List<sbyte> { 10, 20 });
			yield return RunTest<SByteListProperties2, List<sbyte>>(new List<sbyte> { 42, 69 }, new List<sbyte> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveSByteListNullableField()
		{
			yield return RunTest<SByteListNullableField1, List<sbyte?>>(new List<sbyte?> { null, 42 });
			yield return RunTest<SByteListNullableField2, List<sbyte?>>(new List<sbyte?> { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveSByteListNullableFields()
		{
			yield return RunTest<SByteListNullableFields1, List<sbyte?>>(new List<sbyte?> { null, 42 }, new List<sbyte?> { 10, null });
			yield return RunTest<SByteListNullableFields2, List<sbyte?>>(new List<sbyte?> { 42, null }, new List<sbyte?> { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveSByteListNullableProperty()
		{
			yield return RunTest<SByteListNullableProperty1, List<sbyte?>>(new List<sbyte?> { null, 42 });
			yield return RunTest<SByteListNullableProperty2, List<sbyte?>>(new List<sbyte?> { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveSByteListNullableProperties()
		{
			yield return RunTest<SByteListNullableProperties1, List<sbyte?>>(new List<sbyte?> { 69, null }, new List<sbyte?> { null, 20 });
			yield return RunTest<SByteListNullableProperties2, List<sbyte?>>(new List<sbyte?> { null, 69 }, new List<sbyte?> { 20, null });
		}
		#endregion

		#region Short
		[UnityTest]
		public IEnumerator SaveShortField()
		{
			yield return RunTest<ShortField1, short>(69);
			yield return RunTest<ShortField2, short>(42);
		}

		[UnityTest]
		public IEnumerator SaveShortFields()
		{
			yield return RunTest<ShortFields1, short>(42, 69);
			yield return RunTest<ShortFields2, short>(69, 42);
		}

		[UnityTest]
		public IEnumerator SaveShortProperty()
		{
			yield return RunTest<ShortProperty1, short>(69);
			yield return RunTest<ShortProperty2, short>(42);
		}

		[UnityTest]
		public IEnumerator SaveShortProperties()
		{
			yield return RunTest<ShortProperties1, short>(42, 69);
			yield return RunTest<ShortProperties2, short>(69, 42);
		}

		[UnityTest]
		public IEnumerator SaveShortNullableField()
		{
			yield return RunTest<ShortNullableField1, short?>(69);
			yield return RunTest<ShortNullableField2, short?>(42);
			yield return RunTest<ShortNullableField1, short?>(null);
			yield return RunTest<ShortNullableField2, short?>(null);
		}

		[UnityTest]
		public IEnumerator SaveShortNullableFields()
		{
			yield return RunTest<ShortNullableFields1, short?>(42, 69);
			yield return RunTest<ShortNullableFields2, short?>(69, 42);
			yield return RunTest<ShortNullableFields1, short?>(null, 69);
			yield return RunTest<ShortNullableFields2, short?>(69, null);
		}

		[UnityTest]
		public IEnumerator SaveShortNullableProperty()
		{
			yield return RunTest<ShortNullableProperty1, short?>(69);
			yield return RunTest<ShortNullableProperty2, short?>(42);
			yield return RunTest<ShortNullableProperty1, short?>(null);
			yield return RunTest<ShortNullableProperty2, short?>(null);
		}

		[UnityTest]
		public IEnumerator SaveShortNullableProperties()
		{
			yield return RunTest<ShortNullableProperties1, short?>(null, 69);
			yield return RunTest<ShortNullableProperties2, short?>(69, null);
		}

		[UnityTest]
		public IEnumerator SaveShortArrayField()
		{
			yield return RunTest<ShortArrayField1, short[]>(new short[] { 69, 42 });
			yield return RunTest<ShortArrayField2, short[]>(new short[] { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveShortArrayFields()
		{
			yield return RunTest<ShortArrayFields1, short[]>(new short[] { 69, 42 }, new short[] { 10, 20 });
			yield return RunTest<ShortArrayFields2, short[]>(new short[] { 42, 69 }, new short[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveShortArrayProperty()
		{
			yield return RunTest<ShortArrayProperty1, short[]>(new short[] { 69, 42 });
			yield return RunTest<ShortArrayProperty2, short[]>(new short[] { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveShortArrayProperties()
		{
			yield return RunTest<ShortArrayProperties1, short[]>(new short[] { 69, 42 }, new short[] { 10, 20 });
			yield return RunTest<ShortArrayProperties2, short[]>(new short[] { 42, 69 }, new short[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveShortArrayNullableField()
		{
			yield return RunTest<ShortArrayNullableField1, short?[]>(new short?[] { null, 42 });
			yield return RunTest<ShortArrayNullableField2, short?[]>(new short?[] { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveShortArrayNullableFields()
		{
			yield return RunTest<ShortArrayNullableFields1, short?[]>(new short?[] { null, 42 }, new short?[] { 10, null });
			yield return RunTest<ShortArrayNullableFields2, short?[]>(new short?[] { 42, null }, new short?[] { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveShortArrayNullableProperty()
		{
			yield return RunTest<ShortArrayNullableProperty1, short?[]>(new short?[] { null, 42 });
			yield return RunTest<ShortArrayNullableProperty2, short?[]>(new short?[] { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveShortArrayNullableProperties()
		{
			yield return RunTest<ShortArrayNullableProperties1, short?[]>(new short?[] { 69, null }, new short?[] { null, 20 });
			yield return RunTest<ShortArrayNullableProperties2, short?[]>(new short?[] { null, 69 }, new short?[] { 20, null });
		}

		[UnityTest]
		public IEnumerator SaveShortListField()
		{
			yield return RunTest<ShortListField1, List<short>>(new List<short> { 69, 42 });
			yield return RunTest<ShortListField2, List<short>>(new List<short> { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveShortListFields()
		{
			yield return RunTest<ShortListFields1, List<short>>(new List<short> { 69, 42 }, new List<short> { 10, 20 });
			yield return RunTest<ShortListFields2, List<short>>(new List<short> { 42, 69 }, new List<short> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveShortListProperty()
		{
			yield return RunTest<ShortListProperty1, List<short>>(new List<short> { 69, 42 });
			yield return RunTest<ShortListProperty2, List<short>>(new List<short> { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveShortListProperties()
		{
			yield return RunTest<ShortListProperties1, List<short>>(new List<short> { 69, 42 }, new List<short> { 10, 20 });
			yield return RunTest<ShortListProperties2, List<short>>(new List<short> { 42, 69 }, new List<short> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveShortListNullableField()
		{
			yield return RunTest<ShortListNullableField1, List<short?>>(new List<short?> { null, 42 });
			yield return RunTest<ShortListNullableField2, List<short?>>(new List<short?> { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveShortListNullableFields()
		{
			yield return RunTest<ShortListNullableFields1, List<short?>>(new List<short?> { null, 42 }, new List<short?> { 10, null });
			yield return RunTest<ShortListNullableFields2, List<short?>>(new List<short?> { 42, null }, new List<short?> { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveShortListNullableProperty()
		{
			yield return RunTest<ShortListNullableProperty1, List<short?>>(new List<short?> { null, 42 });
			yield return RunTest<ShortListNullableProperty2, List<short?>>(new List<short?> { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveShortListNullableProperties()
		{
			yield return RunTest<ShortListNullableProperties1, List<short?>>(new List<short?> { 69, null }, new List<short?> { null, 20 });
			yield return RunTest<ShortListNullableProperties2, List<short?>>(new List<short?> { null, 69 }, new List<short?> { 20, null });
		}
		#endregion

		#region UShort
		[UnityTest]
		public IEnumerator SaveUShortField()
		{
			yield return RunTest<UShortField1, ushort>(69);
			yield return RunTest<UShortField2, ushort>(42);
		}

		[UnityTest]
		public IEnumerator SaveUShortFields()
		{
			yield return RunTest<UShortFields1, ushort>(42, 69);
			yield return RunTest<UShortFields2, ushort>(69, 42);
		}

		[UnityTest]
		public IEnumerator SaveUShortProperty()
		{
			yield return RunTest<UShortProperty1, ushort>(69);
			yield return RunTest<UShortProperty2, ushort>(42);
		}

		[UnityTest]
		public IEnumerator SaveUShortProperties()
		{
			yield return RunTest<UShortProperties1, ushort>(42, 69);
			yield return RunTest<UShortProperties2, ushort>(69, 42);
		}

		[UnityTest]
		public IEnumerator SaveUShortNullableField()
		{
			yield return RunTest<UShortNullableField1, ushort?>(69);
			yield return RunTest<UShortNullableField2, ushort?>(42);
			yield return RunTest<UShortNullableField1, ushort?>(null);
			yield return RunTest<UShortNullableField2, ushort?>(null);
		}

		[UnityTest]
		public IEnumerator SaveUShortNullableFields()
		{
			yield return RunTest<UShortNullableFields1, ushort?>(42, 69);
			yield return RunTest<UShortNullableFields2, ushort?>(69, 42);
			yield return RunTest<UShortNullableFields1, ushort?>(null, 69);
			yield return RunTest<UShortNullableFields2, ushort?>(69, null);
		}

		[UnityTest]
		public IEnumerator SaveUShortNullableProperty()
		{
			yield return RunTest<UShortNullableProperty1, ushort?>(69);
			yield return RunTest<UShortNullableProperty2, ushort?>(42);
			yield return RunTest<UShortNullableProperty1, ushort?>(null);
			yield return RunTest<UShortNullableProperty2, ushort?>(null);
		}

		[UnityTest]
		public IEnumerator SaveUShortNullableProperties()
		{
			yield return RunTest<UShortNullableProperties1, ushort?>(null, 69);
			yield return RunTest<UShortNullableProperties2, ushort?>(69, null);
		}

		[UnityTest]
		public IEnumerator SaveUShortArrayField()
		{
			yield return RunTest<UShortArrayField1, ushort[]>(new ushort[] { 69, 42 });
			yield return RunTest<UShortArrayField2, ushort[]>(new ushort[] { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveUShortArrayFields()
		{
			yield return RunTest<UShortArrayFields1, ushort[]>(new ushort[] { 69, 42 }, new ushort[] { 10, 20 });
			yield return RunTest<UShortArrayFields2, ushort[]>(new ushort[] { 42, 69 }, new ushort[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveUShortArrayProperty()
		{
			yield return RunTest<UShortArrayProperty1, ushort[]>(new ushort[] { 69, 42 });
			yield return RunTest<UShortArrayProperty2, ushort[]>(new ushort[] { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveUShortArrayProperties()
		{
			yield return RunTest<UShortArrayProperties1, ushort[]>(new ushort[] { 69, 42 }, new ushort[] { 10, 20 });
			yield return RunTest<UShortArrayProperties2, ushort[]>(new ushort[] { 42, 69 }, new ushort[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveUShortArrayNullableField()
		{
			yield return RunTest<UShortArrayNullableField1, ushort?[]>(new ushort?[] { null, 42 });
			yield return RunTest<UShortArrayNullableField2, ushort?[]>(new ushort?[] { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveUShortArrayNullableFields()
		{
			yield return RunTest<UShortArrayNullableFields1, ushort?[]>(new ushort?[] { null, 42 }, new ushort?[] { 10, null });
			yield return RunTest<UShortArrayNullableFields2, ushort?[]>(new ushort?[] { 42, null }, new ushort?[] { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveUShortArrayNullableProperty()
		{
			yield return RunTest<UShortArrayNullableProperty1, ushort?[]>(new ushort?[] { null, 42 });
			yield return RunTest<UShortArrayNullableProperty2, ushort?[]>(new ushort?[] { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveUShortArrayNullableProperties()
		{
			yield return RunTest<UShortArrayNullableProperties1, ushort?[]>(new ushort?[] { 69, null }, new ushort?[] { null, 20 });
			yield return RunTest<UShortArrayNullableProperties2, ushort?[]>(new ushort?[] { null, 69 }, new ushort?[] { 20, null });
		}

		[UnityTest]
		public IEnumerator SaveUShortListField()
		{
			yield return RunTest<UShortListField1, List<ushort>>(new List<ushort> { 69, 42 });
			yield return RunTest<UShortListField2, List<ushort>>(new List<ushort> { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveUShortListFields()
		{
			yield return RunTest<UShortListFields1, List<ushort>>(new List<ushort> { 69, 42 }, new List<ushort> { 10, 20 });
			yield return RunTest<UShortListFields2, List<ushort>>(new List<ushort> { 42, 69 }, new List<ushort> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveUShortListProperty()
		{
			yield return RunTest<UShortListProperty1, List<ushort>>(new List<ushort> { 69, 42 });
			yield return RunTest<UShortListProperty2, List<ushort>>(new List<ushort> { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveUShortListProperties()
		{
			yield return RunTest<UShortListProperties1, List<ushort>>(new List<ushort> { 69, 42 }, new List<ushort> { 10, 20 });
			yield return RunTest<UShortListProperties2, List<ushort>>(new List<ushort> { 42, 69 }, new List<ushort> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveUShortListNullableField()
		{
			yield return RunTest<UShortListNullableField1, List<ushort?>>(new List<ushort?> { null, 42 });
			yield return RunTest<UShortListNullableField2, List<ushort?>>(new List<ushort?> { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveUShortListNullableFields()
		{
			yield return RunTest<UShortListNullableFields1, List<ushort?>>(new List<ushort?> { null, 42 }, new List<ushort?> { 10, null });
			yield return RunTest<UShortListNullableFields2, List<ushort?>>(new List<ushort?> { 42, null }, new List<ushort?> { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveUShortListNullableProperty()
		{
			yield return RunTest<UShortListNullableProperty1, List<ushort?>>(new List<ushort?> { null, 42 });
			yield return RunTest<UShortListNullableProperty2, List<ushort?>>(new List<ushort?> { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveUShortListNullableProperties()
		{
			yield return RunTest<UShortListNullableProperties1, List<ushort?>>(new List<ushort?> { 69, null }, new List<ushort?> { null, 20 });
			yield return RunTest<UShortListNullableProperties2, List<ushort?>>(new List<ushort?> { null, 69 }, new List<ushort?> { 20, null });
		}
		#endregion

		#region Int
		[UnityTest]
		public IEnumerator SaveIntField()
		{
			yield return RunTest<IntField1, int>(69);
			yield return RunTest<IntField2, int>(42);
		}

		[UnityTest]
		public IEnumerator SaveIntFields()
		{
			yield return RunTest<IntFields1, int>(42, 69);
			yield return RunTest<IntFields2, int>(69, 42);
		}

		[UnityTest]
		public IEnumerator SaveIntProperty()
		{
			yield return RunTest<IntProperty1, int>(69);
			yield return RunTest<IntProperty2, int>(42);
		}

		[UnityTest]
		public IEnumerator SaveIntProperties()
		{
			yield return RunTest<IntProperties1, int>(42, 69);
			yield return RunTest<IntProperties2, int>(69, 42);
		}

		[UnityTest]
		public IEnumerator SaveIntNullableField()
		{
			yield return RunTest<IntNullableField1, int?>(69);
			yield return RunTest<IntNullableField2, int?>(42);
			yield return RunTest<IntNullableField1, int?>(null);
			yield return RunTest<IntNullableField2, int?>(null);
		}

		[UnityTest]
		public IEnumerator SaveIntNullableFields()
		{
			yield return RunTest<IntNullableFields1, int?>(42, 69);
			yield return RunTest<IntNullableFields2, int?>(69, 42);
			yield return RunTest<IntNullableFields1, int?>(null, 69);
			yield return RunTest<IntNullableFields2, int?>(69, null);
		}

		[UnityTest]
		public IEnumerator SaveIntNullableProperty()
		{
			yield return RunTest<IntNullableProperty1, int?>(69);
			yield return RunTest<IntNullableProperty2, int?>(42);
			yield return RunTest<IntNullableProperty1, int?>(null);
			yield return RunTest<IntNullableProperty2, int?>(null);
		}

		[UnityTest]
		public IEnumerator SaveIntNullableProperties()
		{
			yield return RunTest<IntNullableProperties1, int?>(null, 69);
			yield return RunTest<IntNullableProperties2, int?>(69, null);
		}

		[UnityTest]
		public IEnumerator SaveIntArrayField()
		{
			yield return RunTest<IntArrayField1, int[]>(new[] { 69, 42 });
			yield return RunTest<IntArrayField2, int[]>(new[] { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveIntArrayFields()
		{
			yield return RunTest<IntArrayFields1, int[]>(new[] { 69, 42 }, new[] { 10, 20 });
			yield return RunTest<IntArrayFields2, int[]>(new[] { 42, 69 }, new[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveIntArrayProperty()
		{
			yield return RunTest<IntArrayProperty1, int[]>(new[] { 69, 42 });
			yield return RunTest<IntArrayProperty2, int[]>(new[] { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveIntArrayProperties()
		{
			yield return RunTest<IntArrayProperties1, int[]>(new[] { 69, 42 }, new[] { 10, 20 });
			yield return RunTest<IntArrayProperties2, int[]>(new[] { 42, 69 }, new[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveIntArrayNullableField()
		{
			yield return RunTest<IntArrayNullableField1, int?[]>(new int?[] { null, 42 });
			yield return RunTest<IntArrayNullableField2, int?[]>(new int?[] { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveIntArrayNullableFields()
		{
			yield return RunTest<IntArrayNullableFields1, int?[]>(new int?[] { null, 42 }, new int?[] { 10, null });
			yield return RunTest<IntArrayNullableFields2, int?[]>(new int?[] { 42, null }, new int?[] { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveIntArrayNullableProperty()
		{
			yield return RunTest<IntArrayNullableProperty1, int?[]>(new int?[] { null, 42 });
			yield return RunTest<IntArrayNullableProperty2, int?[]>(new int?[] { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveIntArrayNullableProperties()
		{
			yield return RunTest<IntArrayNullableProperties1, int?[]>(new int?[] { 69, null }, new int?[] { null, 20 });
			yield return RunTest<IntArrayNullableProperties2, int?[]>(new int?[] { null, 69 }, new int?[] { 20, null });
		}

		[UnityTest]
		public IEnumerator SaveIntListField()
		{
			yield return RunTest<IntListField1, List<int>>(new List<int> { 69, 42 });
			yield return RunTest<IntListField2, List<int>>(new List<int> { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveIntListFields()
		{
			yield return RunTest<IntListFields1, List<int>>(new List<int> { 69, 42 }, new List<int> { 10, 20 });
			yield return RunTest<IntListFields2, List<int>>(new List<int> { 42, 69 }, new List<int> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveIntListProperty()
		{
			yield return RunTest<IntListProperty1, List<int>>(new List<int> { 69, 42 });
			yield return RunTest<IntListProperty2, List<int>>(new List<int> { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveIntListProperties()
		{
			yield return RunTest<IntListProperties1, List<int>>(new List<int> { 69, 42 }, new List<int> { 10, 20 });
			yield return RunTest<IntListProperties2, List<int>>(new List<int> { 42, 69 }, new List<int> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveIntListNullableField()
		{
			yield return RunTest<IntListNullableField1, List<int?>>(new List<int?> { null, 42 });
			yield return RunTest<IntListNullableField2, List<int?>>(new List<int?> { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveIntListNullableFields()
		{
			yield return RunTest<IntListNullableFields1, List<int?>>(new List<int?> { null, 42 }, new List<int?> { 10, null });
			yield return RunTest<IntListNullableFields2, List<int?>>(new List<int?> { 42, null }, new List<int?> { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveIntListNullableProperty()
		{
			yield return RunTest<IntListNullableProperty1, List<int?>>(new List<int?> { null, 42 });
			yield return RunTest<IntListNullableProperty2, List<int?>>(new List<int?> { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveIntListNullableProperties()
		{
			yield return RunTest<IntListNullableProperties1, List<int?>>(new List<int?> { 69, null }, new List<int?> { null, 20 });
			yield return RunTest<IntListNullableProperties2, List<int?>>(new List<int?> { null, 69 }, new List<int?> { 20, null });
		}
		#endregion

		#region UInt
		[UnityTest]
		public IEnumerator SaveUIntField()
		{
			yield return RunTest<UIntField1, uint>(69);
			yield return RunTest<UIntField2, uint>(42);
		}

		[UnityTest]
		public IEnumerator SaveUIntFields()
		{
			yield return RunTest<UIntFields1, uint>(42, 69);
			yield return RunTest<UIntFields2, uint>(69, 42);
		}

		[UnityTest]
		public IEnumerator SaveUIntProperty()
		{
			yield return RunTest<UIntProperty1, uint>(69);
			yield return RunTest<UIntProperty2, uint>(42);
		}

		[UnityTest]
		public IEnumerator SaveUIntProperties()
		{
			yield return RunTest<UIntProperties1, uint>(42, 69);
			yield return RunTest<UIntProperties2, uint>(69, 42);
		}

		[UnityTest]
		public IEnumerator SaveUIntNullableField()
		{
			yield return RunTest<UIntNullableField1, uint?>(69);
			yield return RunTest<UIntNullableField2, uint?>(42);
			yield return RunTest<UIntNullableField1, uint?>(null);
			yield return RunTest<UIntNullableField2, uint?>(null);
		}

		[UnityTest]
		public IEnumerator SaveUIntNullableFields()
		{
			yield return RunTest<UIntNullableFields1, uint?>(42, 69);
			yield return RunTest<UIntNullableFields2, uint?>(69, 42);
			yield return RunTest<UIntNullableFields1, uint?>(null, 69);
			yield return RunTest<UIntNullableFields2, uint?>(69, null);
		}

		[UnityTest]
		public IEnumerator SaveUIntNullableProperty()
		{
			yield return RunTest<UIntNullableProperty1, uint?>(69);
			yield return RunTest<UIntNullableProperty2, uint?>(42);
			yield return RunTest<UIntNullableProperty1, uint?>(null);
			yield return RunTest<UIntNullableProperty2, uint?>(null);
		}

		[UnityTest]
		public IEnumerator SaveUIntNullableProperties()
		{
			yield return RunTest<UIntNullableProperties1, uint?>(null, 69);
			yield return RunTest<UIntNullableProperties2, uint?>(69, null);
		}

		[UnityTest]
		public IEnumerator SaveUIntArrayField()
		{
			yield return RunTest<UIntArrayField1, uint[]>(new uint[] { 69, 42 });
			yield return RunTest<UIntArrayField2, uint[]>(new uint[] { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveUIntArrayFields()
		{
			yield return RunTest<UIntArrayFields1, uint[]>(new uint[] { 69, 42 }, new uint[] { 10, 20 });
			yield return RunTest<UIntArrayFields2, uint[]>(new uint[] { 42, 69 }, new uint[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveUIntArrayProperty()
		{
			yield return RunTest<UIntArrayProperty1, uint[]>(new uint[] { 69, 42 });
			yield return RunTest<UIntArrayProperty2, uint[]>(new uint[] { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveUIntArrayProperties()
		{
			yield return RunTest<UIntArrayProperties1, uint[]>(new uint[] { 69, 42 }, new uint[] { 10, 20 });
			yield return RunTest<UIntArrayProperties2, uint[]>(new uint[] { 42, 69 }, new uint[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveUIntArrayNullableField()
		{
			yield return RunTest<UIntArrayNullableField1, uint?[]>(new uint?[] { null, 42 });
			yield return RunTest<UIntArrayNullableField2, uint?[]>(new uint?[] { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveUIntArrayNullableFields()
		{
			yield return RunTest<UIntArrayNullableFields1, uint?[]>(new uint?[] { null, 42 }, new uint?[] { 10, null });
			yield return RunTest<UIntArrayNullableFields2, uint?[]>(new uint?[] { 42, null }, new uint?[] { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveUIntArrayNullableProperty()
		{
			yield return RunTest<UIntArrayNullableProperty1, uint?[]>(new uint?[] { null, 42 });
			yield return RunTest<UIntArrayNullableProperty2, uint?[]>(new uint?[] { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveUIntArrayNullableProperties()
		{
			yield return RunTest<UIntArrayNullableProperties1, uint?[]>(new uint?[] { 69, null }, new uint?[] { null, 20 });
			yield return RunTest<UIntArrayNullableProperties2, uint?[]>(new uint?[] { null, 69 }, new uint?[] { 20, null });
		}

		[UnityTest]
		public IEnumerator SaveUIntListField()
		{
			yield return RunTest<UIntListField1, List<uint>>(new List<uint> { 69, 42 });
			yield return RunTest<UIntListField2, List<uint>>(new List<uint> { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveUIntListFields()
		{
			yield return RunTest<UIntListFields1, List<uint>>(new List<uint> { 69, 42 }, new List<uint> { 10, 20 });
			yield return RunTest<UIntListFields2, List<uint>>(new List<uint> { 42, 69 }, new List<uint> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveUIntListProperty()
		{
			yield return RunTest<UIntListProperty1, List<uint>>(new List<uint> { 69, 42 });
			yield return RunTest<UIntListProperty2, List<uint>>(new List<uint> { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveUIntListProperties()
		{
			yield return RunTest<UIntListProperties1, List<uint>>(new List<uint> { 69, 42 }, new List<uint> { 10, 20 });
			yield return RunTest<UIntListProperties2, List<uint>>(new List<uint> { 42, 69 }, new List<uint> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveUIntListNullableField()
		{
			yield return RunTest<UIntListNullableField1, List<uint?>>(new List<uint?> { null, 42 });
			yield return RunTest<UIntListNullableField2, List<uint?>>(new List<uint?> { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveUIntListNullableFields()
		{
			yield return RunTest<UIntListNullableFields1, List<uint?>>(new List<uint?> { null, 42 }, new List<uint?> { 10, null });
			yield return RunTest<UIntListNullableFields2, List<uint?>>(new List<uint?> { 42, null }, new List<uint?> { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveUIntListNullableProperty()
		{
			yield return RunTest<UIntListNullableProperty1, List<uint?>>(new List<uint?> { null, 42 });
			yield return RunTest<UIntListNullableProperty2, List<uint?>>(new List<uint?> { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveUIntListNullableProperties()
		{
			yield return RunTest<UIntListNullableProperties1, List<uint?>>(new List<uint?> { 69, null }, new List<uint?> { null, 20 });
			yield return RunTest<UIntListNullableProperties2, List<uint?>>(new List<uint?> { null, 69 }, new List<uint?> { 20, null });
		}
		#endregion

		#region Long
		[UnityTest]
		public IEnumerator SaveLongField()
		{
			yield return RunTest<LongField1, long>(69);
			yield return RunTest<LongField2, long>(42);
		}

		[UnityTest]
		public IEnumerator SaveLongFields()
		{
			yield return RunTest<LongFields1, long>(42, 69);
			yield return RunTest<LongFields2, long>(69, 42);
		}

		[UnityTest]
		public IEnumerator SaveLongProperty()
		{
			yield return RunTest<LongProperty1, long>(69);
			yield return RunTest<LongProperty2, long>(42);
		}

		[UnityTest]
		public IEnumerator SaveLongProperties()
		{
			yield return RunTest<LongProperties1, long>(42, 69);
			yield return RunTest<LongProperties2, long>(69, 42);
		}

		[UnityTest]
		public IEnumerator SaveLongNullableField()
		{
			yield return RunTest<LongNullableField1, long?>(69);
			yield return RunTest<LongNullableField2, long?>(42);
			yield return RunTest<LongNullableField1, long?>(null);
			yield return RunTest<LongNullableField2, long?>(null);
		}

		[UnityTest]
		public IEnumerator SaveLongNullableFields()
		{
			yield return RunTest<LongNullableFields1, long?>(42, 69);
			yield return RunTest<LongNullableFields2, long?>(69, 42);
			yield return RunTest<LongNullableFields1, long?>(null, 69);
			yield return RunTest<LongNullableFields2, long?>(69, null);
		}

		[UnityTest]
		public IEnumerator SaveLongNullableProperty()
		{
			yield return RunTest<LongNullableProperty1, long?>(69);
			yield return RunTest<LongNullableProperty2, long?>(42);
			yield return RunTest<LongNullableProperty1, long?>(null);
			yield return RunTest<LongNullableProperty2, long?>(null);
		}

		[UnityTest]
		public IEnumerator SaveLongNullableProperties()
		{
			yield return RunTest<LongNullableProperties1, long?>(null, 69);
			yield return RunTest<LongNullableProperties2, long?>(69, null);
		}

		[UnityTest]
		public IEnumerator SaveLongArrayField()
		{
			yield return RunTest<LongArrayField1, long[]>(new long[] { 69, 42 });
			yield return RunTest<LongArrayField2, long[]>(new long[] { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveLongArrayFields()
		{
			yield return RunTest<LongArrayFields1, long[]>(new long[] { 69, 42 }, new long[] { 10, 20 });
			yield return RunTest<LongArrayFields2, long[]>(new long[] { 42, 69 }, new long[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveLongArrayProperty()
		{
			yield return RunTest<LongArrayProperty1, long[]>(new long[] { 69, 42 });
			yield return RunTest<LongArrayProperty2, long[]>(new long[] { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveLongArrayProperties()
		{
			yield return RunTest<LongArrayProperties1, long[]>(new long[] { 69, 42 }, new long[] { 10, 20 });
			yield return RunTest<LongArrayProperties2, long[]>(new long[] { 42, 69 }, new long[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveLongArrayNullableField()
		{
			yield return RunTest<LongArrayNullableField1, long?[]>(new long?[] { null, 42 });
			yield return RunTest<LongArrayNullableField2, long?[]>(new long?[] { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveLongArrayNullableFields()
		{
			yield return RunTest<LongArrayNullableFields1, long?[]>(new long?[] { null, 42 }, new long?[] { 10, null });
			yield return RunTest<LongArrayNullableFields2, long?[]>(new long?[] { 42, null }, new long?[] { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveLongArrayNullableProperty()
		{
			yield return RunTest<LongArrayNullableProperty1, long?[]>(new long?[] { null, 42 });
			yield return RunTest<LongArrayNullableProperty2, long?[]>(new long?[] { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveLongArrayNullableProperties()
		{
			yield return RunTest<LongArrayNullableProperties1, long?[]>(new long?[] { 69, null }, new long?[] { null, 20 });
			yield return RunTest<LongArrayNullableProperties2, long?[]>(new long?[] { null, 69 }, new long?[] { 20, null });
		}

		[UnityTest]
		public IEnumerator SaveLongListField()
		{
			yield return RunTest<LongListField1, List<long>>(new List<long> { 69, 42 });
			yield return RunTest<LongListField2, List<long>>(new List<long> { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveLongListFields()
		{
			yield return RunTest<LongListFields1, List<long>>(new List<long> { 69, 42 }, new List<long> { 10, 20 });
			yield return RunTest<LongListFields2, List<long>>(new List<long> { 42, 69 }, new List<long> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveLongListProperty()
		{
			yield return RunTest<LongListProperty1, List<long>>(new List<long> { 69, 42 });
			yield return RunTest<LongListProperty2, List<long>>(new List<long> { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveLongListProperties()
		{
			yield return RunTest<LongListProperties1, List<long>>(new List<long> { 69, 42 }, new List<long> { 10, 20 });
			yield return RunTest<LongListProperties2, List<long>>(new List<long> { 42, 69 }, new List<long> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveLongListNullableField()
		{
			yield return RunTest<LongListNullableField1, List<long?>>(new List<long?> { null, 42 });
			yield return RunTest<LongListNullableField2, List<long?>>(new List<long?> { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveLongListNullableFields()
		{
			yield return RunTest<LongListNullableFields1, List<long?>>(new List<long?> { null, 42 }, new List<long?> { 10, null });
			yield return RunTest<LongListNullableFields2, List<long?>>(new List<long?> { 42, null }, new List<long?> { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveLongListNullableProperty()
		{
			yield return RunTest<LongListNullableProperty1, List<long?>>(new List<long?> { null, 42 });
			yield return RunTest<LongListNullableProperty2, List<long?>>(new List<long?> { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveLongListNullableProperties()
		{
			yield return RunTest<LongListNullableProperties1, List<long?>>(new List<long?> { 69, null }, new List<long?> { null, 20 });
			yield return RunTest<LongListNullableProperties2, List<long?>>(new List<long?> { null, 69 }, new List<long?> { 20, null });
		}
		#endregion

		#region ULong
		[UnityTest]
		public IEnumerator SaveULongField()
		{
			yield return RunTest<ULongField1, ulong>(69);
			yield return RunTest<ULongField2, ulong>(42);
		}

		[UnityTest]
		public IEnumerator SaveULongFields()
		{
			yield return RunTest<ULongFields1, ulong>(42, 69);
			yield return RunTest<ULongFields2, ulong>(69, 42);
		}

		[UnityTest]
		public IEnumerator SaveULongProperty()
		{
			yield return RunTest<ULongProperty1, ulong>(69);
			yield return RunTest<ULongProperty2, ulong>(42);
		}

		[UnityTest]
		public IEnumerator SaveULongProperties()
		{
			yield return RunTest<ULongProperties1, ulong>(42, 69);
			yield return RunTest<ULongProperties2, ulong>(69, 42);
		}

		[UnityTest]
		public IEnumerator SaveULongNullableField()
		{
			yield return RunTest<ULongNullableField1, ulong?>(69);
			yield return RunTest<ULongNullableField2, ulong?>(42);
			yield return RunTest<ULongNullableField1, ulong?>(null);
			yield return RunTest<ULongNullableField2, ulong?>(null);
		}

		[UnityTest]
		public IEnumerator SaveULongNullableFields()
		{
			yield return RunTest<ULongNullableFields1, ulong?>(42, 69);
			yield return RunTest<ULongNullableFields2, ulong?>(69, 42);
			yield return RunTest<ULongNullableFields1, ulong?>(null, 69);
			yield return RunTest<ULongNullableFields2, ulong?>(69, null);
		}

		[UnityTest]
		public IEnumerator SaveULongNullableProperty()
		{
			yield return RunTest<ULongNullableProperty1, ulong?>(69);
			yield return RunTest<ULongNullableProperty2, ulong?>(42);
			yield return RunTest<ULongNullableProperty1, ulong?>(null);
			yield return RunTest<ULongNullableProperty2, ulong?>(null);
		}

		[UnityTest]
		public IEnumerator SaveULongNullableProperties()
		{
			yield return RunTest<ULongNullableProperties1, ulong?>(null, 69);
			yield return RunTest<ULongNullableProperties2, ulong?>(69, null);
		}

		[UnityTest]
		public IEnumerator SaveULongArrayField()
		{
			yield return RunTest<ULongArrayField1, ulong[]>(new ulong[] { 69, 42 });
			yield return RunTest<ULongArrayField2, ulong[]>(new ulong[] { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveULongArrayFields()
		{
			yield return RunTest<ULongArrayFields1, ulong[]>(new ulong[] { 69, 42 }, new ulong[] { 10, 20 });
			yield return RunTest<ULongArrayFields2, ulong[]>(new ulong[] { 42, 69 }, new ulong[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveULongArrayProperty()
		{
			yield return RunTest<ULongArrayProperty1, ulong[]>(new ulong[] { 69, 42 });
			yield return RunTest<ULongArrayProperty2, ulong[]>(new ulong[] { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveULongArrayProperties()
		{
			yield return RunTest<ULongArrayProperties1, ulong[]>(new ulong[] { 69, 42 }, new ulong[] { 10, 20 });
			yield return RunTest<ULongArrayProperties2, ulong[]>(new ulong[] { 42, 69 }, new ulong[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveULongArrayNullableField()
		{
			yield return RunTest<ULongArrayNullableField1, ulong?[]>(new ulong?[] { null, 42 });
			yield return RunTest<ULongArrayNullableField2, ulong?[]>(new ulong?[] { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveULongArrayNullableFields()
		{
			yield return RunTest<ULongArrayNullableFields1, ulong?[]>(new ulong?[] { null, 42 }, new ulong?[] { 10, null });
			yield return RunTest<ULongArrayNullableFields2, ulong?[]>(new ulong?[] { 42, null }, new ulong?[] { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveULongArrayNullableProperty()
		{
			yield return RunTest<ULongArrayNullableProperty1, ulong?[]>(new ulong?[] { null, 42 });
			yield return RunTest<ULongArrayNullableProperty2, ulong?[]>(new ulong?[] { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveULongArrayNullableProperties()
		{
			yield return RunTest<ULongArrayNullableProperties1, ulong?[]>(new ulong?[] { 69, null }, new ulong?[] { null, 20 });
			yield return RunTest<ULongArrayNullableProperties2, ulong?[]>(new ulong?[] { null, 69 }, new ulong?[] { 20, null });
		}

		[UnityTest]
		public IEnumerator SaveULongListField()
		{
			yield return RunTest<ULongListField1, List<ulong>>(new List<ulong> { 69, 42 });
			yield return RunTest<ULongListField2, List<ulong>>(new List<ulong> { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveULongListFields()
		{
			yield return RunTest<ULongListFields1, List<ulong>>(new List<ulong> { 69, 42 }, new List<ulong> { 10, 20 });
			yield return RunTest<ULongListFields2, List<ulong>>(new List<ulong> { 42, 69 }, new List<ulong> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveULongListProperty()
		{
			yield return RunTest<ULongListProperty1, List<ulong>>(new List<ulong> { 69, 42 });
			yield return RunTest<ULongListProperty2, List<ulong>>(new List<ulong> { 42, 69 });
		}

		[UnityTest]
		public IEnumerator SaveULongListProperties()
		{
			yield return RunTest<ULongListProperties1, List<ulong>>(new List<ulong> { 69, 42 }, new List<ulong> { 10, 20 });
			yield return RunTest<ULongListProperties2, List<ulong>>(new List<ulong> { 42, 69 }, new List<ulong> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveULongListNullableField()
		{
			yield return RunTest<ULongListNullableField1, List<ulong?>>(new List<ulong?> { null, 42 });
			yield return RunTest<ULongListNullableField2, List<ulong?>>(new List<ulong?> { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveULongListNullableFields()
		{
			yield return RunTest<ULongListNullableFields1, List<ulong?>>(new List<ulong?> { null, 42 }, new List<ulong?> { 10, null });
			yield return RunTest<ULongListNullableFields2, List<ulong?>>(new List<ulong?> { 42, null }, new List<ulong?> { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveULongListNullableProperty()
		{
			yield return RunTest<ULongListNullableProperty1, List<ulong?>>(new List<ulong?> { null, 42 });
			yield return RunTest<ULongListNullableProperty2, List<ulong?>>(new List<ulong?> { 42, null });
		}

		[UnityTest]
		public IEnumerator SaveULongListNullableProperties()
		{
			yield return RunTest<ULongListNullableProperties1, List<ulong?>>(new List<ulong?> { 69, null }, new List<ulong?> { null, 20 });
			yield return RunTest<ULongListNullableProperties2, List<ulong?>>(new List<ulong?> { null, 69 }, new List<ulong?> { 20, null });
		}
		#endregion

		#region Float
		[UnityTest]
		public IEnumerator SaveFloatField()
		{
			yield return RunTest<FloatField1, float>(69.1f);
			yield return RunTest<FloatField2, float>(42.2f);
		}

		[UnityTest]
		public IEnumerator SaveFloatFields()
		{
			yield return RunTest<FloatFields1, float>(42.2f, 69.1f);
			yield return RunTest<FloatFields2, float>(69.1f, 42.2f);
		}

		[UnityTest]
		public IEnumerator SaveFloatProperty()
		{
			yield return RunTest<FloatProperty1, float>(69.1f);
			yield return RunTest<FloatProperty2, float>(42.2f);
		}

		[UnityTest]
		public IEnumerator SaveFloatProperties()
		{
			yield return RunTest<FloatProperties1, float>(42.2f, 69.1f);
			yield return RunTest<FloatProperties2, float>(69.1f, 42.2f);
		}

		[UnityTest]
		public IEnumerator SaveFloatNullableField()
		{
			yield return RunTest<FloatNullableField1, float?>(69.1f);
			yield return RunTest<FloatNullableField2, float?>(42.2f);
			yield return RunTest<FloatNullableField1, float?>(null);
			yield return RunTest<FloatNullableField2, float?>(null);
		}

		[UnityTest]
		public IEnumerator SaveFloatNullableFields()
		{
			yield return RunTest<FloatNullableFields1, float?>(42.2f, 69.1f);
			yield return RunTest<FloatNullableFields2, float?>(69.1f, 42.2f);
			yield return RunTest<FloatNullableFields1, float?>(null, 69.1f);
			yield return RunTest<FloatNullableFields2, float?>(69.1f, null);
		}

		[UnityTest]
		public IEnumerator SaveFloatNullableProperty()
		{
			yield return RunTest<FloatNullableProperty1, float?>(69.1f);
			yield return RunTest<FloatNullableProperty2, float?>(42.2f);
			yield return RunTest<FloatNullableProperty1, float?>(null);
			yield return RunTest<FloatNullableProperty2, float?>(null);
		}

		[UnityTest]
		public IEnumerator SaveFloatNullableProperties()
		{
			yield return RunTest<FloatNullableProperties1, float?>(null, 69.1f);
			yield return RunTest<FloatNullableProperties2, float?>(69.1f, null);
		}

		[UnityTest]
		public IEnumerator SaveFloatArrayField()
		{
			yield return RunTest<FloatArrayField1, float[]>(new[] { 69.1f, 42.2f });
			yield return RunTest<FloatArrayField2, float[]>(new[] { 42.2f, 69.1f });
		}

		[UnityTest]
		public IEnumerator SaveFloatArrayFields()
		{
			yield return RunTest<FloatArrayFields1, float[]>(new[] { 69.1f, 42.2f }, new float[] { 10, 20 });
			yield return RunTest<FloatArrayFields2, float[]>(new[] { 42.2f, 69.1f }, new float[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveFloatArrayProperty()
		{
			yield return RunTest<FloatArrayProperty1, float[]>(new[] { 69.1f, 42.2f });
			yield return RunTest<FloatArrayProperty2, float[]>(new[] { 42.2f, 69.1f });
		}

		[UnityTest]
		public IEnumerator SaveFloatArrayProperties()
		{
			yield return RunTest<FloatArrayProperties1, float[]>(new[] { 69.1f, 42.2f }, new float[] { 10, 20 });
			yield return RunTest<FloatArrayProperties2, float[]>(new[] { 42.2f, 69.1f }, new float[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveFloatArrayNullableField()
		{
			yield return RunTest<FloatArrayNullableField1, float?[]>(new float?[] { null, 42.2f });
			yield return RunTest<FloatArrayNullableField2, float?[]>(new float?[] { 42.2f, null });
		}

		[UnityTest]
		public IEnumerator SaveFloatArrayNullableFields()
		{
			yield return RunTest<FloatArrayNullableFields1, float?[]>(new float?[] { null, 42.2f }, new float?[] { 10, null });
			yield return RunTest<FloatArrayNullableFields2, float?[]>(new float?[] { 42.2f, null }, new float?[] { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveFloatArrayNullableProperty()
		{
			yield return RunTest<FloatArrayNullableProperty1, float?[]>(new float?[] { null, 42.2f });
			yield return RunTest<FloatArrayNullableProperty2, float?[]>(new float?[] { 42.2f, null });
		}

		[UnityTest]
		public IEnumerator SaveFloatArrayNullableProperties()
		{
			yield return RunTest<FloatArrayNullableProperties1, float?[]>(new float?[] { 69.1f, null }, new float?[] { null, 20 });
			yield return RunTest<FloatArrayNullableProperties2, float?[]>(new float?[] { null, 69.1f }, new float?[] { 20, null });
		}

		[UnityTest]
		public IEnumerator SaveFloatListField()
		{
			yield return RunTest<FloatListField1, List<float>>(new List<float> { 69.1f, 42.2f });
			yield return RunTest<FloatListField2, List<float>>(new List<float> { 42.2f, 69.1f });
		}

		[UnityTest]
		public IEnumerator SaveFloatListFields()
		{
			yield return RunTest<FloatListFields1, List<float>>(new List<float> { 69.1f, 42.2f }, new List<float> { 10, 20 });
			yield return RunTest<FloatListFields2, List<float>>(new List<float> { 42.2f, 69.1f }, new List<float> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveFloatListProperty()
		{
			yield return RunTest<FloatListProperty1, List<float>>(new List<float> { 69.1f, 42.2f });
			yield return RunTest<FloatListProperty2, List<float>>(new List<float> { 42.2f, 69.1f });
		}

		[UnityTest]
		public IEnumerator SaveFloatListProperties()
		{
			yield return RunTest<FloatListProperties1, List<float>>(new List<float> { 69.1f, 42.2f }, new List<float> { 10, 20 });
			yield return RunTest<FloatListProperties2, List<float>>(new List<float> { 42.2f, 69.1f }, new List<float> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveFloatListNullableField()
		{
			yield return RunTest<FloatListNullableField1, List<float?>>(new List<float?> { null, 42.2f });
			yield return RunTest<FloatListNullableField2, List<float?>>(new List<float?> { 42.2f, null });
		}

		[UnityTest]
		public IEnumerator SaveFloatListNullableFields()
		{
			yield return RunTest<FloatListNullableFields1, List<float?>>(new List<float?> { null, 42.2f }, new List<float?> { 10, null });
			yield return RunTest<FloatListNullableFields2, List<float?>>(new List<float?> { 42.2f, null }, new List<float?> { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveFloatListNullableProperty()
		{
			yield return RunTest<FloatListNullableProperty1, List<float?>>(new List<float?> { null, 42.2f });
			yield return RunTest<FloatListNullableProperty2, List<float?>>(new List<float?> { 42.2f, null });
		}

		[UnityTest]
		public IEnumerator SaveFloatListNullableProperties()
		{
			yield return RunTest<FloatListNullableProperties1, List<float?>>(new List<float?> { 69.1f, null }, new List<float?> { null, 20 });
			yield return RunTest<FloatListNullableProperties2, List<float?>>(new List<float?> { null, 69.1f }, new List<float?> { 20, null });
		}
		#endregion

		#region Double
		[UnityTest]
		public IEnumerator SaveDoubleField()
		{
			yield return RunTest<DoubleField1, double>(69.420);
			yield return RunTest<DoubleField2, double>(42.2);
		}

		[UnityTest]
		public IEnumerator SaveDoubleFields()
		{
			yield return RunTest<DoubleFields1, double>(42.2, 69.420);
			yield return RunTest<DoubleFields2, double>(69.420, 42.2);
		}

		[UnityTest]
		public IEnumerator SaveDoubleProperty()
		{
			yield return RunTest<DoubleProperty1, double>(69.420);
			yield return RunTest<DoubleProperty2, double>(42.2);
		}

		[UnityTest]
		public IEnumerator SaveDoubleProperties()
		{
			yield return RunTest<DoubleProperties1, double>(42.2, 69.420);
			yield return RunTest<DoubleProperties2, double>(69.420, 42.2);
		}

		[UnityTest]
		public IEnumerator SaveDoubleNullableField()
		{
			yield return RunTest<DoubleNullableField1, double?>(69.420);
			yield return RunTest<DoubleNullableField2, double?>(42.2);
			yield return RunTest<DoubleNullableField1, double?>(null);
			yield return RunTest<DoubleNullableField2, double?>(null);
		}

		[UnityTest]
		public IEnumerator SaveDoubleNullableFields()
		{
			yield return RunTest<DoubleNullableFields1, double?>(42.2, 69.420);
			yield return RunTest<DoubleNullableFields2, double?>(69.420, 42.2);
			yield return RunTest<DoubleNullableFields1, double?>(null, 69.420);
			yield return RunTest<DoubleNullableFields2, double?>(69.420, null);
		}

		[UnityTest]
		public IEnumerator SaveDoubleNullableProperty()
		{
			yield return RunTest<DoubleNullableProperty1, double?>(69.420);
			yield return RunTest<DoubleNullableProperty2, double?>(42.2);
			yield return RunTest<DoubleNullableProperty1, double?>(null);
			yield return RunTest<DoubleNullableProperty2, double?>(null);
		}

		[UnityTest]
		public IEnumerator SaveDoubleNullableProperties()
		{
			yield return RunTest<DoubleNullableProperties1, double?>(null, 69.420);
			yield return RunTest<DoubleNullableProperties2, double?>(69.420, null);
		}

		[UnityTest]
		public IEnumerator SaveDoubleArrayField()
		{
			yield return RunTest<DoubleArrayField1, double[]>(new[] { 69.420, 42.2 });
			yield return RunTest<DoubleArrayField2, double[]>(new[] { 42.2, 69.420 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleArrayFields()
		{
			yield return RunTest<DoubleArrayFields1, double[]>(new[] { 69.420, 42.2 }, new double[] { 10, 20 });
			yield return RunTest<DoubleArrayFields2, double[]>(new[] { 42.2, 69.420 }, new double[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleArrayProperty()
		{
			yield return RunTest<DoubleArrayProperty1, double[]>(new[] { 69.420, 42.2 });
			yield return RunTest<DoubleArrayProperty2, double[]>(new[] { 42.2, 69.420 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleArrayProperties()
		{
			yield return RunTest<DoubleArrayProperties1, double[]>(new[] { 69.420, 42.2 }, new double[] { 10, 20 });
			yield return RunTest<DoubleArrayProperties2, double[]>(new[] { 42.2, 69.420 }, new double[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleArrayNullableField()
		{
			yield return RunTest<DoubleArrayNullableField1, double?[]>(new double?[] { null, 42.2 });
			yield return RunTest<DoubleArrayNullableField2, double?[]>(new double?[] { 42.2, null });
		}

		[UnityTest]
		public IEnumerator SaveDoubleArrayNullableFields()
		{
			yield return RunTest<DoubleArrayNullableFields1, double?[]>(new double?[] { null, 42.2 }, new double?[] { 10, null });
			yield return RunTest<DoubleArrayNullableFields2, double?[]>(new double?[] { 42.2, null }, new double?[] { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleArrayNullableProperty()
		{
			yield return RunTest<DoubleArrayNullableProperty1, double?[]>(new double?[] { null, 42.2 });
			yield return RunTest<DoubleArrayNullableProperty2, double?[]>(new double?[] { 42.2, null });
		}

		[UnityTest]
		public IEnumerator SaveDoubleArrayNullableProperties()
		{
			yield return RunTest<DoubleArrayNullableProperties1, double?[]>(new double?[] { 69.420, null }, new double?[] { null, 20 });
			yield return RunTest<DoubleArrayNullableProperties2, double?[]>(new double?[] { null, 69.420 }, new double?[] { 20, null });
		}

		[UnityTest]
		public IEnumerator SaveDoubleListField()
		{
			yield return RunTest<DoubleListField1, List<double>>(new List<double> { 69.420, 42.2 });
			yield return RunTest<DoubleListField2, List<double>>(new List<double> { 42.2, 69.420 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleListFields()
		{
			yield return RunTest<DoubleListFields1, List<double>>(new List<double> { 69.420, 42.2 }, new List<double> { 10, 20 });
			yield return RunTest<DoubleListFields2, List<double>>(new List<double> { 42.2, 69.420 }, new List<double> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleListProperty()
		{
			yield return RunTest<DoubleListProperty1, List<double>>(new List<double> { 69.420, 42.2 });
			yield return RunTest<DoubleListProperty2, List<double>>(new List<double> { 42.2, 69.420 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleListProperties()
		{
			yield return RunTest<DoubleListProperties1, List<double>>(new List<double> { 69.420, 42.2 }, new List<double> { 10, 20 });
			yield return RunTest<DoubleListProperties2, List<double>>(new List<double> { 42.2, 69.420 }, new List<double> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleListNullableField()
		{
			yield return RunTest<DoubleListNullableField1, List<double?>>(new List<double?> { null, 42.2 });
			yield return RunTest<DoubleListNullableField2, List<double?>>(new List<double?> { 42.2, null });
		}

		[UnityTest]
		public IEnumerator SaveDoubleListNullableFields()
		{
			yield return RunTest<DoubleListNullableFields1, List<double?>>(new List<double?> { null, 42.2 }, new List<double?> { 10, null });
			yield return RunTest<DoubleListNullableFields2, List<double?>>(new List<double?> { 42.2, null }, new List<double?> { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleListNullableProperty()
		{
			yield return RunTest<DoubleListNullableProperty1, List<double?>>(new List<double?> { null, 42.2 });
			yield return RunTest<DoubleListNullableProperty2, List<double?>>(new List<double?> { 42.2, null });
		}

		[UnityTest]
		public IEnumerator SaveDoubleListNullableProperties()
		{
			yield return RunTest<DoubleListNullableProperties1, List<double?>>(new List<double?> { 69.420, null }, new List<double?> { null, 20 });
			yield return RunTest<DoubleListNullableProperties2, List<double?>>(new List<double?> { null, 69.420 }, new List<double?> { 20, null });
		}
		#endregion

		#region Decimal
		[UnityTest]
		public IEnumerator SaveDecimalField()
		{
			yield return RunTest<DecimalField1, decimal>(69.6969m);
			yield return RunTest<DecimalField2, decimal>(42.777m);
		}

		[UnityTest]
		public IEnumerator SaveDecimalFields()
		{
			yield return RunTest<DecimalFields1, decimal>(42.777m, 69.6969m);
			yield return RunTest<DecimalFields2, decimal>(69.6969m, 42.777m);
		}

		[UnityTest]
		public IEnumerator SaveDecimalProperty()
		{
			yield return RunTest<DecimalProperty1, decimal>(69.6969m);
			yield return RunTest<DecimalProperty2, decimal>(42.777m);
		}

		[UnityTest]
		public IEnumerator SaveDecimalProperties()
		{
			yield return RunTest<DecimalProperties1, decimal>(42.777m, 69.6969m);
			yield return RunTest<DecimalProperties2, decimal>(69.6969m, 42.777m);
		}

		[UnityTest]
		public IEnumerator SaveDecimalNullableField()
		{
			yield return RunTest<DecimalNullableField1, decimal?>(69.6969m);
			yield return RunTest<DecimalNullableField2, decimal?>(42.777m);
			yield return RunTest<DecimalNullableField1, decimal?>(null);
			yield return RunTest<DecimalNullableField2, decimal?>(null);
		}

		[UnityTest]
		public IEnumerator SaveDecimalNullableFields()
		{
			yield return RunTest<DecimalNullableFields1, decimal?>(42.777m, 69.6969m);
			yield return RunTest<DecimalNullableFields2, decimal?>(69.6969m, 42.777m);
			yield return RunTest<DecimalNullableFields1, decimal?>(null, 69.6969m);
			yield return RunTest<DecimalNullableFields2, decimal?>(69.6969m, null);
		}

		[UnityTest]
		public IEnumerator SaveDecimalNullableProperty()
		{
			yield return RunTest<DecimalNullableProperty1, decimal?>(69.6969m);
			yield return RunTest<DecimalNullableProperty2, decimal?>(42.777m);
			yield return RunTest<DecimalNullableProperty1, decimal?>(null);
			yield return RunTest<DecimalNullableProperty2, decimal?>(null);
		}

		[UnityTest]
		public IEnumerator SaveDecimalNullableProperties()
		{
			yield return RunTest<DecimalNullableProperties1, decimal?>(null, 69.6969m);
			yield return RunTest<DecimalNullableProperties2, decimal?>(69.6969m, null);
		}

		[UnityTest]
		public IEnumerator SaveDecimalArrayField()
		{
			yield return RunTest<DecimalArrayField1, decimal[]>(new[] { 69.6969m, 42.777m });
			yield return RunTest<DecimalArrayField2, decimal[]>(new[] { 42.777m, 69.6969m });
		}

		[UnityTest]
		public IEnumerator SaveDecimalArrayFields()
		{
			yield return RunTest<DecimalArrayFields1, decimal[]>(new[] { 69.6969m, 42.777m }, new decimal[] { 10, 20 });
			yield return RunTest<DecimalArrayFields2, decimal[]>(new[] { 42.777m, 69.6969m }, new decimal[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveDecimalArrayProperty()
		{
			yield return RunTest<DecimalArrayProperty1, decimal[]>(new[] { 69.6969m, 42.777m });
			yield return RunTest<DecimalArrayProperty2, decimal[]>(new[] { 42.777m, 69.6969m });
		}

		[UnityTest]
		public IEnumerator SaveDecimalArrayProperties()
		{
			yield return RunTest<DecimalArrayProperties1, decimal[]>(new[] { 69.6969m, 42.777m }, new decimal[] { 10, 20 });
			yield return RunTest<DecimalArrayProperties2, decimal[]>(new[] { 42.777m, 69.6969m }, new decimal[] { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveDecimalArrayNullableField()
		{
			yield return RunTest<DecimalArrayNullableField1, decimal?[]>(new decimal?[] { null, 42.777m });
			yield return RunTest<DecimalArrayNullableField2, decimal?[]>(new decimal?[] { 42.777m, null });
		}

		[UnityTest]
		public IEnumerator SaveDecimalArrayNullableFields()
		{
			yield return RunTest<DecimalArrayNullableFields1, decimal?[]>(new decimal?[] { null, 42.777m }, new decimal?[] { 10, null });
			yield return RunTest<DecimalArrayNullableFields2, decimal?[]>(new decimal?[] { 42.777m, null }, new decimal?[] { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveDecimalArrayNullableProperty()
		{
			yield return RunTest<DecimalArrayNullableProperty1, decimal?[]>(new decimal?[] { null, 42.777m });
			yield return RunTest<DecimalArrayNullableProperty2, decimal?[]>(new decimal?[] { 42.777m, null });
		}

		[UnityTest]
		public IEnumerator SaveDecimalArrayNullableProperties()
		{
			yield return RunTest<DecimalArrayNullableProperties1, decimal?[]>(new decimal?[] { 69.6969m, null }, new decimal?[] { null, 20 });
			yield return RunTest<DecimalArrayNullableProperties2, decimal?[]>(new decimal?[] { null, 69.6969m }, new decimal?[] { 20, null });
		}

		[UnityTest]
		public IEnumerator SaveDecimalListField()
		{
			yield return RunTest<DecimalListField1, List<decimal>>(new List<decimal> { 69.6969m, 42.777m });
			yield return RunTest<DecimalListField2, List<decimal>>(new List<decimal> { 42.777m, 69.6969m });
		}

		[UnityTest]
		public IEnumerator SaveDecimalListFields()
		{
			yield return RunTest<DecimalListFields1, List<decimal>>(new List<decimal> { 69.6969m, 42.777m }, new List<decimal> { 10, 20 });
			yield return RunTest<DecimalListFields2, List<decimal>>(new List<decimal> { 42.777m, 69.6969m }, new List<decimal> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveDecimalListProperty()
		{
			yield return RunTest<DecimalListProperty1, List<decimal>>(new List<decimal> { 69.6969m, 42.777m });
			yield return RunTest<DecimalListProperty2, List<decimal>>(new List<decimal> { 42.777m, 69.6969m });
		}

		[UnityTest]
		public IEnumerator SaveDecimalListProperties()
		{
			yield return RunTest<DecimalListProperties1, List<decimal>>(new List<decimal> { 69.6969m, 42.777m }, new List<decimal> { 10, 20 });
			yield return RunTest<DecimalListProperties2, List<decimal>>(new List<decimal> { 42.777m, 69.6969m }, new List<decimal> { 20, 10 });
		}

		[UnityTest]
		public IEnumerator SaveDecimalListNullableField()
		{
			yield return RunTest<DecimalListNullableField1, List<decimal?>>(new List<decimal?> { null, 42.777m });
			yield return RunTest<DecimalListNullableField2, List<decimal?>>(new List<decimal?> { 42.777m, null });
		}

		[UnityTest]
		public IEnumerator SaveDecimalListNullableFields()
		{
			yield return RunTest<DecimalListNullableFields1, List<decimal?>>(new List<decimal?> { null, 42.777m }, new List<decimal?> { 10, null });
			yield return RunTest<DecimalListNullableFields2, List<decimal?>>(new List<decimal?> { 42.777m, null }, new List<decimal?> { null, 10 });
		}

		[UnityTest]
		public IEnumerator SaveDecimalListNullableProperty()
		{
			yield return RunTest<DecimalListNullableProperty1, List<decimal?>>(new List<decimal?> { null, 42.777m });
			yield return RunTest<DecimalListNullableProperty2, List<decimal?>>(new List<decimal?> { 42.777m, null });
		}

		[UnityTest]
		public IEnumerator SaveDecimalListNullableProperties()
		{
			yield return RunTest<DecimalListNullableProperties1, List<decimal?>>(new List<decimal?> { 69.6969m, null }, new List<decimal?> { null, 20 });
			yield return RunTest<DecimalListNullableProperties2, List<decimal?>>(new List<decimal?> { null, 69.6969m }, new List<decimal?> { 20, null });
		}
		#endregion

		#region Bool
		[UnityTest]
		public IEnumerator SaveBoolField()
		{
			yield return RunTest<BoolField1, bool>(true);
			yield return RunTest<BoolField2, bool>(false);
		}

		[UnityTest]
		public IEnumerator SaveBoolFields()
		{
			yield return RunTest<BoolFields1, bool>(false, true);
			yield return RunTest<BoolFields2, bool>(true, false);
		}

		[UnityTest]
		public IEnumerator SaveBoolProperty()
		{
			yield return RunTest<BoolProperty1, bool>(true);
			yield return RunTest<BoolProperty2, bool>(false);
		}

		[UnityTest]
		public IEnumerator SaveBoolProperties()
		{
			yield return RunTest<BoolProperties1, bool>(false, true);
			yield return RunTest<BoolProperties2, bool>(true, false);
		}

		[UnityTest]
		public IEnumerator SaveBoolNullableField()
		{
			yield return RunTest<BoolNullableField1, bool?>(true);
			yield return RunTest<BoolNullableField2, bool?>(false);
			yield return RunTest<BoolNullableField1, bool?>(null);
			yield return RunTest<BoolNullableField2, bool?>(null);
		}

		[UnityTest]
		public IEnumerator SaveBoolNullableFields()
		{
			yield return RunTest<BoolNullableFields1, bool?>(false, true);
			yield return RunTest<BoolNullableFields2, bool?>(true, false);
			yield return RunTest<BoolNullableFields1, bool?>(null, true);
			yield return RunTest<BoolNullableFields2, bool?>(true, null);
		}

		[UnityTest]
		public IEnumerator SaveBoolNullableProperty()
		{
			yield return RunTest<BoolNullableProperty1, bool?>(true);
			yield return RunTest<BoolNullableProperty2, bool?>(false);
			yield return RunTest<BoolNullableProperty1, bool?>(null);
			yield return RunTest<BoolNullableProperty2, bool?>(null);
		}

		[UnityTest]
		public IEnumerator SaveBoolNullableProperties()
		{
			yield return RunTest<BoolNullableProperties1, bool?>(null, true);
			yield return RunTest<BoolNullableProperties2, bool?>(true, null);
		}

		[UnityTest]
		public IEnumerator SaveBoolArrayField()
		{
			yield return RunTest<BoolArrayField1, bool[]>(new[] { true, false });
			yield return RunTest<BoolArrayField2, bool[]>(new[] { false, true });
		}

		[UnityTest]
		public IEnumerator SaveBoolArrayFields()
		{
			yield return RunTest<BoolArrayFields1, bool[]>(new[] { true, false }, new[] { true, false });
			yield return RunTest<BoolArrayFields2, bool[]>(new[] { false, true }, new[] { false, true });
		}

		[UnityTest]
		public IEnumerator SaveBoolArrayProperty()
		{
			yield return RunTest<BoolArrayProperty1, bool[]>(new[] { true, false });
			yield return RunTest<BoolArrayProperty2, bool[]>(new[] { false, true });
		}

		[UnityTest]
		public IEnumerator SaveBoolArrayProperties()
		{
			yield return RunTest<BoolArrayProperties1, bool[]>(new[] { true, false }, new[] { true, false });
			yield return RunTest<BoolArrayProperties2, bool[]>(new[] { false, true }, new[] { false, true });
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
			yield return RunTest<BoolArrayNullableFields1, bool?[]>(new bool?[] { null, false }, new bool?[] { true, null });
			yield return RunTest<BoolArrayNullableFields2, bool?[]>(new bool?[] { false, null }, new bool?[] { null, true });
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
			yield return RunTest<BoolArrayNullableProperties1, bool?[]>(new bool?[] { true, null }, new bool?[] { null, false });
			yield return RunTest<BoolArrayNullableProperties2, bool?[]>(new bool?[] { null, true }, new bool?[] { false, null });
		}

		[UnityTest]
		public IEnumerator SaveBoolListField()
		{
			yield return RunTest<BoolListField1, List<bool>>(new List<bool> { true, false });
			yield return RunTest<BoolListField2, List<bool>>(new List<bool> { false, true });
		}

		[UnityTest]
		public IEnumerator SaveBoolListFields()
		{
			yield return RunTest<BoolListFields1, List<bool>>(new List<bool> { true, false }, new List<bool> { true, false });
			yield return RunTest<BoolListFields2, List<bool>>(new List<bool> { false, true }, new List<bool> { false, true });
		}

		[UnityTest]
		public IEnumerator SaveBoolListProperty()
		{
			yield return RunTest<BoolListProperty1, List<bool>>(new List<bool> { true, false });
			yield return RunTest<BoolListProperty2, List<bool>>(new List<bool> { false, true });
		}

		[UnityTest]
		public IEnumerator SaveBoolListProperties()
		{
			yield return RunTest<BoolListProperties1, List<bool>>(new List<bool> { true, false }, new List<bool> { true, false });
			yield return RunTest<BoolListProperties2, List<bool>>(new List<bool> { false, true }, new List<bool> { false, true });
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
			yield return RunTest<BoolListNullableFields1, List<bool?>>(new List<bool?> { null, false }, new List<bool?> { true, null });
			yield return RunTest<BoolListNullableFields2, List<bool?>>(new List<bool?> { false, null }, new List<bool?> { null, true });
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
			yield return RunTest<BoolListNullableProperties1, List<bool?>>(new List<bool?> { true, null }, new List<bool?> { null, false });
			yield return RunTest<BoolListNullableProperties2, List<bool?>>(new List<bool?> { null, true }, new List<bool?> { false, null });
		}
		#endregion

		#region String
		[UnityTest]
		public IEnumerator SaveStringField()
		{
			yield return RunTest<StringField1, string>("Hello, ");
			yield return RunTest<StringField2, string>("World!");
		}

		[UnityTest]
		public IEnumerator SaveStringFields()
		{
			yield return RunTest<StringFields1, string>("World!", "Hello, ");
			yield return RunTest<StringFields2, string>("Hello, ", "World!");
		}

		[UnityTest]
		public IEnumerator SaveStringProperty()
		{
			yield return RunTest<StringProperty1, string>("Hello, ");
			yield return RunTest<StringProperty2, string>("World!");
		}

		[UnityTest]
		public IEnumerator SaveStringProperties()
		{
			yield return RunTest<StringProperties1, string>("World!", "Hello, ");
			yield return RunTest<StringProperties2, string>("Hello, ", "World!");
		}

		[UnityTest]
		public IEnumerator SaveStringNullableField()
		{
			yield return RunTest<StringField1, string>("Hello, ");
			yield return RunTest<StringField2, string>("World!");
			yield return RunTest<StringField1, string>(null);
			yield return RunTest<StringField2, string>(null);
		}

		[UnityTest]
		public IEnumerator SaveStringNullableFields()
		{
			yield return RunTest<StringFields1, string>("World!", "Hello, ");
			yield return RunTest<StringFields2, string>("Hello, ", "World!");
			yield return RunTest<StringFields1, string>(null, "Hello, ");
			yield return RunTest<StringFields2, string>("Hello, ", null);
		}

		[UnityTest]
		public IEnumerator SaveStringNullableProperty()
		{
			yield return RunTest<StringProperty1, string>("Hello, ");
			yield return RunTest<StringProperty2, string>("World!");
			yield return RunTest<StringProperty1, string>(null);
			yield return RunTest<StringProperty2, string>(null);
		}

		[UnityTest]
		public IEnumerator SaveStringNullableProperties()
		{
			yield return RunTest<StringProperties1, string>(null, "Hello, ");
			yield return RunTest<StringProperties2, string>("Hello, ", null);
		}

		[UnityTest]
		public IEnumerator SaveStringArrayField()
		{
			yield return RunTest<StringArrayField1, string[]>(new[] { "Hello, ", "World!" });
			yield return RunTest<StringArrayField2, string[]>(new[] { "World!", "Hello, " });
		}

		[UnityTest]
		public IEnumerator SaveStringArrayFields()
		{
			yield return RunTest<StringArrayFields1, string[]>(new[] { "Hello, ", "World!" }, new[] { "Hi ", "Mom! " });
			yield return RunTest<StringArrayFields2, string[]>(new[] { "World!", "Hello, " }, new[] { "Mom! ", "Hi " });
		}

		[UnityTest]
		public IEnumerator SaveStringArrayProperty()
		{
			yield return RunTest<StringArrayProperty1, string[]>(new[] { "Hello, ", "World!" });
			yield return RunTest<StringArrayProperty2, string[]>(new[] { "World!", "Hello, " });
		}

		[UnityTest]
		public IEnumerator SaveStringArrayProperties()
		{
			yield return RunTest<StringArrayProperties1, string[]>(new[] { "Hello, ", "World!" }, new[] { "Hi ", "Mom! " });
			yield return RunTest<StringArrayProperties2, string[]>(new[] { "World!", "Hello, " }, new[] { "Mom! ", "Hi " });
		}

		[UnityTest]
		public IEnumerator SaveStringArrayNullableField()
		{
			yield return RunTest<StringArrayField1, string[]>(new[] { null, "World!" });
			yield return RunTest<StringArrayField2, string[]>(new[] { "World!", null });
		}

		[UnityTest]
		public IEnumerator SaveStringArrayNullableFields()
		{
			yield return RunTest<StringArrayFields1, string[]>(new[] { null, "World!" }, new[] { "Hi ", null });
			yield return RunTest<StringArrayFields2, string[]>(new[] { "World!", null }, new[] { null, "Hi " });
		}

		[UnityTest]
		public IEnumerator SaveStringArrayNullableProperty()
		{
			yield return RunTest<StringArrayProperty1, string[]>(new[] { null, "World!" });
			yield return RunTest<StringArrayProperty2, string[]>(new[] { "World!", null });
		}

		[UnityTest]
		public IEnumerator SaveStringArrayNullableProperties()
		{
			yield return RunTest<StringArrayProperties1, string[]>(new[] { "Hello, ", null }, new[] { null, "Mom! " });
			yield return RunTest<StringArrayProperties2, string[]>(new[] { null, "Hello, " }, new[] { "Mom! ", null });
		}

		[UnityTest]
		public IEnumerator SaveStringListField()
		{
			yield return RunTest<StringListField1, List<string>>(new List<string> { "Hello, ", "World!" });
			yield return RunTest<StringListField2, List<string>>(new List<string> { "World!", "Hello, " });
		}

		[UnityTest]
		public IEnumerator SaveStringListFields()
		{
			yield return RunTest<StringListFields1, List<string>>(new List<string> { "Hello, ", "World!" }, new List<string> { "Hi ", "Mom! " });
			yield return RunTest<StringListFields2, List<string>>(new List<string> { "World!", "Hello, " }, new List<string> { "Mom! ", "Hi " });
		}

		[UnityTest]
		public IEnumerator SaveStringListProperty()
		{
			yield return RunTest<StringListProperty1, List<string>>(new List<string> { "Hello, ", "World!" });
			yield return RunTest<StringListProperty2, List<string>>(new List<string> { "World!", "Hello, " });
		}

		[UnityTest]
		public IEnumerator SaveStringListProperties()
		{
			yield return RunTest<StringListProperties1, List<string>>(new List<string> { "Hello, ", "World!" }, new List<string> { "Hi ", "Mom! " });
			yield return RunTest<StringListProperties2, List<string>>(new List<string> { "World!", "Hello, " }, new List<string> { "Mom! ", "Hi " });
		}

		[UnityTest]
		public IEnumerator SaveStringListNullableField()
		{
			yield return RunTest<StringListField1, List<string>>(new List<string> { null, "World!" });
			yield return RunTest<StringListField2, List<string>>(new List<string> { "World!", null });
		}

		[UnityTest]
		public IEnumerator SaveStringListNullableFields()
		{
			yield return RunTest<StringListFields1, List<string>>(new List<string> { null, "World!" }, new List<string> { "Hi ", null });
			yield return RunTest<StringListFields2, List<string>>(new List<string> { "World!", null }, new List<string> { null, "Hi " });
		}

		[UnityTest]
		public IEnumerator SaveStringListNullableProperty()
		{
			yield return RunTest<StringListProperty1, List<string>>(new List<string> { null, "World!" });
			yield return RunTest<StringListProperty2, List<string>>(new List<string> { "World!", null });
		}

		[UnityTest]
		public IEnumerator SaveStringListNullableProperties()
		{
			yield return RunTest<StringListProperties1, List<string>>(new List<string> { "Hello, ", null }, new List<string> { null, "Mom! " });
			yield return RunTest<StringListProperties2, List<string>>(new List<string> { null, "Hello, " }, new List<string> { "Mom! ", null });
		}
		#endregion

		#region Guid
		[UnityTest]
		public IEnumerator SaveGuidField()
		{
			yield return RunTest<GuidField1, Guid>(Guid.NewGuid());
			yield return RunTest<GuidField2, Guid>(Guid.NewGuid());
		}

		[UnityTest]
		public IEnumerator SaveGuidFields()
		{
			yield return RunTest<GuidFields1, Guid>(Guid.NewGuid(), Guid.NewGuid());
			yield return RunTest<GuidFields2, Guid>(Guid.NewGuid(), Guid.NewGuid());
		}

		[UnityTest]
		public IEnumerator SaveGuidProperty()
		{
			yield return RunTest<GuidProperty1, Guid>(Guid.NewGuid());
			yield return RunTest<GuidProperty2, Guid>(Guid.NewGuid());
		}

		[UnityTest]
		public IEnumerator SaveGuidProperties()
		{
			yield return RunTest<GuidProperties1, Guid>(Guid.NewGuid(), Guid.NewGuid());
			yield return RunTest<GuidProperties2, Guid>(Guid.NewGuid(), Guid.NewGuid());
		}

		[UnityTest]
		public IEnumerator SaveGuidNullableField()
		{
			yield return RunTest<GuidNullableField1, Guid?>(Guid.NewGuid());
			yield return RunTest<GuidNullableField2, Guid?>(Guid.NewGuid());
			yield return RunTest<GuidNullableField1, Guid?>(null);
			yield return RunTest<GuidNullableField2, Guid?>(null);
		}

		[UnityTest]
		public IEnumerator SaveGuidNullableFields()
		{
			yield return RunTest<GuidNullableFields1, Guid?>(Guid.NewGuid(), Guid.NewGuid());
			yield return RunTest<GuidNullableFields2, Guid?>(Guid.NewGuid(), Guid.NewGuid());
			yield return RunTest<GuidNullableFields1, Guid?>(null, Guid.NewGuid());
			yield return RunTest<GuidNullableFields2, Guid?>(Guid.NewGuid(), null);
		}

		[UnityTest]
		public IEnumerator SaveGuidNullableProperty()
		{
			yield return RunTest<GuidNullableProperty1, Guid?>(Guid.NewGuid());
			yield return RunTest<GuidNullableProperty2, Guid?>(Guid.NewGuid());
			yield return RunTest<GuidNullableProperty1, Guid?>(null);
			yield return RunTest<GuidNullableProperty2, Guid?>(null);
		}

		[UnityTest]
		public IEnumerator SaveGuidNullableProperties()
		{
			yield return RunTest<GuidNullableProperties1, Guid?>(null, Guid.NewGuid());
			yield return RunTest<GuidNullableProperties2, Guid?>(Guid.NewGuid(), null);
		}

		[UnityTest]
		public IEnumerator SaveGuidArrayField()
		{
			yield return RunTest<GuidArrayField1, Guid[]>(new[] { Guid.NewGuid(), Guid.NewGuid() });
			yield return RunTest<GuidArrayField2, Guid[]>(new[] { Guid.NewGuid(), Guid.NewGuid() });
		}

		[UnityTest]
		public IEnumerator SaveGuidArrayFields()
		{
			yield return RunTest<GuidArrayFields1, Guid[]>(new[] { Guid.NewGuid(), Guid.NewGuid() }, new[] { Guid.NewGuid(), Guid.NewGuid() });
			yield return RunTest<GuidArrayFields2, Guid[]>(new[] { Guid.NewGuid(), Guid.NewGuid() }, new[] { Guid.NewGuid(), Guid.NewGuid() });
		}

		[UnityTest]
		public IEnumerator SaveGuidArrayProperty()
		{
			yield return RunTest<GuidArrayProperty1, Guid[]>(new[] { Guid.NewGuid(), Guid.NewGuid() });
			yield return RunTest<GuidArrayProperty2, Guid[]>(new[] { Guid.NewGuid(), Guid.NewGuid() });
		}

		[UnityTest]
		public IEnumerator SaveGuidArrayProperties()
		{
			yield return RunTest<GuidArrayProperties1, Guid[]>(new[] { Guid.NewGuid(), Guid.NewGuid() }, new[] { Guid.NewGuid(), Guid.NewGuid() });
			yield return RunTest<GuidArrayProperties2, Guid[]>(new[] { Guid.NewGuid(), Guid.NewGuid() }, new[] { Guid.NewGuid(), Guid.NewGuid() });
		}

		[UnityTest]
		public IEnumerator SaveGuidArrayNullableField()
		{
			yield return RunTest<GuidArrayNullableField1, Guid?[]>(new Guid?[] { null, Guid.NewGuid() });
			yield return RunTest<GuidArrayNullableField2, Guid?[]>(new Guid?[] { Guid.NewGuid(), null });
		}

		[UnityTest]
		public IEnumerator SaveGuidArrayNullableFields()
		{
			yield return RunTest<GuidArrayNullableFields1, Guid?[]>(new Guid?[] { null, Guid.NewGuid() }, new Guid?[] { Guid.NewGuid(), null });
			yield return RunTest<GuidArrayNullableFields2, Guid?[]>(new Guid?[] { Guid.NewGuid(), null }, new Guid?[] { null, Guid.NewGuid() });
		}

		[UnityTest]
		public IEnumerator SaveGuidArrayNullableProperty()
		{
			yield return RunTest<GuidArrayNullableProperty1, Guid?[]>(new Guid?[] { null, Guid.NewGuid() });
			yield return RunTest<GuidArrayNullableProperty2, Guid?[]>(new Guid?[] { Guid.NewGuid(), null });
		}

		[UnityTest]
		public IEnumerator SaveGuidArrayNullableProperties()
		{
			yield return RunTest<GuidArrayNullableProperties1, Guid?[]>(new Guid?[] { Guid.NewGuid(), null }, new Guid?[] { null, Guid.NewGuid() });
			yield return RunTest<GuidArrayNullableProperties2, Guid?[]>(new Guid?[] { null, Guid.NewGuid() }, new Guid?[] { Guid.NewGuid(), null });
		}

		[UnityTest]
		public IEnumerator SaveGuidListField()
		{
			yield return RunTest<GuidListField1, List<Guid>>(new List<Guid> { Guid.NewGuid(), Guid.NewGuid() });
			yield return RunTest<GuidListField2, List<Guid>>(new List<Guid> { Guid.NewGuid(), Guid.NewGuid() });
		}

		[UnityTest]
		public IEnumerator SaveGuidListFields()
		{
			yield return RunTest<GuidListFields1, List<Guid>>(new List<Guid> { Guid.NewGuid(), Guid.NewGuid() }, new List<Guid> { Guid.NewGuid(), Guid.NewGuid() });
			yield return RunTest<GuidListFields2, List<Guid>>(new List<Guid> { Guid.NewGuid(), Guid.NewGuid() }, new List<Guid> { Guid.NewGuid(), Guid.NewGuid() });
		}

		[UnityTest]
		public IEnumerator SaveGuidListProperty()
		{
			yield return RunTest<GuidListProperty1, List<Guid>>(new List<Guid> { Guid.NewGuid(), Guid.NewGuid() });
			yield return RunTest<GuidListProperty2, List<Guid>>(new List<Guid> { Guid.NewGuid(), Guid.NewGuid() });
		}

		[UnityTest]
		public IEnumerator SaveGuidListProperties()
		{
			yield return RunTest<GuidListProperties1, List<Guid>>(new List<Guid> { Guid.NewGuid(), Guid.NewGuid() }, new List<Guid> { Guid.NewGuid(), Guid.NewGuid() });
			yield return RunTest<GuidListProperties2, List<Guid>>(new List<Guid> { Guid.NewGuid(), Guid.NewGuid() }, new List<Guid> { Guid.NewGuid(), Guid.NewGuid() });
		}

		[UnityTest]
		public IEnumerator SaveGuidListNullableField()
		{
			yield return RunTest<GuidListNullableField1, List<Guid?>>(new List<Guid?> { null, Guid.NewGuid() });
			yield return RunTest<GuidListNullableField2, List<Guid?>>(new List<Guid?> { Guid.NewGuid(), null });
		}

		[UnityTest]
		public IEnumerator SaveGuidListNullableFields()
		{
			yield return RunTest<GuidListNullableFields1, List<Guid?>>(new List<Guid?> { null, Guid.NewGuid() }, new List<Guid?> { Guid.NewGuid(), null });
			yield return RunTest<GuidListNullableFields2, List<Guid?>>(new List<Guid?> { Guid.NewGuid(), null }, new List<Guid?> { null, Guid.NewGuid() });
		}

		[UnityTest]
		public IEnumerator SaveGuidListNullableProperty()
		{
			yield return RunTest<GuidListNullableProperty1, List<Guid?>>(new List<Guid?> { null, Guid.NewGuid() });
			yield return RunTest<GuidListNullableProperty2, List<Guid?>>(new List<Guid?> { Guid.NewGuid(), null });
		}

		[UnityTest]
		public IEnumerator SaveGuidListNullableProperties()
		{
			yield return RunTest<GuidListNullableProperties1, List<Guid?>>(new List<Guid?> { Guid.NewGuid(), null }, new List<Guid?> { null, Guid.NewGuid() });
			yield return RunTest<GuidListNullableProperties2, List<Guid?>>(new List<Guid?> { null, Guid.NewGuid() }, new List<Guid?> { Guid.NewGuid(), null });
		}
		#endregion

		#region TimeSpan
		[UnityTest]
		public IEnumerator SaveTimeSpanField()
		{
			yield return RunTest<TimeSpanField1, TimeSpan>(TimeSpan.FromSeconds(69));
			yield return RunTest<TimeSpanField2, TimeSpan>(TimeSpan.FromMinutes(42));
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanFields()
		{
			yield return RunTest<TimeSpanFields1, TimeSpan>(TimeSpan.FromMinutes(42), TimeSpan.FromSeconds(69));
			yield return RunTest<TimeSpanFields2, TimeSpan>(TimeSpan.FromSeconds(69), TimeSpan.FromMinutes(42));
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanProperty()
		{
			yield return RunTest<TimeSpanProperty1, TimeSpan>(TimeSpan.FromSeconds(69));
			yield return RunTest<TimeSpanProperty2, TimeSpan>(TimeSpan.FromMinutes(42));
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanProperties()
		{
			yield return RunTest<TimeSpanProperties1, TimeSpan>(TimeSpan.FromMinutes(42), TimeSpan.FromSeconds(69));
			yield return RunTest<TimeSpanProperties2, TimeSpan>(TimeSpan.FromSeconds(69), TimeSpan.FromMinutes(42));
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanNullableField()
		{
			yield return RunTest<TimeSpanNullableField1, TimeSpan?>(TimeSpan.FromSeconds(69));
			yield return RunTest<TimeSpanNullableField2, TimeSpan?>(TimeSpan.FromMinutes(42));
			yield return RunTest<TimeSpanNullableField1, TimeSpan?>(null);
			yield return RunTest<TimeSpanNullableField2, TimeSpan?>(null);
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanNullableFields()
		{
			yield return RunTest<TimeSpanNullableFields1, TimeSpan?>(TimeSpan.FromMinutes(42), TimeSpan.FromSeconds(69));
			yield return RunTest<TimeSpanNullableFields2, TimeSpan?>(TimeSpan.FromSeconds(69), TimeSpan.FromMinutes(42));
			yield return RunTest<TimeSpanNullableFields1, TimeSpan?>(null, TimeSpan.FromSeconds(69));
			yield return RunTest<TimeSpanNullableFields2, TimeSpan?>(TimeSpan.FromSeconds(69), null);
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanNullableProperty()
		{
			yield return RunTest<TimeSpanNullableProperty1, TimeSpan?>(TimeSpan.FromSeconds(69));
			yield return RunTest<TimeSpanNullableProperty2, TimeSpan?>(TimeSpan.FromMinutes(42));
			yield return RunTest<TimeSpanNullableProperty1, TimeSpan?>(null);
			yield return RunTest<TimeSpanNullableProperty2, TimeSpan?>(null);
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanNullableProperties()
		{
			yield return RunTest<TimeSpanNullableProperties1, TimeSpan?>(null, TimeSpan.FromSeconds(69));
			yield return RunTest<TimeSpanNullableProperties2, TimeSpan?>(TimeSpan.FromSeconds(69), null);
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanArrayField()
		{
			yield return RunTest<TimeSpanArrayField1, TimeSpan[]>(new[] { TimeSpan.FromSeconds(69), TimeSpan.FromMinutes(42) });
			yield return RunTest<TimeSpanArrayField2, TimeSpan[]>(new[] { TimeSpan.FromMinutes(42), TimeSpan.FromSeconds(69) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanArrayFields()
		{
			yield return RunTest<TimeSpanArrayFields1, TimeSpan[]>(new[] { TimeSpan.FromSeconds(69), TimeSpan.FromMinutes(42) }, new[] { TimeSpan.FromSeconds(69), TimeSpan.FromMinutes(42) });
			yield return RunTest<TimeSpanArrayFields2, TimeSpan[]>(new[] { TimeSpan.FromMinutes(42), TimeSpan.FromSeconds(69) }, new[] { TimeSpan.FromMinutes(42), TimeSpan.FromSeconds(69) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanArrayProperty()
		{
			yield return RunTest<TimeSpanArrayProperty1, TimeSpan[]>(new[] { TimeSpan.FromSeconds(69), TimeSpan.FromMinutes(42) });
			yield return RunTest<TimeSpanArrayProperty2, TimeSpan[]>(new[] { TimeSpan.FromMinutes(42), TimeSpan.FromSeconds(69) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanArrayProperties()
		{
			yield return RunTest<TimeSpanArrayProperties1, TimeSpan[]>(new[] { TimeSpan.FromSeconds(69), TimeSpan.FromMinutes(42) }, new[] { TimeSpan.FromSeconds(69), TimeSpan.FromMinutes(42) });
			yield return RunTest<TimeSpanArrayProperties2, TimeSpan[]>(new[] { TimeSpan.FromMinutes(42), TimeSpan.FromSeconds(69) }, new[] { TimeSpan.FromMinutes(42), TimeSpan.FromSeconds(69) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanArrayNullableField()
		{
			yield return RunTest<TimeSpanArrayNullableField1, TimeSpan?[]>(new TimeSpan?[] { null, TimeSpan.FromMinutes(42) });
			yield return RunTest<TimeSpanArrayNullableField2, TimeSpan?[]>(new TimeSpan?[] { TimeSpan.FromMinutes(42), null });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanArrayNullableFields()
		{
			yield return RunTest<TimeSpanArrayNullableFields1, TimeSpan?[]>(new TimeSpan?[] { null, TimeSpan.FromMinutes(42) }, new TimeSpan?[] { TimeSpan.FromSeconds(69), null });
			yield return RunTest<TimeSpanArrayNullableFields2, TimeSpan?[]>(new TimeSpan?[] { TimeSpan.FromMinutes(42), null }, new TimeSpan?[] { null, TimeSpan.FromSeconds(69) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanArrayNullableProperty()
		{
			yield return RunTest<TimeSpanArrayNullableProperty1, TimeSpan?[]>(new TimeSpan?[] { null, TimeSpan.FromMinutes(42) });
			yield return RunTest<TimeSpanArrayNullableProperty2, TimeSpan?[]>(new TimeSpan?[] { TimeSpan.FromMinutes(42), null });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanArrayNullableProperties()
		{
			yield return RunTest<TimeSpanArrayNullableProperties1, TimeSpan?[]>(new TimeSpan?[] { TimeSpan.FromSeconds(69), null }, new TimeSpan?[] { null, TimeSpan.FromMinutes(42) });
			yield return RunTest<TimeSpanArrayNullableProperties2, TimeSpan?[]>(new TimeSpan?[] { null, TimeSpan.FromSeconds(69) }, new TimeSpan?[] { TimeSpan.FromMinutes(42), null });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanListField()
		{
			yield return RunTest<TimeSpanListField1, List<TimeSpan>>(new List<TimeSpan> { TimeSpan.FromSeconds(69), TimeSpan.FromMinutes(42) });
			yield return RunTest<TimeSpanListField2, List<TimeSpan>>(new List<TimeSpan> { TimeSpan.FromMinutes(42), TimeSpan.FromSeconds(69) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanListFields()
		{
			yield return RunTest<TimeSpanListFields1, List<TimeSpan>>(new List<TimeSpan> { TimeSpan.FromSeconds(69), TimeSpan.FromMinutes(42) }, new List<TimeSpan> { TimeSpan.FromSeconds(69), TimeSpan.FromMinutes(42) });
			yield return RunTest<TimeSpanListFields2, List<TimeSpan>>(new List<TimeSpan> { TimeSpan.FromMinutes(42), TimeSpan.FromSeconds(69) }, new List<TimeSpan> { TimeSpan.FromMinutes(42), TimeSpan.FromSeconds(69) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanListProperty()
		{
			yield return RunTest<TimeSpanListProperty1, List<TimeSpan>>(new List<TimeSpan> { TimeSpan.FromSeconds(69), TimeSpan.FromMinutes(42) });
			yield return RunTest<TimeSpanListProperty2, List<TimeSpan>>(new List<TimeSpan> { TimeSpan.FromMinutes(42), TimeSpan.FromSeconds(69) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanListProperties()
		{
			yield return RunTest<TimeSpanListProperties1, List<TimeSpan>>(new List<TimeSpan> { TimeSpan.FromSeconds(69), TimeSpan.FromMinutes(42) }, new List<TimeSpan> { TimeSpan.FromSeconds(69), TimeSpan.FromMinutes(42) });
			yield return RunTest<TimeSpanListProperties2, List<TimeSpan>>(new List<TimeSpan> { TimeSpan.FromMinutes(42), TimeSpan.FromSeconds(69) }, new List<TimeSpan> { TimeSpan.FromMinutes(42), TimeSpan.FromSeconds(69) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanListNullableField()
		{
			yield return RunTest<TimeSpanListNullableField1, List<TimeSpan?>>(new List<TimeSpan?> { null, TimeSpan.FromMinutes(42) });
			yield return RunTest<TimeSpanListNullableField2, List<TimeSpan?>>(new List<TimeSpan?> { TimeSpan.FromMinutes(42), null });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanListNullableFields()
		{
			yield return RunTest<TimeSpanListNullableFields1, List<TimeSpan?>>(new List<TimeSpan?> { null, TimeSpan.FromMinutes(42) }, new List<TimeSpan?> { TimeSpan.FromSeconds(69), null });
			yield return RunTest<TimeSpanListNullableFields2, List<TimeSpan?>>(new List<TimeSpan?> { TimeSpan.FromMinutes(42), null }, new List<TimeSpan?> { null, TimeSpan.FromSeconds(69) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanListNullableProperty()
		{
			yield return RunTest<TimeSpanListNullableProperty1, List<TimeSpan?>>(new List<TimeSpan?> { null, TimeSpan.FromMinutes(42) });
			yield return RunTest<TimeSpanListNullableProperty2, List<TimeSpan?>>(new List<TimeSpan?> { TimeSpan.FromMinutes(42), null });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanListNullableProperties()
		{
			yield return RunTest<TimeSpanListNullableProperties1, List<TimeSpan?>>(new List<TimeSpan?> { TimeSpan.FromSeconds(69), null }, new List<TimeSpan?> { null, TimeSpan.FromMinutes(42) });
			yield return RunTest<TimeSpanListNullableProperties2, List<TimeSpan?>>(new List<TimeSpan?> { null, TimeSpan.FromSeconds(69) }, new List<TimeSpan?> { TimeSpan.FromMinutes(42), null });
		}
		#endregion

		#region DateTime
		[UnityTest]
		public IEnumerator SaveDateTimeField()
		{
			yield return RunTest<DateTimeField1, DateTime>(new DateTime(2022, 1, 1, 17, 42, 0));
			yield return RunTest<DateTimeField2, DateTime>(new DateTime(2000, 7, 6, 02, 20, 0));
		}

		[UnityTest]
		public IEnumerator SaveDateTimeFields()
		{
			yield return RunTest<DateTimeFields1, DateTime>(new DateTime(2000, 7, 6, 02, 20, 0), new DateTime(2022, 1, 1, 17, 42, 0));
			yield return RunTest<DateTimeFields2, DateTime>(new DateTime(2022, 1, 1, 17, 42, 0), new DateTime(2000, 7, 6, 02, 20, 0));
		}

		[UnityTest]
		public IEnumerator SaveDateTimeProperty()
		{
			yield return RunTest<DateTimeProperty1, DateTime>(new DateTime(2022, 1, 1, 17, 42, 0));
			yield return RunTest<DateTimeProperty2, DateTime>(new DateTime(2000, 7, 6, 02, 20, 0));
		}

		[UnityTest]
		public IEnumerator SaveDateTimeProperties()
		{
			yield return RunTest<DateTimeProperties1, DateTime>(new DateTime(2000, 7, 6, 02, 20, 0), new DateTime(2022, 1, 1, 17, 42, 0));
			yield return RunTest<DateTimeProperties2, DateTime>(new DateTime(2022, 1, 1, 17, 42, 0), new DateTime(2000, 7, 6, 02, 20, 0));
		}

		[UnityTest]
		public IEnumerator SaveDateTimeNullableField()
		{
			yield return RunTest<DateTimeNullableField1, DateTime?>(new DateTime(2022, 1, 1, 17, 42, 0));
			yield return RunTest<DateTimeNullableField2, DateTime?>(new DateTime(2000, 7, 6, 02, 20, 0));
			yield return RunTest<DateTimeNullableField1, DateTime?>(null);
			yield return RunTest<DateTimeNullableField2, DateTime?>(null);
		}

		[UnityTest]
		public IEnumerator SaveDateTimeNullableFields()
		{
			yield return RunTest<DateTimeNullableFields1, DateTime?>(new DateTime(2000, 7, 6, 02, 20, 0), new DateTime(2022, 1, 1, 17, 42, 0));
			yield return RunTest<DateTimeNullableFields2, DateTime?>(new DateTime(2022, 1, 1, 17, 42, 0), new DateTime(2000, 7, 6, 02, 20, 0));
			yield return RunTest<DateTimeNullableFields1, DateTime?>(null, new DateTime(2022, 1, 1, 17, 42, 0));
			yield return RunTest<DateTimeNullableFields2, DateTime?>(new DateTime(2022, 1, 1, 17, 42, 0), null);
		}

		[UnityTest]
		public IEnumerator SaveDateTimeNullableProperty()
		{
			yield return RunTest<DateTimeNullableProperty1, DateTime?>(new DateTime(2022, 1, 1, 17, 42, 0));
			yield return RunTest<DateTimeNullableProperty2, DateTime?>(new DateTime(2000, 7, 6, 02, 20, 0));
			yield return RunTest<DateTimeNullableProperty1, DateTime?>(null);
			yield return RunTest<DateTimeNullableProperty2, DateTime?>(null);
		}

		[UnityTest]
		public IEnumerator SaveDateTimeNullableProperties()
		{
			yield return RunTest<DateTimeNullableProperties1, DateTime?>(null, new DateTime(2022, 1, 1, 17, 42, 0));
			yield return RunTest<DateTimeNullableProperties2, DateTime?>(new DateTime(2022, 1, 1, 17, 42, 0), null);
		}

		[UnityTest]
		public IEnumerator SaveDateTimeArrayField()
		{
			yield return RunTest<DateTimeArrayField1, DateTime[]>(new[] { new DateTime(2022, 1, 1, 17, 42, 0), new DateTime(2000, 7, 6, 02, 20, 0) });
			yield return RunTest<DateTimeArrayField2, DateTime[]>(new[] { new DateTime(2000, 7, 6, 02, 20, 0), new DateTime(2022, 1, 1, 17, 42, 0) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeArrayFields()
		{
			yield return RunTest<DateTimeArrayFields1, DateTime[]>(new[] { new DateTime(2022, 1, 1, 17, 42, 0), new DateTime(2000, 7, 6, 02, 20, 0) }, new[] { new DateTime(2022, 1, 1, 17, 42, 0), new DateTime(2000, 7, 6, 02, 20, 0) });
			yield return RunTest<DateTimeArrayFields2, DateTime[]>(new[] { new DateTime(2000, 7, 6, 02, 20, 0), new DateTime(2022, 1, 1, 17, 42, 0) }, new[] { new DateTime(2000, 7, 6, 02, 20, 0), new DateTime(2022, 1, 1, 17, 42, 0) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeArrayProperty()
		{
			yield return RunTest<DateTimeArrayProperty1, DateTime[]>(new[] { new DateTime(2022, 1, 1, 17, 42, 0), new DateTime(2000, 7, 6, 02, 20, 0) });
			yield return RunTest<DateTimeArrayProperty2, DateTime[]>(new[] { new DateTime(2000, 7, 6, 02, 20, 0), new DateTime(2022, 1, 1, 17, 42, 0) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeArrayProperties()
		{
			yield return RunTest<DateTimeArrayProperties1, DateTime[]>(new[] { new DateTime(2022, 1, 1, 17, 42, 0), new DateTime(2000, 7, 6, 02, 20, 0) }, new[] { new DateTime(2022, 1, 1, 17, 42, 0), new DateTime(2000, 7, 6, 02, 20, 0) });
			yield return RunTest<DateTimeArrayProperties2, DateTime[]>(new[] { new DateTime(2000, 7, 6, 02, 20, 0), new DateTime(2022, 1, 1, 17, 42, 0) }, new[] { new DateTime(2000, 7, 6, 02, 20, 0), new DateTime(2022, 1, 1, 17, 42, 0) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeArrayNullableField()
		{
			yield return RunTest<DateTimeArrayNullableField1, DateTime?[]>(new DateTime?[] { null, new DateTime(2000, 7, 6, 02, 20, 0) });
			yield return RunTest<DateTimeArrayNullableField2, DateTime?[]>(new DateTime?[] { new DateTime(2000, 7, 6, 02, 20, 0), null });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeArrayNullableFields()
		{
			yield return RunTest<DateTimeArrayNullableFields1, DateTime?[]>(new DateTime?[] { null, new DateTime(2000, 7, 6, 02, 20, 0) }, new DateTime?[] { new DateTime(2022, 1, 1, 17, 42, 0), null });
			yield return RunTest<DateTimeArrayNullableFields2, DateTime?[]>(new DateTime?[] { new DateTime(2000, 7, 6, 02, 20, 0), null }, new DateTime?[] { null, new DateTime(2022, 1, 1, 17, 42, 0) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeArrayNullableProperty()
		{
			yield return RunTest<DateTimeArrayNullableProperty1, DateTime?[]>(new DateTime?[] { null, new DateTime(2000, 7, 6, 02, 20, 0) });
			yield return RunTest<DateTimeArrayNullableProperty2, DateTime?[]>(new DateTime?[] { new DateTime(2000, 7, 6, 02, 20, 0), null });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeArrayNullableProperties()
		{
			yield return RunTest<DateTimeArrayNullableProperties1, DateTime?[]>(new DateTime?[] { new DateTime(2022, 1, 1, 17, 42, 0), null }, new DateTime?[] { null, new DateTime(2000, 7, 6, 02, 20, 0) });
			yield return RunTest<DateTimeArrayNullableProperties2, DateTime?[]>(new DateTime?[] { null, new DateTime(2022, 1, 1, 17, 42, 0) }, new DateTime?[] { new DateTime(2000, 7, 6, 02, 20, 0), null });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeListField()
		{
			yield return RunTest<DateTimeListField1, List<DateTime>>(new List<DateTime> { new DateTime(2022, 1, 1, 17, 42, 0), new DateTime(2000, 7, 6, 02, 20, 0) });
			yield return RunTest<DateTimeListField2, List<DateTime>>(new List<DateTime> { new DateTime(2000, 7, 6, 02, 20, 0), new DateTime(2022, 1, 1, 17, 42, 0) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeListFields()
		{
			yield return RunTest<DateTimeListFields1, List<DateTime>>(new List<DateTime> { new DateTime(2022, 1, 1, 17, 42, 0), new DateTime(2000, 7, 6, 02, 20, 0) }, new List<DateTime> { new DateTime(2022, 1, 1, 17, 42, 0), new DateTime(2000, 7, 6, 02, 20, 0) });
			yield return RunTest<DateTimeListFields2, List<DateTime>>(new List<DateTime> { new DateTime(2000, 7, 6, 02, 20, 0), new DateTime(2022, 1, 1, 17, 42, 0) }, new List<DateTime> { new DateTime(2000, 7, 6, 02, 20, 0), new DateTime(2022, 1, 1, 17, 42, 0) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeListProperty()
		{
			yield return RunTest<DateTimeListProperty1, List<DateTime>>(new List<DateTime> { new DateTime(2022, 1, 1, 17, 42, 0), new DateTime(2000, 7, 6, 02, 20, 0) });
			yield return RunTest<DateTimeListProperty2, List<DateTime>>(new List<DateTime> { new DateTime(2000, 7, 6, 02, 20, 0), new DateTime(2022, 1, 1, 17, 42, 0) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeListProperties()
		{
			yield return RunTest<DateTimeListProperties1, List<DateTime>>(new List<DateTime> { new DateTime(2022, 1, 1, 17, 42, 0), new DateTime(2000, 7, 6, 02, 20, 0) }, new List<DateTime> { new DateTime(2022, 1, 1, 17, 42, 0), new DateTime(2000, 7, 6, 02, 20, 0) });
			yield return RunTest<DateTimeListProperties2, List<DateTime>>(new List<DateTime> { new DateTime(2000, 7, 6, 02, 20, 0), new DateTime(2022, 1, 1, 17, 42, 0) }, new List<DateTime> { new DateTime(2000, 7, 6, 02, 20, 0), new DateTime(2022, 1, 1, 17, 42, 0) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeListNullableField()
		{
			yield return RunTest<DateTimeListNullableField1, List<DateTime?>>(new List<DateTime?> { null, new DateTime(2000, 7, 6, 02, 20, 0) });
			yield return RunTest<DateTimeListNullableField2, List<DateTime?>>(new List<DateTime?> { new DateTime(2000, 7, 6, 02, 20, 0), null });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeListNullableFields()
		{
			yield return RunTest<DateTimeListNullableFields1, List<DateTime?>>(new List<DateTime?> { null, new DateTime(2000, 7, 6, 02, 20, 0) }, new List<DateTime?> { new DateTime(2022, 1, 1, 17, 42, 0), null });
			yield return RunTest<DateTimeListNullableFields2, List<DateTime?>>(new List<DateTime?> { new DateTime(2000, 7, 6, 02, 20, 0), null }, new List<DateTime?> { null, new DateTime(2022, 1, 1, 17, 42, 0) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeListNullableProperty()
		{
			yield return RunTest<DateTimeListNullableProperty1, List<DateTime?>>(new List<DateTime?> { null, new DateTime(2000, 7, 6, 02, 20, 0) });
			yield return RunTest<DateTimeListNullableProperty2, List<DateTime?>>(new List<DateTime?> { new DateTime(2000, 7, 6, 02, 20, 0), null });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeListNullableProperties()
		{
			yield return RunTest<DateTimeListNullableProperties1, List<DateTime?>>(new List<DateTime?> { new DateTime(2022, 1, 1, 17, 42, 0), null }, new List<DateTime?> { null, new DateTime(2000, 7, 6, 02, 20, 0) });
			yield return RunTest<DateTimeListNullableProperties2, List<DateTime?>>(new List<DateTime?> { null, new DateTime(2022, 1, 1, 17, 42, 0) }, new List<DateTime?> { new DateTime(2000, 7, 6, 02, 20, 0), null });
		}
		#endregion

		#region Uri
		[UnityTest]
		public IEnumerator SaveUriField()
		{
			yield return RunTest<UriField1, Uri>(new Uri("https://hertzole.github.io/advanced-level-editor"));
			yield return RunTest<UriField2, Uri>(new Uri("https://www.hertzole.se"));
		}

		[UnityTest]
		public IEnumerator SaveUriFields()
		{
			yield return RunTest<UriFields1, Uri>(new Uri("https://www.hertzole.se"), new Uri("https://hertzole.github.io/advanced-level-editor"));
			yield return RunTest<UriFields2, Uri>(new Uri("https://hertzole.github.io/advanced-level-editor"), new Uri("https://www.hertzole.se"));
		}

		[UnityTest]
		public IEnumerator SaveUriProperty()
		{
			yield return RunTest<UriProperty1, Uri>(new Uri("https://hertzole.github.io/advanced-level-editor"));
			yield return RunTest<UriProperty2, Uri>(new Uri("https://www.hertzole.se"));
		}

		[UnityTest]
		public IEnumerator SaveUriProperties()
		{
			yield return RunTest<UriProperties1, Uri>(new Uri("https://www.hertzole.se"), new Uri("https://hertzole.github.io/advanced-level-editor"));
			yield return RunTest<UriProperties2, Uri>(new Uri("https://hertzole.github.io/advanced-level-editor"), new Uri("https://www.hertzole.se"));
		}

		[UnityTest]
		public IEnumerator SaveUriNullableField()
		{
			yield return RunTest<UriField1, Uri>(new Uri("https://hertzole.github.io/advanced-level-editor"));
			yield return RunTest<UriField2, Uri>(new Uri("https://www.hertzole.se"));
			yield return RunTest<UriField1, Uri>(null);
			yield return RunTest<UriField2, Uri>(null);
		}

		[UnityTest]
		public IEnumerator SaveUriNullableFields()
		{
			yield return RunTest<UriFields1, Uri>(new Uri("https://www.hertzole.se"), new Uri("https://hertzole.github.io/advanced-level-editor"));
			yield return RunTest<UriFields2, Uri>(new Uri("https://hertzole.github.io/advanced-level-editor"), new Uri("https://www.hertzole.se"));
			yield return RunTest<UriFields1, Uri>(null, new Uri("https://hertzole.github.io/advanced-level-editor"));
			yield return RunTest<UriFields2, Uri>(new Uri("https://hertzole.github.io/advanced-level-editor"), null);
		}

		[UnityTest]
		public IEnumerator SaveUriNullableProperty()
		{
			yield return RunTest<UriProperty1, Uri>(new Uri("https://hertzole.github.io/advanced-level-editor"));
			yield return RunTest<UriProperty2, Uri>(new Uri("https://www.hertzole.se"));
			yield return RunTest<UriProperty1, Uri>(null);
			yield return RunTest<UriProperty2, Uri>(null);
		}

		[UnityTest]
		public IEnumerator SaveUriNullableProperties()
		{
			yield return RunTest<UriProperties1, Uri>(null, new Uri("https://hertzole.github.io/advanced-level-editor"));
			yield return RunTest<UriProperties2, Uri>(new Uri("https://hertzole.github.io/advanced-level-editor"), null);
		}

		[UnityTest]
		public IEnumerator SaveUriArrayField()
		{
			yield return RunTest<UriArrayField1, Uri[]>(new[] { new Uri("https://hertzole.github.io/advanced-level-editor"), new Uri("https://www.hertzole.se") });
			yield return RunTest<UriArrayField2, Uri[]>(new[] { new Uri("https://www.hertzole.se"), new Uri("https://hertzole.github.io/advanced-level-editor") });
		}

		[UnityTest]
		public IEnumerator SaveUriArrayFields()
		{
			yield return RunTest<UriArrayFields1, Uri[]>(new[] { new Uri("https://hertzole.github.io/advanced-level-editor"), new Uri("https://www.hertzole.se") }, new[] { new Uri("https://www.hertzole.se/gaming/blasters/"), new Uri("https://www.twitter.com/hertzole") });
			yield return RunTest<UriArrayFields2, Uri[]>(new[] { new Uri("https://www.hertzole.se"), new Uri("https://hertzole.github.io/advanced-level-editor") }, new[] { new Uri("https://www.twitter.com/hertzole"), new Uri("https://www.hertzole.se/gaming/blasters/") });
		}

		[UnityTest]
		public IEnumerator SaveUriArrayProperty()
		{
			yield return RunTest<UriArrayProperty1, Uri[]>(new[] { new Uri("https://hertzole.github.io/advanced-level-editor"), new Uri("https://www.hertzole.se") });
			yield return RunTest<UriArrayProperty2, Uri[]>(new[] { new Uri("https://www.hertzole.se"), new Uri("https://hertzole.github.io/advanced-level-editor") });
		}

		[UnityTest]
		public IEnumerator SaveUriArrayProperties()
		{
			yield return RunTest<UriArrayProperties1, Uri[]>(new[] { new Uri("https://hertzole.github.io/advanced-level-editor"), new Uri("https://www.hertzole.se") }, new[] { new Uri("https://www.hertzole.se/gaming/blasters/"), new Uri("https://www.twitter.com/hertzole") });
			yield return RunTest<UriArrayProperties2, Uri[]>(new[] { new Uri("https://www.hertzole.se"), new Uri("https://hertzole.github.io/advanced-level-editor") }, new[] { new Uri("https://www.twitter.com/hertzole"), new Uri("https://www.hertzole.se/gaming/blasters/") });
		}

		[UnityTest]
		public IEnumerator SaveUriArrayNullableField()
		{
			yield return RunTest<UriArrayField1, Uri[]>(new[] { null, new Uri("https://www.hertzole.se") });
			yield return RunTest<UriArrayField2, Uri[]>(new[] { new Uri("https://www.hertzole.se"), null });
		}

		[UnityTest]
		public IEnumerator SaveUriArrayNullableFields()
		{
			yield return RunTest<UriArrayFields1, Uri[]>(new[] { null, new Uri("https://www.hertzole.se") }, new[] { new Uri("https://www.hertzole.se/gaming/blasters/"), null });
			yield return RunTest<UriArrayFields2, Uri[]>(new[] { new Uri("https://www.hertzole.se"), null }, new[] { null, new Uri("https://www.hertzole.se/gaming/blasters/") });
		}

		[UnityTest]
		public IEnumerator SaveUriArrayNullableProperty()
		{
			yield return RunTest<UriArrayProperty1, Uri[]>(new[] { null, new Uri("https://www.hertzole.se") });
			yield return RunTest<UriArrayProperty2, Uri[]>(new[] { new Uri("https://www.hertzole.se"), null });
		}

		[UnityTest]
		public IEnumerator SaveUriArrayNullableProperties()
		{
			yield return RunTest<UriArrayProperties1, Uri[]>(new[] { new Uri("https://hertzole.github.io/advanced-level-editor"), null }, new[] { null, new Uri("https://www.twitter.com/hertzole") });
			yield return RunTest<UriArrayProperties2, Uri[]>(new[] { null, new Uri("https://hertzole.github.io/advanced-level-editor") }, new[] { new Uri("https://www.twitter.com/hertzole"), null });
		}

		[UnityTest]
		public IEnumerator SaveUriListField()
		{
			yield return RunTest<UriListField1, List<Uri>>(new List<Uri> { new Uri("https://hertzole.github.io/advanced-level-editor"), new Uri("https://www.hertzole.se") });
			yield return RunTest<UriListField2, List<Uri>>(new List<Uri> { new Uri("https://www.hertzole.se"), new Uri("https://hertzole.github.io/advanced-level-editor") });
		}

		[UnityTest]
		public IEnumerator SaveUriListFields()
		{
			yield return RunTest<UriListFields1, List<Uri>>(new List<Uri> { new Uri("https://hertzole.github.io/advanced-level-editor"), new Uri("https://www.hertzole.se") }, new List<Uri> { new Uri("https://www.hertzole.se/gaming/blasters/"), new Uri("https://www.twitter.com/hertzole") });
			yield return RunTest<UriListFields2, List<Uri>>(new List<Uri> { new Uri("https://www.hertzole.se"), new Uri("https://hertzole.github.io/advanced-level-editor") }, new List<Uri> { new Uri("https://www.twitter.com/hertzole"), new Uri("https://www.hertzole.se/gaming/blasters/") });
		}

		[UnityTest]
		public IEnumerator SaveUriListProperty()
		{
			yield return RunTest<UriListProperty1, List<Uri>>(new List<Uri> { new Uri("https://hertzole.github.io/advanced-level-editor"), new Uri("https://www.hertzole.se") });
			yield return RunTest<UriListProperty2, List<Uri>>(new List<Uri> { new Uri("https://www.hertzole.se"), new Uri("https://hertzole.github.io/advanced-level-editor") });
		}

		[UnityTest]
		public IEnumerator SaveUriListProperties()
		{
			yield return RunTest<UriListProperties1, List<Uri>>(new List<Uri> { new Uri("https://hertzole.github.io/advanced-level-editor"), new Uri("https://www.hertzole.se") }, new List<Uri> { new Uri("https://www.hertzole.se/gaming/blasters/"), new Uri("https://www.twitter.com/hertzole") });
			yield return RunTest<UriListProperties2, List<Uri>>(new List<Uri> { new Uri("https://www.hertzole.se"), new Uri("https://hertzole.github.io/advanced-level-editor") }, new List<Uri> { new Uri("https://www.twitter.com/hertzole"), new Uri("https://www.hertzole.se/gaming/blasters/") });
		}

		[UnityTest]
		public IEnumerator SaveUriListNullableField()
		{
			yield return RunTest<UriListField1, List<Uri>>(new List<Uri> { null, new Uri("https://www.hertzole.se") });
			yield return RunTest<UriListField2, List<Uri>>(new List<Uri> { new Uri("https://www.hertzole.se"), null });
		}

		[UnityTest]
		public IEnumerator SaveUriListNullableFields()
		{
			yield return RunTest<UriListFields1, List<Uri>>(new List<Uri> { null, new Uri("https://www.hertzole.se") }, new List<Uri> { new Uri("https://www.hertzole.se/gaming/blasters/"), null });
			yield return RunTest<UriListFields2, List<Uri>>(new List<Uri> { new Uri("https://www.hertzole.se"), null }, new List<Uri> { null, new Uri("https://www.hertzole.se/gaming/blasters/") });
		}

		[UnityTest]
		public IEnumerator SaveUriListNullableProperty()
		{
			yield return RunTest<UriListProperty1, List<Uri>>(new List<Uri> { null, new Uri("https://www.hertzole.se") });
			yield return RunTest<UriListProperty2, List<Uri>>(new List<Uri> { new Uri("https://www.hertzole.se"), null });
		}

		[UnityTest]
		public IEnumerator SaveUriListNullableProperties()
		{
			yield return RunTest<UriListProperties1, List<Uri>>(new List<Uri> { new Uri("https://hertzole.github.io/advanced-level-editor"), null }, new List<Uri> { null, new Uri("https://www.twitter.com/hertzole") });
			yield return RunTest<UriListProperties2, List<Uri>>(new List<Uri> { null, new Uri("https://hertzole.github.io/advanced-level-editor") }, new List<Uri> { new Uri("https://www.twitter.com/hertzole"), null });
		}
		#endregion
	}
}