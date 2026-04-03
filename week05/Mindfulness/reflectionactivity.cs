using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What did you learn from this experience?",
        "How can you use this in the future?"
    };

    public ReflectionActivity()
        : base("Reflection", "This activity helps you reflect on your strengths and resilience.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random rand = new Random();

        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"--- {_prompts[rand.Next(_prompts.Count)]} ---");

        Console.WriteLine("\nWhen you have something in mind, press Enter...");
        Console.ReadLine();

        Console.WriteLine("Now reflect on the following questions:");

        int time = 0;

        while (time < _duration)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.Write($"\n{question} ");
            ShowSpinner(5);

            time += 5;
        }

        DisplayEndingMessage();
    }
}