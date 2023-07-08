using System;
using System.Collections.Generic;

namespace EternalQuestProgram
{
    class EternalQuestApp
    {
        private List<Goal> goals;

        public EternalQuestApp()
        {
            goals = new List<Goal>();
        }

        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                // Display menu options
                Console.WriteLine("Eternal Quest Program");
                Console.WriteLine("---------------------");
                Console.WriteLine("1. Create a new goal");
                Console.WriteLine("2. Record an event");
                Console.WriteLine("3. View goals");
                Console.WriteLine("4. View score");
                Console.WriteLine("5. Save goals and score");
                Console.WriteLine("6. Load goals and score");
                Console.WriteLine("7. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        RecordEvent();
                        break;
                    case "3":
                        ViewGoals();
                        break;
                    case "4":
                        ViewScore();
                        break;
                    case "5":
                        SaveData();
                        break;
                    case "6":
                        LoadData();
                        break;
                    case "7":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.WriteLine();
                        break;
                }
            }
        }

        private void CreateGoal()
        {
            Console.WriteLine("Create a New Goal");
            Console.WriteLine("-----------------");

            Console.WriteLine("Select the goal type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateSimpleGoal();
                    break;
                case "2":
                    CreateEternalGoal();
                    break;
                case "3":
                    CreateChecklistGoal();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }

        private void CreateSimpleGoal()
        {
            Console.WriteLine("Create a Simple Goal");
            Console.WriteLine("--------------------");

            Console.Write("Enter the goal name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the points for completing the goal: ");
            int points = Convert.ToInt32(Console.ReadLine());

            Goal simpleGoal = new SimpleGoal(name, points);
            goals.Add(simpleGoal);

            Console.WriteLine("Simple goal created successfully!");
            Console.WriteLine();
        }

        private void CreateEternalGoal()
        {
            Console.WriteLine("Create an Eternal Goal");
            Console.WriteLine("----------------------");

            Console.Write("Enter the goal name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the points for each recording: ");
            int points = Convert.ToInt32(Console.ReadLine());

            Goal eternalGoal = new EternalGoal(name, points);
            goals.Add(eternalGoal);

            Console.WriteLine("Eternal goal created successfully!");
            Console.WriteLine();
        }

        private void CreateChecklistGoal()
        {
            Console.WriteLine("Create a Checklist Goal");
            Console.WriteLine("-----------------------");

            Console.Write("Enter the goal name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the points for each recording: ");
            int points = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the total number of times to complete the goal: ");
            int targetCount = Convert.ToInt32(Console.ReadLine());

            Goal checklistGoal = new ChecklistGoal(name, points, targetCount);
            goals.Add(checklistGoal);

            Console.WriteLine("Checklist goal created successfully!");
            Console.WriteLine();
        }

        private void RecordEvent()
        {
            Console.WriteLine("Record an Event");
            Console.WriteLine("----------------");

            if (goals.Count == 0)
            {
                Console.WriteLine("No goals available. Create a goal first.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Select a goal to record an event:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].Name}");
            }

            Console.Write("Enter the goal number: ");
            int goalNumber = Convert.ToInt32(Console.ReadLine());

            if (goalNumber < 1 || goalNumber > goals.Count)
            {
                Console.WriteLine("Invalid goal number. Please try again.");
                Console.WriteLine();
                return;
            }

            Goal selectedGoal = goals[goalNumber - 1];
            selectedGoal.RecordEvent();

            Console.WriteLine("Event recorded successfully!");
            Console.WriteLine();
        }

        private void ViewGoals()
        {
            Console.WriteLine("Goals");
            Console.WriteLine("-----");

            if (goals.Count == 0)
            {
                Console.WriteLine("No goals available. Create a goal first.");
                Console.WriteLine();
                return;
            }

            for (int i = 0; i < goals.Count; i++)
            {
                Goal goal = goals[i];
                string status;

                if (goal is ChecklistGoal checklistGoal)
                {
                    status = $"Completed {checklistGoal.CompletedCount}/{checklistGoal.TargetCount} times";
                }
                else
                {
                    status = goal.IsComplete ? "[X]" : "[ ]";
                }

                Console.WriteLine($"{i + 1}. {status} {goal.Name}");
            }

            Console.WriteLine();
        }

        private void ViewScore()
        {
            Console.WriteLine("Score");
            Console.WriteLine("-----");

            int totalScore = 0;

            foreach (Goal goal in goals)
            {
                totalScore += goal.Points;
            }

            Console.WriteLine($"Total Score: {totalScore}");
            Console.WriteLine();
        }

        private void SaveData()
        {
            Console.WriteLine("Saving goals and score...");
            // Code to save goals and score goes here
            Console.WriteLine("Goals and score saved successfully!");
            Console.WriteLine();
        }

        private void LoadData()
        {
            Console.WriteLine("Loading goals and score...");
            // Code to load goals and score goes here
            Console.WriteLine("Goals and score loaded successfully!");
            Console.WriteLine();
        }
    }
}
