using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;

namespace DevServer.Handler
{
    public class ColShapeHandler : IScript
    {
        private static IColShape rentalZone;

        public ColShapeHandler()
        {
            rentalZone = Alt.CreateColShapeSphere(
                new Position(-1018.2066f, -2704.2197f, 13.744385f),
                1f
            );

            Alt.Log("[ColShape] Rental zone initialized.");
        }

        [ScriptEvent(ScriptEventType.ColShape)]
        public static void OnColShapeEvent(IColShape shape, IEntity entity, bool state)
        {
            if (shape != rentalZone) return;
            if (entity is not IPlayer player) return;

            if (state)
            {
                player.SendChatMessage("~g~You have entered the rental zone.");
                Alt.Log($"[ColShape] {player.Name} entered the rental zone.");
            }
            else
            {
                player.SendChatMessage("~y~You have left the rental zone.");
                Alt.Log($"[ColShape] {player.Name} left the rental zone.");
            }
        }
    }
}