class PlayerData : Character
{
    private LevelSystem _level;

    public PlayerData(string name, int attack, int defense, int max_life) : base(name, attack, defense, max_life)
    {
        _level = new LevelSystem();
    }

    public override char[] displayCharacter()
    {
        return "\\o/".ToCharArray();
    }

    public override int getAttack()
    {
        return base.getAttack() * _level.getLevel();
    }

    public override int getDefense()
    {
        return base.getDefense() + _level.getLevel();
    }

    public void resetHealth()
    {
        GetLifeBarData().resetHealth();
    }
    public void LevelUp()
    {
        GetLifeBarData().increaseMaxHealth(30);
    }
    public LevelSystem getLevelSystem()
    {
        return _level;
    }

    public void displayStats()
    {
        Console.Clear();
        Console.WriteLine(_name);
        Console.WriteLine("\\o/");
        Console.WriteLine("Level: " + _level.getLevel());
        Console.WriteLine("Exp: " + _level.getExp());
        Console.WriteLine("Attack: " + getAttack());
        Console.WriteLine("Defense: " + getDefense());
        Console.WriteLine("Health: " + GetLifeBarData().displayLife());
    }
}