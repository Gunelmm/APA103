namespace _05_AbstractClassPolymorphismForEach;

public class Motorcycle : Vehicle
{
    public int EngineCapacity;
    public bool HasSidecar;
    public int MaxSpeed;
    public string Type;

    public Motorcycle(string brand, string model, int year, int engineCapacity,
        string type, bool hasSidecar, int maxSpeed) : base(brand, model, year)
    {
        this.EngineCapacity = engineCapacity;
        this.HasSidecar = hasSidecar;
        this.MaxSpeed = maxSpeed;
        this.Type = type;
    }
    public Motorcycle(string brand, int year, int engineCapacity,
        string type, bool hasSidecar, int maxSpeed) : base(brand, year)
    {
        this.EngineCapacity = engineCapacity;
        this.HasSidecar = hasSidecar;
        this.MaxSpeed = maxSpeed;
        this.Type = type;
    }
    

    public void ShowMotorcycleInfo()
    {
        ShowBaseInfo();
        Console.WriteLine($"EngineCapacity: {EngineCapacity}, HasSidecar: {HasSidecar}, MaxSpeed: {MaxSpeed}, Type: {Type}" );
        
    }

    public double CalculateFuelCost(double distance)
    {
        return (distance / 100) * 4 * 1.5;
    }
}