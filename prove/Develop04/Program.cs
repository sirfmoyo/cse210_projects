using System;
using System.Threading;

public class Activity
{
    protected string name;
    protected string description;
    protected int duration;

    public void DisplayStartingMessage()
    {
        Console.WriteLine("Welcome to the activity: " + name);
        Console.WriteLine("Description: " + description);
        Console.WriteLine("Please enter the duration in seconds: ");
        duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Prepare to begin in 3 seconds...");
        Thread.Sleep(3000);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Good job! You have completed the activity: " + name);
        Console.WriteLine("Duration: " + duration + " seconds");
        Console.WriteLine("Finishing in 3 seconds...");
        Thread.Sleep(3000);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b-");
            Thread.Sleep(250);
            Console.Write("\b\\");
            Thread.Sleep(250);
            Console.Write("\b|");
            Thread.Sleep(250);
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine("Countdown: " + i + " seconds");
            Thread.Sleep(1000);
        }
    }
}

public class BreathingActivity : Activity
{
    public void Run()
    {
        name = "Breathing Activity";
        description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";

        DisplayStartingMessage();

        Console.WriteLine("Starting breathing activity...");

        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(3);

            Console.WriteLine("Breathe out...");
            ShowCountdown(3);
        }

        DisplayEndingMessage();
    }
}

public class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public void Run()
    {
        name = "Reflection Activity";
        description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        DisplayStartingMessage();

        Console.WriteLine("Starting reflection activity...");

        Random rand = new Random();

        for (int i = 0; i < duration; i++)
        {
            string prompt = prompts[rand.Next(prompts.Length)];
            Console.WriteLine(prompt);

            foreach (string question in questions)
            {
                Console.WriteLine(question);
                ShowSpinner(3);
            }
        }

        DisplayEndingMessage();
    }
}

public class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public void Run()
    {
        name = "Listing Activity";
        description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        DisplayStartingMessage();

        Console.WriteLine("Starting listing activity...");

        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine(prompt);

        Console.WriteLine("You have " + duration + " seconds to list as many items as you can.");
        ShowCountdown(duration);

        // Simulating user input by waiting for the specified duration
        Thread.Sleep(duration * 1000);

        Console.WriteLine("Number of items listed: " + duration);

        DisplayEndingMessage();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("Please enter your choice: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.Run();
                break;
            case 2:
                ReflectionActivity reflectionActivity = new ReflectionActivity();
                reflectionActivity.Run();
                break;
            case 3:
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.Run();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}
