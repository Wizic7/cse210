using System.Globalization;
using System.Numerics;

abstract class Activity{
protected int _time;
protected String _description;
protected String _name;

public Activity(String name, String description)
{
    _description = description;
    _name = name;
    DisplayStartup();
}

public abstract void RunActivity();

public void DisplayStartup()
{
    Console.Clear();
    Console.WriteLine("Welcome to the " + _name +"\n");
    Console.WriteLine(_description +"\n");
    Console.Write("How long, in seconds, would you like for your session? ");
    _time = int.Parse(Console.ReadLine());
}
public void DisplayCountdown(int seconds)
{
    DateTime startTime = DateTime.Now;
    DateTime endTime = startTime.AddSeconds(seconds);
    DateTime currentTime = DateTime.Now;

    int x = seconds;
    while(currentTime < endTime){
        Console.Write(x);
        Thread.Sleep(1000);

        //Removes the spaces in case of multiple digits
        int digits_temp = x;
        while(digits_temp/10 >= 1){
            Console.Write("\b" + " \b");
            digits_temp = digits_temp / 10;
        }

        Console.Write("\b" + " \b");
        currentTime = DateTime.Now;
        x--;
    }
    
}
public void DisplaySpinner(int seconds)
{
    List<String> animation = GetAnimation();
    DateTime startTime = DateTime.Now;
    DateTime endTime = startTime.AddSeconds(seconds);
    DateTime currentTime = DateTime.Now;

    while(currentTime < endTime){
        foreach(String frame in animation){
            Console.Write(frame);
            Thread.Sleep(100);
            Console.Write("\b \b");
        }
        currentTime = DateTime.Now;
    }


}

private List<String> GetAnimation()
{
    List<String> animation = new List<String>();

    animation.Add("|");
    animation.Add("/");
    animation.Add("—");
    animation.Add("\\");

    return animation;
}

}