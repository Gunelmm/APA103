namespace _04_AccessModifiresEncupsulationNamespace.Models;

public class Person
{
    public string FirstName;
    public string LastName;
    private string Password;
    protected string Id;
    
    public Person(string firstName, string lastName, string password, string id)
    {
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Id = id;
    }

    public void GetFullName()
    {
        Console.WriteLine($"{FirstName} {LastName}");
    }
    
    public void GetInfo()
    {
        Console.WriteLine($"Firstname: {FirstName}");
        Console.WriteLine($"Lastname: {LastName}");
    }
    public void GetPassword()
    {
        // Password private olduğu üçün eyni classda əlçatandir.
        Console.WriteLine($"Password: {Password}");
    }
}