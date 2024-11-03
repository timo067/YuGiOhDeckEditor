using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserDecks:BaseID
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
