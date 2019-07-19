using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibrary
{
    public class Spider : Monster
    {

        public bool IsInWeb { get; set; }

        public Spider(string name, int hitChance, int life, int maxLife, int block, int minDamage, int maxDamage, string description, bool isInWeb)
            :base (name, hitChance, life, maxLife, block, minDamage, maxDamage, description)
        {
            IsInWeb = isInWeb;
        }//fqctor

        public override string ToString()
        {
            return base.ToString() + (IsInWeb ? "\nThe spider uses it's web to shield itself from your advances, making it harder to hit" : "");
        }//ToString()

        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            if (IsInWeb)
            {
                calculatedBlock += calculatedBlock / 2;
                //+50% block chance improvement (from base block chance)
            }//if
            return calculatedBlock;
        }//CalcBlock()
    }//class
}//namespace
