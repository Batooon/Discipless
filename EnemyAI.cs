using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciples
{
    class EnemyAI
    {
        public int ChangeX { get; private set; }
        public int ChangeY { get; private set; }

        public void RefreshPosition(Player p,Foes f)
        {
            int newX = 0, newY = 0;
            
            if (f.X < p.X)
                newX += 1;

            if (f.Y < p.Y)
                newY += 1;

            else if (f.X > p.X)
                newX -= 1;

            else if (f.Y > p.Y)
                newY -= 1;

            System.Threading.Thread.Sleep(150);

                ChangeX = newX;
                ChangeY = newY;
        }
    }
}
