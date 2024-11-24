class ChecklistGoal : Goal
{

public ChecklistGoal() : base("checklist")
{
    _maxCompletions = GetValidIntFromPrompt("How many times does this goal need to be completed for a bonus? ");
    _bonusPoints = GetValidIntFromPrompt("What is the amount of points for completing this goal that many times? ");
}

public ChecklistGoal(string[] Json) : base("checklist", Json)
{
    
}
public override string DisplayInfo()
{
    return base.DisplayInfo() + " -- Currently Completed " + _timesCompleted + "/" + _maxCompletions;
}
protected override string[] CreateJson()
{
    return base.CreateJson().Concat([
        "'_bonuspoints':" + _bonusPoints
    ]).ToArray();
}
public override int GetPoints()
{
    if(_timesCompleted == _maxCompletions)
    {
        return base.GetPoints() + _bonusPoints;
    }
    return base.GetPoints();
}

    public override void RecordEvent()
    {
        base.RecordEvent();
            if(_timesCompleted == _maxCompletions)
        {
            Console.WriteLine("You have earned an additional " + _bonusPoints + " points for completing this goal " + _timesCompleted + "/" + _maxCompletions + " times!");
        }
    }
}

