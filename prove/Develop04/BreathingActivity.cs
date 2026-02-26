public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {}

    public void InteractBreathing()
    {
        InteractPrologue();

        Console.WriteLine("Get ready...");
        PauseWithAnimation(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            Console.WriteLine();
            CountDownWithAnimation(4);

            Console.WriteLine();
            Console.Write("Now breathe out... ");
            Console.WriteLine();
            CountDownWithAnimation(6);
        }

        InteractEpilogue();
    }
}