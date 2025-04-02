/*-------------------------------------------------------
 * Written by:      Thomas Kalamees
 * Date Started:    03/11/25
 * Goal:            Create a basic text based rpg 
 *                  that utilizes classes, objects,
 *                  encapsulation, and methods.
 *_______________________________________________________
 */

using Game.Characters;
using Game.Combat;
using Utils;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    public static bool GameOver = false; // Global field to end game 
    // Main method
    public static void Main(string[]args)
    {
        while(!GameOver)
        {
            StartGame();
        }
        Environment.Exit(0);
    }
    // Main game method
    static void StartGame()
    {
        Console.Write($"\n\tWelcome to the Text RPG\n\tPress any key to start playing." +
            $"\n                                             ,--,  ,.-." +
            $"\r\n               ,                   \\,       '-,-`,'-.' | ._" +
            $"\r\n              /|           \\    ,   |\\         }}  )/  / `-,'," +
            $"\r\n              [ ,          |\\  /|   | |        /  \\|  |/`  ,`" +
            $"\r\n              | |       ,.`  `,` `, | |  _,...(   (      .'," +
            $"\r\n              \\  \\  __ ,-` `  ,  , `/ |,'      Y     (   /_L" +
            $"\\\r\n               \\  \\_\\,``,   ` , ,  /  |         )         _,/" +
            $"\r\n                \\  '  `  ,_ _`_,-,<._.<        /         /" +
            $"\r\n                 ', `>.,`  `  `   ,., |_      |         /" +
            $"\r\n                   \\/`  `,   `   ,`  | /__,.-`    _,   `" +
            $"\\\r\n               -,-..\\  _  \\  `  /  ,  / `._) _,-\\`       " +
            $"\\\r\n                \\_,,.) /\\    ` /  / ) (-,, ``    ,        |" +
            $"\r\n               ,` )  | \\_\\       '-`  |  `(               " +
            $"\\\r\n              /  /```(   , --, ,' \\   |`<`    ,            |" +
            $"\r\n             /  /_,--`\\   <\\  V /> ,` )<_/)  | \\      _____)" +
            $"\r\n       ,-, ,`   `   (_,\\ \\    |   /) / __/  /   `----`" +
            $"\r\n      (-, \\           ) \\ ('_.-._)/ /,`    /" +
            $"\r\n      | /  `          `/ " +
            $"\\\\ V   V, /`     /" +
            $"\r\n   ,--\\(        ,     <_/`\\\\     ||      /" +
            $"\r\n  (   ,``-     \\/|         \\-A.A-`|     /" +
            $"\r\n ,>,_ )_,..(    )" +
            $"\\          -,,_-`  _--`" +
            $"\r\n(_ \\|`   _,/_  /  \\_            ,--`" +
            $"\r\n \\( `   <.,../`     `-.._   _,-`");
        Console.ReadKey();

        Console.Clear();
        Console.Write("\n\tPlease enter the name of your character: ");
        string name = Console.ReadLine();
        while (true) // Checks for null input when entering character's name
        {
            if (name == "")
            {
                Console.Write("Invalid entry. Please enter a name: ");
                name = Console.ReadLine();
            }
            else { break; }
        }
        Console.Clear();

        // Instantiates a player and begins gameplay
        Player player = Player.ClassSelection(name);

        /* Scene 1: The Cottage
         * Introduces the player to the combat and running mechanic
         */
        Console.Clear();
        Console.WriteLine($"\n\t{player.Name} awakened one summer morning in a cottage on the hillside." +
            $"\n\tThe sun was shining and there was but a whisper in the air." +
            $"\n\t{player.Name} decided to do some training outside in the yard with his handy training dummy." +
            $"\n\tPress Enter to continue." +
            $"\n            \r\n          .      '      .\r\n    .      .     :     .      .\r\n     '.        ______" +
            $"       .'\r\n       '  _.-\"`      `\"-._ '\r\n        .'                '.\r\n `'--. /                    " +
            $"\\ .--'`\r\n      /                      \\\r\n     ;                        ;\r\n- -- |         " +
            $"               | -- -\r\n     |     _.                 |\r\n     ;    /__`    ,_          ;\r\n .-' " +
            $" \\   |= |;._.}}{{__       /  '-.\r\n    _.-\"\"-|.' # '. `  `.-\"{{}}<._\r\n          /       \\     \\" +
            $"  -   `\"\r\n     ----/         \\_.-'|-------\r\n     -=_ |         |    |- -.  =_\r\n    - __ |_____" +
            $"____|_.-'|_---##\r\n        `'-._|_|;:;_.-'` '::.  `\"-\r\n     .:;.      .:.   ::.     '::.");
        Console.ReadKey();

        Enemy trainingDummy = new Enemy(name:"Training Dummy", health:10, damage:0, fleeability:true);
        bool fightStatus = Fight.StartFight(player, trainingDummy);

        /* Scene 2: The Black Forest
         * Introduces the first enemy that can kill the player
         */
        Console.Clear();
        if (fightStatus) // Story response if dummy is fought
        {
            Console.WriteLine($"\n\tAfter the training, {player.Name} felt warmed up and ready for an adventure." +
                $"\n\tHe exited the back cottage gates and headed for the mysterious black forest." +
                $"\n\tIn this forest, the sun lacked the strength to beam it's rays through the thick branches of the trees." +
                $"\n\t{player.Name}, searching for a quest, continued on with determination before hearing a rustle in a nearby bush." +
                $"\n\tPress Enter to Continue." +
                $"\n             ,@@@@@@@,\r\n       ,,,.   ,@@@@@@/@@,  .oo8888o.\r\n    ,&%%&%&&%,@@@@@/@@@@@@,8888\\88/8o\r\n   ,%" +
                $"&\\%&&%&&%,@@@\\@@@/@@@88\\88888/88'\r\n   %&&%&%&/%&&%@@\\@@/ /@@@88888\\88888'\r\n   %&&%/ %&%%&&@@\\ V /@@' `88\\8" +
                $" `/88'\r\n   `&%\\ ` /%&'    |.|        \\ '|8'\r\n       |o|        | |         | |\r\n       |.|        | |    " +
                $"     | |\r\n    \\\\/ ._\\//_/__/  ,\\_//__\\\\/.  \\_//__/_");
            Console.ReadKey();
        }
        else // Alternative story response if dummy is skipped
        {
            Console.WriteLine($"\n\tAfter {player.Name} decided not to train, he still felt that there was something more for him to find out in the world" +
                $"\n\tHe exited the back cottage gates and headed for the mysterious black forest." +
                $"\n\tIn this forest, the sun lacks the strength to beam it's rays through the thick branches of the trees." +
                $"\n\t{player.Name}, searching for a quest, continues on with determination before hearing a rustle in a nearby bush." +
                $"\n\tPress Enter to Continue." +
                $"\n\n\n             ,@@@@@@@,\r\n       ,,,.   ,@@@@@@/@@,  .oo8888o.\r\n    ,&%%&%&&%,@@@@@/@@@@@@,8888\\88/8o\r\n   ,%" +
                $"&\\%&&%&&%,@@@\\@@@/@@@88\\88888/88'\r\n   %&&%&%&/%&&%@@\\@@/ /@@@88888\\88888'\r\n   %&&%/ %&%%&&@@\\ V /@@' `88\\8" +
                $" `/88'\r\n   `&%\\ ` /%&'    |.|        \\ '|8'\r\n       |o|        | |         | |\r\n       |.|        | |    " +
                $"     | |\r\n    \\\\/ ._\\//_/__/  ,\\_//__\\\\/.  \\_//__/_");
            Console.ReadKey();
        }
        Enemy wildBoar = new Enemy(name:"Wild Boar", health:200, damage:50, fleeability: false);
        fightStatus = Fight.StartFight(player, wildBoar);
    }
}
