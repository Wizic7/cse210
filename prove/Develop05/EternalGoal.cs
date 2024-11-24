class EternalGoal : Goal
{
public EternalGoal() : base("eternal")
{
    _maxCompletions = int.MaxValue;
}
public EternalGoal(string[] Json) : base("eternal", Json)
{
}
}