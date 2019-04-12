using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class GameState
    {
        Worm w = new Worm('O');
        Food f = new Food('@');
        Wall b = new Wall('#');

        public GameState()
        {
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            Console.CursorVisible = false;
        }
        public void Draw()
        {
            w.Draw();
            f.Draw();
            b.Draw();
        }
        void CheckFood()
        {
            if (w.CheckCollision(f.body[0]))
            {
                w.Eat(f.body[0]);
                f.Generate();
            }
        }
        public void PressedKey(ConsoleKeyInfo consoleKeyInfo)
        {
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

            CheckFood();
        }
    }
}
