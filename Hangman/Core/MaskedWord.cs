namespace Hangman.Core
{
    internal class MaskedWord
    {
        private readonly Random _random = new();

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
            var maskArray = Mask.ToCharArray();
            for (var i = 0; i < SecretWord.Length; i++)
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

        internal void OpenNLettersInMask(int letterCount)
        {
            for (var i = 0; i < letterCount; i++)
            {
                var randomIndex = _random.Next(SecretWord.Length);
                var randomLetter = SecretWord[randomIndex];
                OpenLetter(randomLetter);
            }
        }
    }
}
