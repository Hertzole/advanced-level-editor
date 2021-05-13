using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Hertzole.ALE.Generated
{
	public class TestScriptFormatter : IMessagePackFormatter<TestScript.WrapperTemplate>
	{
		public void Serialize(ref MessagePackWriter writer, TestScript.WrapperTemplate value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			// writer.WriteInt32(value.Color.Item1);
			// options.Resolver.GetFormatter<Color32>().Serialize(ref writer, value.Color.Item2, options);
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
						decimalTest = options.Resolver.GetFormatter<decimal>().Deserialize(ref reader, options);
					}
					else if (id == 12)
					{
						vector2Test = options.Resolver.GetFormatter<Vector2>().Deserialize(ref reader, options);
					}
					else if (id == 13)
					{
						vector2IntTest = options.Resolver.GetFormatter<Vector2Int>().Deserialize(ref reader, options);
					}
					else if (id == 14)
					{
						vector3Test = options.Resolver.GetFormatter<Vector3>().Deserialize(ref reader, options);
					}
					else if (id == 15)
					{
						vector3IntTest = options.Resolver.GetFormatter<Vector3Int>().Deserialize(ref reader, options);
					}
					else if (id == 17)
					{
						boolTest = reader.ReadBoolean();
					}
					else if (id == 18)
					{
						colorField = options.Resolver.GetFormatter<Color>().Deserialize(ref reader, options);
					}
					else if (id == 19)
					{
						color32Field = options.Resolver.GetFormatter<Color32>().Deserialize(ref reader, options);
					}
					else if (id == 20)
					{
						otherObject = options.Resolver.GetFormatter<ComponentDataWrapper>().Deserialize(ref reader, options);
					}
					else if (id == 21)
					{
						messages = options.Resolver.GetFormatter<string[]>().Deserialize(ref reader, options);
					}
					else if (id == 22)
					{
						structTest = options.Resolver.GetFormatter<MyCustomStruct>().Deserialize(ref reader, options);
					}
					else if (id == 23)
					{
						secondVector3 = options.Resolver.GetFormatter<Vector2>().Deserialize(ref reader, options);
					}
					else if (id == 24)
					{
						secondVector4 = options.Resolver.GetFormatter<Vector2>().Deserialize(ref reader, options);
					}
					else if (id == 25)
					{
						secondVector5 = options.Resolver.GetFormatter<Vector2>().Deserialize(ref reader, options);
					}
					else if (id == 26)
					{
						transformArray = options.Resolver.GetFormatter<ComponentDataWrapper>().Deserialize(ref reader, options);
					}
					else if (id == 27)
					{
						gooderStruct = options.Resolver.GetFormatter<MyGooderStruct>().Deserialize(ref reader, options);
					}
					else if (id == 28)
					{
						enumTest = options.Resolver.GetFormatter<TestScript.TestEnum>().Deserialize(ref reader, options);
					}
					else if (id == 29)
					{
						gameObjectField = options.Resolver.GetFormatter<ComponentDataWrapper>().Deserialize(ref reader, options);
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