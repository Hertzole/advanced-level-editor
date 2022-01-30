---
sidebar_position: 3
---

# Unity Primitives

The most common Unity primitives can be used and serialized by the serializer. These types include
`Bounds`, `BoundsInt`, `Color32`, `Color`, `GradientAlphaKey`, `GradientColorKey`, `Keyframe`, `LayerMask`, `Matrix4x4`,
`Quaternion`, `RangeInt`, `Rect`, `RectInt`, `Vector2`, `Vector2Int`, `Vector3`, `Vector3Int`, `Vector4`, and `WrapMode`.

You can also serialize references to other scene objects that has been spawned by the level editor. You just make a reference
like normal using GameObject, Transform, or your own scripts.

It also supports all these types as an array (for example `Color[]`), as lists (for example `List<Color>`), and as nullable 
(for example `Color?`).

:::tip Fully Tested

All the types above are covered by serialization tests! They are completely safe to use without any surprise issues.

:::