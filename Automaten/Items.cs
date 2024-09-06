using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    public class Items
    {
        private int _id;
        private string _name;
        private double _price;
        private int _quantity;
        public Items(int id, string name, double price, int quantity)
        {
            _id = id;
            _name = name;
            _price = price;
            _quantity = quantity;
        }

        public int Quantity { get => _quantity; set => _quantity = value; }
        public double Price { get => _price; set => _price = value; }
        public string Name { get => _name; set => _name = value; }
        public int Id { get => _id; set => _id = value; }

        public override string ToString() 
        {
            return $"#:{Id}.\nName: {Name}.\nPrice: {Price}.\nQuantity: {Quantity}.";
        }
    }
}
