namespace ConsoleApp1;

public class OverfillException : Exception
{
    public OverfillException()
    {
    }

    public OverfillException(string message) : base(message)
    {
        Console.WriteLine("Maksymalna waga przekroczona. Nie można załadować.");
    }

    public OverfillException(string message, Exception inner) : base(message, inner)
    {
        
    }
}