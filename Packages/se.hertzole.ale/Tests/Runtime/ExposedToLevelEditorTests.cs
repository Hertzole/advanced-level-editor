using System;
using System.Collections;
using System.Collections.Generic;
using Hertzole.ALE.Tests.TestScripts;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

// ReSharper disable SuspiciousTypeConversion.Global
// ReSharper disable UnusedMember.Local
#pragma warning disable 169

namespace Hertzole.ALE.Tests
{
	public class ExposedToLevelEditorTests : LevelEditorTest
	{
		[UnityTest]
		public IEnumerator SetValueByte()
		{
			yield return SetValueTest<byte, ByteValue>(10, 20);
		}

		[UnityTest]
		public IEnumerator SetValueSByte()
		{
			yield return SetValueTest<sbyte, SByteValue>(-10, 20);
		}

		[UnityTest]
		public IEnumerator SetValueShort()
		{
			yield return SetValueTest<short, ShortValue>(-100, 200);
		}

		[UnityTest]
		public IEnumerator SetValueUShort()
		{
			yield return SetValueTest<ushort, UShortValue>(1000, 20000);
		}

		[UnityTest]
		public IEnumerator SetValueInt()
		{
			yield return SetValueTest<int, IntValue>(-1000000, 2000000);
		}

		[UnityTest]
		public IEnumerator SetValueUInt()
		{
			yield return SetValueTest<uint, UIntValue>(1000000, 2000000);
		}

		[UnityTest]
		public IEnumerator SetValueLong()
		{
			yield return SetValueTest<long, LongValue>(-1000000000, 2000000000);
		}

		[UnityTest]
		public IEnumerator SetValueULong()
		{
			yield return SetValueTest<ulong, ULongValue>(10000000000, 20000000000);
		}

		[UnityTest]
		public IEnumerator SetValueFloat()
		{
			yield return SetValueTest<float, FloatValue>(-4.20f, 6.9f);
		}

		[UnityTest]
		public IEnumerator SetValueDouble()
		{
			yield return SetValueTest<double, DoubleValue>(-4.20d, 6.9d);
		}

		[UnityTest]
		public IEnumerator SetValueDecimal()
		{
			yield return SetValueTest<decimal, DecimalValue>((decimal)-4.2d, (decimal)6.9);
		}

		[UnityTest]
		public IEnumerator SetValueString()
		{
			yield return SetValueTest<string, StringValue>("Hello, ", "World!");
		}

		[UnityTest]
		public IEnumerator SetValueChar()
		{
			yield return SetValueTest<char, CharValue>('H', 'i');
		}

		[UnityTest]
		public IEnumerator SetValueVector()
		{
			yield return SetValueTest<Vector3, Vector3Value>(new Vector3(1.1f, 2.2f, 3.3f), new Vector3(4.4f, 5.5f, 6.6f));
		}

		[UnityTest]
		public IEnumerator SetValueVectorInt()
		{
			yield return SetValueTest<Vector2Int, Vector2IntValue>(new Vector2Int(1, 2), new Vector2Int(3, 4));
		}

		[UnityTest]
		public IEnumerator SetValueColor()
		{
			yield return SetValueTest<Color, ColorValue>(Color.red, Color.green);
		}

		[UnityTest]
		public IEnumerator SetValueColor32()
		{
			yield return SetValueTest<Color32, Color32Value>(new Color32(255, 0, 128, 50), new Color32(128, 128, 0, 128));
		}

		[UnityTest]
		public IEnumerator SetValueGameObject()
		{
			ILevelEditorObject newSphere = objectManager.CreateObject("sphere");
			ILevelEditorObject newCapsule = objectManager.CreateObject("capsule");

			ComponentDataWrapper sphereRef = new ComponentDataWrapper(newSphere.MyGameObject);
			ComponentDataWrapper capsuleRef = new ComponentDataWrapper(newCapsule.MyGameObject);
			yield return SetValueTest<ComponentDataWrapper, GameObjectReference>(sphereRef, capsuleRef);
		}

		[UnityTest]
		public IEnumerator SetValueGameObjectArray()
		{
			ILevelEditorObject newSphere = objectManager.CreateObject("sphere");
			ILevelEditorObject newCapsule = objectManager.CreateObject("capsule");

			ComponentDataWrapper array1 = new ComponentDataWrapper(new[] { newSphere.MyGameObject, newCapsule.MyGameObject });
			ComponentDataWrapper array2 = new ComponentDataWrapper(new[] { newCapsule.MyGameObject, newSphere.MyGameObject });
			yield return SetValueTest<ComponentDataWrapper, GameObjectArray>(array1, array2);
		}

		[UnityTest]
		public IEnumerator SetValueGameObjectList()
		{
			ILevelEditorObject newSphere = objectManager.CreateObject("sphere");
			ILevelEditorObject newCapsule = objectManager.CreateObject("capsule");

			ComponentDataWrapper array1 = new ComponentDataWrapper(new[] { newSphere.MyGameObject, newCapsule.MyGameObject });
			ComponentDataWrapper array2 = new ComponentDataWrapper(new[] { newCapsule.MyGameObject, newSphere.MyGameObject });
			yield return SetValueTest<ComponentDataWrapper, GameObjectList>(array1, array2);
		}

		[UnityTest]
		public IEnumerator SetValueTransform()
		{
			ILevelEditorObject newSphere = objectManager.CreateObject("sphere");
			ILevelEditorObject newCapsule = objectManager.CreateObject("capsule");

			ComponentDataWrapper sphereRef = new ComponentDataWrapper(newSphere.MyGameObject.transform);
			ComponentDataWrapper capsuleRef = new ComponentDataWrapper(newCapsule.MyGameObject.transform);
			yield return SetValueTest<ComponentDataWrapper, TransformReference>(sphereRef, capsuleRef);
		}

		[UnityTest]
		public IEnumerator SetValueTransformArray()
		{
			ILevelEditorObject newSphere = objectManager.CreateObject("sphere");
			ILevelEditorObject newCapsule = objectManager.CreateObject("capsule");

			ComponentDataWrapper array1 = new ComponentDataWrapper(new Component[] { newSphere.MyGameObject.transform, newCapsule.MyGameObject.transform });
			ComponentDataWrapper array2 = new ComponentDataWrapper(new Component[] { newCapsule.MyGameObject.transform, newSphere.MyGameObject.transform });
			yield return SetValueTest<ComponentDataWrapper, TransformArray>(array1, array2);
		}

		[UnityTest]
		public IEnumerator SetValueTransformList()
		{
			ILevelEditorObject newSphere = objectManager.CreateObject("sphere");
			ILevelEditorObject newCapsule = objectManager.CreateObject("capsule");

			ComponentDataWrapper array1 = new ComponentDataWrapper(new Component[] { newSphere.MyGameObject.transform, newCapsule.MyGameObject.transform });
			ComponentDataWrapper array2 = new ComponentDataWrapper(new Component[] { newCapsule.MyGameObject.transform, newSphere.MyGameObject.transform });
			yield return SetValueTest<ComponentDataWrapper, TransformList>(array1, array2);
		}

		[UnityTest]
		public IEnumerator SetValueScript()
		{
			sphere.AddComponent<TempTestScript>();
			capsule.AddComponent<TempTestScript>();
			
			ILevelEditorObject newSphere = objectManager.CreateObject("sphere");
			ILevelEditorObject newCapsule = objectManager.CreateObject("capsule");

			ComponentDataWrapper sphereRef = new ComponentDataWrapper(newSphere.MyGameObject.GetComponent<TempTestScript>());
			ComponentDataWrapper capsuleRef = new ComponentDataWrapper(newCapsule.MyGameObject.GetComponent<TempTestScript>());
			yield return SetValueTest<ComponentDataWrapper, ScriptReference>(sphereRef, capsuleRef);
		}

		[UnityTest]
		public IEnumerator SetValueScriptArray()
		{
			sphere.AddComponent<TempTestScript>();
			capsule.AddComponent<TempTestScript>();
			
			ILevelEditorObject newSphere = objectManager.CreateObject("sphere");
			ILevelEditorObject newCapsule = objectManager.CreateObject("capsule");

			ComponentDataWrapper array1 = new ComponentDataWrapper(new TempTestScript[] { newSphere.MyGameObject.GetComponent<TempTestScript>(), newCapsule.MyGameObject.GetComponent<TempTestScript>() });
			ComponentDataWrapper array2 = new ComponentDataWrapper(new TempTestScript[] { newCapsule.MyGameObject.GetComponent<TempTestScript>(), newSphere.MyGameObject.GetComponent<TempTestScript>() });
			yield return SetValueTest<ComponentDataWrapper, ScriptArray>(array1, array2);
		}

		[UnityTest]
		public IEnumerator SetValueScriptList()
		{
			sphere.AddComponent<TempTestScript>();
			capsule.AddComponent<TempTestScript>();
			
			ILevelEditorObject newSphere = objectManager.CreateObject("sphere");
			ILevelEditorObject newCapsule = objectManager.CreateObject("capsule");

			ComponentDataWrapper array1 = new ComponentDataWrapper(new TempTestScript[] { newSphere.MyGameObject.GetComponent<TempTestScript>(), newCapsule.MyGameObject.GetComponent<TempTestScript>() });
			ComponentDataWrapper array2 = new ComponentDataWrapper(new TempTestScript[] { newCapsule.MyGameObject.GetComponent<TempTestScript>(), newSphere.MyGameObject.GetComponent<TempTestScript>() });
			yield return SetValueTest<ComponentDataWrapper, ScriptList>(array1, array2);
		}

		[UnityTest]
		public IEnumerator SetValueStruct()
		{
			yield return SetValueTest<Struct, StructValue>(new Struct(42, 24), new Struct(128, 256));
		}

		[UnityTest]
		public IEnumerator SetValueStructEquality()
		{
			yield return SetValueTest<StructEquality, StructEqualityValue>(new StructEquality(42, 24), new StructEquality(128, 256));
		}

		[UnityTest]
		public IEnumerator SetValueStructEquals()
		{
			yield return SetValueTest<StructEquals, StructEqualsValue>(new StructEquals(42, 24), new StructEquals(128, 256));
		}

		[UnityTest]
		public IEnumerator SetValueStructEquatable()
		{
			yield return SetValueTest<StructEquatable, StructEquatableValue>(new StructEquatable(42, 24), new StructEquatable(128, 256));
		}

		//TODO: Use when classes are supported.
		// [UnityTest]
		// public IEnumerator SetValueClass()
		// {
		// 	yield return SetValueTest<Class, ClassValue>(new Class(42, 24), new Class(128, 256));
		// }
		//
		// [UnityTest]
		// public IEnumerator SetValueClassEquality()
		// {
		// 	yield return SetValueTest<ClassEquality, ClassEqualityValue>(new ClassEquality(42, 24), new ClassEquality(128, 256));
		// }
		//
		// [UnityTest]
		// public IEnumerator SetValueClassEquals()
		// {
		// 	yield return SetValueTest<ClassEquals, ClassEqualsValue>(new ClassEquals(42, 24), new ClassEquals(128, 256));
		// }
		//
		// [UnityTest]
		// public IEnumerator SetValueClassEquatable()
		// {
		// 	yield return SetValueTest<ClassEquatable, ClassEquatableValue>(new ClassEquatable(42, 24), new ClassEquatable(128, 256));
		// }

		private IEnumerator SetValueTest<TValue, TScript>(TValue value1, TValue value2) where TScript : Component
		{
			yield return SetValueTest<TValue, TScript, TScript>(value1, value2);
		}

		private IEnumerator SetValueTest<TValue, TScript1, TScript2>(TValue value1, TValue value2) where TScript1 : Component where TScript2 : Component
		{
			cube.AddComponent<TScript1>();
			if (typeof(TScript1) != typeof(TScript2))
			{
				cube.AddComponent<TScript2>();
			}

			ILevelEditorObject newCube = objectManager.CreateObject("cube");
			IExposedToLevelEditor exposed1 = newCube.MyGameObject.GetComponent<TScript1>() as IExposedToLevelEditor;
			IExposedToLevelEditor exposed2 = null;
			if (typeof(TScript1) != typeof(TScript2))
			{
				exposed2 = newCube.MyGameObject.GetComponent<TScript2>() as IExposedToLevelEditor;
			}

			Assert.IsNotNull(exposed1);
			if (exposed2 != null)
			{
				Assert.IsNotNull(exposed2);
			}

			exposed1.SetValue(0, value1, true);
			if (exposed2 != null)
			{
				exposed2.SetValue(512, value2, true);
			}
			else
			{
				exposed1.SetValue(512, value2, true);
			}

			yield return null;

			TValue newValue1 = (TValue)exposed1.GetValue(0);
			TValue newValue2;
			if (exposed2 != null)
			{
				newValue2 = (TValue)exposed2.GetValue(512);
			}
			else
			{
				newValue2 = (TValue)exposed1.GetValue(512);
			}

			Assert.AreEqual(typeof(TValue), value1.GetType());
			Assert.AreEqual(typeof(TValue), value2.GetType());

			Assert.AreEqual(newValue1, value1);
			Assert.AreEqual(newValue2, value2);

			yield return null;
		}

		private class ByteValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private byte value;

			[ExposeToLevelEditor(0)]
			private byte Value { get; set; }
		}

		private class SByteValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private sbyte value;

			[ExposeToLevelEditor(0)]
			private sbyte Value { get; set; }
		}

		private class ShortValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private short value;

			[ExposeToLevelEditor(0)]
			private short Value { get; set; }
		}

		private class UShortValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private ushort value;

			[ExposeToLevelEditor(0)]
			private ushort Value { get; set; }
		}

		private class IntValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private int value;

			[ExposeToLevelEditor(0)]
			private int Value { get; set; }
		}

		private class UIntValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private uint value;

			[ExposeToLevelEditor(0)]
			private uint Value { get; set; }
		}

		private class LongValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private long value;

			[ExposeToLevelEditor(0)]
			private long Value { get; set; }
		}

		private class ULongValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private ulong value;

			[ExposeToLevelEditor(0)]
			private ulong Value { get; set; }
		}

		private class FloatValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private float value;

			[ExposeToLevelEditor(0)]
			private float Value { get; set; }
		}

		private class DoubleValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private double value;

			[ExposeToLevelEditor(0)]
			private double Value { get; set; }
		}

		private class DecimalValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private decimal value;

			[ExposeToLevelEditor(0)]
			private decimal Value { get; set; }
		}

		private class StringValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private string value;

			[ExposeToLevelEditor(0)]
			private string Value { get; set; }

			private int editingId = 0;
			private object editValue;
			
			protected virtual bool TEMPLATE(object value, ref bool changed)
			{
				if (editingId == 512)
				{
					if (value is string str1)
					{
						this.value = str1;
						editValue = str1;
						changed = true;
						return true;
					}
				}
				if (editingId == 0)
				{
					if (value is string str2)
					{
						Value = str2;
						editValue = str2;
						changed = true;
						return true;
					}
				}
				return false;
			}
		}

		private class CharValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private char value;

			[ExposeToLevelEditor(0)]
			private char Value { get; set; }
		}

		private class Vector3Value : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private Vector3 value;

			[ExposeToLevelEditor(0)]
			private Vector3 Value { get; set; }
		}

		private class Vector2IntValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private Vector2Int value;

			[ExposeToLevelEditor(0)]
			private Vector2Int Value { get; set; }
		}

		private class ColorValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private Color value;

			[ExposeToLevelEditor(0)]
			private Color Value { get; set; }
		}

		private class Color32Value : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private Color32 value;

			[ExposeToLevelEditor(0)]
			private Color32 Value { get; set; }
		}

		private class GameObjectReference : MonoBehaviour
		{
			[ExposeToLevelEditor(-1)]
			private bool notImportant; // Just to make sure there aren't all ComponentDataWrappers.
			
			[ExposeToLevelEditor(512)]
			private GameObject value;

			[ExposeToLevelEditor(0)]
			private GameObject Value { get; set; }
		}

		private class GameObjectArray : MonoBehaviour
		{
			[ExposeToLevelEditor(-1)]
			private bool notImportant; // Just to make sure there aren't all ComponentDataWrappers.
			
			[ExposeToLevelEditor(512)]
			private GameObject[] value;

			[ExposeToLevelEditor(0)]
			private GameObject[] Value { get; set; }
		}

		private class GameObjectList : MonoBehaviour
		{
			[ExposeToLevelEditor(-1)]
			private bool notImportant; // Just to make sure there aren't all ComponentDataWrappers.
			
			[ExposeToLevelEditor(512)]
			private List<GameObject> value;

			[ExposeToLevelEditor(0)]
			private List<GameObject> Value { get; set; }
		}

		private class TransformReference : MonoBehaviour
		{
			[ExposeToLevelEditor(-1)]
			private bool notImportant; // Just to make sure there aren't all ComponentDataWrappers.
			
			[ExposeToLevelEditor(512)]
			private Transform value;

			[ExposeToLevelEditor(0)]
			private Transform Value { get; set; }
		}

		private class TransformArray : MonoBehaviour
		{
			[ExposeToLevelEditor(-1)]
			private bool notImportant; // Just to make sure there aren't all ComponentDataWrappers.
			
			[ExposeToLevelEditor(512)]
			private Transform[] value;

			[ExposeToLevelEditor(0)]
			private Transform[] Value { get; set; }
		}

		private class TransformList : MonoBehaviour
		{
			[ExposeToLevelEditor(-1)]
			private bool notImportant; // Just to make sure there aren't all ComponentDataWrappers.
			
			[ExposeToLevelEditor(512)]
			private List<Transform> value;

			[ExposeToLevelEditor(0)]
			private List<Transform> Value { get; set; }
		}

		private class ScriptReference : MonoBehaviour
		{
			[ExposeToLevelEditor(-1)]
			private bool notImportant; // Just to make sure there aren't all ComponentDataWrappers.
			
			[ExposeToLevelEditor(512)]
			private TempTestScript value;

			[ExposeToLevelEditor(0)]
			private TempTestScript Value { get; set; }
		}

		private class ScriptArray : MonoBehaviour
		{
			[ExposeToLevelEditor(-1)]
			private bool notImportant; // Just to make sure there aren't all ComponentDataWrappers.
			
			[ExposeToLevelEditor(512)]
			private TempTestScript[] value;

			[ExposeToLevelEditor(0)]
			private TempTestScript[] Value { get; set; }
		}

		private class ScriptList : MonoBehaviour
		{
			[ExposeToLevelEditor(-1)]
			private bool notImportant; // Just to make sure there aren't all ComponentDataWrappers.
			
			[ExposeToLevelEditor(512)]
			private List<TempTestScript> value;

			[ExposeToLevelEditor(0)]
			private List<TempTestScript> Value { get; set; }
		}

		private class StructValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private Struct value;
			[ExposeToLevelEditor(0)]
			private Struct Value { get; set; }
		}

		private class StructEqualityValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private StructEquality value;
			[ExposeToLevelEditor(0)]
			private StructEquality Value { get; set; }
		}

		private class StructEqualsValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private StructEquals value;
			[ExposeToLevelEditor(0)]
			private StructEquals Value { get; set; }
		}

		private class StructEquatableValue : MonoBehaviour
		{
			[ExposeToLevelEditor(512)]
			private StructEquatable value;
			[ExposeToLevelEditor(0)]
			private StructEquatable Value { get; set; }
		}

		//TODO: Use when classes are supported.
		// private class ClassValue : MonoBehaviour
		// {
		// 	[ExposeToLevelEditor(512)]
		// 	private Class value;
		// 	[ExposeToLevelEditor(0)]
		// 	private Class Value { get; set; }
		// }
		//
		// private class ClassEqualityValue : MonoBehaviour
		// {
		// 	[ExposeToLevelEditor(512)]
		// 	private ClassEquality value;
		// 	[ExposeToLevelEditor(0)]
		// 	private ClassEquality Value { get; set; }
		// }
		//
		// private class ClassEqualsValue : MonoBehaviour
		// {
		// 	[ExposeToLevelEditor(512)]
		// 	private ClassEquals value;
		// 	[ExposeToLevelEditor(0)]
		// 	private ClassEquals Value { get; set; }
		// }
		//
		// private class ClassEquatableValue : MonoBehaviour
		// {
		// 	[ExposeToLevelEditor(512)]
		// 	private ClassEquatable value;
		// 	[ExposeToLevelEditor(0)]
		// 	private ClassEquatable Value { get; set; }
		// }

		private struct Struct
		{
			public int _x;
			public int _y;

			public Struct(int x, int y)
			{
				this._x = x;
				this._y = y;
			}
		}

#pragma warning disable 660,661
		private struct StructEquality
#pragma warning restore 660,661
		{
			public int _x;
			public int _y;

			public StructEquality(int x, int y)
			{
				this._x = x;
				this._y = y;
			}

			public static bool operator ==(StructEquality left, StructEquality right)
			{
				return left.Equals(right);
			}

			public static bool operator !=(StructEquality left, StructEquality right)
			{
				return !left.Equals(right);
			}
		}

		private struct StructEquals
		{
			public int _x;
			public int _y;

			public StructEquals(int x, int y)
			{
				this._x = x;
				this._y = y;
			}

			public bool Equals(StructEquals other)
			{
				return _x == other._x && _y == other._y;
			}

			public override bool Equals(object obj)
			{
				return obj is StructEquals other && Equals(other);
			}

			public override int GetHashCode()
			{
				unchecked
				{
					return (_x * 397) ^ _y;
				}
			}
		}

		private struct StructEquatable : IEquatable<StructEquatable>
		{
			public int _x;
			public int _y;

			public StructEquatable(int x, int y)
			{
				this._x = x;
				this._y = y;
			}

			public bool Equals(StructEquatable other)
			{
				return _x == other._x && _y == other._y;
			}

			public override bool Equals(object obj)
			{
				return obj is StructEquatable other && Equals(other);
			}

			public override int GetHashCode()
			{
				unchecked
				{
					return (_x * 397) ^ _y;
				}
			}

			public static bool operator ==(StructEquatable left, StructEquatable right)
			{
				return left.Equals(right);
			}

			public static bool operator !=(StructEquatable left, StructEquatable right)
			{
				return !left.Equals(right);
			}
		}

		private class Class
		{
			public int x;
			public int y;

			public Class(int x, int y)
			{
				this.x = x;
				this.y = y;
			}
		}

#pragma warning disable 660,661
		private class ClassEquality
#pragma warning restore 660,661
		{
			public int x;
			public int y;

			public ClassEquality(int x, int y)
			{
				this.x = x;
				this.y = y;
			}

			public static bool operator ==(ClassEquality left, ClassEquality right)
			{
				return left.Equals(right);
			}

			public static bool operator !=(ClassEquality left, ClassEquality right)
			{
				return !left.Equals(right);
			}
		}

		private class ClassEquals
		{
			public int x;
			public int y;

			public ClassEquals(int x, int y)
			{
				this.x = x;
				this.y = y;
			}

			public bool Equals(ClassEquals other)
			{
				return x == other.x && y == other.y;
			}

			public override bool Equals(object obj)
			{
				return obj is ClassEquals other && Equals(other);
			}

			public override int GetHashCode()
			{
				unchecked
				{
					return (x * 397) ^ y;
				}
			}
		}

		private class ClassEquatable : IEquatable<ClassEquatable>
		{
			public int x;
			public int y;

			public ClassEquatable(int x, int y)
			{
				this.x = x;
				this.y = y;
			}

			public bool Equals(ClassEquatable other)
			{
				return x == other.x && y == other.y;
			}

			public override bool Equals(object obj)
			{
				return obj is ClassEquatable other && Equals(other);
			}

			public override int GetHashCode()
			{
				unchecked
				{
					return (x * 397) ^ y;
				}
			}

			public static bool operator ==(ClassEquatable left, ClassEquatable right)
			{
				return left.Equals(right);
			}

			public static bool operator !=(ClassEquatable left, ClassEquatable right)
			{
				return !left.Equals(right);
			}
		}
	}
}