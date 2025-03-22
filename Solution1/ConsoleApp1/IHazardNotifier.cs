namespace ConsoleApp1;

public interface IHazardNotifier
{
    public void notify()
    {
        Console.WriteLine("Niebezpieczna sytuacja");
    }
}