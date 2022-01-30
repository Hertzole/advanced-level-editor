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
		public IEnumerator SaveKeyframeField()
		{
			yield return RunTest<KeyframeField1, Keyframe>(new Keyframe(0.82F, 1.00F, 0.36F, 0.69F));
			yield return RunTest<KeyframeField2, Keyframe>(new Keyframe(0.22F, 0.70F, 0.89F, 0.25F));
		}

		[UnityTest]
		public IEnumerator SaveKeyframeFields()
		{
			yield return RunTest<KeyframeFields1, Keyframe>(new Keyframe(0.22F, 0.70F, 0.89F, 0.25F), new Keyframe(0.82F, 1.00F, 0.36F, 0.69F));
			yield return RunTest<KeyframeFields2, Keyframe>(new Keyframe(0.82F, 1.00F, 0.36F, 0.69F), new Keyframe(0.22F, 0.70F, 0.89F, 0.25F));
		}

		[UnityTest]
		public IEnumerator SaveKeyframeProperty()
		{
			yield return RunTest<KeyframeProperty1, Keyframe>(new Keyframe(0.82F, 1.00F, 0.36F, 0.69F));
			yield return RunTest<KeyframeProperty2, Keyframe>(new Keyframe(0.22F, 0.70F, 0.89F, 0.25F));
		}

		[UnityTest]
		public IEnumerator SaveKeyframeProperties()
		{
			yield return RunTest<KeyframeProperties1, Keyframe>(new Keyframe(0.22F, 0.70F, 0.89F, 0.25F), new Keyframe(0.82F, 1.00F, 0.36F, 0.69F));
			yield return RunTest<KeyframeProperties2, Keyframe>(new Keyframe(0.82F, 1.00F, 0.36F, 0.69F), new Keyframe(0.22F, 0.70F, 0.89F, 0.25F));
		}

		[UnityTest]
		public IEnumerator SaveKeyframeNullableField()
		{
			yield return RunTest<KeyframeNullableField1, Keyframe?>(new Keyframe(0.82F, 1.00F, 0.36F, 0.69F));
			yield return RunTest<KeyframeNullableField2, Keyframe?>(new Keyframe(0.22F, 0.70F, 0.89F, 0.25F));
			yield return RunTest<KeyframeNullableField1, Keyframe?>(null);
			yield return RunTest<KeyframeNullableField2, Keyframe?>(null);
		}

		[UnityTest]
		public IEnumerator SaveKeyframeNullableFields()
		{
			yield return RunTest<KeyframeNullableFields1, Keyframe?>(new Keyframe(0.22F, 0.70F, 0.89F, 0.25F), new Keyframe(0.82F, 1.00F, 0.36F, 0.69F));
			yield return RunTest<KeyframeNullableFields2, Keyframe?>(new Keyframe(0.82F, 1.00F, 0.36F, 0.69F), new Keyframe(0.22F, 0.70F, 0.89F, 0.25F));
			yield return RunTest<KeyframeNullableFields1, Keyframe?>(null, new Keyframe(0.82F, 1.00F, 0.36F, 0.69F));
			yield return RunTest<KeyframeNullableFields2, Keyframe?>(new Keyframe(0.82F, 1.00F, 0.36F, 0.69F), null);
		}

		[UnityTest]
		public IEnumerator SaveKeyframeNullableProperty()
		{
			yield return RunTest<KeyframeNullableProperty1, Keyframe?>(new Keyframe(0.82F, 1.00F, 0.36F, 0.69F));
			yield return RunTest<KeyframeNullableProperty2, Keyframe?>(new Keyframe(0.22F, 0.70F, 0.89F, 0.25F));
			yield return RunTest<KeyframeNullableProperty1, Keyframe?>(null);
			yield return RunTest<KeyframeNullableProperty2, Keyframe?>(null);
		}

		[UnityTest]
		public IEnumerator SaveKeyframeNullableProperties()
		{
			yield return RunTest<KeyframeNullableProperties1, Keyframe?>(new Keyframe(0.22F, 0.70F, 0.89F, 0.25F), new Keyframe(0.82F, 1.00F, 0.36F, 0.69F));
			yield return RunTest<KeyframeNullableProperties2, Keyframe?>(new Keyframe(0.82F, 1.00F, 0.36F, 0.69F), new Keyframe(0.22F, 0.70F, 0.89F, 0.25F));
			yield return RunTest<KeyframeNullableProperties1, Keyframe?>(null, new Keyframe(0.82F, 1.00F, 0.36F, 0.69F));
			yield return RunTest<KeyframeNullableProperties2, Keyframe?>(new Keyframe(0.82F, 1.00F, 0.36F, 0.69F), null);
		}

		[UnityTest]
		public IEnumerator SaveKeyframeArrayField()
		{
			yield return RunTest<KeyframeArrayField1, Keyframe[]>(new Keyframe[] { new Keyframe(0.82F, 1.00F, 0.36F, 0.69F), new Keyframe(0.22F, 0.70F, 0.89F, 0.25F) });
			yield return RunTest<KeyframeArrayField2, Keyframe[]>(new Keyframe[] { new Keyframe(0.22F, 0.70F, 0.89F, 0.25F), new Keyframe(0.82F, 1.00F, 0.36F, 0.69F) });
		}

		[UnityTest]
		public IEnumerator SaveKeyframeArrayFields()
		{
			yield return RunTest<KeyframeArrayFields1, Keyframe[]>(new Keyframe[] { new Keyframe(0.82F, 1.00F, 0.36F, 0.69F), new Keyframe(0.22F, 0.70F, 0.89F, 0.25F) }, new Keyframe[] { new Keyframe(0.91F, 0.05F, 0.94F, 0.84F), new Keyframe(0.89F, 0.36F, 0.82F, 0.67F) });
			yield return RunTest<KeyframeArrayFields2, Keyframe[]>(new Keyframe[] { new Keyframe(0.22F, 0.70F, 0.89F, 0.25F), new Keyframe(0.82F, 1.00F, 0.36F, 0.69F) }, new Keyframe[] { new Keyframe(0.89F, 0.36F, 0.82F, 0.67F), new Keyframe(0.91F, 0.05F, 0.94F, 0.84F) });
		}

		[UnityTest]
		public IEnumerator SaveKeyframeArrayProperty()
		{
			yield return RunTest<KeyframeArrayProperty1, Keyframe[]>(new Keyframe[] { new Keyframe(0.82F, 1.00F, 0.36F, 0.69F), new Keyframe(0.22F, 0.70F, 0.89F, 0.25F) });
			yield return RunTest<KeyframeArrayProperty2, Keyframe[]>(new Keyframe[] { new Keyframe(0.22F, 0.70F, 0.89F, 0.25F), new Keyframe(0.82F, 1.00F, 0.36F, 0.69F) });
		}

		[UnityTest]
		public IEnumerator SaveKeyframeArrayProperties()
		{
			yield return RunTest<KeyframeArrayProperties1, Keyframe[]>(new Keyframe[] { new Keyframe(0.82F, 1.00F, 0.36F, 0.69F), new Keyframe(0.22F, 0.70F, 0.89F, 0.25F) }, new Keyframe[] { new Keyframe(0.91F, 0.05F, 0.94F, 0.84F), new Keyframe(0.89F, 0.36F, 0.82F, 0.67F) });
			yield return RunTest<KeyframeArrayProperties2, Keyframe[]>(new Keyframe[] { new Keyframe(0.22F, 0.70F, 0.89F, 0.25F), new Keyframe(0.82F, 1.00F, 0.36F, 0.69F) }, new Keyframe[] { new Keyframe(0.89F, 0.36F, 0.82F, 0.67F), new Keyframe(0.91F, 0.05F, 0.94F, 0.84F) });
		}

		[UnityTest]
		public IEnumerator SaveKeyframeArrayNullableField()
		{
			yield return RunTest<KeyframeArrayNullableField1, Keyframe?[]>(new Keyframe?[] { null, new Keyframe(0.22F, 0.70F, 0.89F, 0.25F) });
			yield return RunTest<KeyframeArrayNullableField2, Keyframe?[]>(new Keyframe?[] { new Keyframe(0.22F, 0.70F, 0.89F, 0.25F), null });
		}

		[UnityTest]
		public IEnumerator SaveKeyframeArrayNullableFields()
		{
			yield return RunTest<KeyframeArrayNullableFields1, Keyframe?[]>(new Keyframe?[] { null, new Keyframe(0.22F, 0.70F, 0.89F, 0.25F) }, new Keyframe?[] { new Keyframe(0.91F, 0.05F, 0.94F, 0.84F), null });
			yield return RunTest<KeyframeArrayNullableFields2, Keyframe?[]>(new Keyframe?[] { new Keyframe(0.22F, 0.70F, 0.89F, 0.25F), null }, new Keyframe?[] { null, new Keyframe(0.91F, 0.05F, 0.94F, 0.84F) });
		}

		[UnityTest]
		public IEnumerator SaveKeyframeArrayNullableProperty()
		{
			yield return RunTest<KeyframeArrayNullableProperty1, Keyframe?[]>(new Keyframe?[] { null, new Keyframe(0.22F, 0.70F, 0.89F, 0.25F) });
			yield return RunTest<KeyframeArrayNullableProperty2, Keyframe?[]>(new Keyframe?[] { new Keyframe(0.22F, 0.70F, 0.89F, 0.25F), null });
		}

		[UnityTest]
		public IEnumerator SaveKeyframeArrayNullableProperties()
		{
			yield return RunTest<KeyframeArrayNullableProperties1, Keyframe?[]>(new Keyframe?[] { new Keyframe(0.82F, 1.00F, 0.36F, 0.69F), null }, new Keyframe?[] { null, new Keyframe(0.89F, 0.36F, 0.82F, 0.67F) });
			yield return RunTest<KeyframeArrayNullableProperties2, Keyframe?[]>(new Keyframe?[] { null, new Keyframe(0.82F, 1.00F, 0.36F, 0.69F) }, new Keyframe?[] { new Keyframe(0.89F, 0.36F, 0.82F, 0.67F), null });
		}

		[UnityTest]
		public IEnumerator SaveKeyframeListField()
		{
			yield return RunTest<KeyframeListField1, List<Keyframe>>(new List<Keyframe> { new Keyframe(0.82F, 1.00F, 0.36F, 0.69F), new Keyframe(0.22F, 0.70F, 0.89F, 0.25F) });
			yield return RunTest<KeyframeListField2, List<Keyframe>>(new List<Keyframe> { new Keyframe(0.22F, 0.70F, 0.89F, 0.25F), new Keyframe(0.82F, 1.00F, 0.36F, 0.69F) });
		}

		[UnityTest]
		public IEnumerator SaveKeyframeListFields()
		{
			yield return RunTest<KeyframeListFields1, List<Keyframe>>(new List<Keyframe> { new Keyframe(0.82F, 1.00F, 0.36F, 0.69F), new Keyframe(0.22F, 0.70F, 0.89F, 0.25F) }, new List<Keyframe> { new Keyframe(0.91F, 0.05F, 0.94F, 0.84F), new Keyframe(0.89F, 0.36F, 0.82F, 0.67F) });
			yield return RunTest<KeyframeListFields2, List<Keyframe>>(new List<Keyframe> { new Keyframe(0.22F, 0.70F, 0.89F, 0.25F), new Keyframe(0.82F, 1.00F, 0.36F, 0.69F) }, new List<Keyframe> { new Keyframe(0.89F, 0.36F, 0.82F, 0.67F), new Keyframe(0.91F, 0.05F, 0.94F, 0.84F) });
		}

		[UnityTest]
		public IEnumerator SaveKeyframeListProperty()
		{
			yield return RunTest<KeyframeListProperty1, List<Keyframe>>(new List<Keyframe> { new Keyframe(0.82F, 1.00F, 0.36F, 0.69F), new Keyframe(0.22F, 0.70F, 0.89F, 0.25F) });
			yield return RunTest<KeyframeListProperty2, List<Keyframe>>(new List<Keyframe> { new Keyframe(0.22F, 0.70F, 0.89F, 0.25F), new Keyframe(0.82F, 1.00F, 0.36F, 0.69F) });
		}

		[UnityTest]
		public IEnumerator SaveKeyframeListProperties()
		{
			yield return RunTest<KeyframeListProperties1, List<Keyframe>>(new List<Keyframe> { new Keyframe(0.82F, 1.00F, 0.36F, 0.69F), new Keyframe(0.22F, 0.70F, 0.89F, 0.25F) }, new List<Keyframe> { new Keyframe(0.91F, 0.05F, 0.94F, 0.84F), new Keyframe(0.89F, 0.36F, 0.82F, 0.67F) });
			yield return RunTest<KeyframeListProperties2, List<Keyframe>>(new List<Keyframe> { new Keyframe(0.22F, 0.70F, 0.89F, 0.25F), new Keyframe(0.82F, 1.00F, 0.36F, 0.69F) }, new List<Keyframe> { new Keyframe(0.89F, 0.36F, 0.82F, 0.67F), new Keyframe(0.91F, 0.05F, 0.94F, 0.84F) });
		}

		[UnityTest]
		public IEnumerator SaveKeyframeListNullableField()
		{
			yield return RunTest<KeyframeListNullableField1, List<Keyframe?>>(new List<Keyframe?> { null, new Keyframe(0.22F, 0.70F, 0.89F, 0.25F) });
			yield return RunTest<KeyframeListNullableField2, List<Keyframe?>>(new List<Keyframe?> { new Keyframe(0.22F, 0.70F, 0.89F, 0.25F), null });
		}

		[UnityTest]
		public IEnumerator SaveKeyframeListNullableFields()
		{
			yield return RunTest<KeyframeListNullableFields1, List<Keyframe?>>(new List<Keyframe?> { null, new Keyframe(0.22F, 0.70F, 0.89F, 0.25F) }, new List<Keyframe?> { new Keyframe(0.91F, 0.05F, 0.94F, 0.84F), null });
			yield return RunTest<KeyframeListNullableFields2, List<Keyframe?>>(new List<Keyframe?> { new Keyframe(0.22F, 0.70F, 0.89F, 0.25F), null }, new List<Keyframe?> { null, new Keyframe(0.91F, 0.05F, 0.94F, 0.84F) });
		}

		[UnityTest]
		public IEnumerator SaveKeyframeListNullableProperty()
		{
			yield return RunTest<KeyframeListNullableProperty1, List<Keyframe?>>(new List<Keyframe?> { null, new Keyframe(0.22F, 0.70F, 0.89F, 0.25F) });
			yield return RunTest<KeyframeListNullableProperty2, List<Keyframe?>>(new List<Keyframe?> { new Keyframe(0.22F, 0.70F, 0.89F, 0.25F), null });
		}

		[UnityTest]
		public IEnumerator SaveKeyframeListNullableProperties()
		{
			yield return RunTest<KeyframeListNullableProperties1, List<Keyframe?>>(new List<Keyframe?> { new Keyframe(0.82F, 1.00F, 0.36F, 0.69F), null }, new List<Keyframe?> { null, new Keyframe(0.89F, 0.36F, 0.82F, 0.67F) });
			yield return RunTest<KeyframeListNullableProperties2, List<Keyframe?>>(new List<Keyframe?> { null, new Keyframe(0.82F, 1.00F, 0.36F, 0.69F) }, new List<Keyframe?> { new Keyframe(0.89F, 0.36F, 0.82F, 0.67F), null });
		}
	}
}