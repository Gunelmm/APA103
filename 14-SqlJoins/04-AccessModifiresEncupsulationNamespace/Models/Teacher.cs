namespace _04_AccessModifiresEncupsulationNamespace.Models;

public class Teacher
{
    public void Test()
    {
        Person person = new Person("Lalə", "Aliyeva", "la9865", "8877");
        
        // Biz FirstName-i public təyin etdiyimiz üçün FirstName əlçatandir.
        // Bu kod sətri public üçün same assembly, non-derived nümunəsidir.
        Console.WriteLine(person.FirstName);
        person.GetInfo();
        person.GetFullName();
        // Password private təyin edilib bu səbəbdən biz başqa classda istifadə edə bilmirik.
        // person.Password;

        // Miras alinmadığı üçün protected əlçatan deyil.
       // Console.WriteLine(person.Id); 
    }
    
}