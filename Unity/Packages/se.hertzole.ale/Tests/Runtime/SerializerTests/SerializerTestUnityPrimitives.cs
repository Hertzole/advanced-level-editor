using NUnit.Framework;
using UnityEngine;

namespace Hertzole.ALE.Tests
{
	public partial class SerializerTest
	{
		// Bounds
		[Test]
		public void SerializeDeserialize_Bounds([ValueSource(nameof(boundsValues))] Bounds value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// BoundsInt
		[Test]
		public void SerializeDeserialize_BoundsInt([ValueSource(nameof(boundsIntValues))] BoundsInt value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Color32
		[Test]
		public void SerializeDeserialize_Color32([ValueSource(nameof(color32Values))] Color32 value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Color
		[Test]
		public void SerializeDeserialize_Color([ValueSource(nameof(colorValues))] Color value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// GradientAlphaKey
		[Test]
		public void SerializeDeserialize_GradientAlphaKey([ValueSource(nameof(gradientAlphaKeyValues))] GradientAlphaKey value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// GradientColorKey
		[Test]
		public void SerializeDeserialize_GradientColorKey([ValueSource(nameof(gradientColorKeyValues))] GradientColorKey value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Keyframe
		[Test]
		public void SerializeDeserialize_Keyframe([ValueSource(nameof(keyframeValues))] Keyframe value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// LayerMask
		[Test]
		public void SerializeDeserialize_LayerMask([ValueSource(nameof(layerMaskValues))] LayerMask value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Matrix4x4
		[Test]
		public void SerializeDeserialize_Matrix4x4([ValueSource(nameof(matrix4x4Values))] Matrix4x4 value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Quaternion
		[Test]
		public void SerializeDeserialize_Quaternion([ValueSource(nameof(quaternionValues))] Quaternion value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// RangeInt
		[Test]
		public void SerializeDeserialize_RangeInt([ValueSource(nameof(rangeIntValues))] RangeInt value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Rect
		[Test]
		public void SerializeDeserialize_Rect([ValueSource(nameof(rectValues))] Rect value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// RectInt
		[Test]
		public void SerializeDeserialize_RectInt([ValueSource(nameof(rectIntValues))] RectInt value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Vector2
		[Test]
		public void SerializeDeserialize_Vector2([ValueSource(nameof(vector2Values))] Vector2 value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Vector2Int
		[Test]
		public void SerializeDeserialize_Vector2Int([ValueSource(nameof(vector2IntValues))] Vector2Int value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Vector3
		[Test]
		public void SerializeDeserialize_Vector3([ValueSource(nameof(vector3Values))] Vector3 value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Vector3Int
		[Test]
		public void SerializeDeserialize_Vector3Int([ValueSource(nameof(vector3IntValues))] Vector3Int value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// Vector4
		[Test]
		public void SerializeDeserialize_Vector4([ValueSource(nameof(vector4Values))] Vector4 value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}

		// WrapMode
		[Test]
		public void SerializeDeserialize_WrapMode([ValueSource(nameof(wrapModeValues))] WrapMode value, [ValueSource(nameof(boolValues))] bool compressed)
		{
			SerializeTest(value, true);
		}
	}
}