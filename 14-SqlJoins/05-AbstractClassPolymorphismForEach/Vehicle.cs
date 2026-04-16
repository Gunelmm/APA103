namespace _05_AbstractClassPolymorphismForEach;

public class Vehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string PlateNumber { get; set; }
    public double FuelLevel{ get; set; }
    
    public Vehicle(string brand, string model, int year, string plateNumber, double fuelLevel=100)
    {
        this.Brand = brand;
        this.Model = model;
        this.Year = year;
        this.PlateNumber = plateNumber;
        this.FuelLevel = fuelLevel;
    }

    public Vehicle(string brand, string model, int year,  double fuelLevel=100)
    {
        this.Brand = brand;
        this.Model = model;
        this.Year = year;
        this.FuelLevel = fuelLevel;
    }

    public Vehicle(string brand, int year)
    {
        this.Brand = brand;
        this.Year = year;
    }

    public string GetVehicleInfo()
    {
        return $"Brand: {Brand}, Model: {Model}, Year: {Year}, Plate number: {PlateNumber}, Fuel level: {FuelLevel}";
    }

    public void ShowBaseInfo()
    {
        Console.WriteLine(GetVehicleInfo());
        // Console.WriteLine($"Brand: {Brand}");
        // Console.WriteLine($"Model: {Model}");
        // Console.WriteLine($"Year: {Year}");
        // Console.WriteLine($"PlateNumber: {PlateNumber}");
        // Console.WriteLine($"FuelLevel: {FuelLevel}");
    }
}