public class Activity
{
    protected string _title;
    protected string _desc;
    protected int _duration;

    public Activity(string title, string desc)
    {
        _title = title;
        _desc = desc;
    }

    public void GetDuration()
    {
        Console.WriteLine("How long, in seconds, would you like for your session? ");
        Console.Write(" > ");
        _duration = int.Parse(Console.ReadLine());
    }

    public void InteractPrologue()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to {_title}");
        Console.WriteLine();
        Console.WriteLine($"{_desc}");
        Console.WriteLine();
        GetDuration();
        Console.Clear();
    }

    public void InteractEpilogue()
    {
        Console.Write("Well done!! ");
        PauseWithAnimation(3);
        Console.WriteLine();
        Console.Write($"You have completed anthor {_duration} seconds of the {_title}. ");
        PauseWithAnimation(3);
        Console.WriteLine();
    }

    public void PauseWithAnimation(int duration)
    {
        string[] spinner = { "|", "/", "-", "\\" };

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[index]);
            Thread.Sleep(200);
            Console.Write("\b \b");

            index = (index + 1) % spinner.Length;
        }
    }

    // public void CountDownWithAnimation(int duration)
    // {
    //     for (int i = duration; i > 0; i--)
    //     {
    //         Console.Write(i);
    //         Thread.Sleep(1000);
    //         Console.Write("\b \b");
    //     }
    // }
    public void CountDownWithAnimation(int duration)
    {
        int barWidth = 30;

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            double timeLeft = (endTime - DateTime.Now).TotalSeconds;
            double progress = 1 - (timeLeft / duration);

            int filled = (int)(progress * barWidth);
            int percent = (int)(progress * 100);

            Console.Write("\r[");
            Console.Write(new string('#', filled));
            Console.Write(new string('-', barWidth - filled));
            Console.Write($"] {percent}%   ");

            Thread.Sleep(100);
        }

        Console.Write("\r[" + new string('#', barWidth) + $"] 100%");
        Console.WriteLine();
        Console.WriteLine();
    }
}