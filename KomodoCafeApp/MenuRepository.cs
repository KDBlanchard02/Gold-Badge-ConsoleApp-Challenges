using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KomodoCafeApp;
using System.Threading.Tasks;

namespace KomodoCafeApp
{
    public class MenuRepository
    {
        // CR-D

        private readonly List<Menu> _menu = new List<Menu>();

        //Create
        public void CreateMenuItem(Menu menu)
        {
            _menu.Add(menu);
        }

        //Read
        public List<Menu> DisplayMenuItems()
        {
            return _menu;
        }

        public Menu GetMenuItemByNumber(int number)
        {
            foreach (Menu item in _menu)
            {
                if (item.Number == number)
                {
                    return item;
                }
            }

            return null;
        }

        //Delete
        public void DeleteMenuItem(Menu menu)
        {
            _menu.Remove(menu);
        }

        public bool DeleteMenuItemByNumber(int number)
        {
            Menu targetMenuItem = GetMenuItemByNumber(number);
            return _menu.Remove(targetMenuItem);
        }

    }
}
