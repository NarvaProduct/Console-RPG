using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Characters
{
    class Enemy : Character
    {
        private bool _fleeability;

        public bool Fleeability
        {
            get { return _fleeability; }
            set { _fleeability = value; }
        }

        public Enemy(string name, int health, int damage, bool fleeability) : base(name, health, damage) { }

        public override void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"\n\t{Name} took {amount} damage!" +
                $"\n\tPrepare for an attack!");
            Console.WriteLine($"\tPress Enter to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
