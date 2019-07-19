using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibrary
{
    public class Zombie : Monster
    {

        public bool IsInfected { get; set; }

        public Zombie(string name, int hitChance, int life, int maxLife, int block, int minDamage, int maxDamage, string description, bool isInfected)
            :base (name, hitChance, life, maxLife, block, minDamage, maxDamage, description)
        {
            IsInfected = isInfected;
        }

        public override string ToString()
        {
            return base.ToString() + (IsInfected ? "\nThis creature seems to carrying all kinds of horrific diseases, most of which will certainly affect you as you fight it." : "");
        }

        //This is for old functionality (code that increased block chance)
        //public override int CalcBlock()
        //{
        //    int calculatedBlock = Block;
        //    if (IsInfected)
        //    {
        //        calculatedBlock += calculatedBlock / 2;
        //    }
        //    return calculatedBlock;
        //}

        //Instead of increasing block chance, IsInfected will deal a certain amount of damage to the player
        //EVERY ROUND (after at least the first time the monster has hit you.)
        //Functionally, if an infected monster hits the player (but not if it misses) then until that
        //monster dies (or until a new monster is generated if a player runs away - in other words: until
        //the GetMonster() is called...) after every DoBattle() the player receives a guaranteed
        //2 or 3 or whatever damage (regardless of whether the monster registers another hit at all)
    }
}
