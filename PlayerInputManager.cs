using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciples
{
    class PlayerInputManager
    {
        public int ChangeX { get; private set; }
        public int ChangeY { get; private set; }

        public void RefreshInput()
        {
            int newX = 0, newY = 0;

            while (Console.KeyAvailable)
            {
                ConsoleKey Key = Console.ReadKey().Key;

                switch (Key)
                {
                    case ConsoleKey.W:
                        newX--;
                        break;
                    case ConsoleKey.S:
                        newX++;
                        break;
                    case ConsoleKey.A:
                        newY--;
                        break;
                    case ConsoleKey.D:
                        newY++;
                        break;
                }
            }

            ChangeX = newX;
            ChangeY = newY;
        }
    }
}
