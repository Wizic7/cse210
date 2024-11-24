class SimpleGoal : Goal
{
public SimpleGoal() : base("simple")
{
    _maxCompletions = 1;
}

public SimpleGoal(string[] Json) : base("simple", Json)
{
}
}