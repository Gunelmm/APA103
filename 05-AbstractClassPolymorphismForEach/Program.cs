using _05_AbstractClassPolymorphismForEach;

namespace _05_AbstractClassPolmorphismForEach
{
    class Program
        {
            static void Main()
            {
                Car car1 = new Car("Mercedes", "E200",  2023, 4, 500, true, 220);
                Car car2 = new Car("BMW","320i", 2022, 4, 480, true, 235);
                Car car3 = new Car("Toyota","Camry", 2021, 4, 524, true, 210);
                
                car1.ShowCarInfo();
                Console.WriteLine(car1.CalculateFuelCost(500.0));
                car2.ShowCarInfo();
                Console.WriteLine(car2.CalculateFuelCost(500.0));
                car3.ShowCarInfo();
                Console.WriteLine(car3.CalculateFuelCost(500.0));
                
                Motorcycle motorcycle1 = new Motorcycle("Yamaha","R1", 2023,  998, "Sport", false, 299);
                Motorcycle motorcycle2 = new Motorcycle("Harley-Davidson", 2022, 1868, "Cruiser", true, 180);
                
                motorcycle1.ShowMotorcycleInfo();
                Console.WriteLine(motorcycle1.CalculateFuelCost(300.0));
                motorcycle2.ShowMotorcycleInfo();
                Console.WriteLine(motorcycle2.CalculateFuelCost(300.0));
                
                Truck trunk1 = new Truck("MAN"," TGX", 2020, 18, 3, 12, 120);
                Truck trunk2 = new Truck("Volvo","FH16", 2021,  25, 4, 18, 110);
                
                trunk1.ShowTruckInfo();
                Console.WriteLine(trunk1.CalculateFuelCost(800.0));
                trunk1.LoadCargo(5.0);
                Console.WriteLine(trunk1.CalculateFuelCost(800.0));
                trunk2.ShowTruckInfo();
                Console.WriteLine(trunk2.CalculateFuelCost(800.0));
                
            }
        }
}

