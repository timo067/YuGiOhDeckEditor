namespace YuGiOhDeckEditor.Entities
{
    public class DeckViewModel
    {
        public DeckInfo Deck { get; set; } = new DeckInfo(); // Using the parameterless constructor
        public IEnumerable<CardsInfo> AvailableCards { get; set; }
    }
}
