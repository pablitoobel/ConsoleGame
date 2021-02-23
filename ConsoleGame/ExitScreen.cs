using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleGame
{
    class ExitScreen
    {
        public static void EndTheGame()
        {
            Console.Clear();
            string e = "   GAME OVER   ";
            Console.SetCursorPosition((Console.WindowWidth - e.Length)/2, Console.WindowHeight/2);
            Console.WriteLine(e);
            Thread.Sleep(2000);
            Console.Clear();
        }
    }
}
