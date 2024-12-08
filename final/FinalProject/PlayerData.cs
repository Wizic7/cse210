class PlayerData : Character
{
    private LevelSystem _level;

    public PlayerData(string name, int attack, int defense, int max_life) : base(name, attack, defense, max_life)
    {
        _level = new LevelSystem();
    }

    public override void displayCharacter()
    {
        throw new NotImplementedException();
    }
}