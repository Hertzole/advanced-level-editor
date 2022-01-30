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
		public IEnumerator SaveMatrix4x4Field()
		{
			yield return RunTest<Matrix4x4Field1, Matrix4x4>(new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)));
			yield return RunTest<Matrix4x4Field2, Matrix4x4>(new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)));
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4Fields()
		{
			yield return RunTest<Matrix4x4Fields1, Matrix4x4>(new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)), new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)));
			yield return RunTest<Matrix4x4Fields2, Matrix4x4>(new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)), new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)));
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4Property()
		{
			yield return RunTest<Matrix4x4Property1, Matrix4x4>(new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)));
			yield return RunTest<Matrix4x4Property2, Matrix4x4>(new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)));
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4Properties()
		{
			yield return RunTest<Matrix4x4Properties1, Matrix4x4>(new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)), new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)));
			yield return RunTest<Matrix4x4Properties2, Matrix4x4>(new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)), new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)));
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4NullableField()
		{
			yield return RunTest<Matrix4x4NullableField1, Matrix4x4?>(new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)));
			yield return RunTest<Matrix4x4NullableField2, Matrix4x4?>(new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)));
			yield return RunTest<Matrix4x4NullableField1, Matrix4x4?>(null);
			yield return RunTest<Matrix4x4NullableField2, Matrix4x4?>(null);
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4NullableFields()
		{
			yield return RunTest<Matrix4x4NullableFields1, Matrix4x4?>(new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)), new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)));
			yield return RunTest<Matrix4x4NullableFields2, Matrix4x4?>(new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)), new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)));
			yield return RunTest<Matrix4x4NullableFields1, Matrix4x4?>(null, new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)));
			yield return RunTest<Matrix4x4NullableFields2, Matrix4x4?>(new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)), null);
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4NullableProperty()
		{
			yield return RunTest<Matrix4x4NullableProperty1, Matrix4x4?>(new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)));
			yield return RunTest<Matrix4x4NullableProperty2, Matrix4x4?>(new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)));
			yield return RunTest<Matrix4x4NullableProperty1, Matrix4x4?>(null);
			yield return RunTest<Matrix4x4NullableProperty2, Matrix4x4?>(null);
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4NullableProperties()
		{
			yield return RunTest<Matrix4x4NullableProperties1, Matrix4x4?>(new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)), new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)));
			yield return RunTest<Matrix4x4NullableProperties2, Matrix4x4?>(new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)), new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)));
			yield return RunTest<Matrix4x4NullableProperties1, Matrix4x4?>(null, new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)));
			yield return RunTest<Matrix4x4NullableProperties2, Matrix4x4?>(new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)), null);
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4ArrayField()
		{
			yield return RunTest<Matrix4x4ArrayField1, Matrix4x4[]>(new Matrix4x4[] { new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)), new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)) });
			yield return RunTest<Matrix4x4ArrayField2, Matrix4x4[]>(new Matrix4x4[] { new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)), new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)) });
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4ArrayFields()
		{
			yield return RunTest<Matrix4x4ArrayFields1, Matrix4x4[]>(new Matrix4x4[] { new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)), new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)) }, new Matrix4x4[] { new Matrix4x4(new Vector4(0.41F, 0.06F, 0.12F, 0.18F), new Vector4(0.39F, 0.10F, 0.70F, 0.60F), new Vector4(0.85F, 0.51F, 0.59F, 0.45F), new Vector4(0.68F, 0.68F, 0.49F, 0.19F)), new Matrix4x4(new Vector4(0.40F, 0.21F, 0.21F, 0.82F), new Vector4(0.67F, 0.20F, 0.33F, 0.55F), new Vector4(0.58F, 0.52F, 0.36F, 0.04F), new Vector4(0.74F, 0.98F, 0.26F, 0.56F)) });
			yield return RunTest<Matrix4x4ArrayFields2, Matrix4x4[]>(new Matrix4x4[] { new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)), new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)) }, new Matrix4x4[] { new Matrix4x4(new Vector4(0.40F, 0.21F, 0.21F, 0.82F), new Vector4(0.67F, 0.20F, 0.33F, 0.55F), new Vector4(0.58F, 0.52F, 0.36F, 0.04F), new Vector4(0.74F, 0.98F, 0.26F, 0.56F)), new Matrix4x4(new Vector4(0.41F, 0.06F, 0.12F, 0.18F), new Vector4(0.39F, 0.10F, 0.70F, 0.60F), new Vector4(0.85F, 0.51F, 0.59F, 0.45F), new Vector4(0.68F, 0.68F, 0.49F, 0.19F)) });
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4ArrayProperty()
		{
			yield return RunTest<Matrix4x4ArrayProperty1, Matrix4x4[]>(new Matrix4x4[] { new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)), new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)) });
			yield return RunTest<Matrix4x4ArrayProperty2, Matrix4x4[]>(new Matrix4x4[] { new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)), new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)) });
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4ArrayProperties()
		{
			yield return RunTest<Matrix4x4ArrayProperties1, Matrix4x4[]>(new Matrix4x4[] { new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)), new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)) }, new Matrix4x4[] { new Matrix4x4(new Vector4(0.41F, 0.06F, 0.12F, 0.18F), new Vector4(0.39F, 0.10F, 0.70F, 0.60F), new Vector4(0.85F, 0.51F, 0.59F, 0.45F), new Vector4(0.68F, 0.68F, 0.49F, 0.19F)), new Matrix4x4(new Vector4(0.40F, 0.21F, 0.21F, 0.82F), new Vector4(0.67F, 0.20F, 0.33F, 0.55F), new Vector4(0.58F, 0.52F, 0.36F, 0.04F), new Vector4(0.74F, 0.98F, 0.26F, 0.56F)) });
			yield return RunTest<Matrix4x4ArrayProperties2, Matrix4x4[]>(new Matrix4x4[] { new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)), new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)) }, new Matrix4x4[] { new Matrix4x4(new Vector4(0.40F, 0.21F, 0.21F, 0.82F), new Vector4(0.67F, 0.20F, 0.33F, 0.55F), new Vector4(0.58F, 0.52F, 0.36F, 0.04F), new Vector4(0.74F, 0.98F, 0.26F, 0.56F)), new Matrix4x4(new Vector4(0.41F, 0.06F, 0.12F, 0.18F), new Vector4(0.39F, 0.10F, 0.70F, 0.60F), new Vector4(0.85F, 0.51F, 0.59F, 0.45F), new Vector4(0.68F, 0.68F, 0.49F, 0.19F)) });
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4ArrayNullableField()
		{
			yield return RunTest<Matrix4x4ArrayNullableField1, Matrix4x4?[]>(new Matrix4x4?[] { null, new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)) });
			yield return RunTest<Matrix4x4ArrayNullableField2, Matrix4x4?[]>(new Matrix4x4?[] { new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)), null });
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4ArrayNullableFields()
		{
			yield return RunTest<Matrix4x4ArrayNullableFields1, Matrix4x4?[]>(new Matrix4x4?[] { null, new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)) }, new Matrix4x4?[] { new Matrix4x4(new Vector4(0.41F, 0.06F, 0.12F, 0.18F), new Vector4(0.39F, 0.10F, 0.70F, 0.60F), new Vector4(0.85F, 0.51F, 0.59F, 0.45F), new Vector4(0.68F, 0.68F, 0.49F, 0.19F)), null });
			yield return RunTest<Matrix4x4ArrayNullableFields2, Matrix4x4?[]>(new Matrix4x4?[] { new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)), null }, new Matrix4x4?[] { null, new Matrix4x4(new Vector4(0.41F, 0.06F, 0.12F, 0.18F), new Vector4(0.39F, 0.10F, 0.70F, 0.60F), new Vector4(0.85F, 0.51F, 0.59F, 0.45F), new Vector4(0.68F, 0.68F, 0.49F, 0.19F)) });
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4ArrayNullableProperty()
		{
			yield return RunTest<Matrix4x4ArrayNullableProperty1, Matrix4x4?[]>(new Matrix4x4?[] { null, new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)) });
			yield return RunTest<Matrix4x4ArrayNullableProperty2, Matrix4x4?[]>(new Matrix4x4?[] { new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)), null });
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4ArrayNullableProperties()
		{
			yield return RunTest<Matrix4x4ArrayNullableProperties1, Matrix4x4?[]>(new Matrix4x4?[] { new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)), null }, new Matrix4x4?[] { null, new Matrix4x4(new Vector4(0.40F, 0.21F, 0.21F, 0.82F), new Vector4(0.67F, 0.20F, 0.33F, 0.55F), new Vector4(0.58F, 0.52F, 0.36F, 0.04F), new Vector4(0.74F, 0.98F, 0.26F, 0.56F)) });
			yield return RunTest<Matrix4x4ArrayNullableProperties2, Matrix4x4?[]>(new Matrix4x4?[] { null, new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)) }, new Matrix4x4?[] { new Matrix4x4(new Vector4(0.40F, 0.21F, 0.21F, 0.82F), new Vector4(0.67F, 0.20F, 0.33F, 0.55F), new Vector4(0.58F, 0.52F, 0.36F, 0.04F), new Vector4(0.74F, 0.98F, 0.26F, 0.56F)), null });
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4ListField()
		{
			yield return RunTest<Matrix4x4ListField1, List<Matrix4x4>>(new List<Matrix4x4> { new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)), new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)) });
			yield return RunTest<Matrix4x4ListField2, List<Matrix4x4>>(new List<Matrix4x4> { new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)), new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)) });
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4ListFields()
		{
			yield return RunTest<Matrix4x4ListFields1, List<Matrix4x4>>(new List<Matrix4x4> { new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)), new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)) }, new List<Matrix4x4> { new Matrix4x4(new Vector4(0.41F, 0.06F, 0.12F, 0.18F), new Vector4(0.39F, 0.10F, 0.70F, 0.60F), new Vector4(0.85F, 0.51F, 0.59F, 0.45F), new Vector4(0.68F, 0.68F, 0.49F, 0.19F)), new Matrix4x4(new Vector4(0.40F, 0.21F, 0.21F, 0.82F), new Vector4(0.67F, 0.20F, 0.33F, 0.55F), new Vector4(0.58F, 0.52F, 0.36F, 0.04F), new Vector4(0.74F, 0.98F, 0.26F, 0.56F)) });
			yield return RunTest<Matrix4x4ListFields2, List<Matrix4x4>>(new List<Matrix4x4> { new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)), new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)) }, new List<Matrix4x4> { new Matrix4x4(new Vector4(0.40F, 0.21F, 0.21F, 0.82F), new Vector4(0.67F, 0.20F, 0.33F, 0.55F), new Vector4(0.58F, 0.52F, 0.36F, 0.04F), new Vector4(0.74F, 0.98F, 0.26F, 0.56F)), new Matrix4x4(new Vector4(0.41F, 0.06F, 0.12F, 0.18F), new Vector4(0.39F, 0.10F, 0.70F, 0.60F), new Vector4(0.85F, 0.51F, 0.59F, 0.45F), new Vector4(0.68F, 0.68F, 0.49F, 0.19F)) });
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4ListProperty()
		{
			yield return RunTest<Matrix4x4ListProperty1, List<Matrix4x4>>(new List<Matrix4x4> { new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)), new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)) });
			yield return RunTest<Matrix4x4ListProperty2, List<Matrix4x4>>(new List<Matrix4x4> { new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)), new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)) });
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4ListProperties()
		{
			yield return RunTest<Matrix4x4ListProperties1, List<Matrix4x4>>(new List<Matrix4x4> { new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)), new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)) }, new List<Matrix4x4> { new Matrix4x4(new Vector4(0.41F, 0.06F, 0.12F, 0.18F), new Vector4(0.39F, 0.10F, 0.70F, 0.60F), new Vector4(0.85F, 0.51F, 0.59F, 0.45F), new Vector4(0.68F, 0.68F, 0.49F, 0.19F)), new Matrix4x4(new Vector4(0.40F, 0.21F, 0.21F, 0.82F), new Vector4(0.67F, 0.20F, 0.33F, 0.55F), new Vector4(0.58F, 0.52F, 0.36F, 0.04F), new Vector4(0.74F, 0.98F, 0.26F, 0.56F)) });
			yield return RunTest<Matrix4x4ListProperties2, List<Matrix4x4>>(new List<Matrix4x4> { new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)), new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)) }, new List<Matrix4x4> { new Matrix4x4(new Vector4(0.40F, 0.21F, 0.21F, 0.82F), new Vector4(0.67F, 0.20F, 0.33F, 0.55F), new Vector4(0.58F, 0.52F, 0.36F, 0.04F), new Vector4(0.74F, 0.98F, 0.26F, 0.56F)), new Matrix4x4(new Vector4(0.41F, 0.06F, 0.12F, 0.18F), new Vector4(0.39F, 0.10F, 0.70F, 0.60F), new Vector4(0.85F, 0.51F, 0.59F, 0.45F), new Vector4(0.68F, 0.68F, 0.49F, 0.19F)) });
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4ListNullableField()
		{
			yield return RunTest<Matrix4x4ListNullableField1, List<Matrix4x4?>>(new List<Matrix4x4?> { null, new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)) });
			yield return RunTest<Matrix4x4ListNullableField2, List<Matrix4x4?>>(new List<Matrix4x4?> { new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)), null });
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4ListNullableFields()
		{
			yield return RunTest<Matrix4x4ListNullableFields1, List<Matrix4x4?>>(new List<Matrix4x4?> { null, new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)) }, new List<Matrix4x4?> { new Matrix4x4(new Vector4(0.41F, 0.06F, 0.12F, 0.18F), new Vector4(0.39F, 0.10F, 0.70F, 0.60F), new Vector4(0.85F, 0.51F, 0.59F, 0.45F), new Vector4(0.68F, 0.68F, 0.49F, 0.19F)), null });
			yield return RunTest<Matrix4x4ListNullableFields2, List<Matrix4x4?>>(new List<Matrix4x4?> { new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)), null }, new List<Matrix4x4?> { null, new Matrix4x4(new Vector4(0.41F, 0.06F, 0.12F, 0.18F), new Vector4(0.39F, 0.10F, 0.70F, 0.60F), new Vector4(0.85F, 0.51F, 0.59F, 0.45F), new Vector4(0.68F, 0.68F, 0.49F, 0.19F)) });
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4ListNullableProperty()
		{
			yield return RunTest<Matrix4x4ListNullableProperty1, List<Matrix4x4?>>(new List<Matrix4x4?> { null, new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)) });
			yield return RunTest<Matrix4x4ListNullableProperty2, List<Matrix4x4?>>(new List<Matrix4x4?> { new Matrix4x4(new Vector4(0.34F, 0.74F, 0.65F, 0.78F), new Vector4(0.32F, 0.05F, 0.84F, 0.13F), new Vector4(0.07F, 0.82F, 0.73F, 0.28F), new Vector4(0.01F, 0.16F, 0.48F, 0.33F)), null });
		}

		[UnityTest]
		public IEnumerator SaveMatrix4x4ListNullableProperties()
		{
			yield return RunTest<Matrix4x4ListNullableProperties1, List<Matrix4x4?>>(new List<Matrix4x4?> { new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)), null }, new List<Matrix4x4?> { null, new Matrix4x4(new Vector4(0.40F, 0.21F, 0.21F, 0.82F), new Vector4(0.67F, 0.20F, 0.33F, 0.55F), new Vector4(0.58F, 0.52F, 0.36F, 0.04F), new Vector4(0.74F, 0.98F, 0.26F, 0.56F)) });
			yield return RunTest<Matrix4x4ListNullableProperties2, List<Matrix4x4?>>(new List<Matrix4x4?> { null, new Matrix4x4(new Vector4(0.50F, 0.95F, 0.01F, 0.89F), new Vector4(0.28F, 0.90F, 0.30F, 0.72F), new Vector4(0.64F, 0.25F, 0.66F, 0.64F), new Vector4(0.67F, 0.16F, 0.67F, 0.28F)) }, new List<Matrix4x4?> { new Matrix4x4(new Vector4(0.40F, 0.21F, 0.21F, 0.82F), new Vector4(0.67F, 0.20F, 0.33F, 0.55F), new Vector4(0.58F, 0.52F, 0.36F, 0.04F), new Vector4(0.74F, 0.98F, 0.26F, 0.56F)), null });
		}
	}
}