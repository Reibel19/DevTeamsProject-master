using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamUI
{
    class ProgramUI
    {
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();

        public void Run()
        {
            SeedDevTeamList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add a Developer to the Repository\n" +
                    "2. View All Developers\n" +
                    "3. View Pluralsight Access\n" +
                    "4. Update Developer Info\n" +
                    "5. Delete Developer from Repository\n" +
                    "6. Create a Developer Team\n" +
                    "7. Add Developer to Existing Team\n" +
                    "8. Remove Developer from Existing Team\n" +
                    "9. Delete Entire Developer Team\n" +
                    "10. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewDeveloper();
                        break;
                    case "2":
                        DisplayAllDev();
                        break;
                    case "3":
                        DisplayAccessByNumber();
                        break;
                    case "4":
                        UpdateDevInfo();
                        break;
                    case "5":
                        DeleteDev();
                        break;
                    case "10":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;

                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

        }

        private void AddNewDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            Console.WriteLine("Enter the name of the new Developer:");
            newDeveloper.Name = Console.ReadLine();

            Console.WriteLine("Enter the ID Number of the new Developer:");
            newDeveloper.IDNumber = Console.ReadLine();

            Console.WriteLine("Does the Developer have access to Pluralsight? (y/n)");
            string accessToPluralsight = Console.ReadLine().ToLower();

            if (accessToPluralsight == "y")
            {
                newDeveloper.PluralsightAccess = true;
            }
            else
            {
                newDeveloper.PluralsightAccess = false;
            }

            _devTeamRepo.AddDeveloperToRepo(newDeveloper);
        }

        private void DisplayAllDev()
        {
            Console.Clear();

            List<Developer> listOfDev = _devTeamRepo.GetDevList();

            foreach (Developer dev in listOfDev)
            {
                Console.WriteLine($"Name: {dev.Name}\n" +
                    $"ID Number: {dev.IDNumber}\n");
            }
        }

        private void DisplayAccessByNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID Number of the Developer you would like to see:");

            string idNumber = Console.ReadLine();

            Developer dev = _devTeamRepo.GetDevByNumber(idNumber);

            if (dev != null)
            {
                Console.WriteLine($"Name: {dev.Name}\n" +
                    $"ID Number: {dev.IDNumber}\n" +
                    $"Access to Pluralsight: {dev.PluralsightAccess}")
            }
            else
            {
                Console.WriteLine("No Developer with that ID.");
            }
        }


        private void UpdateDevInfo()
        {
            DisplayAllDev();

            Console.WriteLine("Enter the name of the Developer you would like to update:");

            string oldName = Console.ReadLine();

            Developer newDeveloper = new Developer();

            Console.WriteLine("Enter the Developer name:");
            newDeveloper.Name = Console.ReadLine();

            Console.WriteLine("Enter the ID number for the Developer");
            newDeveloper.IDNumber = Console.ReadLine();

            Console.WriteLine("Does this developer have access to Pluralsight? (y/n)");
            string accessToPluralsight = Console.ReadLine().ToLower();

            if (accessToPluralsight == "y")
            {
                newDeveloper.PluralsightAccess = true;
            }
            else
            {
                newDeveloper.PluralsightAccess = false;
            }

            bool wasUpdated = _devTeamRepo.UpdateDevInfo(oldName, newDeveloper);

            if (wasUpdated)
            {
                Console.WriteLine("Developer successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update Developer.");
            }
        }

        private void DeleteDev()
        {
            DisplayAllDev();

            Console.WriteLine("\nEnter the name of the Developer you'd like to delete:");

            string input = Console.ReadLine();

            bool wasDeleted = _devTeamRepo.RemoveDevFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The Developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The Developer couldn't be deleted.");
            }
        }

        private void SeedDevList()
        {
            Developer james = new Developer("James", "47", true);
            Developer anna = new Developer("Anna", "32", false);

            _devTeamRepo.AddNewDeveloper(james);
            _devTeamRepo.AddNewDeveloper(anna);
        }
    }
}
