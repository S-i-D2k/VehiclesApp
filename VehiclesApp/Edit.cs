using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApp
{
    class Edit
    {
        public static int EditRemoveVehicle(string type, int count, int speed)
        {
            string input = "";
            int parsedInput;
            type = type.Remove(type.Length - 1);

            do
            {
                Console.Clear();
                Console.WriteLine("-- {0} {1} --", type, count);
                Console.WriteLine("Speed: {0}", speed);
                Console.WriteLine("Please enter new speed(0 - 100) or – to remove {0}. Press escape to cancel.", type);
                input = NewReadLine.ReadLine();        // Custom Readline that only accepts numbers and reacts to minus and backspace
                if (input == "-")
                    return 555;    // return 555 to delete object
                if (input == "esc")
                    return speed;  // returns original speed to go back to previous menu
            }
            while (!Int32.TryParse(input, out parsedInput) || (parsedInput > 100) || (parsedInput < 0));

            return parsedInput;
        }
    }
}
