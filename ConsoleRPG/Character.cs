using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Characters
{
    class Character
    {
        private string _name;
        private int _health;
        private int _damage;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        public Character(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        public virtual void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"\n\t{Name} took {amount} damage" +
                $"\n\tPress enter to continue.");
            Console.ReadKey();
        }
    }
}       
   

