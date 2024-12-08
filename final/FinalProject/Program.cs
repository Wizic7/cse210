using System;

class Program
{
    static void Main(string[] args)
    {
        PlayerData Test = new PlayerData("John", 15, 25, 2);
        Enemy Goblin = new Enemy("Goblin", 26, 10, 10);

        string hero = Test.getName();
        Console.WriteLine(hero + "attacks a " + Goblin.getName());
        Console.WriteLine(hero + " did " + DamageCalculator.calculateDamage(Test.getAttack(), Goblin.getDefense()) + " damage!");
    }
}