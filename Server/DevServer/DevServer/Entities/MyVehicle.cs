using AltV.Net;
using AltV.Net.Elements.Entities;

namespace DevServer.Entities;

public class MyVehicle : Vehicle
{
    public MyVehicle(ICore core, IntPtr nativePointer, uint id) : base(core, nativePointer, id)
    {

    }
}