namespace _03_ObjectClassConstructorInheritanceThisvsBase;
public class Person
{
    public string FirstName;
    public string LastName;
    public int Age;
    public string Email;
    public string Id;

    public Person(string firstName, string lastName, int age, string email , string id)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Email = email;
        this.Id = id;
    }
    
    public void GetFullName()
    {
        Console.WriteLine($"Name: {this.FirstName} {this.LastName}");
    }
    public void ShowBasicInfo()
    {
        GetFullName();
        Console.WriteLine($"Age: {this.Age}");
        Console.WriteLine($"Email: {this.Email}");
        Console.WriteLine($"Id: {this.Id}");
    }
}