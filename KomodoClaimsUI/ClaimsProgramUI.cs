using KomodoClaimsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KomodoClaimsUI
{
    class ClaimsProgramUI
    {
        //Method that runs the app
        public void Run()
        {
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display options to the user

                Console.WriteLine("Select a menu option:\n" +
                    "1. See All Claims\n" +
                    "2. Take Care of The Next Claim in The Queue\n" +
                    "3. Enter a New Claim\n" +
                    "20. Exit The Program");

                //Get the users input
                string input = Console.ReadLine();

                //Evaluate user input and act accordingly
                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;

                    case "2":
                        NextClaim();
                        break;

                    case "3":
                        EnterNewClaim();
                        break;

                    case "20":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void SeeAllClaims()
        {
            ClaimsRepository claimsRepository = new ClaimsRepository();
            Queue<ClaimContent> claimQueue;
            claimQueue = claimsRepository.GetClaimsQueue();

            ClaimContent[] claimArray = new ClaimContent[claimQueue.Count];
            claimQueue.CopyTo(claimArray, 0);

            foreach (ClaimContent item in claimArray)
            {
                Console.WriteLine(item.ClaimID + " " +
                                  item.ClaimType + " " +
                                  item.ClaimAmount + " " +
                                  item.DateOfIncident + " " +
                                  item.DateOfClaim + " " +
                                  item.IsValid + "\n"
                                  );
            }
        }

        private void NextClaim()
        {
            ClaimsRepository nextClaim = new ClaimsRepository();
            ClaimContent thisClaim;
            thisClaim = nextClaim.DisplayClaim();
            Console.WriteLine(thisClaim.ClaimID + " " +
                                  thisClaim.ClaimType + " " +
                                  thisClaim.ClaimAmount + " " +
                                  thisClaim.DateOfIncident + " " +
                                  thisClaim.DateOfClaim + " " +
                                  thisClaim.IsValid + "\n"
                                  );
            Console.WriteLine("Do you want to deal with this claim now(y/n)? ");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "y")
            {
                nextClaim.TakeCareOfNextClaim();
            }

        }

        private void EnterNewClaim()
        {
            ClaimsRepository claimsRepo = new ClaimsRepository();
            ClaimContent newClaim = new ClaimContent();
            Console.WriteLine("Enter Claim ID: ");
            newClaim.ClaimID = Console.ReadLine();


            Console.WriteLine("Indicate your claim type - \n" +
                "1. for Car\n" +
                "2. for Home\n" +
                "3. for Theft");
            string tempVar = Console.ReadLine();
            int temp2 = int.Parse(tempVar);
            //finds the enum value from the claimtype number
            newClaim.ClaimType = (ClaimType)temp2;

            Console.WriteLine("Enter claim description: ");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter Claim Amount: ");
            tempVar = Console.ReadLine();
            newClaim.ClaimAmount = decimal.Parse(tempVar);


            Console.WriteLine("Enter the date of accident as yyyy-mm-dd: ");
            tempVar = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(tempVar);


            Console.WriteLine("Enter the claim date as yyyy-mm-dd: ");
            tempVar = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(tempVar);

            double differenceInDates;
            differenceInDates = (newClaim.DateOfClaim - newClaim.DateOfIncident).TotalDays;
            if(differenceInDates > 30)
            {
                newClaim.IsValid = false;
            }
            else
            {
                newClaim.IsValid = true;
            }       

            claimsRepo.AddClaimToQueue(newClaim);
        }

    }
}

