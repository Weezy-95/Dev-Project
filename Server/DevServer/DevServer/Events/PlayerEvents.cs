using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace DevServer;

public class PlayerEvents : IScript
{
    [ScriptEvent(ScriptEventType.PlayerConnect)]
    public void PlayerConnect(Player player, string reason)
    {
        player.SetDateTime(DateTime.Now);
        player.Model = (uint)PedModel.FreemodeMale01;
    }
}