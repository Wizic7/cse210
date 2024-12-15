class Enemy : Character
{
    private int _expValue;
    public Enemy(string name, int attack, int defense, int max_life, int expValue) : base(name, attack, defense, max_life)
    {
        _expValue = expValue;
    }
    
    public override char[] displayCharacter()
    {
        return _name.Substring(0, 3).ToCharArray();
    }

    public int getEXPValue()
    {
        return _expValue;
    }

}