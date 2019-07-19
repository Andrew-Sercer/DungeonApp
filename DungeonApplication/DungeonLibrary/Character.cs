using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Character
    {
        //NOTE: The abstract keyword indicates that the thing being modified by that keyword
        //is an incomplete implementation. This means that the class is intended to ONLY be
        //a parent to pass class members to child classes and that CAN'T BE INSTANTIATED.

        //fields
        private int _life; //this is the only field that must be declared (business rules)

        //properties
        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {
                _life = value <= MaxLife ? value : MaxLife;
            }//set Life
        }//Life property


        //We don't inherit constructors from the parent, and because Character is abstract,
        //we are never going to instantiate one. Therefore, we will NOT build a ctor here
        //Instead, we get the free parameterless one, but we'll never be able to use it
        //(you get a syntax error if you attempt to create an object from an abstract class

        public virtual int CalcBlock()
        {
            return Block;
        }

        //MINILAB!
        //make the CalcHitChance()
        //return the HitChance, and make it overridable

        public virtual int CalcHitChance()
        {
            return HitChance;
        }

        public virtual int CalcDamage()
        {
            return 0;
        }
    }
}
