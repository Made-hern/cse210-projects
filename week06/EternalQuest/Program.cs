using System;
using System.Collections.Generic;
using System.IO;
// EXCEEDING REQUIREMENTS:
// - Added bonus system
// - Infinite goal symbol
// - Improved UI structure
class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int score = 0;

        while (true)
        {
            Console.WriteLine("\nYou have " + score + " points.");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");

            Console.Write("Choose: ");
            int choice = int.Parse(Console.ReadLine());

            // CREATE GOAL
            if (choice == 1)
            {
                Console.WriteLine("1. Simple Goal");
                Console.WriteLine("2. Eternal Goal");
                Console.WriteLine("3. Checklist Goal");

                int type = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Description: ");
                string desc = Console.ReadLine();

                Console.Write("Points: ");
                int points = int.Parse(Console.ReadLine());

                if (type == 1)
                    goals.Add(new SimpleGoal(name, desc, points));

                else if (type == 2)
                    goals.Add(new EternalGoal(name, desc, points));

                else if (type == 3)
                {
                    Console.Write("Target: ");
                    int target = int.Parse(Console.ReadLine());

                    Console.Write("Bonus: ");
                    int bonus = int.Parse(Console.ReadLine());

                    goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                }
            }

            // LIST GOALS
            else if (choice == 2)
            {
                for (int i = 0; i < goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
                }
            }

            // RECORD EVENT
            else if (choice == 3)
            {
                Console.WriteLine("Select goal:");

                for (int i = 0; i < goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
                }

                int index = int.Parse(Console.ReadLine()) - 1;
                score += goals[index].RecordEvent();
            }

            // SAVE
            else if (choice == 4)
            {
                using (StreamWriter sw = new StreamWriter("goals.txt"))
                {
                    sw.WriteLine(score);

                    foreach (Goal g in goals)
                    {
                        sw.WriteLine(g.GetStringRepresentation());
                    }
                }
            }

            // LOAD
            else if (choice == 5)
            {
                if (File.Exists("goals.txt"))
                {
                    string[] lines = File.ReadAllLines("goals.txt");

                    goals.Clear();
                    score = int.Parse(lines[0]);

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] parts = lines[i].Split("|");

                        if (parts[0] == "SimpleGoal")
                            goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));

                        else if (parts[0] == "EternalGoal")
                            goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));

                        else if (parts[0] == "ChecklistGoal")
                            goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                                int.Parse(parts[4]), int.Parse(parts[6]), int.Parse(parts[5])));
                    }
                }
            }

            // EXIT
            else if (choice == 6)
            {
                break;
            }
        }
    }
}