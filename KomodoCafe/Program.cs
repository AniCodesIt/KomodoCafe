using KomodoCafeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    class Program
    {
       
        static void Main(string[] args)
        {
            MenuRepository menuRepository = new MenuRepository();
            menuRepository.loaddata();

            
                bool isRunning = true;
                while (isRunning)
                {
                Console.WriteLine("Welcome to Komodo Cafe App\n" +
                    "1. View the full menu\n" +
                    "2. Create a new menu item\n" +
                    "3. Delete an item from the menu\n" +
                    "20. Closes the program");                       

                    var userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            menuRepository.GetAllMenuItems();
                            break;
                        case "2":
                          menuRepository.CreateAMenuItem();
                            break;
                        case "3":
                            menuRepository.RemoveAMenuItem();
                            break;
                        case "20":
                        isRunning = false;
                        break;
                        default:
                            break;
                    }
                }
                Console.Clear();         
  




        }
    }

}
