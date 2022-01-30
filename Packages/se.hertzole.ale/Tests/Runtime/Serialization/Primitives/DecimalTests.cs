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
		public IEnumerator SaveDecimalField()
		{
			yield return RunTest<DecimalField1, decimal>(441159424.98399728120520082365m);
			yield return RunTest<DecimalField2, decimal>(-60691495411.649927462767805982m);
		}

		[UnityTest]
		public IEnumerator SaveDecimalFields()
		{
			yield return RunTest<DecimalFields1, decimal>(-60691495411.649927462767805982m, 441159424.98399728120520082365m);
			yield return RunTest<DecimalFields2, decimal>(441159424.98399728120520082365m, -60691495411.649927462767805982m);
		}

		[UnityTest]
		public IEnumerator SaveDecimalProperty()
		{
			yield return RunTest<DecimalProperty1, decimal>(441159424.98399728120520082365m);
			yield return RunTest<DecimalProperty2, decimal>(-60691495411.649927462767805982m);
		}

		[UnityTest]
		public IEnumerator SaveDecimalProperties()
		{
			yield return RunTest<DecimalProperties1, decimal>(-60691495411.649927462767805982m, 441159424.98399728120520082365m);
			yield return RunTest<DecimalProperties2, decimal>(441159424.98399728120520082365m, -60691495411.649927462767805982m);
		}

		[UnityTest]
		public IEnumerator SaveDecimalNullableField()
		{
			yield return RunTest<DecimalNullableField1, decimal?>(441159424.98399728120520082365m);
			yield return RunTest<DecimalNullableField2, decimal?>(-60691495411.649927462767805982m);
			yield return RunTest<DecimalNullableField1, decimal?>(null);
			yield return RunTest<DecimalNullableField2, decimal?>(null);
		}

		[UnityTest]
		public IEnumerator SaveDecimalNullableFields()
		{
			yield return RunTest<DecimalNullableFields1, decimal?>(-60691495411.649927462767805982m, 441159424.98399728120520082365m);
			yield return RunTest<DecimalNullableFields2, decimal?>(441159424.98399728120520082365m, -60691495411.649927462767805982m);
			yield return RunTest<DecimalNullableFields1, decimal?>(null, 441159424.98399728120520082365m);
			yield return RunTest<DecimalNullableFields2, decimal?>(441159424.98399728120520082365m, null);
		}

		[UnityTest]
		public IEnumerator SaveDecimalNullableProperty()
		{
			yield return RunTest<DecimalNullableProperty1, decimal?>(441159424.98399728120520082365m);
			yield return RunTest<DecimalNullableProperty2, decimal?>(-60691495411.649927462767805982m);
			yield return RunTest<DecimalNullableProperty1, decimal?>(null);
			yield return RunTest<DecimalNullableProperty2, decimal?>(null);
		}

		[UnityTest]
		public IEnumerator SaveDecimalNullableProperties()
		{
			yield return RunTest<DecimalNullableProperties1, decimal?>(-60691495411.649927462767805982m, 441159424.98399728120520082365m);
			yield return RunTest<DecimalNullableProperties2, decimal?>(441159424.98399728120520082365m, -60691495411.649927462767805982m);
			yield return RunTest<DecimalNullableProperties1, decimal?>(null, 441159424.98399728120520082365m);
			yield return RunTest<DecimalNullableProperties2, decimal?>(441159424.98399728120520082365m, null);
		}

		[UnityTest]
		public IEnumerator SaveDecimalArrayField()
		{
			yield return RunTest<DecimalArrayField1, decimal[]>(new decimal[] { 441159424.98399728120520082365m, -60691495411.649927462767805982m });
			yield return RunTest<DecimalArrayField2, decimal[]>(new decimal[] { -60691495411.649927462767805982m, 441159424.98399728120520082365m });
		}

		[UnityTest]
		public IEnumerator SaveDecimalArrayFields()
		{
			yield return RunTest<DecimalArrayFields1, decimal[]>(new decimal[] { 441159424.98399728120520082365m, -60691495411.649927462767805982m }, new decimal[] { -130.56231153028789747330382823m, -6887084844529655256540311.0439m });
			yield return RunTest<DecimalArrayFields2, decimal[]>(new decimal[] { -60691495411.649927462767805982m, 441159424.98399728120520082365m }, new decimal[] { -6887084844529655256540311.0439m, -130.56231153028789747330382823m });
		}

		[UnityTest]
		public IEnumerator SaveDecimalArrayProperty()
		{
			yield return RunTest<DecimalArrayProperty1, decimal[]>(new decimal[] { 441159424.98399728120520082365m, -60691495411.649927462767805982m });
			yield return RunTest<DecimalArrayProperty2, decimal[]>(new decimal[] { -60691495411.649927462767805982m, 441159424.98399728120520082365m });
		}

		[UnityTest]
		public IEnumerator SaveDecimalArrayProperties()
		{
			yield return RunTest<DecimalArrayProperties1, decimal[]>(new decimal[] { 441159424.98399728120520082365m, -60691495411.649927462767805982m }, new decimal[] { -130.56231153028789747330382823m, -6887084844529655256540311.0439m });
			yield return RunTest<DecimalArrayProperties2, decimal[]>(new decimal[] { -60691495411.649927462767805982m, 441159424.98399728120520082365m }, new decimal[] { -6887084844529655256540311.0439m, -130.56231153028789747330382823m });
		}

		[UnityTest]
		public IEnumerator SaveDecimalArrayNullableField()
		{
			yield return RunTest<DecimalArrayNullableField1, decimal?[]>(new decimal?[] { null, -60691495411.649927462767805982m });
			yield return RunTest<DecimalArrayNullableField2, decimal?[]>(new decimal?[] { -60691495411.649927462767805982m, null });
		}

		[UnityTest]
		public IEnumerator SaveDecimalArrayNullableFields()
		{
			yield return RunTest<DecimalArrayNullableFields1, decimal?[]>(new decimal?[] { null, -60691495411.649927462767805982m }, new decimal?[] { -130.56231153028789747330382823m, null });
			yield return RunTest<DecimalArrayNullableFields2, decimal?[]>(new decimal?[] { -60691495411.649927462767805982m, null }, new decimal?[] { null, -130.56231153028789747330382823m });
		}

		[UnityTest]
		public IEnumerator SaveDecimalArrayNullableProperty()
		{
			yield return RunTest<DecimalArrayNullableProperty1, decimal?[]>(new decimal?[] { null, -60691495411.649927462767805982m });
			yield return RunTest<DecimalArrayNullableProperty2, decimal?[]>(new decimal?[] { -60691495411.649927462767805982m, null });
		}

		[UnityTest]
		public IEnumerator SaveDecimalArrayNullableProperties()
		{
			yield return RunTest<DecimalArrayNullableProperties1, decimal?[]>(new decimal?[] { 441159424.98399728120520082365m, null }, new decimal?[] { null, -6887084844529655256540311.0439m });
			yield return RunTest<DecimalArrayNullableProperties2, decimal?[]>(new decimal?[] { null, 441159424.98399728120520082365m }, new decimal?[] { -6887084844529655256540311.0439m, null });
		}

		[UnityTest]
		public IEnumerator SaveDecimalListField()
		{
			yield return RunTest<DecimalListField1, List<decimal>>(new List<decimal> { 441159424.98399728120520082365m, -60691495411.649927462767805982m });
			yield return RunTest<DecimalListField2, List<decimal>>(new List<decimal> { -60691495411.649927462767805982m, 441159424.98399728120520082365m });
		}

		[UnityTest]
		public IEnumerator SaveDecimalListFields()
		{
			yield return RunTest<DecimalListFields1, List<decimal>>(new List<decimal> { 441159424.98399728120520082365m, -60691495411.649927462767805982m }, new List<decimal> { -130.56231153028789747330382823m, -6887084844529655256540311.0439m });
			yield return RunTest<DecimalListFields2, List<decimal>>(new List<decimal> { -60691495411.649927462767805982m, 441159424.98399728120520082365m }, new List<decimal> { -6887084844529655256540311.0439m, -130.56231153028789747330382823m });
		}

		[UnityTest]
		public IEnumerator SaveDecimalListProperty()
		{
			yield return RunTest<DecimalListProperty1, List<decimal>>(new List<decimal> { 441159424.98399728120520082365m, -60691495411.649927462767805982m });
			yield return RunTest<DecimalListProperty2, List<decimal>>(new List<decimal> { -60691495411.649927462767805982m, 441159424.98399728120520082365m });
		}

		[UnityTest]
		public IEnumerator SaveDecimalListProperties()
		{
			yield return RunTest<DecimalListProperties1, List<decimal>>(new List<decimal> { 441159424.98399728120520082365m, -60691495411.649927462767805982m }, new List<decimal> { -130.56231153028789747330382823m, -6887084844529655256540311.0439m });
			yield return RunTest<DecimalListProperties2, List<decimal>>(new List<decimal> { -60691495411.649927462767805982m, 441159424.98399728120520082365m }, new List<decimal> { -6887084844529655256540311.0439m, -130.56231153028789747330382823m });
		}

		[UnityTest]
		public IEnumerator SaveDecimalListNullableField()
		{
			yield return RunTest<DecimalListNullableField1, List<decimal?>>(new List<decimal?> { null, -60691495411.649927462767805982m });
			yield return RunTest<DecimalListNullableField2, List<decimal?>>(new List<decimal?> { -60691495411.649927462767805982m, null });
		}

		[UnityTest]
		public IEnumerator SaveDecimalListNullableFields()
		{
			yield return RunTest<DecimalListNullableFields1, List<decimal?>>(new List<decimal?> { null, -60691495411.649927462767805982m }, new List<decimal?> { -130.56231153028789747330382823m, null });
			yield return RunTest<DecimalListNullableFields2, List<decimal?>>(new List<decimal?> { -60691495411.649927462767805982m, null }, new List<decimal?> { null, -130.56231153028789747330382823m });
		}

		[UnityTest]
		public IEnumerator SaveDecimalListNullableProperty()
		{
			yield return RunTest<DecimalListNullableProperty1, List<decimal?>>(new List<decimal?> { null, -60691495411.649927462767805982m });
			yield return RunTest<DecimalListNullableProperty2, List<decimal?>>(new List<decimal?> { -60691495411.649927462767805982m, null });
		}

		[UnityTest]
		public IEnumerator SaveDecimalListNullableProperties()
		{
			yield return RunTest<DecimalListNullableProperties1, List<decimal?>>(new List<decimal?> { 441159424.98399728120520082365m, null }, new List<decimal?> { null, -6887084844529655256540311.0439m });
			yield return RunTest<DecimalListNullableProperties2, List<decimal?>>(new List<decimal?> { null, 441159424.98399728120520082365m }, new List<decimal?> { -6887084844529655256540311.0439m, null });
		}
	}
}