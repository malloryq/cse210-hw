using System;
using System.Threading;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Mindfulness App!");
                Console.WriteLine("Choose an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BreathingActivity.Start();
                        break;
                    case "2":
                        ReflectionActivity.Start();
                        break;
                    case "3":
                        ListingActivity.Start();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

    abstract class Activity
    {
        protected string Name { get; set; }
        protected string Description { get; set; }
        protected int Duration { get; set; }

        public abstract void Start();
        public abstract void End();

        protected void DisplayAnimation(string message, int duration)
        {
            for (int i = 0; i < duration; i++)
            {
                Console.Write($"\r{message} {i + 1}");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }

    class BreathingActivity : Activity
    {
        public BreathingActivity()
        {
            Name = "Breathing Activity";
            Description = "This activity will help you relax by guiding you through deep breathing exercises.";
        }

        public override void Start()
        {
            Console.WriteLine($"Starting {Name}: {Description}");
            Console.Write("Enter duration (in seconds): ");
            Duration = int.Parse(Console.ReadLine());

            Console.WriteLine("Prepare to begin...");
            DisplayAnimation("Breathe In", Duration);
            DisplayAnimation("Breathe Out", Duration);

            End();
        }

        public override void End()
        {
            Console.WriteLine($"Good job! You have completed the {Name}. Duration: {Duration} seconds.");
            Thread.Sleep(2000);
        }
    }

    class ReflectionActivity : Activity
    {
        public ReflectionActivity()
        {
            Name = "Reflection Activity";
            Description = "This activity will help you reflect on times when you have shown strength and resilience.";
        }

        public override void Start()
        {
            Console.WriteLine($"Starting {Name}: {Description}");
            Console.Write("Enter duration (in seconds): ");
            Duration = int.Parse(Console.ReadLine());

            Console.WriteLine("Prepare to begin...");

            string[] prompts = { "Think of a time when you stood up for someone else.",
                                 "Think of a time when you did something really difficult.",
                                 "Think of a time when you helped someone in need.",
                                 "Think of a time when you did something truly selfless." };

            Random rand = new Random();
            int index = rand.Next(prompts.Length);

            Console.WriteLine(prompts[index]);

            DisplayAnimation("Reflecting", Duration);

            End();
        }

        public override void End()
        {
            Console.WriteLine($"Good job! You have completed the {Name}. Duration: {Duration} seconds.");
            Thread.Sleep(2000);
        }
    }

    class ListingActivity : Activity
    {
        public ListingActivity()
        {
            Name = "Listing Activity";
            Description = "This activity will help you reflect on the good things in your life by listing items.";
        }

        public override void Start()
        {
            Console.WriteLine($"Starting {Name}: {Description}");
            Console.Write("Enter duration (in seconds): ");
            Duration = int.Parse(Console.ReadLine());

            Console.WriteLine("Prepare to begin...");

            string[] prompts = { "Who are people that you appreciate?",
                                 "What are personal strengths of yours?",
                                 "Who are people that you have helped this week?",
                                 "When have you felt the Holy Ghost this month?",
                                 "Who are some of your personal heroes?" };

            Random rand = new Random();
            int index = rand.Next(prompts.Length);

            Console.WriteLine(prompts[index]);
            Thread.Sleep(2000);

            Console.WriteLine("Start listing items:");

            DateTime endTime = DateTime.Now.AddSeconds(Duration);
            int count = 0;
            while (DateTime.Now < endTime)
            {
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    count++;
                }
            }

            Console.WriteLine($"You listed {count} items.");
            Thread.Sleep(2000);

            End();
        }

        public override void End()
        {
            Console.WriteLine($"Good job! You have completed the {Name}. Duration: {Duration} seconds.");
            Thread.Sleep(2000);
        }
    }
}