using Core.Entities;

namespace YuGiOhDeckEditor.Entities
{
	public class BanList : BaseID
    {
        public string Name { get; set; }
        public int CardId { get; set; }
        public string LimitType { get; set; }

        // Parameterized constructor
        public BanList(string name, int cardId, string limitType)
        {
            Name = name;
            CardId = cardId;
            LimitType = limitType;
        }

        // Parameterless constructor
        public BanList() { }
    }
}
