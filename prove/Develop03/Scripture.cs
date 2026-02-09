class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(string book, int chapter, int startVerse, int endVerse, string scripture)
    {
        _reference = new Reference(book, chapter, startVerse, endVerse);
        _words = new List<Word>();
        string[] wordList = scripture.Split(' ');
        foreach (string word in wordList)
        {
            _words.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.Write(_reference.GetDisplayText());
        foreach (Word word in _words)
        {
            Console.Write(' ');
            Console.Write(word.GetDisplayText());
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();

        for (int i = 0; i < numberToHide; i++)
        {
            List<Word> visibleWords = _words.FindAll(w => !w.IsHidden());
            if (visibleWords.Count == 0)
            {
                break;
            }

            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
        }
    }
}
