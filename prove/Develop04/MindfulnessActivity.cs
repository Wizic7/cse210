class MindfulnessActivity : Activity
{

    public MindfulnessActivity() : base("Mindfulness Activity", "This activity will help you become more mindful by drawing your mind to the various senses you are currently experiencing. Follow the prompts as they appear. It is RECCOMNEDED to set the time to more than 60 seconds for this activity.")
    {
    }
    public override void RunActivity(){
        Console.Clear();
        Console.WriteLine("Get Ready...");
        DisplaySpinner(3);

        int temp_time = _time;
        int reamaining_time = temp_time % 10;

        if(reamaining_time == 0){
            reamaining_time = 10;
        }
        
        temp_time -= reamaining_time;
        
        Console.WriteLine("Draw your attention to your breath. Notice when it draws in and then flows out.");
        DisplaySpinner(reamaining_time);
        Console.WriteLine("As you continue to focus on your breath, close your eyes and pay attention to your chest. Notice how it rises and falls without making any judgments.");
        DisplaySpinner(temp_time);
        Console.WriteLine("\nWell Done!!!");
        Console.WriteLine("\nYou have completed another " + _time + " seconds of the Mindfulness Activity!");
        DisplaySpinner(3);

    }

}