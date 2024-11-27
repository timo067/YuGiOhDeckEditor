using YuGiOhDeckEditor.Entities;

namespace Common.Entities
{
    public class AddCardViewModel
    {
        public int Id { get; set; }  // Temporary ID for ViewModel usage, not for EF.
        public DeckInfo Deck { get; set; }  // Deck information
        public List<CardsInfo> Cards { get; set; }  // List of cards to select from
        public string SearchTerm { get; set; }
    }
}
