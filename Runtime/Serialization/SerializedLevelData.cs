using Newtonsoft.Json;
using System.Collections.Generic;

namespace Hertzole.ALE
{
    public class SerializedLevelData
    {
        [JsonProperty("objectPalette")]
        public Dictionary<string, int> ObjectPalette { get; set; }
        [JsonProperty("typePalette")]
        public Dictionary<string, int> TypePalette { get; set; }

        [JsonProperty("data")]
        public LevelEditorSaveData Data { get; set; }
    }
}
