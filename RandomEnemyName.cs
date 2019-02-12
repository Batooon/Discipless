using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Disciples
{
    class RandomEnemyName
    {
        List<string> names = new List<string>();
        public void Read()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("D:\\Disciples/Disciples/EnemyNames.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    names.Add(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exeption: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
        public void Show()
        {
            foreach(string s in names)
            {
                Console.WriteLine(s);
            }
        }
    }
}
