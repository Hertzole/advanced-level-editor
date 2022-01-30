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
		public IEnumerator SaveVector4Field()
		{
			yield return RunTest<Vector4Field1, Vector4>(new Vector4(0.28F, 0.92F, 0.48F, 0.82F));
			yield return RunTest<Vector4Field2, Vector4>(new Vector4(0.08F, 0.08F, 0.31F, 0.96F));
		}

		[UnityTest]
		public IEnumerator SaveVector4Fields()
		{
			yield return RunTest<Vector4Fields1, Vector4>(new Vector4(0.08F, 0.08F, 0.31F, 0.96F), new Vector4(0.28F, 0.92F, 0.48F, 0.82F));
			yield return RunTest<Vector4Fields2, Vector4>(new Vector4(0.28F, 0.92F, 0.48F, 0.82F), new Vector4(0.08F, 0.08F, 0.31F, 0.96F));
		}

		[UnityTest]
		public IEnumerator SaveVector4Property()
		{
			yield return RunTest<Vector4Property1, Vector4>(new Vector4(0.28F, 0.92F, 0.48F, 0.82F));
			yield return RunTest<Vector4Property2, Vector4>(new Vector4(0.08F, 0.08F, 0.31F, 0.96F));
		}

		[UnityTest]
		public IEnumerator SaveVector4Properties()
		{
			yield return RunTest<Vector4Properties1, Vector4>(new Vector4(0.08F, 0.08F, 0.31F, 0.96F), new Vector4(0.28F, 0.92F, 0.48F, 0.82F));
			yield return RunTest<Vector4Properties2, Vector4>(new Vector4(0.28F, 0.92F, 0.48F, 0.82F), new Vector4(0.08F, 0.08F, 0.31F, 0.96F));
		}

		[UnityTest]
		public IEnumerator SaveVector4NullableField()
		{
			yield return RunTest<Vector4NullableField1, Vector4?>(new Vector4(0.28F, 0.92F, 0.48F, 0.82F));
			yield return RunTest<Vector4NullableField2, Vector4?>(new Vector4(0.08F, 0.08F, 0.31F, 0.96F));
			yield return RunTest<Vector4NullableField1, Vector4?>(null);
			yield return RunTest<Vector4NullableField2, Vector4?>(null);
		}

		[UnityTest]
		public IEnumerator SaveVector4NullableFields()
		{
			yield return RunTest<Vector4NullableFields1, Vector4?>(new Vector4(0.08F, 0.08F, 0.31F, 0.96F), new Vector4(0.28F, 0.92F, 0.48F, 0.82F));
			yield return RunTest<Vector4NullableFields2, Vector4?>(new Vector4(0.28F, 0.92F, 0.48F, 0.82F), new Vector4(0.08F, 0.08F, 0.31F, 0.96F));
			yield return RunTest<Vector4NullableFields1, Vector4?>(null, new Vector4(0.28F, 0.92F, 0.48F, 0.82F));
			yield return RunTest<Vector4NullableFields2, Vector4?>(new Vector4(0.28F, 0.92F, 0.48F, 0.82F), null);
		}

		[UnityTest]
		public IEnumerator SaveVector4NullableProperty()
		{
			yield return RunTest<Vector4NullableProperty1, Vector4?>(new Vector4(0.28F, 0.92F, 0.48F, 0.82F));
			yield return RunTest<Vector4NullableProperty2, Vector4?>(new Vector4(0.08F, 0.08F, 0.31F, 0.96F));
			yield return RunTest<Vector4NullableProperty1, Vector4?>(null);
			yield return RunTest<Vector4NullableProperty2, Vector4?>(null);
		}

		[UnityTest]
		public IEnumerator SaveVector4NullableProperties()
		{
			yield return RunTest<Vector4NullableProperties1, Vector4?>(new Vector4(0.08F, 0.08F, 0.31F, 0.96F), new Vector4(0.28F, 0.92F, 0.48F, 0.82F));
			yield return RunTest<Vector4NullableProperties2, Vector4?>(new Vector4(0.28F, 0.92F, 0.48F, 0.82F), new Vector4(0.08F, 0.08F, 0.31F, 0.96F));
			yield return RunTest<Vector4NullableProperties1, Vector4?>(null, new Vector4(0.28F, 0.92F, 0.48F, 0.82F));
			yield return RunTest<Vector4NullableProperties2, Vector4?>(new Vector4(0.28F, 0.92F, 0.48F, 0.82F), null);
		}

		[UnityTest]
		public IEnumerator SaveVector4ArrayField()
		{
			yield return RunTest<Vector4ArrayField1, Vector4[]>(new Vector4[] { new Vector4(0.28F, 0.92F, 0.48F, 0.82F), new Vector4(0.08F, 0.08F, 0.31F, 0.96F) });
			yield return RunTest<Vector4ArrayField2, Vector4[]>(new Vector4[] { new Vector4(0.08F, 0.08F, 0.31F, 0.96F), new Vector4(0.28F, 0.92F, 0.48F, 0.82F) });
		}

		[UnityTest]
		public IEnumerator SaveVector4ArrayFields()
		{
			yield return RunTest<Vector4ArrayFields1, Vector4[]>(new Vector4[] { new Vector4(0.28F, 0.92F, 0.48F, 0.82F), new Vector4(0.08F, 0.08F, 0.31F, 0.96F) }, new Vector4[] { new Vector4(0.54F, 0.78F, 0.69F, 0.33F), new Vector4(0.78F, 0.58F, 0.68F, 0.64F) });
			yield return RunTest<Vector4ArrayFields2, Vector4[]>(new Vector4[] { new Vector4(0.08F, 0.08F, 0.31F, 0.96F), new Vector4(0.28F, 0.92F, 0.48F, 0.82F) }, new Vector4[] { new Vector4(0.78F, 0.58F, 0.68F, 0.64F), new Vector4(0.54F, 0.78F, 0.69F, 0.33F) });
		}

		[UnityTest]
		public IEnumerator SaveVector4ArrayProperty()
		{
			yield return RunTest<Vector4ArrayProperty1, Vector4[]>(new Vector4[] { new Vector4(0.28F, 0.92F, 0.48F, 0.82F), new Vector4(0.08F, 0.08F, 0.31F, 0.96F) });
			yield return RunTest<Vector4ArrayProperty2, Vector4[]>(new Vector4[] { new Vector4(0.08F, 0.08F, 0.31F, 0.96F), new Vector4(0.28F, 0.92F, 0.48F, 0.82F) });
		}

		[UnityTest]
		public IEnumerator SaveVector4ArrayProperties()
		{
			yield return RunTest<Vector4ArrayProperties1, Vector4[]>(new Vector4[] { new Vector4(0.28F, 0.92F, 0.48F, 0.82F), new Vector4(0.08F, 0.08F, 0.31F, 0.96F) }, new Vector4[] { new Vector4(0.54F, 0.78F, 0.69F, 0.33F), new Vector4(0.78F, 0.58F, 0.68F, 0.64F) });
			yield return RunTest<Vector4ArrayProperties2, Vector4[]>(new Vector4[] { new Vector4(0.08F, 0.08F, 0.31F, 0.96F), new Vector4(0.28F, 0.92F, 0.48F, 0.82F) }, new Vector4[] { new Vector4(0.78F, 0.58F, 0.68F, 0.64F), new Vector4(0.54F, 0.78F, 0.69F, 0.33F) });
		}

		[UnityTest]
		public IEnumerator SaveVector4ArrayNullableField()
		{
			yield return RunTest<Vector4ArrayNullableField1, Vector4?[]>(new Vector4?[] { null, new Vector4(0.08F, 0.08F, 0.31F, 0.96F) });
			yield return RunTest<Vector4ArrayNullableField2, Vector4?[]>(new Vector4?[] { new Vector4(0.08F, 0.08F, 0.31F, 0.96F), null });
		}

		[UnityTest]
		public IEnumerator SaveVector4ArrayNullableFields()
		{
			yield return RunTest<Vector4ArrayNullableFields1, Vector4?[]>(new Vector4?[] { null, new Vector4(0.08F, 0.08F, 0.31F, 0.96F) }, new Vector4?[] { new Vector4(0.54F, 0.78F, 0.69F, 0.33F), null });
			yield return RunTest<Vector4ArrayNullableFields2, Vector4?[]>(new Vector4?[] { new Vector4(0.08F, 0.08F, 0.31F, 0.96F), null }, new Vector4?[] { null, new Vector4(0.54F, 0.78F, 0.69F, 0.33F) });
		}

		[UnityTest]
		public IEnumerator SaveVector4ArrayNullableProperty()
		{
			yield return RunTest<Vector4ArrayNullableProperty1, Vector4?[]>(new Vector4?[] { null, new Vector4(0.08F, 0.08F, 0.31F, 0.96F) });
			yield return RunTest<Vector4ArrayNullableProperty2, Vector4?[]>(new Vector4?[] { new Vector4(0.08F, 0.08F, 0.31F, 0.96F), null });
		}

		[UnityTest]
		public IEnumerator SaveVector4ArrayNullableProperties()
		{
			yield return RunTest<Vector4ArrayNullableProperties1, Vector4?[]>(new Vector4?[] { new Vector4(0.28F, 0.92F, 0.48F, 0.82F), null }, new Vector4?[] { null, new Vector4(0.78F, 0.58F, 0.68F, 0.64F) });
			yield return RunTest<Vector4ArrayNullableProperties2, Vector4?[]>(new Vector4?[] { null, new Vector4(0.28F, 0.92F, 0.48F, 0.82F) }, new Vector4?[] { new Vector4(0.78F, 0.58F, 0.68F, 0.64F), null });
		}

		[UnityTest]
		public IEnumerator SaveVector4ListField()
		{
			yield return RunTest<Vector4ListField1, List<Vector4>>(new List<Vector4> { new Vector4(0.28F, 0.92F, 0.48F, 0.82F), new Vector4(0.08F, 0.08F, 0.31F, 0.96F) });
			yield return RunTest<Vector4ListField2, List<Vector4>>(new List<Vector4> { new Vector4(0.08F, 0.08F, 0.31F, 0.96F), new Vector4(0.28F, 0.92F, 0.48F, 0.82F) });
		}

		[UnityTest]
		public IEnumerator SaveVector4ListFields()
		{
			yield return RunTest<Vector4ListFields1, List<Vector4>>(new List<Vector4> { new Vector4(0.28F, 0.92F, 0.48F, 0.82F), new Vector4(0.08F, 0.08F, 0.31F, 0.96F) }, new List<Vector4> { new Vector4(0.54F, 0.78F, 0.69F, 0.33F), new Vector4(0.78F, 0.58F, 0.68F, 0.64F) });
			yield return RunTest<Vector4ListFields2, List<Vector4>>(new List<Vector4> { new Vector4(0.08F, 0.08F, 0.31F, 0.96F), new Vector4(0.28F, 0.92F, 0.48F, 0.82F) }, new List<Vector4> { new Vector4(0.78F, 0.58F, 0.68F, 0.64F), new Vector4(0.54F, 0.78F, 0.69F, 0.33F) });
		}

		[UnityTest]
		public IEnumerator SaveVector4ListProperty()
		{
			yield return RunTest<Vector4ListProperty1, List<Vector4>>(new List<Vector4> { new Vector4(0.28F, 0.92F, 0.48F, 0.82F), new Vector4(0.08F, 0.08F, 0.31F, 0.96F) });
			yield return RunTest<Vector4ListProperty2, List<Vector4>>(new List<Vector4> { new Vector4(0.08F, 0.08F, 0.31F, 0.96F), new Vector4(0.28F, 0.92F, 0.48F, 0.82F) });
		}

		[UnityTest]
		public IEnumerator SaveVector4ListProperties()
		{
			yield return RunTest<Vector4ListProperties1, List<Vector4>>(new List<Vector4> { new Vector4(0.28F, 0.92F, 0.48F, 0.82F), new Vector4(0.08F, 0.08F, 0.31F, 0.96F) }, new List<Vector4> { new Vector4(0.54F, 0.78F, 0.69F, 0.33F), new Vector4(0.78F, 0.58F, 0.68F, 0.64F) });
			yield return RunTest<Vector4ListProperties2, List<Vector4>>(new List<Vector4> { new Vector4(0.08F, 0.08F, 0.31F, 0.96F), new Vector4(0.28F, 0.92F, 0.48F, 0.82F) }, new List<Vector4> { new Vector4(0.78F, 0.58F, 0.68F, 0.64F), new Vector4(0.54F, 0.78F, 0.69F, 0.33F) });
		}

		[UnityTest]
		public IEnumerator SaveVector4ListNullableField()
		{
			yield return RunTest<Vector4ListNullableField1, List<Vector4?>>(new List<Vector4?> { null, new Vector4(0.08F, 0.08F, 0.31F, 0.96F) });
			yield return RunTest<Vector4ListNullableField2, List<Vector4?>>(new List<Vector4?> { new Vector4(0.08F, 0.08F, 0.31F, 0.96F), null });
		}

		[UnityTest]
		public IEnumerator SaveVector4ListNullableFields()
		{
			yield return RunTest<Vector4ListNullableFields1, List<Vector4?>>(new List<Vector4?> { null, new Vector4(0.08F, 0.08F, 0.31F, 0.96F) }, new List<Vector4?> { new Vector4(0.54F, 0.78F, 0.69F, 0.33F), null });
			yield return RunTest<Vector4ListNullableFields2, List<Vector4?>>(new List<Vector4?> { new Vector4(0.08F, 0.08F, 0.31F, 0.96F), null }, new List<Vector4?> { null, new Vector4(0.54F, 0.78F, 0.69F, 0.33F) });
		}

		[UnityTest]
		public IEnumerator SaveVector4ListNullableProperty()
		{
			yield return RunTest<Vector4ListNullableProperty1, List<Vector4?>>(new List<Vector4?> { null, new Vector4(0.08F, 0.08F, 0.31F, 0.96F) });
			yield return RunTest<Vector4ListNullableProperty2, List<Vector4?>>(new List<Vector4?> { new Vector4(0.08F, 0.08F, 0.31F, 0.96F), null });
		}

		[UnityTest]
		public IEnumerator SaveVector4ListNullableProperties()
		{
			yield return RunTest<Vector4ListNullableProperties1, List<Vector4?>>(new List<Vector4?> { new Vector4(0.28F, 0.92F, 0.48F, 0.82F), null }, new List<Vector4?> { null, new Vector4(0.78F, 0.58F, 0.68F, 0.64F) });
			yield return RunTest<Vector4ListNullableProperties2, List<Vector4?>>(new List<Vector4?> { null, new Vector4(0.28F, 0.92F, 0.48F, 0.82F) }, new List<Vector4?> { new Vector4(0.78F, 0.58F, 0.68F, 0.64F), null });
		}
	}
}