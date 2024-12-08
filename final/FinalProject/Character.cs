abstract class Character
{
    private string _name;
    private int _attack;
    private int _defense;
    private LifeBarData _lifeBar;

    public abstract void displayCharacter();
    public Character(string name, int attack, int defense, int max_life)
    {
        _name = name;
        _attack = attack;
        _defense = defense;
        _lifeBar = new LifeBarData(max_life);
    }

    public int getAttack()
    {
        return _attack;
    }

    public int getDefense()
    {
        return _defense;
    }

    public string getName()
    {
        return _name;
    }

    public LifeBarData GetLifeBarData()
    {
        return _lifeBar;
    }


}