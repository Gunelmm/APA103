class Teacher : Person
{
    public string Department;
    public string MainSubject;
    public decimal BaseSalary;
    public int ExperienceYears;

    public Teacher(string firstName, string lastName, int age, string email, string id,
        string department, string mainSubject, decimal baseSalary, int experienceYears) 
        : base(firstName, lastName, age, email, id)
    {
        this.Department = department;
        this.MainSubject = mainSubject;
        this.BaseSalary = baseSalary;
        this.ExperienceYears = experienceYears;
    }

    public void ShowTeacherInfo()
    {
        ShowBasicInfo();
        Console.WriteLine($"Department: {this.Department}");
        Console.WriteLine($"Main subject {this.MainSubject}");
        Console.WriteLine($"Base salary {this.BaseSalary}");
        Console.WriteLine($"Experience years {this.ExperienceYears}");
    }

    public double CalculateSalary()
    {
        double salary = Convert.ToDouble(BaseSalary + (ExperienceYears * 50));
        return salary;
    }
}