using System;

public class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public Address(string streetAddress, string city, string state, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public string GetFullAddress()
    {
        return $"{streetAddress}, {city}, {state}, {country}";
    }

    public bool IsInUSA()
    {
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }
}

public class Event
{
    private string _title;
    private string _description;
    private DateTime _date;
    private string _time;
    private Address _address;

    public Event(string title, string description, DateTime date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {_title}\nDescription: {_description}\nDate: {_date.ToShortDateString()}\nTime: {_time}\nAddress: {_address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Event Type: Standard\nTitle: {_title}\nDate: {_date.ToShortDateString()}";
    }
}

public class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return base.GetStandardDetails() + $"\nEvent Type: Lecture\nSpeaker: {_speaker}\nCapacity: {_capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Event Type: Lecture\nTitle: {_title}\nDate: {_date.ToShortDateString()}";
    }
}

public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string title, string description, DateTime date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return base.GetStandardDetails() + $"\nEvent Type: Reception\nRSVP Email: {_rsvpEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Event Type: Reception\nTitle: {_title}\nDate: {_date.ToShortDateString()}";
    }
}

public class OutdoorGathering : Event
{
    private string _weatherStatement;

    public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weatherStatement)
        : base(title, description, date, time, address)
    {
        _weatherStatement = weatherStatement;
    }

    public override string GetFullDetails()
    {
        return base.GetStandardDetails() + $"\nEvent Type: Outdoor Gathering\nWeather Statement: {_weatherStatement}";
    }

    public override string GetShortDescription()
    {
        return $"Event Type: Outdoor Gathering\nTitle: {_title}\nDate: {_date.ToShortDateString()}";
    }
}

class Program3
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "City", "State", "Country");
        Address address2 = new Address("456 Elm St", "Town", "Province", "Country");

        Event lecture = new Lecture("Lecture on AI", "Introduction to Artificial Intelligence", new DateTime(2024, 2, 20), "10:00 AM", address1, "Dr. Smith", 50);
        Event reception = new Reception("Company Anniversary Reception", "Celebrating 10 Years of Success", new DateTime(2024, 3, 15), "7:00 PM", address2, "rsvp@example.com");
        Event outdoorGathering = new OutdoorGathering("Summer Picnic", "Annual Company Picnic", new DateTime(2024, 6, 1), "12:00 PM", address1, "Sunny weather expected");

        Console.WriteLine("Lecture Details:");
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine("\nReception Details:");
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine("\nOutdoor Gathering Details:");
        Console.WriteLine(outdoorGathering.GetFullDetails());

        Console.WriteLine("\nShort Descriptions:");
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine(outdoorGathering.GetShortDescription());
    }
}