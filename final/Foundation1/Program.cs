using System;
using System.Collections.Generic;

public class Video
{
    private string title;
    private string author;
    private int length;
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        this.title = title;
        this.author = author;
        this.length = length;
        this.comments = new List<Comment>();
    }

    public void AddComment(string commenter, string text)
    {
        Comment comment = new Comment(commenter, text);
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Length: {length} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");

        foreach (Comment comment in comments)
        {
            Console.WriteLine($"Comment by {comment.Commenter}: {comment.Text}");
        }
    }
}

public class Comment
{
    private string commenter;
    private string text;

    public Comment(string commenter, string text)
    {
        this.commenter = commenter;
        this.text = text;
    }

    public string Commenter
    {
        get { return commenter; }
    }

    public string Text
    {
        get { return text; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Video 1", "Author 1", 120);
        Video video2 = new Video("Video 2", "Author 2", 180);

        video1.AddComment("User1", "Nice video!");
        video1.AddComment("User2", "I loved it!");
        video2.AddComment("User3", "Great content!");

        Console.WriteLine("Video 1 Details:");
        video1.DisplayDetails();

        Console.WriteLine("\nVideo 2 Details:");
        video2.DisplayDetails();
    }
}