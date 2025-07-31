using AltV.Net;
using AltV.Net.Elements.Entities;
using DevServer.Factories;

namespace DevServer;

internal class Main : Resource
{
    public override void OnStart()
    {
        Console.WriteLine("Started");
    }

    public override void OnStop()
    {
        Console.WriteLine("Stopped");
    }
    
    public override IEntityFactory<IPlayer> GetPlayerFactory()
    {
        return new MyPlayerFactory();
    }

    public override IEntityFactory<IVehicle> GetVehicleFactory()
    {
        return new MyVehicleFactory();
    }
}
