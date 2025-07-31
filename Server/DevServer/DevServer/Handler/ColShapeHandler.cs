using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;

namespace DevServer.Handler;

public class ColShapreHandler : IScript
{
    public ColShapeHandler()
    {
        var colShape = Alt.CreateColShapeSphere(new Position(-1018.2066f, -2704.2197f, 13.744385f), 3.0f);

        colShape.ColShapeType = ColShapeType.Circle;

        colShape.OnColShapeEnter += (shape, entity) =>
        {
            if (entity is IPlayer player)
            {
                player.SendChatMessage("~g~Du hast den Bereich betreten.");
                Alt.Log($"[COLSHAPE] {player.Name} hat den Bereich betreten.");
            }
        };

        colShape.OnColShapeExit += (shape, entity) =>
        {
            if (entity is IPlayer player)
            {
                player.SendChatMessage("~y~Du hast den Bereich verlassen.");
                Alt.Log($"[COLSHAPE] {player.Name} hat den Bereich verlassen.");
            }
        };
    }
}