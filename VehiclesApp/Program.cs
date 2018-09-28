using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Vehicle.Data;

namespace VehicleApp
{
    class Program
    {

        static void Main()
        {
            try
            {
                bool showMain = true;
                Menu instance = new Menu(); // creating a menu object

                int mainMenuSelect = 0;

                do  // loop mainmenu while showMain is true
                {
                    mainMenuSelect = Menu.ShowMainMenu();

                    switch (mainMenuSelect)
                    {
                        case 3:
                            instance.SpeedPrinter();
                            
                            break;
                        case 4:
                            showMain = false;
                            break;
                        default:
                            instance.ListCreateVehiclesOfType(mainMenuSelect);
                            break;
                    }
                } while (showMain == true);

            } catch(Exception e)
            {
                Console.WriteLine("Ett fel uppstod. {0}", e.Message);
                Console.ReadKey();
            }

        }

    }
}
