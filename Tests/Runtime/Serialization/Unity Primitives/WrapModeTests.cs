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
		public IEnumerator SaveWrapModeField()
		{
			yield return RunTest<WrapModeField1, WrapMode>(WrapMode.Once);
			yield return RunTest<WrapModeField2, WrapMode>(WrapMode.Clamp);
		}

		[UnityTest]
		public IEnumerator SaveWrapModeFields()
		{
			yield return RunTest<WrapModeFields1, WrapMode>(WrapMode.Clamp, WrapMode.Once);
			yield return RunTest<WrapModeFields2, WrapMode>(WrapMode.Once, WrapMode.Clamp);
		}

		[UnityTest]
		public IEnumerator SaveWrapModeProperty()
		{
			yield return RunTest<WrapModeProperty1, WrapMode>(WrapMode.Once);
			yield return RunTest<WrapModeProperty2, WrapMode>(WrapMode.Clamp);
		}

		[UnityTest]
		public IEnumerator SaveWrapModeProperties()
		{
			yield return RunTest<WrapModeProperties1, WrapMode>(WrapMode.Clamp, WrapMode.Once);
			yield return RunTest<WrapModeProperties2, WrapMode>(WrapMode.Once, WrapMode.Clamp);
		}

		[UnityTest]
		public IEnumerator SaveWrapModeNullableField()
		{
			yield return RunTest<WrapModeNullableField1, WrapMode?>(WrapMode.Once);
			yield return RunTest<WrapModeNullableField2, WrapMode?>(WrapMode.Clamp);
			yield return RunTest<WrapModeNullableField1, WrapMode?>(null);
			yield return RunTest<WrapModeNullableField2, WrapMode?>(null);
		}

		[UnityTest]
		public IEnumerator SaveWrapModeNullableFields()
		{
			yield return RunTest<WrapModeNullableFields1, WrapMode?>(WrapMode.Clamp, WrapMode.Once);
			yield return RunTest<WrapModeNullableFields2, WrapMode?>(WrapMode.Once, WrapMode.Clamp);
			yield return RunTest<WrapModeNullableFields1, WrapMode?>(null, WrapMode.Once);
			yield return RunTest<WrapModeNullableFields2, WrapMode?>(WrapMode.Once, null);
		}

		[UnityTest]
		public IEnumerator SaveWrapModeNullableProperty()
		{
			yield return RunTest<WrapModeNullableProperty1, WrapMode?>(WrapMode.Once);
			yield return RunTest<WrapModeNullableProperty2, WrapMode?>(WrapMode.Clamp);
			yield return RunTest<WrapModeNullableProperty1, WrapMode?>(null);
			yield return RunTest<WrapModeNullableProperty2, WrapMode?>(null);
		}

		[UnityTest]
		public IEnumerator SaveWrapModeNullableProperties()
		{
			yield return RunTest<WrapModeNullableProperties1, WrapMode?>(WrapMode.Clamp, WrapMode.Once);
			yield return RunTest<WrapModeNullableProperties2, WrapMode?>(WrapMode.Once, WrapMode.Clamp);
			yield return RunTest<WrapModeNullableProperties1, WrapMode?>(null, WrapMode.Once);
			yield return RunTest<WrapModeNullableProperties2, WrapMode?>(WrapMode.Once, null);
		}

		[UnityTest]
		public IEnumerator SaveWrapModeArrayField()
		{
			yield return RunTest<WrapModeArrayField1, WrapMode[]>(new WrapMode[] { WrapMode.Once, WrapMode.Clamp });
			yield return RunTest<WrapModeArrayField2, WrapMode[]>(new WrapMode[] { WrapMode.Clamp, WrapMode.Once });
		}

		[UnityTest]
		public IEnumerator SaveWrapModeArrayFields()
		{
			yield return RunTest<WrapModeArrayFields1, WrapMode[]>(new WrapMode[] { WrapMode.Once, WrapMode.Clamp }, new WrapMode[] { WrapMode.PingPong, WrapMode.Default });
			yield return RunTest<WrapModeArrayFields2, WrapMode[]>(new WrapMode[] { WrapMode.Clamp, WrapMode.Once }, new WrapMode[] { WrapMode.Default, WrapMode.PingPong });
		}

		[UnityTest]
		public IEnumerator SaveWrapModeArrayProperty()
		{
			yield return RunTest<WrapModeArrayProperty1, WrapMode[]>(new WrapMode[] { WrapMode.Once, WrapMode.Clamp });
			yield return RunTest<WrapModeArrayProperty2, WrapMode[]>(new WrapMode[] { WrapMode.Clamp, WrapMode.Once });
		}

		[UnityTest]
		public IEnumerator SaveWrapModeArrayProperties()
		{
			yield return RunTest<WrapModeArrayProperties1, WrapMode[]>(new WrapMode[] { WrapMode.Once, WrapMode.Clamp }, new WrapMode[] { WrapMode.PingPong, WrapMode.Default });
			yield return RunTest<WrapModeArrayProperties2, WrapMode[]>(new WrapMode[] { WrapMode.Clamp, WrapMode.Once }, new WrapMode[] { WrapMode.Default, WrapMode.PingPong });
		}

		[UnityTest]
		public IEnumerator SaveWrapModeArrayNullableField()
		{
			yield return RunTest<WrapModeArrayNullableField1, WrapMode?[]>(new WrapMode?[] { null, WrapMode.Clamp });
			yield return RunTest<WrapModeArrayNullableField2, WrapMode?[]>(new WrapMode?[] { WrapMode.Clamp, null });
		}

		[UnityTest]
		public IEnumerator SaveWrapModeArrayNullableFields()
		{
			yield return RunTest<WrapModeArrayNullableFields1, WrapMode?[]>(new WrapMode?[] { null, WrapMode.Clamp }, new WrapMode?[] { WrapMode.PingPong, null });
			yield return RunTest<WrapModeArrayNullableFields2, WrapMode?[]>(new WrapMode?[] { WrapMode.Clamp, null }, new WrapMode?[] { null, WrapMode.PingPong });
		}

		[UnityTest]
		public IEnumerator SaveWrapModeArrayNullableProperty()
		{
			yield return RunTest<WrapModeArrayNullableProperty1, WrapMode?[]>(new WrapMode?[] { null, WrapMode.Clamp });
			yield return RunTest<WrapModeArrayNullableProperty2, WrapMode?[]>(new WrapMode?[] { WrapMode.Clamp, null });
		}

		[UnityTest]
		public IEnumerator SaveWrapModeArrayNullableProperties()
		{
			yield return RunTest<WrapModeArrayNullableProperties1, WrapMode?[]>(new WrapMode?[] { WrapMode.Once, null }, new WrapMode?[] { null, WrapMode.Default });
			yield return RunTest<WrapModeArrayNullableProperties2, WrapMode?[]>(new WrapMode?[] { null, WrapMode.Once }, new WrapMode?[] { WrapMode.Default, null });
		}

		[UnityTest]
		public IEnumerator SaveWrapModeListField()
		{
			yield return RunTest<WrapModeListField1, List<WrapMode>>(new List<WrapMode> { WrapMode.Once, WrapMode.Clamp });
			yield return RunTest<WrapModeListField2, List<WrapMode>>(new List<WrapMode> { WrapMode.Clamp, WrapMode.Once });
		}

		[UnityTest]
		public IEnumerator SaveWrapModeListFields()
		{
			yield return RunTest<WrapModeListFields1, List<WrapMode>>(new List<WrapMode> { WrapMode.Once, WrapMode.Clamp }, new List<WrapMode> { WrapMode.PingPong, WrapMode.Default });
			yield return RunTest<WrapModeListFields2, List<WrapMode>>(new List<WrapMode> { WrapMode.Clamp, WrapMode.Once }, new List<WrapMode> { WrapMode.Default, WrapMode.PingPong });
		}

		[UnityTest]
		public IEnumerator SaveWrapModeListProperty()
		{
			yield return RunTest<WrapModeListProperty1, List<WrapMode>>(new List<WrapMode> { WrapMode.Once, WrapMode.Clamp });
			yield return RunTest<WrapModeListProperty2, List<WrapMode>>(new List<WrapMode> { WrapMode.Clamp, WrapMode.Once });
		}

		[UnityTest]
		public IEnumerator SaveWrapModeListProperties()
		{
			yield return RunTest<WrapModeListProperties1, List<WrapMode>>(new List<WrapMode> { WrapMode.Once, WrapMode.Clamp }, new List<WrapMode> { WrapMode.PingPong, WrapMode.Default });
			yield return RunTest<WrapModeListProperties2, List<WrapMode>>(new List<WrapMode> { WrapMode.Clamp, WrapMode.Once }, new List<WrapMode> { WrapMode.Default, WrapMode.PingPong });
		}

		[UnityTest]
		public IEnumerator SaveWrapModeListNullableField()
		{
			yield return RunTest<WrapModeListNullableField1, List<WrapMode?>>(new List<WrapMode?> { null, WrapMode.Clamp });
			yield return RunTest<WrapModeListNullableField2, List<WrapMode?>>(new List<WrapMode?> { WrapMode.Clamp, null });
		}

		[UnityTest]
		public IEnumerator SaveWrapModeListNullableFields()
		{
			yield return RunTest<WrapModeListNullableFields1, List<WrapMode?>>(new List<WrapMode?> { null, WrapMode.Clamp }, new List<WrapMode?> { WrapMode.PingPong, null });
			yield return RunTest<WrapModeListNullableFields2, List<WrapMode?>>(new List<WrapMode?> { WrapMode.Clamp, null }, new List<WrapMode?> { null, WrapMode.PingPong });
		}

		[UnityTest]
		public IEnumerator SaveWrapModeListNullableProperty()
		{
			yield return RunTest<WrapModeListNullableProperty1, List<WrapMode?>>(new List<WrapMode?> { null, WrapMode.Clamp });
			yield return RunTest<WrapModeListNullableProperty2, List<WrapMode?>>(new List<WrapMode?> { WrapMode.Clamp, null });
		}

		[UnityTest]
		public IEnumerator SaveWrapModeListNullableProperties()
		{
			yield return RunTest<WrapModeListNullableProperties1, List<WrapMode?>>(new List<WrapMode?> { WrapMode.Once, null }, new List<WrapMode?> { null, WrapMode.Default });
			yield return RunTest<WrapModeListNullableProperties2, List<WrapMode?>>(new List<WrapMode?> { null, WrapMode.Once }, new List<WrapMode?> { WrapMode.Default, null });
		}
	}
}