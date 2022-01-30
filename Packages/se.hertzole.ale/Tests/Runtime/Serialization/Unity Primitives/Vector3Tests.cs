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
		public IEnumerator SaveVector3Field()
		{
			yield return RunTest<Vector3Field1, Vector3>(new Vector3(0.49F, 0.39F, 0.69F));
			yield return RunTest<Vector3Field2, Vector3>(new Vector3(0.78F, 0.20F, 0.44F));
		}

		[UnityTest]
		public IEnumerator SaveVector3Fields()
		{
			yield return RunTest<Vector3Fields1, Vector3>(new Vector3(0.78F, 0.20F, 0.44F), new Vector3(0.49F, 0.39F, 0.69F));
			yield return RunTest<Vector3Fields2, Vector3>(new Vector3(0.49F, 0.39F, 0.69F), new Vector3(0.78F, 0.20F, 0.44F));
		}

		[UnityTest]
		public IEnumerator SaveVector3Property()
		{
			yield return RunTest<Vector3Property1, Vector3>(new Vector3(0.49F, 0.39F, 0.69F));
			yield return RunTest<Vector3Property2, Vector3>(new Vector3(0.78F, 0.20F, 0.44F));
		}

		[UnityTest]
		public IEnumerator SaveVector3Properties()
		{
			yield return RunTest<Vector3Properties1, Vector3>(new Vector3(0.78F, 0.20F, 0.44F), new Vector3(0.49F, 0.39F, 0.69F));
			yield return RunTest<Vector3Properties2, Vector3>(new Vector3(0.49F, 0.39F, 0.69F), new Vector3(0.78F, 0.20F, 0.44F));
		}

		[UnityTest]
		public IEnumerator SaveVector3NullableField()
		{
			yield return RunTest<Vector3NullableField1, Vector3?>(new Vector3(0.49F, 0.39F, 0.69F));
			yield return RunTest<Vector3NullableField2, Vector3?>(new Vector3(0.78F, 0.20F, 0.44F));
			yield return RunTest<Vector3NullableField1, Vector3?>(null);
			yield return RunTest<Vector3NullableField2, Vector3?>(null);
		}

		[UnityTest]
		public IEnumerator SaveVector3NullableFields()
		{
			yield return RunTest<Vector3NullableFields1, Vector3?>(new Vector3(0.78F, 0.20F, 0.44F), new Vector3(0.49F, 0.39F, 0.69F));
			yield return RunTest<Vector3NullableFields2, Vector3?>(new Vector3(0.49F, 0.39F, 0.69F), new Vector3(0.78F, 0.20F, 0.44F));
			yield return RunTest<Vector3NullableFields1, Vector3?>(null, new Vector3(0.49F, 0.39F, 0.69F));
			yield return RunTest<Vector3NullableFields2, Vector3?>(new Vector3(0.49F, 0.39F, 0.69F), null);
		}

		[UnityTest]
		public IEnumerator SaveVector3NullableProperty()
		{
			yield return RunTest<Vector3NullableProperty1, Vector3?>(new Vector3(0.49F, 0.39F, 0.69F));
			yield return RunTest<Vector3NullableProperty2, Vector3?>(new Vector3(0.78F, 0.20F, 0.44F));
			yield return RunTest<Vector3NullableProperty1, Vector3?>(null);
			yield return RunTest<Vector3NullableProperty2, Vector3?>(null);
		}

		[UnityTest]
		public IEnumerator SaveVector3NullableProperties()
		{
			yield return RunTest<Vector3NullableProperties1, Vector3?>(new Vector3(0.78F, 0.20F, 0.44F), new Vector3(0.49F, 0.39F, 0.69F));
			yield return RunTest<Vector3NullableProperties2, Vector3?>(new Vector3(0.49F, 0.39F, 0.69F), new Vector3(0.78F, 0.20F, 0.44F));
			yield return RunTest<Vector3NullableProperties1, Vector3?>(null, new Vector3(0.49F, 0.39F, 0.69F));
			yield return RunTest<Vector3NullableProperties2, Vector3?>(new Vector3(0.49F, 0.39F, 0.69F), null);
		}

		[UnityTest]
		public IEnumerator SaveVector3ArrayField()
		{
			yield return RunTest<Vector3ArrayField1, Vector3[]>(new Vector3[] { new Vector3(0.49F, 0.39F, 0.69F), new Vector3(0.78F, 0.20F, 0.44F) });
			yield return RunTest<Vector3ArrayField2, Vector3[]>(new Vector3[] { new Vector3(0.78F, 0.20F, 0.44F), new Vector3(0.49F, 0.39F, 0.69F) });
		}

		[UnityTest]
		public IEnumerator SaveVector3ArrayFields()
		{
			yield return RunTest<Vector3ArrayFields1, Vector3[]>(new Vector3[] { new Vector3(0.49F, 0.39F, 0.69F), new Vector3(0.78F, 0.20F, 0.44F) }, new Vector3[] { new Vector3(0.66F, 0.04F, 0.76F), new Vector3(0.74F, 0.44F, 0.74F) });
			yield return RunTest<Vector3ArrayFields2, Vector3[]>(new Vector3[] { new Vector3(0.78F, 0.20F, 0.44F), new Vector3(0.49F, 0.39F, 0.69F) }, new Vector3[] { new Vector3(0.74F, 0.44F, 0.74F), new Vector3(0.66F, 0.04F, 0.76F) });
		}

		[UnityTest]
		public IEnumerator SaveVector3ArrayProperty()
		{
			yield return RunTest<Vector3ArrayProperty1, Vector3[]>(new Vector3[] { new Vector3(0.49F, 0.39F, 0.69F), new Vector3(0.78F, 0.20F, 0.44F) });
			yield return RunTest<Vector3ArrayProperty2, Vector3[]>(new Vector3[] { new Vector3(0.78F, 0.20F, 0.44F), new Vector3(0.49F, 0.39F, 0.69F) });
		}

		[UnityTest]
		public IEnumerator SaveVector3ArrayProperties()
		{
			yield return RunTest<Vector3ArrayProperties1, Vector3[]>(new Vector3[] { new Vector3(0.49F, 0.39F, 0.69F), new Vector3(0.78F, 0.20F, 0.44F) }, new Vector3[] { new Vector3(0.66F, 0.04F, 0.76F), new Vector3(0.74F, 0.44F, 0.74F) });
			yield return RunTest<Vector3ArrayProperties2, Vector3[]>(new Vector3[] { new Vector3(0.78F, 0.20F, 0.44F), new Vector3(0.49F, 0.39F, 0.69F) }, new Vector3[] { new Vector3(0.74F, 0.44F, 0.74F), new Vector3(0.66F, 0.04F, 0.76F) });
		}

		[UnityTest]
		public IEnumerator SaveVector3ArrayNullableField()
		{
			yield return RunTest<Vector3ArrayNullableField1, Vector3?[]>(new Vector3?[] { null, new Vector3(0.78F, 0.20F, 0.44F) });
			yield return RunTest<Vector3ArrayNullableField2, Vector3?[]>(new Vector3?[] { new Vector3(0.78F, 0.20F, 0.44F), null });
		}

		[UnityTest]
		public IEnumerator SaveVector3ArrayNullableFields()
		{
			yield return RunTest<Vector3ArrayNullableFields1, Vector3?[]>(new Vector3?[] { null, new Vector3(0.78F, 0.20F, 0.44F) }, new Vector3?[] { new Vector3(0.66F, 0.04F, 0.76F), null });
			yield return RunTest<Vector3ArrayNullableFields2, Vector3?[]>(new Vector3?[] { new Vector3(0.78F, 0.20F, 0.44F), null }, new Vector3?[] { null, new Vector3(0.66F, 0.04F, 0.76F) });
		}

		[UnityTest]
		public IEnumerator SaveVector3ArrayNullableProperty()
		{
			yield return RunTest<Vector3ArrayNullableProperty1, Vector3?[]>(new Vector3?[] { null, new Vector3(0.78F, 0.20F, 0.44F) });
			yield return RunTest<Vector3ArrayNullableProperty2, Vector3?[]>(new Vector3?[] { new Vector3(0.78F, 0.20F, 0.44F), null });
		}

		[UnityTest]
		public IEnumerator SaveVector3ArrayNullableProperties()
		{
			yield return RunTest<Vector3ArrayNullableProperties1, Vector3?[]>(new Vector3?[] { new Vector3(0.49F, 0.39F, 0.69F), null }, new Vector3?[] { null, new Vector3(0.74F, 0.44F, 0.74F) });
			yield return RunTest<Vector3ArrayNullableProperties2, Vector3?[]>(new Vector3?[] { null, new Vector3(0.49F, 0.39F, 0.69F) }, new Vector3?[] { new Vector3(0.74F, 0.44F, 0.74F), null });
		}

		[UnityTest]
		public IEnumerator SaveVector3ListField()
		{
			yield return RunTest<Vector3ListField1, List<Vector3>>(new List<Vector3> { new Vector3(0.49F, 0.39F, 0.69F), new Vector3(0.78F, 0.20F, 0.44F) });
			yield return RunTest<Vector3ListField2, List<Vector3>>(new List<Vector3> { new Vector3(0.78F, 0.20F, 0.44F), new Vector3(0.49F, 0.39F, 0.69F) });
		}

		[UnityTest]
		public IEnumerator SaveVector3ListFields()
		{
			yield return RunTest<Vector3ListFields1, List<Vector3>>(new List<Vector3> { new Vector3(0.49F, 0.39F, 0.69F), new Vector3(0.78F, 0.20F, 0.44F) }, new List<Vector3> { new Vector3(0.66F, 0.04F, 0.76F), new Vector3(0.74F, 0.44F, 0.74F) });
			yield return RunTest<Vector3ListFields2, List<Vector3>>(new List<Vector3> { new Vector3(0.78F, 0.20F, 0.44F), new Vector3(0.49F, 0.39F, 0.69F) }, new List<Vector3> { new Vector3(0.74F, 0.44F, 0.74F), new Vector3(0.66F, 0.04F, 0.76F) });
		}

		[UnityTest]
		public IEnumerator SaveVector3ListProperty()
		{
			yield return RunTest<Vector3ListProperty1, List<Vector3>>(new List<Vector3> { new Vector3(0.49F, 0.39F, 0.69F), new Vector3(0.78F, 0.20F, 0.44F) });
			yield return RunTest<Vector3ListProperty2, List<Vector3>>(new List<Vector3> { new Vector3(0.78F, 0.20F, 0.44F), new Vector3(0.49F, 0.39F, 0.69F) });
		}

		[UnityTest]
		public IEnumerator SaveVector3ListProperties()
		{
			yield return RunTest<Vector3ListProperties1, List<Vector3>>(new List<Vector3> { new Vector3(0.49F, 0.39F, 0.69F), new Vector3(0.78F, 0.20F, 0.44F) }, new List<Vector3> { new Vector3(0.66F, 0.04F, 0.76F), new Vector3(0.74F, 0.44F, 0.74F) });
			yield return RunTest<Vector3ListProperties2, List<Vector3>>(new List<Vector3> { new Vector3(0.78F, 0.20F, 0.44F), new Vector3(0.49F, 0.39F, 0.69F) }, new List<Vector3> { new Vector3(0.74F, 0.44F, 0.74F), new Vector3(0.66F, 0.04F, 0.76F) });
		}

		[UnityTest]
		public IEnumerator SaveVector3ListNullableField()
		{
			yield return RunTest<Vector3ListNullableField1, List<Vector3?>>(new List<Vector3?> { null, new Vector3(0.78F, 0.20F, 0.44F) });
			yield return RunTest<Vector3ListNullableField2, List<Vector3?>>(new List<Vector3?> { new Vector3(0.78F, 0.20F, 0.44F), null });
		}

		[UnityTest]
		public IEnumerator SaveVector3ListNullableFields()
		{
			yield return RunTest<Vector3ListNullableFields1, List<Vector3?>>(new List<Vector3?> { null, new Vector3(0.78F, 0.20F, 0.44F) }, new List<Vector3?> { new Vector3(0.66F, 0.04F, 0.76F), null });
			yield return RunTest<Vector3ListNullableFields2, List<Vector3?>>(new List<Vector3?> { new Vector3(0.78F, 0.20F, 0.44F), null }, new List<Vector3?> { null, new Vector3(0.66F, 0.04F, 0.76F) });
		}

		[UnityTest]
		public IEnumerator SaveVector3ListNullableProperty()
		{
			yield return RunTest<Vector3ListNullableProperty1, List<Vector3?>>(new List<Vector3?> { null, new Vector3(0.78F, 0.20F, 0.44F) });
			yield return RunTest<Vector3ListNullableProperty2, List<Vector3?>>(new List<Vector3?> { new Vector3(0.78F, 0.20F, 0.44F), null });
		}

		[UnityTest]
		public IEnumerator SaveVector3ListNullableProperties()
		{
			yield return RunTest<Vector3ListNullableProperties1, List<Vector3?>>(new List<Vector3?> { new Vector3(0.49F, 0.39F, 0.69F), null }, new List<Vector3?> { null, new Vector3(0.74F, 0.44F, 0.74F) });
			yield return RunTest<Vector3ListNullableProperties2, List<Vector3?>>(new List<Vector3?> { null, new Vector3(0.49F, 0.39F, 0.69F) }, new List<Vector3?> { new Vector3(0.74F, 0.44F, 0.74F), null });
		}
	}
}