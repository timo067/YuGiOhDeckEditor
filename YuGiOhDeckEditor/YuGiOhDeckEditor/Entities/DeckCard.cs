using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DeckCard : BaseID
    {
        public int DeckId { get; set; } // Reference to the Deck containing the card.

        public int CardId { get; set; } // Reference to the Card in the deck.

        public int Quantity { get; set; } // Number of copies of this card in the deck.

        public DeckCard(int deckId, int cardId, int quantity)
        {
            DeckId = deckId;
            CardId = cardId;
            Quantity = quantity;
        }
    }
}
