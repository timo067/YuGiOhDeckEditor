using Core.Entities;

namespace YuGiOhDeckEditor.Entities
{
    public class DeckCard:BaseID
    {
        public int DeckId { get; set; }
        public DeckInfo Deck { get; set; } // Navigation property to DeckInfo
        public int CardId { get; set; }
        public CardsInfo Card { get; set; } // Navigation property to CardsInfo
        public int Quantity { get; set; }

        // Constructor that matches the parameters you are passing
        public DeckCard(int deckId, int cardId, int quantity)
        {
            DeckId = deckId;
            CardId = cardId;
            Quantity = quantity;
        }
    }

}
