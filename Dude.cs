using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciples
{
    class Dude
    {
        public Dude(int h,int d,string n)
        {
            Hp = h;
            Damage = d;
            Name = n;
        }
        public int Hp;
        public int Damage;
        public string Name;

        public void Init()
        {
            Console.WriteLine("Hello, my name is " + Name +
                "\nHealth = " + Hp +
                "\nDamage = " + Damage);
            Console.WriteLine();
        }
        public void Death(Dude dead)
        {
            Console.WriteLine(dead.Name + " подох");
        }
        public void Attack(Dude aim)
        {
            aim.Hp -= Damage;
            if (aim.Hp <= 0)
                Death(aim);
            else
                aim.Init();
        }
    }
}
