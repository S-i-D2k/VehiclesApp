using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApp
{
    class NewReadLine
    {

        public static string ReadLine() 
        {                               
            string returnString = "";
            ConsoleKeyInfo keyInput;

            while (true)
            {
                keyInput = Console.ReadKey(true);
                switch (keyInput.Key)
                {
                    case ConsoleKey.Subtract:
                    case ConsoleKey.OemMinus:
                        return "-";
                    case ConsoleKey.Escape:
                        return "esc";
                    case ConsoleKey.Enter:
                        return returnString;
                    case ConsoleKey.Backspace:
                        if (!(returnString.Length == 0))
                        {
                            returnString = returnString.Remove(returnString.Length - 1);
                            Console.Write("\b \b");
                        }
                        break;
                    default:
                        if (Char.IsDigit(keyInput.KeyChar))
                        {
                            Console.Write(keyInput.KeyChar);
                            returnString = returnString + keyInput.KeyChar;
                        }
                        break;
                }
            }
        }
    }
}
