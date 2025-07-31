using AltV.Net;
using AltV.Net.Enums;
using DevServer.Entities;

namespace DevServer.Events;

public class PlayerEvents : IScript
{
    [ScriptEvent(ScriptEventType.PlayerConnect)]
    public void PlayerConnect(MyPlayer player, string reason)
    {
        player.SetDateTime(DateTime.Now);
        player.Model = (uint)PedModel.FreemodeMale01;
        player.Spawn(new AltV.Net.Data.Position((float)-1032.8967, (float) -2729.855, (float)13.744385), 0);
    }
}