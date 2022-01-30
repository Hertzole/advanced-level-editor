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
		public IEnumerator SaveRectField()
		{
			yield return RunTest<RectField1, Rect>(new Rect(0.32F, 0.18F, 0.80F, 0.98F));
			yield return RunTest<RectField2, Rect>(new Rect(0.46F, 0.63F, 0.16F, 0.91F));
		}

		[UnityTest]
		public IEnumerator SaveRectFields()
		{
			yield return RunTest<RectFields1, Rect>(new Rect(0.46F, 0.63F, 0.16F, 0.91F), new Rect(0.32F, 0.18F, 0.80F, 0.98F));
			yield return RunTest<RectFields2, Rect>(new Rect(0.32F, 0.18F, 0.80F, 0.98F), new Rect(0.46F, 0.63F, 0.16F, 0.91F));
		}

		[UnityTest]
		public IEnumerator SaveRectProperty()
		{
			yield return RunTest<RectProperty1, Rect>(new Rect(0.32F, 0.18F, 0.80F, 0.98F));
			yield return RunTest<RectProperty2, Rect>(new Rect(0.46F, 0.63F, 0.16F, 0.91F));
		}

		[UnityTest]
		public IEnumerator SaveRectProperties()
		{
			yield return RunTest<RectProperties1, Rect>(new Rect(0.46F, 0.63F, 0.16F, 0.91F), new Rect(0.32F, 0.18F, 0.80F, 0.98F));
			yield return RunTest<RectProperties2, Rect>(new Rect(0.32F, 0.18F, 0.80F, 0.98F), new Rect(0.46F, 0.63F, 0.16F, 0.91F));
		}

		[UnityTest]
		public IEnumerator SaveRectNullableField()
		{
			yield return RunTest<RectNullableField1, Rect?>(new Rect(0.32F, 0.18F, 0.80F, 0.98F));
			yield return RunTest<RectNullableField2, Rect?>(new Rect(0.46F, 0.63F, 0.16F, 0.91F));
			yield return RunTest<RectNullableField1, Rect?>(null);
			yield return RunTest<RectNullableField2, Rect?>(null);
		}

		[UnityTest]
		public IEnumerator SaveRectNullableFields()
		{
			yield return RunTest<RectNullableFields1, Rect?>(new Rect(0.46F, 0.63F, 0.16F, 0.91F), new Rect(0.32F, 0.18F, 0.80F, 0.98F));
			yield return RunTest<RectNullableFields2, Rect?>(new Rect(0.32F, 0.18F, 0.80F, 0.98F), new Rect(0.46F, 0.63F, 0.16F, 0.91F));
			yield return RunTest<RectNullableFields1, Rect?>(null, new Rect(0.32F, 0.18F, 0.80F, 0.98F));
			yield return RunTest<RectNullableFields2, Rect?>(new Rect(0.32F, 0.18F, 0.80F, 0.98F), null);
		}

		[UnityTest]
		public IEnumerator SaveRectNullableProperty()
		{
			yield return RunTest<RectNullableProperty1, Rect?>(new Rect(0.32F, 0.18F, 0.80F, 0.98F));
			yield return RunTest<RectNullableProperty2, Rect?>(new Rect(0.46F, 0.63F, 0.16F, 0.91F));
			yield return RunTest<RectNullableProperty1, Rect?>(null);
			yield return RunTest<RectNullableProperty2, Rect?>(null);
		}

		[UnityTest]
		public IEnumerator SaveRectNullableProperties()
		{
			yield return RunTest<RectNullableProperties1, Rect?>(new Rect(0.46F, 0.63F, 0.16F, 0.91F), new Rect(0.32F, 0.18F, 0.80F, 0.98F));
			yield return RunTest<RectNullableProperties2, Rect?>(new Rect(0.32F, 0.18F, 0.80F, 0.98F), new Rect(0.46F, 0.63F, 0.16F, 0.91F));
			yield return RunTest<RectNullableProperties1, Rect?>(null, new Rect(0.32F, 0.18F, 0.80F, 0.98F));
			yield return RunTest<RectNullableProperties2, Rect?>(new Rect(0.32F, 0.18F, 0.80F, 0.98F), null);
		}

		[UnityTest]
		public IEnumerator SaveRectArrayField()
		{
			yield return RunTest<RectArrayField1, Rect[]>(new Rect[] { new Rect(0.32F, 0.18F, 0.80F, 0.98F), new Rect(0.46F, 0.63F, 0.16F, 0.91F) });
			yield return RunTest<RectArrayField2, Rect[]>(new Rect[] { new Rect(0.46F, 0.63F, 0.16F, 0.91F), new Rect(0.32F, 0.18F, 0.80F, 0.98F) });
		}

		[UnityTest]
		public IEnumerator SaveRectArrayFields()
		{
			yield return RunTest<RectArrayFields1, Rect[]>(new Rect[] { new Rect(0.32F, 0.18F, 0.80F, 0.98F), new Rect(0.46F, 0.63F, 0.16F, 0.91F) }, new Rect[] { new Rect(0.03F, 0.05F, 0.06F, 0.50F), new Rect(0.21F, 0.05F, 0.87F, 0.62F) });
			yield return RunTest<RectArrayFields2, Rect[]>(new Rect[] { new Rect(0.46F, 0.63F, 0.16F, 0.91F), new Rect(0.32F, 0.18F, 0.80F, 0.98F) }, new Rect[] { new Rect(0.21F, 0.05F, 0.87F, 0.62F), new Rect(0.03F, 0.05F, 0.06F, 0.50F) });
		}

		[UnityTest]
		public IEnumerator SaveRectArrayProperty()
		{
			yield return RunTest<RectArrayProperty1, Rect[]>(new Rect[] { new Rect(0.32F, 0.18F, 0.80F, 0.98F), new Rect(0.46F, 0.63F, 0.16F, 0.91F) });
			yield return RunTest<RectArrayProperty2, Rect[]>(new Rect[] { new Rect(0.46F, 0.63F, 0.16F, 0.91F), new Rect(0.32F, 0.18F, 0.80F, 0.98F) });
		}

		[UnityTest]
		public IEnumerator SaveRectArrayProperties()
		{
			yield return RunTest<RectArrayProperties1, Rect[]>(new Rect[] { new Rect(0.32F, 0.18F, 0.80F, 0.98F), new Rect(0.46F, 0.63F, 0.16F, 0.91F) }, new Rect[] { new Rect(0.03F, 0.05F, 0.06F, 0.50F), new Rect(0.21F, 0.05F, 0.87F, 0.62F) });
			yield return RunTest<RectArrayProperties2, Rect[]>(new Rect[] { new Rect(0.46F, 0.63F, 0.16F, 0.91F), new Rect(0.32F, 0.18F, 0.80F, 0.98F) }, new Rect[] { new Rect(0.21F, 0.05F, 0.87F, 0.62F), new Rect(0.03F, 0.05F, 0.06F, 0.50F) });
		}

		[UnityTest]
		public IEnumerator SaveRectArrayNullableField()
		{
			yield return RunTest<RectArrayNullableField1, Rect?[]>(new Rect?[] { null, new Rect(0.46F, 0.63F, 0.16F, 0.91F) });
			yield return RunTest<RectArrayNullableField2, Rect?[]>(new Rect?[] { new Rect(0.46F, 0.63F, 0.16F, 0.91F), null });
		}

		[UnityTest]
		public IEnumerator SaveRectArrayNullableFields()
		{
			yield return RunTest<RectArrayNullableFields1, Rect?[]>(new Rect?[] { null, new Rect(0.46F, 0.63F, 0.16F, 0.91F) }, new Rect?[] { new Rect(0.03F, 0.05F, 0.06F, 0.50F), null });
			yield return RunTest<RectArrayNullableFields2, Rect?[]>(new Rect?[] { new Rect(0.46F, 0.63F, 0.16F, 0.91F), null }, new Rect?[] { null, new Rect(0.03F, 0.05F, 0.06F, 0.50F) });
		}

		[UnityTest]
		public IEnumerator SaveRectArrayNullableProperty()
		{
			yield return RunTest<RectArrayNullableProperty1, Rect?[]>(new Rect?[] { null, new Rect(0.46F, 0.63F, 0.16F, 0.91F) });
			yield return RunTest<RectArrayNullableProperty2, Rect?[]>(new Rect?[] { new Rect(0.46F, 0.63F, 0.16F, 0.91F), null });
		}

		[UnityTest]
		public IEnumerator SaveRectArrayNullableProperties()
		{
			yield return RunTest<RectArrayNullableProperties1, Rect?[]>(new Rect?[] { new Rect(0.32F, 0.18F, 0.80F, 0.98F), null }, new Rect?[] { null, new Rect(0.21F, 0.05F, 0.87F, 0.62F) });
			yield return RunTest<RectArrayNullableProperties2, Rect?[]>(new Rect?[] { null, new Rect(0.32F, 0.18F, 0.80F, 0.98F) }, new Rect?[] { new Rect(0.21F, 0.05F, 0.87F, 0.62F), null });
		}

		[UnityTest]
		public IEnumerator SaveRectListField()
		{
			yield return RunTest<RectListField1, List<Rect>>(new List<Rect> { new Rect(0.32F, 0.18F, 0.80F, 0.98F), new Rect(0.46F, 0.63F, 0.16F, 0.91F) });
			yield return RunTest<RectListField2, List<Rect>>(new List<Rect> { new Rect(0.46F, 0.63F, 0.16F, 0.91F), new Rect(0.32F, 0.18F, 0.80F, 0.98F) });
		}

		[UnityTest]
		public IEnumerator SaveRectListFields()
		{
			yield return RunTest<RectListFields1, List<Rect>>(new List<Rect> { new Rect(0.32F, 0.18F, 0.80F, 0.98F), new Rect(0.46F, 0.63F, 0.16F, 0.91F) }, new List<Rect> { new Rect(0.03F, 0.05F, 0.06F, 0.50F), new Rect(0.21F, 0.05F, 0.87F, 0.62F) });
			yield return RunTest<RectListFields2, List<Rect>>(new List<Rect> { new Rect(0.46F, 0.63F, 0.16F, 0.91F), new Rect(0.32F, 0.18F, 0.80F, 0.98F) }, new List<Rect> { new Rect(0.21F, 0.05F, 0.87F, 0.62F), new Rect(0.03F, 0.05F, 0.06F, 0.50F) });
		}

		[UnityTest]
		public IEnumerator SaveRectListProperty()
		{
			yield return RunTest<RectListProperty1, List<Rect>>(new List<Rect> { new Rect(0.32F, 0.18F, 0.80F, 0.98F), new Rect(0.46F, 0.63F, 0.16F, 0.91F) });
			yield return RunTest<RectListProperty2, List<Rect>>(new List<Rect> { new Rect(0.46F, 0.63F, 0.16F, 0.91F), new Rect(0.32F, 0.18F, 0.80F, 0.98F) });
		}

		[UnityTest]
		public IEnumerator SaveRectListProperties()
		{
			yield return RunTest<RectListProperties1, List<Rect>>(new List<Rect> { new Rect(0.32F, 0.18F, 0.80F, 0.98F), new Rect(0.46F, 0.63F, 0.16F, 0.91F) }, new List<Rect> { new Rect(0.03F, 0.05F, 0.06F, 0.50F), new Rect(0.21F, 0.05F, 0.87F, 0.62F) });
			yield return RunTest<RectListProperties2, List<Rect>>(new List<Rect> { new Rect(0.46F, 0.63F, 0.16F, 0.91F), new Rect(0.32F, 0.18F, 0.80F, 0.98F) }, new List<Rect> { new Rect(0.21F, 0.05F, 0.87F, 0.62F), new Rect(0.03F, 0.05F, 0.06F, 0.50F) });
		}

		[UnityTest]
		public IEnumerator SaveRectListNullableField()
		{
			yield return RunTest<RectListNullableField1, List<Rect?>>(new List<Rect?> { null, new Rect(0.46F, 0.63F, 0.16F, 0.91F) });
			yield return RunTest<RectListNullableField2, List<Rect?>>(new List<Rect?> { new Rect(0.46F, 0.63F, 0.16F, 0.91F), null });
		}

		[UnityTest]
		public IEnumerator SaveRectListNullableFields()
		{
			yield return RunTest<RectListNullableFields1, List<Rect?>>(new List<Rect?> { null, new Rect(0.46F, 0.63F, 0.16F, 0.91F) }, new List<Rect?> { new Rect(0.03F, 0.05F, 0.06F, 0.50F), null });
			yield return RunTest<RectListNullableFields2, List<Rect?>>(new List<Rect?> { new Rect(0.46F, 0.63F, 0.16F, 0.91F), null }, new List<Rect?> { null, new Rect(0.03F, 0.05F, 0.06F, 0.50F) });
		}

		[UnityTest]
		public IEnumerator SaveRectListNullableProperty()
		{
			yield return RunTest<RectListNullableProperty1, List<Rect?>>(new List<Rect?> { null, new Rect(0.46F, 0.63F, 0.16F, 0.91F) });
			yield return RunTest<RectListNullableProperty2, List<Rect?>>(new List<Rect?> { new Rect(0.46F, 0.63F, 0.16F, 0.91F), null });
		}

		[UnityTest]
		public IEnumerator SaveRectListNullableProperties()
		{
			yield return RunTest<RectListNullableProperties1, List<Rect?>>(new List<Rect?> { new Rect(0.32F, 0.18F, 0.80F, 0.98F), null }, new List<Rect?> { null, new Rect(0.21F, 0.05F, 0.87F, 0.62F) });
			yield return RunTest<RectListNullableProperties2, List<Rect?>>(new List<Rect?> { null, new Rect(0.32F, 0.18F, 0.80F, 0.98F) }, new List<Rect?> { new Rect(0.21F, 0.05F, 0.87F, 0.62F), null });
		}
	}
}