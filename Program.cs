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
            Field field = new Field();
            field.ShowCoordinates();
            /*Foes enemies = new Foes(4);
            enemies.Draw();*/
        }
        static void Main(string[] args)
        {
            Randomchik.Init();
            Init();
        }
    }
}
