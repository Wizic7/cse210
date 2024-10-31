class Assignment 
{
    protected String _studentName;
    protected String _topic;

    public Assignment(String studentName, String topic)
    {
        _studentName = studentName;
        _topic = topic;
    }
    public string GetSummary(){
        return _studentName + " - " + _topic;
    }
}