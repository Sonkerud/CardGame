using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLibrary.Utils
{
    public static class InputControl
    {
        public static int ControlIntInput(int from, int to)
        {
            int value = 0;
            bool inmatning = false;
            while (!inmatning)
            {
                try
                {
                    value = int.Parse(Console.ReadLine());
                    if (value >= from && value <= to)
                    {
                        inmatning = true;
                    }
                    else
                    {
                        Console.WriteLine($"Input number between {from} - {to}");
                    }
                  
                }
                catch (Exception)
                {
                    Console.WriteLine("Input valid number");
                }
            }
            return value;
        }
    }
}
