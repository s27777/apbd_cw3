namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // dziedziczenie metody info
            // coś nie tak z overfill exception
            // ihazardnotifier
            
            Console.WriteLine("initial");
            
            ContainerLiquid ll = new ContainerLiquid(1, 1, 1, 1000, false);
            Console.WriteLine(ll);
        }
    }
}