using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibrary
{
    public class Skeleton : Monster
    {
        public bool HasFlesh { get; set; }

        public Skeleton(string name, int hitChance, int life, int maxLife, int block, int minDamage, int maxDamage, string description, bool hasFlesh)
            :base(name, hitChance, life, maxLife, block, minDamage, maxDamage, description)
        {
            HasFlesh = hasFlesh;
        }

        public override string ToString()
        {
            return base.ToString() + (HasFlesh ? "" : "\nThis skeleton is completely devoid of any remaining flesh or muscle, making it more difficult to find it's weak spots.");
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            if (!HasFlesh)
            {
                calculatedBlock += calculatedBlock / 2;
            }
            return calculatedBlock;
        }
    }
}
