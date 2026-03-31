namespace _09_UpcastingDowncastingExplicitImplicit.Models;

public abstract class Animal
{
    public  int AvgLifeTime { get; set; }
    public string Gender { get; set; }

    public virtual void Eat()
    {
        Console.WriteLine("The animal eats.");
    }

}