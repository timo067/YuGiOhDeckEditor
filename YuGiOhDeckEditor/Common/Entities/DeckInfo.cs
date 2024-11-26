using Core.Entities;

namespace YuGiOhDeckEditor.Entities
{
    public class DeckInfo : BaseID
    {
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public string Description { get; set; }

        public ICollection<CardsInfo> DeckCards { get; set; }

        // Constructor with parameters (optional for convenience)
        public DeckInfo(string name, string ownerId, string description, List<CardsInfo> deckCards)
        {
            Name = name;
            OwnerId = ownerId;
            Description = description;
            DeckCards = deckCards;
        }

        public DeckInfo()
        {
        }
    }
}
