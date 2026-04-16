using _06_InterfaceAbstraction;

Calculation calculate = new ();

Console.WriteLine("Enter the first number: ");
double firstNum = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Enter the second number: ");
double secondNum = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Enter the operation: ");
char operation = Convert.ToChar(Console.ReadLine());

Console.WriteLine(calculate.Calculate(firstNum, secondNum, operation));
