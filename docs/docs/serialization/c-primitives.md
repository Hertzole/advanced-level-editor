---
sidebar_position: 2
title: C# Primitives
---

The most common C# primitives can be used and serialized by the serializer. These types include
`bool`, `byte`, `sbyte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `float`, `decimal`, `double`, `string`, 
and `char`. There's also some special structs that also can be serialized. These types include `Guid`, `DateTime`, 
`TimeSpan`, and `Uri`.

It also supports all these types as an array (for example `int[]`), as lists (for example `List<int>`), and as nullable 
(for example `int?`).

:::tip Fully Tested

All the types above are covered by serialization tests! They are completely safe to use without any surprise issues.

:::