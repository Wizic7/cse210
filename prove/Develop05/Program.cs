using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Boolean is_looping = true;
        int total_points = 0;
        string filename = "";

        List<Goal> goal_list = new List<Goal>();
        while(is_looping)
        {
            Console.WriteLine("\nYou have " + total_points + " points.");
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1.Create New Goal");
            Console.WriteLine("2.List Goals");
            Console.WriteLine("3.Save Goals");
            Console.WriteLine("4.Load Goals");
            Console.WriteLine("5.Record Event");
            Console.WriteLine("6.Quit");
            Console.Write("Select a choice from the menu: ");
            int choice = 0;
            while(choice == 0)

            if(Int32.TryParse(Console.ReadLine(), out choice))
            {
                switch(choice)
                {
                    //Create Goal
                    case 1:
                        choice = 0;
                        Console.WriteLine("The types of goals are:");
                        Console.WriteLine("   1. Simple Goal");
                        Console.WriteLine("   2. Eternal Goal");
                        Console.WriteLine("   3. Checklist Goal");
                        Console.Write("What kind of goal would you like to set? ");
                        while(choice == 0)

                        if(Int32.TryParse(Console.ReadLine(), out choice))
                        {
                            switch (choice){
                                case 1:
                                    goal_list.Add(new SimpleGoal());
                                    break;
                                case 2:
                                    goal_list.Add(new EternalGoal());
                                    break;
                                case 3:
                                    goal_list.Add(new ChecklistGoal());
                                    break;
                                default:
                                    Console.WriteLine("There is no such goal type.");
                                    break;
                            }
                        }
                        break;

                    //List Goals
                    case 2:
                        int count = 0;
                        foreach (Goal goal in goal_list){
                            count++;
                            Console.WriteLine( count + ". " + goal.DisplayInfo());
                        }
                        break;
                    //Save Goals
                    case 3:
                        Console.Write("What is the name of your file?");
                        filename = Console.ReadLine();

                        using (StreamWriter outputFile = new StreamWriter(filename))
                        {
                            outputFile.WriteLine(total_points);
                            foreach (Goal goal in goal_list){
                                outputFile.WriteLine(goal.getJSON());
                            }
                        }
                        break;
                    //Load Goals
                    case 4:
                        Console.Write("What is the name of the file to load? ");
                        filename = Console.ReadLine();
                        string[] lines = System.IO.File.ReadAllLines(filename);
                        total_points = Int32.Parse(lines[0]);
                        string JSON = "";
                        for (int i = 1; i< lines.Length; i++) 
                        {
                            JSON += lines[i].Trim();
                        }
                        break;
                    //Record Event
                    case 5:
                        Console.WriteLine("Your goals are:");
                        int couter = 0;
                        foreach (Goal goal in goal_list)
                        {
                            couter++;
                            Console.WriteLine(couter + ". " + goal.DisplayName());
                        }
                        Console.WriteLine("What goal did you acomplish? ");
                        int completed = Int32.Parse(Console.ReadLine());
                        int orignial_points = goal_list[completed-1].GetPoints();
                        goal_list[completed-1].RecordEvent();
                        total_points += goal_list[completed-1].GetPoints() - orignial_points;
                        break;
                    //Quit
                    case 6:
                        is_looping = false;
                        break;
                }
                
            }
        }
    }
}