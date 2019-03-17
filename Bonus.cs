using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;

namespace Disciples
{
    class Bonus
    {
        public int X;
        public int Y;
        public char Show = '$';

        public Bonus(int x,int y)
        {
            X = x;
            Y = y;
        }

        public void DrawBonus()
        {
            Console.Write(Show);
        }

        /*public void InitTimer()
        {
            Timer timer = new Timer(20);
            timer.Elapsed += async (sender, e) => await HandleTimer();
            timer.Start();
            Console.Write("fjeo");
            Console.ReadKey();
        }*/

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
