namespace _05_AbstractClassPolymorphismForEach;

public class Truck : Vehicle
{
    public double CargoCapacity { get; set; }
    public int AxleCount { get; set; }
    public double CurrentLoad { get; set; }
    public int MaxSpeed { get; set; }
    
    public Truck(string brand, string model, int year,
        double cargoCapacity, int axleCount, double currentLoad, int maxSpeed)
        : base(brand, model, year)
    {
        CargoCapacity = cargoCapacity;
        AxleCount = axleCount;
        CurrentLoad = currentLoad;
        MaxSpeed = maxSpeed;
    }

    public void ShowTruckInfo()
    {
        ShowBaseInfo();
        Console.WriteLine($"CargoCapacity: {CargoCapacity}, AxleCount: {AxleCount}, CurrentLoad: {CurrentLoad}, MaxSpeed: {MaxSpeed}");
    }

    public void LoadCargo(double weight)
    {
        if (CurrentLoad + weight <= CargoCapacity)
            {
            CurrentLoad += weight;
            }
        else
        {
            Console.WriteLine("Cargo capacity exceeded");
            
        }
        
    }
    public double CalculateFuelCost(double distance)
    {
        double result = (distance / 100) * (25 + CurrentLoad * 2) * 1.8;
        return result;
        
    }
}
