using System.Runtime.CompilerServices;

class LifeBarData {
    private int _current_health;
    private  int _total_health;
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

    public Boolean isAlive()
    {
        return _current_health > 0;
    }

    public int getHealth()
    {
        return _current_health;
    }
    public void increaseMaxHealth(int change)
    {
        _total_health += change;
    }

    public string displayLife()
    {
        return _current_health + "/" + _total_health;
    }

    public void resetHealth()
    {
        _current_health = _total_health;
    }

    public void changeLife(int change)
    {
        if(_current_health + change > _total_health)
        {
            _current_health = _total_health;
        }
        else
        {
            _current_health += change;
        }
    }
}