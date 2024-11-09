class ListingActivity : Activity
{
    private String[] _prompts;

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = [
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        ];
    }

    public override void RunActivity(){
        Console.Clear();
        Console.WriteLine("Get Ready...");
        DisplaySpinner(3);

        Random rng = new Random();
        Console.WriteLine("List as many as you can of the following prompt:");
        Console.WriteLine(" --- " + _prompts[rng.Next(0, _prompts.Length)] + " ---");
        Console.Write("You may begin in: ");
        DisplayCountdown(5);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_time);
        DateTime currentTime = DateTime.Now;

        int count = 0;

        while(currentTime < endTime)
        {
            Console.Write("\n> ");
            Console.ReadLine();
            count++;
            currentTime = DateTime.Now;
        }

        Console.WriteLine("\nYou listed " + count + " items!");

        Console.WriteLine("\nWell done!!");
        DisplaySpinner(2);
        Console.WriteLine("\nYou have completed another " + _time + " seconds of the " + _name + "!");
        DisplaySpinner(3);
    }   
}