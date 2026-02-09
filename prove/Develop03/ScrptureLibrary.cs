class ScriptureLibrary
{
    private List<Scripture> _scriptures = new List<Scripture>();
    private Random _random = new Random();

    public ScriptureLibrary(string filename)
    {
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            int startVerse = int.Parse(parts[2]);
            int endVerse = int.Parse(parts[3]);
            string text = parts[4];

            _scriptures.Add(new Scripture(book, chapter, startVerse, endVerse, text));
        }
    }

    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}