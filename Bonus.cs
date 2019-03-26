using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;
using System.Xml;

namespace Disciples
{
    class Bonus
    {
        public string name;
        public int X;
        public int Y;
        public char Show = '$';
        public ConsoleColor FColor;
        public ConsoleColor BColor;
        public int AddHp = 0;
        public bool IsInvulnerability = false;

        public Bonus()
        {

        }

        public Bonus(int x,int y)
        {
            X = x;
            Y = y;
        }

        public Bonus(Bonus other)
        {
            name = other.name;
            FColor = other.FColor;
            BColor = other.BColor;
            AddHp = other.AddHp;
        }

        public void DrawBonus()
        {
            Console.Write(Show);
        }

        public void Activate(ref bool bonus,ref int hp)
        {
            bonus = true;
            switch (name)
            {
                case "invulnerability":
                    IsInvulnerability = true;
                    break;
                case "SHeal":
                    hp += AddHp;
                    break;
                case "MHeal":
                    hp += AddHp;
                    break;
                case "BHeal":
                    hp += AddHp;
                    break;
            }
        }
    }
}
