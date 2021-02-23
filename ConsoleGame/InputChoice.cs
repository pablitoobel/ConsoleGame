using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    class InputChoice
    {
        public static int Choice()
        {
            Console.WriteLine();
            int.TryParse(Console.ReadLine(), out int choice);
            return choice;
        }
    }
}
