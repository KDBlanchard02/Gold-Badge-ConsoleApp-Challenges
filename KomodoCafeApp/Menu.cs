using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeApp
{
    public class Menu
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Menu()
        {

        }

        public Menu(int number, string name, string description, double price)
        {
            Number = number;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
