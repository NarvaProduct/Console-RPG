using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items
{
    class Item
    {
        private int _damageBoosting;
        private int _healing;

        public int damageBoosting
        {
            get { return _damageBoosting; }
            set { _damageBoosting = value; }
        }
        public int Healing
        {
            get { return _healing; }
            set { _healing = value; }
        }
    }
}
