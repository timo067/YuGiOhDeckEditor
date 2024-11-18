using Core.Entities;

namespace YuGiOhDeckEditor.Entities
{
	public class UserDecks : BaseID
    {
        public int UserId { get; set; } // Reference to the user

        public int DeckId { get; set; } // Reference

        public UserDecks(int userId, int deckId)
        {
            UserId = userId;
            DeckId = deckId;
        }
    }
}
