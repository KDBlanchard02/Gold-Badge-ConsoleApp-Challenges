using System;
using System.Collections.Generic;
using static KomodoCafeApp.MenuRepository;

namespace KomodoCafeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramUI _programUI = new ProgramUI();
            _programUI.Start();
        }
    }

    public class ProgramUI
    {
        private bool _isRunning = true;

        private readonly MenuRepository _repo = new MenuRepository();

        public void Start()
        {
            SeedMenuList();
            RunMenu();
        }

        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = GetMenuSelection();
                OpenMenuItem(userInput);
            }
        }

        private string GetMenuSelection()
        {
            Console.Clear();
            Console.WriteLine("Komodo Cafe Menu Management - Select a # and press enter. \n" +
                              "1. Add Menu Item \n" +
                              "2. Delete Menu Item \n" +
                              "3. Display Menu \n" +
                              "4. Exit App \n");

            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();

            switch (userInput)
            {
                case "1":
                    AddMenuItem();
                    break;
                case "2":
                    DeleteMenuItem();
                    break;
                case "3":
                    DisplayFullMenu();
                    break;
                case "4":
                    ExitApp();
                    break;
                default:
                    Console.WriteLine("Invalid Selection. Press any Key To Return to Main Menu.");
                    GetMenuSelection();
                    return;
            }
        }

        private void DisplayFullMenu()
        {
            List<Menu> menuList = _repo.DisplayMenuItems();

            foreach (Menu menu in menuList)
            {
                DisplayMenu(menu);
            }

            PressAnyKey();
        }

        private void AddMenuItem()
        {
            Console.WriteLine("Enter a # for the menu item:");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a name for the menu item:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter a description for the menu item:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter a price for the menu item:");
            double price = double.Parse(Console.ReadLine());

            Menu menu = new Menu(number, name, description, price);

            _repo.CreateMenuItem(menu);

            PressAnyKey();
        }

        private void DisplayMenu(Menu menu)
        {
            Console.WriteLine($"Number: {menu.Number}\n" +
                                  $"Name: {menu.Name}\n" +
                                  $"Description: {menu.Description}\n" +
                                  $"Price: ${menu.Price}\n" );
        }

        private void DeleteMenuItem()
        {
            Console.WriteLine("Enter menu item to be deleted: ");

            _repo.DeleteMenuItemByTitle(int.Parse(Console.ReadLine()));

            PressAnyKey();
        }

        private void PressAnyKey()
        {
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            RunMenu();
        }

        private void ExitApp()
        {
            _isRunning = false;
        }

        private void SeedMenuList()
        {
            Menu burger = new Menu(1, "Cheeseburger", "A yummy 'Merican classic.", 3.99);
            Menu friedChicken = new Menu(2, "Bucket O Fried Chicken", "A large bucket of deep-fried chicken.", 12.99);
            Menu grilledCheese = new Menu(3, "Grilled Cheese", "Two freshly toasted/roasted slices of white bread, held together by cheddar.", 2.99);
            _repo.CreateMenuItem(burger);
            _repo.CreateMenuItem(friedChicken);
            _repo.CreateMenuItem(grilledCheese);
        }
    }
}
