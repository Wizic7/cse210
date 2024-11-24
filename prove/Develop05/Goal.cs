using System.Dynamic;
using System.Text.Json;

abstract class Goal
{
private string _goalType;
private string _name;
private string _description;
protected int _timesCompleted;
private int _points;
protected int _maxCompletions;

public Goal(string goalType)
{
    _goalType = goalType;
    Console.Write("What is the name of your goal? ");
    _name = Console.ReadLine();
    Console.Write("What is a short description of your goal? ");
    _description = Console.ReadLine();
    _points = GetValidIntFromPrompt("How many points are associated with this goal? ");
}

public string DisplayName(){
    return _name;
}
public virtual string DisplayInfo()
{
    String completion = " ";
    if(_timesCompleted == _maxCompletions)
    {
        completion = "X";
    }
    return "[" + completion + "] " + _name + " (" + _description + ")";
}
protected virtual string[] CreateJson()
{
    return [
        "'_goalType':" + _goalType,
        "'_name':" + _name,
        "'_description':" + _description,
        "'_times_completed':" + _timesCompleted,
        "'_points':" + _points,
        "'_maxCompletions:'" + _maxCompletions
    ];
}

public string getJSON(){
    string[] JSON = CreateJson();
    string output = "";
    foreach (string line in JSON)
    {
        output+= line + ",";
    }
    return "[" + output + "]";
}

public virtual void DecomposeJSON(string jsonString){
    Goal goal = JsonSerializer.Deserialize<Goal>(jsonString)!;
    Console.WriteLine("" + goal._name);
}
public virtual int GetPoints()
{
    return _points * _timesCompleted;
}

public virtual void RecordEvent()
{
    if(_timesCompleted < _maxCompletions)
    {
        _timesCompleted++;
        Console.WriteLine("Congradulations! You have earned " + _points + " points!");
    }
    else
    {
        Console.WriteLine("You have already completed this goal");
    }
    
}

protected int GetValidIntFromPrompt(string input)
{
    Boolean is_not_int = true;
    while(is_not_int)
    {
        Console.Write(input);
        if(Int32.TryParse(Console.ReadLine(), out int _to_return))
        {
            return _to_return;
        }
        else
        {
            Console.WriteLine("Sorry that's not a whole number please try again");
        }
    }
    return -1;
}

}