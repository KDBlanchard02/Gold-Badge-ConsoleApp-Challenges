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
                              "3. Display Menu \n");

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
            Console.Clear();
            Console.WriteLine($"Number: {menu.Number}\n" +
                                  $"Name: {menu.Name}\n" +
                                  $"Description: {menu.Description}\n" +
                                  $"Price: {menu.Price}\n" );
        }

        private void DeleteMenuItem()
        {
            Console.WriteLine("Enter menu item to be deleted: ");

            _repo.DeleteMenuItemByTitle(int.Parse(Console.ReadLine()));

            PressAnyKey();
        }

        public void PressAnyKey()
        {
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            RunMenu();
        }
    }
}
