using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using MonsterLibrary;

namespace DungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "!!!!!THE DUNGEON!!!!!";
            Console.Write("Enter your name here: ");
            string heroName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Welcome, {0}. Your journey begins ...\n", heroName);
            Weapon spear = new Weapon("Bronze Spear", 2, 10, 5, true); //default weapon????
            Player player = new Player(heroName, 83, 25, 125, 125, spear, PlayerRace.WhiteRabbit);
            //TODO Player Race functionality
            int monstersSlain = 0;

            bool exit = false;

            do
            {
                Console.Title = "Total Kills: " + monstersSlain;
                Console.WriteLine("Building a room ...");
                Console.WriteLine(GetRoom());

                Console.WriteLine("Populating room with ... things ...");
                Monster monster = GetMonster();
                Console.WriteLine("In this room you see: {0}",monster.Name);

                bool reload = false;
                do
                {
                    Console.Write("\nPlease choose an action!\n" +
                        "A) Attack\n" +
                        "R) RUN AWAY!\n" +
                        "P) See the Player Stats\n" +
                        "M) See the Monster Stats\n" +
                        "X) EXit\n");
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();

                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Combat.DoBattle(player, monster);
                            if (monster.Life < 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("You've slain {0}!", monster.Name);
                                Console.ResetColor();
                                monstersSlain++;
                                reload = true;
                            }//if monster is dead
                            break;

                        case ConsoleKey.R:
                            Console.WriteLine("{0} attacks you as you turn your back to run!", monster.Name);
                            Combat.DoAttack(monster, player);
                            reload = true;
                            break;

                        case ConsoleKey.P:
                            Console.WriteLine(player);
                            break;

                        case ConsoleKey.M:
                            Console.WriteLine(monster);
                            break;

                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("Ok, yeah, I need a break too ...");
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("That was not an option!");
                            break;
                    }//end switch

                    if (player.Life <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nYou've been defeated in single combat.");
                        Console.ResetColor();
                        exit = true;
                    }

                } while (!reload && !exit); //end inner loop do while


            } while (!exit); //end outer loop do while

            Console.WriteLine("\n\nGAME OVER\n\n");




        }//end Main()

        private static string GetRoom()
        {
            string[] rooms =
            {
                "This chamber is clearly a prison. Small barred cells line the walls, leaving a 15-foot-wide pathway for a guard to walk. Channels run down either side of the path next to the cages, probably to allow the prisoners' waste to flow through the grates on the other side of the room. The cells appear empty but your vantage point doesn't allow you to see the full extent of them all." ,
                "The scent of earthy decay assaults your nose upon peering through the open door to this room. Smashed bookcases and their sundered contents litter the floor. Paper rots in mold-spotted heaps, and shattered wood grows white fungus." ,
                "This short hall leads to another door. On either side of the hall, niches are set into the wall within which stand clay urns. One of the urns has been shattered, and its contents have spilled onto its shelf and the floor. Amid the ash it held, you see blackened chunks of something that might be bone.",
                "This narrow room at first appears to be a dead-end corridor, but then you note several metal plates on the walls set at about eye height. Looking more closely, you see that one of these plates is slid aside to reveal a peephole.",
                "Huge rusted metal blades jut out of cracks in the walls, and rusting spikes project down from the ceiling almost to the floor. This room may have once been trapped heavily, but someone triggered them, apparently without getting killed. The traps were never reset and now seem rusted in place.",
                "You feel a sense of foreboding upon peering into this cavernous chamber. At its center lies a low heap of refuse, rubble, and bones atop which sit several huge broken eggshells. Judging by their shattered remains, the eggs were big enough to hold a crouching man, making you wonder how large -- and where -- the mother is.",
                "A dozen statues stand or kneel in this room, and each one lacks a head and stands in a posture of action or defense. All are garbed for battle. It's difficult to tell for sure without their heads, but two appear to be dwarves, one might be an elf, six appear human, and the rest look like they might be orcs.",
                "This room looks like it was designed by drow. Rusted metal tiles create a huge mosaic of a spider in the floor, and someone set up rusted gratings like draperies of webs. At the far end of the chamber, the carving of a spider squats on the floor. It's about 3 feet tall and seems molded into the floor. Beyond it stands tall double doors of stone, their surface covered in a glittering web of gold.",
                "This room is shattered. A huge crevasse shears the chamber in half, and the ground and ceilings are tilted away from it. It's as though the room was gripped in two enormous hands and broken like a loaf of bread. Someone has torn a tall stone door from its hinges somewhere else in the dungeon and used it to bridge the 15-foot gap of the chasm between the two sides of the room. Whatever did that must have possessed tremendous strength because the door is huge, and the enormous hinges look bent and mangled.",
                "A large forge squats against the far wall of this room, and coals glow dimly inside. Before the forge stands a wide block of iron with a heavy-looking hammer lying atop it, no doubt for use in pounding out shapes in hot metal. Other forge tools hang in racks nearby, and a barrel of water and bellows rest on the floor nearby.",
            };//end string[] rooms initialization
            //Random rand = new Random();
            //int indexNbr = rand.Next(rooms.Length);
            //string room = rooms[indexNbr];
            return rooms[new Random().Next(rooms.Length)];
        }//end GetRoom()

        private static Monster GetMonster()
        {
            Spider babySpider = new Spider("Baby Spider", 50, 15, 15, 5, 1, 4, "Lucky for you, this spider is still a baby.", false);
            Spider bossSpider = new Spider("Giant Black Widow", 83, 100, 100, 15, 3, 10, "The spider is so large it almost takes up half the room.", true);
            Spider fireSpider = new Spider("Unknown (Spider)", 67, 70, 70, 20, 2, 8, "Somehow the spider is infusing his bite with fire -- is it a Dragon Spider?", false);
            Skeleton oldSkeleton = new Skeleton("Crumbling Skeleton", 83, 25, 25, 5, 5, 6, "This skeleton seems like it's about to crumble into dust", false);
            Skeleton bossSkeleton = new Skeleton("Lord Balthazar", 95, 75, 75, 12, 8, 12, "Formerly the ruler of the largest kingdom in the land ... and is now fighting to reclaim his throne.", true);
            Zombie babyZombie = new Zombie("Baby Zombie", 67, 20, 20, 20, 2, 3, "This is a tiny zombie, but don't underestimate it!", true);
            Zombie bossZombie = new Zombie("Zzyzbor The Man-Eater", 75, 120, 120, 20, 5, 9, "Your worst nightmare come true: Watch Out!", true);

            List<Monster> monsters = new List<Monster>()
            {
                babySpider, babySpider, babySpider, babySpider,
                bossSpider,
                fireSpider, fireSpider,
                oldSkeleton, oldSkeleton, oldSkeleton,
                bossSkeleton,
                babyZombie, babyZombie, babyZombie,
                bossZombie
            };

            return monsters[new Random().Next(monsters.Count)];
        }
    }//end class
}//end namespace
