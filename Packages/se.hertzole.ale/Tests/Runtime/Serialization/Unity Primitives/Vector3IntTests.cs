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
		public IEnumerator SaveVector3IntField()
		{
			yield return RunTest<Vector3IntField1, Vector3Int>(new Vector3Int(179, 1748, 699));
			yield return RunTest<Vector3IntField2, Vector3Int>(new Vector3Int(1338, 708, 691));
		}

		[UnityTest]
		public IEnumerator SaveVector3IntFields()
		{
			yield return RunTest<Vector3IntFields1, Vector3Int>(new Vector3Int(1338, 708, 691), new Vector3Int(179, 1748, 699));
			yield return RunTest<Vector3IntFields2, Vector3Int>(new Vector3Int(179, 1748, 699), new Vector3Int(1338, 708, 691));
		}

		[UnityTest]
		public IEnumerator SaveVector3IntProperty()
		{
			yield return RunTest<Vector3IntProperty1, Vector3Int>(new Vector3Int(179, 1748, 699));
			yield return RunTest<Vector3IntProperty2, Vector3Int>(new Vector3Int(1338, 708, 691));
		}

		[UnityTest]
		public IEnumerator SaveVector3IntProperties()
		{
			yield return RunTest<Vector3IntProperties1, Vector3Int>(new Vector3Int(1338, 708, 691), new Vector3Int(179, 1748, 699));
			yield return RunTest<Vector3IntProperties2, Vector3Int>(new Vector3Int(179, 1748, 699), new Vector3Int(1338, 708, 691));
		}

		[UnityTest]
		public IEnumerator SaveVector3IntNullableField()
		{
			yield return RunTest<Vector3IntNullableField1, Vector3Int?>(new Vector3Int(179, 1748, 699));
			yield return RunTest<Vector3IntNullableField2, Vector3Int?>(new Vector3Int(1338, 708, 691));
			yield return RunTest<Vector3IntNullableField1, Vector3Int?>(null);
			yield return RunTest<Vector3IntNullableField2, Vector3Int?>(null);
		}

		[UnityTest]
		public IEnumerator SaveVector3IntNullableFields()
		{
			yield return RunTest<Vector3IntNullableFields1, Vector3Int?>(new Vector3Int(1338, 708, 691), new Vector3Int(179, 1748, 699));
			yield return RunTest<Vector3IntNullableFields2, Vector3Int?>(new Vector3Int(179, 1748, 699), new Vector3Int(1338, 708, 691));
			yield return RunTest<Vector3IntNullableFields1, Vector3Int?>(null, new Vector3Int(179, 1748, 699));
			yield return RunTest<Vector3IntNullableFields2, Vector3Int?>(new Vector3Int(179, 1748, 699), null);
		}

		[UnityTest]
		public IEnumerator SaveVector3IntNullableProperty()
		{
			yield return RunTest<Vector3IntNullableProperty1, Vector3Int?>(new Vector3Int(179, 1748, 699));
			yield return RunTest<Vector3IntNullableProperty2, Vector3Int?>(new Vector3Int(1338, 708, 691));
			yield return RunTest<Vector3IntNullableProperty1, Vector3Int?>(null);
			yield return RunTest<Vector3IntNullableProperty2, Vector3Int?>(null);
		}

		[UnityTest]
		public IEnumerator SaveVector3IntNullableProperties()
		{
			yield return RunTest<Vector3IntNullableProperties1, Vector3Int?>(new Vector3Int(1338, 708, 691), new Vector3Int(179, 1748, 699));
			yield return RunTest<Vector3IntNullableProperties2, Vector3Int?>(new Vector3Int(179, 1748, 699), new Vector3Int(1338, 708, 691));
			yield return RunTest<Vector3IntNullableProperties1, Vector3Int?>(null, new Vector3Int(179, 1748, 699));
			yield return RunTest<Vector3IntNullableProperties2, Vector3Int?>(new Vector3Int(179, 1748, 699), null);
		}

		[UnityTest]
		public IEnumerator SaveVector3IntArrayField()
		{
			yield return RunTest<Vector3IntArrayField1, Vector3Int[]>(new Vector3Int[] { new Vector3Int(179, 1748, 699), new Vector3Int(1338, 708, 691) });
			yield return RunTest<Vector3IntArrayField2, Vector3Int[]>(new Vector3Int[] { new Vector3Int(1338, 708, 691), new Vector3Int(179, 1748, 699) });
		}

		[UnityTest]
		public IEnumerator SaveVector3IntArrayFields()
		{
			yield return RunTest<Vector3IntArrayFields1, Vector3Int[]>(new Vector3Int[] { new Vector3Int(179, 1748, 699), new Vector3Int(1338, 708, 691) }, new Vector3Int[] { new Vector3Int(39, 971, 1930), new Vector3Int(207, 803, 792) });
			yield return RunTest<Vector3IntArrayFields2, Vector3Int[]>(new Vector3Int[] { new Vector3Int(1338, 708, 691), new Vector3Int(179, 1748, 699) }, new Vector3Int[] { new Vector3Int(207, 803, 792), new Vector3Int(39, 971, 1930) });
		}

		[UnityTest]
		public IEnumerator SaveVector3IntArrayProperty()
		{
			yield return RunTest<Vector3IntArrayProperty1, Vector3Int[]>(new Vector3Int[] { new Vector3Int(179, 1748, 699), new Vector3Int(1338, 708, 691) });
			yield return RunTest<Vector3IntArrayProperty2, Vector3Int[]>(new Vector3Int[] { new Vector3Int(1338, 708, 691), new Vector3Int(179, 1748, 699) });
		}

		[UnityTest]
		public IEnumerator SaveVector3IntArrayProperties()
		{
			yield return RunTest<Vector3IntArrayProperties1, Vector3Int[]>(new Vector3Int[] { new Vector3Int(179, 1748, 699), new Vector3Int(1338, 708, 691) }, new Vector3Int[] { new Vector3Int(39, 971, 1930), new Vector3Int(207, 803, 792) });
			yield return RunTest<Vector3IntArrayProperties2, Vector3Int[]>(new Vector3Int[] { new Vector3Int(1338, 708, 691), new Vector3Int(179, 1748, 699) }, new Vector3Int[] { new Vector3Int(207, 803, 792), new Vector3Int(39, 971, 1930) });
		}

		[UnityTest]
		public IEnumerator SaveVector3IntArrayNullableField()
		{
			yield return RunTest<Vector3IntArrayNullableField1, Vector3Int?[]>(new Vector3Int?[] { null, new Vector3Int(1338, 708, 691) });
			yield return RunTest<Vector3IntArrayNullableField2, Vector3Int?[]>(new Vector3Int?[] { new Vector3Int(1338, 708, 691), null });
		}

		[UnityTest]
		public IEnumerator SaveVector3IntArrayNullableFields()
		{
			yield return RunTest<Vector3IntArrayNullableFields1, Vector3Int?[]>(new Vector3Int?[] { null, new Vector3Int(1338, 708, 691) }, new Vector3Int?[] { new Vector3Int(39, 971, 1930), null });
			yield return RunTest<Vector3IntArrayNullableFields2, Vector3Int?[]>(new Vector3Int?[] { new Vector3Int(1338, 708, 691), null }, new Vector3Int?[] { null, new Vector3Int(39, 971, 1930) });
		}

		[UnityTest]
		public IEnumerator SaveVector3IntArrayNullableProperty()
		{
			yield return RunTest<Vector3IntArrayNullableProperty1, Vector3Int?[]>(new Vector3Int?[] { null, new Vector3Int(1338, 708, 691) });
			yield return RunTest<Vector3IntArrayNullableProperty2, Vector3Int?[]>(new Vector3Int?[] { new Vector3Int(1338, 708, 691), null });
		}

		[UnityTest]
		public IEnumerator SaveVector3IntArrayNullableProperties()
		{
			yield return RunTest<Vector3IntArrayNullableProperties1, Vector3Int?[]>(new Vector3Int?[] { new Vector3Int(179, 1748, 699), null }, new Vector3Int?[] { null, new Vector3Int(207, 803, 792) });
			yield return RunTest<Vector3IntArrayNullableProperties2, Vector3Int?[]>(new Vector3Int?[] { null, new Vector3Int(179, 1748, 699) }, new Vector3Int?[] { new Vector3Int(207, 803, 792), null });
		}

		[UnityTest]
		public IEnumerator SaveVector3IntListField()
		{
			yield return RunTest<Vector3IntListField1, List<Vector3Int>>(new List<Vector3Int> { new Vector3Int(179, 1748, 699), new Vector3Int(1338, 708, 691) });
			yield return RunTest<Vector3IntListField2, List<Vector3Int>>(new List<Vector3Int> { new Vector3Int(1338, 708, 691), new Vector3Int(179, 1748, 699) });
		}

		[UnityTest]
		public IEnumerator SaveVector3IntListFields()
		{
			yield return RunTest<Vector3IntListFields1, List<Vector3Int>>(new List<Vector3Int> { new Vector3Int(179, 1748, 699), new Vector3Int(1338, 708, 691) }, new List<Vector3Int> { new Vector3Int(39, 971, 1930), new Vector3Int(207, 803, 792) });
			yield return RunTest<Vector3IntListFields2, List<Vector3Int>>(new List<Vector3Int> { new Vector3Int(1338, 708, 691), new Vector3Int(179, 1748, 699) }, new List<Vector3Int> { new Vector3Int(207, 803, 792), new Vector3Int(39, 971, 1930) });
		}

		[UnityTest]
		public IEnumerator SaveVector3IntListProperty()
		{
			yield return RunTest<Vector3IntListProperty1, List<Vector3Int>>(new List<Vector3Int> { new Vector3Int(179, 1748, 699), new Vector3Int(1338, 708, 691) });
			yield return RunTest<Vector3IntListProperty2, List<Vector3Int>>(new List<Vector3Int> { new Vector3Int(1338, 708, 691), new Vector3Int(179, 1748, 699) });
		}

		[UnityTest]
		public IEnumerator SaveVector3IntListProperties()
		{
			yield return RunTest<Vector3IntListProperties1, List<Vector3Int>>(new List<Vector3Int> { new Vector3Int(179, 1748, 699), new Vector3Int(1338, 708, 691) }, new List<Vector3Int> { new Vector3Int(39, 971, 1930), new Vector3Int(207, 803, 792) });
			yield return RunTest<Vector3IntListProperties2, List<Vector3Int>>(new List<Vector3Int> { new Vector3Int(1338, 708, 691), new Vector3Int(179, 1748, 699) }, new List<Vector3Int> { new Vector3Int(207, 803, 792), new Vector3Int(39, 971, 1930) });
		}

		[UnityTest]
		public IEnumerator SaveVector3IntListNullableField()
		{
			yield return RunTest<Vector3IntListNullableField1, List<Vector3Int?>>(new List<Vector3Int?> { null, new Vector3Int(1338, 708, 691) });
			yield return RunTest<Vector3IntListNullableField2, List<Vector3Int?>>(new List<Vector3Int?> { new Vector3Int(1338, 708, 691), null });
		}

		[UnityTest]
		public IEnumerator SaveVector3IntListNullableFields()
		{
			yield return RunTest<Vector3IntListNullableFields1, List<Vector3Int?>>(new List<Vector3Int?> { null, new Vector3Int(1338, 708, 691) }, new List<Vector3Int?> { new Vector3Int(39, 971, 1930), null });
			yield return RunTest<Vector3IntListNullableFields2, List<Vector3Int?>>(new List<Vector3Int?> { new Vector3Int(1338, 708, 691), null }, new List<Vector3Int?> { null, new Vector3Int(39, 971, 1930) });
		}

		[UnityTest]
		public IEnumerator SaveVector3IntListNullableProperty()
		{
			yield return RunTest<Vector3IntListNullableProperty1, List<Vector3Int?>>(new List<Vector3Int?> { null, new Vector3Int(1338, 708, 691) });
			yield return RunTest<Vector3IntListNullableProperty2, List<Vector3Int?>>(new List<Vector3Int?> { new Vector3Int(1338, 708, 691), null });
		}

		[UnityTest]
		public IEnumerator SaveVector3IntListNullableProperties()
		{
			yield return RunTest<Vector3IntListNullableProperties1, List<Vector3Int?>>(new List<Vector3Int?> { new Vector3Int(179, 1748, 699), null }, new List<Vector3Int?> { null, new Vector3Int(207, 803, 792) });
			yield return RunTest<Vector3IntListNullableProperties2, List<Vector3Int?>>(new List<Vector3Int?> { null, new Vector3Int(179, 1748, 699) }, new List<Vector3Int?> { new Vector3Int(207, 803, 792), null });
		}
	}
}