using UnityEngine;

namespace Hertzole.ALE.Tests
{
	public partial class BaseTest
	{
		protected static readonly Bounds[] boundsValues =
		{
			new Bounds(),
			new Bounds(Vector3.zero, Vector3.one)
		};
		protected static readonly BoundsInt[] boundsIntValues =
		{
			new BoundsInt(),
			new BoundsInt(Vector3Int.zero, Vector3Int.one)
		};
		protected static readonly Color32[] color32Values =
		{
			new Color32(),
			new Color32(255, 255, 255, 255),
			new Color32(128, 128, 128, 128)
		};
		protected static readonly Color[] colorValues =
		{
			new Color(),
			new Color(1, 1, 1, 1),
			new Color(0.5f, 0.5f, 0.5f, 0.5f)
		};
		protected static readonly GradientAlphaKey[] gradientAlphaKeyValues =
		{
			new GradientAlphaKey(),
			new GradientAlphaKey(1, 1),
			new GradientAlphaKey(0.5f, 0.5f)
		};
		protected static readonly GradientColorKey[] gradientColorKeyValues =
		{
			new GradientColorKey(),
			new GradientColorKey(Color.white, 1),
			new GradientColorKey(Color.black, 0.5f)
		};
		protected static readonly Keyframe[] keyframeValues =
		{
			new Keyframe(),
			new Keyframe(1, 1, 1, 1),
			new Keyframe(0.5f, 0.5f, 0.5f, 0.5f)
		};
		protected static readonly LayerMask[] layerMaskValues =
		{
			new LayerMask(),
			LayerMask.NameToLayer("TransparentFX"),
			LayerMask.GetMask("TransparentFX", "Default")
		};
		protected static readonly Matrix4x4[] matrix4x4Values =
		{
			Matrix4x4.identity,
			Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Vector3.one),
			Matrix4x4.TRS(Vector3.one, Quaternion.Euler(45, 45, 45), Vector3.one),
			Matrix4x4.TRS(Vector3.one * 2, Quaternion.Euler(90, 90, 90), Vector3.one),
			Matrix4x4.TRS(Vector3.one * 3, Quaternion.Euler(180, 180, 180), Vector3.one),
			Matrix4x4.TRS(Vector3.one * 4, Quaternion.Euler(270, 270, 270), Vector3.one)
		};
		protected static readonly Quaternion[] quaternionValues =
		{
			Quaternion.identity,
			Quaternion.Euler(45, 45, 45),
			Quaternion.Euler(90, 90, 90),
			Quaternion.Euler(180, 180, 180),
			Quaternion.Euler(270, 270, 270)
		};
		protected static readonly RangeInt[] rangeIntValues =
		{
			new RangeInt(),
			new RangeInt(1, 1)
		};
		protected static readonly Rect[] rectValues =
		{
			new Rect(),
			new Rect(0, 0, 1, 1),
			new Rect(0.5f, 0.5f, 0.5f, 0.5f),
			new Rect(0.25f, 0.25f, 0.25f, 0.25f),
			new Rect(0.75f, 0.75f, 0.75f, 0.75f)
		};
		protected static readonly RectInt[] rectIntValues =
		{
			new RectInt(),
			new RectInt(0, 0, 1, 1),
			new RectInt(0, 0, 2, 2),
			new RectInt(0, 0, 3, 3),
			new RectInt(0, 0, 4, 4)
		};
		protected static readonly Vector2[] vector2Values =
		{
			Vector2.zero,
			Vector2.one,
			new Vector2(0.5f, 0.5f),
			new Vector2(0.25f, 0.25f),
			new Vector2(0.75f, 0.75f)
		};
		protected static readonly Vector2Int[] vector2IntValues =
		{
			Vector2Int.zero,
			Vector2Int.one,
			new Vector2Int(0, 0),
			new Vector2Int(1, 1),
			new Vector2Int(2, 2),
			new Vector2Int(3, 3)
		};
		protected static readonly Vector3[] vector3Values =
		{
			Vector3.zero,
			Vector3.one,
			new Vector3(0.5f, 0.5f, 0.5f),
			new Vector3(0.25f, 0.25f, 0.25f),
			new Vector3(0.75f, 0.75f, 0.75f)
		};
		protected static readonly Vector3Int[] vector3IntValues =
		{
			Vector3Int.zero,
			Vector3Int.one,
			new Vector3Int(0, 0, 0),
			new Vector3Int(1, 1, 1),
			new Vector3Int(2, 2, 2),
			new Vector3Int(3, 3, 3)
		};
		protected static readonly Vector4[] vector4Values =
		{
			Vector4.zero,
			Vector4.one,
			new Vector4(0.5f, 0.5f, 0.5f, 0.5f),
			new Vector4(0.25f, 0.25f, 0.25f, 0.25f),
			new Vector4(0.75f, 0.75f, 0.75f, 0.75f)
		};
		protected static readonly WrapMode[] wrapModeValues =
		{
			WrapMode.Default,
			WrapMode.Clamp,
			WrapMode.Loop,
			WrapMode.Once,
			WrapMode.ClampForever,
			WrapMode.PingPong
		};

		protected static readonly Bounds?[] boundsValuesNullable =
		{
			null,
			new Bounds(),
			new Bounds(Vector3.zero, Vector3.one)
		};
		protected static readonly BoundsInt?[] boundsIntValuesNullable =
		{
			null,
			new BoundsInt(),
			new BoundsInt(Vector3Int.zero, Vector3Int.one)
		};
		protected static readonly Color32?[] color32ValuesNullable =
		{
			null,
			new Color32(),
			new Color32(255, 255, 255, 255),
			new Color32(128, 128, 128, 128)
		};
		protected static readonly Color?[] colorValuesNullable =
		{
			null,
			new Color(),
			new Color(1, 1, 1, 1),
			new Color(0.5f, 0.5f, 0.5f, 0.5f)
		};
		protected static readonly GradientAlphaKey?[] gradientAlphaKeyValuesNullable =
		{
			null,
			new GradientAlphaKey(),
			new GradientAlphaKey(1, 1),
			new GradientAlphaKey(0.5f, 0.5f)
		};
		protected static readonly GradientColorKey?[] gradientColorKeyValuesNullable =
		{
			null,
			new GradientColorKey(),
			new GradientColorKey(Color.white, 1),
			new GradientColorKey(Color.black, 0.5f)
		};
		protected static readonly Keyframe?[] keyframeValuesNullable =
		{
			null,
			new Keyframe(),
			new Keyframe(1, 1, 1, 1),
			new Keyframe(0.5f, 0.5f, 0.5f, 0.5f)
		};
		
		protected static readonly LayerMask?[] layerMaskValuesNullable =
		{
			null,
			new LayerMask(),
			LayerMask.NameToLayer("TransparentFX"),
			LayerMask.GetMask("TransparentFX", "Default")
		};
		protected static readonly Matrix4x4?[] matrix4x4ValuesNullable =
		{
			null,
			Matrix4x4.identity,
			Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Vector3.one),
			Matrix4x4.TRS(Vector3.one, Quaternion.Euler(45, 45, 45), Vector3.one),
			Matrix4x4.TRS(Vector3.one * 2, Quaternion.Euler(90, 90, 90), Vector3.one),
			Matrix4x4.TRS(Vector3.one * 3, Quaternion.Euler(180, 180, 180), Vector3.one),
			Matrix4x4.TRS(Vector3.one * 4, Quaternion.Euler(270, 270, 270), Vector3.one)
		};
		protected static readonly Quaternion?[] quaternionValuesNullable =
		{
			null,
			Quaternion.identity,
			Quaternion.Euler(45, 45, 45),
			Quaternion.Euler(90, 90, 90),
			Quaternion.Euler(180, 180, 180),
			Quaternion.Euler(270, 270, 270)
		};
		protected static readonly RangeInt?[] rangeIntValuesNullable =
		{
			null,
			new RangeInt(),
			new RangeInt(1, 1)
		};
		protected static readonly Rect?[] rectValuesNullable =
		{
			null,
			new Rect(),
			new Rect(0, 0, 1, 1),
			new Rect(0.5f, 0.5f, 0.5f, 0.5f),
			new Rect(0.25f, 0.25f, 0.25f, 0.25f),
			new Rect(0.75f, 0.75f, 0.75f, 0.75f)
		};
		protected static readonly RectInt?[] rectIntValuesNullable =
		{
			null,
			new RectInt(),
			new RectInt(0, 0, 1, 1),
			new RectInt(0, 0, 2, 2),
			new RectInt(0, 0, 3, 3),
			new RectInt(0, 0, 4, 4)
		};
		protected static readonly Vector2?[] vector2ValuesNullable =
		{
			null,
			Vector2.zero,
			Vector2.one,
			new Vector2(0.5f, 0.5f),
			new Vector2(0.25f, 0.25f),
			new Vector2(0.75f, 0.75f)
		};
		protected static readonly Vector2Int?[] vector2IntValuesNullable =
		{
			null,
			Vector2Int.zero,
			Vector2Int.one,
			new Vector2Int(0, 0),
			new Vector2Int(1, 1),
			new Vector2Int(2, 2),
			new Vector2Int(3, 3)
		};
		protected static readonly Vector3?[] vector3ValuesNullable =
		{
			null,
			Vector3.zero,
			Vector3.one,
			new Vector3(0.5f, 0.5f, 0.5f),
			new Vector3(0.25f, 0.25f, 0.25f),
			new Vector3(0.75f, 0.75f, 0.75f)
		};
		protected static readonly Vector3Int?[] vector3IntValuesNullable =
		{
			null,
			Vector3Int.zero,
			Vector3Int.one,
			new Vector3Int(0, 0, 0),
			new Vector3Int(1, 1, 1),
			new Vector3Int(2, 2, 2),
			new Vector3Int(3, 3, 3)
		};
		protected static readonly Vector4?[] vector4ValuesNullable =
		{
			null,
			Vector4.zero,
			Vector4.one,
			new Vector4(0.5f, 0.5f, 0.5f, 0.5f),
			new Vector4(0.25f, 0.25f, 0.25f, 0.25f),
			new Vector4(0.75f, 0.75f, 0.75f, 0.75f)
		};
		protected static readonly WrapMode?[] wrapModeValuesNullable =
		{
			null,
			WrapMode.Default,
			WrapMode.Clamp,
			WrapMode.Loop,
			WrapMode.Once,
			WrapMode.ClampForever,
			WrapMode.PingPong
		};
	}
}