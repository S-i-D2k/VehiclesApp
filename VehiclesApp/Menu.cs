using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Data;

namespace VehicleApp
{
    public class Menu
    {
        Vehicles vehiclesList = new Vehicles();


        public static int ShowMainMenu()
        {
            string[] menu = {      "1. Print/Create cars",
                                   "2. Print/Create boats",
                                   "3. Print/Create motorcycles",
                                   "4. Print all vehicles in m/s",
                                   "5. Exit program"};
            int curItem = 0, c;
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
                Console.WriteLine("-- Please Select --");

                // Looping through menu items
                for (c = 0; c < menu.Length; c++)
                {
                    if (curItem == c)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menu[c]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else    Console.WriteLine(menu[c]);
                    
                }

                Console.Write("Select your choice with the arrow keys.");
                key = Console.ReadKey(true);


                if (key.Key == ConsoleKey.DownArrow)
                {
                    curItem++;
                    if (curItem > menu.Length - 1)
                        curItem = 0;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    curItem--;
                    if (curItem < 0)
                        curItem = menu.Length - 1;
                }
            } while (key.Key != ConsoleKey.Enter); // Exit loop and returns selection if 
                                                   // enter is pressed.

            return curItem;
        }

        public void ListCreateVehiclesOfType(int selection) // Prints out the selected type of objects
        {                                                   // and lets you add or edit them.
            List<IVehicle> sortedList = new List<IVehicle>();
            string type = "";
            int curItem = 0, c = 0;
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
                // extract corresponding objects depending on choice in mainmenu and insert into a new list
                if (selection == 0)
                {
                    sortedList = vehiclesList.GetCars();
                    type = "cars";
                }
                else if (selection == 1)
                {
                    sortedList = vehiclesList.GetBoats();
                    type = "boats";
                }
                else if (selection == 2)
                {
                    sortedList = vehiclesList.GetMotorcycles();
                    type = "motorcycles";
                }
                if (sortedList.Count == 1)
                {
                    string oneVehicle = type.Remove(type.Length - 1);
                    Console.WriteLine("-- {0} {1} in list--", sortedList.Count, oneVehicle);
                }
                else
                    Console.WriteLine("-- {0} {1} in list--", sortedList.Count, type);
                

                // Looping through menu items
                for (c = 0; c < sortedList.Count; c++)
                {
                    if (curItem == c)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("{0} {1} - {2}", type, c, sortedList[c].GetSpeed());
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else    Console.WriteLine("{0} {1} - {2}", type, c, sortedList[c].GetSpeed());
                    
                }

                Console.Write("Select item to edit with the arrow keys. Press + to add an item or press ESC to go back to previous menu.");
                key = Console.ReadKey(true);


                if (key.Key == ConsoleKey.DownArrow)  
                {
                    curItem++;
                    if (curItem > sortedList.Count - 1) // go to top of menu if at end of menu
                        curItem = 0; 
                }

                else if (key.Key == ConsoleKey.UpArrow)
                {
                    curItem--;
                    if (curItem < 0) // and vice versa
                        curItem = sortedList.Count - 1; 
                }

                else if (key.Key == ConsoleKey.OemPlus || key.Key == ConsoleKey.Add)
                {
                    if (sortedList.Count == 9)
                    {
                        Console.WriteLine("\nMax number of vehicles (9) for this type has been reached.");
                        Console.ReadKey();
                    }
                    else
                    {
                        if (type == "cars")
                            vehiclesList.Add(vehiclesList.Factory(Vehicles.Types.Car));

                        else if (type == "boats")
                            vehiclesList.Add(vehiclesList.Factory(Vehicles.Types.Boat));

                        else if (type == "motorcycles")
                            vehiclesList.Add(vehiclesList.Factory(Vehicles.Types.Motorcycle));
                    }
                }

                if (key.Key == ConsoleKey.Enter && sortedList.Count > 0)
                {
                    int speedToSet;

                    speedToSet = Edit.EditRemoveVehicle(type, curItem, (int)sortedList[curItem].Speed);

                    if (speedToSet >= 0 && speedToSet < 101)
                        vehiclesList.Select(sortedList[curItem]).SetSpeed((double)speedToSet);
                    
                    else if (speedToSet == 555)
                        vehiclesList.Remove(sortedList[curItem]);
                    

                }
            } while (key.Key != ConsoleKey.Escape ); // Exit if esc is pressed

        }

        public void SpeedPrinter() // Lists vehicles of all types and their speed in meters per second
        {
            List<IVehicle> carsList = vehiclesList.GetCars();
            List<IVehicle> boatsList = vehiclesList.GetBoats();
            List<IVehicle> motorcyclesList = vehiclesList.GetMotorcycles();

            Console.Clear();
            Console.WriteLine("-- {0} cars in stock --", carsList.Count);
            for (int c = 0; c < carsList.Count; c++)
            {
                Console.Write("Car {0} - ", c );
                Vehicles.PrintSpeedInMetersPerSecond(carsList[c]);
            }
            Console.WriteLine("-- {0} boats in stock --", boatsList.Count);
            for (int c = 0; c < boatsList.Count; c++)
            {
                Console.Write("Boat {0} - ", c);
                Vehicles.PrintSpeedInMetersPerSecond(boatsList[c]);
            }
            Console.WriteLine("-- {0} motorcycles in stock --", motorcyclesList.Count);
            for (int c = 0; c < motorcyclesList.Count; c++)
            {
                Console.Write("Motorcycle {0} - ", c);
                Vehicles.PrintSpeedInMetersPerSecond(motorcyclesList[c]);
            }
            Console.WriteLine("Press any key to go back to main menu.");
            Console.ReadKey();
        }

    }
}
