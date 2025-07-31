using AltV.Net;
using AltV.Net.Elements.Entities;

namespace DevServer.Factories;

public class MyVehicleFactory : IEntityFactory<IVehicle>
{
    public IVehicle Create(ICore core, IntPtr entityPointer, uint id)
    {
        return new Vehicle(core, entityPointer, id);
    }
}