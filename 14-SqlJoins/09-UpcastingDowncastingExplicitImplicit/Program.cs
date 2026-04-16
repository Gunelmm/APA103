using _09_UpcastingDowncastingExplicitImplicit.Exchange;
using _09_UpcastingDowncastingExplicitImplicit.Models;

Dog dog = new Dog {AvgLifeTime = 13, Breed = "Golden", Gender = "male", Name = "Hachi"};
Eagle eagle = new Eagle {AvgLifeTime = 300, FlySpeed = 100, Gender = "female"};

// Animal animal = dog;
// Animal animal = eagle;

// Dog dog1 = (Dog)animal;
// Eagle eagle1 = (Eagle)animal;

Animal[] animals = {dog, eagle};

foreach (var animal in animals)
{
    if (animal is Eagle)
    {
        Eagle eagle1 = animal as Eagle;
        eagle1.Fly();
        eagle.Eat();
    }

    if (animal is Dog)
    {
        Dog dog1 = animal as Dog;
        dog1.Eat();
    }
}

Test test  = new Test();
ITest Itest = test;

Dollar dollar = new Dollar(400);
Console.WriteLine(dollar.USD);

Manat manat = new (3400);
Console.WriteLine(manat.AZN);

Dollar dollar1 = manat;
Console.WriteLine(dollar1.USD);

Manat manat2 = dollar;
Console.WriteLine(manat2.AZN);
