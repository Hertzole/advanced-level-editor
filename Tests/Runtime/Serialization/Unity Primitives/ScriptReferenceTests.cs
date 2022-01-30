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
		public IEnumerator SaveScriptReferenceField()
		{
			yield return RunReferenceTest<ScriptReferenceField1, ScriptReference>(false);
			yield return RunReferenceTest<ScriptReferenceField2, ScriptReference>(false);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceFields()
		{
			yield return RunReferenceTest<ScriptReferenceFields1, ScriptReference>(false, false);
			yield return RunReferenceTest<ScriptReferenceFields2, ScriptReference>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceProperty()
		{
			yield return RunReferenceTest<ScriptReferenceProperty1, ScriptReference>(false);
			yield return RunReferenceTest<ScriptReferenceProperty2, ScriptReference>(false);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceProperties()
		{
			yield return RunReferenceTest<ScriptReferenceProperties1, ScriptReference>(false, false);
			yield return RunReferenceTest<ScriptReferenceProperties2, ScriptReference>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceNullableField()
		{
			yield return RunReferenceTest<ScriptReferenceNullableField1, ScriptReference?>(false);
			yield return RunReferenceTest<ScriptReferenceNullableField2, ScriptReference?>(false);
			yield return RunReferenceTest<ScriptReferenceNullableField1, ScriptReference?>(true);
			yield return RunReferenceTest<ScriptReferenceNullableField2, ScriptReference?>(true);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceNullableFields()
		{
			yield return RunReferenceTest<ScriptReferenceNullableFields1, ScriptReference?>(false, false);
			yield return RunReferenceTest<ScriptReferenceNullableFields2, ScriptReference?>(false, false);
			yield return RunReferenceTest<ScriptReferenceNullableFields1, ScriptReference?>(true, false);
			yield return RunReferenceTest<ScriptReferenceNullableFields2, ScriptReference?>(false, true);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceNullableProperty()
		{
			yield return RunReferenceTest<ScriptReferenceNullableProperty1, ScriptReference?>(false);
			yield return RunReferenceTest<ScriptReferenceNullableProperty2, ScriptReference?>(false);
			yield return RunReferenceTest<ScriptReferenceNullableProperty1, ScriptReference?>(true);
			yield return RunReferenceTest<ScriptReferenceNullableProperty2, ScriptReference?>(true);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceNullableProperties()
		{
			yield return RunReferenceTest<ScriptReferenceNullableProperties1, ScriptReference?>(false, false);
			yield return RunReferenceTest<ScriptReferenceNullableProperties2, ScriptReference?>(false, false);
			yield return RunReferenceTest<ScriptReferenceNullableProperties1, ScriptReference?>(true, false);
			yield return RunReferenceTest<ScriptReferenceNullableProperties2, ScriptReference?>(false, true);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceArrayField()
		{
			yield return RunReferenceCollectionTest<ScriptReferenceArrayField1, ScriptReference[]>(false, false);
			yield return RunReferenceCollectionTest<ScriptReferenceArrayField2, ScriptReference[]>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceArrayFields()
		{
			yield return RunReferenceCollectionTest<ScriptReferenceArrayFields1, ScriptReference[]>(false, false, false, false);
			yield return RunReferenceCollectionTest<ScriptReferenceArrayFields2, ScriptReference[]>(false, false, false, false);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceArrayProperty()
		{
			yield return RunReferenceCollectionTest<ScriptReferenceArrayProperty1, ScriptReference[]>(false, false);
			yield return RunReferenceCollectionTest<ScriptReferenceArrayProperty2, ScriptReference[]>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceArrayProperties()
		{
			yield return RunReferenceCollectionTest<ScriptReferenceArrayProperties1, ScriptReference[]>(false, false, false, false);
			yield return RunReferenceCollectionTest<ScriptReferenceArrayProperties2, ScriptReference[]>(false, false, false, false);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceArrayNullableField()
		{
			yield return RunReferenceCollectionTest<ScriptReferenceArrayNullableField1, ScriptReference?[]>(true, false);
			yield return RunReferenceCollectionTest<ScriptReferenceArrayNullableField2, ScriptReference?[]>(false, true);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceArrayNullableFields()
		{
			yield return RunReferenceCollectionTest<ScriptReferenceArrayNullableFields1, ScriptReference?[]>(true, false, false, true);
			yield return RunReferenceCollectionTest<ScriptReferenceArrayNullableFields2, ScriptReference?[]>(false, true, true, false);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceArrayNullableProperty()
		{
			yield return RunReferenceCollectionTest<ScriptReferenceArrayNullableProperty1, ScriptReference?[]>(true, false);
			yield return RunReferenceCollectionTest<ScriptReferenceArrayNullableProperty2, ScriptReference?[]>(false, true);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceArrayNullableProperties()
		{
			yield return RunReferenceCollectionTest<ScriptReferenceArrayNullableProperties1, ScriptReference?[]>(false, true, true, false);
			yield return RunReferenceCollectionTest<ScriptReferenceArrayNullableProperties2, ScriptReference?[]>(true, false, false, true);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceListField()
		{
			yield return RunReferenceCollectionTest<ScriptReferenceListField1, List<ScriptReference>>(false, false);
			yield return RunReferenceCollectionTest<ScriptReferenceListField2, List<ScriptReference>>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceListFields()
		{
			yield return RunReferenceCollectionTest<ScriptReferenceListFields1, List<ScriptReference>>(false, false, false, false);
			yield return RunReferenceCollectionTest<ScriptReferenceListFields2, List<ScriptReference>>(false, false, false, false);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceListProperty()
		{
			yield return RunReferenceCollectionTest<ScriptReferenceListProperty1, List<ScriptReference>>(false, false);
			yield return RunReferenceCollectionTest<ScriptReferenceListProperty2, List<ScriptReference>>(false, false);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceListProperties()
		{
			yield return RunReferenceCollectionTest<ScriptReferenceListProperties1, List<ScriptReference>>(false, false, false, false);
			yield return RunReferenceCollectionTest<ScriptReferenceListProperties2, List<ScriptReference>>(false, false, false, false);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceListNullableField()
		{
			yield return RunReferenceCollectionTest<ScriptReferenceListNullableField1, List<ScriptReference?>>(true, false);
			yield return RunReferenceCollectionTest<ScriptReferenceListNullableField2, List<ScriptReference?>>(false, true);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceListNullableFields()
		{
			yield return RunReferenceCollectionTest<ScriptReferenceListNullableFields1, List<ScriptReference?>>(true, false, false, true);
			yield return RunReferenceCollectionTest<ScriptReferenceListNullableFields2, List<ScriptReference?>>(false, true, true, false);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceListNullableProperty()
		{
			yield return RunReferenceCollectionTest<ScriptReferenceListNullableProperty1, List<ScriptReference?>>(true, false);
			yield return RunReferenceCollectionTest<ScriptReferenceListNullableProperty2, List<ScriptReference?>>(false, true);
		}

		[UnityTest]
		public IEnumerator SaveScriptReferenceListNullableProperties()
		{
			yield return RunReferenceCollectionTest<ScriptReferenceListNullableProperties1, List<ScriptReference?>>(false, true, true, false);
			yield return RunReferenceCollectionTest<ScriptReferenceListNullableProperties2, List<ScriptReference?>>(true, false, false, true);
		}
	}
}