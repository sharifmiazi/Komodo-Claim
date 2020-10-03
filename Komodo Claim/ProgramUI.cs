using Komodo_Claim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claim
{
    public class ProgramUI
    {
       
        private bool _isRunning = true;
        private ClaimRepository Claim_Repo = new ClaimRepository();

       
        public void StartRun()
        {
            SeedContent();
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
            Console.WriteLine(
                "Choose a menu item:\n" +
                "1. Check all the claims\n" +
                "2. Check of your next claim\n" +
                "3. Enter a new claim\n" +
                "4. Edit an existing claim\n" +
                "5. Exit");

            string userInput = Console.ReadLine();
            return userInput;
        }

        
        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    DisplayAllClaims();
                    break;
                case "2":
                    DisplayNextClaim();
                    break;
                case "3":
                    CreateAClaim();
                    break;
                case "4":
                    UpdateClaim();
                    break;
                case "5":
                    _isRunning = false;
                    return;
                default:
                    Console.WriteLine("Invalid input.");
                    return;
            }
            Console.WriteLine("");
            Console.WriteLine("Press any key to return to menu.");
            Console.ReadKey();
        }

        // Show all Claims in console, case "1"
        private void DisplayAllClaims()
        {
            Queue<Claim> queueClaims = Claim_Repo.GetClaimQ();

            Console.WriteLine($"{"ClaimID",1} {"Type",1} {"Description",400} {"Amount",400} {"DateOfAccident",4/25/18} {"DateOfClaim",4/27/18} {"IsValid",1}");
            foreach (Claim item in queueClaims)
            {
                Console.WriteLine($"{item.ClaimID,1} {item.ClaimTypes,1} {item.ClaimDescription,400} {item.ClaimAmount,400} {item.DateOfIncident.ToShortDateString(),4/25/18} {item.DateOfClaim.ToShortDateString(),4/27/18} {item.IsValid,1}");
            }
        }

        // See next claim, case "2"
        private void DisplayNextClaim()
        {
            Console.Clear();
            Queue<Claim> queueClaims = Claim_Repo.GetClaimQ();
            bool nextClaim = true;
            while (nextClaim)
            {
                if (queueClaims.Count > 0)
                {
                    var nextInQueue = queueClaims.Peek();
                    DisplaySingleClaim(nextInQueue);
                }
                
                Console.Write("would you like to continue with this claim (y/n)? : ");
                //  y/n input
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "y":
                    case "yes":
                        queueClaims.Dequeue();
                        break;
                    case "n":
                    case "no":
                        GetMenuSelection();
                        break;
                }
            }
        }
        private void DisplaySingleClaim(Claim claim)
        {
            Console.WriteLine($"More Detail fo next Claim:\n" +
                $"ClaimID: {claim.ClaimAmount}\n" +
                $"Type: {claim.ClaimTypes}\n" +
                $"Description: {claim.ClaimDescription}\n" +
                $"Amount: {claim.ClaimAmount}\n" +
                $"DateOfAccident: {claim.DateOfIncident}\n" +
                $"DateOfClaim: {claim.DateOfClaim}\n" +
                $"IsValid: {claim.IsValid}");
        }


        // Enter a new claim, case "3"
        // .date;
        private void CreateAClaim()
        {
            

            Console.WriteLine("put details of the new claim:");
            Console.Write("Enter the claim ID: ");
            int claimID = int.Parse(Console.ReadLine());

            Console.Write("Enter the claim type: ");
            int claimTypes = (int)GetClaimType();

            Console.Write("Enter a claim description: ");
            string claimDescription = Console.ReadLine();

            Console.Write("Amount of Damage: ");
            double claimAmount = double.Parse(Console.ReadLine());

            Console.Write("Date of Accident: ");
            string dateOfAccident = Console.ReadLine();
            DateTime dateOfIncident = Convert.ToDateTime(dateOfAccident);

            Console.Write("Date of Claim: ");
            string dateOfNewClaim = Console.ReadLine();
            DateTime dateOfClaim = Convert.ToDateTime(dateOfNewClaim);

            Console.Write("This claim is valid.");

            Claim newClaim = new Claim(claimID, claimTypes, claimDescription, claimAmount, dateOfIncident, dateOfClaim);
            Claim_Repo.AddClaimToDictionary(newClaim);
        }
        private claimTypes GetClaimType()
        {
            Console.WriteLine("" +
                "1. Home\n" +
                "2. Car\n" +
                "3. Theft\n");
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                    case "Home":
                    case "home":
                        return claimTypes.Home;
                    case "2":
                    case "Car":
                    case "car":
                        return claimTypes.Car;
                    case "3":
                    case "Theft":
                    case "theft":
                        return claimTypes.Theft;
                }
                Console.WriteLine(" please try again.");
            }
        }

        // Modify an existing claim, case "4"
        private void UpdateClaim()
        {
            
            DisplayAllClaims();

            // Propt and get cliam ID #
            Console.Write("Enter the Claim ID you wish to update: ");
            int claimToUpdate = Convert.ToInt32(Console.ReadLine());

            //  new info
            Console.Write("Enter Claim ID: ");
            int newClaimID = int.Parse(Console.ReadLine());

            Console.Write("Enter Claim Type: ");
            int claimTypes = (int)GetClaimType();

            Console.Write("Enter Description: ");
            string newDescription = Console.ReadLine();

            Console.Write("Enter Claim Amount: $");
            double newAmount = double.Parse(Console.ReadLine());

            Console.Write("Date of Accident: ");
            string accidentInput = Console.ReadLine();
            DateTime dateOfAccident = Convert.ToDateTime(accidentInput);

            Console.Write("Date of Claim: ");
            string claimDateInput = Console.ReadLine();
            DateTime dateOfClaim = Convert.ToDateTime(claimDateInput);

            Claim newClaim = new Claim(newClaimID, claimTypes, newDescription, newAmount, dateOfAccident, dateOfClaim);

            bool verifyUpdate = Claim_Repo.UpdateClaimContent(claimToUpdate, newClaim);

            if (verifyUpdate)
            {
                Console.WriteLine("Claim is updated.");
            }
            else
            {
                Console.WriteLine("please try again.");
            }
        }
        public void SeedContent()
        {
            Claim claim1 = new Claim(1, ClaimTypes.Car, "Testing .", 120000, new DateTime(2020, 1, 1), new DateTime(2020, 10, 03));
            Claim claim2 = new Claim(2, ClaimTypes.Home, "More seed data to test.", 2000000, new DateTime(2020, 10, 03).Date, DateTime.Now.Date);
            Claim claim3 = new Claim(3, ClaimTypes.Theft, "Testing.", 150000, DateTime.Now.Date, DateTime.Now.Date);

            Claim_Repo.AddClaimToDirectory(claim1);
            Claim_Repo.AddClaimToDirectory(claim2);
            Claim_Repo.AddClaimToDirectory(claim3);

        }
    }


}