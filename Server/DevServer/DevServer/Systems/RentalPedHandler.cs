using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace DevServer.Systems
{
    public class RentalPedHandler : IScript
    {
        private static IPed rentalPed;

        public RentalPedHandler()
        {
            var pedPosition = new Position(-1018.2066f, -2704.2197f, 13.744385f);
            var pedRotation = new Rotation(0f, 0f, 2.572643f); 
            var pedModel = Alt.Hash("S_F_Y_AirHostess_01"); 

            rentalPed = Alt.CreatePed(pedModel, pedPosition, pedRotation);

            rentalPed.Frozen = true;
            rentalPed.IsStaticEntity = true;
            rentalPed.Health = 9999;
            rentalPed.Armour = 9999;

            rentalPed.SetStreamSyncedMetaData("pedType", "rental");

            Alt.Log("[PedHandler] Rental ped spawned and frozen.");
        }
    }
}