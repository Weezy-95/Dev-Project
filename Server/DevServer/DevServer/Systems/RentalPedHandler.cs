using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Data;

namespace DevServer.Handler
{
    public class PedHandler : IScript
    {
        private static IPed rentalPed;

        public PedHandler()
        {
            var pedPosition = new Position(-1018.2066f, -2704.2197f, 13.744385f);
            var pedRotation = new Rotation(0f, 0f, 180f); 
            var pedModel = Alt.Hash("mp_m_shopkeep_01"); 

            rentalPed = Alt.CreatePed(pedModel, pedPosition, pedRotation);

            rentalPed.Frozen = true;
            rentalPed.Health = 9999;
            rentalPed.Armour = 9999;

            rentalPed.SetStreamSyncedMetaData("pedType", "rental");

            Alt.Log("[PedHandler] Rental ped spawned and frozen.");
        }
    }
}