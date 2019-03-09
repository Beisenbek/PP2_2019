using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Snake
{
    class GameState
    {
        System.Timers.Timer timer = new System.Timers.Timer(120);
        System.Timers.Timer gameTime = new System.Timers.Timer(1000);
        Worm worm = new Worm('O');
        Food food = new Food('@');
        Wall wall = new Wall('#');

        public GameState()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            food.Generate(wall.body, worm.body);
        }

        public void Run()
        {
            ThreadStart action = new ThreadStart(ChangeFrame);
            Thread task = new Thread(action);
            task.Start();
            food.Draw();
            wall.Draw();
        }

        public void Run2()
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            gameTime.Elapsed += GameTime_Elapsed;
            gameTime.Start();


            food.Draw();
            wall.Draw();
        }

        private void GameTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            ShowStatusBar2(DateTime.Now.Second.ToString());
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            worm.Clear();
            worm.Move();
            worm.Draw();
            CheckColision();
            ShowStatusBar(worm.body.Count.ToString());
        }

        private void ChangeFrame()
        {
            while (true)
            {
                worm.Clear();
                worm.Move();
                worm.Draw();
                CheckColision();
                Thread.Sleep(400);
            }
        }

        public void PressedKey(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    worm.Dx = 0;
                    worm.Dy = -1;
                    break;
                case ConsoleKey.DownArrow:
                    worm.Dx = 0;
                    worm.Dy = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    worm.Dx = -1;
                    worm.Dy = 0;
                    break;
                case ConsoleKey.RightArrow:
                    worm.Dx = 1;
                    worm.Dy = 0;
                    break;
                case ConsoleKey.Spacebar:
                    timer.Enabled = !timer.Enabled;
                    break;
            }
        }

        void ShowStatusBar(string message)
        {
            Console.SetCursorPosition(10, 37);
            Console.Write(message);
        }

        void ShowStatusBar2(string message)
        {
            Console.SetCursorPosition(10, 38);
            Console.Write(message);
        }

        void CheckColision()
        {
            if (worm.CheckIntersection(food.body) == true)
            {
                worm.Eat(food.body);
                food.Generate(wall.body, worm.body);
                food.Draw();
            }
        }
    }
}
