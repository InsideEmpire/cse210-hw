using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        int choice;
        do
        {
            choice = Prompt();

            switch (choice)
            {
                case 1:
                    journal.AddEntry();
                    break;
                case 2:
                    journal.DisplayAll();
                    break;
                case 3:
                    journal.LoadFromFile();
                    break;
                case 4:
                    journal.SaveToFile();
                    break;
                default:
                    Console.WriteLine("Goodbye!");
                    break;
            }
        } while (choice != 5);


        int Prompt()
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            int choice = int.Parse(Console.ReadLine());

            return choice;
        }
    }
}

class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;
    private string _mood;
    private static readonly string[] _prompts =
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };
    public Entry(string date, string mood, string promptText, string entryText)
    {
        this._date = date;
        this._mood = mood;
        this._promptText = promptText;
        this._entryText = entryText;
    }
    public Entry()
    {
        DateTime dateTime = DateTime.Now;
        this._date = dateTime.ToShortDateString();

        Random random = new Random();
        int index = random.Next(_prompts.Length);
        this._promptText = _prompts[index];
    }
    public void SetEntryText(string entryText)
    {
        this._entryText = entryText;
    }
    public void SetMood(string mood)
    {
        this._mood = mood;
    }
    public void PrintPrompt()
    {
        Console.WriteLine($"{this._promptText}");
    }
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Mood: {_mood}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }
    public string GetDisplay()
    {
        return $"{_date}|{_mood}|{_promptText}|{_entryText}";
    }
}

class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        this._entries = new List<Entry>();
    }
    public void AddEntry()
    {
        Entry entry = new Entry();
        entry.PrintPrompt();
        Console.Write(" > ");
        string entryText;
        entryText = Console.ReadLine();
        entry.SetEntryText(entryText);

        Console.Write("How are you feeling today? ");
        string mood = Console.ReadLine();
        entry.SetMood(mood);

        this._entries.Add(entry);
    }
    public void DisplayAll()
    {
        foreach (Entry entry in this._entries)
        {
            entry.Display();
        }
    }
    public void SaveToFile()
    {
        Console.WriteLine("What is the filename?");

        string filename;
        filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in this._entries)
            {
                outputFile.WriteLine(entry.GetDisplay());
            }
        }

        Console.WriteLine("Journal saved successfully.");
    }
    public void LoadFromFile()
    {
        _entries.Clear();
        Console.WriteLine("What is the filename?");
        
        string filename;
        filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            Entry entry = new Entry(parts[0], parts[1], parts[2], parts[3]);

            this._entries.Add(entry);
        }

        Console.WriteLine($"Journal loaded from {filename}.");
    }
}