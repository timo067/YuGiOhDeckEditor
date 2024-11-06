using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CardsInfo : BaseID
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Attribute { get; set; }

        public string Typing { get; set; }

        public string LevelOrRank { get; set; }

        public string Archetype { get; set; }

        public string TCGDate { get; set; }

        public string OCGDate { get; set; }

        public string Description { get; set; }

        public string PendulumDescription { get; set; }

        public int AttackPoints { get; set; }

        public int DefencePoints { get; set; }

        public int Limit { get; set; }

        public CardsInfo(string name, string type, string attribute, string typing, string levelOrRank, string archetype, string tCGDate, string oCGDate, string description, string pendulumDescription, int attackPoints, int defencePoints, int limit)
        {
            Name = name;
            Type = type;
            Attribute = attribute;
            Typing = typing;
            LevelOrRank = levelOrRank;
            Archetype = archetype;
            TCGDate = tCGDate;
            OCGDate = oCGDate;
            Description = description;
            AttackPoints = attackPoints;
            DefencePoints = defencePoints;
            Limit = limit;
            PendulumDescription = pendulumDescription;
        }
    }
}
