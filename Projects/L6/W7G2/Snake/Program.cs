using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static ConsoleKeyInfo consoleKeyInfo;
        static GameState gameState = new GameState();
        static void Main(string[] args)
        {
            Task task = new Task(new Action(DoIt));
            task.Start();
            gameState.Run();

            while (true)
            {
                gameState.ChangeFrame();
                Thread.Sleep(120);
            }
        }

        static void DoIt()
        {
            while (true)
            {
                consoleKeyInfo = Console.ReadKey();

                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.F2:
                        gameState.Save();
                        break;
                    case ConsoleKey.F3:
                        Console.Clear();
                        gameState = gameState.Load();
                        gameState.Run();
                        break;
                    default:
                        gameState.ProcessKey(consoleKeyInfo);
                        break;
                }
            }
        }
    }
}
