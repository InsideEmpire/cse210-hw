using System;

class Program
{
    static void Main(string[] args)
    {
        // --- 第一部分：验证构造函数 ---
        Fraction f1 = new Fraction();          // 1/1
        Fraction f2 = new Fraction(5);         // 5/1
        Fraction f3 = new Fraction(3, 4);      // 3/4
        Fraction f4 = new Fraction(1, 3);      // 1/3

        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());
        
        Fraction testFraction = new Fraction();
        Random random = new Random();

        for (int i = 1; i <= 20; i++)
        {
            int randomTop = random.Next(1, 11);
            int randomBottom = random.Next(1, 11);

            testFraction.SetTop(randomTop);
            testFraction.SetBottom(randomBottom);

            string fractionString = testFraction.GetFractionString();
            double decimalValue = testFraction.GetDecimalValue();

            Console.WriteLine($"Fraction {i}: string: {fractionString.PadRight(5)} Number: {decimalValue}");
        }
    }
}