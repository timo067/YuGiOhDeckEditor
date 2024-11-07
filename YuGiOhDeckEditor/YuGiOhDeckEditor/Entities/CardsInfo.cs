using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Core.Entities;

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
        public string LevelOrRank { get; set; }

        [JsonPropertyName("archetype ")]
        public string Archetype { get; set; }

        [JsonPropertyName("race")]
        public string TCGDate { get; set; }

        [JsonPropertyName("race")]
        public string OCGDate { get; set; }

        [JsonPropertyName("desc")]
        public string Description { get; set; }

        [JsonPropertyName("scale")]
        public string Scale { get; set; }

        [JsonPropertyName("atk")]
        public int AttackPoints { get; set; }

        [JsonPropertyName("def")]
        public int DefencePoints { get; set; }

        public int Limit { get; set; }

        public CardsInfo(string type, string name, string frameType, string attribute, string typing, string levelOrRank, string archetype, string tCGDate, string oCGDate, string description, string scale, int attackPoints, int defencePoints, int limit)
        {
            Name = name;
            FrameType = frameType;
            Type = type;
            Attribute = attribute;
            Typing = typing;
            LevelOrRank = levelOrRank;
            Archetype = archetype;
            TCGDate = tCGDate;
            OCGDate = oCGDate;
            Description = description;
            AttackPoints = attackPoints;
            DefencePoints = defencePoints;
            Limit = limit;
            Scale = scale;
        }
    }
}
