using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {

        String Option = "";
        while (Option != "5"){
            Console.Clear();
            Console.Write("");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("   1. Start breathing activity");
            Console.WriteLine("   2. Start reflecting activity");
            Console.WriteLine("   3. Start listing activity");
            Console.WriteLine("   4. Start mindfulness activity");
            Console.WriteLine("   5. Quit");
            Console.WriteLine("Select a choice from the menu: ");
            Option = Console.ReadLine().Trim();

            switch (Option)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.RunActivity();
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.RunActivity();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.RunActivity();
                    break;
                case "4":
                    MindfulnessActivity mindful = new MindfulnessActivity();
                    mindful.RunActivity();
                    break;
            }

                        
        }

    }
}