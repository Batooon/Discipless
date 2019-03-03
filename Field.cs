using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciples
{
    class Field
    {
        public char[,] field;
        public int x = 8, y = 8;
        public int number = 1;

        public Field()
        {
            field = new char[x, y];
            //GenerateField();
            ShowCoordinates();
        }

        public void ShowCoordinates()
        {
            for (int i = 0; i < x; i++)
                Console.Write((char)('A' + i));

            for (int j = 0; j < y; j++)
            {
                Console.SetCursorPosition(y, j+1);
                Console.Write(number);
                number++;
            }
        }
    }
}
