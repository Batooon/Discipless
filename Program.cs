using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciples
{
    class Program
    {
        static void Init()
        {
            Dude player = new Dude(200,100,"Pidor");
            Dude enemy = new Dude(100, 10, "Рикардо Милос епт");

            player.Init();
            enemy.Init();
            player.Attack(enemy);
        }
        static void Main(string[] args)
        {
            Randomchik.Init();
            Init();
        }
    }
}
