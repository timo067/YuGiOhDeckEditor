using Core.Entities;

namespace YuGiOhDeckEditor.Entities
{
	public class CardType : BaseID
    {
        public string TypeName { get; set; } // Shows if the card is monster, spell or trap
    }
}
