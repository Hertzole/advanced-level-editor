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
		public IEnumerator SaveColorField()
		{
			yield return RunTest<ColorField1, Color>(new Color(0.08F, 0.75F, 0.21F, 0.48F));
			yield return RunTest<ColorField2, Color>(new Color(0.64F, 0.56F, 0.99F, 0.46F));
		}

		[UnityTest]
		public IEnumerator SaveColorFields()
		{
			yield return RunTest<ColorFields1, Color>(new Color(0.64F, 0.56F, 0.99F, 0.46F), new Color(0.08F, 0.75F, 0.21F, 0.48F));
			yield return RunTest<ColorFields2, Color>(new Color(0.08F, 0.75F, 0.21F, 0.48F), new Color(0.64F, 0.56F, 0.99F, 0.46F));
		}

		[UnityTest]
		public IEnumerator SaveColorProperty()
		{
			yield return RunTest<ColorProperty1, Color>(new Color(0.08F, 0.75F, 0.21F, 0.48F));
			yield return RunTest<ColorProperty2, Color>(new Color(0.64F, 0.56F, 0.99F, 0.46F));
		}

		[UnityTest]
		public IEnumerator SaveColorProperties()
		{
			yield return RunTest<ColorProperties1, Color>(new Color(0.64F, 0.56F, 0.99F, 0.46F), new Color(0.08F, 0.75F, 0.21F, 0.48F));
			yield return RunTest<ColorProperties2, Color>(new Color(0.08F, 0.75F, 0.21F, 0.48F), new Color(0.64F, 0.56F, 0.99F, 0.46F));
		}

		[UnityTest]
		public IEnumerator SaveColorNullableField()
		{
			yield return RunTest<ColorNullableField1, Color?>(new Color(0.08F, 0.75F, 0.21F, 0.48F));
			yield return RunTest<ColorNullableField2, Color?>(new Color(0.64F, 0.56F, 0.99F, 0.46F));
			yield return RunTest<ColorNullableField1, Color?>(null);
			yield return RunTest<ColorNullableField2, Color?>(null);
		}

		[UnityTest]
		public IEnumerator SaveColorNullableFields()
		{
			yield return RunTest<ColorNullableFields1, Color?>(new Color(0.64F, 0.56F, 0.99F, 0.46F), new Color(0.08F, 0.75F, 0.21F, 0.48F));
			yield return RunTest<ColorNullableFields2, Color?>(new Color(0.08F, 0.75F, 0.21F, 0.48F), new Color(0.64F, 0.56F, 0.99F, 0.46F));
			yield return RunTest<ColorNullableFields1, Color?>(null, new Color(0.08F, 0.75F, 0.21F, 0.48F));
			yield return RunTest<ColorNullableFields2, Color?>(new Color(0.08F, 0.75F, 0.21F, 0.48F), null);
		}

		[UnityTest]
		public IEnumerator SaveColorNullableProperty()
		{
			yield return RunTest<ColorNullableProperty1, Color?>(new Color(0.08F, 0.75F, 0.21F, 0.48F));
			yield return RunTest<ColorNullableProperty2, Color?>(new Color(0.64F, 0.56F, 0.99F, 0.46F));
			yield return RunTest<ColorNullableProperty1, Color?>(null);
			yield return RunTest<ColorNullableProperty2, Color?>(null);
		}

		[UnityTest]
		public IEnumerator SaveColorNullableProperties()
		{
			yield return RunTest<ColorNullableProperties1, Color?>(new Color(0.64F, 0.56F, 0.99F, 0.46F), new Color(0.08F, 0.75F, 0.21F, 0.48F));
			yield return RunTest<ColorNullableProperties2, Color?>(new Color(0.08F, 0.75F, 0.21F, 0.48F), new Color(0.64F, 0.56F, 0.99F, 0.46F));
			yield return RunTest<ColorNullableProperties1, Color?>(null, new Color(0.08F, 0.75F, 0.21F, 0.48F));
			yield return RunTest<ColorNullableProperties2, Color?>(new Color(0.08F, 0.75F, 0.21F, 0.48F), null);
		}

		[UnityTest]
		public IEnumerator SaveColorArrayField()
		{
			yield return RunTest<ColorArrayField1, Color[]>(new Color[] { new Color(0.08F, 0.75F, 0.21F, 0.48F), new Color(0.64F, 0.56F, 0.99F, 0.46F) });
			yield return RunTest<ColorArrayField2, Color[]>(new Color[] { new Color(0.64F, 0.56F, 0.99F, 0.46F), new Color(0.08F, 0.75F, 0.21F, 0.48F) });
		}

		[UnityTest]
		public IEnumerator SaveColorArrayFields()
		{
			yield return RunTest<ColorArrayFields1, Color[]>(new Color[] { new Color(0.08F, 0.75F, 0.21F, 0.48F), new Color(0.64F, 0.56F, 0.99F, 0.46F) }, new Color[] { new Color(0.82F, 0.94F, 0.08F, 0.34F), new Color(0.40F, 0.41F, 0.49F, 0.59F) });
			yield return RunTest<ColorArrayFields2, Color[]>(new Color[] { new Color(0.64F, 0.56F, 0.99F, 0.46F), new Color(0.08F, 0.75F, 0.21F, 0.48F) }, new Color[] { new Color(0.40F, 0.41F, 0.49F, 0.59F), new Color(0.82F, 0.94F, 0.08F, 0.34F) });
		}

		[UnityTest]
		public IEnumerator SaveColorArrayProperty()
		{
			yield return RunTest<ColorArrayProperty1, Color[]>(new Color[] { new Color(0.08F, 0.75F, 0.21F, 0.48F), new Color(0.64F, 0.56F, 0.99F, 0.46F) });
			yield return RunTest<ColorArrayProperty2, Color[]>(new Color[] { new Color(0.64F, 0.56F, 0.99F, 0.46F), new Color(0.08F, 0.75F, 0.21F, 0.48F) });
		}

		[UnityTest]
		public IEnumerator SaveColorArrayProperties()
		{
			yield return RunTest<ColorArrayProperties1, Color[]>(new Color[] { new Color(0.08F, 0.75F, 0.21F, 0.48F), new Color(0.64F, 0.56F, 0.99F, 0.46F) }, new Color[] { new Color(0.82F, 0.94F, 0.08F, 0.34F), new Color(0.40F, 0.41F, 0.49F, 0.59F) });
			yield return RunTest<ColorArrayProperties2, Color[]>(new Color[] { new Color(0.64F, 0.56F, 0.99F, 0.46F), new Color(0.08F, 0.75F, 0.21F, 0.48F) }, new Color[] { new Color(0.40F, 0.41F, 0.49F, 0.59F), new Color(0.82F, 0.94F, 0.08F, 0.34F) });
		}

		[UnityTest]
		public IEnumerator SaveColorArrayNullableField()
		{
			yield return RunTest<ColorArrayNullableField1, Color?[]>(new Color?[] { null, new Color(0.64F, 0.56F, 0.99F, 0.46F) });
			yield return RunTest<ColorArrayNullableField2, Color?[]>(new Color?[] { new Color(0.64F, 0.56F, 0.99F, 0.46F), null });
		}

		[UnityTest]
		public IEnumerator SaveColorArrayNullableFields()
		{
			yield return RunTest<ColorArrayNullableFields1, Color?[]>(new Color?[] { null, new Color(0.64F, 0.56F, 0.99F, 0.46F) }, new Color?[] { new Color(0.82F, 0.94F, 0.08F, 0.34F), null });
			yield return RunTest<ColorArrayNullableFields2, Color?[]>(new Color?[] { new Color(0.64F, 0.56F, 0.99F, 0.46F), null }, new Color?[] { null, new Color(0.82F, 0.94F, 0.08F, 0.34F) });
		}

		[UnityTest]
		public IEnumerator SaveColorArrayNullableProperty()
		{
			yield return RunTest<ColorArrayNullableProperty1, Color?[]>(new Color?[] { null, new Color(0.64F, 0.56F, 0.99F, 0.46F) });
			yield return RunTest<ColorArrayNullableProperty2, Color?[]>(new Color?[] { new Color(0.64F, 0.56F, 0.99F, 0.46F), null });
		}

		[UnityTest]
		public IEnumerator SaveColorArrayNullableProperties()
		{
			yield return RunTest<ColorArrayNullableProperties1, Color?[]>(new Color?[] { new Color(0.08F, 0.75F, 0.21F, 0.48F), null }, new Color?[] { null, new Color(0.40F, 0.41F, 0.49F, 0.59F) });
			yield return RunTest<ColorArrayNullableProperties2, Color?[]>(new Color?[] { null, new Color(0.08F, 0.75F, 0.21F, 0.48F) }, new Color?[] { new Color(0.40F, 0.41F, 0.49F, 0.59F), null });
		}

		[UnityTest]
		public IEnumerator SaveColorListField()
		{
			yield return RunTest<ColorListField1, List<Color>>(new List<Color> { new Color(0.08F, 0.75F, 0.21F, 0.48F), new Color(0.64F, 0.56F, 0.99F, 0.46F) });
			yield return RunTest<ColorListField2, List<Color>>(new List<Color> { new Color(0.64F, 0.56F, 0.99F, 0.46F), new Color(0.08F, 0.75F, 0.21F, 0.48F) });
		}

		[UnityTest]
		public IEnumerator SaveColorListFields()
		{
			yield return RunTest<ColorListFields1, List<Color>>(new List<Color> { new Color(0.08F, 0.75F, 0.21F, 0.48F), new Color(0.64F, 0.56F, 0.99F, 0.46F) }, new List<Color> { new Color(0.82F, 0.94F, 0.08F, 0.34F), new Color(0.40F, 0.41F, 0.49F, 0.59F) });
			yield return RunTest<ColorListFields2, List<Color>>(new List<Color> { new Color(0.64F, 0.56F, 0.99F, 0.46F), new Color(0.08F, 0.75F, 0.21F, 0.48F) }, new List<Color> { new Color(0.40F, 0.41F, 0.49F, 0.59F), new Color(0.82F, 0.94F, 0.08F, 0.34F) });
		}

		[UnityTest]
		public IEnumerator SaveColorListProperty()
		{
			yield return RunTest<ColorListProperty1, List<Color>>(new List<Color> { new Color(0.08F, 0.75F, 0.21F, 0.48F), new Color(0.64F, 0.56F, 0.99F, 0.46F) });
			yield return RunTest<ColorListProperty2, List<Color>>(new List<Color> { new Color(0.64F, 0.56F, 0.99F, 0.46F), new Color(0.08F, 0.75F, 0.21F, 0.48F) });
		}

		[UnityTest]
		public IEnumerator SaveColorListProperties()
		{
			yield return RunTest<ColorListProperties1, List<Color>>(new List<Color> { new Color(0.08F, 0.75F, 0.21F, 0.48F), new Color(0.64F, 0.56F, 0.99F, 0.46F) }, new List<Color> { new Color(0.82F, 0.94F, 0.08F, 0.34F), new Color(0.40F, 0.41F, 0.49F, 0.59F) });
			yield return RunTest<ColorListProperties2, List<Color>>(new List<Color> { new Color(0.64F, 0.56F, 0.99F, 0.46F), new Color(0.08F, 0.75F, 0.21F, 0.48F) }, new List<Color> { new Color(0.40F, 0.41F, 0.49F, 0.59F), new Color(0.82F, 0.94F, 0.08F, 0.34F) });
		}

		[UnityTest]
		public IEnumerator SaveColorListNullableField()
		{
			yield return RunTest<ColorListNullableField1, List<Color?>>(new List<Color?> { null, new Color(0.64F, 0.56F, 0.99F, 0.46F) });
			yield return RunTest<ColorListNullableField2, List<Color?>>(new List<Color?> { new Color(0.64F, 0.56F, 0.99F, 0.46F), null });
		}

		[UnityTest]
		public IEnumerator SaveColorListNullableFields()
		{
			yield return RunTest<ColorListNullableFields1, List<Color?>>(new List<Color?> { null, new Color(0.64F, 0.56F, 0.99F, 0.46F) }, new List<Color?> { new Color(0.82F, 0.94F, 0.08F, 0.34F), null });
			yield return RunTest<ColorListNullableFields2, List<Color?>>(new List<Color?> { new Color(0.64F, 0.56F, 0.99F, 0.46F), null }, new List<Color?> { null, new Color(0.82F, 0.94F, 0.08F, 0.34F) });
		}

		[UnityTest]
		public IEnumerator SaveColorListNullableProperty()
		{
			yield return RunTest<ColorListNullableProperty1, List<Color?>>(new List<Color?> { null, new Color(0.64F, 0.56F, 0.99F, 0.46F) });
			yield return RunTest<ColorListNullableProperty2, List<Color?>>(new List<Color?> { new Color(0.64F, 0.56F, 0.99F, 0.46F), null });
		}

		[UnityTest]
		public IEnumerator SaveColorListNullableProperties()
		{
			yield return RunTest<ColorListNullableProperties1, List<Color?>>(new List<Color?> { new Color(0.08F, 0.75F, 0.21F, 0.48F), null }, new List<Color?> { null, new Color(0.40F, 0.41F, 0.49F, 0.59F) });
			yield return RunTest<ColorListNullableProperties2, List<Color?>>(new List<Color?> { null, new Color(0.08F, 0.75F, 0.21F, 0.48F) }, new List<Color?> { new Color(0.40F, 0.41F, 0.49F, 0.59F), null });
		}
	}
}