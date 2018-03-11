using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiq_SpellCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader stream = new StreamReader("test.txt"))
            {
                List<string> dic = new List<string>();
                while (!stream.EndOfStream)
                {
                    dic.Add(stream.ReadLine());
                }

                mainMenu(new SpellCheck(dic));
            }
        }

        private static void mainMenu(SpellCheck spellCheck)
        {
            bool exit = false;
            while (!exit)
            {

            }
        }
    }
}
