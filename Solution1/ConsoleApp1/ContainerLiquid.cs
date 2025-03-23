namespace ConsoleApp1;

public class ContainerLiquid : Container, IHazardNotifier
{
    protected int Height { get; set; }
    protected int Depth { get; set; }
    protected int NetWeight { get; set; }
    protected int MaxLoad { get; set; }
    protected int LoadWeight { get; set; }
    
    protected string SerialNumber { get; set; }
    protected bool Hazardous { get; set; }

    public ContainerLiquid(int height, int depth, int netwieght, int maxload, bool hazardous) : base (height, depth, netwieght, maxload)
    {
        Height = height;
        Depth = depth;
        NetWeight = netwieght;
        MaxLoad = maxload;
        LoadWeight = 0;
        SerialNumber = generateSerialNumber();
    }
    
    public override string generateSerialNumber()
    {
        string nr = "";
        iterator++;
        nr = "KON-L-" + iterator;
        return nr;
    }

    public void empty()
    {
        base.empty();
    }

    public void load(int l, IHazardNotifier ihn)
    {
        if (Hazardous && LoadWeight > MaxLoad*0.5 || !Hazardous && LoadWeight > MaxLoad*0.9)
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
    
    Exception OverfillException()
    {
        String lkjh = "aberty";
        return new Exception();
    }
    
    public void info()
    {
        base.info();
    }
}