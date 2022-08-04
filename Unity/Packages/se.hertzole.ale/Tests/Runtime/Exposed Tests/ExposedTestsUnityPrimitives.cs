using NUnit.Framework;
using UnityEngine;

namespace Hertzole.ALE.Tests
{
	public partial class ExposedTests
	{
		// Bounds
		[Test]
		public void SetGet_Bounds([ValueSource(nameof(boundsValues))] Bounds value)
		{
			TestSetGetValue<BoundsExposed, Bounds>(0, value);
		}

		// BoundsInt
		[Test]
		public void SetGet_BoundsInt([ValueSource(nameof(boundsIntValues))] BoundsInt value)
		{
			TestSetGetValue<BoundsIntExposed, BoundsInt>(0, value);
		}

		// Color32
		[Test]
		public void SetGet_Color32([ValueSource(nameof(color32Values))] Color32 value)
		{
			TestSetGetValue<Color32Exposed, Color32>(0, value);
		}

		// Color
		[Test]
		public void SetGet_Color([ValueSource(nameof(colorValues))] Color value)
		{
			TestSetGetValue<ColorExposed, Color>(0, value);
		}

		// GradientAlphaKey
		[Test]
		public void SetGet_GradientAlphaKey([ValueSource(nameof(gradientAlphaKeyValues))] GradientAlphaKey value)
		{
			TestSetGetValue<GradientAlphaKeyExposed, GradientAlphaKey>(0, value);
		}

		// GradientColorKey
		[Test]
		public void SetGet_GradientColorKey([ValueSource(nameof(gradientColorKeyValues))] GradientColorKey value)
		{
			TestSetGetValue<GradientColorKeyExposed, GradientColorKey>(0, value);
		}

		// Keyframe
		[Test]
		public void SetGet_Keyframe([ValueSource(nameof(keyframeValues))] Keyframe value)
		{
			TestSetGetValue<KeyframeExposed, Keyframe>(0, value);
		}

		// LayerMask
		[Test]
		public void SetGet_LayerMask([ValueSource(nameof(layerMaskValues))] LayerMask value)
		{
			TestSetGetValue<LayerMaskExposed, LayerMask>(0, value);
		}

		// Matrix4x4
		[Test]
		public void SetGet_Matrix4x4([ValueSource(nameof(matrix4x4Values))] Matrix4x4 value)
		{
			TestSetGetValue<Matrix4x4Exposed, Matrix4x4>(0, value);
		}

		// Quaternion
		[Test]
		public void SetGet_Quaternion([ValueSource(nameof(quaternionValues))] Quaternion value)
		{
			TestSetGetValue<QuaternionExposed, Quaternion>(0, value);
		}

		// RangeInt
		[Test]
		public void SetGet_RangeInt([ValueSource(nameof(rangeIntValues))] RangeInt value)
		{
			TestSetGetValue<RangeIntExposed, RangeInt>(0, value);
		}

		// Rect
		[Test]
		public void SetGet_Rect([ValueSource(nameof(rectValues))] Rect value)
		{
			TestSetGetValue<RectExposed, Rect>(0, value);
		}

		// RectInt
		[Test]
		public void SetGet_RectInt([ValueSource(nameof(rectIntValues))] RectInt value)
		{
			TestSetGetValue<RectIntExposed, RectInt>(0, value);
		}

		// Vector2
		[Test]
		public void SetGet_Vector2([ValueSource(nameof(vector2Values))] Vector2 value)
		{
			TestSetGetValue<Vector2Exposed, Vector2>(0, value);
		}

		// Vector2Int
		[Test]
		public void SetGet_Vector2Int([ValueSource(nameof(vector2IntValues))] Vector2Int value)
		{
			TestSetGetValue<Vector2IntExposed, Vector2Int>(0, value);
		}

		// Vector3
		[Test]
		public void SetGet_Vector3([ValueSource(nameof(vector3Values))] Vector3 value)
		{
			TestSetGetValue<Vector3Exposed, Vector3>(0, value);
		}

		// Vector3Int
		[Test]
		public void SetGet_Vector3Int([ValueSource(nameof(vector3IntValues))] Vector3Int value)
		{
			TestSetGetValue<Vector3IntExposed, Vector3Int>(0, value);
		}

		// Vector4
		[Test]
		public void SetGet_Vector4([ValueSource(nameof(vector4Values))] Vector4 value)
		{
			TestSetGetValue<Vector4Exposed, Vector4>(0, value);
		}

		// WrapMode
		[Test]
		public void SetGet_WrapMode([ValueSource(nameof(wrapModeValues))] WrapMode value)
		{
			TestSetGetValue<WrapModeExposed, WrapMode>(0, value);
		}
	}
}