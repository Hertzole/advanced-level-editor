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
		public IEnumerator SaveBoundsIntField()
		{
			yield return RunTest<BoundsIntField1, BoundsInt>(new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)));
			yield return RunTest<BoundsIntField2, BoundsInt>(new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)));
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntFields()
		{
			yield return RunTest<BoundsIntFields1, BoundsInt>(new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)), new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)));
			yield return RunTest<BoundsIntFields2, BoundsInt>(new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)), new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)));
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntProperty()
		{
			yield return RunTest<BoundsIntProperty1, BoundsInt>(new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)));
			yield return RunTest<BoundsIntProperty2, BoundsInt>(new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)));
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntProperties()
		{
			yield return RunTest<BoundsIntProperties1, BoundsInt>(new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)), new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)));
			yield return RunTest<BoundsIntProperties2, BoundsInt>(new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)), new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)));
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntNullableField()
		{
			yield return RunTest<BoundsIntNullableField1, BoundsInt?>(new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)));
			yield return RunTest<BoundsIntNullableField2, BoundsInt?>(new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)));
			yield return RunTest<BoundsIntNullableField1, BoundsInt?>(null);
			yield return RunTest<BoundsIntNullableField2, BoundsInt?>(null);
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntNullableFields()
		{
			yield return RunTest<BoundsIntNullableFields1, BoundsInt?>(new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)), new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)));
			yield return RunTest<BoundsIntNullableFields2, BoundsInt?>(new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)), new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)));
			yield return RunTest<BoundsIntNullableFields1, BoundsInt?>(null, new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)));
			yield return RunTest<BoundsIntNullableFields2, BoundsInt?>(new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)), null);
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntNullableProperty()
		{
			yield return RunTest<BoundsIntNullableProperty1, BoundsInt?>(new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)));
			yield return RunTest<BoundsIntNullableProperty2, BoundsInt?>(new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)));
			yield return RunTest<BoundsIntNullableProperty1, BoundsInt?>(null);
			yield return RunTest<BoundsIntNullableProperty2, BoundsInt?>(null);
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntNullableProperties()
		{
			yield return RunTest<BoundsIntNullableProperties1, BoundsInt?>(new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)), new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)));
			yield return RunTest<BoundsIntNullableProperties2, BoundsInt?>(new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)), new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)));
			yield return RunTest<BoundsIntNullableProperties1, BoundsInt?>(null, new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)));
			yield return RunTest<BoundsIntNullableProperties2, BoundsInt?>(new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)), null);
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntArrayField()
		{
			yield return RunTest<BoundsIntArrayField1, BoundsInt[]>(new BoundsInt[] { new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)), new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)) });
			yield return RunTest<BoundsIntArrayField2, BoundsInt[]>(new BoundsInt[] { new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)), new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntArrayFields()
		{
			yield return RunTest<BoundsIntArrayFields1, BoundsInt[]>(new BoundsInt[] { new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)), new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)) }, new BoundsInt[] { new BoundsInt(new Vector3Int(1882, 579, 1118), new Vector3Int(1374, 1807, 368)), new BoundsInt(new Vector3Int(1736, 1256, 1784), new Vector3Int(667, 219, 1882)) });
			yield return RunTest<BoundsIntArrayFields2, BoundsInt[]>(new BoundsInt[] { new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)), new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)) }, new BoundsInt[] { new BoundsInt(new Vector3Int(1736, 1256, 1784), new Vector3Int(667, 219, 1882)), new BoundsInt(new Vector3Int(1882, 579, 1118), new Vector3Int(1374, 1807, 368)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntArrayProperty()
		{
			yield return RunTest<BoundsIntArrayProperty1, BoundsInt[]>(new BoundsInt[] { new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)), new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)) });
			yield return RunTest<BoundsIntArrayProperty2, BoundsInt[]>(new BoundsInt[] { new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)), new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntArrayProperties()
		{
			yield return RunTest<BoundsIntArrayProperties1, BoundsInt[]>(new BoundsInt[] { new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)), new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)) }, new BoundsInt[] { new BoundsInt(new Vector3Int(1882, 579, 1118), new Vector3Int(1374, 1807, 368)), new BoundsInt(new Vector3Int(1736, 1256, 1784), new Vector3Int(667, 219, 1882)) });
			yield return RunTest<BoundsIntArrayProperties2, BoundsInt[]>(new BoundsInt[] { new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)), new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)) }, new BoundsInt[] { new BoundsInt(new Vector3Int(1736, 1256, 1784), new Vector3Int(667, 219, 1882)), new BoundsInt(new Vector3Int(1882, 579, 1118), new Vector3Int(1374, 1807, 368)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntArrayNullableField()
		{
			yield return RunTest<BoundsIntArrayNullableField1, BoundsInt?[]>(new BoundsInt?[] { null, new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)) });
			yield return RunTest<BoundsIntArrayNullableField2, BoundsInt?[]>(new BoundsInt?[] { new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)), null });
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntArrayNullableFields()
		{
			yield return RunTest<BoundsIntArrayNullableFields1, BoundsInt?[]>(new BoundsInt?[] { null, new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)) }, new BoundsInt?[] { new BoundsInt(new Vector3Int(1882, 579, 1118), new Vector3Int(1374, 1807, 368)), null });
			yield return RunTest<BoundsIntArrayNullableFields2, BoundsInt?[]>(new BoundsInt?[] { new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)), null }, new BoundsInt?[] { null, new BoundsInt(new Vector3Int(1882, 579, 1118), new Vector3Int(1374, 1807, 368)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntArrayNullableProperty()
		{
			yield return RunTest<BoundsIntArrayNullableProperty1, BoundsInt?[]>(new BoundsInt?[] { null, new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)) });
			yield return RunTest<BoundsIntArrayNullableProperty2, BoundsInt?[]>(new BoundsInt?[] { new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)), null });
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntArrayNullableProperties()
		{
			yield return RunTest<BoundsIntArrayNullableProperties1, BoundsInt?[]>(new BoundsInt?[] { new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)), null }, new BoundsInt?[] { null, new BoundsInt(new Vector3Int(1736, 1256, 1784), new Vector3Int(667, 219, 1882)) });
			yield return RunTest<BoundsIntArrayNullableProperties2, BoundsInt?[]>(new BoundsInt?[] { null, new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)) }, new BoundsInt?[] { new BoundsInt(new Vector3Int(1736, 1256, 1784), new Vector3Int(667, 219, 1882)), null });
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntListField()
		{
			yield return RunTest<BoundsIntListField1, List<BoundsInt>>(new List<BoundsInt> { new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)), new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)) });
			yield return RunTest<BoundsIntListField2, List<BoundsInt>>(new List<BoundsInt> { new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)), new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntListFields()
		{
			yield return RunTest<BoundsIntListFields1, List<BoundsInt>>(new List<BoundsInt> { new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)), new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)) }, new List<BoundsInt> { new BoundsInt(new Vector3Int(1882, 579, 1118), new Vector3Int(1374, 1807, 368)), new BoundsInt(new Vector3Int(1736, 1256, 1784), new Vector3Int(667, 219, 1882)) });
			yield return RunTest<BoundsIntListFields2, List<BoundsInt>>(new List<BoundsInt> { new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)), new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)) }, new List<BoundsInt> { new BoundsInt(new Vector3Int(1736, 1256, 1784), new Vector3Int(667, 219, 1882)), new BoundsInt(new Vector3Int(1882, 579, 1118), new Vector3Int(1374, 1807, 368)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntListProperty()
		{
			yield return RunTest<BoundsIntListProperty1, List<BoundsInt>>(new List<BoundsInt> { new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)), new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)) });
			yield return RunTest<BoundsIntListProperty2, List<BoundsInt>>(new List<BoundsInt> { new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)), new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntListProperties()
		{
			yield return RunTest<BoundsIntListProperties1, List<BoundsInt>>(new List<BoundsInt> { new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)), new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)) }, new List<BoundsInt> { new BoundsInt(new Vector3Int(1882, 579, 1118), new Vector3Int(1374, 1807, 368)), new BoundsInt(new Vector3Int(1736, 1256, 1784), new Vector3Int(667, 219, 1882)) });
			yield return RunTest<BoundsIntListProperties2, List<BoundsInt>>(new List<BoundsInt> { new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)), new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)) }, new List<BoundsInt> { new BoundsInt(new Vector3Int(1736, 1256, 1784), new Vector3Int(667, 219, 1882)), new BoundsInt(new Vector3Int(1882, 579, 1118), new Vector3Int(1374, 1807, 368)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntListNullableField()
		{
			yield return RunTest<BoundsIntListNullableField1, List<BoundsInt?>>(new List<BoundsInt?> { null, new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)) });
			yield return RunTest<BoundsIntListNullableField2, List<BoundsInt?>>(new List<BoundsInt?> { new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)), null });
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntListNullableFields()
		{
			yield return RunTest<BoundsIntListNullableFields1, List<BoundsInt?>>(new List<BoundsInt?> { null, new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)) }, new List<BoundsInt?> { new BoundsInt(new Vector3Int(1882, 579, 1118), new Vector3Int(1374, 1807, 368)), null });
			yield return RunTest<BoundsIntListNullableFields2, List<BoundsInt?>>(new List<BoundsInt?> { new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)), null }, new List<BoundsInt?> { null, new BoundsInt(new Vector3Int(1882, 579, 1118), new Vector3Int(1374, 1807, 368)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntListNullableProperty()
		{
			yield return RunTest<BoundsIntListNullableProperty1, List<BoundsInt?>>(new List<BoundsInt?> { null, new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)) });
			yield return RunTest<BoundsIntListNullableProperty2, List<BoundsInt?>>(new List<BoundsInt?> { new BoundsInt(new Vector3Int(848, 470, 1412), new Vector3Int(422, 1766, 1514)), null });
		}

		[UnityTest]
		public IEnumerator SaveBoundsIntListNullableProperties()
		{
			yield return RunTest<BoundsIntListNullableProperties1, List<BoundsInt?>>(new List<BoundsInt?> { new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)), null }, new List<BoundsInt?> { null, new BoundsInt(new Vector3Int(1736, 1256, 1784), new Vector3Int(667, 219, 1882)) });
			yield return RunTest<BoundsIntListNullableProperties2, List<BoundsInt?>>(new List<BoundsInt?> { null, new BoundsInt(new Vector3Int(1116, 1247, 1333), new Vector3Int(816, 971, 1347)) }, new List<BoundsInt?> { new BoundsInt(new Vector3Int(1736, 1256, 1784), new Vector3Int(667, 219, 1882)), null });
		}
	}
}