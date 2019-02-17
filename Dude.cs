using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciples
{
    class Dude
    {
        public Dude(int h,int d,char s)
        {
            Hp = h;
            Damage = d;
            Show = s;
        }
        public char Show;
        public int Hp;
        public int Damage;

        public void Death(Dude dead)
        {
            Console.WriteLine(/*dead.Name + " подох"*/);
        }
        public void Attack(Dude aim)
        {
            /*aim.Hp -= Damage;
            if (aim.Hp <= 0)
                Death(aim);
            else
                aim.Init();*/
        }
    }
}
