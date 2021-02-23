using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleGame
{
    class StartScreen
    {
        public static void MainOptions()
        {
            Console.WriteLine("1. Start the game");
            Console.WriteLine("2. Options");
            Console.WriteLine("3. Exit");
            MainOptionsSwitch();
        }

        public static void MainOptionsSwitch()
        {
            int choice = InputChoice.Choice();
            switch (choice)
            {
                case 1:
                    {
                        Console.Clear();
                        Game.GameLogic();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Options.OptionsMenu();
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        ExitScreen.EndTheGame();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Choose again");
                        Thread.Sleep(1000);
                        Console.Clear();
                        MainOptions();
                        break;
                    }
            }
        }

    }
}
