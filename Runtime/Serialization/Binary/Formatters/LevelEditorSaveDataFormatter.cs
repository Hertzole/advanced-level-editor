using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Hertzole.ALE
{
	public sealed class LevelEditorSaveDataFormatter : IMessagePackFormatter<LevelEditorSaveData>
	{
		public void Serialize(ref MessagePackWriter writer, LevelEditorSaveData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(4);
			writer.WriteUInt16(LevelEditorSaveData.SAVE_VERSION);
			writer.Write(value.name);
			options.Resolver.GetFormatterWithVerify<List<LevelEditorObjectData>>().Serialize(ref writer, value.objects, options);
			options.Resolver.GetFormatterWithVerify<Dictionary<string, LevelEditorCustomData>>().Serialize(ref writer, value.customData, options);
		}

		public LevelEditorSaveData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			options.Security.DepthStep(ref reader);

			ushort saveVersion = 0;
			string name = null;
			List<LevelEditorObjectData> objects = null;
			Dictionary<string, LevelEditorCustomData> customData = null;

			LevelEditorSerializerOptions levelEditorOptions = options as LevelEditorSerializerOptions;
			if (levelEditorOptions != null)
			{
				levelEditorOptions.SaveVersion = 0;
			}
			int count = reader.ReadArrayHeader();
			for (int i = 0; i < count; i++)
			{
				switch (i)
				{
					case 0:
#if ALE_COMPATIBILITY_0
						// This used to be name in save format 0.
						if (reader.NextMessagePackType == MessagePackType.String)
						{
							name = reader.ReadString();
						}
						else
#endif
						{
							saveVersion = reader.ReadUInt16();
						}

						if (levelEditorOptions != null)
						{
							levelEditorOptions.SaveVersion = saveVersion;
						}

						break;
					case 1:
#if ALE_COMPATIBILITY_0
						// This used to be objects in save format 0.
						if (saveVersion == 0)
						{
							objects = options.Resolver.GetFormatterWithVerify<List<LevelEditorObjectData>>().Deserialize(ref reader, options);
						}
						else
#endif
						{
							name = reader.ReadString();
						}

						break;
					case 2:
#if ALE_COMPATIBILITY_0
						// This used to be customData in save format 0.
						if (saveVersion == 0)
						{
							customData = options.Resolver.GetFormatterWithVerify<Dictionary<string, LevelEditorCustomData>>().Deserialize(ref reader, options);
						}
						else
#endif
						{
							objects = options.Resolver.GetFormatterWithVerify<List<LevelEditorObjectData>>().Deserialize(ref reader, options);
						}

						break;
					case 3:
						customData = options.Resolver.GetFormatterWithVerify<Dictionary<string, LevelEditorCustomData>>().Deserialize(ref reader, options);
						break;
					default:
						reader.Skip();
						break;
				}
			}

			reader.Depth--;

			return new LevelEditorSaveData(name) { objects = objects, customData = customData };
		}
	}
}