using NUnit.Framework;
using UnityEngine;

namespace Hertzole.ALE.Tests
{
	public partial class SerializerTest
	{
		// Bounds
		[Test]
		public void SerializeDeserialize_BoundsNullable([ValueSource(nameof(boundsValues))] Bounds? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// BoundsInt
		[Test]
		public void SerializeDeserialize_BoundsIntNullable([ValueSource(nameof(boundsIntValues))] BoundsInt? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Color32
		[Test]
		public void SerializeDeserialize_Color32Nullable([ValueSource(nameof(color32Values))] Color32? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Color
		[Test]
		public void SerializeDeserialize_ColorNullable([ValueSource(nameof(colorValues))] Color? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// GradientAlphaKey
		[Test]
		public void SerializeDeserialize_GradientAlphaKeyNullable([ValueSource(nameof(gradientAlphaKeyValues))] GradientAlphaKey? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// GradientColorKey
		[Test]
		public void SerializeDeserialize_GradientColorKeyNullable([ValueSource(nameof(gradientColorKeyValues))] GradientColorKey? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Keyframe
		[Test]
		public void SerializeDeserialize_KeyframeNullable([ValueSource(nameof(keyframeValues))] Keyframe? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// LayerMask
		[Test]
		public void SerializeDeserialize_LayerMaskNullable([ValueSource(nameof(layerMaskValues))] LayerMask? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Matrix4x4
		[Test]
		public void SerializeDeserialize_Matrix4x4Nullable([ValueSource(nameof(matrix4x4Values))] Matrix4x4? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Quaternion
		[Test]
		public void SerializeDeserialize_QuaternionNullable([ValueSource(nameof(quaternionValues))] Quaternion? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// RangeInt
		[Test]
		public void SerializeDeserialize_RangeIntNullable([ValueSource(nameof(rangeIntValues))] RangeInt? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Rect
		[Test]
		public void SerializeDeserialize_RectNullable([ValueSource(nameof(rectValues))] Rect? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// RectInt
		[Test]
		public void SerializeDeserialize_RectIntNullable([ValueSource(nameof(rectIntValues))] RectInt? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Vector2
		[Test]
		public void SerializeDeserialize_Vector2Nullable([ValueSource(nameof(vector2Values))] Vector2? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Vector2Int
		[Test]
		public void SerializeDeserialize_Vector2IntNullable([ValueSource(nameof(vector2IntValues))] Vector2Int? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Vector3
		[Test]
		public void SerializeDeserialize_Vector3Nullable([ValueSource(nameof(vector3Values))] Vector3? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Vector3Int
		[Test]
		public void SerializeDeserialize_Vector3IntNullable([ValueSource(nameof(vector3IntValues))] Vector3Int? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Vector4
		[Test]
		public void SerializeDeserialize_Vector4Nullable([ValueSource(nameof(vector4Values))] Vector4? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// WrapMode
		[Test]
		public void SerializeDeserialize_WrapModeNullable([ValueSource(nameof(wrapModeValues))] WrapMode? value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
	}
}