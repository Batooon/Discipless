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
        public int AmountOfFood;
        public char Show = '*';

        public void DrawFood()
        {
            Console.Write(Show);
        }

        public Food(int x,int y,int n)
        {
            X = x;
            Y = y;
            AmountOfFood = n;
        }
    }
}
