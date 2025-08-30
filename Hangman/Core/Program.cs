namespace Hangman.Core
{
    internal class Program
    {
        private const string Path = "Data/words.txt";
        private static readonly TextReader Reader = Console.In;

        internal static void Main(string[] args)
        {
            var wordDictionary = new WordDictionary(Path);
            bool isPlayAgain;

            do
            {
                var maskedWord = new MaskedWord(wordDictionary);

                var game = new Game(maskedWord, Reader);
                game.RunGameLoop();

                Console.WriteLine("Хотите сыграть еще раз? (Y/N)");

                var input = Reader.ReadLine();
                var answer = GetAnswer(input);

                isPlayAgain = answer is 'Y' or 'y';
            } while (isPlayAgain);
        }

        private static char GetAnswer(string? input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return input[0];
            }
            else
            {
                return 'N';
            }
        }
    }
}
