using System;
using System.IO;
using System.Collections;

namespace Quiq_SpellCheck
{
    class Program
    {
        /// <summary>
        /// Setup dictionary, create SpellCheck object abd call start()
        /// </summary>
        /// <param name="args">Command line arguments</param>
        static void Main(string[] args)
        {
            Hashtable dic = new Hashtable();
            Hashtable dicCommon = new Hashtable();

            //create small dictionary of common words
            using (StreamReader commonStream = new StreamReader("wordsCommon.txt"))
            {
                while (!commonStream.EndOfStream)
                {
                    dicCommon.Add(commonStream.ReadLine(), true);
                }
            }

            //make lookup dictionary
            using (StreamReader stream = new StreamReader("words.txt"))
            {
                while (!stream.EndOfStream)
                {
                    //add every line in file to dictionary
                    dic.Add(stream.ReadLine(), false);
                }
            }

            //label common words with true value
            foreach (string commonWord in dicCommon.Keys)
            {
                if (dic.Contains(commonWord))
                {
                    dic[commonWord] = true;
                }
            }

            //start reading in words and checking their spelling
            start(new SpellCheck(dic), args[0]);
        }
        
        /// <summary>
        /// Reads in words from file path given in command line and checks each of them
        /// </summary>
        /// <param name="spellCheck">Spell check object uset to check the words</param>
        /// <param name="filePath">Path to input file</param>
        private static void start(SpellCheck spellCheck, string filePath)
        {
            //open file to read in words
            using (StreamReader stream = new StreamReader(filePath))//TODO change this to filepath
            {
                while (!stream.EndOfStream)
                {
                    var word = stream.ReadLine();

                    //if word is in the dictionary
                    if (spellCheck.lookup(word))
                    {
                        Console.WriteLine("CORRECT:\t" + word);
                    }

                    //if the word is not in the dictionary, attempt to find suggestion
                    else if (spellCheck.suggest(word)) { }

                    //if no suggestion found print incorrect
                    else
                    {
                        Console.WriteLine("INCORRECT:\t" + word);
                    }
                }
            }
            //wait for user to press esc key to exit
            Console.WriteLine("Press ESC to exit");
            while (Console.ReadKey(false).Key != ConsoleKey.Escape) { }
        }
    }
}
