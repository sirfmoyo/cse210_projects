using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the number of papers (1, 2, or 3): ");
        int numberOfPapers = int.Parse(Console.ReadLine());

        List<Paper> papers = new List<Paper>();

        for (int i = 0; i < numberOfPapers; i++)
        {
            Console.Write($"Enter the name of Paper {i + 1}: ");
            string paperName = Console.ReadLine();

            Console.Write($"Enter the total marks for {paperName}: ");
            int totalMarks = int.Parse(Console.ReadLine());

            Console.Write($"Enter the percentage weight for {paperName}: ");
            int paperWeight = int.Parse(Console.ReadLine());

            papers.Add(new Paper { Name = paperName, TotalMarks = totalMarks, Weight = paperWeight });
        }

        bool addAnotherStudent = true;
        List<Student> students = new List<Student>();

        while (addAnotherStudent)
        {
            Student student = new Student();

            Console.Write("Enter the name of the student: ");
            student.Name = Console.ReadLine();

            // Record student's performance in each paper
            foreach (Paper paper in papers)
            {
                Console.Write($"Enter the mark for {paper.Name} (out of {paper.TotalMarks}): ");
                int paperMark = int.Parse(Console.ReadLine());

                student.Subject.Papers.Add(new Paper
                {
                    Name = paper.Name,
                    TotalMarks = paper.TotalMarks,
                    Weight = paper.Weight,
                    Mark = paperMark
                });
            }

            CalculateFinalMark(student);
            students.Add(student);

            Console.Write("Do you want to add another student? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            addAnotherStudent = response == "yes" || response == "y";
        }

        DisplayResults(students);
    }

    static void CalculateFinalMark(Student student)
    {
        double totalWeightedMarks = 0;
        int totalWeight = 0;

        foreach (Paper paper in student.Subject.Papers)
        {
            totalWeightedMarks += (paper.Mark / (double)paper.TotalMarks) * paper.Weight;
            totalWeight += paper.Weight;
        }

        if (totalWeight != 100)
        {
            Console.WriteLine("Warning: The total percentage weight does not equal 100%");
        }

        student.FinalMark = totalWeightedMarks;
    }

    static void DisplayResults(List<Student> students)
    {
        foreach (Student student in students)
        {
            Console.WriteLine($"Student Name: {student.Name}");
            Console.WriteLine($"Final Mark: {student.FinalMark:F2}");
            Console.WriteLine($"Grade: {AssignGrade(student.FinalMark)}");
            Console.WriteLine();
        }
    }

    static string AssignGrade(double finalMark)
    {
        if (finalMark >= 90)
        {
            return "A";
        }
        else if (finalMark >= 80)
        {
            return "B";
        }
        else if (finalMark >= 70)
        {
            return "C";
        }
        else if (finalMark >= 60)
        {
            return "D";
        }
        else
        {
            return "F";
        }
    }
}
