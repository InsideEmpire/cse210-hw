using System;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals;
        int score;
        void CreateGoal()
        {
            int goalChoice;
            Console.Clear();
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("   1. Simple Goal");
            Console.WriteLine("   2. Eternal Goal");
            Console.WriteLine("   3. Checklist Goal");
            Console.WriteLine("   4. Negative Goal");
            Console.Write("Which type of goal would you like to create? ");
            goalChoice = int.Parse(Console.ReadLine());
            switch (goalChoice)
            {
                case 1:
                    goals.Add(new SimpleGoal());
                    break;
                case 2:
                    goals.Add(new EternalGoal());
                    break;
                case 3:
                    goals.Add(new ChecklistGoal());
                    break;
                case 4:
                    goals.Add(new NegativeGoal());
                    break;
                default:
                    break;
            }
        }
        void ListGoals()
        {
            Console.Clear();
            Console.WriteLine($"You now have {score} points. ");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                goals[i].Display();
            }
            Console.ReadLine();
        }
        void SaveGoals()
        {
            Console.Write("What is the filename? ");
            string filename = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(score);

                foreach (Goal g in goals)
                {
                    writer.WriteLine(g.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved.");
            Console.ReadLine();
        }
        void LoadGoals()
        {
            Console.Write("What is the filename? ");
            string filename = Console.ReadLine();

            string[] lines = File.ReadAllLines(filename);

            goals.Clear();

            score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("|");

                string type = parts[0];

                if (type == "SimpleGoal")
                {
                    goals.Add(new SimpleGoal(parts));
                }
                else if (type == "EternalGoal")
                {
                    goals.Add(new EternalGoal(parts));
                }
                else if (type == "ChecklistGoal")
                {
                    goals.Add(new ChecklistGoal(parts));
                }
                else if (type == "NegativeGoal")
                {
                    goals.Add(new NegativeGoal(parts));
                }
            }

            Console.WriteLine("Goals loaded.");
            Console.ReadLine();
        }
        void RecordEvent()
        {
            int i = 0;
            Console.Clear();
            Console.WriteLine("The goals are: ");
            for (; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetName()}");
            }
            Console.Write("Which goal did you accomplished? ");
            i = int.Parse(Console.ReadLine()) - 1;
            score += goals[i].RecordEvent();
            Console.WriteLine($"You now have {score} points. ");
            Console.ReadLine();
        }

        goals = new List<Goal>();
        score = 0;
        int choice;
        do
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("    1. Create New Goal");
            Console.WriteLine("    2. List Goals");
            Console.WriteLine("    3. Save Goals");
            Console.WriteLine("    4. Load Goals");
            Console.WriteLine("    5. Record Event");
            Console.WriteLine("    6. Quit");
            Console.WriteLine("Select a choice from the menu: ");
            Console.Write(" > ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                default:
                    return;
            }
        } while (choice != 6);
    }
}