using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Program
    {
        private const string Path = "words.txt";

        internal static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(Path);
            Console.WriteLine(text);
        }
    }
}
