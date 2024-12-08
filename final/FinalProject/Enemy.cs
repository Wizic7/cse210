class Enemy : Character
{
    public Enemy(string name, int attack, int defense, int max_life) : base(name, attack, defense, max_life)
    {
    }
    
    public override void displayCharacter()
    {
        throw new NotImplementedException();
    }
}