using Microsoft.VisualBasic;

namespace ConsoleApp1;

public class Ship
{
    public List<Container> Containers = new List<Container>();

    protected int vMax { get; set; }
    protected string SerialNumber { get; set; }
    //protected int CurrentLoad { get; set; }
    protected int MaxContainersCount { get; set; }
    protected int MaxContainersWeight { get; set; }
    private static int iterator = 0;

    public Ship(int vmax, int maxload, int maxcontainerscount, int maxcontainersweight)
    {
        vMax = vmax;
        SerialNumber = generateSerialNumber();
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
        try
        {
            if (getTotalContainersWeight() + c.getTotalWeight() > MaxContainersWeight || Containers.Count + 1 > MaxContainersWeight)
            {
                throw new OverfillException();
            }
            else
            {
                Containers.Add(c);
                Console.WriteLine("Kontener " + c + " został załatowany na statek " + SerialNumber);
            }
        }
        catch (OverfillException e)
        {
            //e.Message();
            Console.WriteLine("OverfillException (ship)");
        }
    }

    public void loadFromList(List<Container> cl)
    {
        foreach (Container c in cl)
        {
            load(c);
        }
    }

    /*public void replace(string a, Container b)
    {
        foreach (Container c in Containers)
        {
            if (c.ToString() == a)
            {
                remove(a);
                Containers.Add(b);
            }
        }
    }*/
    
    public void replace(string id, Container c)
    {
        for (int i = Containers.Count - 1; i >= 0; i--)
        {
            if (Containers[i].ToString() == id)
            {
                Containers.RemoveAt(i);
                Containers.Add(c);
                Console.WriteLine("Kontener " + id + " na statku " + SerialNumber + " został zastąpiony kontenerem " + c);
            }
        }
    }

    public void remove(string id)
    {
        for (int i = Containers.Count - 1; i >= 0; i--)
        {
            if (Containers[i].ToString() == id)
            {
                Containers.RemoveAt(i);
                Console.WriteLine("Kontener " + id + " został usunięty ze statku " + SerialNumber);
            }
        }
    }

    public void removeAll()
    {
        Containers.Clear();
        Console.WriteLine("Statek " + SerialNumber + " został rozładowany");
    }
    
    /*public static void moveToAnotherShip(Ship a, Ship b, string containerid)
    {
        foreach (Container c in a.Containers)
        {
            if (c.ToString() == containerid)
            {
                a.remove(containerid);
                b.Containers.Add(c);
                Console.WriteLine("Kontener " + containerid + " przeniesiony z " + a + " do " + b);
            }
        }
    }*/
    
    public static void moveToAnotherShipp(Ship a, Ship b, string id)
    {
        for (int i = a.Containers.Count - 1; i >= 0; i--)
        {
            if (a.Containers[i].ToString() == id)
            {
                a.Containers.RemoveAt(i);
                Container c = a.Containers[i];
                b.Containers.Add(c);
                Console.WriteLine("Kontener " + id + " przeniesiony z " + a + " do " + b);
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
