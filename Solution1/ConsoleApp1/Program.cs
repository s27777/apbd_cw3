namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tworzenie i ładowanie kontenerów
            Console.WriteLine("\nTworzenie i ładowanie kontenerów");
            ContainerLiquid cl = new ContainerLiquid(1000, 3310, 33, 1000, true);
            cl.load(502);
            cl.load(400);
            cl.load(400);
            cl.info();
            cl.empty();
            ContainerCooled cc = new ContainerCooled(1920, 1080, 60, 100000, "Cheese", 3);
            ContainerGas cg = new ContainerGas(1, 1, 1, 1000,  1);
            
            
            // Tworzenie i ładowanie statków
            Console.WriteLine("\nTworzenie i ładowanie statków");
            Ship sheep = new Ship(1, 1, 10, 10000);
            sheep.load(cl);
            sheep.load(cc);
            sheep.load(cg);
            ContainerLiquid tooheavy = new ContainerLiquid(1, 1, 200000, 1, true);
            tooheavy.info();
            sheep.load(tooheavy);
            Console.WriteLine("\n");
            sheep.showList();
            sheep.info();
            
            
            // Ładowanie listy kontenerów na statek
            Console.WriteLine("\nŁadowanie listy kontenerów na statek");
            List<Container> containerlist = new List<Container>();
            ContainerCooled fridge = new ContainerCooled(1920, 1080, 60, 100000, "Cheese", 3);
            containerlist.Add(fridge);
            ContainerGas gas = new ContainerGas(100, 100, 100, 1000,  1);
            containerlist.Add(gas);
            ContainerGas gaz = new ContainerGas(102, 103, 100, 1000,  1);
            containerlist.Add(gaz);
            ContainerLiquid liquid = new ContainerLiquid(100, 100, 177, 2000, true);
            containerlist.Add(liquid);
            
            fridge.info();
            sheep.loadFromList(containerlist);
            Console.WriteLine("\n");
            sheep.showList();


            // Usuwanie kontenera ze statku
            Console.WriteLine("\nUsuwanie kontenera ze statku");
            sheep.remove("KON-G-5");

            // Zastępowanie kontenera innym
            Console.WriteLine("\nZastępowanie kontenera innym");
            ContainerLiquid ll = new ContainerLiquid(1, 1, 1, 111, false);
            sheep.replace("KON-L-13", ll);
            sheep.showList();
            
            // Przenoszenie na inny statek
            Console.WriteLine("\nPrzenoszenie na inny statek");
            Ship ship = new Ship(1, 1, 1, 1);
            Ship.moveToAnotherShipp(sheep, ship,"KON-L-1");
            
            Console.WriteLine(".\n.");
            sheep.showList();
            Console.WriteLine(".\n.");
            ship.showList();
            
            // Rozładowanie całego statku
            Console.WriteLine("\nRozładowanie całego statku");
            sheep.removeAll();
        }
    }
}