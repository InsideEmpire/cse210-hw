using System;

class Program
{
    static void Main(string[] args)
    {
        void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        void PromptUserBirthYear(out int birthYear)
        {
            Console.Write("Please enter the year you were born: ");
            birthYear = int.Parse(Console.ReadLine());
        }

        int SquareNumber(int number)
        {
            return number * number;
        }

        void DisplayResult(string name, int squaredNumber, int birthYear)
        {
            int currentYear = DateTime.Now.Year;
            int age = currentYear - birthYear;

            Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
            Console.WriteLine($"{name}, you will turn {age} this year.");
        }
        
        DisplayWelcome();

        string name = PromptUserName();

        int favoriteNumber = PromptUserNumber();

        int birthYear;
        PromptUserBirthYear(out birthYear);

        int squaredNumber = SquareNumber(favoriteNumber);

        DisplayResult(name, squaredNumber, birthYear);
    }

}