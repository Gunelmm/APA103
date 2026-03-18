namespace _03_ObjectClassConstructorInheritanceThisvsBase;
    class Administrator : Person
{
    public string Position;
    public string Department;
    public int AccessLevel;

    public Administrator(string firstName, string lastName, int age, string email, string id,
        string position, string department, int accessLevel)
        : base(firstName, lastName, age, email, id)
    {
        this.Position = position;
        this.Department = department;
        this.AccessLevel = accessLevel;
    }

    public void ShowAdminInfo()
    {
        ShowBasicInfo();
        Console.WriteLine($"Position: {this.Position}");
        Console.WriteLine($"Department: {this.Department}");
        Console.WriteLine($"AccessLevel: {this.AccessLevel}");
    }
    public void GrantAccess(string sn)  
    {
        Console.WriteLine($"Access granted to student {sn}");
    }
}