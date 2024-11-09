using System.ComponentModel;

class ReflectionActivity : Activity
{
    private String[] _prompts;
    private String[] _questions;

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power that you have and how you can use it in other aspects of your life.")
    {
        _prompts = [
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you felt successful"
        ];
        _questions = [
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        ];
    }

    public override void RunActivity(){
        Console.Clear();
        Console.WriteLine("Get Ready...");
        DisplaySpinner(3);

        Random rng = new Random();
        String chosen_prompt = _prompts[rng.Next(0, _prompts.Length)];

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine("\n --- " + chosen_prompt + " ---");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("\nNow ponder each of the following questions as they related to the experience.");
        Console.Write("You may begin in: ");
        DisplayCountdown(5);

        Console.Clear();
        Console.WriteLine(" --- " + chosen_prompt + " ---");

        //Ask a new question every 5 seconds
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_time);
        DateTime currentTime = DateTime.Now;
        int temp_time = _time;
        int time_per_question = 5;
        int reamaining_time = temp_time % time_per_question;
        temp_time -= reamaining_time;
        int total_questions =  temp_time / time_per_question;

        if(reamaining_time == 0){
            reamaining_time = time_per_question;
            total_questions -= 1;
        }

        //If we're gonna ask too many questions, divide the time so it's spread evenly among all but the first question
        if(total_questions > _questions.Length-1)
        {
            temp_time = _time;
            reamaining_time = temp_time % _questions.Length-1;
            temp_time -= reamaining_time;
            time_per_question = temp_time / _questions.Length-1;
            total_questions =  _questions.Length-1;
            
        }

        int next_question_index = rng.Next(0, _questions.Length);
        String next_question = _questions[next_question_index];
        List<int> asked_questions = new List<int>();
        asked_questions.Append(next_question_index);

        Console.Write(" > " + next_question + " ");
        DisplaySpinner(reamaining_time);

        for(int x = 0; x < total_questions; x++)
        {   
            next_question_index = rng.Next(0, _questions.Length);
            while(asked_questions.Contains(next_question_index) == true)
            {
                next_question_index = rng.Next(0, _questions.Length);
            }
            asked_questions.Append(next_question_index);
            next_question = _questions[next_question_index];
            Console.Write("\n > " + next_question + " ");
            DisplaySpinner(reamaining_time);
        }

        Console.WriteLine("\n\nWell done!!");
        Console.WriteLine("\nYou have completed another " + _time + " seconds of the " + _name + "!");
        DisplaySpinner(3);
    }
}