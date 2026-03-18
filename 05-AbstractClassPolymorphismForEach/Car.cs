namespace _05_AbstractClassPolymorphismForEach;

public class Car : Vehicle
{
    public int DoorsCount { get; set; }
    public int TrunkCapacity { get; set; }
    public bool IsAutomatic { get; set; }
    public int MaxSpeed { get; set; }

    public Car (string brand, string model, int year, int doorsCount, int trunkCapacity, bool isAutomatic, int maxSpeed) 
        : base (brand, model, year)
    {
        this.DoorsCount = doorsCount;
        this.TrunkCapacity = trunkCapacity;
        this.IsAutomatic = isAutomatic;
        this.MaxSpeed = maxSpeed;
    }

    public void ShowCarInfo()
    {
        ShowBaseInfo();
        Console.WriteLine($"DoorsCount: {DoorsCount},  TrunkCapacity: {TrunkCapacity}, IsAutomatic: {IsAutomatic},  MaxSpeed: {MaxSpeed}");
    }

    public double CalculateFuelCost(double distance)
    {
        return (distance / 100) * 8 * 1.5;
    }
}