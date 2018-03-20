using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Quiq_SpellCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> dic = new List<string>();
            Hashtable dic = new Hashtable();
            using (StreamReader stream = new StreamReader("words.txt"))
            {
                while (!stream.EndOfStream)
                {
                    dic.Add(stream.ReadLine(), true);
                }
            }
            mainMenu(new SpellCheck(dic), args[0]);
        }

        private static void mainMenu(SpellCheck spellCheck, string filePath)
        {
            //Console.WriteLine("~~~~WELCOME TO SPELL CHECK~~~~");
            //Console.WriteLine("Enter a word or press ESC to exit");
            //while (Console.ReadKey(false).Key != ConsoleKey.Escape)

            using (StreamReader stream = new StreamReader("words.txt"))
            {
                int count = 0;
                while (!stream.EndOfStream)
                {
                    count++;
                    if (count % 10000 == 0) { Console.WriteLine(count); }
                    var word = stream.ReadLine();
                    if (spellCheck.lookup(word))
                    {
                        //Console.Write("C");
                    }
                    else if (false)
                    {
                        //suggestion here
                    }
                    else
                    {
                        Console.WriteLine("INCORRECT:\t" + word);
                        Console.WriteLine("on line " + count);
                    }

                }
            }
            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~END OF TEST~~~~~~~~");
            Console.WriteLine("Press ESC to exit");
            while (Console.ReadKey(false).Key != ConsoleKey.Escape) { }
        }
    }
}
