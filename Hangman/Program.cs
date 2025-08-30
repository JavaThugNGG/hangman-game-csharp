namespace Hangman
{
    internal class Program
    {
        private const string Path = "words.txt";
        private static readonly TextReader Reader = Console.In;

        internal static void Main(string[] args)
        {
            WordDictionary wordDictionary = new WordDictionary(Path);
            bool isPlayAgain;

            do
            {
                MaskedWord maskedWord = new MaskedWord(wordDictionary);

                Game game = new Game(maskedWord, Reader);
                game.RunGameLoop();

                Console.WriteLine("Хотите сыграть еще раз? (Y/N)");

                string? input = Reader.ReadLine();
                char answer = GetAnswer(input);

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
