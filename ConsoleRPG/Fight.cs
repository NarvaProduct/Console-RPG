using Game.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using System.Numerics;

namespace Game.Combat
{
    class Fight
    {
        public static void FightLoop(Player player, Enemy enemy)
        {
            while (true)
            {
                Console.Clear();
                DisplayFightStats(player, enemy);
                FightDecision(player, enemy);

                Console.Clear();
                DisplayFightStats(player, enemy);
                player.TakeDamage(enemy.Damage);
                int fightStatus = CheckWin(player, enemy);
                if (fightStatus == 1) // 1 means player win; 2 means player loss; 3 means fight continues
                {
                    break;
                }
                else if(fightStatus == 2)
                {
                    Console.Clear();
                    Console.WriteLine($"\n\tThe insatiable thirst for adventure brought {player.Name} to his peril. Game Over" +
                        $"\n\tPress enter to end the game." +
                        $"\n                           ,--.\r\n                          {{    }}\r\n   " +
                        $"                       K,   }}\r\n                         /  `Y`\r\n         " +
                        $"           _   /   /\r\n                   {{_'-K.__/\r\n                     " +
                        $"`/-.__L._\r\n                     /  ' /`\\_}}\r\n                    /  ' /    " +
                        $"              \r\n            ____   /  ' /\r\n     ,-'~~~~    ~~/  ' /_\r\n   ,' " +
                        $"            ``~~~%%',\r\n  (                     %  Y\r\n {{                   " +
                        $"   %% I\r\n{{      -                 %  `.\r\n|       ',                %  )\r\n| " +
                        $"       |   ,..__      __. Y\r\n|    .,_./  Y ' / ^Y   J   )|\r\n\\           |' /" +
                        $"   |   |   ||\r\n \\          L_/    . _ (_,.'(\r\n  \\,   ,      ^^\"\"' / |     " +
                        $" )\r\n    \\_  \\          /,L]     /\r\n      '-_`-,       ` `   ./`\r\n         `" +
                        $"-(_            )\r\n             ^^\\..___,.--`");
                    Console.ReadKey();
                    Program.GameOver = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        public static void DisplayFightStats(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine($"\n\t\tBATTLE MENU" +
                $"\n----------------------------------------------" +
                $"\n\n\t{player.Name}" +
                $"\n\tHealth: {player.Health}" +
                $"\n\tDamage: {player.Damage}" +
                
                $"\n\n\t{enemy.Name}" +
                $"\n\tHealth: {enemy.Health}" +
                $"\n\tDamage: {enemy.Damage}" +
                $"\n\n----------------------------------------------");
        }
        public static void FightDecision(Player player, Enemy enemy)
        {
            Console.Write("\n\t\tFight Options:" +
                "\n\t|1. Attack" +
                "\n\t|2. Run away" +
                "\n\t|Choose from the options above: ");
            int userInput = Utils.Utils.CheckUserInput(Console.ReadLine(), 2);

            if(userInput == 1)
            {
                Console.Clear();
                DisplayFightStats(player, enemy);
                player.Attack(enemy, player.Damage);
            }
            else if(enemy.Fleeability)
            {
                Console.WriteLine($"{player.Name} escaped {enemy.Name}!\nPress enter to continue");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine($"{enemy.Name} does not let you escape!\nPress enter to continue");
                Console.ReadKey();
            }

        }
        public static int CheckWin(Player player, Enemy enemy) // 1 means player loss; 2 means player win; 3 means fight continues
        {
            if (player.Health <= 0)
            {
                Console.Clear();
                Console.WriteLine($"\n{player} has died!");
                return 2;
            }
            else if (enemy.Health <= 0)
            {
                Console.Clear();
                Console.Write($"\n\t{enemy.Name} has been defeated!" +
                    $"\n\t{player.Name} is victorious!" +
                    $"\n\tPress enter to continue.");
                Console.ReadKey();
                return 1;
            }
            else
            {
                return 3;
            }
        }
        public static bool StartFight(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.Write($"\n\tA fight has begun between {player.Name} and {enemy.Name}." +
                $"\n\tDo you engage?\n\t1. Yes\n\t2. No" +
                $"\n\tChoose from the options above: ");

            int userInput = Utils.Utils.CheckUserInput(Console.ReadLine(), 2);
            if (userInput == 1)
            {
                FightLoop(player, enemy);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}