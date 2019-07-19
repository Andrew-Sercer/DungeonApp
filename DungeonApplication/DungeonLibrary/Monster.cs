using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        private int _minDamage;
        public int MaxDamage { get; set; }
        public string Description { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : 1;
            }//set MinDamage
        }//MinDamage property

        public Monster(string name, int hitChance, int life, int maxLife, int block, int minDamage, int maxDamage, string description)
        {
            MaxDamage = maxDamage;
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Life = life;
            Block = block;
            Description = description;
            MinDamage = minDamage;
        }//fqctor

        public override string ToString()
        {
            return string.Format($"{Name}\nLife: {Life} of {MaxLife}\nDamage: {MinDamage} to {MaxDamage}\n" +
                $"Hit Chance: {CalcHitChance()}%\nBlock: {CalcBlock()}%\nDescription:\n{Description}");
        }//ToString()

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }//CalcDamage()

    }
}
