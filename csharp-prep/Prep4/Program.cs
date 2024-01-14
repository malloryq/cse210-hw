using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");

        List<int> numbers = new List<int>();

        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Please enter a number (0 to quit): ");

            string userResponse = Console.ReadLine();

            if (int.TryParse(userResponse, out userNumber))
            {
                if (userNumber != 0)
                {
                    numbers.Add(userNumber);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        if (numbers.Count > 0)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine($"The Sum is: {sum}");

            float average = ((float)sum) / numbers.Count;
            Console.WriteLine($"The Average is: {average}");

            int max = numbers[0];

            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            Console.WriteLine($"The Max is: {max}");
        }
        else
        {
            Console.WriteLine("No numbers entered.");
        }
    }
}