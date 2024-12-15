using System;

class Program
{
    // When done, cd to FinalProject folder, run dotnet build, check it with dotnet run, and then do dotnet publish
    static void Main(string[] args)
    {
        // string hero = Player.getName();
        // Console.WriteLine(hero + "attacks a " + Goblin.getName());
        // Console.WriteLine(hero + " did " + DamageCalculator.calculateDamage(Player, Goblin) + " damage!");
        Console.WriteLine("Welcome adventurer what is your name?");
        string name = Console.ReadLine();
        
        PlayerData player = new PlayerData(name, 10, 2, 20);
        Story yourAdventure = new Story(player);

        Boolean playing = true;
        while (playing)
        {
            Console.Clear();
            Console.WriteLine("Welcome back to your Adventure! What would you like to do next?");
            Console.WriteLine("1. See my stats");
            Console.WriteLine("2. Explore");
            Console.WriteLine("3. Quit Playing");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    player.displayStats();
                    Console.ReadLine();
                    break;
                case "2":
                    string[] unlockedAreas = yourAdventure.getEncounterNames();
                    Console.Clear();
                    Console.WriteLine("Where would you like to explore?");
                    for (int i = 0; i < unlockedAreas.Length; i++)
                    {
                        if (i % 5 == 0 && i > 0)
                        {
                            Console.WriteLine();
                        }
                        Console.Write( i+1 + ". " + unlockedAreas[i] + "    ");
                    }
                    Console.WriteLine();
                    int area = Int32.Parse(Console.ReadLine())-1;
                    if(area < unlockedAreas.Length)
                    {
                        yourAdventure.runEncounter(area);
                    }
                    break;
                case "3":
                    playing = false;
                    break;
            }

            
        }
    }
}