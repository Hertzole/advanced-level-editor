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
		public IEnumerator SaveCharField()
		{
			yield return RunTest<CharField1, char>('l');
			yield return RunTest<CharField2, char>('I');
		}

		[UnityTest]
		public IEnumerator SaveCharFields()
		{
			yield return RunTest<CharFields1, char>('I', 'l');
			yield return RunTest<CharFields2, char>('l', 'I');
		}

		[UnityTest]
		public IEnumerator SaveCharProperty()
		{
			yield return RunTest<CharProperty1, char>('l');
			yield return RunTest<CharProperty2, char>('I');
		}

		[UnityTest]
		public IEnumerator SaveCharProperties()
		{
			yield return RunTest<CharProperties1, char>('I', 'l');
			yield return RunTest<CharProperties2, char>('l', 'I');
		}

		[UnityTest]
		public IEnumerator SaveCharNullableField()
		{
			yield return RunTest<CharNullableField1, char?>('l');
			yield return RunTest<CharNullableField2, char?>('I');
			yield return RunTest<CharNullableField1, char?>(null);
			yield return RunTest<CharNullableField2, char?>(null);
		}

		[UnityTest]
		public IEnumerator SaveCharNullableFields()
		{
			yield return RunTest<CharNullableFields1, char?>('I', 'l');
			yield return RunTest<CharNullableFields2, char?>('l', 'I');
			yield return RunTest<CharNullableFields1, char?>(null, 'l');
			yield return RunTest<CharNullableFields2, char?>('l', null);
		}

		[UnityTest]
		public IEnumerator SaveCharNullableProperty()
		{
			yield return RunTest<CharNullableProperty1, char?>('l');
			yield return RunTest<CharNullableProperty2, char?>('I');
			yield return RunTest<CharNullableProperty1, char?>(null);
			yield return RunTest<CharNullableProperty2, char?>(null);
		}

		[UnityTest]
		public IEnumerator SaveCharNullableProperties()
		{
			yield return RunTest<CharNullableProperties1, char?>('I', 'l');
			yield return RunTest<CharNullableProperties2, char?>('l', 'I');
			yield return RunTest<CharNullableProperties1, char?>(null, 'l');
			yield return RunTest<CharNullableProperties2, char?>('l', null);
		}

		[UnityTest]
		public IEnumerator SaveCharArrayField()
		{
			yield return RunTest<CharArrayField1, char[]>(new char[] { 'l', 'I' });
			yield return RunTest<CharArrayField2, char[]>(new char[] { 'I', 'l' });
		}

		[UnityTest]
		public IEnumerator SaveCharArrayFields()
		{
			yield return RunTest<CharArrayFields1, char[]>(new char[] { 'l', 'I' }, new char[] { 'a', 'u' });
			yield return RunTest<CharArrayFields2, char[]>(new char[] { 'I', 'l' }, new char[] { 'u', 'a' });
		}

		[UnityTest]
		public IEnumerator SaveCharArrayProperty()
		{
			yield return RunTest<CharArrayProperty1, char[]>(new char[] { 'l', 'I' });
			yield return RunTest<CharArrayProperty2, char[]>(new char[] { 'I', 'l' });
		}

		[UnityTest]
		public IEnumerator SaveCharArrayProperties()
		{
			yield return RunTest<CharArrayProperties1, char[]>(new char[] { 'l', 'I' }, new char[] { 'a', 'u' });
			yield return RunTest<CharArrayProperties2, char[]>(new char[] { 'I', 'l' }, new char[] { 'u', 'a' });
		}

		[UnityTest]
		public IEnumerator SaveCharArrayNullableField()
		{
			yield return RunTest<CharArrayNullableField1, char?[]>(new char?[] { null, 'I' });
			yield return RunTest<CharArrayNullableField2, char?[]>(new char?[] { 'I', null });
		}

		[UnityTest]
		public IEnumerator SaveCharArrayNullableFields()
		{
			yield return RunTest<CharArrayNullableFields1, char?[]>(new char?[] { null, 'I' }, new char?[] { 'a', null });
			yield return RunTest<CharArrayNullableFields2, char?[]>(new char?[] { 'I', null }, new char?[] { null, 'a' });
		}

		[UnityTest]
		public IEnumerator SaveCharArrayNullableProperty()
		{
			yield return RunTest<CharArrayNullableProperty1, char?[]>(new char?[] { null, 'I' });
			yield return RunTest<CharArrayNullableProperty2, char?[]>(new char?[] { 'I', null });
		}

		[UnityTest]
		public IEnumerator SaveCharArrayNullableProperties()
		{
			yield return RunTest<CharArrayNullableProperties1, char?[]>(new char?[] { 'l', null }, new char?[] { null, 'u' });
			yield return RunTest<CharArrayNullableProperties2, char?[]>(new char?[] { null, 'l' }, new char?[] { 'u', null });
		}

		[UnityTest]
		public IEnumerator SaveCharListField()
		{
			yield return RunTest<CharListField1, List<char>>(new List<char> { 'l', 'I' });
			yield return RunTest<CharListField2, List<char>>(new List<char> { 'I', 'l' });
		}

		[UnityTest]
		public IEnumerator SaveCharListFields()
		{
			yield return RunTest<CharListFields1, List<char>>(new List<char> { 'l', 'I' }, new List<char> { 'a', 'u' });
			yield return RunTest<CharListFields2, List<char>>(new List<char> { 'I', 'l' }, new List<char> { 'u', 'a' });
		}

		[UnityTest]
		public IEnumerator SaveCharListProperty()
		{
			yield return RunTest<CharListProperty1, List<char>>(new List<char> { 'l', 'I' });
			yield return RunTest<CharListProperty2, List<char>>(new List<char> { 'I', 'l' });
		}

		[UnityTest]
		public IEnumerator SaveCharListProperties()
		{
			yield return RunTest<CharListProperties1, List<char>>(new List<char> { 'l', 'I' }, new List<char> { 'a', 'u' });
			yield return RunTest<CharListProperties2, List<char>>(new List<char> { 'I', 'l' }, new List<char> { 'u', 'a' });
		}

		[UnityTest]
		public IEnumerator SaveCharListNullableField()
		{
			yield return RunTest<CharListNullableField1, List<char?>>(new List<char?> { null, 'I' });
			yield return RunTest<CharListNullableField2, List<char?>>(new List<char?> { 'I', null });
		}

		[UnityTest]
		public IEnumerator SaveCharListNullableFields()
		{
			yield return RunTest<CharListNullableFields1, List<char?>>(new List<char?> { null, 'I' }, new List<char?> { 'a', null });
			yield return RunTest<CharListNullableFields2, List<char?>>(new List<char?> { 'I', null }, new List<char?> { null, 'a' });
		}

		[UnityTest]
		public IEnumerator SaveCharListNullableProperty()
		{
			yield return RunTest<CharListNullableProperty1, List<char?>>(new List<char?> { null, 'I' });
			yield return RunTest<CharListNullableProperty2, List<char?>>(new List<char?> { 'I', null });
		}

		[UnityTest]
		public IEnumerator SaveCharListNullableProperties()
		{
			yield return RunTest<CharListNullableProperties1, List<char?>>(new List<char?> { 'l', null }, new List<char?> { null, 'u' });
			yield return RunTest<CharListNullableProperties2, List<char?>>(new List<char?> { null, 'l' }, new List<char?> { 'u', null });
		}
	}
}