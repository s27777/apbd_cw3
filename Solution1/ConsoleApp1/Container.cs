namespace ConsoleApp1;

public abstract class Container
{
    protected int Height { get; set; }
    protected int Depth { get; set; }
    protected int NetWeight { get; set; }
    protected int MaxLoad { get; set; }
    protected int LoadWeight { get; set; }
    
    protected string SerialNumber { get; set; }
    public static int iterator = 0;

    public Container(int height, int depth, int netwieght, int maxload)
    {
        Height = height;
        Depth = depth;
        NetWeight = netwieght;
        MaxLoad = maxload;
        LoadWeight = 0;
        SerialNumber = generateSerialNumber();
    }

    public virtual string generateSerialNumber()
    {
        iterator++;
        return "virtual";
    }

    public virtual void empty()
    {
        Console.WriteLine("base method triggered");
        NetWeight = 0;
        Console.WriteLine("Kontener " + SerialNumber + " Został Opróżniony.");
    }
    
    public virtual void load(int l)
    {
        Console.WriteLine("base command triggered");
        try
        {
            if (LoadWeight + l > MaxLoad)
                    {
                        //Console.WriteLine("Przeładowanie. Nie można załadować.");
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
    
    public virtual void load(int l, IHazardNotifier ihn)
    {
        Console.WriteLine("base command triggered");
        try
        {
            if (LoadWeight + l > MaxLoad)
            {
                //Console.WriteLine("Przeładowanie. Nie można załadować.");
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
    
    Exception OverfillException()
    {
        String lkjh = "aberty";
        return new Exception();
    }

    public virtual void info()
    {
        Console.WriteLine("Dane kontenera " + SerialNumber + ":");
        Console.WriteLine("Masa ładunku: " + LoadWeight);
        Console.WriteLine("Masa brutto: " + this.getTotalWeight());
    }

    public virtual int getLoadWeight()
    {
        return LoadWeight;
    }

    public virtual int getTotalWeight()
    {
        return NetWeight + LoadWeight;
    }

    public override string ToString()
    {
        return this.SerialNumber;
    }

}