using System;
using System.Collections.Generic;
using System.Linq;
using static KomodoClaimsApp.Claim;
using static KomodoClaimsApp.ClaimsRepository;

namespace KomodoClaimsApp
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

        private readonly ClaimsRepository _repo = new ClaimsRepository();

        public void Start()
        {
            SeedClaimList();
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
            Console.WriteLine("Komodo Claims Management Menu - Select a # and press enter. \n" +
                              "1. See All Claims \n" +
                              "2. Handle Next Claim In Queue \n" +
                              "3. Enter New Claim \n" +
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
                    SeeAllClaims();
                    break;
                case "2":
                    HandleNextClaim();
                    break;
                case "3":
                    EnterNewClaim();
                    break;
                case "4":
                    ExitApp();
                    break;
            }
        }

        private void SeeAllClaims()
        {
            List<Claim> claimList = _repo.SeeAllClaims();

            foreach (Claim claim in claimList)
            {
                SeeClaim(claim);
            }

            PressAnyKey();
        }

        private void SeeClaim(Claim claim)
        {
            Console.WriteLine($"Claim ID: {claim.ClaimId}\n" +
                                  $"Claim Type: {claim.Type}\n" +
                                  $"Description: {claim.Description}\n" +
                                  $"Claim Amount: ${claim.ClaimAmount}\n" +
                                  $"Date Of Incident: {claim.DateOfIncident.Date}\n" +
                                  $"Date Of Claim: {claim.DateOfClaim.Date}\n" +
                                  $"IsValid: {claim.IsValid}\n" +
                                   "-------------------------- \n");
        }

        private void HandleNextClaim()
        {
            List<Claim> claimList = _repo.SeeAllClaims();

            Claim oldest = claimList.OrderByDescending(c => c.DateOfClaim).Last();

            SeeClaim(oldest);
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "y":
                        _repo.DeleteClaim(oldest);
                        PressAnyKey();
                        return;
                    case "n":
                        GetMenuSelection();
                        return;
                }
            }
        }

        private void EnterNewClaim()
        {
            Console.Clear();
            Console.WriteLine("Enter the claim ID:");
            string line = Console.ReadLine();
            int claimId;
            if (!int.TryParse(line, out claimId))
            {
                Console.WriteLine("{0} is not an integer", line);
                // Catch
            }

            ClaimType type = GetClaimType();

            Console.WriteLine("Enter a claim description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter claim amount in $USD:");
            string lineTwo = Console.ReadLine();
            double claimAmount;
            if (!double.TryParse(lineTwo, out claimAmount))
            {
                Console.WriteLine("{0} is not an integer", lineTwo);
                // Catch
            }

            Console.WriteLine("Enter date of incident in mm/dd/yyyy format:");
            string lineThree = Console.ReadLine();
            DateTime dateOfIncident;
            if (!DateTime.TryParse(lineThree, out dateOfIncident))
            {
                Console.WriteLine("invalid format");
                // Whatever
            }

            DateTime dateOfClaim = DateTime.Now;
            TimeSpan validityWindow = dateOfClaim.Subtract(dateOfIncident);

            bool isValid = validityWindow.Days < 30;

            Claim claim = new Claim(claimId, type, description, claimAmount, dateOfIncident, dateOfClaim, isValid);

            _repo.CreateClaim(claim);

            PressAnyKey();
        }

        private ClaimType GetClaimType()
        {
            Console.WriteLine("Select a Claim Type - Select a # and press Enter.\n" +
                           "1. Car\n" +
                           "2. Home\n" +
                           "3. Theft\n");

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        return ClaimType.Car;
                    case "2":
                        return ClaimType.Home;
                    case "3":
                        return ClaimType.Theft;
                }
            }
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

        private void SeedClaimList()
        {
            Claim claimOne = new Claim(1, Claim.ClaimType.Car, "Significant front-end damage to silver 2010 Toyota Prius after recent collision.", 2200.00, Convert.ToDateTime("07, 01, 2021"), Convert.ToDateTime("07, 03, 2021"), true);
            Claim claimTwo = new Claim(2, Claim.ClaimType.Theft, "ATV stolen from property overnight.", 8900.00, Convert.ToDateTime("07, 08, 2021"), Convert.ToDateTime("07, 09, 2021"), true);
            _repo.CreateClaim(claimOne);
            _repo.CreateClaim(claimTwo);
            
        }
    }
}
