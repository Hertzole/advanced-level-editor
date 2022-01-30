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
		public IEnumerator SaveGradientColorKeyField()
		{
			yield return RunTest<GradientColorKeyField1, GradientColorKey>(new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F));
			yield return RunTest<GradientColorKeyField2, GradientColorKey>(new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F));
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyFields()
		{
			yield return RunTest<GradientColorKeyFields1, GradientColorKey>(new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F), new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F));
			yield return RunTest<GradientColorKeyFields2, GradientColorKey>(new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F), new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F));
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyProperty()
		{
			yield return RunTest<GradientColorKeyProperty1, GradientColorKey>(new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F));
			yield return RunTest<GradientColorKeyProperty2, GradientColorKey>(new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F));
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyProperties()
		{
			yield return RunTest<GradientColorKeyProperties1, GradientColorKey>(new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F), new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F));
			yield return RunTest<GradientColorKeyProperties2, GradientColorKey>(new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F), new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F));
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyNullableField()
		{
			yield return RunTest<GradientColorKeyNullableField1, GradientColorKey?>(new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F));
			yield return RunTest<GradientColorKeyNullableField2, GradientColorKey?>(new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F));
			yield return RunTest<GradientColorKeyNullableField1, GradientColorKey?>(null);
			yield return RunTest<GradientColorKeyNullableField2, GradientColorKey?>(null);
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyNullableFields()
		{
			yield return RunTest<GradientColorKeyNullableFields1, GradientColorKey?>(new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F), new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F));
			yield return RunTest<GradientColorKeyNullableFields2, GradientColorKey?>(new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F), new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F));
			yield return RunTest<GradientColorKeyNullableFields1, GradientColorKey?>(null, new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F));
			yield return RunTest<GradientColorKeyNullableFields2, GradientColorKey?>(new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F), null);
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyNullableProperty()
		{
			yield return RunTest<GradientColorKeyNullableProperty1, GradientColorKey?>(new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F));
			yield return RunTest<GradientColorKeyNullableProperty2, GradientColorKey?>(new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F));
			yield return RunTest<GradientColorKeyNullableProperty1, GradientColorKey?>(null);
			yield return RunTest<GradientColorKeyNullableProperty2, GradientColorKey?>(null);
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyNullableProperties()
		{
			yield return RunTest<GradientColorKeyNullableProperties1, GradientColorKey?>(new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F), new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F));
			yield return RunTest<GradientColorKeyNullableProperties2, GradientColorKey?>(new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F), new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F));
			yield return RunTest<GradientColorKeyNullableProperties1, GradientColorKey?>(null, new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F));
			yield return RunTest<GradientColorKeyNullableProperties2, GradientColorKey?>(new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F), null);
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyArrayField()
		{
			yield return RunTest<GradientColorKeyArrayField1, GradientColorKey[]>(new GradientColorKey[] { new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F), new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F) });
			yield return RunTest<GradientColorKeyArrayField2, GradientColorKey[]>(new GradientColorKey[] { new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F), new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyArrayFields()
		{
			yield return RunTest<GradientColorKeyArrayFields1, GradientColorKey[]>(new GradientColorKey[] { new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F), new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F) }, new GradientColorKey[] { new GradientColorKey(new Color(0.09F, 0.00F, 0.58F, 0.21F), 0.10F), new GradientColorKey(new Color(0.22F, 0.96F, 0.65F, 0.24F), 0.82F) });
			yield return RunTest<GradientColorKeyArrayFields2, GradientColorKey[]>(new GradientColorKey[] { new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F), new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F) }, new GradientColorKey[] { new GradientColorKey(new Color(0.22F, 0.96F, 0.65F, 0.24F), 0.82F), new GradientColorKey(new Color(0.09F, 0.00F, 0.58F, 0.21F), 0.10F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyArrayProperty()
		{
			yield return RunTest<GradientColorKeyArrayProperty1, GradientColorKey[]>(new GradientColorKey[] { new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F), new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F) });
			yield return RunTest<GradientColorKeyArrayProperty2, GradientColorKey[]>(new GradientColorKey[] { new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F), new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyArrayProperties()
		{
			yield return RunTest<GradientColorKeyArrayProperties1, GradientColorKey[]>(new GradientColorKey[] { new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F), new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F) }, new GradientColorKey[] { new GradientColorKey(new Color(0.09F, 0.00F, 0.58F, 0.21F), 0.10F), new GradientColorKey(new Color(0.22F, 0.96F, 0.65F, 0.24F), 0.82F) });
			yield return RunTest<GradientColorKeyArrayProperties2, GradientColorKey[]>(new GradientColorKey[] { new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F), new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F) }, new GradientColorKey[] { new GradientColorKey(new Color(0.22F, 0.96F, 0.65F, 0.24F), 0.82F), new GradientColorKey(new Color(0.09F, 0.00F, 0.58F, 0.21F), 0.10F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyArrayNullableField()
		{
			yield return RunTest<GradientColorKeyArrayNullableField1, GradientColorKey?[]>(new GradientColorKey?[] { null, new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F) });
			yield return RunTest<GradientColorKeyArrayNullableField2, GradientColorKey?[]>(new GradientColorKey?[] { new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F), null });
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyArrayNullableFields()
		{
			yield return RunTest<GradientColorKeyArrayNullableFields1, GradientColorKey?[]>(new GradientColorKey?[] { null, new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F) }, new GradientColorKey?[] { new GradientColorKey(new Color(0.09F, 0.00F, 0.58F, 0.21F), 0.10F), null });
			yield return RunTest<GradientColorKeyArrayNullableFields2, GradientColorKey?[]>(new GradientColorKey?[] { new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F), null }, new GradientColorKey?[] { null, new GradientColorKey(new Color(0.09F, 0.00F, 0.58F, 0.21F), 0.10F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyArrayNullableProperty()
		{
			yield return RunTest<GradientColorKeyArrayNullableProperty1, GradientColorKey?[]>(new GradientColorKey?[] { null, new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F) });
			yield return RunTest<GradientColorKeyArrayNullableProperty2, GradientColorKey?[]>(new GradientColorKey?[] { new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F), null });
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyArrayNullableProperties()
		{
			yield return RunTest<GradientColorKeyArrayNullableProperties1, GradientColorKey?[]>(new GradientColorKey?[] { new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F), null }, new GradientColorKey?[] { null, new GradientColorKey(new Color(0.22F, 0.96F, 0.65F, 0.24F), 0.82F) });
			yield return RunTest<GradientColorKeyArrayNullableProperties2, GradientColorKey?[]>(new GradientColorKey?[] { null, new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F) }, new GradientColorKey?[] { new GradientColorKey(new Color(0.22F, 0.96F, 0.65F, 0.24F), 0.82F), null });
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyListField()
		{
			yield return RunTest<GradientColorKeyListField1, List<GradientColorKey>>(new List<GradientColorKey> { new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F), new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F) });
			yield return RunTest<GradientColorKeyListField2, List<GradientColorKey>>(new List<GradientColorKey> { new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F), new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyListFields()
		{
			yield return RunTest<GradientColorKeyListFields1, List<GradientColorKey>>(new List<GradientColorKey> { new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F), new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F) }, new List<GradientColorKey> { new GradientColorKey(new Color(0.09F, 0.00F, 0.58F, 0.21F), 0.10F), new GradientColorKey(new Color(0.22F, 0.96F, 0.65F, 0.24F), 0.82F) });
			yield return RunTest<GradientColorKeyListFields2, List<GradientColorKey>>(new List<GradientColorKey> { new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F), new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F) }, new List<GradientColorKey> { new GradientColorKey(new Color(0.22F, 0.96F, 0.65F, 0.24F), 0.82F), new GradientColorKey(new Color(0.09F, 0.00F, 0.58F, 0.21F), 0.10F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyListProperty()
		{
			yield return RunTest<GradientColorKeyListProperty1, List<GradientColorKey>>(new List<GradientColorKey> { new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F), new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F) });
			yield return RunTest<GradientColorKeyListProperty2, List<GradientColorKey>>(new List<GradientColorKey> { new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F), new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyListProperties()
		{
			yield return RunTest<GradientColorKeyListProperties1, List<GradientColorKey>>(new List<GradientColorKey> { new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F), new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F) }, new List<GradientColorKey> { new GradientColorKey(new Color(0.09F, 0.00F, 0.58F, 0.21F), 0.10F), new GradientColorKey(new Color(0.22F, 0.96F, 0.65F, 0.24F), 0.82F) });
			yield return RunTest<GradientColorKeyListProperties2, List<GradientColorKey>>(new List<GradientColorKey> { new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F), new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F) }, new List<GradientColorKey> { new GradientColorKey(new Color(0.22F, 0.96F, 0.65F, 0.24F), 0.82F), new GradientColorKey(new Color(0.09F, 0.00F, 0.58F, 0.21F), 0.10F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyListNullableField()
		{
			yield return RunTest<GradientColorKeyListNullableField1, List<GradientColorKey?>>(new List<GradientColorKey?> { null, new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F) });
			yield return RunTest<GradientColorKeyListNullableField2, List<GradientColorKey?>>(new List<GradientColorKey?> { new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F), null });
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyListNullableFields()
		{
			yield return RunTest<GradientColorKeyListNullableFields1, List<GradientColorKey?>>(new List<GradientColorKey?> { null, new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F) }, new List<GradientColorKey?> { new GradientColorKey(new Color(0.09F, 0.00F, 0.58F, 0.21F), 0.10F), null });
			yield return RunTest<GradientColorKeyListNullableFields2, List<GradientColorKey?>>(new List<GradientColorKey?> { new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F), null }, new List<GradientColorKey?> { null, new GradientColorKey(new Color(0.09F, 0.00F, 0.58F, 0.21F), 0.10F) });
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyListNullableProperty()
		{
			yield return RunTest<GradientColorKeyListNullableProperty1, List<GradientColorKey?>>(new List<GradientColorKey?> { null, new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F) });
			yield return RunTest<GradientColorKeyListNullableProperty2, List<GradientColorKey?>>(new List<GradientColorKey?> { new GradientColorKey(new Color(0.85F, 0.64F, 0.88F, 0.55F), 0.84F), null });
		}

		[UnityTest]
		public IEnumerator SaveGradientColorKeyListNullableProperties()
		{
			yield return RunTest<GradientColorKeyListNullableProperties1, List<GradientColorKey?>>(new List<GradientColorKey?> { new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F), null }, new List<GradientColorKey?> { null, new GradientColorKey(new Color(0.22F, 0.96F, 0.65F, 0.24F), 0.82F) });
			yield return RunTest<GradientColorKeyListNullableProperties2, List<GradientColorKey?>>(new List<GradientColorKey?> { null, new GradientColorKey(new Color(0.76F, 0.95F, 0.11F, 0.22F), 0.13F) }, new List<GradientColorKey?> { new GradientColorKey(new Color(0.22F, 0.96F, 0.65F, 0.24F), 0.82F), null });
		}
	}
}