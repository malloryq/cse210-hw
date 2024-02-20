using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

abstract class Goal {
    private string _name;
    protected bool _completed;

    public Goal(string name) {
        _name = name;
        _completed = false;
    }

    public void Complete() {
        _completed = true;
    }

    public bool IsCompleted() {
        return _completed;
    }

    public string GetName() {
        return _name;
    }
}

class SimpleGoal : Goal {
    private int _points;

    public SimpleGoal(string name, int points) : base(name) {
        _points = points;
    }

    public int Complete() {
        base.Complete();
        return _points;
    }
}

class EternalGoal : Goal {
    private int _pointsPerCompletion;

    public EternalGoal(string name, int pointsPerCompletion) : base(name) {
        _pointsPerCompletion = pointsPerCompletion;
    }

    public int GetPointsPerCompletion() {
        return _pointsPerCompletion;
    }
}

class ChecklistGoal : Goal {
    private int _pointsPerCompletion;
    private int _targetCount;
    private int _completedCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, int pointsPerCompletion, int targetCount, int bonusPoints) : base(name) {
        _pointsPerCompletion = pointsPerCompletion;
        _targetCount = targetCount;
        _completedCount = 0;
        _bonusPoints = bonusPoints;
    }

    public int Complete() {
        base.Complete();
        _completedCount++;
        if (_completedCount == _targetCount) {
            return _pointsPerCompletion + _bonusPoints;
        }
        return _pointsPerCompletion;
    }

    public string GetProgress() {
        return $"{_completedCount}/{_targetCount}";
    }
}

class User {
    private string _name;
    private List<Goal> _goals;
    private int _score;

    public User(string name) {
        _name = name;
        _goals = new List<Goal>();
        _score = 0;
    }

    public void AddGoal(Goal goal) {
        _goals.Add(goal);
    }

    public void RecordEvent(string goalName) {
        foreach (Goal goal in _goals) {
            if (goal.GetName() == goalName) {
                _score += goal.Complete();
                return;
            }
        }
        Console.WriteLine($"No goal with name '{goalName}' found.");
    }

    public void DisplayScore() {
        Console.WriteLine($"{_name}'s score: {_score}");
    }

    public void DisplayGoals() {
        Console.WriteLine($"{_name}'s goals:");
        foreach (Goal goal in _goals) {
            if (goal is ChecklistGoal) {
                ChecklistGoal checklistGoal = (ChecklistGoal)goal;
                Console.WriteLine($"- {checklistGoal.GetName()}: {(checklistGoal.IsCompleted() ? "Completed" : "Not Completed")} {checklistGoal.GetProgress()} times");
            } else {
                Console.WriteLine($"- {goal.GetName()}: {(goal.IsCompleted() ? "Completed" : "Not Completed")}");
            }
        }
    }

    public void Save(string filename) {
        using (FileStream fileStream = new FileStream(filename, FileMode.Create)) {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, this);
        }
    }

    public static User Load(string filename) {
        using (FileStream fileStream = new FileStream(filename, FileMode.Open)) {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return (User)binaryFormatter.Deserialize(fileStream);
        }
    }
}

class Program {
    static void Main(string[] args) {
        User user = new User("John");

        EternalGoal readScripturesGoal = new EternalGoal("Read Scriptures", 100);
        SimpleGoal runMarathonGoal = new SimpleGoal("Run Marathon", 1000);
        ChecklistGoal attendTempleGoal = new ChecklistGoal("Attend Temple", 50, 10, 500);

        user.AddGoal(readScripturesGoal);
        user.AddGoal(runMarathonGoal);
        user.AddGoal(attendTempleGoal);

        user.RecordEvent("Read Scriptures");
        user.RecordEvent("Run Marathon");
        user.RecordEvent("Attend Temple");
        user.RecordEvent("Attend Temple");

        user.DisplayScore();
        user.DisplayGoals();

        user.Save("user_data.dat");

        User loadedUser = User.Load("user_data.dat");
        loadedUser.DisplayScore();
        loadedUser.DisplayGoals();
    }
}
