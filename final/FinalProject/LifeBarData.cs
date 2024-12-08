class LifeBarData {
    public int _current_health;
    public int _total_health;
    public LifeBarData(int health, int totalhealth) 
    {
        _current_health = health;
        _total_health = totalhealth;
    }

    public LifeBarData(int max_life)
    {
        _current_health = max_life;
        _total_health = max_life;
    }
}