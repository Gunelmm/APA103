namespace _09_UpcastingDowncastingExplicitImplicit.Models;

public class Eagle : Animal
{
    public int FlySpeed {get; set; }

    public override void Eat()
    {
        Console.WriteLine("Eagle eats meat.");
    }

    public void Fly()
    {
        Console.WriteLine("Flew away");
    }
}