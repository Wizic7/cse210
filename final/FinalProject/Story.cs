using System.Runtime.ExceptionServices;
using System.Transactions;
using System.IO;

class Story
{
    private List<Encounter> _encounters;
    private List<String> _encounterNames;
    private List<String> _unlockedEncounters;
    private PlayerData _player;
    public Story(PlayerData player)
    {
        _player = player;
        LoadTextFile(player);
    }
    
            //Builds the encounters and story from a prebuilt txt/json file
    private void LoadTextFile(PlayerData player)
    {
        _encounters = new List<Encounter>();
        _encounterNames = new List<String>();
        _unlockedEncounters = new List<String>();

        string[] lines = System.IO.File.ReadAllLines("story.csv");
        Boolean isNotHeadings = false;
        foreach (string line in lines)
        {
            if(isNotHeadings)
            {
                string[] encounterData = line.Split(",");
                for(int i = 0; i < encounterData.Length; i++)
                {
                    encounterData[i] = encounterData[i].Trim();
                }

                string encounterName = encounterData[0]; 
                int boardSize = Int32.Parse(encounterData[1]); 
                int enemyCount = Int32.Parse(encounterData[2]); 
                int maxEnemyCount = Int32.Parse(encounterData[3]); 
                string enemyName = encounterData[4]; 
                int enemyAttack = Int32.Parse(encounterData[5]); 
                int enemyDefense = Int32.Parse(encounterData[6]); 
                int enemyLife = Int32.Parse(encounterData[7]); 
                int enemyExp = Int32.Parse(encounterData[8]); 

                Enemy enemy = new Enemy(enemyName, enemyAttack, enemyDefense, enemyLife, enemyExp);
                Encounter encounter = new Encounter(player, enemy, boardSize, enemyCount, maxEnemyCount);
                _encounters.Add(encounter);
                _encounterNames.Add(encounterName);
            }
            isNotHeadings = true;
        }
        
        _unlockedEncounters.Add(_encounterNames[0]);

    }

    public void runEncounter(int number)
    {
        Encounter currentEncounter = _encounters[number];
        while(currentEncounter._encounterFinished == false)
        {
            currentEncounter.Update();
            Thread.Sleep(250);
        }
        if(currentEncounter._isWon){
            Console.WriteLine("You WON!!!");
            if(number < _encounterNames.Count() - 1)
            {
                if(number + 2 > _unlockedEncounters.Count)
                {
                    _unlockedEncounters.Add(_encounterNames[number+1]);
                }
            }
            else
            {
                Console.WriteLine("You have saved the town from the evil necromancer!");
            }
        }
        else 
        {
            Console.WriteLine("YOU DIED!!!");
        }
        currentEncounter.resetEncounter();
        _player.resetHealth();
    }

    public string[] getEncounterNames()
    {
        return _unlockedEncounters.ToArray();
    }
}