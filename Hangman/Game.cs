using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Game
    {
        private const int Easy = 1;
        private const int Medium = 2;
        private const int Hard = 3;
        private readonly StreamReader _streamReader;
        private MaskedWord _maskedWord;

        internal Game(MaskedWord maskedWord)
        {
            _maskedWord = maskedWord;
        }

        internal void RunGameLoop()
        {
            int difficultyLevel = InputDifficultyLevel();
            ISet<char> usedLetters = new HashSet<char>();

            if (difficultyLevel == Easy)
            {
                _maskedWord.OpenNLetterInMask(2);
            }

            int mistakes = 0;
            bool isWin = false;
            bool isLose = false;

            do
            {
                PrintHangman(mistakes);
                Console.WriteLine(Environment.NewLine + "Ошибок: " + mistakes);
                Console.WriteLine(_maskedWord.Mask);

                if (difficultyLevel == Easy || difficultyLevel == Medium)
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

        internal static char InputValidLetter(ISet<char> usedLetters)
        {
            while (true)
            {
                Console.WriteLine("Введите букву: ");
                string input = Console.ReadLine();

                if (input.Length != 1)
                {
                    Console.WriteLine("Введите только одну букву!");
                    continue;
                }

                char letter = input[0];

                if (letter < 'a' || letter > 'z')
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

        internal static int InputDifficultyLevel()
        {
            Console.WriteLine("Выберите уровень сложности (1/2/3: ");
            Console.WriteLine("1. Легкий - значение слова как подсказка, две открытые буквы");
            Console.WriteLine("2. Средний - значение слова как подсказка");
            Console.WriteLine("3. Сложный - без подсказок");

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Length != 1 || !char.IsDigit(input[0]))
                {
                    Console.WriteLine("Введите число!");
                    continue;
                }

                int difficultyLevel = int.Parse(input);

                if (difficultyLevel < 1 || difficultyLevel > 3)
                {
                    Console.WriteLine("Введите число от 1 до 3!");
                    continue;
                }

                return difficultyLevel;
            }
        }

        static void PrintHangman(int mistakes)
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
