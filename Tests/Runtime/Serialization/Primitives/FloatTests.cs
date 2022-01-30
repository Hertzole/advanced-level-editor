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
		public IEnumerator SaveFloatField()
		{
			yield return RunTest<FloatField1, float>(-354.48F);
			yield return RunTest<FloatField2, float>(-559.96F);
		}

		[UnityTest]
		public IEnumerator SaveFloatFields()
		{
			yield return RunTest<FloatFields1, float>(-559.96F, -354.48F);
			yield return RunTest<FloatFields2, float>(-354.48F, -559.96F);
		}

		[UnityTest]
		public IEnumerator SaveFloatProperty()
		{
			yield return RunTest<FloatProperty1, float>(-354.48F);
			yield return RunTest<FloatProperty2, float>(-559.96F);
		}

		[UnityTest]
		public IEnumerator SaveFloatProperties()
		{
			yield return RunTest<FloatProperties1, float>(-559.96F, -354.48F);
			yield return RunTest<FloatProperties2, float>(-354.48F, -559.96F);
		}

		[UnityTest]
		public IEnumerator SaveFloatNullableField()
		{
			yield return RunTest<FloatNullableField1, float?>(-354.48F);
			yield return RunTest<FloatNullableField2, float?>(-559.96F);
			yield return RunTest<FloatNullableField1, float?>(null);
			yield return RunTest<FloatNullableField2, float?>(null);
		}

		[UnityTest]
		public IEnumerator SaveFloatNullableFields()
		{
			yield return RunTest<FloatNullableFields1, float?>(-559.96F, -354.48F);
			yield return RunTest<FloatNullableFields2, float?>(-354.48F, -559.96F);
			yield return RunTest<FloatNullableFields1, float?>(null, -354.48F);
			yield return RunTest<FloatNullableFields2, float?>(-354.48F, null);
		}

		[UnityTest]
		public IEnumerator SaveFloatNullableProperty()
		{
			yield return RunTest<FloatNullableProperty1, float?>(-354.48F);
			yield return RunTest<FloatNullableProperty2, float?>(-559.96F);
			yield return RunTest<FloatNullableProperty1, float?>(null);
			yield return RunTest<FloatNullableProperty2, float?>(null);
		}

		[UnityTest]
		public IEnumerator SaveFloatNullableProperties()
		{
			yield return RunTest<FloatNullableProperties1, float?>(-559.96F, -354.48F);
			yield return RunTest<FloatNullableProperties2, float?>(-354.48F, -559.96F);
			yield return RunTest<FloatNullableProperties1, float?>(null, -354.48F);
			yield return RunTest<FloatNullableProperties2, float?>(-354.48F, null);
		}

		[UnityTest]
		public IEnumerator SaveFloatArrayField()
		{
			yield return RunTest<FloatArrayField1, float[]>(new float[] { -354.48F, -559.96F });
			yield return RunTest<FloatArrayField2, float[]>(new float[] { -559.96F, -354.48F });
		}

		[UnityTest]
		public IEnumerator SaveFloatArrayFields()
		{
			yield return RunTest<FloatArrayFields1, float[]>(new float[] { -354.48F, -559.96F }, new float[] { -723.06F, 733.74F });
			yield return RunTest<FloatArrayFields2, float[]>(new float[] { -559.96F, -354.48F }, new float[] { 733.74F, -723.06F });
		}

		[UnityTest]
		public IEnumerator SaveFloatArrayProperty()
		{
			yield return RunTest<FloatArrayProperty1, float[]>(new float[] { -354.48F, -559.96F });
			yield return RunTest<FloatArrayProperty2, float[]>(new float[] { -559.96F, -354.48F });
		}

		[UnityTest]
		public IEnumerator SaveFloatArrayProperties()
		{
			yield return RunTest<FloatArrayProperties1, float[]>(new float[] { -354.48F, -559.96F }, new float[] { -723.06F, 733.74F });
			yield return RunTest<FloatArrayProperties2, float[]>(new float[] { -559.96F, -354.48F }, new float[] { 733.74F, -723.06F });
		}

		[UnityTest]
		public IEnumerator SaveFloatArrayNullableField()
		{
			yield return RunTest<FloatArrayNullableField1, float?[]>(new float?[] { null, -559.96F });
			yield return RunTest<FloatArrayNullableField2, float?[]>(new float?[] { -559.96F, null });
		}

		[UnityTest]
		public IEnumerator SaveFloatArrayNullableFields()
		{
			yield return RunTest<FloatArrayNullableFields1, float?[]>(new float?[] { null, -559.96F }, new float?[] { -723.06F, null });
			yield return RunTest<FloatArrayNullableFields2, float?[]>(new float?[] { -559.96F, null }, new float?[] { null, -723.06F });
		}

		[UnityTest]
		public IEnumerator SaveFloatArrayNullableProperty()
		{
			yield return RunTest<FloatArrayNullableProperty1, float?[]>(new float?[] { null, -559.96F });
			yield return RunTest<FloatArrayNullableProperty2, float?[]>(new float?[] { -559.96F, null });
		}

		[UnityTest]
		public IEnumerator SaveFloatArrayNullableProperties()
		{
			yield return RunTest<FloatArrayNullableProperties1, float?[]>(new float?[] { -354.48F, null }, new float?[] { null, 733.74F });
			yield return RunTest<FloatArrayNullableProperties2, float?[]>(new float?[] { null, -354.48F }, new float?[] { 733.74F, null });
		}

		[UnityTest]
		public IEnumerator SaveFloatListField()
		{
			yield return RunTest<FloatListField1, List<float>>(new List<float> { -354.48F, -559.96F });
			yield return RunTest<FloatListField2, List<float>>(new List<float> { -559.96F, -354.48F });
		}

		[UnityTest]
		public IEnumerator SaveFloatListFields()
		{
			yield return RunTest<FloatListFields1, List<float>>(new List<float> { -354.48F, -559.96F }, new List<float> { -723.06F, 733.74F });
			yield return RunTest<FloatListFields2, List<float>>(new List<float> { -559.96F, -354.48F }, new List<float> { 733.74F, -723.06F });
		}

		[UnityTest]
		public IEnumerator SaveFloatListProperty()
		{
			yield return RunTest<FloatListProperty1, List<float>>(new List<float> { -354.48F, -559.96F });
			yield return RunTest<FloatListProperty2, List<float>>(new List<float> { -559.96F, -354.48F });
		}

		[UnityTest]
		public IEnumerator SaveFloatListProperties()
		{
			yield return RunTest<FloatListProperties1, List<float>>(new List<float> { -354.48F, -559.96F }, new List<float> { -723.06F, 733.74F });
			yield return RunTest<FloatListProperties2, List<float>>(new List<float> { -559.96F, -354.48F }, new List<float> { 733.74F, -723.06F });
		}

		[UnityTest]
		public IEnumerator SaveFloatListNullableField()
		{
			yield return RunTest<FloatListNullableField1, List<float?>>(new List<float?> { null, -559.96F });
			yield return RunTest<FloatListNullableField2, List<float?>>(new List<float?> { -559.96F, null });
		}

		[UnityTest]
		public IEnumerator SaveFloatListNullableFields()
		{
			yield return RunTest<FloatListNullableFields1, List<float?>>(new List<float?> { null, -559.96F }, new List<float?> { -723.06F, null });
			yield return RunTest<FloatListNullableFields2, List<float?>>(new List<float?> { -559.96F, null }, new List<float?> { null, -723.06F });
		}

		[UnityTest]
		public IEnumerator SaveFloatListNullableProperty()
		{
			yield return RunTest<FloatListNullableProperty1, List<float?>>(new List<float?> { null, -559.96F });
			yield return RunTest<FloatListNullableProperty2, List<float?>>(new List<float?> { -559.96F, null });
		}

		[UnityTest]
		public IEnumerator SaveFloatListNullableProperties()
		{
			yield return RunTest<FloatListNullableProperties1, List<float?>>(new List<float?> { -354.48F, null }, new List<float?> { null, 733.74F });
			yield return RunTest<FloatListNullableProperties2, List<float?>>(new List<float?> { null, -354.48F }, new List<float?> { 733.74F, null });
		}
	}
}