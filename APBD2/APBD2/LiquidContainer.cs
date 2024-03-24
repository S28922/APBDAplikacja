using System;

namespace Containers;

public class LiquidContainer : Container, IHazardNotifier
{

    private bool _hazard;
    
    public bool Hazard
    {
        get { return _hazard;}
        set { _hazard = value; }
    }
    public LiquidContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload, bool hazard)
        : base(cargoMass, height, tareWeight, depth, maxPayload)
    {
        SerialNumber = GenerateSerialNumber("L");
        _hazard = hazard;
    }

    public override void LoadCargo(double mass)
    {
        try
        {
            if (_hazard)
            {
                NotifyHazard();
                if (mass < MaxPayload * 0.5)
                {
                    CargoMass = mass;
                }
                else
                {
                    throw new OverfillException("Cargo mass exceeds maximum payload.");
                }
            }
            else
            {
                if (mass < MaxPayload * 0.9)
                {
                    CargoMass = mass;
                }
                else
                {
                    throw new OverfillException("Cargo mass exceeds maximum payload.");
                }
            }
        }
        catch (OverfillException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public override void EmptyCargo()
    {
        CargoMass = 0;
    }

    public void NotifyHazard()
    {
        Console.WriteLine("The hazard liquid is filling container " + SerialNumber + ", please be careful.");
    }

    public override string ToString()
    {
        return $"{base.ToString()}, hazardness: {_hazard}.";
    }
}