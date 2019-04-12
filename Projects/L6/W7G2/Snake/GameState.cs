using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Serialization;

namespace Snake
{
    public class GameState
    {
        public Worm worm = new Worm('O');
        public Food food = new Food('@');
        public Wall wall = new Wall('#');

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameState));

        public GameState()
        {
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            Console.CursorVisible = false;
            Console.Clear();
            wall.Draw();
        }
        public void Run()
        {
            food.Generate(worm.body, wall.body);
            food.Draw();
        }
        
        public void ChangeFrame()
        {
            worm.Clear();
            worm.Move();
            worm.Draw();

            PrintInfo(worm.body[0].ToString() + "===" + food.body[0].ToString());

            CheckCollision();
        }
        public void CheckCollision()
        {
            if (worm.CheckIntersection(food.body[0]))
            {
                worm.Eat(food.body[0]);
                food.Generate(worm.body, wall.body);
                food.Draw();
            }
        }

        public void Save()
        {
            using (FileStream stream = new FileStream("game.xml", FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(stream, this);
            }
        }

        public GameState Load()
        {
            GameState gameState = null;
            using (FileStream stream = new FileStream("game.xml", FileMode.Open, FileAccess.Read))
            {
                gameState = xmlSerializer.Deserialize(stream) as GameState;
            }
            return gameState;
        }

        public void PrintInfo(string message)
        {
            Console.SetCursorPosition(0, 37);
            Console.Write(message);
        }

        public void ProcessKey(ConsoleKeyInfo consoleKeyInfo)
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
            }
        }
    }
}
