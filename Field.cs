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
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int number = 1;

        public Field()
        {
            Width = 8;
            Height = 8;

            field = new char[Width, Height];
            //GenerateField();
        }
    }
}
