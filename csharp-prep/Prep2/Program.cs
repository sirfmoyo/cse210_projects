using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userGrade = Console.ReadLine();
        int score = int.Parse(userGrade);

        string symbol = "";

        if (score >= 90)
        {
            symbol = "A";
        }
        else if (percent >= 80)
        {
            symbol = "B";
        }
        else if (score >= 70)
        {
            symbol = "C";
        }
        else if (score >= 60)
        {
            symbol = "D";
        }
        else
        {
            symbol = "F";
        }

        Console.WriteLine($"Your grade is: {symbol}");

    }
}