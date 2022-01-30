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
		public IEnumerator SaveGradientAlphaKeyField()
		{
			yield return RunTest<GradientAlphaKeyField1, GradientAlphaKey>(new GradientAlphaKey(0.52F, 0.82F));
			yield return RunTest<GradientAlphaKeyField2, GradientAlphaKey>(new GradientAlphaKey(0.22F, 0.72F));
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyFields()
		{
			yield return RunTest<GradientAlphaKeyFields1, GradientAlphaKey>(new GradientAlphaKey(0.22F, 0.72F), new GradientAlphaKey(0.52F, 0.82F));
			yield return RunTest<GradientAlphaKeyFields2, GradientAlphaKey>(new GradientAlphaKey(0.52F, 0.82F), new GradientAlphaKey(0.22F, 0.72F));
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyProperty()
		{
			yield return RunTest<GradientAlphaKeyProperty1, GradientAlphaKey>(new GradientAlphaKey(0.52F, 0.82F));
			yield return RunTest<GradientAlphaKeyProperty2, GradientAlphaKey>(new GradientAlphaKey(0.22F, 0.72F));
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyProperties()
		{
			yield return RunTest<GradientAlphaKeyProperties1, GradientAlphaKey>(new GradientAlphaKey(0.22F, 0.72F), new GradientAlphaKey(0.52F, 0.82F));
			yield return RunTest<GradientAlphaKeyProperties2, GradientAlphaKey>(new GradientAlphaKey(0.52F, 0.82F), new GradientAlphaKey(0.22F, 0.72F));
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyNullableField()
		{
			yield return RunTest<GradientAlphaKeyNullableField1, GradientAlphaKey?>(new GradientAlphaKey(0.52F, 0.82F));
			yield return RunTest<GradientAlphaKeyNullableField2, GradientAlphaKey?>(new GradientAlphaKey(0.22F, 0.72F));
			yield return RunTest<GradientAlphaKeyNullableField1, GradientAlphaKey?>(null);
			yield return RunTest<GradientAlphaKeyNullableField2, GradientAlphaKey?>(null);
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyNullableFields()
		{
			yield return RunTest<GradientAlphaKeyNullableFields1, GradientAlphaKey?>(new GradientAlphaKey(0.22F, 0.72F), new GradientAlphaKey(0.52F, 0.82F));
			yield return RunTest<GradientAlphaKeyNullableFields2, GradientAlphaKey?>(new GradientAlphaKey(0.52F, 0.82F), new GradientAlphaKey(0.22F, 0.72F));
			yield return RunTest<GradientAlphaKeyNullableFields1, GradientAlphaKey?>(null, new GradientAlphaKey(0.52F, 0.82F));
			yield return RunTest<GradientAlphaKeyNullableFields2, GradientAlphaKey?>(new GradientAlphaKey(0.52F, 0.82F), null);
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyNullableProperty()
		{
			yield return RunTest<GradientAlphaKeyNullableProperty1, GradientAlphaKey?>(new GradientAlphaKey(0.52F, 0.82F));
			yield return RunTest<GradientAlphaKeyNullableProperty2, GradientAlphaKey?>(new GradientAlphaKey(0.22F, 0.72F));
			yield return RunTest<GradientAlphaKeyNullableProperty1, GradientAlphaKey?>(null);
			yield return RunTest<GradientAlphaKeyNullableProperty2, GradientAlphaKey?>(null);
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyNullableProperties()
		{
			yield return RunTest<GradientAlphaKeyNullableProperties1, GradientAlphaKey?>(new GradientAlphaKey(0.22F, 0.72F), new GradientAlphaKey(0.52F, 0.82F));
			yield return RunTest<GradientAlphaKeyNullableProperties2, GradientAlphaKey?>(new GradientAlphaKey(0.52F, 0.82F), new GradientAlphaKey(0.22F, 0.72F));
			yield return RunTest<GradientAlphaKeyNullableProperties1, GradientAlphaKey?>(null, new GradientAlphaKey(0.52F, 0.82F));
			yield return RunTest<GradientAlphaKeyNullableProperties2, GradientAlphaKey?>(new GradientAlphaKey(0.52F, 0.82F), null);
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyArrayField()
		{
			yield return RunTest<GradientAlphaKeyArrayField1, GradientAlphaKey[]>(new GradientAlphaKey[] { new GradientAlphaKey(0.52F, 0.82F), new GradientAlphaKey(0.22F, 0.72F) });
			yield return RunTest<GradientAlphaKeyArrayField2, GradientAlphaKey[]>(new GradientAlphaKey[] { new GradientAlphaKey(0.22F, 0.72F), new GradientAlphaKey(0.52F, 0.82F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyArrayFields()
		{
			yield return RunTest<GradientAlphaKeyArrayFields1, GradientAlphaKey[]>(new GradientAlphaKey[] { new GradientAlphaKey(0.52F, 0.82F), new GradientAlphaKey(0.22F, 0.72F) }, new GradientAlphaKey[] { new GradientAlphaKey(0.27F, 0.08F), new GradientAlphaKey(0.09F, 0.72F) });
			yield return RunTest<GradientAlphaKeyArrayFields2, GradientAlphaKey[]>(new GradientAlphaKey[] { new GradientAlphaKey(0.22F, 0.72F), new GradientAlphaKey(0.52F, 0.82F) }, new GradientAlphaKey[] { new GradientAlphaKey(0.09F, 0.72F), new GradientAlphaKey(0.27F, 0.08F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyArrayProperty()
		{
			yield return RunTest<GradientAlphaKeyArrayProperty1, GradientAlphaKey[]>(new GradientAlphaKey[] { new GradientAlphaKey(0.52F, 0.82F), new GradientAlphaKey(0.22F, 0.72F) });
			yield return RunTest<GradientAlphaKeyArrayProperty2, GradientAlphaKey[]>(new GradientAlphaKey[] { new GradientAlphaKey(0.22F, 0.72F), new GradientAlphaKey(0.52F, 0.82F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyArrayProperties()
		{
			yield return RunTest<GradientAlphaKeyArrayProperties1, GradientAlphaKey[]>(new GradientAlphaKey[] { new GradientAlphaKey(0.52F, 0.82F), new GradientAlphaKey(0.22F, 0.72F) }, new GradientAlphaKey[] { new GradientAlphaKey(0.27F, 0.08F), new GradientAlphaKey(0.09F, 0.72F) });
			yield return RunTest<GradientAlphaKeyArrayProperties2, GradientAlphaKey[]>(new GradientAlphaKey[] { new GradientAlphaKey(0.22F, 0.72F), new GradientAlphaKey(0.52F, 0.82F) }, new GradientAlphaKey[] { new GradientAlphaKey(0.09F, 0.72F), new GradientAlphaKey(0.27F, 0.08F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyArrayNullableField()
		{
			yield return RunTest<GradientAlphaKeyArrayNullableField1, GradientAlphaKey?[]>(new GradientAlphaKey?[] { null, new GradientAlphaKey(0.22F, 0.72F) });
			yield return RunTest<GradientAlphaKeyArrayNullableField2, GradientAlphaKey?[]>(new GradientAlphaKey?[] { new GradientAlphaKey(0.22F, 0.72F), null });
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyArrayNullableFields()
		{
			yield return RunTest<GradientAlphaKeyArrayNullableFields1, GradientAlphaKey?[]>(new GradientAlphaKey?[] { null, new GradientAlphaKey(0.22F, 0.72F) }, new GradientAlphaKey?[] { new GradientAlphaKey(0.27F, 0.08F), null });
			yield return RunTest<GradientAlphaKeyArrayNullableFields2, GradientAlphaKey?[]>(new GradientAlphaKey?[] { new GradientAlphaKey(0.22F, 0.72F), null }, new GradientAlphaKey?[] { null, new GradientAlphaKey(0.27F, 0.08F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyArrayNullableProperty()
		{
			yield return RunTest<GradientAlphaKeyArrayNullableProperty1, GradientAlphaKey?[]>(new GradientAlphaKey?[] { null, new GradientAlphaKey(0.22F, 0.72F) });
			yield return RunTest<GradientAlphaKeyArrayNullableProperty2, GradientAlphaKey?[]>(new GradientAlphaKey?[] { new GradientAlphaKey(0.22F, 0.72F), null });
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyArrayNullableProperties()
		{
			yield return RunTest<GradientAlphaKeyArrayNullableProperties1, GradientAlphaKey?[]>(new GradientAlphaKey?[] { new GradientAlphaKey(0.52F, 0.82F), null }, new GradientAlphaKey?[] { null, new GradientAlphaKey(0.09F, 0.72F) });
			yield return RunTest<GradientAlphaKeyArrayNullableProperties2, GradientAlphaKey?[]>(new GradientAlphaKey?[] { null, new GradientAlphaKey(0.52F, 0.82F) }, new GradientAlphaKey?[] { new GradientAlphaKey(0.09F, 0.72F), null });
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyListField()
		{
			yield return RunTest<GradientAlphaKeyListField1, List<GradientAlphaKey>>(new List<GradientAlphaKey> { new GradientAlphaKey(0.52F, 0.82F), new GradientAlphaKey(0.22F, 0.72F) });
			yield return RunTest<GradientAlphaKeyListField2, List<GradientAlphaKey>>(new List<GradientAlphaKey> { new GradientAlphaKey(0.22F, 0.72F), new GradientAlphaKey(0.52F, 0.82F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyListFields()
		{
			yield return RunTest<GradientAlphaKeyListFields1, List<GradientAlphaKey>>(new List<GradientAlphaKey> { new GradientAlphaKey(0.52F, 0.82F), new GradientAlphaKey(0.22F, 0.72F) }, new List<GradientAlphaKey> { new GradientAlphaKey(0.27F, 0.08F), new GradientAlphaKey(0.09F, 0.72F) });
			yield return RunTest<GradientAlphaKeyListFields2, List<GradientAlphaKey>>(new List<GradientAlphaKey> { new GradientAlphaKey(0.22F, 0.72F), new GradientAlphaKey(0.52F, 0.82F) }, new List<GradientAlphaKey> { new GradientAlphaKey(0.09F, 0.72F), new GradientAlphaKey(0.27F, 0.08F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyListProperty()
		{
			yield return RunTest<GradientAlphaKeyListProperty1, List<GradientAlphaKey>>(new List<GradientAlphaKey> { new GradientAlphaKey(0.52F, 0.82F), new GradientAlphaKey(0.22F, 0.72F) });
			yield return RunTest<GradientAlphaKeyListProperty2, List<GradientAlphaKey>>(new List<GradientAlphaKey> { new GradientAlphaKey(0.22F, 0.72F), new GradientAlphaKey(0.52F, 0.82F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyListProperties()
		{
			yield return RunTest<GradientAlphaKeyListProperties1, List<GradientAlphaKey>>(new List<GradientAlphaKey> { new GradientAlphaKey(0.52F, 0.82F), new GradientAlphaKey(0.22F, 0.72F) }, new List<GradientAlphaKey> { new GradientAlphaKey(0.27F, 0.08F), new GradientAlphaKey(0.09F, 0.72F) });
			yield return RunTest<GradientAlphaKeyListProperties2, List<GradientAlphaKey>>(new List<GradientAlphaKey> { new GradientAlphaKey(0.22F, 0.72F), new GradientAlphaKey(0.52F, 0.82F) }, new List<GradientAlphaKey> { new GradientAlphaKey(0.09F, 0.72F), new GradientAlphaKey(0.27F, 0.08F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyListNullableField()
		{
			yield return RunTest<GradientAlphaKeyListNullableField1, List<GradientAlphaKey?>>(new List<GradientAlphaKey?> { null, new GradientAlphaKey(0.22F, 0.72F) });
			yield return RunTest<GradientAlphaKeyListNullableField2, List<GradientAlphaKey?>>(new List<GradientAlphaKey?> { new GradientAlphaKey(0.22F, 0.72F), null });
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyListNullableFields()
		{
			yield return RunTest<GradientAlphaKeyListNullableFields1, List<GradientAlphaKey?>>(new List<GradientAlphaKey?> { null, new GradientAlphaKey(0.22F, 0.72F) }, new List<GradientAlphaKey?> { new GradientAlphaKey(0.27F, 0.08F), null });
			yield return RunTest<GradientAlphaKeyListNullableFields2, List<GradientAlphaKey?>>(new List<GradientAlphaKey?> { new GradientAlphaKey(0.22F, 0.72F), null }, new List<GradientAlphaKey?> { null, new GradientAlphaKey(0.27F, 0.08F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyListNullableProperty()
		{
			yield return RunTest<GradientAlphaKeyListNullableProperty1, List<GradientAlphaKey?>>(new List<GradientAlphaKey?> { null, new GradientAlphaKey(0.22F, 0.72F) });
			yield return RunTest<GradientAlphaKeyListNullableProperty2, List<GradientAlphaKey?>>(new List<GradientAlphaKey?> { new GradientAlphaKey(0.22F, 0.72F), null });
		}

		[UnityTest]
		public IEnumerator SaveGradientAlphaKeyListNullableProperties()
		{
			yield return RunTest<GradientAlphaKeyListNullableProperties1, List<GradientAlphaKey?>>(new List<GradientAlphaKey?> { new GradientAlphaKey(0.52F, 0.82F), null }, new List<GradientAlphaKey?> { null, new GradientAlphaKey(0.09F, 0.72F) });
			yield return RunTest<GradientAlphaKeyListNullableProperties2, List<GradientAlphaKey?>>(new List<GradientAlphaKey?> { null, new GradientAlphaKey(0.52F, 0.82F) }, new List<GradientAlphaKey?> { new GradientAlphaKey(0.09F, 0.72F), null });
		}
	}
}