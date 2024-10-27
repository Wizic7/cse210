using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {

        List<Scripture> scriptures = new List<Scripture>();
        //load SCriptures from a file
        string filename = "scriptures.txt";
        string[] lines = System.IO.File.ReadAllLines(filename);

    for (int x = 0; x < lines.Length; x++)
    {
        Scripture newScripture = new Scripture(lines[x]);

        scriptures.Add(newScripture);
    }
        Random random= new Random();
        Scripture choice = scriptures[random.Next(0, scriptures.Count)];

        Boolean cont = true;
        while (cont) {
            choice.displayVerse();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Please press enter to continue, type 'new' to load another verse, 'reset' to reset the verse, or 'quit' to finish: ");
            String input = Console.ReadLine();
            if(input.ToLower().Equals("quit")) {
                cont = false;
            }
            else if(input.ToLower().Equals("new")) {
                choice.reset();
                choice = scriptures[random.Next(0, scriptures.Count)];
            }
            else if(input.ToLower().Equals("reset")) {
                choice.reset();
            }
            else {
                choice.hideWords();
            }
        }
    }
}