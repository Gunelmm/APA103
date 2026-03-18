namespace _03_ObjectClassConstructorInheritanceThisvsBase;
using System;

class Program
{
    static void Main()
    {
        Student student1 = new Student("Ehmed", "Aliyev", 19, "ehmed@gmail.com", "H001",
            "101", "İT", 88.5, 1);
        Student student2 = new Student("Nigar", "Hesenova", 20, "nigar@gmail.com", "H002",
            "102", "Computer engineer", 92.0, 2);
        Student student3 = new Student("Kenan", "Muradov", 22, "kenan@gmail.com", "H003",
            "103", "İT", 68.5, 1); 
        
        student1.ShowStudentInfo();
        Console.WriteLine($"Scholar salary: {student1.CalculateScholarship()}");
        student2.ShowStudentInfo();
        Console.WriteLine($"Scholar salary: {student2.CalculateScholarship()}");
        student3.ShowStudentInfo();
        Console.WriteLine($"Scholar salary: {student3.CalculateScholarship()}");
        
        Teacher teacher1 = new Teacher("Akif", "Mammadov", 47, "akif@gmail.com", "HH20",
            "İTT", "Proqrammlaşdirma",  2000, 15);
        Teacher teacher2 = new Teacher("Rasim", "Mehdiyev", 35, "rasim@gmail.com", "HH10",
            "İTT", "Excel", 1000, 8);
        
        teacher1.ShowTeacherInfo();
        Console.WriteLine($"Salary: {teacher1.CalculateSalary()}");
        teacher2.ShowTeacherInfo();
        System.Console.WriteLine($"Salary: {teacher2.CalculateSalary()}");
        
        Administrator administrator = new Administrator("Almaz", "Demirova", 63, "almaz@gmail.com", "A001",
            "Dekan", "İTT", 5);
        
        administrator.ShowAdminInfo();
        administrator.GrantAccess(student1.StudentNumber);
        
        double sumScholarSalary = student1.CalculateScholarship() + student2.CalculateScholarship() + student3.CalculateScholarship();
        Console.WriteLine($"Total scholar salary: {sumScholarSalary}");
        
        double sumSalary = teacher1.CalculateSalary() + teacher2.CalculateSalary();
        Console.WriteLine($"Total salary: {sumSalary}");
    }
    
}