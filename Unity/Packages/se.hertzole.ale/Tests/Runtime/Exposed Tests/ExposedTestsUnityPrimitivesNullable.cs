using NUnit.Framework;
using UnityEngine;

namespace Hertzole.ALE.Tests
{
	public partial class ExposedTests
	{
		// Bounds
		[Test]
		public void SetGet_BoundsNullable([ValueSource(nameof(boundsValuesNullable))] Bounds?value)
		{
			TestSetGetValue<BoundsExposedNullable, Bounds?>(0, value);
		}

		// BoundsInt
		[Test]
		public void SetGet_BoundsIntNullable([ValueSource(nameof(boundsIntValuesNullable))] BoundsInt?value)
		{
			TestSetGetValue<BoundsIntExposedNullable, BoundsInt?>(0, value);
		}

		// Color32
		[Test]
		public void SetGet_Color32Nullable([ValueSource(nameof(color32ValuesNullable))] Color32?value)
		{
			TestSetGetValue<Color32ExposedNullable, Color32?>(0, value);
		}

		// Color
		[Test]
		public void SetGet_ColorNullable([ValueSource(nameof(colorValuesNullable))] Color?value)
		{
			TestSetGetValue<ColorExposedNullable, Color?>(0, value);
		}

		// GradientAlphaKey
		[Test]
		public void SetGet_GradientAlphaKeyNullable([ValueSource(nameof(gradientAlphaKeyValuesNullable))] GradientAlphaKey?value)
		{
			TestSetGetValue<GradientAlphaKeyExposedNullable, GradientAlphaKey?>(0, value);
		}

		// GradientColorKey
		[Test]
		public void SetGet_GradientColorKeyNullable([ValueSource(nameof(gradientColorKeyValuesNullable))] GradientColorKey?value)
		{
			TestSetGetValue<GradientColorKeyExposedNullable, GradientColorKey?>(0, value);
		}

		// Keyframe
		[Test]
		public void SetGet_KeyframeNullable([ValueSource(nameof(keyframeValuesNullable))] Keyframe?value)
		{
			TestSetGetValue<KeyframeExposedNullable, Keyframe?>(0, value);
		}

		// LayerMask
		[Test]
		public void SetGet_LayerMaskNullable([ValueSource(nameof(layerMaskValuesNullable))] LayerMask?value)
		{
			TestSetGetValue<LayerMaskExposedNullable, LayerMask?>(0, value);
		}

		// Matrix4x4
		[Test]
		public void SetGet_Matrix4x4Nullable([ValueSource(nameof(matrix4x4ValuesNullable))] Matrix4x4?value)
		{
			TestSetGetValue<Matrix4x4ExposedNullable, Matrix4x4?>(0, value);
		}

		// Quaternion
		[Test]
		public void SetGet_QuaternionNullable([ValueSource(nameof(quaternionValuesNullable))] Quaternion?value)
		{
			TestSetGetValue<QuaternionExposedNullable, Quaternion?>(0, value);
		}

		// RangeInt
		[Test]
		public void SetGet_RangeIntNullable([ValueSource(nameof(rangeIntValuesNullable))] RangeInt?value)
		{
			TestSetGetValue<RangeIntExposedNullable, RangeInt?>(0, value);
		}

		// Rect
		[Test]
		public void SetGet_RectNullable([ValueSource(nameof(rectValuesNullable))] Rect?value)
		{
			TestSetGetValue<RectExposedNullable, Rect?>(0, value);
		}

		// RectInt
		[Test]
		public void SetGet_RectIntNullable([ValueSource(nameof(rectIntValuesNullable))] RectInt?value)
		{
			TestSetGetValue<RectIntExposedNullable, RectInt?>(0, value);
		}

		// Vector2
		[Test]
		public void SetGet_Vector2Nullable([ValueSource(nameof(vector2ValuesNullable))] Vector2?value)
		{
			TestSetGetValue<Vector2ExposedNullable, Vector2?>(0, value);
		}

		// Vector2Int
		[Test]
		public void SetGet_Vector2IntNullable([ValueSource(nameof(vector2IntValuesNullable))] Vector2Int?value)
		{
			TestSetGetValue<Vector2IntExposedNullable, Vector2Int?>(0, value);
		}

		// Vector3
		[Test]
		public void SetGet_Vector3Nullable([ValueSource(nameof(vector3ValuesNullable))] Vector3?value)
		{
			TestSetGetValue<Vector3ExposedNullable, Vector3?>(0, value);
		}

		// Vector3Int
		[Test]
		public void SetGet_Vector3IntNullable([ValueSource(nameof(vector3IntValuesNullable))] Vector3Int?value)
		{
			TestSetGetValue<Vector3IntExposedNullable, Vector3Int?>(0, value);
		}

		// Vector4
		[Test]
		public void SetGet_Vector4Nullable([ValueSource(nameof(vector4ValuesNullable))] Vector4?value)
		{
			TestSetGetValue<Vector4ExposedNullable, Vector4?>(0, value);
		}

		// WrapMode
		[Test]
		public void SetGet_WrapModeNullable([ValueSource(nameof(wrapModeValuesNullable))] WrapMode?value)
		{
			TestSetGetValue<WrapModeExposedNullable, WrapMode?>(0, value);
		}
	}
}