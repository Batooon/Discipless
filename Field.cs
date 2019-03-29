using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Disciples
{
    public class Field
    {
        public char[,] field;

        public Field(int w,int h)
        {
            field = new char[w, h];
        }

        public Field()
        {

        }
    }
}
