namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*ContainerGas gas = new ContainerGas(1, 1, 200, 1000, 1);
            gas.load(77);
            gas.load(33);
            gas.load(999);
            Console.WriteLine(gas);
            Console.WriteLine(gas.getLoadWeight() + " " + gas.getTotalWeight());*/
            ContainerLiquid josh = new ContainerLiquid(1, 1, 1, 10000, true);
            josh.load(11000);
            Console.WriteLine(josh);
            josh.info();
            
            Console.WriteLine("done");
        }
    }
}