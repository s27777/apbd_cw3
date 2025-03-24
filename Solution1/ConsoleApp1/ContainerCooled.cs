namespace ConsoleApp1;

public class ContainerCooled : Container
{
    protected int Height { get; set; }
    protected int Depth { get; set; }
    protected int NetWeight { get; set; }
    protected int MaxLoad { get; set; }
    protected int LoadWeight { get; set; }
    protected string SerialNumber { get; set; }
    protected string Product { get; set; }
    protected int Temperature { get; set; }

    public ContainerCooled(int height, int depth, int netwieght, int maxload, string product, int temperature) : base (height, depth, netwieght, maxload)
    {
        Height = height;
        Depth = depth;
        NetWeight = netwieght;
        MaxLoad = maxload;
        LoadWeight = 0;
        Product = product;
        Temperature = temperature;
        SerialNumber = generateSerialNumber();
    }
    
    public string generateSerialNumber()
    {
        string nr = "";
        iterator++;
        nr = "KON-C-" + iterator;
        return nr;
    }

    public void empty()
    {
        base.empty();
    }

    public void load(int l)
    {
        base.load(l);
    }

    public void info()
    {
        base.info();
    }

    public int getTotalWeight()
    {
        return NetWeight + LoadWeight;
    }
}