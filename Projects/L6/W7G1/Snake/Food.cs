using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Food : GameObject
    {
        public Food() : base()
        {

        }
        public Food(char sign):base(sign)
        {
            Generate();
        }
        public void Generate()
        {
            Random random = new Random(DateTime.Now.Second);
            body.Clear();
            body.Add(new Point
            {
                X = random.Next(1, 39),
                Y = random.Next(1, 39)
            });
        }
    }
}
