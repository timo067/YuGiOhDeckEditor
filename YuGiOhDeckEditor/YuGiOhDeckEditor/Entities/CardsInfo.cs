using Core.Entities;
using System.Text.Json.Serialization;

namespace YuGiOhDeckEditor.Entities
{
    public class CardsInfo : BaseID
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("frameType")]
        public string FrameType { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("attribute")]
        public string Attribute { get; set; }

        [JsonPropertyName("race")]
        public string Typing { get; set; }

        [JsonPropertyName("level")]
        public int? LevelOrRank { get; set; }

        [JsonPropertyName("archetype")]
        public string Archetype { get; set; }

        [JsonPropertyName("tcgDate")]
        public string TCGDate { get; set; }

        [JsonPropertyName("ocgDate")]
        public string OCGDate { get; set; }

        [JsonPropertyName("desc")]
        public string Description { get; set; }

        [JsonPropertyName("scale")]
        public decimal? Scale { get; set; }

        [JsonPropertyName("atk")]
        public int? AttackPoints { get; set; }

        [JsonPropertyName("def")]
        public int? DefencePoints { get; set; }

        public int Limit { get; set; }
    }
}
