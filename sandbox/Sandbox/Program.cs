using System;
using System.Reflection.Metadata.Ecma335;

class Program
{
       static void Main(string[] args)
    {
    }



    static void shoppingList(){
                Console.WriteLine("Hello Sandbox World!");
        Console.WriteLine(" ________________________");
        Console.WriteLine("|                        |");
        Console.WriteLine("|    __|__      _____    |");
        Console.WriteLine("|      |                 |");
        Console.WriteLine("|               \\  /     |");
        Console.WriteLine("|     ()         \\/      |");
        Console.WriteLine("|   _______      /\\      |");
        Console.WriteLine("|     ()        /  \\     |");
        Console.WriteLine("|________________________|");
        Console.WriteLine("|                        |");
        Console.WriteLine("|                        |");
        Console.WriteLine("|                        |");
        Console.WriteLine("|                        |");
        Console.WriteLine("|                        |");
        Console.WriteLine("|________________________|");

        Console.WriteLine();

        List<String> shoppingList = new List<String>();
        Boolean shoping = true;
        Console.WriteLine("Welcome to my store! Type \"done\" when you finish shopping.");
        while(shoping)
        {
            Console.Write("What would you like to buy? ");
            String order = Console.ReadLine();
            if(order == "done")
            {
                shoping = false;
            }
            else{
                shoppingList.Add(order);
            }
        }
        Console.WriteLine("Grocery List (" + shoppingList.Count + " items)");
        foreach(String item in shoppingList)
        {
            Console.WriteLine("* " + item);
        }
    }


}