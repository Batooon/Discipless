using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Disciples
{
    class Bonus
    {
        public int X;
        public int Y;
        public bool Isbonus = false;
        public int Id;
        public char Show = '$';

        public Bonus(int id,int x,int y)
        {
            Id = id;
            X = x;
            Y = y;
        }

        public void DrawBonus()
        {
            Console.Write(Show);
        }

        /*private void Read()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("Bonus.txt");

                line = sr.ReadLine();

                while (line != null)
                {
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch(Exception e)
            {
                Console.Clear();
                Console.WriteLine("Что-то тут не так: " + e.Message);
            }
            finally
            {
                //прост
            }
        }*/

        /*private void Show2(Player g)
        {
            if (!Isbonus)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Isbonus = true;
            }
        }

        private void Show1(Player g)
        {
            if (!Isbonus)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Isbonus = true;
            }
        }*/
    }
}
