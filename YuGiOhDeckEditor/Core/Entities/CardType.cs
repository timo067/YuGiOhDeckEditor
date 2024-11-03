using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CardType:BaseID
    {
        public string TypeName { get; set; } // Shows if the card is monster, spell or trap
    }
}
