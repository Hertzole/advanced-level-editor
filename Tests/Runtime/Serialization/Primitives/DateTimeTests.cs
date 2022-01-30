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
		public IEnumerator SaveDateTimeField()
		{
			yield return RunTest<DateTimeField1, DateTime>(new DateTime(2000, 9, 24, 9, 37, 2));
			yield return RunTest<DateTimeField2, DateTime>(new DateTime(2019, 2, 21, 23, 55, 47));
		}

		[UnityTest]
		public IEnumerator SaveDateTimeFields()
		{
			yield return RunTest<DateTimeFields1, DateTime>(new DateTime(2019, 2, 21, 23, 55, 47), new DateTime(2000, 9, 24, 9, 37, 2));
			yield return RunTest<DateTimeFields2, DateTime>(new DateTime(2000, 9, 24, 9, 37, 2), new DateTime(2019, 2, 21, 23, 55, 47));
		}

		[UnityTest]
		public IEnumerator SaveDateTimeProperty()
		{
			yield return RunTest<DateTimeProperty1, DateTime>(new DateTime(2000, 9, 24, 9, 37, 2));
			yield return RunTest<DateTimeProperty2, DateTime>(new DateTime(2019, 2, 21, 23, 55, 47));
		}

		[UnityTest]
		public IEnumerator SaveDateTimeProperties()
		{
			yield return RunTest<DateTimeProperties1, DateTime>(new DateTime(2019, 2, 21, 23, 55, 47), new DateTime(2000, 9, 24, 9, 37, 2));
			yield return RunTest<DateTimeProperties2, DateTime>(new DateTime(2000, 9, 24, 9, 37, 2), new DateTime(2019, 2, 21, 23, 55, 47));
		}

		[UnityTest]
		public IEnumerator SaveDateTimeNullableField()
		{
			yield return RunTest<DateTimeNullableField1, DateTime?>(new DateTime(2000, 9, 24, 9, 37, 2));
			yield return RunTest<DateTimeNullableField2, DateTime?>(new DateTime(2019, 2, 21, 23, 55, 47));
			yield return RunTest<DateTimeNullableField1, DateTime?>(null);
			yield return RunTest<DateTimeNullableField2, DateTime?>(null);
		}

		[UnityTest]
		public IEnumerator SaveDateTimeNullableFields()
		{
			yield return RunTest<DateTimeNullableFields1, DateTime?>(new DateTime(2019, 2, 21, 23, 55, 47), new DateTime(2000, 9, 24, 9, 37, 2));
			yield return RunTest<DateTimeNullableFields2, DateTime?>(new DateTime(2000, 9, 24, 9, 37, 2), new DateTime(2019, 2, 21, 23, 55, 47));
			yield return RunTest<DateTimeNullableFields1, DateTime?>(null, new DateTime(2000, 9, 24, 9, 37, 2));
			yield return RunTest<DateTimeNullableFields2, DateTime?>(new DateTime(2000, 9, 24, 9, 37, 2), null);
		}

		[UnityTest]
		public IEnumerator SaveDateTimeNullableProperty()
		{
			yield return RunTest<DateTimeNullableProperty1, DateTime?>(new DateTime(2000, 9, 24, 9, 37, 2));
			yield return RunTest<DateTimeNullableProperty2, DateTime?>(new DateTime(2019, 2, 21, 23, 55, 47));
			yield return RunTest<DateTimeNullableProperty1, DateTime?>(null);
			yield return RunTest<DateTimeNullableProperty2, DateTime?>(null);
		}

		[UnityTest]
		public IEnumerator SaveDateTimeNullableProperties()
		{
			yield return RunTest<DateTimeNullableProperties1, DateTime?>(new DateTime(2019, 2, 21, 23, 55, 47), new DateTime(2000, 9, 24, 9, 37, 2));
			yield return RunTest<DateTimeNullableProperties2, DateTime?>(new DateTime(2000, 9, 24, 9, 37, 2), new DateTime(2019, 2, 21, 23, 55, 47));
			yield return RunTest<DateTimeNullableProperties1, DateTime?>(null, new DateTime(2000, 9, 24, 9, 37, 2));
			yield return RunTest<DateTimeNullableProperties2, DateTime?>(new DateTime(2000, 9, 24, 9, 37, 2), null);
		}

		[UnityTest]
		public IEnumerator SaveDateTimeArrayField()
		{
			yield return RunTest<DateTimeArrayField1, DateTime[]>(new DateTime[] { new DateTime(2000, 9, 24, 9, 37, 2), new DateTime(2019, 2, 21, 23, 55, 47) });
			yield return RunTest<DateTimeArrayField2, DateTime[]>(new DateTime[] { new DateTime(2019, 2, 21, 23, 55, 47), new DateTime(2000, 9, 24, 9, 37, 2) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeArrayFields()
		{
			yield return RunTest<DateTimeArrayFields1, DateTime[]>(new DateTime[] { new DateTime(2000, 9, 24, 9, 37, 2), new DateTime(2019, 2, 21, 23, 55, 47) }, new DateTime[] { new DateTime(2009, 1, 18, 10, 18, 20), new DateTime(2004, 2, 5, 2, 23, 40) });
			yield return RunTest<DateTimeArrayFields2, DateTime[]>(new DateTime[] { new DateTime(2019, 2, 21, 23, 55, 47), new DateTime(2000, 9, 24, 9, 37, 2) }, new DateTime[] { new DateTime(2004, 2, 5, 2, 23, 40), new DateTime(2009, 1, 18, 10, 18, 20) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeArrayProperty()
		{
			yield return RunTest<DateTimeArrayProperty1, DateTime[]>(new DateTime[] { new DateTime(2000, 9, 24, 9, 37, 2), new DateTime(2019, 2, 21, 23, 55, 47) });
			yield return RunTest<DateTimeArrayProperty2, DateTime[]>(new DateTime[] { new DateTime(2019, 2, 21, 23, 55, 47), new DateTime(2000, 9, 24, 9, 37, 2) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeArrayProperties()
		{
			yield return RunTest<DateTimeArrayProperties1, DateTime[]>(new DateTime[] { new DateTime(2000, 9, 24, 9, 37, 2), new DateTime(2019, 2, 21, 23, 55, 47) }, new DateTime[] { new DateTime(2009, 1, 18, 10, 18, 20), new DateTime(2004, 2, 5, 2, 23, 40) });
			yield return RunTest<DateTimeArrayProperties2, DateTime[]>(new DateTime[] { new DateTime(2019, 2, 21, 23, 55, 47), new DateTime(2000, 9, 24, 9, 37, 2) }, new DateTime[] { new DateTime(2004, 2, 5, 2, 23, 40), new DateTime(2009, 1, 18, 10, 18, 20) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeArrayNullableField()
		{
			yield return RunTest<DateTimeArrayNullableField1, DateTime?[]>(new DateTime?[] { null, new DateTime(2019, 2, 21, 23, 55, 47) });
			yield return RunTest<DateTimeArrayNullableField2, DateTime?[]>(new DateTime?[] { new DateTime(2019, 2, 21, 23, 55, 47), null });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeArrayNullableFields()
		{
			yield return RunTest<DateTimeArrayNullableFields1, DateTime?[]>(new DateTime?[] { null, new DateTime(2019, 2, 21, 23, 55, 47) }, new DateTime?[] { new DateTime(2009, 1, 18, 10, 18, 20), null });
			yield return RunTest<DateTimeArrayNullableFields2, DateTime?[]>(new DateTime?[] { new DateTime(2019, 2, 21, 23, 55, 47), null }, new DateTime?[] { null, new DateTime(2009, 1, 18, 10, 18, 20) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeArrayNullableProperty()
		{
			yield return RunTest<DateTimeArrayNullableProperty1, DateTime?[]>(new DateTime?[] { null, new DateTime(2019, 2, 21, 23, 55, 47) });
			yield return RunTest<DateTimeArrayNullableProperty2, DateTime?[]>(new DateTime?[] { new DateTime(2019, 2, 21, 23, 55, 47), null });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeArrayNullableProperties()
		{
			yield return RunTest<DateTimeArrayNullableProperties1, DateTime?[]>(new DateTime?[] { new DateTime(2000, 9, 24, 9, 37, 2), null }, new DateTime?[] { null, new DateTime(2004, 2, 5, 2, 23, 40) });
			yield return RunTest<DateTimeArrayNullableProperties2, DateTime?[]>(new DateTime?[] { null, new DateTime(2000, 9, 24, 9, 37, 2) }, new DateTime?[] { new DateTime(2004, 2, 5, 2, 23, 40), null });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeListField()
		{
			yield return RunTest<DateTimeListField1, List<DateTime>>(new List<DateTime> { new DateTime(2000, 9, 24, 9, 37, 2), new DateTime(2019, 2, 21, 23, 55, 47) });
			yield return RunTest<DateTimeListField2, List<DateTime>>(new List<DateTime> { new DateTime(2019, 2, 21, 23, 55, 47), new DateTime(2000, 9, 24, 9, 37, 2) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeListFields()
		{
			yield return RunTest<DateTimeListFields1, List<DateTime>>(new List<DateTime> { new DateTime(2000, 9, 24, 9, 37, 2), new DateTime(2019, 2, 21, 23, 55, 47) }, new List<DateTime> { new DateTime(2009, 1, 18, 10, 18, 20), new DateTime(2004, 2, 5, 2, 23, 40) });
			yield return RunTest<DateTimeListFields2, List<DateTime>>(new List<DateTime> { new DateTime(2019, 2, 21, 23, 55, 47), new DateTime(2000, 9, 24, 9, 37, 2) }, new List<DateTime> { new DateTime(2004, 2, 5, 2, 23, 40), new DateTime(2009, 1, 18, 10, 18, 20) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeListProperty()
		{
			yield return RunTest<DateTimeListProperty1, List<DateTime>>(new List<DateTime> { new DateTime(2000, 9, 24, 9, 37, 2), new DateTime(2019, 2, 21, 23, 55, 47) });
			yield return RunTest<DateTimeListProperty2, List<DateTime>>(new List<DateTime> { new DateTime(2019, 2, 21, 23, 55, 47), new DateTime(2000, 9, 24, 9, 37, 2) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeListProperties()
		{
			yield return RunTest<DateTimeListProperties1, List<DateTime>>(new List<DateTime> { new DateTime(2000, 9, 24, 9, 37, 2), new DateTime(2019, 2, 21, 23, 55, 47) }, new List<DateTime> { new DateTime(2009, 1, 18, 10, 18, 20), new DateTime(2004, 2, 5, 2, 23, 40) });
			yield return RunTest<DateTimeListProperties2, List<DateTime>>(new List<DateTime> { new DateTime(2019, 2, 21, 23, 55, 47), new DateTime(2000, 9, 24, 9, 37, 2) }, new List<DateTime> { new DateTime(2004, 2, 5, 2, 23, 40), new DateTime(2009, 1, 18, 10, 18, 20) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeListNullableField()
		{
			yield return RunTest<DateTimeListNullableField1, List<DateTime?>>(new List<DateTime?> { null, new DateTime(2019, 2, 21, 23, 55, 47) });
			yield return RunTest<DateTimeListNullableField2, List<DateTime?>>(new List<DateTime?> { new DateTime(2019, 2, 21, 23, 55, 47), null });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeListNullableFields()
		{
			yield return RunTest<DateTimeListNullableFields1, List<DateTime?>>(new List<DateTime?> { null, new DateTime(2019, 2, 21, 23, 55, 47) }, new List<DateTime?> { new DateTime(2009, 1, 18, 10, 18, 20), null });
			yield return RunTest<DateTimeListNullableFields2, List<DateTime?>>(new List<DateTime?> { new DateTime(2019, 2, 21, 23, 55, 47), null }, new List<DateTime?> { null, new DateTime(2009, 1, 18, 10, 18, 20) });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeListNullableProperty()
		{
			yield return RunTest<DateTimeListNullableProperty1, List<DateTime?>>(new List<DateTime?> { null, new DateTime(2019, 2, 21, 23, 55, 47) });
			yield return RunTest<DateTimeListNullableProperty2, List<DateTime?>>(new List<DateTime?> { new DateTime(2019, 2, 21, 23, 55, 47), null });
		}

		[UnityTest]
		public IEnumerator SaveDateTimeListNullableProperties()
		{
			yield return RunTest<DateTimeListNullableProperties1, List<DateTime?>>(new List<DateTime?> { new DateTime(2000, 9, 24, 9, 37, 2), null }, new List<DateTime?> { null, new DateTime(2004, 2, 5, 2, 23, 40) });
			yield return RunTest<DateTimeListNullableProperties2, List<DateTime?>>(new List<DateTime?> { null, new DateTime(2000, 9, 24, 9, 37, 2) }, new List<DateTime?> { new DateTime(2004, 2, 5, 2, 23, 40), null });
		}
	}
}