using System;

class Program
{
    static void Main(string[] args)
    {
        
        
        Boolean another = true;
        
        while (another == true){
            another = false;

            Random randomgenerator =  new Random();
            int magic = randomgenerator.Next(1, 100);
            // Console.Write("What is the magic number?");
            // int magic = int.Parse(Console.ReadLine());
            int guess = -1;
            while (guess != magic){
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if(guess < magic){
                    Console.WriteLine("Higher");
                }
                if(guess > magic){
                    Console.WriteLine("Lower");
                }
                if(guess == magic){
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.WriteLine("Would you like to play another game? (Y/N)");
            string response = Console.ReadLine();
            if(response == "Y" || response == "y")
            {
                another = true;
            }
        }

    }
}