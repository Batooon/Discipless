using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciples
{
    class Foes:Dude
    {
        //public List<Foes> foes;

        public Foes(int x,int y,int hp,int dmg,char sym)
        {
            X = x;
            Y = y;
            Hp = hp;
            Damage = dmg;
            Show = sym;
            //foes = new List<Foes>();
        }

        public void Draw()
        {
            Console.Write(Show);
        }

        /*public override bool CanMoveTo(int x, int y)
        {
            return base.CanMoveTo(x, y);
        }*/

        public void MoveTo(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
}
