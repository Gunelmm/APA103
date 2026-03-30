using _07_NullableEnumStruct;

DrinkOrder order1 = new(101, "Ali", DrinkType.Coffee, DrinkSize.Medium);
order1.DisplayOrder();
order1.UpdateStatus(OrderStatus.Preparing);
order1.UpdateStatus(OrderStatus.Ready);
order1.UpdateStatus(OrderStatus.Delivered);

DrinkOrder order2 = new(102, "Leyla", DrinkType.Tea, DrinkSize.Large);
order2.DisplayOrder();
order2.UpdateStatus(OrderStatus.Ready);

DrinkOrder order3 = new(103, "Vüqar", DrinkType.Juice, DrinkSize.Small);
order3.DisplayOrder();

foreach (DrinkType type in Enum.GetValues(typeof(DrinkType)))
{
    Console.WriteLine(type);
}
foreach (DrinkSize size in Enum.GetValues(typeof(DrinkSize)))
{
    Console.WriteLine(size);
}
foreach (OrderStatus status in Enum.GetValues(typeof(OrderStatus)))
{
    Console.WriteLine(status);
}

Console.WriteLine(DrinkType.Coffee.ToString());
Console.WriteLine(DrinkSize.Large.ToString());

decimal totalPrice = order1.Price + order2.Price + order3.Price;
Console.WriteLine("Total order number: 3");
Console.WriteLine($"Order 1 price: {order1.Price}");
Console.WriteLine($"Order 2 price: {order2.Price}");
Console.WriteLine($"Order 3 price: {order3.Price}");
Console.WriteLine($"Total order price: {totalPrice}");