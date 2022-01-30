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
		public IEnumerator SaveUlongField()
		{
			yield return RunTest<UlongField1, ulong>(2549827794090373653);
			yield return RunTest<UlongField2, ulong>(3582883266592650326);
		}

		[UnityTest]
		public IEnumerator SaveUlongFields()
		{
			yield return RunTest<UlongFields1, ulong>(3582883266592650326, 2549827794090373653);
			yield return RunTest<UlongFields2, ulong>(2549827794090373653, 3582883266592650326);
		}

		[UnityTest]
		public IEnumerator SaveUlongProperty()
		{
			yield return RunTest<UlongProperty1, ulong>(2549827794090373653);
			yield return RunTest<UlongProperty2, ulong>(3582883266592650326);
		}

		[UnityTest]
		public IEnumerator SaveUlongProperties()
		{
			yield return RunTest<UlongProperties1, ulong>(3582883266592650326, 2549827794090373653);
			yield return RunTest<UlongProperties2, ulong>(2549827794090373653, 3582883266592650326);
		}

		[UnityTest]
		public IEnumerator SaveUlongNullableField()
		{
			yield return RunTest<UlongNullableField1, ulong?>(2549827794090373653);
			yield return RunTest<UlongNullableField2, ulong?>(3582883266592650326);
			yield return RunTest<UlongNullableField1, ulong?>(null);
			yield return RunTest<UlongNullableField2, ulong?>(null);
		}

		[UnityTest]
		public IEnumerator SaveUlongNullableFields()
		{
			yield return RunTest<UlongNullableFields1, ulong?>(3582883266592650326, 2549827794090373653);
			yield return RunTest<UlongNullableFields2, ulong?>(2549827794090373653, 3582883266592650326);
			yield return RunTest<UlongNullableFields1, ulong?>(null, 2549827794090373653);
			yield return RunTest<UlongNullableFields2, ulong?>(2549827794090373653, null);
		}

		[UnityTest]
		public IEnumerator SaveUlongNullableProperty()
		{
			yield return RunTest<UlongNullableProperty1, ulong?>(2549827794090373653);
			yield return RunTest<UlongNullableProperty2, ulong?>(3582883266592650326);
			yield return RunTest<UlongNullableProperty1, ulong?>(null);
			yield return RunTest<UlongNullableProperty2, ulong?>(null);
		}

		[UnityTest]
		public IEnumerator SaveUlongNullableProperties()
		{
			yield return RunTest<UlongNullableProperties1, ulong?>(3582883266592650326, 2549827794090373653);
			yield return RunTest<UlongNullableProperties2, ulong?>(2549827794090373653, 3582883266592650326);
			yield return RunTest<UlongNullableProperties1, ulong?>(null, 2549827794090373653);
			yield return RunTest<UlongNullableProperties2, ulong?>(2549827794090373653, null);
		}

		[UnityTest]
		public IEnumerator SaveUlongArrayField()
		{
			yield return RunTest<UlongArrayField1, ulong[]>(new ulong[] { 2549827794090373653, 3582883266592650326 });
			yield return RunTest<UlongArrayField2, ulong[]>(new ulong[] { 3582883266592650326, 2549827794090373653 });
		}

		[UnityTest]
		public IEnumerator SaveUlongArrayFields()
		{
			yield return RunTest<UlongArrayFields1, ulong[]>(new ulong[] { 2549827794090373653, 3582883266592650326 }, new ulong[] { 7275046138579431351, 3869392535914652102 });
			yield return RunTest<UlongArrayFields2, ulong[]>(new ulong[] { 3582883266592650326, 2549827794090373653 }, new ulong[] { 3869392535914652102, 7275046138579431351 });
		}

		[UnityTest]
		public IEnumerator SaveUlongArrayProperty()
		{
			yield return RunTest<UlongArrayProperty1, ulong[]>(new ulong[] { 2549827794090373653, 3582883266592650326 });
			yield return RunTest<UlongArrayProperty2, ulong[]>(new ulong[] { 3582883266592650326, 2549827794090373653 });
		}

		[UnityTest]
		public IEnumerator SaveUlongArrayProperties()
		{
			yield return RunTest<UlongArrayProperties1, ulong[]>(new ulong[] { 2549827794090373653, 3582883266592650326 }, new ulong[] { 7275046138579431351, 3869392535914652102 });
			yield return RunTest<UlongArrayProperties2, ulong[]>(new ulong[] { 3582883266592650326, 2549827794090373653 }, new ulong[] { 3869392535914652102, 7275046138579431351 });
		}

		[UnityTest]
		public IEnumerator SaveUlongArrayNullableField()
		{
			yield return RunTest<UlongArrayNullableField1, ulong?[]>(new ulong?[] { null, 3582883266592650326 });
			yield return RunTest<UlongArrayNullableField2, ulong?[]>(new ulong?[] { 3582883266592650326, null });
		}

		[UnityTest]
		public IEnumerator SaveUlongArrayNullableFields()
		{
			yield return RunTest<UlongArrayNullableFields1, ulong?[]>(new ulong?[] { null, 3582883266592650326 }, new ulong?[] { 7275046138579431351, null });
			yield return RunTest<UlongArrayNullableFields2, ulong?[]>(new ulong?[] { 3582883266592650326, null }, new ulong?[] { null, 7275046138579431351 });
		}

		[UnityTest]
		public IEnumerator SaveUlongArrayNullableProperty()
		{
			yield return RunTest<UlongArrayNullableProperty1, ulong?[]>(new ulong?[] { null, 3582883266592650326 });
			yield return RunTest<UlongArrayNullableProperty2, ulong?[]>(new ulong?[] { 3582883266592650326, null });
		}

		[UnityTest]
		public IEnumerator SaveUlongArrayNullableProperties()
		{
			yield return RunTest<UlongArrayNullableProperties1, ulong?[]>(new ulong?[] { 2549827794090373653, null }, new ulong?[] { null, 3869392535914652102 });
			yield return RunTest<UlongArrayNullableProperties2, ulong?[]>(new ulong?[] { null, 2549827794090373653 }, new ulong?[] { 3869392535914652102, null });
		}

		[UnityTest]
		public IEnumerator SaveUlongListField()
		{
			yield return RunTest<UlongListField1, List<ulong>>(new List<ulong> { 2549827794090373653, 3582883266592650326 });
			yield return RunTest<UlongListField2, List<ulong>>(new List<ulong> { 3582883266592650326, 2549827794090373653 });
		}

		[UnityTest]
		public IEnumerator SaveUlongListFields()
		{
			yield return RunTest<UlongListFields1, List<ulong>>(new List<ulong> { 2549827794090373653, 3582883266592650326 }, new List<ulong> { 7275046138579431351, 3869392535914652102 });
			yield return RunTest<UlongListFields2, List<ulong>>(new List<ulong> { 3582883266592650326, 2549827794090373653 }, new List<ulong> { 3869392535914652102, 7275046138579431351 });
		}

		[UnityTest]
		public IEnumerator SaveUlongListProperty()
		{
			yield return RunTest<UlongListProperty1, List<ulong>>(new List<ulong> { 2549827794090373653, 3582883266592650326 });
			yield return RunTest<UlongListProperty2, List<ulong>>(new List<ulong> { 3582883266592650326, 2549827794090373653 });
		}

		[UnityTest]
		public IEnumerator SaveUlongListProperties()
		{
			yield return RunTest<UlongListProperties1, List<ulong>>(new List<ulong> { 2549827794090373653, 3582883266592650326 }, new List<ulong> { 7275046138579431351, 3869392535914652102 });
			yield return RunTest<UlongListProperties2, List<ulong>>(new List<ulong> { 3582883266592650326, 2549827794090373653 }, new List<ulong> { 3869392535914652102, 7275046138579431351 });
		}

		[UnityTest]
		public IEnumerator SaveUlongListNullableField()
		{
			yield return RunTest<UlongListNullableField1, List<ulong?>>(new List<ulong?> { null, 3582883266592650326 });
			yield return RunTest<UlongListNullableField2, List<ulong?>>(new List<ulong?> { 3582883266592650326, null });
		}

		[UnityTest]
		public IEnumerator SaveUlongListNullableFields()
		{
			yield return RunTest<UlongListNullableFields1, List<ulong?>>(new List<ulong?> { null, 3582883266592650326 }, new List<ulong?> { 7275046138579431351, null });
			yield return RunTest<UlongListNullableFields2, List<ulong?>>(new List<ulong?> { 3582883266592650326, null }, new List<ulong?> { null, 7275046138579431351 });
		}

		[UnityTest]
		public IEnumerator SaveUlongListNullableProperty()
		{
			yield return RunTest<UlongListNullableProperty1, List<ulong?>>(new List<ulong?> { null, 3582883266592650326 });
			yield return RunTest<UlongListNullableProperty2, List<ulong?>>(new List<ulong?> { 3582883266592650326, null });
		}

		[UnityTest]
		public IEnumerator SaveUlongListNullableProperties()
		{
			yield return RunTest<UlongListNullableProperties1, List<ulong?>>(new List<ulong?> { 2549827794090373653, null }, new List<ulong?> { null, 3869392535914652102 });
			yield return RunTest<UlongListNullableProperties2, List<ulong?>>(new List<ulong?> { null, 2549827794090373653 }, new List<ulong?> { 3869392535914652102, null });
		}
	}
}