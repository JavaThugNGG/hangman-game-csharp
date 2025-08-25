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
            WordDictionary wordDictionary = new WordDictionary(Path);
            bool isPlayAgain;

            do
            {
                MaskedWord maskedWord = new MaskedWord(wordDictionary);

                Game game = new Game(maskedWord);
                game.RunGameLoop();

                Console.WriteLine("Хотите сыграть еще раз? (Y/N)");
                char answer = Console.ReadLine()[0];
                isPlayAgain = answer == 'Y' || answer == 'y';
            } while (isPlayAgain);
        }
    }
}
