using Microsoft.VisualBasic;

namespace ConsoleApp1;

public class Ship
{
    public List<Container> Containers = new List<Container>();

    protected int vMax { get; set; }
    protected int MaxLoad { get; set; }
    protected string SerialNumber { get; set; }
    protected int CurrentLoad { get; set; }
    protected int TotalContainersWeight { get; set; }
    private static int iterator = 0;

    public Ship(int vmax, int maxload, string serialnumber, int currentload, int totalcontainersweight)
    {
        vMax = vmax;
        MaxLoad = maxload;
        SerialNumber = serialnumber;
        CurrentLoad = currentload;
        TotalContainersWeight = totalcontainersweight;
    }

    public string generateSerialNumber()
    {
        iterator++;
        return "SHIP-" + iterator;
    }

    public void load(Container c)
    {
        Containers.Add(c);
        
    }

    public void loadFromList(List<Container> cl)
    {
        foreach (Container c in cl)
        {
            Containers.Add(c);
        }
    }

    public void replace(string a, Container b)
    {
        foreach (Container c in Containers)
        {
            if (c.ToString() == a)
            {
                Containers.Remove(c);
                Containers.Add(b);
            }
        }
    }

    public void remove(string id)
    {
        foreach (Container c in Containers)
        {
            if (c.ToString() == id)
            {
                Containers.Remove(c);
            }
        }
    }

    public static void moveToAnotherShip(Ship a, Ship b, string containerid)
    {
        foreach (Container c in a.Containers)
        {
            if (c.ToString() == containerid)
            {
                a.Containers.Remove(c);
                b.Containers.Add(c);
            }
        }
    }

    public int getNumberOfContainersLoaded()
    {
        int result = 0;
        foreach (Container c in Containers)
        {
            result += c.getTotalWeight();
        }
        return result;
    }

    public void showList()
    {
        foreach (Container c in Containers)
        {
            Console.WriteLine();
        }
    }
    
    public virtual void info()
    {
        Console.WriteLine("Dane kontenera " + SerialNumber + ":");
        Console.WriteLine("Załadowane kontenery: " + Containers.Count);
        //Console.WriteLine("Masa ładunku: " + LoadWeight);
        //Console.WriteLine("Masa brutto: " + this.getTotalWeight());
    }

    public override string ToString()
    {
        return SerialNumber;
    }
    
    
}
