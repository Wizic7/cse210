using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment Matt = new Assignment("Matt Smith", "Robotics");
        MathAssignment Roberto = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        WritingAssignment Mary = new WritingAssignment("Mary Pratt", "Writing 210", "War and Peace");
        Console.WriteLine(Matt.GetSummary());
        Console.WriteLine();
        Console.WriteLine(Roberto.GetSummary());
        Console.WriteLine(Roberto.GetHomeworkList());
        Console.WriteLine();
        Console.WriteLine(Mary.GetSummary());
        Console.WriteLine(Mary.GetWritingInformation());
    }
}