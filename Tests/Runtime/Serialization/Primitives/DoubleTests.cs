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
		public IEnumerator SaveDoubleField()
		{
			yield return RunTest<DoubleField1, double>(52484.5720978848);
			yield return RunTest<DoubleField2, double>(27410.4055610534);
		}

		[UnityTest]
		public IEnumerator SaveDoubleFields()
		{
			yield return RunTest<DoubleFields1, double>(27410.4055610534, 52484.5720978848);
			yield return RunTest<DoubleFields2, double>(52484.5720978848, 27410.4055610534);
		}

		[UnityTest]
		public IEnumerator SaveDoubleProperty()
		{
			yield return RunTest<DoubleProperty1, double>(52484.5720978848);
			yield return RunTest<DoubleProperty2, double>(27410.4055610534);
		}

		[UnityTest]
		public IEnumerator SaveDoubleProperties()
		{
			yield return RunTest<DoubleProperties1, double>(27410.4055610534, 52484.5720978848);
			yield return RunTest<DoubleProperties2, double>(52484.5720978848, 27410.4055610534);
		}

		[UnityTest]
		public IEnumerator SaveDoubleNullableField()
		{
			yield return RunTest<DoubleNullableField1, double?>(52484.5720978848);
			yield return RunTest<DoubleNullableField2, double?>(27410.4055610534);
			yield return RunTest<DoubleNullableField1, double?>(null);
			yield return RunTest<DoubleNullableField2, double?>(null);
		}

		[UnityTest]
		public IEnumerator SaveDoubleNullableFields()
		{
			yield return RunTest<DoubleNullableFields1, double?>(27410.4055610534, 52484.5720978848);
			yield return RunTest<DoubleNullableFields2, double?>(52484.5720978848, 27410.4055610534);
			yield return RunTest<DoubleNullableFields1, double?>(null, 52484.5720978848);
			yield return RunTest<DoubleNullableFields2, double?>(52484.5720978848, null);
		}

		[UnityTest]
		public IEnumerator SaveDoubleNullableProperty()
		{
			yield return RunTest<DoubleNullableProperty1, double?>(52484.5720978848);
			yield return RunTest<DoubleNullableProperty2, double?>(27410.4055610534);
			yield return RunTest<DoubleNullableProperty1, double?>(null);
			yield return RunTest<DoubleNullableProperty2, double?>(null);
		}

		[UnityTest]
		public IEnumerator SaveDoubleNullableProperties()
		{
			yield return RunTest<DoubleNullableProperties1, double?>(27410.4055610534, 52484.5720978848);
			yield return RunTest<DoubleNullableProperties2, double?>(52484.5720978848, 27410.4055610534);
			yield return RunTest<DoubleNullableProperties1, double?>(null, 52484.5720978848);
			yield return RunTest<DoubleNullableProperties2, double?>(52484.5720978848, null);
		}

		[UnityTest]
		public IEnumerator SaveDoubleArrayField()
		{
			yield return RunTest<DoubleArrayField1, double[]>(new double[] { 52484.5720978848, 27410.4055610534 });
			yield return RunTest<DoubleArrayField2, double[]>(new double[] { 27410.4055610534, 52484.5720978848 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleArrayFields()
		{
			yield return RunTest<DoubleArrayFields1, double[]>(new double[] { 52484.5720978848, 27410.4055610534 }, new double[] { -5448.07487421115, 29217.8858673283 });
			yield return RunTest<DoubleArrayFields2, double[]>(new double[] { 27410.4055610534, 52484.5720978848 }, new double[] { 29217.8858673283, -5448.07487421115 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleArrayProperty()
		{
			yield return RunTest<DoubleArrayProperty1, double[]>(new double[] { 52484.5720978848, 27410.4055610534 });
			yield return RunTest<DoubleArrayProperty2, double[]>(new double[] { 27410.4055610534, 52484.5720978848 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleArrayProperties()
		{
			yield return RunTest<DoubleArrayProperties1, double[]>(new double[] { 52484.5720978848, 27410.4055610534 }, new double[] { -5448.07487421115, 29217.8858673283 });
			yield return RunTest<DoubleArrayProperties2, double[]>(new double[] { 27410.4055610534, 52484.5720978848 }, new double[] { 29217.8858673283, -5448.07487421115 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleArrayNullableField()
		{
			yield return RunTest<DoubleArrayNullableField1, double?[]>(new double?[] { null, 27410.4055610534 });
			yield return RunTest<DoubleArrayNullableField2, double?[]>(new double?[] { 27410.4055610534, null });
		}

		[UnityTest]
		public IEnumerator SaveDoubleArrayNullableFields()
		{
			yield return RunTest<DoubleArrayNullableFields1, double?[]>(new double?[] { null, 27410.4055610534 }, new double?[] { -5448.07487421115, null });
			yield return RunTest<DoubleArrayNullableFields2, double?[]>(new double?[] { 27410.4055610534, null }, new double?[] { null, -5448.07487421115 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleArrayNullableProperty()
		{
			yield return RunTest<DoubleArrayNullableProperty1, double?[]>(new double?[] { null, 27410.4055610534 });
			yield return RunTest<DoubleArrayNullableProperty2, double?[]>(new double?[] { 27410.4055610534, null });
		}

		[UnityTest]
		public IEnumerator SaveDoubleArrayNullableProperties()
		{
			yield return RunTest<DoubleArrayNullableProperties1, double?[]>(new double?[] { 52484.5720978848, null }, new double?[] { null, 29217.8858673283 });
			yield return RunTest<DoubleArrayNullableProperties2, double?[]>(new double?[] { null, 52484.5720978848 }, new double?[] { 29217.8858673283, null });
		}

		[UnityTest]
		public IEnumerator SaveDoubleListField()
		{
			yield return RunTest<DoubleListField1, List<double>>(new List<double> { 52484.5720978848, 27410.4055610534 });
			yield return RunTest<DoubleListField2, List<double>>(new List<double> { 27410.4055610534, 52484.5720978848 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleListFields()
		{
			yield return RunTest<DoubleListFields1, List<double>>(new List<double> { 52484.5720978848, 27410.4055610534 }, new List<double> { -5448.07487421115, 29217.8858673283 });
			yield return RunTest<DoubleListFields2, List<double>>(new List<double> { 27410.4055610534, 52484.5720978848 }, new List<double> { 29217.8858673283, -5448.07487421115 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleListProperty()
		{
			yield return RunTest<DoubleListProperty1, List<double>>(new List<double> { 52484.5720978848, 27410.4055610534 });
			yield return RunTest<DoubleListProperty2, List<double>>(new List<double> { 27410.4055610534, 52484.5720978848 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleListProperties()
		{
			yield return RunTest<DoubleListProperties1, List<double>>(new List<double> { 52484.5720978848, 27410.4055610534 }, new List<double> { -5448.07487421115, 29217.8858673283 });
			yield return RunTest<DoubleListProperties2, List<double>>(new List<double> { 27410.4055610534, 52484.5720978848 }, new List<double> { 29217.8858673283, -5448.07487421115 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleListNullableField()
		{
			yield return RunTest<DoubleListNullableField1, List<double?>>(new List<double?> { null, 27410.4055610534 });
			yield return RunTest<DoubleListNullableField2, List<double?>>(new List<double?> { 27410.4055610534, null });
		}

		[UnityTest]
		public IEnumerator SaveDoubleListNullableFields()
		{
			yield return RunTest<DoubleListNullableFields1, List<double?>>(new List<double?> { null, 27410.4055610534 }, new List<double?> { -5448.07487421115, null });
			yield return RunTest<DoubleListNullableFields2, List<double?>>(new List<double?> { 27410.4055610534, null }, new List<double?> { null, -5448.07487421115 });
		}

		[UnityTest]
		public IEnumerator SaveDoubleListNullableProperty()
		{
			yield return RunTest<DoubleListNullableProperty1, List<double?>>(new List<double?> { null, 27410.4055610534 });
			yield return RunTest<DoubleListNullableProperty2, List<double?>>(new List<double?> { 27410.4055610534, null });
		}

		[UnityTest]
		public IEnumerator SaveDoubleListNullableProperties()
		{
			yield return RunTest<DoubleListNullableProperties1, List<double?>>(new List<double?> { 52484.5720978848, null }, new List<double?> { null, 29217.8858673283 });
			yield return RunTest<DoubleListNullableProperties2, List<double?>>(new List<double?> { null, 52484.5720978848 }, new List<double?> { 29217.8858673283, null });
		}
	}
}