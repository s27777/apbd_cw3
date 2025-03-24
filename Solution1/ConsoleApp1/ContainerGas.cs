namespace ConsoleApp1;

public class ContainerGas : Container, IHazardNotifier
{
    protected int Height { get; set; }
    protected int Depth { get; set; }
    protected int NetWeight { get; set; }
    protected int MaxLoad { get; set; }
    protected int LoadWeight { get; set; }
    protected string SerialNumber { get; set; }

    protected float Pressure { get; set; }

    public ContainerGas(int height, int depth, int netwieght, int maxload, float pressure) : base (height, depth, netwieght, maxload)
    {
        Height = height;
        Depth = depth;
        NetWeight = netwieght;
        MaxLoad = maxload;
        LoadWeight = 0;
        Pressure = pressure;
        SerialNumber = generateSerialNumber();
    }
    
    public override string generateSerialNumber()
    {
        string nr = "";
        iterator++;
        nr = "KON-G-" + iterator;
        return nr;
    }
    
    public override void empty()
    {
        this.LoadWeight = (int)(LoadWeight * 0.05);
        Console.WriteLine("Kontener " + SerialNumber + " Został Opróżniony. (5% ładunku pozostało)");
    }

    public override void load(int l, IHazardNotifier ihn)
    {
        try
        {
            if (LoadWeight + l > MaxLoad)
            {
                ihn.notify();
                throw new OverfillException("Maksymalna waga przekroczona. Nie można załadować.");
            }
            else
            {
                LoadWeight += l;
                Console.WriteLine("Załadowano kontener: " + SerialNumber);
                Console.WriteLine("Aktualna masa ładunku: " + LoadWeight);
            }
        }
        catch (OverfillException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public override void info()
    {
        Console.WriteLine();
    }
}