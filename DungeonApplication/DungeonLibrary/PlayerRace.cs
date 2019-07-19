using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public enum PlayerRace
    {
        //There is no direct way to create an enum through the VS interface. To make one,
        //first create a class, make it public (if necessary) and then change the class
        //keyword to enum.

        Elf,
        Dwarf,
        Human,
        Gnome,
        WhiteRabbit

    }//enum
}//namespace
