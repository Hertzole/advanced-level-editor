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
		public IEnumerator SaveQuaternionField()
		{
			yield return RunTest<QuaternionField1, Quaternion>(new Quaternion(0.43F, 0.62F, 0.78F, 0.79F));
			yield return RunTest<QuaternionField2, Quaternion>(new Quaternion(0.45F, 0.32F, 0.62F, 0.70F));
		}

		[UnityTest]
		public IEnumerator SaveQuaternionFields()
		{
			yield return RunTest<QuaternionFields1, Quaternion>(new Quaternion(0.45F, 0.32F, 0.62F, 0.70F), new Quaternion(0.43F, 0.62F, 0.78F, 0.79F));
			yield return RunTest<QuaternionFields2, Quaternion>(new Quaternion(0.43F, 0.62F, 0.78F, 0.79F), new Quaternion(0.45F, 0.32F, 0.62F, 0.70F));
		}

		[UnityTest]
		public IEnumerator SaveQuaternionProperty()
		{
			yield return RunTest<QuaternionProperty1, Quaternion>(new Quaternion(0.43F, 0.62F, 0.78F, 0.79F));
			yield return RunTest<QuaternionProperty2, Quaternion>(new Quaternion(0.45F, 0.32F, 0.62F, 0.70F));
		}

		[UnityTest]
		public IEnumerator SaveQuaternionProperties()
		{
			yield return RunTest<QuaternionProperties1, Quaternion>(new Quaternion(0.45F, 0.32F, 0.62F, 0.70F), new Quaternion(0.43F, 0.62F, 0.78F, 0.79F));
			yield return RunTest<QuaternionProperties2, Quaternion>(new Quaternion(0.43F, 0.62F, 0.78F, 0.79F), new Quaternion(0.45F, 0.32F, 0.62F, 0.70F));
		}

		[UnityTest]
		public IEnumerator SaveQuaternionNullableField()
		{
			yield return RunTest<QuaternionNullableField1, Quaternion?>(new Quaternion(0.43F, 0.62F, 0.78F, 0.79F));
			yield return RunTest<QuaternionNullableField2, Quaternion?>(new Quaternion(0.45F, 0.32F, 0.62F, 0.70F));
			yield return RunTest<QuaternionNullableField1, Quaternion?>(null);
			yield return RunTest<QuaternionNullableField2, Quaternion?>(null);
		}

		[UnityTest]
		public IEnumerator SaveQuaternionNullableFields()
		{
			yield return RunTest<QuaternionNullableFields1, Quaternion?>(new Quaternion(0.45F, 0.32F, 0.62F, 0.70F), new Quaternion(0.43F, 0.62F, 0.78F, 0.79F));
			yield return RunTest<QuaternionNullableFields2, Quaternion?>(new Quaternion(0.43F, 0.62F, 0.78F, 0.79F), new Quaternion(0.45F, 0.32F, 0.62F, 0.70F));
			yield return RunTest<QuaternionNullableFields1, Quaternion?>(null, new Quaternion(0.43F, 0.62F, 0.78F, 0.79F));
			yield return RunTest<QuaternionNullableFields2, Quaternion?>(new Quaternion(0.43F, 0.62F, 0.78F, 0.79F), null);
		}

		[UnityTest]
		public IEnumerator SaveQuaternionNullableProperty()
		{
			yield return RunTest<QuaternionNullableProperty1, Quaternion?>(new Quaternion(0.43F, 0.62F, 0.78F, 0.79F));
			yield return RunTest<QuaternionNullableProperty2, Quaternion?>(new Quaternion(0.45F, 0.32F, 0.62F, 0.70F));
			yield return RunTest<QuaternionNullableProperty1, Quaternion?>(null);
			yield return RunTest<QuaternionNullableProperty2, Quaternion?>(null);
		}

		[UnityTest]
		public IEnumerator SaveQuaternionNullableProperties()
		{
			yield return RunTest<QuaternionNullableProperties1, Quaternion?>(new Quaternion(0.45F, 0.32F, 0.62F, 0.70F), new Quaternion(0.43F, 0.62F, 0.78F, 0.79F));
			yield return RunTest<QuaternionNullableProperties2, Quaternion?>(new Quaternion(0.43F, 0.62F, 0.78F, 0.79F), new Quaternion(0.45F, 0.32F, 0.62F, 0.70F));
			yield return RunTest<QuaternionNullableProperties1, Quaternion?>(null, new Quaternion(0.43F, 0.62F, 0.78F, 0.79F));
			yield return RunTest<QuaternionNullableProperties2, Quaternion?>(new Quaternion(0.43F, 0.62F, 0.78F, 0.79F), null);
		}

		[UnityTest]
		public IEnumerator SaveQuaternionArrayField()
		{
			yield return RunTest<QuaternionArrayField1, Quaternion[]>(new Quaternion[] { new Quaternion(0.43F, 0.62F, 0.78F, 0.79F), new Quaternion(0.45F, 0.32F, 0.62F, 0.70F) });
			yield return RunTest<QuaternionArrayField2, Quaternion[]>(new Quaternion[] { new Quaternion(0.45F, 0.32F, 0.62F, 0.70F), new Quaternion(0.43F, 0.62F, 0.78F, 0.79F) });
		}

		[UnityTest]
		public IEnumerator SaveQuaternionArrayFields()
		{
			yield return RunTest<QuaternionArrayFields1, Quaternion[]>(new Quaternion[] { new Quaternion(0.43F, 0.62F, 0.78F, 0.79F), new Quaternion(0.45F, 0.32F, 0.62F, 0.70F) }, new Quaternion[] { new Quaternion(0.65F, 0.10F, 0.10F, 0.10F), new Quaternion(0.94F, 0.04F, 0.73F, 0.43F) });
			yield return RunTest<QuaternionArrayFields2, Quaternion[]>(new Quaternion[] { new Quaternion(0.45F, 0.32F, 0.62F, 0.70F), new Quaternion(0.43F, 0.62F, 0.78F, 0.79F) }, new Quaternion[] { new Quaternion(0.94F, 0.04F, 0.73F, 0.43F), new Quaternion(0.65F, 0.10F, 0.10F, 0.10F) });
		}

		[UnityTest]
		public IEnumerator SaveQuaternionArrayProperty()
		{
			yield return RunTest<QuaternionArrayProperty1, Quaternion[]>(new Quaternion[] { new Quaternion(0.43F, 0.62F, 0.78F, 0.79F), new Quaternion(0.45F, 0.32F, 0.62F, 0.70F) });
			yield return RunTest<QuaternionArrayProperty2, Quaternion[]>(new Quaternion[] { new Quaternion(0.45F, 0.32F, 0.62F, 0.70F), new Quaternion(0.43F, 0.62F, 0.78F, 0.79F) });
		}

		[UnityTest]
		public IEnumerator SaveQuaternionArrayProperties()
		{
			yield return RunTest<QuaternionArrayProperties1, Quaternion[]>(new Quaternion[] { new Quaternion(0.43F, 0.62F, 0.78F, 0.79F), new Quaternion(0.45F, 0.32F, 0.62F, 0.70F) }, new Quaternion[] { new Quaternion(0.65F, 0.10F, 0.10F, 0.10F), new Quaternion(0.94F, 0.04F, 0.73F, 0.43F) });
			yield return RunTest<QuaternionArrayProperties2, Quaternion[]>(new Quaternion[] { new Quaternion(0.45F, 0.32F, 0.62F, 0.70F), new Quaternion(0.43F, 0.62F, 0.78F, 0.79F) }, new Quaternion[] { new Quaternion(0.94F, 0.04F, 0.73F, 0.43F), new Quaternion(0.65F, 0.10F, 0.10F, 0.10F) });
		}

		[UnityTest]
		public IEnumerator SaveQuaternionArrayNullableField()
		{
			yield return RunTest<QuaternionArrayNullableField1, Quaternion?[]>(new Quaternion?[] { null, new Quaternion(0.45F, 0.32F, 0.62F, 0.70F) });
			yield return RunTest<QuaternionArrayNullableField2, Quaternion?[]>(new Quaternion?[] { new Quaternion(0.45F, 0.32F, 0.62F, 0.70F), null });
		}

		[UnityTest]
		public IEnumerator SaveQuaternionArrayNullableFields()
		{
			yield return RunTest<QuaternionArrayNullableFields1, Quaternion?[]>(new Quaternion?[] { null, new Quaternion(0.45F, 0.32F, 0.62F, 0.70F) }, new Quaternion?[] { new Quaternion(0.65F, 0.10F, 0.10F, 0.10F), null });
			yield return RunTest<QuaternionArrayNullableFields2, Quaternion?[]>(new Quaternion?[] { new Quaternion(0.45F, 0.32F, 0.62F, 0.70F), null }, new Quaternion?[] { null, new Quaternion(0.65F, 0.10F, 0.10F, 0.10F) });
		}

		[UnityTest]
		public IEnumerator SaveQuaternionArrayNullableProperty()
		{
			yield return RunTest<QuaternionArrayNullableProperty1, Quaternion?[]>(new Quaternion?[] { null, new Quaternion(0.45F, 0.32F, 0.62F, 0.70F) });
			yield return RunTest<QuaternionArrayNullableProperty2, Quaternion?[]>(new Quaternion?[] { new Quaternion(0.45F, 0.32F, 0.62F, 0.70F), null });
		}

		[UnityTest]
		public IEnumerator SaveQuaternionArrayNullableProperties()
		{
			yield return RunTest<QuaternionArrayNullableProperties1, Quaternion?[]>(new Quaternion?[] { new Quaternion(0.43F, 0.62F, 0.78F, 0.79F), null }, new Quaternion?[] { null, new Quaternion(0.94F, 0.04F, 0.73F, 0.43F) });
			yield return RunTest<QuaternionArrayNullableProperties2, Quaternion?[]>(new Quaternion?[] { null, new Quaternion(0.43F, 0.62F, 0.78F, 0.79F) }, new Quaternion?[] { new Quaternion(0.94F, 0.04F, 0.73F, 0.43F), null });
		}

		[UnityTest]
		public IEnumerator SaveQuaternionListField()
		{
			yield return RunTest<QuaternionListField1, List<Quaternion>>(new List<Quaternion> { new Quaternion(0.43F, 0.62F, 0.78F, 0.79F), new Quaternion(0.45F, 0.32F, 0.62F, 0.70F) });
			yield return RunTest<QuaternionListField2, List<Quaternion>>(new List<Quaternion> { new Quaternion(0.45F, 0.32F, 0.62F, 0.70F), new Quaternion(0.43F, 0.62F, 0.78F, 0.79F) });
		}

		[UnityTest]
		public IEnumerator SaveQuaternionListFields()
		{
			yield return RunTest<QuaternionListFields1, List<Quaternion>>(new List<Quaternion> { new Quaternion(0.43F, 0.62F, 0.78F, 0.79F), new Quaternion(0.45F, 0.32F, 0.62F, 0.70F) }, new List<Quaternion> { new Quaternion(0.65F, 0.10F, 0.10F, 0.10F), new Quaternion(0.94F, 0.04F, 0.73F, 0.43F) });
			yield return RunTest<QuaternionListFields2, List<Quaternion>>(new List<Quaternion> { new Quaternion(0.45F, 0.32F, 0.62F, 0.70F), new Quaternion(0.43F, 0.62F, 0.78F, 0.79F) }, new List<Quaternion> { new Quaternion(0.94F, 0.04F, 0.73F, 0.43F), new Quaternion(0.65F, 0.10F, 0.10F, 0.10F) });
		}

		[UnityTest]
		public IEnumerator SaveQuaternionListProperty()
		{
			yield return RunTest<QuaternionListProperty1, List<Quaternion>>(new List<Quaternion> { new Quaternion(0.43F, 0.62F, 0.78F, 0.79F), new Quaternion(0.45F, 0.32F, 0.62F, 0.70F) });
			yield return RunTest<QuaternionListProperty2, List<Quaternion>>(new List<Quaternion> { new Quaternion(0.45F, 0.32F, 0.62F, 0.70F), new Quaternion(0.43F, 0.62F, 0.78F, 0.79F) });
		}

		[UnityTest]
		public IEnumerator SaveQuaternionListProperties()
		{
			yield return RunTest<QuaternionListProperties1, List<Quaternion>>(new List<Quaternion> { new Quaternion(0.43F, 0.62F, 0.78F, 0.79F), new Quaternion(0.45F, 0.32F, 0.62F, 0.70F) }, new List<Quaternion> { new Quaternion(0.65F, 0.10F, 0.10F, 0.10F), new Quaternion(0.94F, 0.04F, 0.73F, 0.43F) });
			yield return RunTest<QuaternionListProperties2, List<Quaternion>>(new List<Quaternion> { new Quaternion(0.45F, 0.32F, 0.62F, 0.70F), new Quaternion(0.43F, 0.62F, 0.78F, 0.79F) }, new List<Quaternion> { new Quaternion(0.94F, 0.04F, 0.73F, 0.43F), new Quaternion(0.65F, 0.10F, 0.10F, 0.10F) });
		}

		[UnityTest]
		public IEnumerator SaveQuaternionListNullableField()
		{
			yield return RunTest<QuaternionListNullableField1, List<Quaternion?>>(new List<Quaternion?> { null, new Quaternion(0.45F, 0.32F, 0.62F, 0.70F) });
			yield return RunTest<QuaternionListNullableField2, List<Quaternion?>>(new List<Quaternion?> { new Quaternion(0.45F, 0.32F, 0.62F, 0.70F), null });
		}

		[UnityTest]
		public IEnumerator SaveQuaternionListNullableFields()
		{
			yield return RunTest<QuaternionListNullableFields1, List<Quaternion?>>(new List<Quaternion?> { null, new Quaternion(0.45F, 0.32F, 0.62F, 0.70F) }, new List<Quaternion?> { new Quaternion(0.65F, 0.10F, 0.10F, 0.10F), null });
			yield return RunTest<QuaternionListNullableFields2, List<Quaternion?>>(new List<Quaternion?> { new Quaternion(0.45F, 0.32F, 0.62F, 0.70F), null }, new List<Quaternion?> { null, new Quaternion(0.65F, 0.10F, 0.10F, 0.10F) });
		}

		[UnityTest]
		public IEnumerator SaveQuaternionListNullableProperty()
		{
			yield return RunTest<QuaternionListNullableProperty1, List<Quaternion?>>(new List<Quaternion?> { null, new Quaternion(0.45F, 0.32F, 0.62F, 0.70F) });
			yield return RunTest<QuaternionListNullableProperty2, List<Quaternion?>>(new List<Quaternion?> { new Quaternion(0.45F, 0.32F, 0.62F, 0.70F), null });
		}

		[UnityTest]
		public IEnumerator SaveQuaternionListNullableProperties()
		{
			yield return RunTest<QuaternionListNullableProperties1, List<Quaternion?>>(new List<Quaternion?> { new Quaternion(0.43F, 0.62F, 0.78F, 0.79F), null }, new List<Quaternion?> { null, new Quaternion(0.94F, 0.04F, 0.73F, 0.43F) });
			yield return RunTest<QuaternionListNullableProperties2, List<Quaternion?>>(new List<Quaternion?> { null, new Quaternion(0.43F, 0.62F, 0.78F, 0.79F) }, new List<Quaternion?> { new Quaternion(0.94F, 0.04F, 0.73F, 0.43F), null });
		}
	}
}