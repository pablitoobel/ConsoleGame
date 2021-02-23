using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace ConsoleGame
{
    class Options
    {
        public static void OptionsMenu()
        {
            Console.WriteLine("1. Difficulty");
            Console.WriteLine("2. Volume");
            Console.WriteLine("3. Graphics");
            Console.WriteLine("4. Exit");

            int choice = InputChoice.Choice();
            switch (choice)
            {
                case 1:
                    {
                        break;
                    }
                case 2:
                    {

                        break;
                    }
                case 3:
                    {

                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        StartScreen.MainOptions();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Choose again");
                        Thread.Sleep(1000);
                        Console.Clear();
                        OptionsMenu();
                        break;
                    }
            }
        }
    }
}
