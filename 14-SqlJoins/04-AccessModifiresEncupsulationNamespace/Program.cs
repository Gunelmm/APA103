using _04_AccessModifiresEncupsulationNamespace.Models;

public class Program
{
    public static void Main()
    {
        Student student = new Student("Osman", "Demirov", "od6787", "9988");
        
        // Biz FirstName-i public təyin etdiyimiz üçün FirstName əlçatandir.
        // Bu kod sətri public üçün  same assemly, derived class nümunəsidir.
        Console.WriteLine(student.FirstName);
        student.GetFullName();
        student.GetInfo();
        
        // protected
        // Console.WriteLine(student.Id);
        
        // Password-i private təyin etdiyimiz üçün əlçatan deyil.
        // Console.WriteLine(student.Password);
        
        Teacher teacher = new Teacher();
        
        // Console.WriteLine(teacher.FirstName);
        // teacher.GetFullName();
        // teacher.GetInfo();
        // Console.WriteLine(teacher.Password);




    }
}