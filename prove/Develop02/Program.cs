using System;
using System.Collections.Generic;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
}

class Program
{
    static List<JournalEntry> journalEntries = new List<JournalEntry>();
    static Random random = new Random();

    static void Main(string[] args)
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Quit");


            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteEntry();
                    break;
                case "2":
                    DisplayEntries();
                    break;
                case "3":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void WriteEntry()
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        int randomIndex = random.Next(prompts.Length);
        string prompt = prompts[randomIndex];

        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("Enter your response:");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        JournalEntry entry = new JournalEntry
        {
            Prompt = prompt,
            Response = response,
            Date = date
        };

        journalEntries.Add(entry);

        Console.WriteLine("Entry added successfully.");
        Console.WriteLine();
    }

    static void DisplayEntries()
    {
        if (journalEntries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            Console.WriteLine();
            return;
        }

        foreach (var entry in journalEntries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }
}
