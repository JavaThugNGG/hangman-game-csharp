namespace Hangman
{
    internal class Game
    {
        private const int Easy = 1;
        private const int Medium = 2;
        private const int Hard = 3;
        private MaskedWord _maskedWord;
        private TextReader _input;

        internal Game(MaskedWord maskedWord, TextReader input)
        {
            _maskedWord = maskedWord;
            _input = input;
        }

        internal void RunGameLoop()
        {
            int difficultyLevel = InputDifficultyLevel();
            var usedLetters = new HashSet<char>();

            if (difficultyLevel == Easy)
            {
                _maskedWord.OpenNLettersInMask(2);
            }

            var mistakes = 0;
            var isWin = false;
            var isLose = false;

            do
            {
                PrintHangman(mistakes);
                Console.WriteLine(Environment.NewLine + "Ошибок: " + mistakes);
                Console.WriteLine(_maskedWord.Mask);

                if (difficultyLevel is Easy or Medium)
                {
                    Console.WriteLine("Определение слова: " + _maskedWord.Definition);
                }

                char letter = InputValidLetter(usedLetters);
                usedLetters.Add(letter);

                if (_maskedWord.ContainsLetter(letter))
                {
                    _maskedWord.OpenLetter(letter);
                }
                else
                {
                    mistakes++;
                }

                if (mistakes == 6)
                {
                    isLose = true;
                }

                if (_maskedWord.IsFullyOpen())
                {
                    isWin = true;
                }

            } while (!isWin && !isLose);

            if (isWin)
            {
                Console.WriteLine("Вы выиграли! Загаданное слово: " + _maskedWord.SecretWord);
                Console.WriteLine("Определение: " + _maskedWord.Definition);
            }
            else
            {
                PrintHangman(mistakes);
                Console.WriteLine("Вы проиграли! Загаданное слово: " + _maskedWord.SecretWord);
                Console.WriteLine("Определение: " + _maskedWord.Definition);
            }
        }

        internal char InputValidLetter(ISet<char> usedLetters)
        {
            while (true)
            {
                Console.WriteLine("Введите букву: ");
                string? input = _input.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input) || input.Length != 1)
                {
                    Console.WriteLine("Введите только одну букву!");
                    continue;
                }

                var letter = input[0];

                if (letter is < 'a' or > 'z')
                {
                    Console.WriteLine("Введите строчную букву английского алфавита!");
                    continue;
                }

                if (usedLetters.Contains(letter))
                {
                    Console.WriteLine("Вы уже вводили эту букву!");
                    continue;
                }

                return letter;
            }
        }

        internal int InputDifficultyLevel()
        {
            Console.WriteLine("Выберите уровень сложности (1/2/3: ");
            Console.WriteLine("1. Легкий - значение слова как подсказка, две открытые буквы");
            Console.WriteLine("2. Средний - значение слова как подсказка");
            Console.WriteLine("3. Сложный - без подсказок");

            while (true)
            {
                string? input = _input.ReadLine()?.Trim();

                if (input.Length != 1 || !char.IsDigit(input[0]))
                {
                    Console.WriteLine("Введите число!");
                    continue;
                }

                var difficultyLevel = int.Parse(input);

                if (difficultyLevel is < 1 or > 3)
                {
                    Console.WriteLine("Введите число от 1 до 3!");
                    continue;
                }

                return difficultyLevel;
            }
        }

        internal static void PrintHangman(int mistakes)
        {
            switch (mistakes)
            {
                case 0:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 1:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 2:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 3:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 4:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 5:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine(" /    |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 6:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine(" / \\  |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
            }
        }
    }
}
