using AltV.Net;
using AltV.Net.Elements.Entities;

namespace DevServer.Entities;

public class MyPlayer : Player
{
    public int PlayerId { get; set; }
    public float Money { get; set; }

    public MyPlayer(ICore core, IntPtr nativePointer, uint id) : base(core, nativePointer, id)
    {
        Money = 5000;
    }
}