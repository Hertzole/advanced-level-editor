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
			yield return RunTest<GuidNullableProperties1, Guid?>(Guid.NewGuid(), Guid.NewGuid());
			yield return RunTest<GuidNullableProperties2, Guid?>(Guid.NewGuid(), Guid.NewGuid());
			yield return RunTest<GuidNullableProperties1, Guid?>(null, Guid.NewGuid());
			yield return RunTest<GuidNullableProperties2, Guid?>(Guid.NewGuid(), null);
		}

		[UnityTest]
		public IEnumerator SaveGuidArrayField()
		{
			yield return RunTest<GuidArrayField1, Guid[]>(new Guid[] { Guid.NewGuid(), Guid.NewGuid() });
			yield return RunTest<GuidArrayField2, Guid[]>(new Guid[] { Guid.NewGuid(), Guid.NewGuid() });
		}

		[UnityTest]
		public IEnumerator SaveGuidArrayFields()
		{
			yield return RunTest<GuidArrayFields1, Guid[]>(new Guid[] { Guid.NewGuid(), Guid.NewGuid() }, new Guid[] { Guid.NewGuid(), Guid.NewGuid() });
			yield return RunTest<GuidArrayFields2, Guid[]>(new Guid[] { Guid.NewGuid(), Guid.NewGuid() }, new Guid[] { Guid.NewGuid(), Guid.NewGuid() });
		}

		[UnityTest]
		public IEnumerator SaveGuidArrayProperty()
		{
			yield return RunTest<GuidArrayProperty1, Guid[]>(new Guid[] { Guid.NewGuid(), Guid.NewGuid() });
			yield return RunTest<GuidArrayProperty2, Guid[]>(new Guid[] { Guid.NewGuid(), Guid.NewGuid() });
		}

		[UnityTest]
		public IEnumerator SaveGuidArrayProperties()
		{
			yield return RunTest<GuidArrayProperties1, Guid[]>(new Guid[] { Guid.NewGuid(), Guid.NewGuid() }, new Guid[] { Guid.NewGuid(), Guid.NewGuid() });
			yield return RunTest<GuidArrayProperties2, Guid[]>(new Guid[] { Guid.NewGuid(), Guid.NewGuid() }, new Guid[] { Guid.NewGuid(), Guid.NewGuid() });
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
	}
}