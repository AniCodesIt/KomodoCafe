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

            
            string returnMenu = menuRepository.GetAllMenuItems();
            Console.WriteLine(returnMenu);
            Console.ReadLine();




        }
    }

}
