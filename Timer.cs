using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciples
{
    class Timer
    {
        public int LeftPosiiton, TopPosition;

        public Timer(int left,int top)
        {
            LeftPosiiton = left;
            TopPosition = top;
        }
        public void InitTimer(int seconds)
        {
            Console.SetCursorPosition(LeftPosiiton, TopPosition);
            for (int s = seconds; s >= 0; s--)
            {
                if (s == 0)
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.Write($"\r{s}");
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
