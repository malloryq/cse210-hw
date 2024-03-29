using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your current grade percentage? ");
        string answer = Console.ReadLine();

        if (int.TryParse(answer, out int percent))
        {
            string letter = "";

            if (percent >= 90)
            {
                letter = "A";
            }
            else if (percent >= 80)
            {
                letter = "B";
            }
            else if (percent >= 70)
            {
                letter = "C";
            }
            else if (percent >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            Console.WriteLine($"Your current grade is: {letter}");

            if (percent >= 70)
            {
                Console.WriteLine("You did it! You passed YAY!");
            }
            else
            {
                Console.WriteLine("You didn't pass this time, try again!");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}
