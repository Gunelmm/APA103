namespace _06_InterfaceAbstraction;

public class Calculation : ICalculation
{
    public double Calculate(double firstNum, double secondNum, char operation)
    {
        switch (operation)
        {
            case '+':
                return firstNum + secondNum;
            case '-':
                return firstNum - secondNum;
            case '*':
                return firstNum * secondNum;
            case '/':
                if (secondNum == 0)
                {
                    Console.WriteLine("You can't divide by 0!");
                    return 0;
                }
                return firstNum / secondNum;
            default:
                Console.WriteLine("Invalid opertation!");
                return 0;
        }
    }
}