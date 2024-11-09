class BreathingActivity : Activity
{

    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by giving cues when to breath in and when to breath out slowly. Focus on your breathing to center your mind during the activity")
    {
        // String name = "Breathing Activity";
        // String description = "This activity will help you relax by giving cues when to breath in and when to breath out slowly. Focus on your breathing to center your mind during the activity";
        
    }
    public override void RunActivity(){
        Console.Clear();
        Console.WriteLine("Get Ready...");
        DisplaySpinner(3);

        int temp_time = _time;
        int reamaining_time = temp_time % 10;
        temp_time -= reamaining_time;
        int breaths =  temp_time / 10;

        if(reamaining_time == 0){
            reamaining_time = 10;
            breaths =- 1;
        }

        int extra_second = 0;
        if(reamaining_time % 2 == 1){
            reamaining_time -= 1;
            extra_second = 1;
        }
        
        Console.Write("\nBreathe in...");
        DisplayCountdown(reamaining_time/2 + extra_second);
        Console.Write("\nNow breath out...");
        DisplayCountdown(reamaining_time/2);

        for(int x = 0; x < breaths; x++)
        {
            Console.Write("\n\nBreathe in...");
            DisplayCountdown(4);
            Console.Write("\nNow breath out...");
            DisplayCountdown(6);
        } 

        Console.WriteLine("\nWell Done!!!");
        Console.WriteLine("\nYou have completed another " + _time + " seconds of the Breathing Activity!");
        DisplaySpinner(3);

    }

}