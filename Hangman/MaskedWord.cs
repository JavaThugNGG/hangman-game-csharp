using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class MaskedWord
    {
        private readonly Random _random = new Random();

        internal MaskedWord(WordDictionary wordDictionary)
        {
            SecretWord = wordDictionary.GetRandomWord();
            Definition = wordDictionary.GetDefinition(SecretWord);
            Mask = new string('*', SecretWord.Length);
        }

        public string SecretWord { get; }
        public string Mask { get; private set; }
        public string Definition { get; }

        internal void OpenLetter(char letter)
        {
            char[] maskArray = Mask.ToCharArray();
            for (int i = 0; i < SecretWord.Length; i++)
            {
                if (SecretWord[i] == letter)
                {
                    maskArray[i] = letter;
                }
            }
            Mask = new string(maskArray);
        }

        internal bool ContainsLetter(char letter)
        {
            return SecretWord.Contains(letter);
        }

        internal bool IsFullyOpen()
        {
            return Mask.Equals(SecretWord);
        }

        internal void OpenNLetterInMask(int letterCount)
        {
            for (int i = 0; i < letterCount; i++)
            {
                int randomIndex = _random.Next(SecretWord.Length);
                char randomLetter = SecretWord[randomIndex];
                OpenLetter(randomLetter);
            }
        }
    }
}
