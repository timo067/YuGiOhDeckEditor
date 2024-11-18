using YuGiOhDeckEditor.Entities;

namespace YuGiOhDeckEditor.Models
{
	public class CardsModel
    {
        public CardsModel(CardsInfo cardsInfo)
        {
            Name = cardsInfo.Name;
            FrameType = cardsInfo.FrameType;
            Type = cardsInfo.Type;
            Attribute = cardsInfo.Attribute;
            Typing = cardsInfo.Typing;
            LevelOrRank = cardsInfo.LevelOrRank;
            Archetype = cardsInfo.Archetype;
            Description = cardsInfo.Description;
            Scale = cardsInfo.Scale;
            AttackPoints = cardsInfo.AttackPoints;
            DefencePoints  = cardsInfo.DefencePoints;
        }

        public string Name { get; set; }

        public string FrameType { get; set; }

        public string Type { get; set; }

        public string Attribute { get; set; }

        public string Typing { get; set; }

        public int? LevelOrRank { get; set; }

        public string Archetype { get; set; }

        public string Description { get; set; }

        public decimal? Scale { get; set; }

        public int? AttackPoints { get; set; }

        public int? DefencePoints { get; set; }
    }
}
