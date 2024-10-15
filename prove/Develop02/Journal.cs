using System.Threading.Channels;
using System.IO; 

public class Journal{
    public List<Entry> _entries = new List<Entry>();
    public Journal() { }

    public void ViewJournal() {
        foreach (Entry entry in _entries) 
        {
            Console.WriteLine(entry._date + "\n" + entry._prompt + "\n" + entry._response);
        }
    }

    public void StoreResponse()
    {
        Entry newLog = new Entry();
        Console.WriteLine(newLog._prompt);
        newLog._response = Console.ReadLine();

        DateTime theCurrentTime = DateTime.Now;
        newLog._date = theCurrentTime.ToShortDateString();
        _entries.Add(newLog);
    }

    public void SaveJournal(){
        Console.WriteLine("What is the name of your file?");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries){
                outputFile.WriteLine(entry._date);
                outputFile.WriteLine(entry._prompt);
                outputFile.WriteLine(entry._response);
            }
        }
    }

    public void LoadJournal(){
        Console.WriteLine("What is the name of your file?");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);

    for (int x = 0; x < lines.Length; x = x + 3)
    {
        Entry newEntry = new Entry();
        newEntry._date = lines[x];
        newEntry._prompt = lines[x+1];
        newEntry._response = lines[x+2];

        this._entries.Add(newEntry);
    }
    }
}