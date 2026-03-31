namespace _09_UpcastingDowncastingExplicitImplicit.Models;

public class Test :  ITest
{
    public int number { get; set; }
    public void DoSomething()
    {
        throw new NotImplementedException();
    }
}