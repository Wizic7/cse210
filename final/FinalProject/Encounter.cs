using System.ComponentModel;

class Encounter
{
    public PlayerData _player;
    public Enemy _enemy;
    public List<Enemy> _enemyList;
    private int _boardSize;
    private int _baseboardSize;
    private int _maxEnemyCount;
    private char[] _board;

    private int _baseEnemyCount;
    private int _enemyCount;
    private int _playerPosition;
    private int[] _enemyPosition;
    public Boolean _encounterFinished;

    public Boolean _isWon;
    private Boolean _canMove;
    public Encounter(PlayerData player, Enemy enemy, int boardSize, int enemyCount)
    {
        _player = player;
        _enemy = enemy;
        _boardSize = boardSize;
        _baseboardSize = boardSize;
        _enemyCount = enemyCount;
        _baseEnemyCount = enemyCount;
        _maxEnemyCount = enemyCount;
        _enemyList = new List<Enemy>();

        int playerSize = _player.displayCharacter().Length + 1;
        //Account for some strange scenario where the boardsize sent is too small
        if(_boardSize < playerSize + enemyCount * enemy.displayCharacter().Length)
        {
            _boardSize = playerSize + enemyCount * enemy.displayCharacter().Length;
        }

        _board = Enumerable.Repeat('_', _boardSize).ToArray();
        _enemyPosition = Enumerable.Repeat(0, enemyCount).ToArray();
        _playerPosition = 0;

        SpawnEnemies(enemyCount);
        for(int i = 0; i < enemyCount; i++)
        {
            _enemyList.Add(new Enemy(enemy.getName(), enemy.getAttack(), enemy.getDefense(), enemy.GetLifeBarData().getHealth(), enemy.getEXPValue()));
        }
        SpawnPlayer();
        _encounterFinished = false;
        _isWon = false;
    }

    public Encounter(PlayerData player, Enemy enemy, int boardSize, int enemyCount, int maxEnemyCount)
    {
        _player = player;
        _enemy = enemy;
        _boardSize = boardSize;
        _baseboardSize = boardSize;
        _baseEnemyCount = enemyCount;
        _maxEnemyCount = maxEnemyCount;
        Random rng = new Random();
        _enemyCount = rng.Next(_baseEnemyCount, _maxEnemyCount);
        _enemyList = new List<Enemy>();
        int playerSize = _player.displayCharacter().Length + 1;
        //Account for some strange scenario where the boardsize sent is too small
        if(_boardSize < playerSize + _enemyCount * enemy.displayCharacter().Length)
        {
            _boardSize = playerSize + _enemyCount * enemy.displayCharacter().Length;
        }

        _board = Enumerable.Repeat('_', _boardSize).ToArray();
        _enemyPosition = Enumerable.Repeat(0, _enemyCount).ToArray();
        _playerPosition = 0;

        SpawnEnemies(_enemyCount);
        for(int i = 0; i < _enemyCount; i++)
        {
            _enemyList.Add(new Enemy(enemy.getName(), enemy.getAttack(), enemy.getDefense(), enemy.GetLifeBarData().getHealth(), enemy.getEXPValue()));
        }
        SpawnPlayer();
        _encounterFinished = false;
        _isWon = false;
    }

    private void SpawnPlayer()
    {
        char[] player = _player.displayCharacter();
        for(int i = 0; i < player.Length; i++)
        {
            _board[i] = player[i];
        }
    }
    private void SpawnEnemies(int count)
    {
        //When spawning take only three letters for the name/three spaces for the display.
        //To make sure none overlap, take a random starting position and then add the width of the name plus a random integer from 0-2
        //Enemy position = last placed enemy position + enemy width + rng(0-3)
        Random rng = new Random();
        int spawnPosition = 4;
        char[] name = _enemy.displayCharacter();
        int enemySize = name.Length;
        int extraSpaces = -1;
        int playerSize = _player.displayCharacter().Length + 1;
        while(extraSpaces < 0)
        {
            if(count * enemySize + playerSize < _boardSize-2)
                spawnPosition = rng.Next(playerSize, Convert.ToInt32(_boardSize / count));

            extraSpaces = _boardSize - spawnPosition - enemySize * count;
            // Console.WriteLine("We found " + extraSpaces + " extra spaces for " + count + " enemies!");
        }

        int spawnOrder = 0;
        while(count > 0)
        {
            _enemyPosition[spawnOrder] = spawnPosition;
            spawnOrder++;
            // Console.WriteLine("Spanwing a " + _enemy.getName() + " at " + spawnPosition + " on board of length: " + _board.Length );
            // Console.WriteLine("It has a size of " + name.Length);
            for(int i = 0; i < name.Length; i++)
            {
                _board[spawnPosition] = name[i];
                spawnPosition++;
            }
            count--;
            if(extraSpaces > 2)
            {
                int skippedSpaces = rng.Next(0,Convert.ToInt32(extraSpaces/2));
                spawnPosition += skippedSpaces;
                extraSpaces -= skippedSpaces;
            }
            else if(extraSpaces > 0)
            {
                int skippedSpaces = rng.Next(0,extraSpaces);
                spawnPosition += skippedSpaces;
                extraSpaces -= skippedSpaces;
            }
        }
    }

    public void Update()
    {
        if(_canMove)
        {
            movePlayer();
        }
        collisionCheck();
        displayBoard(touchingEnemy());

        if(touchingEnemy())
        {
            Combat();
        }
        //CollisionCheck will also call in the damage calculation
        

        if(_playerPosition + 2 == _boardSize-1)
        {
            _encounterFinished = true;
            _isWon = true;
        }

        
    }

    private void displayBoard(bool isFighting)
    {
        string printBoard = new string(_board);
        Console.Clear();
        Console.WriteLine(printBoard);
        Console.WriteLine(_player.getName() + ": " + _player.GetLifeBarData().displayLife());
        if(isFighting)
        {
            Console.WriteLine(_enemyList[0].getName() + ": " + _enemyList[0].GetLifeBarData().displayLife());
        }
    }

    private void movePlayer()
    {
        char[] player = _player.displayCharacter();
        _board[_playerPosition + 3] = player[2];
        _board[_playerPosition + 2] = player[1];
        _board[_playerPosition + 1] = player[0];
        _board[_playerPosition] = '_';
        _playerPosition += 1;
    }

    private void collisionCheck()
    {
        if(touchingEnemy())
        {
            _canMove = false;
        }
        else
        {
            _canMove = true;
        }
    }

    private Boolean touchingEnemy()
    {
        foreach(int x in _enemyPosition)
        {
            if(x == _playerPosition + 3)
            {
                return true;
            }
        }
        return false;
    }

    private void Combat()
    {
        //If values don't update, make this one long line
        LifeBarData playerHealth = _player.GetLifeBarData();
        Enemy currentFoe = _enemyList[0];
        LifeBarData enemyHealth = currentFoe.GetLifeBarData();


        playerHealth.changeLife(-1 * DamageCalculator.calculateDamage(currentFoe, _player));
        enemyHealth.changeLife(-1 * DamageCalculator.calculateDamage(_player, currentFoe));

        if(enemyHealth.isAlive() == false)
        {
            clearFromBoard(_enemyPosition[_enemyCount-_enemyList.Count], currentFoe.displayCharacter().Length);

            _enemyPosition[_enemyCount-_enemyList.Count] = 0;
            _enemyList.Remove(currentFoe);
            _player.getLevelSystem().gainExp(_player, currentFoe.getEXPValue());

            _canMove=true;
        }
        if(playerHealth.isAlive() == false)
        { 
            displayBoard(enemyHealth.isAlive());
            _encounterFinished = true;
            _isWon = false;
        }
    }

    private void clearFromBoard(int position, int spaces)
    {
        // Console.WriteLine("Removing enemy at position " + position + ". They are " + spaces + " large");
        for(int i = 0; i < spaces; i++)
        {
            // Console.WriteLine("At the " + i+position + " spot int the array there is a " + _board[position + i]);
            _board[position + i] = '_';
            // Console.WriteLine("Now it is a: " + _board[position + 1]);
        }
    }

    public void resetEncounter()
    {
        _enemyList.Clear();
        int playerSize = _player.displayCharacter().Length + 1;
        if(_maxEnemyCount > _baseEnemyCount)
        {
            Random rng = new Random();
            _enemyCount = rng.Next(_baseEnemyCount, _maxEnemyCount);
        }

        _boardSize = _baseboardSize;
        //Account for some strange scenario where the boardsize sent is too small
        if(_boardSize < playerSize + _enemyCount * _enemy.displayCharacter().Length)
        {
            _boardSize = playerSize + _enemyCount * _enemy.displayCharacter().Length;
        }

        _board = [];
        char[] newBoard = Enumerable.Repeat('_', _boardSize).ToArray();
        _board = newBoard;

        _enemyPosition = [];
        int[] newEnemyPositions = Enumerable.Repeat(0, _enemyCount).ToArray();
        _enemyPosition = newEnemyPositions;

        _playerPosition = 0;

        SpawnEnemies(_enemyCount);
        for(int i = 0; i < _enemyCount; i++)
        {
            _enemyList.Add(new Enemy(_enemy.getName(), _enemy.getAttack(), _enemy.getDefense(), _enemy.GetLifeBarData().getHealth(), _enemy.getEXPValue()));
        }
        SpawnPlayer();
        _encounterFinished = false;
        _isWon = false;
    }
}