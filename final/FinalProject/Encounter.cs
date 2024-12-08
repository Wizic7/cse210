class Encounter
{
    public PlayerData _player;
    public Enemy _enemy;
    public Encounter(PlayerData player, Enemy enemy)
    {
        _player = player;
        _enemy = enemy;
    }
}