public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public List<String> _prompts = new List<String>();
    public Entry(){

        _prompts = [
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What questions did I ask today?",
            "Who did I touch today?"
        ];

        _prompt = getPrompt();
    }

    public string getPrompt()
    {
        Random random = new Random();

        return _prompts[random.Next(0, _prompts.Count)];
    }
}