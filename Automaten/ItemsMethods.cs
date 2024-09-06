using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Automaten
{
    public class ItemsMethods
    {
        private readonly string jsonPath = @"C:\Users\nqvis\OneDrive\Skrivebord\Automaten\Automaten\items.json";
        private List<Items> _items;
        public ItemsMethods()
        {
            LoadItems();
        }

        public void NewItem(int id, string name, double price, int quantity)
        {
            if (ItemExists(id))
            {
                throw new VendingMachineException.IdAlreadyExistsException("Id already exists");
            }
            _items.Add(new Items(id, name, price, quantity));
            SaveItems();
        }
        public List<Items> ShowAllItems()
        {
            LoadItems();
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
            return _items;
        }
        private void LoadItems()
        {
            if (File.Exists(jsonPath))
            {
                var json = File.ReadAllText(jsonPath);
                _items = JsonConvert.DeserializeObject<List<Items>>(json) ?? new List<Items>();
            }
            else
            {
                _items = new List<Items>()
                {
                    new Items(1, "Coca-cola", 9.95, 300),
                    new Items(2, "OstePops", 9.95, 200)
                };
                SaveItems();
            }
        }
        private void SaveItems()
        {
            var json = JsonConvert.SerializeObject(_items, Formatting.Indented );
            File.WriteAllText(jsonPath, json);
        }
        public void BuyItem(int itemNumber, double moneyInserted)
        {
            try
            {
                if (itemNumber < 1 || itemNumber > _items.Count)
                {
                    throw new VendingMachineException.InvalidNumberException("Invalid number");
                }

                Items selectedItem = _items[itemNumber - 1];
                if (selectedItem.Quantity == 0)
                {
                    throw new VendingMachineException.OutOfStockException("Out of stock");
                }
                if (moneyInserted < selectedItem.Price)
                {
                    throw new VendingMachineException.InsufficientFundsException("Insufficient funds");
                }
                selectedItem.Quantity--;
                double change = moneyInserted - selectedItem.Price;
                Console.WriteLine($"Dispensing {selectedItem.Name}. Change: {change:F2}");
            }
            catch (VendingMachineException.InvalidNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (VendingMachineException.OutOfStockException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (VendingMachineException.InsufficientFundsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            SaveItems();
        }
        public bool ItemExists(int id)
        {
            return _items.Any(item => item.Id == id);
        }
    }
}
