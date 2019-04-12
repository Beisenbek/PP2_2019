using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            GameState game = new GameState();
            while (true)
            {
                game.Draw();
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                game.ProcessKeyEvent(consoleKeyInfo);
            }
        }
    }
}
