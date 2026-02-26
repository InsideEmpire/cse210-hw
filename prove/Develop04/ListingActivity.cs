public class ListingActivity : Activity
{
    private string[] _prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {}

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(5)];
    }

    public void InteractListing()
    {
        InteractPrologue();

        Console.WriteLine("Get ready...");
        Console.WriteLine();
        Console.WriteLine("Lists as many responses you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        CountDownWithAnimation(5);
        Console.WriteLine();
        
        int count = 0;

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {count} items!");
        Console.WriteLine();

        InteractEpilogue();
    }
}