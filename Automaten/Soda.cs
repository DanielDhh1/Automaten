using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    public class Soda
    {
        private string _name {  get; set; }
        private int _price { get; set; }

        public Soda(string name, int price)
        {
            _name = name;
            _price = price;
        }
    }
}
