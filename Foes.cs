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

        public Foes()
        {
            foes = new List<Dude>();
            Dude enemy1 = new Dude(100, 20, "Лох", '*');
            Dude enemy2 = new Dude(100, 20, "Лошара", '*');
            Dude enemy3 = new Dude(100, 20, "Какашка", '*');
            foes.Add(enemy1);
            foes.Add(enemy2);
            foes.Add(enemy3);
        }
        public void Draw()
        {
            foreach(Dude d in foes)
                d.Init();
        }
    }
}
