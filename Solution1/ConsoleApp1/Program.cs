namespace ConsoleApp1
{
    class Program
    {
        // do naprawy overfillexception
        // limity ilości kontenerów i max wagi na statku
        static void Main(string[] args)
        {
            ContainerLiquid cl = new ContainerLiquid(1, 1, 1, 1000, false);
            ContainerCooled cc = new ContainerCooled(1, 1, 1, 1, "szambo", 1);
            ContainerGas cg = new ContainerGas(1, 1, 1, 1,  1);

            Ship sheep = new Ship(1, 1, 10, 10000);
            
            sheep.load(cl);
            sheep.load(cc);
            sheep.load(cg);
            
            sheep.info();
            Console.WriteLine("=============================");
            sheep.showList();
        }
    }
}