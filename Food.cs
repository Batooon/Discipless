using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciples
{
    class Food
    {
        public int X;
        public int Y;
        public char Show = '*';

        public void DrawFood()
        {
            Console.Write(Show);
        }

        public Food(int x,int y)
        {
            X = x;
            Y = y;
        }

        public void UpdateScore(ref int score)
        {
            score += 1;
        }
    }
}
