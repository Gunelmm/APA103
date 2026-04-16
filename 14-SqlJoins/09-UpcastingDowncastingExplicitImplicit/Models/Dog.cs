namespace _09_UpcastingDowncastingExplicitImplicit.Models;

public class Dog : Animal
{
    public string Breed { get; set; }
    public string Name {get; set; }

    public override void Eat()
    {
        Console.WriteLine($"{Name} eats dog food.");
    }
}