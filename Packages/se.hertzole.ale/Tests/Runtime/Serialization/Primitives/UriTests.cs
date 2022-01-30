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
		public IEnumerator SaveUriField()
		{
			yield return RunTest<UriField1, Uri>(new Uri("https://www.oelU.com"));
			yield return RunTest<UriField2, Uri>(new Uri("https://www.jQQA.com"));
		}

		[UnityTest]
		public IEnumerator SaveUriFields()
		{
			yield return RunTest<UriFields1, Uri>(new Uri("https://www.jQQA.com"), new Uri("https://www.oelU.com"));
			yield return RunTest<UriFields2, Uri>(new Uri("https://www.oelU.com"), new Uri("https://www.jQQA.com"));
		}

		[UnityTest]
		public IEnumerator SaveUriProperty()
		{
			yield return RunTest<UriProperty1, Uri>(new Uri("https://www.oelU.com"));
			yield return RunTest<UriProperty2, Uri>(new Uri("https://www.jQQA.com"));
		}

		[UnityTest]
		public IEnumerator SaveUriProperties()
		{
			yield return RunTest<UriProperties1, Uri>(new Uri("https://www.jQQA.com"), new Uri("https://www.oelU.com"));
			yield return RunTest<UriProperties2, Uri>(new Uri("https://www.oelU.com"), new Uri("https://www.jQQA.com"));
		}

		[UnityTest]
		public IEnumerator SaveUriNullableField()
		{
			yield return RunTest<UriNullableField1, Uri?>(new Uri("https://www.oelU.com"));
			yield return RunTest<UriNullableField2, Uri?>(new Uri("https://www.jQQA.com"));
			yield return RunTest<UriNullableField1, Uri?>(null);
			yield return RunTest<UriNullableField2, Uri?>(null);
		}

		[UnityTest]
		public IEnumerator SaveUriNullableFields()
		{
			yield return RunTest<UriNullableFields1, Uri?>(new Uri("https://www.jQQA.com"), new Uri("https://www.oelU.com"));
			yield return RunTest<UriNullableFields2, Uri?>(new Uri("https://www.oelU.com"), new Uri("https://www.jQQA.com"));
			yield return RunTest<UriNullableFields1, Uri?>(null, new Uri("https://www.oelU.com"));
			yield return RunTest<UriNullableFields2, Uri?>(new Uri("https://www.oelU.com"), null);
		}

		[UnityTest]
		public IEnumerator SaveUriNullableProperty()
		{
			yield return RunTest<UriNullableProperty1, Uri?>(new Uri("https://www.oelU.com"));
			yield return RunTest<UriNullableProperty2, Uri?>(new Uri("https://www.jQQA.com"));
			yield return RunTest<UriNullableProperty1, Uri?>(null);
			yield return RunTest<UriNullableProperty2, Uri?>(null);
		}

		[UnityTest]
		public IEnumerator SaveUriNullableProperties()
		{
			yield return RunTest<UriNullableProperties1, Uri?>(new Uri("https://www.jQQA.com"), new Uri("https://www.oelU.com"));
			yield return RunTest<UriNullableProperties2, Uri?>(new Uri("https://www.oelU.com"), new Uri("https://www.jQQA.com"));
			yield return RunTest<UriNullableProperties1, Uri?>(null, new Uri("https://www.oelU.com"));
			yield return RunTest<UriNullableProperties2, Uri?>(new Uri("https://www.oelU.com"), null);
		}

		[UnityTest]
		public IEnumerator SaveUriArrayField()
		{
			yield return RunTest<UriArrayField1, Uri[]>(new Uri[] { new Uri("https://www.oelU.com"), new Uri("https://www.jQQA.com") });
			yield return RunTest<UriArrayField2, Uri[]>(new Uri[] { new Uri("https://www.jQQA.com"), new Uri("https://www.oelU.com") });
		}

		[UnityTest]
		public IEnumerator SaveUriArrayFields()
		{
			yield return RunTest<UriArrayFields1, Uri[]>(new Uri[] { new Uri("https://www.oelU.com"), new Uri("https://www.jQQA.com") }, new Uri[] { new Uri("https://www.gpVA.com"), new Uri("https://www.XnXN.com") });
			yield return RunTest<UriArrayFields2, Uri[]>(new Uri[] { new Uri("https://www.jQQA.com"), new Uri("https://www.oelU.com") }, new Uri[] { new Uri("https://www.XnXN.com"), new Uri("https://www.gpVA.com") });
		}

		[UnityTest]
		public IEnumerator SaveUriArrayProperty()
		{
			yield return RunTest<UriArrayProperty1, Uri[]>(new Uri[] { new Uri("https://www.oelU.com"), new Uri("https://www.jQQA.com") });
			yield return RunTest<UriArrayProperty2, Uri[]>(new Uri[] { new Uri("https://www.jQQA.com"), new Uri("https://www.oelU.com") });
		}

		[UnityTest]
		public IEnumerator SaveUriArrayProperties()
		{
			yield return RunTest<UriArrayProperties1, Uri[]>(new Uri[] { new Uri("https://www.oelU.com"), new Uri("https://www.jQQA.com") }, new Uri[] { new Uri("https://www.gpVA.com"), new Uri("https://www.XnXN.com") });
			yield return RunTest<UriArrayProperties2, Uri[]>(new Uri[] { new Uri("https://www.jQQA.com"), new Uri("https://www.oelU.com") }, new Uri[] { new Uri("https://www.XnXN.com"), new Uri("https://www.gpVA.com") });
		}

		[UnityTest]
		public IEnumerator SaveUriArrayNullableField()
		{
			yield return RunTest<UriArrayNullableField1, Uri?[]>(new Uri?[] { null, new Uri("https://www.jQQA.com") });
			yield return RunTest<UriArrayNullableField2, Uri?[]>(new Uri?[] { new Uri("https://www.jQQA.com"), null });
		}

		[UnityTest]
		public IEnumerator SaveUriArrayNullableFields()
		{
			yield return RunTest<UriArrayNullableFields1, Uri?[]>(new Uri?[] { null, new Uri("https://www.jQQA.com") }, new Uri?[] { new Uri("https://www.gpVA.com"), null });
			yield return RunTest<UriArrayNullableFields2, Uri?[]>(new Uri?[] { new Uri("https://www.jQQA.com"), null }, new Uri?[] { null, new Uri("https://www.gpVA.com") });
		}

		[UnityTest]
		public IEnumerator SaveUriArrayNullableProperty()
		{
			yield return RunTest<UriArrayNullableProperty1, Uri?[]>(new Uri?[] { null, new Uri("https://www.jQQA.com") });
			yield return RunTest<UriArrayNullableProperty2, Uri?[]>(new Uri?[] { new Uri("https://www.jQQA.com"), null });
		}

		[UnityTest]
		public IEnumerator SaveUriArrayNullableProperties()
		{
			yield return RunTest<UriArrayNullableProperties1, Uri?[]>(new Uri?[] { new Uri("https://www.oelU.com"), null }, new Uri?[] { null, new Uri("https://www.XnXN.com") });
			yield return RunTest<UriArrayNullableProperties2, Uri?[]>(new Uri?[] { null, new Uri("https://www.oelU.com") }, new Uri?[] { new Uri("https://www.XnXN.com"), null });
		}

		[UnityTest]
		public IEnumerator SaveUriListField()
		{
			yield return RunTest<UriListField1, List<Uri>>(new List<Uri> { new Uri("https://www.oelU.com"), new Uri("https://www.jQQA.com") });
			yield return RunTest<UriListField2, List<Uri>>(new List<Uri> { new Uri("https://www.jQQA.com"), new Uri("https://www.oelU.com") });
		}

		[UnityTest]
		public IEnumerator SaveUriListFields()
		{
			yield return RunTest<UriListFields1, List<Uri>>(new List<Uri> { new Uri("https://www.oelU.com"), new Uri("https://www.jQQA.com") }, new List<Uri> { new Uri("https://www.gpVA.com"), new Uri("https://www.XnXN.com") });
			yield return RunTest<UriListFields2, List<Uri>>(new List<Uri> { new Uri("https://www.jQQA.com"), new Uri("https://www.oelU.com") }, new List<Uri> { new Uri("https://www.XnXN.com"), new Uri("https://www.gpVA.com") });
		}

		[UnityTest]
		public IEnumerator SaveUriListProperty()
		{
			yield return RunTest<UriListProperty1, List<Uri>>(new List<Uri> { new Uri("https://www.oelU.com"), new Uri("https://www.jQQA.com") });
			yield return RunTest<UriListProperty2, List<Uri>>(new List<Uri> { new Uri("https://www.jQQA.com"), new Uri("https://www.oelU.com") });
		}

		[UnityTest]
		public IEnumerator SaveUriListProperties()
		{
			yield return RunTest<UriListProperties1, List<Uri>>(new List<Uri> { new Uri("https://www.oelU.com"), new Uri("https://www.jQQA.com") }, new List<Uri> { new Uri("https://www.gpVA.com"), new Uri("https://www.XnXN.com") });
			yield return RunTest<UriListProperties2, List<Uri>>(new List<Uri> { new Uri("https://www.jQQA.com"), new Uri("https://www.oelU.com") }, new List<Uri> { new Uri("https://www.XnXN.com"), new Uri("https://www.gpVA.com") });
		}

		[UnityTest]
		public IEnumerator SaveUriListNullableField()
		{
			yield return RunTest<UriListNullableField1, List<Uri?>>(new List<Uri?> { null, new Uri("https://www.jQQA.com") });
			yield return RunTest<UriListNullableField2, List<Uri?>>(new List<Uri?> { new Uri("https://www.jQQA.com"), null });
		}

		[UnityTest]
		public IEnumerator SaveUriListNullableFields()
		{
			yield return RunTest<UriListNullableFields1, List<Uri?>>(new List<Uri?> { null, new Uri("https://www.jQQA.com") }, new List<Uri?> { new Uri("https://www.gpVA.com"), null });
			yield return RunTest<UriListNullableFields2, List<Uri?>>(new List<Uri?> { new Uri("https://www.jQQA.com"), null }, new List<Uri?> { null, new Uri("https://www.gpVA.com") });
		}

		[UnityTest]
		public IEnumerator SaveUriListNullableProperty()
		{
			yield return RunTest<UriListNullableProperty1, List<Uri?>>(new List<Uri?> { null, new Uri("https://www.jQQA.com") });
			yield return RunTest<UriListNullableProperty2, List<Uri?>>(new List<Uri?> { new Uri("https://www.jQQA.com"), null });
		}

		[UnityTest]
		public IEnumerator SaveUriListNullableProperties()
		{
			yield return RunTest<UriListNullableProperties1, List<Uri?>>(new List<Uri?> { new Uri("https://www.oelU.com"), null }, new List<Uri?> { null, new Uri("https://www.XnXN.com") });
			yield return RunTest<UriListNullableProperties2, List<Uri?>>(new List<Uri?> { null, new Uri("https://www.oelU.com") }, new List<Uri?> { new Uri("https://www.XnXN.com"), null });
		}
	}
}