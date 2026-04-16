namespace _04_AccessModifiresEncupsulationNamespace.Models;

public class Student : Person
{
    public Student(string firstName, string lastName, string password, string id) : base(firstName, lastName, password, id) 
    {
        // Password private təyin edilib bu səbəbdən biz başqa classda istifadə edə bilmirik.
        // Password = password;
    }
    public void GetId(string id)
    {
        // Protected mirac alan classda əlçatandir.
        Id = id;
    }
    public void GetFirstName(string firstName)
    {
        // public
        Console.WriteLine("First name: " + firstName);
    }
}