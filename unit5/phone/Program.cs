public interface IPhoneNumber
{
    string GetPhoneNumber();
}

public interface IAddress
{
    string GetAddress();
}

class Person : IPhoneNumber, IAddress
{
    private string _name;
    private string _phoneNumber;
    private string _address;

    public Person(string name, string phoneNumber, string address)
    {
        _name = name;
        _phoneNumber = phoneNumber;
        _address = address;
    }

    public string GetPhoneNumber()
    {
        return _phoneNumber;
    }

    public string GetAddress()
    {
        return _address;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IPhoneNumber p1 = new Person("Isaac Cope", "867-867-5309", "Sesame Street 105");
        Console.WriteLine(p1.GetPhoneNumber());
        Console.WriteLine(p1.GetAddress());

        List<IPhoneNumber> phoneNumbers = new List<IPhoneNumber>();
        phoneNumbers.Add(p1);


    }
}