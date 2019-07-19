using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //fields
        private string _name;
        private bool _isTwoHanded;
        private int _bonusHitChance;
        private int _minDamage;
        private int _maxDamage;

        //properties
        //properties with business rules ALWAYS GO LAST
        //because the business rules may rely on the value of other properties
        //even if they don't, it's still good practice to define the properties with
        //business rules after the ones without business rules
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }//Name property
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }//IsTwoHanded property
        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }//BonusHitChance property
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }//MaxDamage property
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : 1;
                //if (value > 0 && value <= MaxDamage)
                //{
                //    _minDamage = value;
                //}//if
                //else
                //{
                //    _minDamage = 1;
                //}
            }//set MinDamage
        }//MinDamage property

        //ctors: FQCTOR only
        public Weapon(string name, int minDamage, int maxDamage, int bonusHitChance, bool isTwoHanded)
        {
            //MinDamage has a dependency on MaxDamage, so MaxDamage MUST be set BEFORE MinDamage
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
        }//FQCTOR

        //methods
        public override string ToString()
        {
            return string.Format("{0}\n{1} to {2} damage\nBonus Hit: {3}%\n{4}",
                Name,
                MinDamage,
                MaxDamage,
                BonusHitChance,
                IsTwoHanded ? "Two-handed weapon" : "One-hand weapon");
        }//ToString()
    }//end Weapon class
}//end namespace
