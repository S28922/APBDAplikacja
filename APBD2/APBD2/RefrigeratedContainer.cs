using System;
using System.Collections.Generic;

namespace Containers;

public class RefrigeratedContainer : Container
{
    public RefrigeratedContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload, string productType, double temperature)
        : base(cargoMass, height, tareWeight, depth, maxPayload)
    {
        SerialNumber = GenerateSerialNumber("C");
        ProductType = productType;
        Temperature = temperature;
    }

    public string ProductType { get; set; }
    public double Temperature { get; set; }

    public override void EmptyCargo()
    {
        CargoMass=0;
    }

    public override void LoadCargo(double mass)
    {
        if (GetRequiredTemperature(ProductType) >= Temperature)
        {
            if (mass < MaxPayload)
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
            Console.WriteLine("Unfortunately the temperature not allows us to fill this container. Ship: " + SerialNumber);
        }
    }
    
    private static double GetRequiredTemperature(string productType)
    {
        IDictionary<string, double> products = new Dictionary<string, double>()
        {
            {"bananas", 13.3},
            {"chocolate", 18},
            {"fish", 2},
            {"meat", -15},
            {"ice cream", -18},
            {"frozen pizza", -30},
            {"cheese", 7.2},
            {"sausages", 5},
            {"butter", 20.5},
            {"eggs", 19},
            
        };
        
        return products[productType.ToLower()]; // Change this to the actual logic
    }

    public override string ToString()
    {
        return $"{base.ToString()}, product type: {ProductType}, temperature: {Temperature}.";
    }
}