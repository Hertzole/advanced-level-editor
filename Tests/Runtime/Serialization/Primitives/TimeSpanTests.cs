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
		public IEnumerator SaveTimeSpanField()
		{
			yield return RunTest<TimeSpanField1, TimeSpan>(new TimeSpan(2567));
			yield return RunTest<TimeSpanField2, TimeSpan>(new TimeSpan(22044));
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanFields()
		{
			yield return RunTest<TimeSpanFields1, TimeSpan>(new TimeSpan(22044), new TimeSpan(2567));
			yield return RunTest<TimeSpanFields2, TimeSpan>(new TimeSpan(2567), new TimeSpan(22044));
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanProperty()
		{
			yield return RunTest<TimeSpanProperty1, TimeSpan>(new TimeSpan(2567));
			yield return RunTest<TimeSpanProperty2, TimeSpan>(new TimeSpan(22044));
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanProperties()
		{
			yield return RunTest<TimeSpanProperties1, TimeSpan>(new TimeSpan(22044), new TimeSpan(2567));
			yield return RunTest<TimeSpanProperties2, TimeSpan>(new TimeSpan(2567), new TimeSpan(22044));
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanNullableField()
		{
			yield return RunTest<TimeSpanNullableField1, TimeSpan?>(new TimeSpan(2567));
			yield return RunTest<TimeSpanNullableField2, TimeSpan?>(new TimeSpan(22044));
			yield return RunTest<TimeSpanNullableField1, TimeSpan?>(null);
			yield return RunTest<TimeSpanNullableField2, TimeSpan?>(null);
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanNullableFields()
		{
			yield return RunTest<TimeSpanNullableFields1, TimeSpan?>(new TimeSpan(22044), new TimeSpan(2567));
			yield return RunTest<TimeSpanNullableFields2, TimeSpan?>(new TimeSpan(2567), new TimeSpan(22044));
			yield return RunTest<TimeSpanNullableFields1, TimeSpan?>(null, new TimeSpan(2567));
			yield return RunTest<TimeSpanNullableFields2, TimeSpan?>(new TimeSpan(2567), null);
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanNullableProperty()
		{
			yield return RunTest<TimeSpanNullableProperty1, TimeSpan?>(new TimeSpan(2567));
			yield return RunTest<TimeSpanNullableProperty2, TimeSpan?>(new TimeSpan(22044));
			yield return RunTest<TimeSpanNullableProperty1, TimeSpan?>(null);
			yield return RunTest<TimeSpanNullableProperty2, TimeSpan?>(null);
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanNullableProperties()
		{
			yield return RunTest<TimeSpanNullableProperties1, TimeSpan?>(new TimeSpan(22044), new TimeSpan(2567));
			yield return RunTest<TimeSpanNullableProperties2, TimeSpan?>(new TimeSpan(2567), new TimeSpan(22044));
			yield return RunTest<TimeSpanNullableProperties1, TimeSpan?>(null, new TimeSpan(2567));
			yield return RunTest<TimeSpanNullableProperties2, TimeSpan?>(new TimeSpan(2567), null);
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanArrayField()
		{
			yield return RunTest<TimeSpanArrayField1, TimeSpan[]>(new TimeSpan[] { new TimeSpan(2567), new TimeSpan(22044) });
			yield return RunTest<TimeSpanArrayField2, TimeSpan[]>(new TimeSpan[] { new TimeSpan(22044), new TimeSpan(2567) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanArrayFields()
		{
			yield return RunTest<TimeSpanArrayFields1, TimeSpan[]>(new TimeSpan[] { new TimeSpan(2567), new TimeSpan(22044) }, new TimeSpan[] { new TimeSpan(1653), new TimeSpan(6766) });
			yield return RunTest<TimeSpanArrayFields2, TimeSpan[]>(new TimeSpan[] { new TimeSpan(22044), new TimeSpan(2567) }, new TimeSpan[] { new TimeSpan(6766), new TimeSpan(1653) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanArrayProperty()
		{
			yield return RunTest<TimeSpanArrayProperty1, TimeSpan[]>(new TimeSpan[] { new TimeSpan(2567), new TimeSpan(22044) });
			yield return RunTest<TimeSpanArrayProperty2, TimeSpan[]>(new TimeSpan[] { new TimeSpan(22044), new TimeSpan(2567) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanArrayProperties()
		{
			yield return RunTest<TimeSpanArrayProperties1, TimeSpan[]>(new TimeSpan[] { new TimeSpan(2567), new TimeSpan(22044) }, new TimeSpan[] { new TimeSpan(1653), new TimeSpan(6766) });
			yield return RunTest<TimeSpanArrayProperties2, TimeSpan[]>(new TimeSpan[] { new TimeSpan(22044), new TimeSpan(2567) }, new TimeSpan[] { new TimeSpan(6766), new TimeSpan(1653) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanArrayNullableField()
		{
			yield return RunTest<TimeSpanArrayNullableField1, TimeSpan?[]>(new TimeSpan?[] { null, new TimeSpan(22044) });
			yield return RunTest<TimeSpanArrayNullableField2, TimeSpan?[]>(new TimeSpan?[] { new TimeSpan(22044), null });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanArrayNullableFields()
		{
			yield return RunTest<TimeSpanArrayNullableFields1, TimeSpan?[]>(new TimeSpan?[] { null, new TimeSpan(22044) }, new TimeSpan?[] { new TimeSpan(1653), null });
			yield return RunTest<TimeSpanArrayNullableFields2, TimeSpan?[]>(new TimeSpan?[] { new TimeSpan(22044), null }, new TimeSpan?[] { null, new TimeSpan(1653) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanArrayNullableProperty()
		{
			yield return RunTest<TimeSpanArrayNullableProperty1, TimeSpan?[]>(new TimeSpan?[] { null, new TimeSpan(22044) });
			yield return RunTest<TimeSpanArrayNullableProperty2, TimeSpan?[]>(new TimeSpan?[] { new TimeSpan(22044), null });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanArrayNullableProperties()
		{
			yield return RunTest<TimeSpanArrayNullableProperties1, TimeSpan?[]>(new TimeSpan?[] { new TimeSpan(2567), null }, new TimeSpan?[] { null, new TimeSpan(6766) });
			yield return RunTest<TimeSpanArrayNullableProperties2, TimeSpan?[]>(new TimeSpan?[] { null, new TimeSpan(2567) }, new TimeSpan?[] { new TimeSpan(6766), null });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanListField()
		{
			yield return RunTest<TimeSpanListField1, List<TimeSpan>>(new List<TimeSpan> { new TimeSpan(2567), new TimeSpan(22044) });
			yield return RunTest<TimeSpanListField2, List<TimeSpan>>(new List<TimeSpan> { new TimeSpan(22044), new TimeSpan(2567) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanListFields()
		{
			yield return RunTest<TimeSpanListFields1, List<TimeSpan>>(new List<TimeSpan> { new TimeSpan(2567), new TimeSpan(22044) }, new List<TimeSpan> { new TimeSpan(1653), new TimeSpan(6766) });
			yield return RunTest<TimeSpanListFields2, List<TimeSpan>>(new List<TimeSpan> { new TimeSpan(22044), new TimeSpan(2567) }, new List<TimeSpan> { new TimeSpan(6766), new TimeSpan(1653) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanListProperty()
		{
			yield return RunTest<TimeSpanListProperty1, List<TimeSpan>>(new List<TimeSpan> { new TimeSpan(2567), new TimeSpan(22044) });
			yield return RunTest<TimeSpanListProperty2, List<TimeSpan>>(new List<TimeSpan> { new TimeSpan(22044), new TimeSpan(2567) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanListProperties()
		{
			yield return RunTest<TimeSpanListProperties1, List<TimeSpan>>(new List<TimeSpan> { new TimeSpan(2567), new TimeSpan(22044) }, new List<TimeSpan> { new TimeSpan(1653), new TimeSpan(6766) });
			yield return RunTest<TimeSpanListProperties2, List<TimeSpan>>(new List<TimeSpan> { new TimeSpan(22044), new TimeSpan(2567) }, new List<TimeSpan> { new TimeSpan(6766), new TimeSpan(1653) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanListNullableField()
		{
			yield return RunTest<TimeSpanListNullableField1, List<TimeSpan?>>(new List<TimeSpan?> { null, new TimeSpan(22044) });
			yield return RunTest<TimeSpanListNullableField2, List<TimeSpan?>>(new List<TimeSpan?> { new TimeSpan(22044), null });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanListNullableFields()
		{
			yield return RunTest<TimeSpanListNullableFields1, List<TimeSpan?>>(new List<TimeSpan?> { null, new TimeSpan(22044) }, new List<TimeSpan?> { new TimeSpan(1653), null });
			yield return RunTest<TimeSpanListNullableFields2, List<TimeSpan?>>(new List<TimeSpan?> { new TimeSpan(22044), null }, new List<TimeSpan?> { null, new TimeSpan(1653) });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanListNullableProperty()
		{
			yield return RunTest<TimeSpanListNullableProperty1, List<TimeSpan?>>(new List<TimeSpan?> { null, new TimeSpan(22044) });
			yield return RunTest<TimeSpanListNullableProperty2, List<TimeSpan?>>(new List<TimeSpan?> { new TimeSpan(22044), null });
		}

		[UnityTest]
		public IEnumerator SaveTimeSpanListNullableProperties()
		{
			yield return RunTest<TimeSpanListNullableProperties1, List<TimeSpan?>>(new List<TimeSpan?> { new TimeSpan(2567), null }, new List<TimeSpan?> { null, new TimeSpan(6766) });
			yield return RunTest<TimeSpanListNullableProperties2, List<TimeSpan?>>(new List<TimeSpan?> { null, new TimeSpan(2567) }, new List<TimeSpan?> { new TimeSpan(6766), null });
		}
	}
}