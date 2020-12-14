using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeRepo
{
    public class MenuRepository
    {
        public List<MenuDataModel> FullListOfMenuItems = new List<MenuDataModel>();
      
        public void CreateAMenuItem()
        {
            MenuDataModel newMenuItem = new MenuDataModel();
            Console.WriteLine("What is the meal number? ");
            string menuItem = Console.ReadLine();
            newMenuItem.MealNumber = int.Parse(menuItem);

            Console.WriteLine("What is the meal name? ");
            newMenuItem.MealName = Console.ReadLine();

            //asking the user for the description, shoving it into the description variable (through the newMenuItem "window")
            Console.WriteLine("What is the description for the meal? ");
            newMenuItem.Description = Console.ReadLine();

            List<string> ingredientEntry = new List<string>();
            string userEntry;
            Console.WriteLine("What are the ingredients? Enter the ingredients one at a time. Enter a blank line when done. ");
            do
            {
                userEntry = Console.ReadLine();
                if (userEntry != "")
                {
                    ingredientEntry.Add(userEntry);
                }
            }
            while (userEntry != "");
            newMenuItem.Ingredients = ingredientEntry;

            Console.WriteLine("What is the price? ");
            menuItem = Console.ReadLine();
            newMenuItem.Price = decimal.Parse(menuItem);

            FullListOfMenuItems.Add(newMenuItem);

        }
        //read method - showing you the entire menu
        public void GetAllMenuItems()
        {
            List<string> thisIngredients = new List<string>();
            string returnString = "";
            string IngredientsString = "";
            foreach (MenuDataModel Snacks in FullListOfMenuItems)
            {
                returnString += Snacks.MealNumber + ": " +
                                Snacks.MealName + " - " +
                                Snacks.Description + " " +
                                //Snacks.Ingredients + " " +
                                "$ " + Snacks.Price.ToString();
                returnString += "\n    ";

                thisIngredients = Snacks.Ingredients;

                IngredientsString = "";
                foreach(string thisString in thisIngredients)
                {
                    IngredientsString += thisString + ", ";
                }
                returnString += IngredientsString;
                returnString += "\n";
            }            
            Console.WriteLine(returnString);
        }

        public void RemoveAMenuItem()
        {
            Console.WriteLine("What is the meal number you want to remove? ");
            string stringMealNumber = Console.ReadLine();
            int intMealNumber = int.Parse(stringMealNumber);
           
            int recordnumber = 0;
            recordnumber = FullListOfMenuItems.FindIndex(x => { return x.MealNumber == intMealNumber; });
            if (recordnumber != -1)

            {
                FullListOfMenuItems.RemoveAt(recordnumber);
                Console.WriteLine("Menu item "+ stringMealNumber +" has been removed");

            }
            else
            {
                Console.WriteLine("Menu item " + stringMealNumber + " was not found. Please try again. ");
            }


        }

        public void loaddata()
        {

            List<string> s1 = new List<string>();

            s1.Add("Chicken");

            s1.Add("Bell Peppers");

            s1.Add("Onions");

            s1.Add("Red Hot Sauce");

            MenuDataModel m1 = new MenuDataModel(1, "Szechuan Chicken", "Hot spicy chicken with hot red sauce and veggies", s1, decimal.Parse("12.95"));



            s1.Clear();

            s1.Add("Eggs");

            s1.Add("Foo");

            s1.Add("Young");

            MenuDataModel m2 = new MenuDataModel(2, "Egg Foo Yung", "An Asian omelette with vegetables", s1, decimal.Parse("13.50"));



            s1.Clear();

            s1.Add("Beef Broth");

            s1.Add("Green Onions");

            s1.Add("Wontons");

            s1.Add("Hot Oil");

            MenuDataModel m3 = new MenuDataModel(3, "Wonton Soup", "Beef broth with onions and Asian dumplings.", s1, decimal.Parse("7.25"));



            s1.Clear();

            s1.Add("Beef");

            s1.Add("Onions");

            s1.Add("Brown Sauce");

            s1.Add("Steamed Rice");

            s1.Add("Brown Sauce");

            MenuDataModel m4 = new MenuDataModel(4, "Mongolian Beef", "Beef with onions and brown sauce over rice", s1, decimal.Parse("15.99"));



            s1.Clear();

            s1.Add("Cabbage");

            s1.Add("Carrots");

            s1.Add("Onions");

            s1.Add("Wonton wrap");

            s1.Add("Scallions");

            MenuDataModel m5 = new MenuDataModel(5, "Spring Roll", "Vegetables rolled in wonton wrap and deep fried", s1, decimal.Parse("4.99"));



            FullListOfMenuItems.Add(m1);

            FullListOfMenuItems.Add(m2);

            FullListOfMenuItems.Add(m3);

            FullListOfMenuItems.Add(m4);

            FullListOfMenuItems.Add(m5);
         
           
        }
    }
}
