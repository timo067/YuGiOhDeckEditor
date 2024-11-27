using Core.Entities;

namespace YuGiOhDeckEditor.Entities
{
    public class DeckViewModel: BaseID
    {
        public DeckInfo Deck { get; set; } = new DeckInfo(); // Using the parameterless constructor
        public IEnumerable<CardsInfo> AvailableCards { get; set; }
    }
}
