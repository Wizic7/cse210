using System.Dynamic;

class LevelSystem
{
    private int _level;
    private int _exp;
    private int _level_Threshold;

    
    // Add skill level unlock tree here if time
    public LevelSystem(){
        _level = 1;
        _exp = 0;
        _level_Threshold = _level * 10;
    }

    public void gainExp(int value)
    {
        _exp += value;
        if( _level_Threshold <= _exp)
        {
            _level++;
            _exp -= _level_Threshold;
            _level_Threshold = Convert.ToInt32(_level_Threshold * 1.5);
        }
    }

    public int getLevel()
    {
        return _level;
    }

}