using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace YuGiOhDeckEditor.Entities
{
    public class CardType : BaseID
    {
        public string TypeName { get; set; } // Shows if the card is monster, spell or trap
    }
}
