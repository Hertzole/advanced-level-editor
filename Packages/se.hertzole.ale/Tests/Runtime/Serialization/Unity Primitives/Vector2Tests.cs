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
		public IEnumerator SaveVector2Field()
		{
			yield return RunTest<Vector2Field1, Vector2>(new Vector2(0.76F, 0.59F));
			yield return RunTest<Vector2Field2, Vector2>(new Vector2(0.12F, 0.49F));
		}

		[UnityTest]
		public IEnumerator SaveVector2Fields()
		{
			yield return RunTest<Vector2Fields1, Vector2>(new Vector2(0.12F, 0.49F), new Vector2(0.76F, 0.59F));
			yield return RunTest<Vector2Fields2, Vector2>(new Vector2(0.76F, 0.59F), new Vector2(0.12F, 0.49F));
		}

		[UnityTest]
		public IEnumerator SaveVector2Property()
		{
			yield return RunTest<Vector2Property1, Vector2>(new Vector2(0.76F, 0.59F));
			yield return RunTest<Vector2Property2, Vector2>(new Vector2(0.12F, 0.49F));
		}

		[UnityTest]
		public IEnumerator SaveVector2Properties()
		{
			yield return RunTest<Vector2Properties1, Vector2>(new Vector2(0.12F, 0.49F), new Vector2(0.76F, 0.59F));
			yield return RunTest<Vector2Properties2, Vector2>(new Vector2(0.76F, 0.59F), new Vector2(0.12F, 0.49F));
		}

		[UnityTest]
		public IEnumerator SaveVector2NullableField()
		{
			yield return RunTest<Vector2NullableField1, Vector2?>(new Vector2(0.76F, 0.59F));
			yield return RunTest<Vector2NullableField2, Vector2?>(new Vector2(0.12F, 0.49F));
			yield return RunTest<Vector2NullableField1, Vector2?>(null);
			yield return RunTest<Vector2NullableField2, Vector2?>(null);
		}

		[UnityTest]
		public IEnumerator SaveVector2NullableFields()
		{
			yield return RunTest<Vector2NullableFields1, Vector2?>(new Vector2(0.12F, 0.49F), new Vector2(0.76F, 0.59F));
			yield return RunTest<Vector2NullableFields2, Vector2?>(new Vector2(0.76F, 0.59F), new Vector2(0.12F, 0.49F));
			yield return RunTest<Vector2NullableFields1, Vector2?>(null, new Vector2(0.76F, 0.59F));
			yield return RunTest<Vector2NullableFields2, Vector2?>(new Vector2(0.76F, 0.59F), null);
		}

		[UnityTest]
		public IEnumerator SaveVector2NullableProperty()
		{
			yield return RunTest<Vector2NullableProperty1, Vector2?>(new Vector2(0.76F, 0.59F));
			yield return RunTest<Vector2NullableProperty2, Vector2?>(new Vector2(0.12F, 0.49F));
			yield return RunTest<Vector2NullableProperty1, Vector2?>(null);
			yield return RunTest<Vector2NullableProperty2, Vector2?>(null);
		}

		[UnityTest]
		public IEnumerator SaveVector2NullableProperties()
		{
			yield return RunTest<Vector2NullableProperties1, Vector2?>(new Vector2(0.12F, 0.49F), new Vector2(0.76F, 0.59F));
			yield return RunTest<Vector2NullableProperties2, Vector2?>(new Vector2(0.76F, 0.59F), new Vector2(0.12F, 0.49F));
			yield return RunTest<Vector2NullableProperties1, Vector2?>(null, new Vector2(0.76F, 0.59F));
			yield return RunTest<Vector2NullableProperties2, Vector2?>(new Vector2(0.76F, 0.59F), null);
		}

		[UnityTest]
		public IEnumerator SaveVector2ArrayField()
		{
			yield return RunTest<Vector2ArrayField1, Vector2[]>(new Vector2[] { new Vector2(0.76F, 0.59F), new Vector2(0.12F, 0.49F) });
			yield return RunTest<Vector2ArrayField2, Vector2[]>(new Vector2[] { new Vector2(0.12F, 0.49F), new Vector2(0.76F, 0.59F) });
		}

		[UnityTest]
		public IEnumerator SaveVector2ArrayFields()
		{
			yield return RunTest<Vector2ArrayFields1, Vector2[]>(new Vector2[] { new Vector2(0.76F, 0.59F), new Vector2(0.12F, 0.49F) }, new Vector2[] { new Vector2(0.24F, 0.31F), new Vector2(0.26F, 0.30F) });
			yield return RunTest<Vector2ArrayFields2, Vector2[]>(new Vector2[] { new Vector2(0.12F, 0.49F), new Vector2(0.76F, 0.59F) }, new Vector2[] { new Vector2(0.26F, 0.30F), new Vector2(0.24F, 0.31F) });
		}

		[UnityTest]
		public IEnumerator SaveVector2ArrayProperty()
		{
			yield return RunTest<Vector2ArrayProperty1, Vector2[]>(new Vector2[] { new Vector2(0.76F, 0.59F), new Vector2(0.12F, 0.49F) });
			yield return RunTest<Vector2ArrayProperty2, Vector2[]>(new Vector2[] { new Vector2(0.12F, 0.49F), new Vector2(0.76F, 0.59F) });
		}

		[UnityTest]
		public IEnumerator SaveVector2ArrayProperties()
		{
			yield return RunTest<Vector2ArrayProperties1, Vector2[]>(new Vector2[] { new Vector2(0.76F, 0.59F), new Vector2(0.12F, 0.49F) }, new Vector2[] { new Vector2(0.24F, 0.31F), new Vector2(0.26F, 0.30F) });
			yield return RunTest<Vector2ArrayProperties2, Vector2[]>(new Vector2[] { new Vector2(0.12F, 0.49F), new Vector2(0.76F, 0.59F) }, new Vector2[] { new Vector2(0.26F, 0.30F), new Vector2(0.24F, 0.31F) });
		}

		[UnityTest]
		public IEnumerator SaveVector2ArrayNullableField()
		{
			yield return RunTest<Vector2ArrayNullableField1, Vector2?[]>(new Vector2?[] { null, new Vector2(0.12F, 0.49F) });
			yield return RunTest<Vector2ArrayNullableField2, Vector2?[]>(new Vector2?[] { new Vector2(0.12F, 0.49F), null });
		}

		[UnityTest]
		public IEnumerator SaveVector2ArrayNullableFields()
		{
			yield return RunTest<Vector2ArrayNullableFields1, Vector2?[]>(new Vector2?[] { null, new Vector2(0.12F, 0.49F) }, new Vector2?[] { new Vector2(0.24F, 0.31F), null });
			yield return RunTest<Vector2ArrayNullableFields2, Vector2?[]>(new Vector2?[] { new Vector2(0.12F, 0.49F), null }, new Vector2?[] { null, new Vector2(0.24F, 0.31F) });
		}

		[UnityTest]
		public IEnumerator SaveVector2ArrayNullableProperty()
		{
			yield return RunTest<Vector2ArrayNullableProperty1, Vector2?[]>(new Vector2?[] { null, new Vector2(0.12F, 0.49F) });
			yield return RunTest<Vector2ArrayNullableProperty2, Vector2?[]>(new Vector2?[] { new Vector2(0.12F, 0.49F), null });
		}

		[UnityTest]
		public IEnumerator SaveVector2ArrayNullableProperties()
		{
			yield return RunTest<Vector2ArrayNullableProperties1, Vector2?[]>(new Vector2?[] { new Vector2(0.76F, 0.59F), null }, new Vector2?[] { null, new Vector2(0.26F, 0.30F) });
			yield return RunTest<Vector2ArrayNullableProperties2, Vector2?[]>(new Vector2?[] { null, new Vector2(0.76F, 0.59F) }, new Vector2?[] { new Vector2(0.26F, 0.30F), null });
		}

		[UnityTest]
		public IEnumerator SaveVector2ListField()
		{
			yield return RunTest<Vector2ListField1, List<Vector2>>(new List<Vector2> { new Vector2(0.76F, 0.59F), new Vector2(0.12F, 0.49F) });
			yield return RunTest<Vector2ListField2, List<Vector2>>(new List<Vector2> { new Vector2(0.12F, 0.49F), new Vector2(0.76F, 0.59F) });
		}

		[UnityTest]
		public IEnumerator SaveVector2ListFields()
		{
			yield return RunTest<Vector2ListFields1, List<Vector2>>(new List<Vector2> { new Vector2(0.76F, 0.59F), new Vector2(0.12F, 0.49F) }, new List<Vector2> { new Vector2(0.24F, 0.31F), new Vector2(0.26F, 0.30F) });
			yield return RunTest<Vector2ListFields2, List<Vector2>>(new List<Vector2> { new Vector2(0.12F, 0.49F), new Vector2(0.76F, 0.59F) }, new List<Vector2> { new Vector2(0.26F, 0.30F), new Vector2(0.24F, 0.31F) });
		}

		[UnityTest]
		public IEnumerator SaveVector2ListProperty()
		{
			yield return RunTest<Vector2ListProperty1, List<Vector2>>(new List<Vector2> { new Vector2(0.76F, 0.59F), new Vector2(0.12F, 0.49F) });
			yield return RunTest<Vector2ListProperty2, List<Vector2>>(new List<Vector2> { new Vector2(0.12F, 0.49F), new Vector2(0.76F, 0.59F) });
		}

		[UnityTest]
		public IEnumerator SaveVector2ListProperties()
		{
			yield return RunTest<Vector2ListProperties1, List<Vector2>>(new List<Vector2> { new Vector2(0.76F, 0.59F), new Vector2(0.12F, 0.49F) }, new List<Vector2> { new Vector2(0.24F, 0.31F), new Vector2(0.26F, 0.30F) });
			yield return RunTest<Vector2ListProperties2, List<Vector2>>(new List<Vector2> { new Vector2(0.12F, 0.49F), new Vector2(0.76F, 0.59F) }, new List<Vector2> { new Vector2(0.26F, 0.30F), new Vector2(0.24F, 0.31F) });
		}

		[UnityTest]
		public IEnumerator SaveVector2ListNullableField()
		{
			yield return RunTest<Vector2ListNullableField1, List<Vector2?>>(new List<Vector2?> { null, new Vector2(0.12F, 0.49F) });
			yield return RunTest<Vector2ListNullableField2, List<Vector2?>>(new List<Vector2?> { new Vector2(0.12F, 0.49F), null });
		}

		[UnityTest]
		public IEnumerator SaveVector2ListNullableFields()
		{
			yield return RunTest<Vector2ListNullableFields1, List<Vector2?>>(new List<Vector2?> { null, new Vector2(0.12F, 0.49F) }, new List<Vector2?> { new Vector2(0.24F, 0.31F), null });
			yield return RunTest<Vector2ListNullableFields2, List<Vector2?>>(new List<Vector2?> { new Vector2(0.12F, 0.49F), null }, new List<Vector2?> { null, new Vector2(0.24F, 0.31F) });
		}

		[UnityTest]
		public IEnumerator SaveVector2ListNullableProperty()
		{
			yield return RunTest<Vector2ListNullableProperty1, List<Vector2?>>(new List<Vector2?> { null, new Vector2(0.12F, 0.49F) });
			yield return RunTest<Vector2ListNullableProperty2, List<Vector2?>>(new List<Vector2?> { new Vector2(0.12F, 0.49F), null });
		}

		[UnityTest]
		public IEnumerator SaveVector2ListNullableProperties()
		{
			yield return RunTest<Vector2ListNullableProperties1, List<Vector2?>>(new List<Vector2?> { new Vector2(0.76F, 0.59F), null }, new List<Vector2?> { null, new Vector2(0.26F, 0.30F) });
			yield return RunTest<Vector2ListNullableProperties2, List<Vector2?>>(new List<Vector2?> { null, new Vector2(0.76F, 0.59F) }, new List<Vector2?> { new Vector2(0.26F, 0.30F), null });
		}
	}
}