import pickle

class Goal:
    def __init__(self, name):
        self.name = name
        self.completed = False

    def complete(self):
        self.completed = True

    def is_completed(self):
        return self.completed

class SimpleGoal(Goal):
    def __init__(self, name, points):
        super().__init__(name)
        self.points = points

    def complete(self):
        super().complete()
        return self.points

class EternalGoal(Goal):
    def __init__(self, name, points_per_completion):
        super().__init__(name)
        self.points_per_completion = points_per_completion

    def complete(self):
        super().complete()
        return self.points_per_completion

class ChecklistGoal(Goal):
    def __init__(self, name, points_per_completion, target_count, bonus_points):
        super().__init__(name)
        self.points_per_completion = points_per_completion
        self.target_count = target_count
        self.completed_count = 0
        self.bonus_points = bonus_points

    def complete(self):
        super().complete()
        self.completed_count += 1
        if self.completed_count == self.target_count:
            return self.points_per_completion + self.bonus_points
        else:
            return self.points_per_completion

class User:
    def __init__(self, name):
        self.name = name
        self.goals = []
        self.score = 0

    def add_goal(self, goal):
        self.goals.append(goal)

    def record_event(self, goal_name):
        for goal in self.goals:
            if goal.name == goal_name:
                points_earned = goal.complete()
                self.score += points_earned
                print(f"You earned {points_earned} points for completing '{goal_name}'.")
                return
        print(f"No goal with name '{goal_name}' found.")

    def display_score(self):
        print(f"{self.name}'s score: {self.score}")

    def display_goals(self):
        print(f"{self.name}'s goals:")
        for goal in self.goals:
            if isinstance(goal, ChecklistGoal):
                print(f"- {goal.name}: {'Completed' if goal.is_completed() else 'Not Completed'} {goal.completed_count}/{goal.target_count} times")
            else:
                print(f"- {goal.name}: {'Completed' if goal.is_completed() else 'Not Completed'}")

    def save(self, filename):
        with open(filename, 'wb') as file:
            pickle.dump(self, file)

    @staticmethod
    def load(filename):
        with open(filename, 'rb') as file:
            return pickle.load(file)

# Example usage:

# Create user
user = User("John")

# Create goals
read_scriptures_goal = EternalGoal("Read Scriptures", 100)
run_marathon_goal = SimpleGoal("Run Marathon", 1000)
attend_temple_goal = ChecklistGoal("Attend Temple", 50, 10, 500)

# Add goals to user
user.add_goal(read_scriptures_goal)
user.add_goal(run_marathon_goal)
user.add_goal(attend_temple_goal)

# Record events
user.record_event("Read Scriptures")
user.record_event("Run Marathon")
user.record_event("Attend Temple")
user.record_event("Attend Temple")  # Record twice for checklist goal

# Display user's score and goals
user.display_score()
user.display_goals()

# Save user data
user.save("user_data.pkl")

# Load user data
loaded_user = User.load("user_data.pkl")
loaded_user.display_score()
loaded_user.display_goals()