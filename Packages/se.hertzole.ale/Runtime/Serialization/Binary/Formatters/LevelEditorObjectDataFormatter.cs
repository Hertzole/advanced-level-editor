using System;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;

namespace Hertzole.ALE
{
	public sealed class LevelEditorObjectDataFormatter : IMessagePackFormatter<LevelEditorObjectData>
	{
		public void Serialize(ref MessagePackWriter writer, LevelEditorObjectData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(5);

			writer.Write(value.name);
			writer.Write(value.active);
			options.Resolver.GetFormatter<LevelEditorIdentifier>().Serialize(ref writer, value.id, options);
			writer.Write(value.instanceId);
			options.Resolver.GetFormatterWithVerify<LevelEditorComponentData[]>().Serialize(ref writer, value.components, options);
		}

		public LevelEditorObjectData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			options.Security.DepthStep(ref reader);

			string name = null;
			bool active = false;
			LevelEditorIdentifier id = new LevelEditorIdentifier();
			uint instanceId = 0;
			LevelEditorComponentData[] components = null;

#if ALE_COMPATIBILITY_0
			if (options is LevelEditorSerializerOptions levelEditorOptions && levelEditorOptions.SaveVersion == 0)
			{
				DeserializeFormat0(ref reader, options, ref name, ref active, ref id, ref instanceId, ref components);
			}
			else
#endif
			{
				DeserializeFormat1(ref reader, options, ref name, ref active, ref id, ref instanceId, ref components);
			}

			reader.Depth--;

			return new LevelEditorObjectData
				{ name = name, active = active, id = id, components = components, instanceId = instanceId };
		}

#if ALE_COMPATIBILITY_0
		private static void DeserializeFormat0(ref MessagePackReader reader, MessagePackSerializerOptions options, ref string name, ref bool active, ref LevelEditorIdentifier id, ref uint instanceId, ref LevelEditorComponentData[] components)
		{
			int count = reader.ReadMapHeader();
			for (int i = 0; i < count; i++)
			{
				ReadOnlySpan<byte> stringKey = CodeGenHelpers.ReadStringSpan(ref reader);
				switch (stringKey.Length)
				{
					default:
						FAIL:
						reader.Skip();
						continue;
					case 4:
						if (AutomataKeyGen.GetKey(ref stringKey) != 1701667182UL)
						{
							goto FAIL;
						}

						name = options.Resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
						continue;
					case 6:
						if (AutomataKeyGen.GetKey(ref stringKey) != 111559249781601UL)
						{
							goto FAIL;
						}

						active = reader.ReadBoolean();
						continue;
					case 2:
						if (AutomataKeyGen.GetKey(ref stringKey) != 25705UL)
						{
							goto FAIL;
						}

						// This used to just be a string in save format 0.
						id = new LevelEditorIdentifier(reader.ReadString());

						continue;
					case 10:
						switch (AutomataKeyGen.GetKey(ref stringKey))
						{
							default: goto FAIL;
							case 7305804385369681513UL:
								if (AutomataKeyGen.GetKey(ref stringKey) != 25673UL)
								{
									goto FAIL;
								}

								instanceId = reader.ReadUInt32();
								continue;

							case 7954885741726494563UL:
								if (AutomataKeyGen.GetKey(ref stringKey) != 29556UL)
								{
									goto FAIL;
								}

								components = options.Resolver.GetFormatterWithVerify<LevelEditorComponentData[]>().Deserialize(ref reader, options);
								continue;
						}
				}
			}
		}
#endif

		private static void DeserializeFormat1(ref MessagePackReader reader, MessagePackSerializerOptions options, ref string name, ref bool active, ref LevelEditorIdentifier id, ref uint instanceId, ref LevelEditorComponentData[] components)
		{
			int count = reader.ReadArrayHeader();
			for (int i = 0; i < count; i++)
			{
				switch (i)
				{
					case 0:
						name = reader.ReadString();
						break;
					case 1:
						active = reader.ReadBoolean();
						break;
					case 2:
						id = options.Resolver.GetFormatter<LevelEditorIdentifier>().Deserialize(ref reader, options);
						break;
					case 3:
						instanceId = reader.ReadUInt32();
						break;
					case 4:
						components = options.Resolver.GetFormatter<LevelEditorComponentData[]>().Deserialize(ref reader, options);
						break;
				}
			}
		}
	}
}