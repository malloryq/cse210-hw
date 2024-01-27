using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create a sample scripture
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life.");

        // Start the memorization process
        while (!scripture.AllWordsHidden)
        {
            Console.Clear();
            scripture.Display();

            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;

            scripture.HideRandomWords();
        }
    }
}

class Scripture
{
    private Reference reference;
    private List<Word> words;
    private Random random;

    public Scripture(string referenceText, string scriptureText)
    {
        reference = new Reference(referenceText);
        words = scriptureText.Split(' ').Select(word => new Word(word)).ToList();
        random = new Random();
    }

    public bool AllWordsHidden => words.All(word => word.IsHidden);

    public void Display()
    {
        Console.WriteLine($"{reference}: {string.Join(" ", words.Select(word => word.IsHidden ? "___" : word.Text))}");
    }

    public void HideRandomWords()
    {
        int wordsToHide = random.Next(1, words.Count(word => !word.IsHidden) + 1);

        for (int i = 0; i < wordsToHide; i++)
        {
            Word wordToHide = words.Where(word => !word.IsHidden).OrderBy(_ => random.Next()).First();
            wordToHide.Hide();
        }
    }
}

class Reference
{
    public string Text { get; private set; }

    public Reference(string referenceText)
    {
        Text = referenceText;
    }
}

class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string wordText)
    {
        Text = wordText;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }
}