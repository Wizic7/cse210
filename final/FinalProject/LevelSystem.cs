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

    public void gainExp(PlayerData player, int value)
    {
        _exp += value;
        while( _level_Threshold <= _exp)
        {
            _level++;
            _exp -= _level_Threshold;
            _level_Threshold = Convert.ToInt32(_level_Threshold * 1.5);
            player.LevelUp();
        }
    }

    public int getLevel()
    {
        return _level;
    }

    public string getExp()
    {
        return _exp + "/" + _level_Threshold;
    }
}