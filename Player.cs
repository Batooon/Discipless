using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciples
{
    class Player:Dude
    {
        public int score = 0;
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

        public void ShowScore()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Score: " + score);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void MoveTo(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
}
