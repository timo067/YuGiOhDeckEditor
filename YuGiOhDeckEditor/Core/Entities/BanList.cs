using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BanList : BaseID
    {
        public string Name { get; set; }

        public int CardId { get; set; }

        public string LimitType { get; set; }

        public BanList(string name, int cardId, string limitType)
        {
            Name = name;
            CardId = cardId;
            LimitType = limitType;
        }
    }
}
