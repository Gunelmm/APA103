using System;

class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student("Ehmed", "Aliyev", 19, "ehmed@gmail.com", "H001",
            "101", "İT", 88.5, 1);
        Student student2 = new Student("Nigar", "Hesenova", 20, "nigar@gmail.com", "H002",
            "102", "Computer engineer", 92.0, 2);
        Student student3 = new Student("Kenan", "Muradov", 22, "kenan@gmail.com", "H003",
            "103", "İT", 68.5, 1); 
        
        student1.ShowStudentInfo();
        student1.CalculateScholarship();
        student2.ShowStudentInfo();
        student2.CalculateScholarship();
        student3.ShowStudentInfo();
        student3.CalculateScholarship();
        
        Teacher teacher1 = new Teacher("Akif", "Mammadov", 47, "akif@gmail.com", "HH20",
            "İTT", "Proqrammlaşdirma",  2000, 15);
        Teacher teacher2 = new Teacher("Rasim", "Mehdiyev", 35, "rasim@gmail.com", "HH10",
            "İTT", "Excel", 1000, 8);
        
        teacher1.ShowTeacherInfo();
        teacher1.CalculateSalary();
        teacher2.ShowTeacherInfo();
        teacher2.CalculateSalary();
        
        Administrator administrator = new Administrator("Almaz", "Demirova", 63, "almaz@gmail.com", "A001",
            "Dekan", "İTT", 5);
        
        administrator.ShowAdminInfo();
        administrator.GrantAccess();
        
        double sumScholarSalary = student1.CalculateScholarship() + student2.CalculateScholarship() + student3.CalculateScholarship();
        Console.WriteLine(sumScholarSalary);
        
        double sumSalary = teacher1.CalculateSalary() + teacher2.CalculateSalary();
        Console.WriteLine(sumSalary);
    }
    
}