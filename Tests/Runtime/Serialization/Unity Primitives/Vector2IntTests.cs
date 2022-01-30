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
		public IEnumerator SaveVector2IntField()
		{
			yield return RunTest<Vector2IntField1, Vector2Int>(new Vector2Int(1479, 1166));
			yield return RunTest<Vector2IntField2, Vector2Int>(new Vector2Int(346, 736));
		}

		[UnityTest]
		public IEnumerator SaveVector2IntFields()
		{
			yield return RunTest<Vector2IntFields1, Vector2Int>(new Vector2Int(346, 736), new Vector2Int(1479, 1166));
			yield return RunTest<Vector2IntFields2, Vector2Int>(new Vector2Int(1479, 1166), new Vector2Int(346, 736));
		}

		[UnityTest]
		public IEnumerator SaveVector2IntProperty()
		{
			yield return RunTest<Vector2IntProperty1, Vector2Int>(new Vector2Int(1479, 1166));
			yield return RunTest<Vector2IntProperty2, Vector2Int>(new Vector2Int(346, 736));
		}

		[UnityTest]
		public IEnumerator SaveVector2IntProperties()
		{
			yield return RunTest<Vector2IntProperties1, Vector2Int>(new Vector2Int(346, 736), new Vector2Int(1479, 1166));
			yield return RunTest<Vector2IntProperties2, Vector2Int>(new Vector2Int(1479, 1166), new Vector2Int(346, 736));
		}

		[UnityTest]
		public IEnumerator SaveVector2IntNullableField()
		{
			yield return RunTest<Vector2IntNullableField1, Vector2Int?>(new Vector2Int(1479, 1166));
			yield return RunTest<Vector2IntNullableField2, Vector2Int?>(new Vector2Int(346, 736));
			yield return RunTest<Vector2IntNullableField1, Vector2Int?>(null);
			yield return RunTest<Vector2IntNullableField2, Vector2Int?>(null);
		}

		[UnityTest]
		public IEnumerator SaveVector2IntNullableFields()
		{
			yield return RunTest<Vector2IntNullableFields1, Vector2Int?>(new Vector2Int(346, 736), new Vector2Int(1479, 1166));
			yield return RunTest<Vector2IntNullableFields2, Vector2Int?>(new Vector2Int(1479, 1166), new Vector2Int(346, 736));
			yield return RunTest<Vector2IntNullableFields1, Vector2Int?>(null, new Vector2Int(1479, 1166));
			yield return RunTest<Vector2IntNullableFields2, Vector2Int?>(new Vector2Int(1479, 1166), null);
		}

		[UnityTest]
		public IEnumerator SaveVector2IntNullableProperty()
		{
			yield return RunTest<Vector2IntNullableProperty1, Vector2Int?>(new Vector2Int(1479, 1166));
			yield return RunTest<Vector2IntNullableProperty2, Vector2Int?>(new Vector2Int(346, 736));
			yield return RunTest<Vector2IntNullableProperty1, Vector2Int?>(null);
			yield return RunTest<Vector2IntNullableProperty2, Vector2Int?>(null);
		}

		[UnityTest]
		public IEnumerator SaveVector2IntNullableProperties()
		{
			yield return RunTest<Vector2IntNullableProperties1, Vector2Int?>(new Vector2Int(346, 736), new Vector2Int(1479, 1166));
			yield return RunTest<Vector2IntNullableProperties2, Vector2Int?>(new Vector2Int(1479, 1166), new Vector2Int(346, 736));
			yield return RunTest<Vector2IntNullableProperties1, Vector2Int?>(null, new Vector2Int(1479, 1166));
			yield return RunTest<Vector2IntNullableProperties2, Vector2Int?>(new Vector2Int(1479, 1166), null);
		}

		[UnityTest]
		public IEnumerator SaveVector2IntArrayField()
		{
			yield return RunTest<Vector2IntArrayField1, Vector2Int[]>(new Vector2Int[] { new Vector2Int(1479, 1166), new Vector2Int(346, 736) });
			yield return RunTest<Vector2IntArrayField2, Vector2Int[]>(new Vector2Int[] { new Vector2Int(346, 736), new Vector2Int(1479, 1166) });
		}

		[UnityTest]
		public IEnumerator SaveVector2IntArrayFields()
		{
			yield return RunTest<Vector2IntArrayFields1, Vector2Int[]>(new Vector2Int[] { new Vector2Int(1479, 1166), new Vector2Int(346, 736) }, new Vector2Int[] { new Vector2Int(1628, 1863), new Vector2Int(1977, 774) });
			yield return RunTest<Vector2IntArrayFields2, Vector2Int[]>(new Vector2Int[] { new Vector2Int(346, 736), new Vector2Int(1479, 1166) }, new Vector2Int[] { new Vector2Int(1977, 774), new Vector2Int(1628, 1863) });
		}

		[UnityTest]
		public IEnumerator SaveVector2IntArrayProperty()
		{
			yield return RunTest<Vector2IntArrayProperty1, Vector2Int[]>(new Vector2Int[] { new Vector2Int(1479, 1166), new Vector2Int(346, 736) });
			yield return RunTest<Vector2IntArrayProperty2, Vector2Int[]>(new Vector2Int[] { new Vector2Int(346, 736), new Vector2Int(1479, 1166) });
		}

		[UnityTest]
		public IEnumerator SaveVector2IntArrayProperties()
		{
			yield return RunTest<Vector2IntArrayProperties1, Vector2Int[]>(new Vector2Int[] { new Vector2Int(1479, 1166), new Vector2Int(346, 736) }, new Vector2Int[] { new Vector2Int(1628, 1863), new Vector2Int(1977, 774) });
			yield return RunTest<Vector2IntArrayProperties2, Vector2Int[]>(new Vector2Int[] { new Vector2Int(346, 736), new Vector2Int(1479, 1166) }, new Vector2Int[] { new Vector2Int(1977, 774), new Vector2Int(1628, 1863) });
		}

		[UnityTest]
		public IEnumerator SaveVector2IntArrayNullableField()
		{
			yield return RunTest<Vector2IntArrayNullableField1, Vector2Int?[]>(new Vector2Int?[] { null, new Vector2Int(346, 736) });
			yield return RunTest<Vector2IntArrayNullableField2, Vector2Int?[]>(new Vector2Int?[] { new Vector2Int(346, 736), null });
		}

		[UnityTest]
		public IEnumerator SaveVector2IntArrayNullableFields()
		{
			yield return RunTest<Vector2IntArrayNullableFields1, Vector2Int?[]>(new Vector2Int?[] { null, new Vector2Int(346, 736) }, new Vector2Int?[] { new Vector2Int(1628, 1863), null });
			yield return RunTest<Vector2IntArrayNullableFields2, Vector2Int?[]>(new Vector2Int?[] { new Vector2Int(346, 736), null }, new Vector2Int?[] { null, new Vector2Int(1628, 1863) });
		}

		[UnityTest]
		public IEnumerator SaveVector2IntArrayNullableProperty()
		{
			yield return RunTest<Vector2IntArrayNullableProperty1, Vector2Int?[]>(new Vector2Int?[] { null, new Vector2Int(346, 736) });
			yield return RunTest<Vector2IntArrayNullableProperty2, Vector2Int?[]>(new Vector2Int?[] { new Vector2Int(346, 736), null });
		}

		[UnityTest]
		public IEnumerator SaveVector2IntArrayNullableProperties()
		{
			yield return RunTest<Vector2IntArrayNullableProperties1, Vector2Int?[]>(new Vector2Int?[] { new Vector2Int(1479, 1166), null }, new Vector2Int?[] { null, new Vector2Int(1977, 774) });
			yield return RunTest<Vector2IntArrayNullableProperties2, Vector2Int?[]>(new Vector2Int?[] { null, new Vector2Int(1479, 1166) }, new Vector2Int?[] { new Vector2Int(1977, 774), null });
		}

		[UnityTest]
		public IEnumerator SaveVector2IntListField()
		{
			yield return RunTest<Vector2IntListField1, List<Vector2Int>>(new List<Vector2Int> { new Vector2Int(1479, 1166), new Vector2Int(346, 736) });
			yield return RunTest<Vector2IntListField2, List<Vector2Int>>(new List<Vector2Int> { new Vector2Int(346, 736), new Vector2Int(1479, 1166) });
		}

		[UnityTest]
		public IEnumerator SaveVector2IntListFields()
		{
			yield return RunTest<Vector2IntListFields1, List<Vector2Int>>(new List<Vector2Int> { new Vector2Int(1479, 1166), new Vector2Int(346, 736) }, new List<Vector2Int> { new Vector2Int(1628, 1863), new Vector2Int(1977, 774) });
			yield return RunTest<Vector2IntListFields2, List<Vector2Int>>(new List<Vector2Int> { new Vector2Int(346, 736), new Vector2Int(1479, 1166) }, new List<Vector2Int> { new Vector2Int(1977, 774), new Vector2Int(1628, 1863) });
		}

		[UnityTest]
		public IEnumerator SaveVector2IntListProperty()
		{
			yield return RunTest<Vector2IntListProperty1, List<Vector2Int>>(new List<Vector2Int> { new Vector2Int(1479, 1166), new Vector2Int(346, 736) });
			yield return RunTest<Vector2IntListProperty2, List<Vector2Int>>(new List<Vector2Int> { new Vector2Int(346, 736), new Vector2Int(1479, 1166) });
		}

		[UnityTest]
		public IEnumerator SaveVector2IntListProperties()
		{
			yield return RunTest<Vector2IntListProperties1, List<Vector2Int>>(new List<Vector2Int> { new Vector2Int(1479, 1166), new Vector2Int(346, 736) }, new List<Vector2Int> { new Vector2Int(1628, 1863), new Vector2Int(1977, 774) });
			yield return RunTest<Vector2IntListProperties2, List<Vector2Int>>(new List<Vector2Int> { new Vector2Int(346, 736), new Vector2Int(1479, 1166) }, new List<Vector2Int> { new Vector2Int(1977, 774), new Vector2Int(1628, 1863) });
		}

		[UnityTest]
		public IEnumerator SaveVector2IntListNullableField()
		{
			yield return RunTest<Vector2IntListNullableField1, List<Vector2Int?>>(new List<Vector2Int?> { null, new Vector2Int(346, 736) });
			yield return RunTest<Vector2IntListNullableField2, List<Vector2Int?>>(new List<Vector2Int?> { new Vector2Int(346, 736), null });
		}

		[UnityTest]
		public IEnumerator SaveVector2IntListNullableFields()
		{
			yield return RunTest<Vector2IntListNullableFields1, List<Vector2Int?>>(new List<Vector2Int?> { null, new Vector2Int(346, 736) }, new List<Vector2Int?> { new Vector2Int(1628, 1863), null });
			yield return RunTest<Vector2IntListNullableFields2, List<Vector2Int?>>(new List<Vector2Int?> { new Vector2Int(346, 736), null }, new List<Vector2Int?> { null, new Vector2Int(1628, 1863) });
		}

		[UnityTest]
		public IEnumerator SaveVector2IntListNullableProperty()
		{
			yield return RunTest<Vector2IntListNullableProperty1, List<Vector2Int?>>(new List<Vector2Int?> { null, new Vector2Int(346, 736) });
			yield return RunTest<Vector2IntListNullableProperty2, List<Vector2Int?>>(new List<Vector2Int?> { new Vector2Int(346, 736), null });
		}

		[UnityTest]
		public IEnumerator SaveVector2IntListNullableProperties()
		{
			yield return RunTest<Vector2IntListNullableProperties1, List<Vector2Int?>>(new List<Vector2Int?> { new Vector2Int(1479, 1166), null }, new List<Vector2Int?> { null, new Vector2Int(1977, 774) });
			yield return RunTest<Vector2IntListNullableProperties2, List<Vector2Int?>>(new List<Vector2Int?> { null, new Vector2Int(1479, 1166) }, new List<Vector2Int?> { new Vector2Int(1977, 774), null });
		}
	}
}