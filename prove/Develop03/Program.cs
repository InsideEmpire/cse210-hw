using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        // Scripture scripture = new Scripture(
        //     "Genesis",
        //     8,
        //     21,
        //     21,
        //     "And the Lord smelled a sweet savour⁠; and the Lord said in his heart, I will not again curse the ground any more for man's sake⁠; for the imagination of man's heart is evil from his youth; neither will I again smite any more every thing living, as I have done."
        // );
        ScriptureLibrary library = new ScriptureLibrary("scriptures.txt");
        Scripture scripture = library.GetRandomScripture();
        string command;

        do {
            Console.Clear();
            Console.WriteLine();
            scripture.Display();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Press enter to continue or type 'quit' to finish> ");
            command = Console.ReadLine();
            if (command == "quit")
            {
                return;
            }
            if (String.IsNullOrEmpty(command))
            {
                scripture.HideRandomWords(3);
            }
        }
        while (String.IsNullOrEmpty(command));
    }
}
