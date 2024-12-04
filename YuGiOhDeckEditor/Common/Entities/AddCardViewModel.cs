using YuGiOhDeckEditor.Entities;

namespace Common.Entities
{
    public class AddCardViewModel
    {
        public int Id { get; set; } // Deck ID
        public DeckInfo Deck { get; set; } // Deck object
        public List<CardsInfo> Cards { get; set; } // List of cards to display
        public string SearchTerm { get; set; } // Search term for filtering cards
        public List<string> CardNames { get; set; } // List of card names to add
    }
}
