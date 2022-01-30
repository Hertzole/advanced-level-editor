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
		public IEnumerator SaveBoundsField()
		{
			yield return RunTest<BoundsField1, Bounds>(new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)));
			yield return RunTest<BoundsField2, Bounds>(new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)));
		}

		[UnityTest]
		public IEnumerator SaveBoundsFields()
		{
			yield return RunTest<BoundsFields1, Bounds>(new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)), new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)));
			yield return RunTest<BoundsFields2, Bounds>(new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)), new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)));
		}

		[UnityTest]
		public IEnumerator SaveBoundsProperty()
		{
			yield return RunTest<BoundsProperty1, Bounds>(new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)));
			yield return RunTest<BoundsProperty2, Bounds>(new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)));
		}

		[UnityTest]
		public IEnumerator SaveBoundsProperties()
		{
			yield return RunTest<BoundsProperties1, Bounds>(new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)), new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)));
			yield return RunTest<BoundsProperties2, Bounds>(new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)), new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)));
		}

		[UnityTest]
		public IEnumerator SaveBoundsNullableField()
		{
			yield return RunTest<BoundsNullableField1, Bounds?>(new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)));
			yield return RunTest<BoundsNullableField2, Bounds?>(new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)));
			yield return RunTest<BoundsNullableField1, Bounds?>(null);
			yield return RunTest<BoundsNullableField2, Bounds?>(null);
		}

		[UnityTest]
		public IEnumerator SaveBoundsNullableFields()
		{
			yield return RunTest<BoundsNullableFields1, Bounds?>(new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)), new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)));
			yield return RunTest<BoundsNullableFields2, Bounds?>(new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)), new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)));
			yield return RunTest<BoundsNullableFields1, Bounds?>(null, new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)));
			yield return RunTest<BoundsNullableFields2, Bounds?>(new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)), null);
		}

		[UnityTest]
		public IEnumerator SaveBoundsNullableProperty()
		{
			yield return RunTest<BoundsNullableProperty1, Bounds?>(new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)));
			yield return RunTest<BoundsNullableProperty2, Bounds?>(new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)));
			yield return RunTest<BoundsNullableProperty1, Bounds?>(null);
			yield return RunTest<BoundsNullableProperty2, Bounds?>(null);
		}

		[UnityTest]
		public IEnumerator SaveBoundsNullableProperties()
		{
			yield return RunTest<BoundsNullableProperties1, Bounds?>(new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)), new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)));
			yield return RunTest<BoundsNullableProperties2, Bounds?>(new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)), new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)));
			yield return RunTest<BoundsNullableProperties1, Bounds?>(null, new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)));
			yield return RunTest<BoundsNullableProperties2, Bounds?>(new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)), null);
		}

		[UnityTest]
		public IEnumerator SaveBoundsArrayField()
		{
			yield return RunTest<BoundsArrayField1, Bounds[]>(new Bounds[] { new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)), new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)) });
			yield return RunTest<BoundsArrayField2, Bounds[]>(new Bounds[] { new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)), new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsArrayFields()
		{
			yield return RunTest<BoundsArrayFields1, Bounds[]>(new Bounds[] { new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)), new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)) }, new Bounds[] { new Bounds(new Vector3(0.56F, 0.61F, 0.35F), new Vector3(0.05F, 0.59F, 0.71F)), new Bounds(new Vector3(0.73F, 0.01F, 0.65F), new Vector3(0.25F, 0.13F, 0.95F)) });
			yield return RunTest<BoundsArrayFields2, Bounds[]>(new Bounds[] { new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)), new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)) }, new Bounds[] { new Bounds(new Vector3(0.73F, 0.01F, 0.65F), new Vector3(0.25F, 0.13F, 0.95F)), new Bounds(new Vector3(0.56F, 0.61F, 0.35F), new Vector3(0.05F, 0.59F, 0.71F)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsArrayProperty()
		{
			yield return RunTest<BoundsArrayProperty1, Bounds[]>(new Bounds[] { new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)), new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)) });
			yield return RunTest<BoundsArrayProperty2, Bounds[]>(new Bounds[] { new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)), new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsArrayProperties()
		{
			yield return RunTest<BoundsArrayProperties1, Bounds[]>(new Bounds[] { new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)), new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)) }, new Bounds[] { new Bounds(new Vector3(0.56F, 0.61F, 0.35F), new Vector3(0.05F, 0.59F, 0.71F)), new Bounds(new Vector3(0.73F, 0.01F, 0.65F), new Vector3(0.25F, 0.13F, 0.95F)) });
			yield return RunTest<BoundsArrayProperties2, Bounds[]>(new Bounds[] { new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)), new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)) }, new Bounds[] { new Bounds(new Vector3(0.73F, 0.01F, 0.65F), new Vector3(0.25F, 0.13F, 0.95F)), new Bounds(new Vector3(0.56F, 0.61F, 0.35F), new Vector3(0.05F, 0.59F, 0.71F)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsArrayNullableField()
		{
			yield return RunTest<BoundsArrayNullableField1, Bounds?[]>(new Bounds?[] { null, new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)) });
			yield return RunTest<BoundsArrayNullableField2, Bounds?[]>(new Bounds?[] { new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)), null });
		}

		[UnityTest]
		public IEnumerator SaveBoundsArrayNullableFields()
		{
			yield return RunTest<BoundsArrayNullableFields1, Bounds?[]>(new Bounds?[] { null, new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)) }, new Bounds?[] { new Bounds(new Vector3(0.56F, 0.61F, 0.35F), new Vector3(0.05F, 0.59F, 0.71F)), null });
			yield return RunTest<BoundsArrayNullableFields2, Bounds?[]>(new Bounds?[] { new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)), null }, new Bounds?[] { null, new Bounds(new Vector3(0.56F, 0.61F, 0.35F), new Vector3(0.05F, 0.59F, 0.71F)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsArrayNullableProperty()
		{
			yield return RunTest<BoundsArrayNullableProperty1, Bounds?[]>(new Bounds?[] { null, new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)) });
			yield return RunTest<BoundsArrayNullableProperty2, Bounds?[]>(new Bounds?[] { new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)), null });
		}

		[UnityTest]
		public IEnumerator SaveBoundsArrayNullableProperties()
		{
			yield return RunTest<BoundsArrayNullableProperties1, Bounds?[]>(new Bounds?[] { new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)), null }, new Bounds?[] { null, new Bounds(new Vector3(0.73F, 0.01F, 0.65F), new Vector3(0.25F, 0.13F, 0.95F)) });
			yield return RunTest<BoundsArrayNullableProperties2, Bounds?[]>(new Bounds?[] { null, new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)) }, new Bounds?[] { new Bounds(new Vector3(0.73F, 0.01F, 0.65F), new Vector3(0.25F, 0.13F, 0.95F)), null });
		}

		[UnityTest]
		public IEnumerator SaveBoundsListField()
		{
			yield return RunTest<BoundsListField1, List<Bounds>>(new List<Bounds> { new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)), new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)) });
			yield return RunTest<BoundsListField2, List<Bounds>>(new List<Bounds> { new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)), new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsListFields()
		{
			yield return RunTest<BoundsListFields1, List<Bounds>>(new List<Bounds> { new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)), new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)) }, new List<Bounds> { new Bounds(new Vector3(0.56F, 0.61F, 0.35F), new Vector3(0.05F, 0.59F, 0.71F)), new Bounds(new Vector3(0.73F, 0.01F, 0.65F), new Vector3(0.25F, 0.13F, 0.95F)) });
			yield return RunTest<BoundsListFields2, List<Bounds>>(new List<Bounds> { new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)), new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)) }, new List<Bounds> { new Bounds(new Vector3(0.73F, 0.01F, 0.65F), new Vector3(0.25F, 0.13F, 0.95F)), new Bounds(new Vector3(0.56F, 0.61F, 0.35F), new Vector3(0.05F, 0.59F, 0.71F)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsListProperty()
		{
			yield return RunTest<BoundsListProperty1, List<Bounds>>(new List<Bounds> { new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)), new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)) });
			yield return RunTest<BoundsListProperty2, List<Bounds>>(new List<Bounds> { new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)), new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsListProperties()
		{
			yield return RunTest<BoundsListProperties1, List<Bounds>>(new List<Bounds> { new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)), new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)) }, new List<Bounds> { new Bounds(new Vector3(0.56F, 0.61F, 0.35F), new Vector3(0.05F, 0.59F, 0.71F)), new Bounds(new Vector3(0.73F, 0.01F, 0.65F), new Vector3(0.25F, 0.13F, 0.95F)) });
			yield return RunTest<BoundsListProperties2, List<Bounds>>(new List<Bounds> { new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)), new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)) }, new List<Bounds> { new Bounds(new Vector3(0.73F, 0.01F, 0.65F), new Vector3(0.25F, 0.13F, 0.95F)), new Bounds(new Vector3(0.56F, 0.61F, 0.35F), new Vector3(0.05F, 0.59F, 0.71F)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsListNullableField()
		{
			yield return RunTest<BoundsListNullableField1, List<Bounds?>>(new List<Bounds?> { null, new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)) });
			yield return RunTest<BoundsListNullableField2, List<Bounds?>>(new List<Bounds?> { new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)), null });
		}

		[UnityTest]
		public IEnumerator SaveBoundsListNullableFields()
		{
			yield return RunTest<BoundsListNullableFields1, List<Bounds?>>(new List<Bounds?> { null, new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)) }, new List<Bounds?> { new Bounds(new Vector3(0.56F, 0.61F, 0.35F), new Vector3(0.05F, 0.59F, 0.71F)), null });
			yield return RunTest<BoundsListNullableFields2, List<Bounds?>>(new List<Bounds?> { new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)), null }, new List<Bounds?> { null, new Bounds(new Vector3(0.56F, 0.61F, 0.35F), new Vector3(0.05F, 0.59F, 0.71F)) });
		}

		[UnityTest]
		public IEnumerator SaveBoundsListNullableProperty()
		{
			yield return RunTest<BoundsListNullableProperty1, List<Bounds?>>(new List<Bounds?> { null, new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)) });
			yield return RunTest<BoundsListNullableProperty2, List<Bounds?>>(new List<Bounds?> { new Bounds(new Vector3(0.68F, 0.84F, 0.49F), new Vector3(0.36F, 0.05F, 0.67F)), null });
		}

		[UnityTest]
		public IEnumerator SaveBoundsListNullableProperties()
		{
			yield return RunTest<BoundsListNullableProperties1, List<Bounds?>>(new List<Bounds?> { new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)), null }, new List<Bounds?> { null, new Bounds(new Vector3(0.73F, 0.01F, 0.65F), new Vector3(0.25F, 0.13F, 0.95F)) });
			yield return RunTest<BoundsListNullableProperties2, List<Bounds?>>(new List<Bounds?> { null, new Bounds(new Vector3(0.95F, 0.32F, 0.40F), new Vector3(0.82F, 0.07F, 0.87F)) }, new List<Bounds?> { new Bounds(new Vector3(0.73F, 0.01F, 0.65F), new Vector3(0.25F, 0.13F, 0.95F)), null });
		}
	}
}