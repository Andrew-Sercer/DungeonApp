using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        #region notes and (now) irrelevant code
        //Automatic properties are a shortcut syntax that was introduced with .Net 3.5
        //which allows us to quickly make a property that doesn't have a business rule.
        //Auto properties automatically create a related field at runtime and therefore
        //do not require us to manually write a field.

        ////fields
        //private int _life; //this is the only field that must be declared (business rules)

        ////properties
        //public string Name { get; set; }
        //public int HitChance { get; set; }
        //public int Block { get; set; }
        //public int MaxLife { get; set; }
        #endregion
        public Weapon EquippedWeapon { get; set; }
        public PlayerRace Race { get; set; }
        #region (now) irrelevant code
        //public int Life
        //{
        //    get { return _life; }
        //    set
        //    {
        //        _life = value <= MaxLife ? value : MaxLife;
        //    }//set Life
        //}//Life property
        #endregion

        //ctors: FQCTOR only
        public Player(string name, int hitChance, int block, int maxLife, int life, Weapon equippedWeapon, PlayerRace race)
        {
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            EquippedWeapon = equippedWeapon;
            Race = race;

            switch (Race)
            {
                case PlayerRace.Elf:
                    break;
                case PlayerRace.Dwarf:
                    break;
                case PlayerRace.Human:
                    break;
                case PlayerRace.Gnome:
                    break;
                case PlayerRace.WhiteRabbit:
                    EquippedWeapon.MaxDamage += 5;
                    EquippedWeapon.MinDamage += 2;
                    break;
                default:
                    break;
            }
        }//FQCTOR

        //methods
        public override string ToString()
        {
            string description = "";
            switch (Race)
            {
                case PlayerRace.Elf:
                    description = "You move around like the wind - fast enough even that other races believe that you can become invisible.";
                    break;
                case PlayerRace.Dwarf:
                    description = "Small in stature, but seemingly impossibly gifted in physical nature, your feats and abilities stand tall over everyone else.";
                    break;
                case PlayerRace.Human:
                    description = "You are a boring, normal Human. Physically imposing, but limited in almost every other way.";
                    break;
                case PlayerRace.Gnome:
                    description = "You're a gnome now. Congratulations. You deserve everything you get in this game.";
                    break;
                case PlayerRace.WhiteRabbit:
                    description = "Not just any rabbit: your fur is the purest white ... and though tales of your ferocity and cunning and mastery haven't traveled well at all, it is only because any who meet you, never live to tell about it.";
                    break;
            }//switch (Race)
            return string.Format("---<<<<< {0} >>>>>---\nLife: {1}/{2}\nHit Chance: {3}%\nWeapon:\n{4}\nBlock: {5}%\nDescription: {6}",
                Name,
                Life,
                MaxLife,
                HitChance,
                EquippedWeapon,
                Block,
                description);
        }//ToString()

        public override int CalcDamage()
        {
            return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
        }//CalcDamage()

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }//CalcHitChance()


    }//class
}//namespace
