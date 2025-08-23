using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class WordDictionary
    {
        private readonly Random random = new Random();
        private readonly Dictionary<string, string> words = new();

        internal WordDictionary(string pathName)
        {
            using var reader = new StreamReader(pathName);
            ReadWords(reader);
        }

        internal string GetRandomWord()
        {
            int index = random.Next(words.Count);
            return words.Keys.ElementAt(index);
        }

        internal string GetDefinition(string word)
        {
            return words[word];
        }

        private void ReadWords(StreamReader reader)
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(" - ");
                words.Add(parts[0], parts[1]);
            }
        }
    }
}
