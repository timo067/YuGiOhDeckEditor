using Core.Entities;

namespace YuGiOhDeckEditor.Entities
{
    public class DeckInfo : BaseID
    {
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public string Description { get; set; }
        public List<CardsInfo> Cards { get; set; } = new List<CardsInfo>();
        public ICollection<DeckCard> DeckCards { get; set; } = new List<DeckCard>();


        // Constructor with parameters (optional for convenience)
        public DeckInfo(string name, string ownerId, string description, List<CardsInfo> cards)
        {
            Name = name;
            OwnerId = ownerId;
            Description = description;
            Cards = cards;
        }

        public DeckInfo() {
            
        }
    }
}
