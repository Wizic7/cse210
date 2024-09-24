using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> nums = new List<int>();
        int num = 1;
        while (num != 0){
            Console.Write("Enter a number: ");
            num = int.Parse(Console.ReadLine());

            if(num != 0){
                nums.Add(num);
            }
        }
        int max = nums.Max();
        nums.Sort();
        int smolButPositive = nums[nums.Count-1];
        int sum = 0;

        foreach (int x in nums) {
            sum += x;
            if(x > 0 && x < smolButPositive)
            {
                smolButPositive = x;
            }
        }

        double average = sum / (nums.Count + 0.0);

        Console.WriteLine("The sum is: " + sum);
        Console.WriteLine("The average is: " + average);
        Console.WriteLine("The largest number is: " + max);
        if(smolButPositive < 0){
            Console.WriteLine("The smallest positive number is... there are no positives here.");
        }
        else {
        Console.WriteLine("The smallest positive number is: " + smolButPositive);
        }
        Console.WriteLine("The sorted list:");
        foreach (int x in nums) {
            Console.WriteLine("" + x);
        }
    }
}