namespace Containers;

public abstract class Container
{
    private static int _curId = 0;
    protected Container(double cargoMass, double height, double tareWeight, double depth, double maxPayload)
    {
        CargoMass = cargoMass;
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        MaxPayload = maxPayload;
    }

    public string SerialNumber { get; protected set; }
    public double CargoMass { get; protected set; }
    public double Height { get; }
    public double TareWeight { get; }
    public double Depth { get; }
    public double MaxPayload { get; }
    public bool Loaded { get; set; }

    public abstract void LoadCargo(double mass);
    public abstract void EmptyCargo();
    public static string GenerateSerialNumber(string type) {
        //implementation of generation of unique number for each container [ids have to be unique]
        type = type.ToUpper();
        _curId++;
        return $"KON-{type}-{_curId}";
    }

    public override string ToString()
    {
        return $"Serial number: {SerialNumber}, height: {Height}, depth: {Depth}\n tare weight: {TareWeight}, max payload: {MaxPayload}, cargo mass: {CargoMass}, Loaded: {Loaded}\n";
    }
}