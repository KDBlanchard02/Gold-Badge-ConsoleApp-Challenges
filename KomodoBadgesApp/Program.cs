using System;
using System.Collections.Generic;

namespace KomodoBadgesApp
{
    public class Program
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

        private readonly BadgeRepository _repo = new BadgeRepository();

        public void Start()
        {
            SeedBadgeList();
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
            Console.WriteLine("Komodo Badge Management Menu - Select a # and press enter. \n" +
                              "1. Create New Badge \n" +
                              "2. Update Doors on Existing Badge \n" +
                              "3. Delete All Doors on Existing Badge \n" +
                              "4. Display All Badges \n" +
                              "5. Exit App \n");

            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();

            switch (userInput)
            {
                case "1":
                    CreateNewBadge();
                    break;
                case "2":
                    UpdateDoorsOnExistingBadge();
                    break;
                case "3":
                    
                    break;
                case "4":
                    ShowAllBadges();
                    break;
                case "5":
                    ExitApp();
                    break;
                default:
                    Console.WriteLine("Invalid Selection. Press any Key To Return to Main Menu.");
                    GetMenuSelection();
                    return;
            }
        }

        private void CreateNewBadge()
        {
            Console.Clear();
            List<string> doorAccess = new List<string>();

            Console.WriteLine("Enter the badge ID:");
            int badgeId = Convert.ToInt32(Console.ReadLine());
            int BadgeID = badgeId;
            badgeId = BadgeID;

            Console.WriteLine("Enter employee name:");
            string badgeName = Console.ReadLine();

            Console.WriteLine("List a door that the badge needs access to:");
            string doorName = Console.ReadLine();

            doorAccess.Add(doorName);

            Badge badge = new Badge(badgeId, badgeName, doorAccess);
            _repo.CreateNewBadge(BadgeID, badge);

            while (true)
            {
                Console.WriteLine("Any other doors(y/n)?");
                switch (Console.ReadLine())
                {
                    case "y":
                        Console.WriteLine("List a door that the badge needs access to:");
                        string doorNameTwo = Console.ReadLine();
                        doorAccess.Add(doorNameTwo);
                        continue;
                    case "n":
                        GetMenuSelection();
                        return;
                }
            }

        }

        private void UpdateDoorsOnExistingBadge()
        {
            Dictionary<int, Badge> badgeList = _repo.ShowAllBadges();

            Console.WriteLine("Enter ID of badge to be edited:");
            int badgeId = Convert.ToInt32(Console.ReadLine());

            foreach (KeyValuePair<int, Badge> badge in badgeList)
            {
                if (badgeId == badge.Key)
                {
                    while (true)
                    {
                        Console.WriteLine($"Badge #: {badgeId}\n" +
                                      $"Door Access: {String.Join(", ", badge.Value.DoorAccess)}\n" +
                                      "--------------------------------- \n" +
                                      "What would you like to do?\n" +
                                      "1. Remove a door \n" +
                                      "2. Add a door \n" +
                                      "3. Return to main menu \n");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine("List the door you would like to remove access to:");
                                string doorName = Console.ReadLine();
                                _repo.RemoveBadgeDoorAccess(badgeId, doorName);
                                continue;
                            case "2":
                                Console.WriteLine("List the door you would like to add access to:");
                                string doorNameTwo = Console.ReadLine();
                                _repo.AddBadgeDoorAccess(badgeId, doorNameTwo);
                                continue;
                            case "3":
                                PressAnyKey();
                                return;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Selection. Press any Key To Return to Main Menu.");
                    GetMenuSelection();
                }
            }

            PressAnyKey();
        }

        private void ShowAllBadges()
        {
            Dictionary<int, Badge> badgeList = _repo.ShowAllBadges();

            foreach (KeyValuePair<int, Badge> badge in badgeList)
            {
                Console.WriteLine($"Badge #: {badge.Value.BadgeId}\n" +
                                  $"Door Access: {String.Join(", ", badge.Value.DoorAccess)}\n" +
                                  "--------------------------------- \n");
            }

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

        private void SeedBadgeList()
        {

        }
    }
}
