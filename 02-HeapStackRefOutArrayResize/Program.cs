int[] numbers = { 1, 4, 9, 16, 25 };
int[] additionalNum = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
int[] newArray = ArrayResize(numbers, additionalNum);
Console.WriteLine(string.Join(" ",  newArray));

static int[] ArrayResize(int[] numbers, params int[] additionalNum)
{
    int newLength = numbers.Length + additionalNum.Length;
    int[] newArray = new int[newLength];

    for (int i = 0; i < numbers.Length; i++)
    {
        newArray[i] = numbers[i];
    }
    for (int i=0; i<additionalNum.Length; i++)
    {
        newArray[numbers.Length+i] = additionalNum[i];
    }
    return newArray;
}