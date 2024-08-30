using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    public abstract class Items
    {
        public string _name;
        public int _price;

        public Items(string name, int price)
        {
            _name = name;
            _price = price;
        }

        
    }
}
