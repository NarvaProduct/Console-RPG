using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Game.Characters
{
    class Player : Character
    {
        private int _experience;

        public int Experience
        {
            get { return _experience; }
            set { _experience = value; }
        }

        public Player(string name, int health, int damage, int experience) : base(name, health, damage) { }

        public void GetExperience(int amount)
        {
            Experience += amount;
            Console.WriteLine($"{Name} gained {amount} experience.");
        }
        public void Attack(Enemy target, int damage)
        {
            target.TakeDamage(damage);
        }
        public static Player ClassSelection(string name)
        {
            while (true)
            {
                Console.Write("\n\tSelect your class\n\t1. Warrior\n\t2. Assassin\n\t3. Show Info\n\tChoose from the options above: ");
                int userInput = Utils.Utils.CheckUserInput(Console.ReadLine(), 3);

                if (userInput == 1 || userInput == 2 || userInput == 3)
                {
                    if (userInput == 1)
                    {
                        return new Player(name, 100, 75, 0);
                    }
                    else if (userInput == 2)
                    {
                        return new Player(name, 75, 110, 0);
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("\n\tWarrior:\n\tHealth: 100\n\tDamage: 75\n\tThe warrior can handle most encounters with his" +
                            "\n\tbalanced health and damage." +
                            "\n\n\tAssassin:\n\tHealth: 75\n\tDamage: 110\n\tThe assassin can't take take too many blows, but his are dealy." +
                            "\n\n\tPress any key to go back to class selection.");
                        Console.ReadKey();
                        Console.Clear();
                        continue;

                    }
                }
            }
        }
    }
}
