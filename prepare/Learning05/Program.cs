using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");

        double interest = .02;
        double x = 50000;
        double y = x * interest;
        int count = 0;
        while (y < 10000)
        {
            count++;
            x = x + y;
            y = x * interest;
            Console.WriteLine("Account: " + x);
            Console.WriteLine("Interest: " + y);
            // Console.ReadLine();
        }
        Console.WriteLine("" + count);
    }
}