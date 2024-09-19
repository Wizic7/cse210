using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int percentage = int.Parse(Console.ReadLine());

    
        string grade = "";
        if(percentage >= 90){
            grade = "A";
        }
        else if(percentage >= 80){
            grade = "B";
        }
        else if(percentage >= 70){
            grade = "C";
        }
        else if(percentage >= 60){
            grade = "D";
        }
        else{
            grade = "F";
        }

        string gradetype = "";
        if(percentage % 10 >= 7){
            gradetype = "+";
        }
        else if(percentage % 10 <= 3){
            gradetype = "-";
        }

        if(percentage >= 97 || grade == "F"){
            gradetype = "";
        }

        Console.WriteLine(grade+gradetype);
        if(percentage >= 70){
            Console.WriteLine("Congradulations! You passed!");
        }
        else{
            Console.WriteLine("You did not pass, but I'm sure youll get it next time!");
        }
    }
}