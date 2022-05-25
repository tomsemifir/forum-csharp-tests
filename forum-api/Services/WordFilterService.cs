namespace forum_api.Services
{
    public class WordFilterService
    {
        private const String BAN_WORDS_PATH = "D:\\dev\\projets\\forum-csharp\\forum-api\\insults.txt";
        public String[] BanWords { get; set; }

        public WordFilterService()
        {
            BanWords = ImportWords();
        }

        private String[] ImportWords()
        {
            String[] words = File.ReadAllLines(BAN_WORDS_PATH);
            return words;
        }

        public String FilterContent(String text)
        {
            String[] contentWords = text.Split(" ");
            for (int i = 0; i < contentWords.Length; i++)
            {
                String word = contentWords[i];
                if (BanWords.Any(banWord => word.ToLower().Equals(banWord)))
                {
                    word = ReplaceLetters(word);
                    contentWords[i] = word;
                }
            }
            text = String.Join(" ", contentWords);
            return text;
        }

        private String ReplaceLetters(String word)
        {
            int size = word.Length;
            char first = word[0];
            char last = word[size - 1];
            String stars = "";
            for(int i = 1; i < size - 1; i++)
            {
                stars += "*";
            }
            return first + stars + last;
        }

    }
}
