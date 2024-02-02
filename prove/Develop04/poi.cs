using System;
using System.Threading;

class MindfulnessActivity
{
    protected int duration;

    public MindfulnessActivity(int duration)
    {
        this.duration = duration;
    }

    public virtual void StartActivity()
    {
        Console.WriteLine($"Prepare for {GetType().Name.ToLower()}...");
        Pause(3);

        Console.WriteLine($"Starting {GetType().Name.ToLower()} for {duration} seconds.");
    }

    public virtual void EndActivity()
    {
        Console.WriteLine($"Good job! You have completed {GetType().Name.ToLower()} for {duration} seconds.");
        Pause(3);
    }

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int duration) : base(duration) { }

    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine("Breathe in...");
            Pause(3);

            Console.WriteLine("Breathe out...");
            Pause(3);
        }

        EndActivity();
    }
}

class ReflectionActivity : MindfulnessActivity
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

    public ReflectionActivity(int duration) : base(duration) { }

    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        string randomPrompt = prompts[new Random().Next(prompts.Length)];
        Console.WriteLine(randomPrompt);

        foreach (var question in questions)
        {
            Console.WriteLine(question);
            Pause(3);
        }

        EndActivity();
    }
}

class ListingActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base(duration) { }

    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        string randomPrompt = prompts[new Random().Next(prompts.Length)];
        Console.WriteLine(randomPrompt);

        Console.WriteLine("Get ready to list...");
        Pause(3);

        Console.WriteLine("Start listing...");

        for (int i = 1; i <= duration; i++)
        {
            Console.WriteLine($"Item {i}");
            Pause(1);
        }

        Console.WriteLine($"You listed {duration} items.");

        EndActivity();
    }
}

class Program
{
    static void Main()
    {
        MindfulnessActivity activity = GetActivity();
        activity.StartActivity();
    }

    static MindfulnessActivity GetActivity()
    {
        Console.WriteLine("Choose an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
        {
            Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
        }

        Console.WriteLine("Enter the duration in seconds:");
        int duration;
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.WriteLine("Invalid duration. Please enter a positive integer.");
        }

        switch (choice)
        {
            case 1:
                return new BreathingActivity(duration);
            case 2:
                return new ReflectionActivity(duration);
            case 3:
                return new ListingActivity(duration);
            default:
                throw new NotImplementedException("Unknown activity choice.");
        }
    }
}