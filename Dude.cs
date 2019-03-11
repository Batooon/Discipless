using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciples
{
    class Dude
    {
        public int X;
        public int Y;
        public char Show;
        public int Hp;
        public int Damage;

        public virtual bool CanMoveTo(int x,int y,int width,int height)
        {
            if (x < 0 || y < 0 || x > width || y > height)
                return false;

            return true;
        }

        /*public Dude(int h,int d,char s,int x,int y)
        {
            Hp = h;
            Damage = d;
            Show = s;
            X = x;
            Y = y;
        }*/
    }
}
