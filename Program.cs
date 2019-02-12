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
            /*Foes enemies = new Foes();
            enemies.Draw();*/
            RandomEnemyName name = new RandomEnemyName();
            name.Read();
            name.Show();
        }
        static void Main(string[] args)
        {
            Randomchik.Init();
            Init();
        }
    }
}
