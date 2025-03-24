using Microsoft.VisualBasic;

namespace ConsoleApp1;

public class Ship
{
    public List<Container> Containers = new List<Container>();

    protected int vMax { get; set; }
    protected int MaxLoad { get; set; }
    protected string SerialNumber { get; set; }
    protected int CurrentLoad { get; set; }
    protected int MaxContainersCount { get; set; }
    protected int MaxContainersWeight { get; set; }
    private static int iterator = 0;

    public Ship(int vmax, int maxload, int maxcontainerscount, int maxcontainersweight)
    {
        vMax = vmax;
        MaxLoad = maxload;
        SerialNumber = this.generateSerialNumber();
        CurrentLoad = 0;
        MaxContainersCount = maxcontainerscount;
        MaxContainersWeight = maxcontainersweight;
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

    public void removeAll()
    {
        Containers.Clear();
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

    public int getTotalContainersWeight()
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
        Console.WriteLine("Lista kontenerów dla " + SerialNumber + ":");
        foreach (Container c in Containers)
        {
            Console.WriteLine(c);
        }
    }
    
    public virtual void info()
    {
        Console.WriteLine("Dane kontenera " + SerialNumber + ":");
        Console.WriteLine("Prędkość maksymalna: " + vMax);
        Console.WriteLine("Załadowane kontenery: " + Containers.Count + "/" + MaxContainersCount);
        Console.WriteLine("Łączna waga kontenerów: " + getTotalContainersWeight() + "/" + MaxContainersWeight);
        
    }

    public override string ToString()
    {
        return SerialNumber;
    }
    
    
}
