using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciples
{
    class Player:Dude
    {
        public Player(int x,int y,int hp,int dmg,char sym)
        {
            X = x;
            Y = y;
            Hp = hp;
            Damage = dmg;
            Show = sym;
        }

        public void Draw()
        {
            Console.Write(Show);
        }
        public void MoveTo(int x,int y)
        {
            X = x;
            Y = y;
        }
        public void ShowHP()
        {
            Console.Write("HP: " + Hp);
        }

    }
}
