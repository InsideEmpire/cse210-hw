using System;

class Program
{
    static void Main(string[] args)
    {
        int choice;
        do
        {
            Console.Clear();
            Console.WriteLine("Menu Qptions:");
            Console.WriteLine("    1. Start breathing activity");
            Console.WriteLine("    2. Start reflecting activity");
            Console.WriteLine("    3. Start listing activity");
            Console.WriteLine("    4. Quit");
            Console.WriteLine("Select a choice from the menu: ");
            Console.Write(" > ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.InteractBreathing();
                    break;
                case 2:
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.InteractReflection();
                    break;
                case 3:
                    ListingActivity listing = new ListingActivity();
                    listing.InteractListing();
                    break;
                default:
                    return;
            }
        } while (choice != 4);
    }
}