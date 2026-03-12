using System;

class Program
{ 
    static int Addition(int num1, int num2)
    {
        return num1 + num2;
    }

    static int Subtraction(int num1, int num2)
    {
        return num1 - num2;
    }

    static int Multiplication(int num1, int num2)
    {
        return num1 * num2;
    }

    static int Division(int num1, int num2)
    {
        if (num2 == 0)
        {
            Console.WriteLine("There is no division by zero!");
            return 0;
        }
        return num1 / num2;
    }

    static double Remain(int num1, int num2)
    {
        return num1 % num2;
    }

    static int Power(int num1, int num2)
    {
        return (int)Math.Pow(num1, num2);
    }
    static int SumDivisible(int[] numbers)
    {
        int sum = 0;
        foreach (int num in numbers)
        {
            if (num % 4 == 0 && num % 5 == 0)
            {
                sum += num;
            }
        }
        return sum;
    }

    static void FindOddEven(params int[] numbers)
    {
        foreach (int num in numbers)
        {
            if (num % 2 == 0)
            {
                Console.WriteLine($"{num} is even.");
            }
            else
                {
                Console.WriteLine($"{num} is odd.");
                }
        }
    }

    static void FindSymbolCount(string sentence, char symbol)
    {
        int count = 0;
        foreach (char sym in sentence)
        {
            if (sym == symbol)
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }

    static void Main(string[] args)
    {
        

        Console.WriteLine(Addition(77, 7));       
        Console.WriteLine(Subtraction(77, 7));    
        Console.WriteLine(Multiplication(10, 7)); 
        Console.WriteLine(Division(77, 7)); 
        Console.WriteLine(Remain(80, 7));
        Console.WriteLine(Power(2, 3));

        int[] arr = [14, 20, 35, 40, 57, 60, 100];
        Console.WriteLine(SumDivisible(arr));

        FindOddEven(14, 20, 35, 40, 57, 60, 100);
        
        FindSymbolCount("Happiness can be found even in the darkest of times, if one only remembers to turn on the light", 'o');
        
        
        
    }
}