using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Hertzole.ALE.Generated
{
	public class TestScriptFormatter : IMessagePackFormatter<TestScript.WrapperTemplate>
	{
		public void Serialize(ref MessagePackWriter writer, TestScript.WrapperTemplate value, MessagePackSerializerOptions options)
		{
			LevelEditorLogger.Log("Serialize");
			writer.WriteArrayHeader(60);
			writer.WriteInt32(value.charTest.Item1);
			options.Resolver.GetFormatterWithVerify<char>().Serialize(ref writer, (char)value.charTest.Item2, options);
			writer.WriteInt32(value.testString.Item1);
			options.Resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.testString.Item2, options);
			writer.WriteInt32(value.testByte.Item1);
			writer.WriteUInt8((byte)value.testByte.Item2);
			writer.WriteInt32(value.testSByte.Item1);
			writer.WriteInt8((sbyte)value.testSByte.Item2);
			writer.WriteInt32(value.testShort.Item1);
			writer.WriteInt16((short)value.testShort.Item2);
			writer.WriteInt32(value.testUShort.Item1);
			writer.WriteUInt16((ushort)value.testUShort.Item2);
			writer.WriteInt32(value.testInt.Item1);
			writer.WriteInt32(value.testInt.Item2);
			writer.WriteInt32(value.testUint.Item1);
			writer.WriteUInt32((uint)value.testUint.Item2);
			writer.WriteInt32(value.testLong.Item1);
			writer.WriteInt64((long)value.testLong.Item2);
			writer.WriteInt32(value.testULong.Item1);
			writer.WriteUInt64((ulong)value.testULong.Item2);
			writer.WriteInt32(value.floatTest.Item1);
			options.Resolver.GetFormatterWithVerify<float>().Serialize(ref writer, (float)value.floatTest.Item2, options);
			writer.WriteInt32(value.doubleTest.Item1);
			options.Resolver.GetFormatterWithVerify<double>().Serialize(ref writer, (double)value.doubleTest.Item2, options);
			writer.WriteInt32(value.decimalTest.Item1);
			options.Resolver.GetFormatterWithVerify<decimal>().Serialize(ref writer, value.decimalTest.Item2, options);
			writer.WriteInt32(value.vector2Test.Item1);
			options.Resolver.GetFormatterWithVerify<Vector2>().Serialize(ref writer, value.vector2Test.Item2, options);
			writer.WriteInt32(value.vector2IntTest.Item1);
			options.Resolver.GetFormatterWithVerify<Vector2Int>().Serialize(ref writer, value.vector2IntTest.Item2, options);
			writer.WriteInt32(value.vector3Test.Item1);
			options.Resolver.GetFormatterWithVerify<Vector3>().Serialize(ref writer, value.vector3Test.Item2, options);
			writer.WriteInt32(value.vector3IntTest.Item1);
			options.Resolver.GetFormatterWithVerify<Vector3Int>().Serialize(ref writer, value.vector3IntTest.Item2, options);
			writer.WriteInt32(value.boolTest.Item1);
			options.Resolver.GetFormatterWithVerify<bool>().Serialize(ref writer, value.boolTest.Item2, options);
			writer.WriteInt32(value.colorField.Item1);
			options.Resolver.GetFormatterWithVerify<Color>().Serialize(ref writer, value.colorField.Item2, options);
			writer.WriteInt32(value.color32Field.Item1);
			options.Resolver.GetFormatterWithVerify<Color32>().Serialize(ref writer, value.color32Field.Item2, options);
			writer.WriteInt32(value.otherObject.Item1);
			options.Resolver.GetFormatterWithVerify<ComponentDataWrapper>().Serialize(ref writer, value.otherObject.Item2, options);
			writer.WriteInt32(value.messages.Item1);
			options.Resolver.GetFormatterWithVerify<string[]>().Serialize(ref writer, value.messages.Item2, options);
			writer.WriteInt32(value.structTest.Item1);
			options.Resolver.GetFormatterWithVerify<global::MyCustomStruct>().Serialize(ref writer, value.structTest.Item2, options);
			writer.WriteInt32(value.secondVector3.Item1);
			options.Resolver.GetFormatterWithVerify<Vector2>().Serialize(ref writer, value.secondVector3.Item2, options);
			writer.WriteInt32(value.secondVector4.Item1);
			options.Resolver.GetFormatterWithVerify<Vector2>().Serialize(ref writer, value.secondVector4.Item2, options);
			writer.WriteInt32(value.secondVector5.Item1);
			options.Resolver.GetFormatterWithVerify<Vector2>().Serialize(ref writer, value.secondVector5.Item2, options);
			writer.WriteInt32(value.transformArray.Item1);
			options.Resolver.GetFormatterWithVerify<ComponentDataWrapper>().Serialize(ref writer, value.transformArray.Item2, options);
			writer.WriteInt32(value.gooderStruct.Item1);
			options.Resolver.GetFormatterWithVerify<global::MyGooderStruct>().Serialize(ref writer, value.gooderStruct.Item2, options);
			writer.WriteInt32(value.enumTest.Item1);
			options.Resolver.GetFormatterWithVerify<global::TestScript.TestEnum>().Serialize(ref writer, (global::TestScript.TestEnum)value.enumTest.Item2, options);
			writer.WriteInt32(value.gameObjectField.Item1);
			options.Resolver.GetFormatterWithVerify<ComponentDataWrapper>().Serialize(ref writer, value.gameObjectField.Item2, options);
		}

		public TestScript.WrapperTemplate Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			options.Security.DepthStep(ref reader);

			int length = reader.ReadArrayHeader();
			char charTest = default;
			string testString = null;
			byte testByte = 0;
			sbyte testSByte = 0;
			short testShort = 0;
			ushort testUShort = 0;
			int testInt = 0;
			uint testUInt = 0;
			long testLong = 0;
			ulong testUlong = 0;
			float floatTest = 0;
			double doubleTest = 0;
			decimal decimalTest = 0;
			Vector2 vector2Test = default;
			Vector2Int vector2IntTest = default;
			Vector3 vector3Test = default;
			Vector3Int vector3IntTest = default;
			bool boolTest = false;
			Color colorField = default;
			Color32 color32Field = default;
			ComponentDataWrapper otherObject = default;
			string[] messages = null;
			global::MyCustomStruct structTest = default;
			Vector2 secondVector3 = default;
			Vector2 secondVector4 = default;
			Vector2 secondVector5 = default;
			ComponentDataWrapper transformArray = default;
			MyGooderStruct gooderStruct = default;
			TestScript.TestEnum enumTest = 0;
			ComponentDataWrapper gameObjectField = default;
			for (int i = 0; i < length; i++)
			{
				if(i % 2 == 0)
				{
					int id = reader.ReadInt32();
					if (id == 16)
					{
						charTest = reader.ReadChar();
					}
					else if (id == 0)
					{
						testString = reader.ReadString();
					}
					else if (id == 1)
					{
						testByte = reader.ReadByte();
					}
					else if (id == 2)
					{
						testSByte = reader.ReadSByte();
					}
					else if (id == 3)
					{
						testShort = reader.ReadInt16();
					}
					else if (id == 4)
					{
						testUShort = reader.ReadUInt16();
					}
					else if (id == 5)
					{
						testInt = reader.ReadInt32();
					}
					else if (id == 6)
					{
						testUInt = reader.ReadUInt32();
					}
					else if (id == 7)
					{
						testLong = reader.ReadInt64();
					}
					else if (id == 8)
					{
						testUlong = reader.ReadUInt64();
					}
					else if (id == 9)
					{
						floatTest = reader.ReadSingle();
					}
					else if (id == 10)
					{
						doubleTest = reader.ReadDouble();
					}
					else if (id == 11)
					{
						decimalTest = options.Resolver.GetFormatterWithVerify<decimal>().Deserialize(ref reader, options);
					}
					else if (id == 12)
					{
						vector2Test = options.Resolver.GetFormatterWithVerify<Vector2>().Deserialize(ref reader, options);
					}
					else if (id == 13)
					{
						vector2IntTest = options.Resolver.GetFormatterWithVerify<Vector2Int>().Deserialize(ref reader, options);
					}
					else if (id == 14)
					{
						vector3Test = options.Resolver.GetFormatterWithVerify<Vector3>().Deserialize(ref reader, options);
					}
					else if (id == 15)
					{
						vector3IntTest = options.Resolver.GetFormatterWithVerify<Vector3Int>().Deserialize(ref reader, options);
					}
					else if (id == 17)
					{
						boolTest = reader.ReadBoolean();
					}
					else if (id == 18)
					{
						colorField = options.Resolver.GetFormatterWithVerify<Color>().Deserialize(ref reader, options);
					}
					else if (id == 19)
					{
						color32Field = options.Resolver.GetFormatterWithVerify<Color32>().Deserialize(ref reader, options);
					}
					else if (id == 20)
					{
						otherObject = options.Resolver.GetFormatterWithVerify<ComponentDataWrapper>().Deserialize(ref reader, options);
					}
					else if (id == 21)
					{
						messages = options.Resolver.GetFormatterWithVerify<string[]>().Deserialize(ref reader, options);
					}
					else if (id == 22)
					{
						structTest = options.Resolver.GetFormatterWithVerify<MyCustomStruct>().Deserialize(ref reader, options);
					}
					else if (id == 23)
					{
						secondVector3 = options.Resolver.GetFormatterWithVerify<Vector2>().Deserialize(ref reader, options);
					}
					else if (id == 24)
					{
						secondVector4 = options.Resolver.GetFormatterWithVerify<Vector2>().Deserialize(ref reader, options);
					}
					else if (id == 25)
					{
						secondVector5 = options.Resolver.GetFormatterWithVerify<Vector2>().Deserialize(ref reader, options);
					}
					else if (id == 26)
					{
						transformArray = options.Resolver.GetFormatterWithVerify<ComponentDataWrapper>().Deserialize(ref reader, options);
					}
					else if (id == 27)
					{
						gooderStruct = options.Resolver.GetFormatterWithVerify<MyGooderStruct>().Deserialize(ref reader, options);
					}
					else if (id == 28)
					{
						enumTest = options.Resolver.GetFormatterWithVerify<TestScript.TestEnum>().Deserialize(ref reader, options);
					}
					else if (id == 29)
					{
						gameObjectField = options.Resolver.GetFormatterWithVerify<ComponentDataWrapper>().Deserialize(ref reader, options);
					}
					else
					{
						reader.Skip();
					}
				}
			}
        
			reader.Depth--;
			return new TestScript.WrapperTemplate(charTest, testString, testByte, testSByte, testShort, testUShort, testInt, testUInt, testLong, testUlong, floatTest, doubleTest, decimalTest, vector2Test, vector2IntTest,
				vector3Test, vector3IntTest, boolTest, colorField, color32Field, otherObject, messages, structTest, secondVector3, secondVector4, secondVector5, transformArray, gooderStruct, enumTest, gameObjectField);
		}
	}
}