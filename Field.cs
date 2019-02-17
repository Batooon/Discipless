using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciples
{
    class Field
    {
        char[,] field;
        const int x = 8, y = 8;
        int number = 1;

        public Field()
        {
            field = new char[x, y];

            for(int i = 0; i < y; i++)
            {
                for(int j = 0; j < x; j++)
                {
                    field[i, j] = '#';
                }
            }

            for(int i = 0; i < y; i++)
            {
                for(int j = 0; j < x; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void ShowCoordinates()
        {
            for (int i = 0; i < y; i++)
                Console.Write((char)('A' + i));

            for (int j = 0; j < x; j++)
            {
                Console.SetCursorPosition(8, j);
                Console.Write(number);
                number++;
            }
        }
    }
}
