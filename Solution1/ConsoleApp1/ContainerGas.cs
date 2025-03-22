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
    //public int iterator { get; set; }

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
    
    public void empty() // todo zostawia 5 procent
    {
        this.LoadWeight = (int)(LoadWeight * 0.05);
    }

    public virtual void load(int l, IHazardNotifier ihn)
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

    /*Exception OverfillException()
    {
        return new Exception();
    }*/

    public void info()
    {
        base.info();
    }

    public int getTotalWeight()
    {
        return NetWeight + LoadWeight;
    }
}