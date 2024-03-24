using System;
using System.Collections.Generic;
using System.Linq;

namespace Containers;

public class ContainerShip
{
    public ContainerShip(int maxSpeed, int maxContainerNumber, double maxWeight)
    {
        Id = ++_id;
        MaxSpeed = maxSpeed;
        MaxContainerNumber = maxContainerNumber;
        MaxWeight = maxWeight;
    }

    private static int _id = 0;
    public int Id { get; set; }

    public List<Container> Containers { get; set; } = new List<Container>();
    public int MaxSpeed { get; }
    public int MaxContainerNumber { get; }
    public double MaxWeight { get; }
    private double _weight;

    private double Weight
    {
        get { return _weight;}
        set { _weight = value; }
    }

    public void AddContainer(Container container)
    {
        if (!container.Loaded)
        {
            if (MaxContainerNumber > Containers.Count + 1)
            {
                if (_weight + ((container.CargoMass + container.TareWeight) / 1000) < MaxWeight)
                {
                    _weight += (container.CargoMass + container.TareWeight) / 1000;
                    container.Loaded = true;
                    Containers.Add(container);
                    Console.WriteLine("The container number: " + container.SerialNumber +
                                      " has been loaded on the ship " +
                                      Id + ".");
                }
                else
                {
                    Console.WriteLine("Sorry, maximum weight has been reached.");
                }
            }
            else
            {
                Console.WriteLine("Sorry, we can't set more containers here.");
            }
        }
        else
        {
            Console.WriteLine("Sorry, this container is already loaded on another ship.");
        }
    }

    public void AddContainer(List<Container> containers)
    {
        foreach (Container container in containers)
        {
            AddContainer(container);
        }
    }

    // Other methods - for loading cargo, removing container, etc.
    public void RemoveContainer(string id)
    {
        Container? toRemove = Containers.SingleOrDefault(r => r.SerialNumber == id);
        if (toRemove != null)
        {
            _weight -= (toRemove.TareWeight + toRemove.CargoMass) / 1000;
            Containers[Containers.IndexOf(toRemove)].Loaded = false;
            Containers.Remove(toRemove);
            Console.WriteLine("The container with number: " + id + "has been removed");
        }
        else
        {
            Console.WriteLine("Sorry, there is no container with this id on this ship.");
        }
    }

    public void ReplaceContainer(string ogId, Container container)
    {
        Container? containerCheck = Containers.SingleOrDefault(r => r.SerialNumber == ogId);
        if (containerCheck != null)
        {
            RemoveContainer(ogId);
            AddContainer(container);
        }
        else
        {
            Console.WriteLine("Sorry, there was no such a container on the ship, so i didn't add new one");
        }
    }

    public void TransferContainer(string id, ContainerShip toTransfer)
    {
        Container? container = Containers.SingleOrDefault(r => r.SerialNumber == id);
        if (container != null)
        {
            RemoveContainer(id);
            toTransfer.AddContainer(container);
        }
        else
        {
            Console.WriteLine("Sorry, there is no container like this on ship " + Id + ".");
        }
    }
    
    

    public void PrintInfo()
    {
        Console.WriteLine($"Ship: {Id}, max speed: {MaxSpeed}, max container number: {MaxContainerNumber}, max weight: {MaxWeight}\n");
        foreach (Container con in Containers)
        {
            Console.WriteLine("[" + con.ToString() + "]");
        }
        
    }
}