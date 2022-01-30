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
		public IEnumerator SaveColor32Field()
		{
			yield return RunTest<Color32Field1, Color32>(new Color32(140, 126, 9, 191));
			yield return RunTest<Color32Field2, Color32>(new Color32(142, 141, 180, 138));
		}

		[UnityTest]
		public IEnumerator SaveColor32Fields()
		{
			yield return RunTest<Color32Fields1, Color32>(new Color32(142, 141, 180, 138), new Color32(140, 126, 9, 191));
			yield return RunTest<Color32Fields2, Color32>(new Color32(140, 126, 9, 191), new Color32(142, 141, 180, 138));
		}

		[UnityTest]
		public IEnumerator SaveColor32Property()
		{
			yield return RunTest<Color32Property1, Color32>(new Color32(140, 126, 9, 191));
			yield return RunTest<Color32Property2, Color32>(new Color32(142, 141, 180, 138));
		}

		[UnityTest]
		public IEnumerator SaveColor32Properties()
		{
			yield return RunTest<Color32Properties1, Color32>(new Color32(142, 141, 180, 138), new Color32(140, 126, 9, 191));
			yield return RunTest<Color32Properties2, Color32>(new Color32(140, 126, 9, 191), new Color32(142, 141, 180, 138));
		}

		[UnityTest]
		public IEnumerator SaveColor32NullableField()
		{
			yield return RunTest<Color32NullableField1, Color32?>(new Color32(140, 126, 9, 191));
			yield return RunTest<Color32NullableField2, Color32?>(new Color32(142, 141, 180, 138));
			yield return RunTest<Color32NullableField1, Color32?>(null);
			yield return RunTest<Color32NullableField2, Color32?>(null);
		}

		[UnityTest]
		public IEnumerator SaveColor32NullableFields()
		{
			yield return RunTest<Color32NullableFields1, Color32?>(new Color32(142, 141, 180, 138), new Color32(140, 126, 9, 191));
			yield return RunTest<Color32NullableFields2, Color32?>(new Color32(140, 126, 9, 191), new Color32(142, 141, 180, 138));
			yield return RunTest<Color32NullableFields1, Color32?>(null, new Color32(140, 126, 9, 191));
			yield return RunTest<Color32NullableFields2, Color32?>(new Color32(140, 126, 9, 191), null);
		}

		[UnityTest]
		public IEnumerator SaveColor32NullableProperty()
		{
			yield return RunTest<Color32NullableProperty1, Color32?>(new Color32(140, 126, 9, 191));
			yield return RunTest<Color32NullableProperty2, Color32?>(new Color32(142, 141, 180, 138));
			yield return RunTest<Color32NullableProperty1, Color32?>(null);
			yield return RunTest<Color32NullableProperty2, Color32?>(null);
		}

		[UnityTest]
		public IEnumerator SaveColor32NullableProperties()
		{
			yield return RunTest<Color32NullableProperties1, Color32?>(new Color32(142, 141, 180, 138), new Color32(140, 126, 9, 191));
			yield return RunTest<Color32NullableProperties2, Color32?>(new Color32(140, 126, 9, 191), new Color32(142, 141, 180, 138));
			yield return RunTest<Color32NullableProperties1, Color32?>(null, new Color32(140, 126, 9, 191));
			yield return RunTest<Color32NullableProperties2, Color32?>(new Color32(140, 126, 9, 191), null);
		}

		[UnityTest]
		public IEnumerator SaveColor32ArrayField()
		{
			yield return RunTest<Color32ArrayField1, Color32[]>(new Color32[] { new Color32(140, 126, 9, 191), new Color32(142, 141, 180, 138) });
			yield return RunTest<Color32ArrayField2, Color32[]>(new Color32[] { new Color32(142, 141, 180, 138), new Color32(140, 126, 9, 191) });
		}

		[UnityTest]
		public IEnumerator SaveColor32ArrayFields()
		{
			yield return RunTest<Color32ArrayFields1, Color32[]>(new Color32[] { new Color32(140, 126, 9, 191), new Color32(142, 141, 180, 138) }, new Color32[] { new Color32(214, 198, 219, 133), new Color32(138, 127, 99, 237) });
			yield return RunTest<Color32ArrayFields2, Color32[]>(new Color32[] { new Color32(142, 141, 180, 138), new Color32(140, 126, 9, 191) }, new Color32[] { new Color32(138, 127, 99, 237), new Color32(214, 198, 219, 133) });
		}

		[UnityTest]
		public IEnumerator SaveColor32ArrayProperty()
		{
			yield return RunTest<Color32ArrayProperty1, Color32[]>(new Color32[] { new Color32(140, 126, 9, 191), new Color32(142, 141, 180, 138) });
			yield return RunTest<Color32ArrayProperty2, Color32[]>(new Color32[] { new Color32(142, 141, 180, 138), new Color32(140, 126, 9, 191) });
		}

		[UnityTest]
		public IEnumerator SaveColor32ArrayProperties()
		{
			yield return RunTest<Color32ArrayProperties1, Color32[]>(new Color32[] { new Color32(140, 126, 9, 191), new Color32(142, 141, 180, 138) }, new Color32[] { new Color32(214, 198, 219, 133), new Color32(138, 127, 99, 237) });
			yield return RunTest<Color32ArrayProperties2, Color32[]>(new Color32[] { new Color32(142, 141, 180, 138), new Color32(140, 126, 9, 191) }, new Color32[] { new Color32(138, 127, 99, 237), new Color32(214, 198, 219, 133) });
		}

		[UnityTest]
		public IEnumerator SaveColor32ArrayNullableField()
		{
			yield return RunTest<Color32ArrayNullableField1, Color32?[]>(new Color32?[] { null, new Color32(142, 141, 180, 138) });
			yield return RunTest<Color32ArrayNullableField2, Color32?[]>(new Color32?[] { new Color32(142, 141, 180, 138), null });
		}

		[UnityTest]
		public IEnumerator SaveColor32ArrayNullableFields()
		{
			yield return RunTest<Color32ArrayNullableFields1, Color32?[]>(new Color32?[] { null, new Color32(142, 141, 180, 138) }, new Color32?[] { new Color32(214, 198, 219, 133), null });
			yield return RunTest<Color32ArrayNullableFields2, Color32?[]>(new Color32?[] { new Color32(142, 141, 180, 138), null }, new Color32?[] { null, new Color32(214, 198, 219, 133) });
		}

		[UnityTest]
		public IEnumerator SaveColor32ArrayNullableProperty()
		{
			yield return RunTest<Color32ArrayNullableProperty1, Color32?[]>(new Color32?[] { null, new Color32(142, 141, 180, 138) });
			yield return RunTest<Color32ArrayNullableProperty2, Color32?[]>(new Color32?[] { new Color32(142, 141, 180, 138), null });
		}

		[UnityTest]
		public IEnumerator SaveColor32ArrayNullableProperties()
		{
			yield return RunTest<Color32ArrayNullableProperties1, Color32?[]>(new Color32?[] { new Color32(140, 126, 9, 191), null }, new Color32?[] { null, new Color32(138, 127, 99, 237) });
			yield return RunTest<Color32ArrayNullableProperties2, Color32?[]>(new Color32?[] { null, new Color32(140, 126, 9, 191) }, new Color32?[] { new Color32(138, 127, 99, 237), null });
		}

		[UnityTest]
		public IEnumerator SaveColor32ListField()
		{
			yield return RunTest<Color32ListField1, List<Color32>>(new List<Color32> { new Color32(140, 126, 9, 191), new Color32(142, 141, 180, 138) });
			yield return RunTest<Color32ListField2, List<Color32>>(new List<Color32> { new Color32(142, 141, 180, 138), new Color32(140, 126, 9, 191) });
		}

		[UnityTest]
		public IEnumerator SaveColor32ListFields()
		{
			yield return RunTest<Color32ListFields1, List<Color32>>(new List<Color32> { new Color32(140, 126, 9, 191), new Color32(142, 141, 180, 138) }, new List<Color32> { new Color32(214, 198, 219, 133), new Color32(138, 127, 99, 237) });
			yield return RunTest<Color32ListFields2, List<Color32>>(new List<Color32> { new Color32(142, 141, 180, 138), new Color32(140, 126, 9, 191) }, new List<Color32> { new Color32(138, 127, 99, 237), new Color32(214, 198, 219, 133) });
		}

		[UnityTest]
		public IEnumerator SaveColor32ListProperty()
		{
			yield return RunTest<Color32ListProperty1, List<Color32>>(new List<Color32> { new Color32(140, 126, 9, 191), new Color32(142, 141, 180, 138) });
			yield return RunTest<Color32ListProperty2, List<Color32>>(new List<Color32> { new Color32(142, 141, 180, 138), new Color32(140, 126, 9, 191) });
		}

		[UnityTest]
		public IEnumerator SaveColor32ListProperties()
		{
			yield return RunTest<Color32ListProperties1, List<Color32>>(new List<Color32> { new Color32(140, 126, 9, 191), new Color32(142, 141, 180, 138) }, new List<Color32> { new Color32(214, 198, 219, 133), new Color32(138, 127, 99, 237) });
			yield return RunTest<Color32ListProperties2, List<Color32>>(new List<Color32> { new Color32(142, 141, 180, 138), new Color32(140, 126, 9, 191) }, new List<Color32> { new Color32(138, 127, 99, 237), new Color32(214, 198, 219, 133) });
		}

		[UnityTest]
		public IEnumerator SaveColor32ListNullableField()
		{
			yield return RunTest<Color32ListNullableField1, List<Color32?>>(new List<Color32?> { null, new Color32(142, 141, 180, 138) });
			yield return RunTest<Color32ListNullableField2, List<Color32?>>(new List<Color32?> { new Color32(142, 141, 180, 138), null });
		}

		[UnityTest]
		public IEnumerator SaveColor32ListNullableFields()
		{
			yield return RunTest<Color32ListNullableFields1, List<Color32?>>(new List<Color32?> { null, new Color32(142, 141, 180, 138) }, new List<Color32?> { new Color32(214, 198, 219, 133), null });
			yield return RunTest<Color32ListNullableFields2, List<Color32?>>(new List<Color32?> { new Color32(142, 141, 180, 138), null }, new List<Color32?> { null, new Color32(214, 198, 219, 133) });
		}

		[UnityTest]
		public IEnumerator SaveColor32ListNullableProperty()
		{
			yield return RunTest<Color32ListNullableProperty1, List<Color32?>>(new List<Color32?> { null, new Color32(142, 141, 180, 138) });
			yield return RunTest<Color32ListNullableProperty2, List<Color32?>>(new List<Color32?> { new Color32(142, 141, 180, 138), null });
		}

		[UnityTest]
		public IEnumerator SaveColor32ListNullableProperties()
		{
			yield return RunTest<Color32ListNullableProperties1, List<Color32?>>(new List<Color32?> { new Color32(140, 126, 9, 191), null }, new List<Color32?> { null, new Color32(138, 127, 99, 237) });
			yield return RunTest<Color32ListNullableProperties2, List<Color32?>>(new List<Color32?> { null, new Color32(140, 126, 9, 191) }, new List<Color32?> { new Color32(138, 127, 99, 237), null });
		}
	}
}