namespace Hangman
{
    internal class WordDictionary
    {
        private readonly Random _random = new Random();
        private readonly IDictionary<string, string> _words = new Dictionary<string, string>();

        internal WordDictionary(string pathName)
        {
            using var reader = new StreamReader(pathName);
            ReadWords(reader);
        }

        internal string GetRandomWord()
        {
            var index = _random.Next(_words.Count);
            return _words.Keys.ElementAt(index);
        }

        internal string GetDefinition(string word)
        {
            return _words[word];
        }

        private void ReadWords(StreamReader reader)
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(" - ");
                _words.Add(parts[0], parts[1]);
            }
        }
    }
}
