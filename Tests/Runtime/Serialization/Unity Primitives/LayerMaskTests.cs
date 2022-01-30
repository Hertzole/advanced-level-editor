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
		public IEnumerator SaveLayerMaskField()
		{
			yield return RunTest<LayerMaskField1, LayerMask>(new LayerMask() { value = 71 });
			yield return RunTest<LayerMaskField2, LayerMask>(new LayerMask() { value = 97 });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskFields()
		{
			yield return RunTest<LayerMaskFields1, LayerMask>(new LayerMask() { value = 97 }, new LayerMask() { value = 71 });
			yield return RunTest<LayerMaskFields2, LayerMask>(new LayerMask() { value = 71 }, new LayerMask() { value = 97 });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskProperty()
		{
			yield return RunTest<LayerMaskProperty1, LayerMask>(new LayerMask() { value = 71 });
			yield return RunTest<LayerMaskProperty2, LayerMask>(new LayerMask() { value = 97 });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskProperties()
		{
			yield return RunTest<LayerMaskProperties1, LayerMask>(new LayerMask() { value = 97 }, new LayerMask() { value = 71 });
			yield return RunTest<LayerMaskProperties2, LayerMask>(new LayerMask() { value = 71 }, new LayerMask() { value = 97 });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskNullableField()
		{
			yield return RunTest<LayerMaskNullableField1, LayerMask?>(new LayerMask() { value = 71 });
			yield return RunTest<LayerMaskNullableField2, LayerMask?>(new LayerMask() { value = 97 });
			yield return RunTest<LayerMaskNullableField1, LayerMask?>(null);
			yield return RunTest<LayerMaskNullableField2, LayerMask?>(null);
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskNullableFields()
		{
			yield return RunTest<LayerMaskNullableFields1, LayerMask?>(new LayerMask() { value = 97 }, new LayerMask() { value = 71 });
			yield return RunTest<LayerMaskNullableFields2, LayerMask?>(new LayerMask() { value = 71 }, new LayerMask() { value = 97 });
			yield return RunTest<LayerMaskNullableFields1, LayerMask?>(null, new LayerMask() { value = 71 });
			yield return RunTest<LayerMaskNullableFields2, LayerMask?>(new LayerMask() { value = 71 }, null);
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskNullableProperty()
		{
			yield return RunTest<LayerMaskNullableProperty1, LayerMask?>(new LayerMask() { value = 71 });
			yield return RunTest<LayerMaskNullableProperty2, LayerMask?>(new LayerMask() { value = 97 });
			yield return RunTest<LayerMaskNullableProperty1, LayerMask?>(null);
			yield return RunTest<LayerMaskNullableProperty2, LayerMask?>(null);
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskNullableProperties()
		{
			yield return RunTest<LayerMaskNullableProperties1, LayerMask?>(new LayerMask() { value = 97 }, new LayerMask() { value = 71 });
			yield return RunTest<LayerMaskNullableProperties2, LayerMask?>(new LayerMask() { value = 71 }, new LayerMask() { value = 97 });
			yield return RunTest<LayerMaskNullableProperties1, LayerMask?>(null, new LayerMask() { value = 71 });
			yield return RunTest<LayerMaskNullableProperties2, LayerMask?>(new LayerMask() { value = 71 }, null);
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskArrayField()
		{
			yield return RunTest<LayerMaskArrayField1, LayerMask[]>(new LayerMask[] { new LayerMask() { value = 71 }, new LayerMask() { value = 97 } });
			yield return RunTest<LayerMaskArrayField2, LayerMask[]>(new LayerMask[] { new LayerMask() { value = 97 }, new LayerMask() { value = 71 } });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskArrayFields()
		{
			yield return RunTest<LayerMaskArrayFields1, LayerMask[]>(new LayerMask[] { new LayerMask() { value = 71 }, new LayerMask() { value = 97 } }, new LayerMask[] { new LayerMask() { value = 96 }, new LayerMask() { value = 93 } });
			yield return RunTest<LayerMaskArrayFields2, LayerMask[]>(new LayerMask[] { new LayerMask() { value = 97 }, new LayerMask() { value = 71 } }, new LayerMask[] { new LayerMask() { value = 93 }, new LayerMask() { value = 96 } });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskArrayProperty()
		{
			yield return RunTest<LayerMaskArrayProperty1, LayerMask[]>(new LayerMask[] { new LayerMask() { value = 71 }, new LayerMask() { value = 97 } });
			yield return RunTest<LayerMaskArrayProperty2, LayerMask[]>(new LayerMask[] { new LayerMask() { value = 97 }, new LayerMask() { value = 71 } });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskArrayProperties()
		{
			yield return RunTest<LayerMaskArrayProperties1, LayerMask[]>(new LayerMask[] { new LayerMask() { value = 71 }, new LayerMask() { value = 97 } }, new LayerMask[] { new LayerMask() { value = 96 }, new LayerMask() { value = 93 } });
			yield return RunTest<LayerMaskArrayProperties2, LayerMask[]>(new LayerMask[] { new LayerMask() { value = 97 }, new LayerMask() { value = 71 } }, new LayerMask[] { new LayerMask() { value = 93 }, new LayerMask() { value = 96 } });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskArrayNullableField()
		{
			yield return RunTest<LayerMaskArrayNullableField1, LayerMask?[]>(new LayerMask?[] { null, new LayerMask() { value = 97 } });
			yield return RunTest<LayerMaskArrayNullableField2, LayerMask?[]>(new LayerMask?[] { new LayerMask() { value = 97 }, null });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskArrayNullableFields()
		{
			yield return RunTest<LayerMaskArrayNullableFields1, LayerMask?[]>(new LayerMask?[] { null, new LayerMask() { value = 97 } }, new LayerMask?[] { new LayerMask() { value = 96 }, null });
			yield return RunTest<LayerMaskArrayNullableFields2, LayerMask?[]>(new LayerMask?[] { new LayerMask() { value = 97 }, null }, new LayerMask?[] { null, new LayerMask() { value = 96 } });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskArrayNullableProperty()
		{
			yield return RunTest<LayerMaskArrayNullableProperty1, LayerMask?[]>(new LayerMask?[] { null, new LayerMask() { value = 97 } });
			yield return RunTest<LayerMaskArrayNullableProperty2, LayerMask?[]>(new LayerMask?[] { new LayerMask() { value = 97 }, null });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskArrayNullableProperties()
		{
			yield return RunTest<LayerMaskArrayNullableProperties1, LayerMask?[]>(new LayerMask?[] { new LayerMask() { value = 71 }, null }, new LayerMask?[] { null, new LayerMask() { value = 93 } });
			yield return RunTest<LayerMaskArrayNullableProperties2, LayerMask?[]>(new LayerMask?[] { null, new LayerMask() { value = 71 } }, new LayerMask?[] { new LayerMask() { value = 93 }, null });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskListField()
		{
			yield return RunTest<LayerMaskListField1, List<LayerMask>>(new List<LayerMask> { new LayerMask() { value = 71 }, new LayerMask() { value = 97 } });
			yield return RunTest<LayerMaskListField2, List<LayerMask>>(new List<LayerMask> { new LayerMask() { value = 97 }, new LayerMask() { value = 71 } });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskListFields()
		{
			yield return RunTest<LayerMaskListFields1, List<LayerMask>>(new List<LayerMask> { new LayerMask() { value = 71 }, new LayerMask() { value = 97 } }, new List<LayerMask> { new LayerMask() { value = 96 }, new LayerMask() { value = 93 } });
			yield return RunTest<LayerMaskListFields2, List<LayerMask>>(new List<LayerMask> { new LayerMask() { value = 97 }, new LayerMask() { value = 71 } }, new List<LayerMask> { new LayerMask() { value = 93 }, new LayerMask() { value = 96 } });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskListProperty()
		{
			yield return RunTest<LayerMaskListProperty1, List<LayerMask>>(new List<LayerMask> { new LayerMask() { value = 71 }, new LayerMask() { value = 97 } });
			yield return RunTest<LayerMaskListProperty2, List<LayerMask>>(new List<LayerMask> { new LayerMask() { value = 97 }, new LayerMask() { value = 71 } });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskListProperties()
		{
			yield return RunTest<LayerMaskListProperties1, List<LayerMask>>(new List<LayerMask> { new LayerMask() { value = 71 }, new LayerMask() { value = 97 } }, new List<LayerMask> { new LayerMask() { value = 96 }, new LayerMask() { value = 93 } });
			yield return RunTest<LayerMaskListProperties2, List<LayerMask>>(new List<LayerMask> { new LayerMask() { value = 97 }, new LayerMask() { value = 71 } }, new List<LayerMask> { new LayerMask() { value = 93 }, new LayerMask() { value = 96 } });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskListNullableField()
		{
			yield return RunTest<LayerMaskListNullableField1, List<LayerMask?>>(new List<LayerMask?> { null, new LayerMask() { value = 97 } });
			yield return RunTest<LayerMaskListNullableField2, List<LayerMask?>>(new List<LayerMask?> { new LayerMask() { value = 97 }, null });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskListNullableFields()
		{
			yield return RunTest<LayerMaskListNullableFields1, List<LayerMask?>>(new List<LayerMask?> { null, new LayerMask() { value = 97 } }, new List<LayerMask?> { new LayerMask() { value = 96 }, null });
			yield return RunTest<LayerMaskListNullableFields2, List<LayerMask?>>(new List<LayerMask?> { new LayerMask() { value = 97 }, null }, new List<LayerMask?> { null, new LayerMask() { value = 96 } });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskListNullableProperty()
		{
			yield return RunTest<LayerMaskListNullableProperty1, List<LayerMask?>>(new List<LayerMask?> { null, new LayerMask() { value = 97 } });
			yield return RunTest<LayerMaskListNullableProperty2, List<LayerMask?>>(new List<LayerMask?> { new LayerMask() { value = 97 }, null });
		}

		[UnityTest]
		public IEnumerator SaveLayerMaskListNullableProperties()
		{
			yield return RunTest<LayerMaskListNullableProperties1, List<LayerMask?>>(new List<LayerMask?> { new LayerMask() { value = 71 }, null }, new List<LayerMask?> { null, new LayerMask() { value = 93 } });
			yield return RunTest<LayerMaskListNullableProperties2, List<LayerMask?>>(new List<LayerMask?> { null, new LayerMask() { value = 71 } }, new List<LayerMask?> { new LayerMask() { value = 93 }, null });
		}
	}
}