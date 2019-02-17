using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciples
{
    class Foes
    {
        List<Dude> foes;

        public Foes(int N)//N - количество врагов
        {
            foes = new List<Dude>();

            for(int i = 0; i < N; i++)
            {
                foes.Add(new Dude(Randomchik.Next(90, 110), Randomchik.Next(15, 25), '*'));
            }
        }
        public void Draw()//Вывод всех врагов на поле
        {
            foreach(Dude d in foes)
            {
                Console.BackgroundColor = ConsoleColor.Red;

                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}
