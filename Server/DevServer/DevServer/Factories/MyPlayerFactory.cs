using AltV.Net;
using AltV.Net.Elements.Entities;
using DevServer.Entities;

namespace DevServer.Factories;

public class MyPlayerFactory : IEntityFactory<IPlayer>
{
    public IPlayer Create(ICore core, IntPtr playerPointer, uint id)
    {
        return new MyPlayer(core, playerPointer, id);
    }
}