namespace _07_NullableEnumStruct;

public class DrinkOrder
{
    public int OrderNumber { get; set; }
    public string CustomerName { get; set; }
    public DrinkType Drink { get; set; }
    public DrinkSize Size { get; set; }
    public OrderStatus Status { get; set; }
    public decimal Price {get; set; }

    public DrinkOrder(int orderNumber, string customerName, DrinkType drink, DrinkSize size)
    {
        OrderNumber = orderNumber;
        CustomerName = customerName;
        Drink = drink;
        Size = size;
        Status = OrderStatus.New;
        Price = CalculatePrice();
    }

    public decimal CalculatePrice()
    {
        switch (Drink)
        {
            case DrinkType.Coffee:
                 switch (Size)
                 {
                    case DrinkSize.Small:
                         Price = 3;
                         break;
                    case DrinkSize.Medium:
                         Price = 4;
                         break;
                    case DrinkSize.Large:
                         Price = 5;
                         break;
                 }
                 
                 break;
            case DrinkType.Tea:
                switch (Size)
                 {
                    case DrinkSize.Small:
                         Price = 2;
                         break;
                    case DrinkSize.Medium:
                         Price = 3;
                         break;
                    case DrinkSize.Large:
                         Price = 4;
                         break;
                 }
                
                 break;
            case DrinkType.Juice:
                switch (Size)
                 {
                    case DrinkSize.Small:
                         Price = 4;
                         break;
                    case DrinkSize.Medium:
                         Price = 5;
                         break;
                    case DrinkSize.Large:
                         Price = 6;
                         break;
                 }

                 break;
            case DrinkType.Water:
                switch (Size)
                 {
                    case DrinkSize.Small:
                         Price = 1;
                         break;
                    case DrinkSize.Medium:
                         Price = 1.5m;
                         break;
                    case DrinkSize.Large:
                         Price = 2;
                         break;
                 }

                 break;
        }
        return Price;
    }
    public void UpdateStatus(OrderStatus newStatus)
    {
        Status = newStatus;
        Console.WriteLine($"Sifariş #{OrderNumber} statusu: {newStatus}");
    }
    public void DisplayOrder()
    {
        Console.WriteLine($"Order number: {OrderNumber}");
        Console.WriteLine($"Customer: {CustomerName}");
        Console.WriteLine($"Drink: {Drink}");
        Console.WriteLine($"Size: {Size}");
        Console.WriteLine($"Status: {Status}");
        Console.WriteLine($"Price: {Price} AZN");
    }
}