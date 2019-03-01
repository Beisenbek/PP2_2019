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
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            Console.CursorVisible = false;
            Worm w = new Worm('O');

            Food f = new Food('@');

            while (true)
            {
                w.Draw();
                f.Draw();

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        w.Move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        w.Move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        w.Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        w.Move(1, 0);
                        break;
                }

            }
        }
    }
}
