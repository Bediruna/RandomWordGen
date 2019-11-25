using System;
using System.Diagnostics;
using System.Text;
using NetSpell.SpellChecker;
using NetSpell.SpellChecker.Dictionary;

namespace RandomWordGen
{
    class Program
    {
        static void Main()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            CreateRandomWords(3, stopWatch);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Console.ReadKey();
        }

        static void CreateRandomWords(int limit, Stopwatch stopWatch)
        {
            Random randy = new Random();

            int randomInt = randy.Next(3, 6);

            string randomString = RandomString(randomInt);

            bool isValid = SpellCheck(randomString);

            if (isValid)
            {
                limit--;
                Console.Write(randomString);

                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine("\t\t" + elapsedTime);
            }

            if (limit > 0)
            {
                CreateRandomWords(limit, stopWatch);
            }
        }
        static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        static bool SpellCheck(string word)
        {
            WordDictionary dictionary = new WordDictionary();

            dictionary.DictionaryFile = "en-US.dic";

            dictionary.Initialize();

            Spelling spelling = new Spelling();

            spelling.Dictionary = dictionary;

            return spelling.TestWord(word);
        }
    }
}
