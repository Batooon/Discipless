using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciples
{
    class Randomchik
    {
        static Random kubik;

        public static void Init()
        {
            kubik = new Random();
        }

        public static int Next(int a, int b)
        {
            return kubik.Next(a, b);
        }
    }
}
