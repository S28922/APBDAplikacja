using System;
using System.Collections.Generic;
using System.Linq;

public interface IHazardNotifier
{
    void NotifyDanger(string containerNumber);
}

public class Container
{
    public string SerialNumber { get; private set; }
    public double LoadCapacity { get; private set; }
    public double Height { get; private set; }
    public double Weight { get; private set; }
    public double Depth { get; private set; }
    public double CurrentLoad { get; private set; }
    public bool IsHazardous { get; private set; }

    public Container(string serialNumber, double loadCapacity, double height, double weight, double depth, bool isHazardous)
    {
        SerialNumber = serialNumber;
        LoadCapacity = loadCapacity;
        Height = height;
        Weight = weight;
        Depth = depth;
        IsHazardous = isHazardous;
    }

    public void Load(double cargoWeight)
    {
        if (cargoWeight > LoadCapacity)
        {
            throw new OverfillException($"Masa ładunku {cargoWeight} ton przekracza maksymalną ładowność kontenera {SerialNumber}.");
        }

        if (IsHazardous && (CurrentLoad + cargoWeight) > (LoadCapacity * 0.5))
        {
            throw new DangerousOperationException($"Próba załadowania niebezpiecznego kontenera {SerialNumber} ponad 50% maksymalnej pojemności.");
        }

        if (!IsHazardous && (CurrentLoad + cargoWeight) > (LoadCapacity * 0.9))
        {
            throw new DangerousOperationException($"Próba załadowania kontenera {SerialNumber} ponad 90% maksymalnej pojemności.");
        }

        CurrentLoad += cargoWeight;
        Console.WriteLine($"Kontener {SerialNumber} został załadowany masą {cargoWeight} ton.");
    }

    public void Unload()
    {
        CurrentLoad = 0;
        Console.WriteLine($"Kontener {SerialNumber} został opróżniony.");
    }
}

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message)
    {
    }
}

public class DangerousOperationException : Exception, IHazardNotifier
{
    public DangerousOperationException(string message) : base(message)
    {
    }

    public void NotifyDanger(string containerNumber)
    {
        Console.WriteLine($"Notyfikacja: Niebezpieczna operacja na kontenerze {containerNumber}.");
    }
}

public class Ship
{
    public List<Container> Containers { get; private set; }
    public int MaxContainers { get; private set; }
    public double MaxWeight { get; private set; }
    public int Speed { get; private set; }

    public Ship(int maxContainers, double maxWeight, int speed)
    {
        Containers = new List<Container>();
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        Speed = speed;
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers)
        {
            throw new InvalidOperationException($"Nie można dodać więcej kontenerów, osiągnięto maksymalną liczbę {MaxContainers}.");
        }

        double currentWeight = Containers.Sum(c => c.CurrentLoad);
        if (currentWeight + container.CurrentLoad > MaxWeight)
        {
            throw new InvalidOperationException($"Masa wszystkich kontenerów na statku przekracza dopuszczalną wagę {MaxWeight} ton.");
        }

        Containers.Add(container);
        Console.WriteLine($"Kontener {container.SerialNumber} załadowany na statek.");
    }

    public void UnloadContainer(Container container)
    {
        Containers.Remove(container);
        Console.WriteLine($"Kontener {container.SerialNumber} został rozładowany ze statku.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Ship ship = new Ship(100, 40, 10);

            Container container1 = new Container("KON-L-1", 10, 200, 1000, 150, true);
            container1.Load(5);
            ship.LoadContainer(container1);

            Container container2 = new Container("KON-G-1", 5, 150, 800, 120, true);
            container2.Load(2);
            ship.LoadContainer(container2);

            Container container3 = new Container("KON-C-1", 12, 180, 1200, 160, false);
            container3.Load(10);
            ship.LoadContainer(container3);

            ship.UnloadContainer(container2);
        }
        catch (OverfillException ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }
        catch (DangerousOperationException ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
            ex.NotifyDanger("KON-G-1");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił nieoczekiwany błąd: {ex.Message}");
        }
    }
}
