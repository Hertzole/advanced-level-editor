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
		public IEnumerator SaveStringField()
		{
			yield return RunTest<StringField1, string>("yPMrQGRT4F3mAfMAuj");
			yield return RunTest<StringField2, string>("9K7XLEl1Ix6MNY");
		}

		[UnityTest]
		public IEnumerator SaveStringFields()
		{
			yield return RunTest<StringFields1, string>("9K7XLEl1Ix6MNY", "yPMrQGRT4F3mAfMAuj");
			yield return RunTest<StringFields2, string>("yPMrQGRT4F3mAfMAuj", "9K7XLEl1Ix6MNY");
		}

		[UnityTest]
		public IEnumerator SaveStringProperty()
		{
			yield return RunTest<StringProperty1, string>("yPMrQGRT4F3mAfMAuj");
			yield return RunTest<StringProperty2, string>("9K7XLEl1Ix6MNY");
		}

		[UnityTest]
		public IEnumerator SaveStringProperties()
		{
			yield return RunTest<StringProperties1, string>("9K7XLEl1Ix6MNY", "yPMrQGRT4F3mAfMAuj");
			yield return RunTest<StringProperties2, string>("yPMrQGRT4F3mAfMAuj", "9K7XLEl1Ix6MNY");
		}

		[UnityTest]
		public IEnumerator SaveStringNullableField()
		{
			yield return RunTest<StringNullableField1, string?>("yPMrQGRT4F3mAfMAuj");
			yield return RunTest<StringNullableField2, string?>("9K7XLEl1Ix6MNY");
			yield return RunTest<StringNullableField1, string?>(null);
			yield return RunTest<StringNullableField2, string?>(null);
		}

		[UnityTest]
		public IEnumerator SaveStringNullableFields()
		{
			yield return RunTest<StringNullableFields1, string?>("9K7XLEl1Ix6MNY", "yPMrQGRT4F3mAfMAuj");
			yield return RunTest<StringNullableFields2, string?>("yPMrQGRT4F3mAfMAuj", "9K7XLEl1Ix6MNY");
			yield return RunTest<StringNullableFields1, string?>(null, "yPMrQGRT4F3mAfMAuj");
			yield return RunTest<StringNullableFields2, string?>("yPMrQGRT4F3mAfMAuj", null);
		}

		[UnityTest]
		public IEnumerator SaveStringNullableProperty()
		{
			yield return RunTest<StringNullableProperty1, string?>("yPMrQGRT4F3mAfMAuj");
			yield return RunTest<StringNullableProperty2, string?>("9K7XLEl1Ix6MNY");
			yield return RunTest<StringNullableProperty1, string?>(null);
			yield return RunTest<StringNullableProperty2, string?>(null);
		}

		[UnityTest]
		public IEnumerator SaveStringNullableProperties()
		{
			yield return RunTest<StringNullableProperties1, string?>("9K7XLEl1Ix6MNY", "yPMrQGRT4F3mAfMAuj");
			yield return RunTest<StringNullableProperties2, string?>("yPMrQGRT4F3mAfMAuj", "9K7XLEl1Ix6MNY");
			yield return RunTest<StringNullableProperties1, string?>(null, "yPMrQGRT4F3mAfMAuj");
			yield return RunTest<StringNullableProperties2, string?>("yPMrQGRT4F3mAfMAuj", null);
		}

		[UnityTest]
		public IEnumerator SaveStringArrayField()
		{
			yield return RunTest<StringArrayField1, string[]>(new string[] { "yPMrQGRT4F3mAfMAuj", "9K7XLEl1Ix6MNY" });
			yield return RunTest<StringArrayField2, string[]>(new string[] { "9K7XLEl1Ix6MNY", "yPMrQGRT4F3mAfMAuj" });
		}

		[UnityTest]
		public IEnumerator SaveStringArrayFields()
		{
			yield return RunTest<StringArrayFields1, string[]>(new string[] { "yPMrQGRT4F3mAfMAuj", "9K7XLEl1Ix6MNY" }, new string[] { "4KKh36aN76FT", "9lb6mEYhkkF7H" });
			yield return RunTest<StringArrayFields2, string[]>(new string[] { "9K7XLEl1Ix6MNY", "yPMrQGRT4F3mAfMAuj" }, new string[] { "9lb6mEYhkkF7H", "4KKh36aN76FT" });
		}

		[UnityTest]
		public IEnumerator SaveStringArrayProperty()
		{
			yield return RunTest<StringArrayProperty1, string[]>(new string[] { "yPMrQGRT4F3mAfMAuj", "9K7XLEl1Ix6MNY" });
			yield return RunTest<StringArrayProperty2, string[]>(new string[] { "9K7XLEl1Ix6MNY", "yPMrQGRT4F3mAfMAuj" });
		}

		[UnityTest]
		public IEnumerator SaveStringArrayProperties()
		{
			yield return RunTest<StringArrayProperties1, string[]>(new string[] { "yPMrQGRT4F3mAfMAuj", "9K7XLEl1Ix6MNY" }, new string[] { "4KKh36aN76FT", "9lb6mEYhkkF7H" });
			yield return RunTest<StringArrayProperties2, string[]>(new string[] { "9K7XLEl1Ix6MNY", "yPMrQGRT4F3mAfMAuj" }, new string[] { "9lb6mEYhkkF7H", "4KKh36aN76FT" });
		}

		[UnityTest]
		public IEnumerator SaveStringArrayNullableField()
		{
			yield return RunTest<StringArrayNullableField1, string?[]>(new string?[] { null, "9K7XLEl1Ix6MNY" });
			yield return RunTest<StringArrayNullableField2, string?[]>(new string?[] { "9K7XLEl1Ix6MNY", null });
		}

		[UnityTest]
		public IEnumerator SaveStringArrayNullableFields()
		{
			yield return RunTest<StringArrayNullableFields1, string?[]>(new string?[] { null, "9K7XLEl1Ix6MNY" }, new string?[] { "4KKh36aN76FT", null });
			yield return RunTest<StringArrayNullableFields2, string?[]>(new string?[] { "9K7XLEl1Ix6MNY", null }, new string?[] { null, "4KKh36aN76FT" });
		}

		[UnityTest]
		public IEnumerator SaveStringArrayNullableProperty()
		{
			yield return RunTest<StringArrayNullableProperty1, string?[]>(new string?[] { null, "9K7XLEl1Ix6MNY" });
			yield return RunTest<StringArrayNullableProperty2, string?[]>(new string?[] { "9K7XLEl1Ix6MNY", null });
		}

		[UnityTest]
		public IEnumerator SaveStringArrayNullableProperties()
		{
			yield return RunTest<StringArrayNullableProperties1, string?[]>(new string?[] { "yPMrQGRT4F3mAfMAuj", null }, new string?[] { null, "9lb6mEYhkkF7H" });
			yield return RunTest<StringArrayNullableProperties2, string?[]>(new string?[] { null, "yPMrQGRT4F3mAfMAuj" }, new string?[] { "9lb6mEYhkkF7H", null });
		}

		[UnityTest]
		public IEnumerator SaveStringListField()
		{
			yield return RunTest<StringListField1, List<string>>(new List<string> { "yPMrQGRT4F3mAfMAuj", "9K7XLEl1Ix6MNY" });
			yield return RunTest<StringListField2, List<string>>(new List<string> { "9K7XLEl1Ix6MNY", "yPMrQGRT4F3mAfMAuj" });
		}

		[UnityTest]
		public IEnumerator SaveStringListFields()
		{
			yield return RunTest<StringListFields1, List<string>>(new List<string> { "yPMrQGRT4F3mAfMAuj", "9K7XLEl1Ix6MNY" }, new List<string> { "4KKh36aN76FT", "9lb6mEYhkkF7H" });
			yield return RunTest<StringListFields2, List<string>>(new List<string> { "9K7XLEl1Ix6MNY", "yPMrQGRT4F3mAfMAuj" }, new List<string> { "9lb6mEYhkkF7H", "4KKh36aN76FT" });
		}

		[UnityTest]
		public IEnumerator SaveStringListProperty()
		{
			yield return RunTest<StringListProperty1, List<string>>(new List<string> { "yPMrQGRT4F3mAfMAuj", "9K7XLEl1Ix6MNY" });
			yield return RunTest<StringListProperty2, List<string>>(new List<string> { "9K7XLEl1Ix6MNY", "yPMrQGRT4F3mAfMAuj" });
		}

		[UnityTest]
		public IEnumerator SaveStringListProperties()
		{
			yield return RunTest<StringListProperties1, List<string>>(new List<string> { "yPMrQGRT4F3mAfMAuj", "9K7XLEl1Ix6MNY" }, new List<string> { "4KKh36aN76FT", "9lb6mEYhkkF7H" });
			yield return RunTest<StringListProperties2, List<string>>(new List<string> { "9K7XLEl1Ix6MNY", "yPMrQGRT4F3mAfMAuj" }, new List<string> { "9lb6mEYhkkF7H", "4KKh36aN76FT" });
		}

		[UnityTest]
		public IEnumerator SaveStringListNullableField()
		{
			yield return RunTest<StringListNullableField1, List<string?>>(new List<string?> { null, "9K7XLEl1Ix6MNY" });
			yield return RunTest<StringListNullableField2, List<string?>>(new List<string?> { "9K7XLEl1Ix6MNY", null });
		}

		[UnityTest]
		public IEnumerator SaveStringListNullableFields()
		{
			yield return RunTest<StringListNullableFields1, List<string?>>(new List<string?> { null, "9K7XLEl1Ix6MNY" }, new List<string?> { "4KKh36aN76FT", null });
			yield return RunTest<StringListNullableFields2, List<string?>>(new List<string?> { "9K7XLEl1Ix6MNY", null }, new List<string?> { null, "4KKh36aN76FT" });
		}

		[UnityTest]
		public IEnumerator SaveStringListNullableProperty()
		{
			yield return RunTest<StringListNullableProperty1, List<string?>>(new List<string?> { null, "9K7XLEl1Ix6MNY" });
			yield return RunTest<StringListNullableProperty2, List<string?>>(new List<string?> { "9K7XLEl1Ix6MNY", null });
		}

		[UnityTest]
		public IEnumerator SaveStringListNullableProperties()
		{
			yield return RunTest<StringListNullableProperties1, List<string?>>(new List<string?> { "yPMrQGRT4F3mAfMAuj", null }, new List<string?> { null, "9lb6mEYhkkF7H" });
			yield return RunTest<StringListNullableProperties2, List<string?>>(new List<string?> { null, "yPMrQGRT4F3mAfMAuj" }, new List<string?> { "9lb6mEYhkkF7H", null });
		}
	}
}