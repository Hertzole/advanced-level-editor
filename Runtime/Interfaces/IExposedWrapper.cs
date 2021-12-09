using System.Collections.Generic;
using MessagePack;

namespace Hertzole.ALE
{
	public interface IExposedWrapper
	{
		Dictionary<int, object> Values { get; }
		Dictionary<int, bool> Dirty { get; }

		void Serialize(int id, ref MessagePackWriter writer, MessagePackSerializerOptions options);

		object Deserialize(int id, ref MessagePackReader reader, MessagePackSerializerOptions options);
	}
}