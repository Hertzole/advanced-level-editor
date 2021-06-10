using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Hertzole.ALE.Generated
{
	// Token: 0x02000034 RID: 52
	public class GeneratedResolver : IFormatterResolver, IWrapperSerializer, IDynamicResolver
	{
		// Token: 0x06000118 RID: 280 RVA: 0x00008A2B File Offset: 0x00006C2B
		private GeneratedResolver()
		{
		}

		private static bool registered = false;

		// Token: 0x0600011A RID: 282 RVA: 0x0000A4C9 File Offset: 0x000086C9
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void RegisterResolver()
		{
			if (registered)
				return;

			registered = true;
			
			LevelEditorResolver.RegisterResolver(instance);
			LevelEditorResolver.RegisterWrapperSerializer((IWrapperSerializer)instance);
			LevelEditorSerializer.RegisterType<ArrayScript>();
			LevelEditorSerializer.RegisterType<GridDrawTest>();
			LevelEditorSerializer.RegisterType<TestScript>();
			LevelEditorSerializer.RegisterType<TilemapTest>();
			LevelEditorSerializer.RegisterType<TintObject>();
			LevelEditorSerializer.RegisterType<TypesTest>();
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000A4FD File Offset: 0x000086FD
		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.formatter;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0000A504 File Offset: 0x00008704
		public bool SerializeWrapper(ref MessagePackWriter A_2, IExposedWrapper A_3, MessagePackSerializerOptions A_4)
		{
			// if (A_3 is global::ArrayScript.Wrapper)
			// {
			// 	global::ArrayScript.Wrapper value = (global::ArrayScript.Wrapper)A_3;
			// 	this.GetFormatter<global::ArrayScript.Wrapper>().Serialize(ref A_2, value, A_4);
			// 	return true;
			// }
			// if (A_3 is global::GridDrawTest.Wrapper)
			// {
			// 	global::GridDrawTest.Wrapper value2 = (global::GridDrawTest.Wrapper)A_3;
			// 	this.GetFormatter<global::GridDrawTest.Wrapper>().Serialize(ref A_2, value2, A_4);
			// 	return true;
			// }
			// if (A_3 is global::TestScript.Wrapper)
			// {
			// 	global::TestScript.Wrapper value3 = (global::TestScript.Wrapper)A_3;
			// 	this.GetFormatter<global::TestScript.Wrapper>().Serialize(ref A_2, value3, A_4);
			// 	return true;
			// }
			// if (A_3 is global::TilemapTest.Wrapper)
			// {
			// 	global::TilemapTest.Wrapper value4 = (global::TilemapTest.Wrapper)A_3;
			// 	this.GetFormatter<global::TilemapTest.Wrapper>().Serialize(ref A_2, value4, A_4);
			// 	return true;
			// }
			// if (A_3 is global::TintObject.Wrapper)
			// {
			// 	global::TintObject.Wrapper value5 = (global::TintObject.Wrapper)A_3;
			// 	this.GetFormatter<global::TintObject.Wrapper>().Serialize(ref A_2, value5, A_4);
			// 	return true;
			// }
			// if (A_3 is global::TypesTest.Wrapper)
			// {
			// 	global::TypesTest.Wrapper value6 = (global::TypesTest.Wrapper)A_3;
			// 	this.GetFormatter<global::TypesTest.Wrapper>().Serialize(ref A_2, value6, A_4);
			// 	return true;
			// }
			return false;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000A5D8 File Offset: 0x000087D8
		public bool DeserializeWrapper(Type A_1, ref MessagePackReader A_2, MessagePackSerializerOptions A_3, out IExposedWrapper A_4)
		{
			// if (A_1 == typeof(global::ArrayScript))
			// {
			// 	A_4 = this.GetFormatter<global::ArrayScript.Wrapper>().Deserialize(ref A_2, A_3);
			// 	return true;
			// }
			// if (A_1 == typeof(global::GridDrawTest))
			// {
			// 	A_4 = this.GetFormatter<global::GridDrawTest.Wrapper>().Deserialize(ref A_2, A_3);
			// 	return true;
			// }
			// if (A_1 == typeof(global::TestScript))
			// {
			// 	A_4 = this.GetFormatter<global::TestScript.Wrapper>().Deserialize(ref A_2, A_3);
			// 	return true;
			// }
			// if (A_1 == typeof(global::TilemapTest))
			// {
			// 	A_4 = this.GetFormatter<global::TilemapTest.Wrapper>().Deserialize(ref A_2, A_3);
			// 	return true;
			// }
			// if (A_1 == typeof(global::TintObject))
			// {
			// 	A_4 = this.GetFormatter<global::TintObject.Wrapper>().Deserialize(ref A_2, A_3);
			// 	return true;
			// }
			// if (A_1 == typeof(global::TypesTest))
			// {
			// 	A_4 = this.GetFormatter<global::TypesTest.Wrapper>().Deserialize(ref A_2, A_3);
			// 	return true;
			// }
			A_4 = null;
			return false;
		}

		// Token: 0x04000100 RID: 256
		private static readonly IFormatterResolver instance = new GeneratedResolver();

		// Token: 0x02000035 RID: 53
		internal static class GetFormatterHelper
		{
			// Token: 0x0600011F RID: 287 RVA: 0x0000A760 File Offset: 0x00008960
			internal static object GetFormatter(Type A_0)
			{
				int num;
				if (!lookup.TryGetValue(A_0, out num))
				{
					return null;
				}
				switch (num)
				{
				// case 0:
				// 	return new Hertzole.ALE.Generated.Formatters._ArrayScript_Formatter();
				// case 1:
				// 	return new Hertzole.ALE.Generated.Formatters._GridDrawTest_Formatter();
				// case 2:
				// 	return new Hertzole.ALE.Generated.Formatters._TestScript_Formatter();
				// case 3:
				// 	return new Hertzole.ALE.Generated.Formatters._TilemapTest_Formatter();
				// case 4:
				// 	return new Hertzole.ALE.Generated.Formatters._TintObject_Formatter();
				// case 5:
				// 	return new Hertzole.ALE.Generated.Formatters._TypesTest_Formatter();
				case 1:
					return new DictionaryFormatter<string, string>();
				default:
					return null;
				}
			}

			// Token: 0x04000101 RID: 257
			private static readonly Dictionary<Type, int> lookup = new Dictionary<Type, int>
			{
				{
					typeof(Dictionary<string, string>),
					0
				}
				// {
				// 	typeof(global::ArrayScript.Wrapper),
				// 	0
				// },
				// {
				// 	typeof(global::GridDrawTest.Wrapper),
				// 	1
				// },
				// {
				// 	typeof(global::TestScript.Wrapper),
				// 	2
				// },
				// {
				// 	typeof(global::TilemapTest.Wrapper),
				// 	3
				// },
				// {
				// 	typeof(global::TintObject.Wrapper),
				// 	4
				// },
				// {
				// 	typeof(global::TypesTest.Wrapper),
				// 	5
				// }
			};
		}

		// Token: 0x02000036 RID: 54
		private static class FormatterCache<T>
		{
			// Token: 0x06000120 RID: 288 RVA: 0x0000A7C4 File Offset: 0x000089C4
			static FormatterCache()
			{
				object obj = GetFormatterHelper.GetFormatter(typeof(T));
				if (obj != null)
				{
					formatter = (IMessagePackFormatter<T>)obj;
				}
			}

			// Token: 0x04000102 RID: 258
			internal static readonly IMessagePackFormatter<T> formatter;
		}

		public bool SerializeDynamic(Type type, ref MessagePackWriter writer, object value, MessagePackSerializerOptions options)
		{
			// if (type == typeof(int))
			// {
			// 	writer.WriteInt32((int) value);
			// 	return true;
			// }
			//
			// if (type == typeof(MyLitStruct))
			// {
			// 	options.Resolver.GetFormatterWithVerify<MyLitStruct>().Serialize(ref writer, (MyLitStruct)value, options);
			// 	return true;
			// }

			return false;
		}

		public bool DeserializeDynamic(Type type, ref MessagePackReader reader, out object value, MessagePackSerializerOptions options)
		{
			if (type == typeof(int))
			{
				value = reader.ReadInt32(); 
				return true;
			}

			if (type == typeof(MyLitStruct))
			{
				value = options.Resolver.GetFormatterWithVerify<MyLitStruct>().Deserialize(ref reader, options);
				return true;
			}

			value = null;
			return false;
		}
	}
}
