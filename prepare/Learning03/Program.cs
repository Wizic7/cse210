using System;
using System.IO;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        Journal journal= new Journal();

        Console.WriteLine("Welcome to the Journal Program!");
        

        int response = 0;
        while (response != 5){
            Console.WriteLine("Please select one of the following chioces:");
            Console.WriteLine("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.WriteLine("What would you like to do?");
            response = int.Parse(Console.ReadLine());

            if (response == 1){
                journal.StoreResponse();
            }
            else if (response == 2){
                journal.ViewJournal();
            }
            else if (response == 3){
                journal.LoadJournal();
            }
            else if (response == 4){
                journal.SaveJournal();
            }

        }
    }
}