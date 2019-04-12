using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Snake
{
    public class GameState
    {
        public Worm w = new Worm('O');
        public Food f = new Food('@');
        public Wall b = new Wall('#');
        Timer timer = new Timer();
        Timer timer2 = new Timer();
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameState));

        public GameState()
        {
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            Console.CursorVisible = false;
        }

        public void Save()
        {
            using (FileStream fileStream = new FileStream("game.xml", FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fileStream, this);
            }
        }

        public void Reset()
        {
            Console.Clear();
            timer.Elapsed -= Timer_Elapsed;
        }

        public GameState Load()
        {
            GameState res = null;
            using (FileStream fileStream = new FileStream("game.xml", FileMode.Open, FileAccess.Read))
            {
                res = xmlSerializer.Deserialize(fileStream) as GameState;
            }

            return res;
        }
        public void Run()
        {
            timer2.Elapsed += ChangeTime;
            timer2.Interval = 1000;
            timer2.Start();

            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 120;
            timer.Start();

            f.Draw();
            b.Draw();
        }

        private void ChangeTime(object sender, ElapsedEventArgs e)
        {
            Console.SetCursorPosition(0, 37);
            Console.WriteLine(DateTime.Now.Second);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            w.Clear();
            w.Move();
            w.Draw();
            CheckFood();
        }

        void CheckFood()
        {
            if (w.CheckCollision(f.body[0]))
            {
                w.Eat(f.body[0]);
                f.Generate();
                f.Draw();
            }
        }
        public void PressedKey(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    w.Dx = 0;
                    w.Dy = -1;
                    break;
                case ConsoleKey.DownArrow:
                    w.Dx = 0;
                    w.Dy = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    w.Dx = -1;
                    w.Dy = 0;
                    break;
                case ConsoleKey.RightArrow:
                    w.Dx = 1;
                    w.Dy = 0;
                    break;
                case ConsoleKey.Spacebar:
                    timer.Enabled = !timer.Enabled;
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }

           
        }
    }
}
