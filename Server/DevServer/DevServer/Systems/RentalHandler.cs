using System;
using System.Collections.Generic;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using DevServer.Entities;

namespace DevServer.Systems
{
    public class RentalHandler : IScript
    {
        private static IPed rentalPed;

        private static readonly Position PedPosition = new(-1018.2066f, -2704.2197f, 13.744385f);
        private const float InteractRange = 3.0f;
        private const int RentPrice = 1000;
        private const int DespawnSeconds = 7200;
        
        private static readonly Dictionary<uint, IVehicle> ActiveRentalByPlayerId = new();

        public RentalHandler()
        {
            var pedRotation = new Rotation(0f, 0f, 2.572643f);
            var pedModel = Alt.Hash("S_F_Y_AirHostess_01");

            rentalPed = Alt.CreatePed(pedModel, PedPosition, pedRotation);
            rentalPed.Frozen = true;
            rentalPed.IsStaticEntity = true;
            rentalPed.Health = 9999;
            rentalPed.Armour = 9999;
            rentalPed.SetStreamSyncedMetaData("pedType", "rental");
            
            
            Alt.OnClient<MyPlayer>("tryRentVehicle", (player) =>
            {
                if (!player.Exists) return;

                if (player.Position.Distance(PedPosition) > InteractRange) return;

                if (ActiveRentalByPlayerId.TryGetValue(player.Id, out var existing) && existing.Exists)
                {
                    player.SendChatMessage("Du hast bereits ein Mietfahrzeug.");
                    return;
                }

                if (player.Money < RentPrice)
                {
                    player.SendChatMessage($"Du brauchst ${RentPrice:N0}.");
                    return;
                }
                
                player.Money -= RentPrice;
                player.SetStreamSyncedMetaData("money", player.Money);
                player.Emit("money:update", player.Money);
                
                var model = Alt.Hash("faggio");
                var spawnPos = player.Position + new Position(2, 0, 0);
                var spawnRot = new Rotation(0, 0, player.Rotation.Yaw);
                var vehicle = Alt.CreateVehicle(model, spawnPos, spawnRot);
                if (vehicle == null)
                {
                    player.SendChatMessage("Fehler beim Spawnen des Fahrzeugs.");
                    return;
                }

                ActiveRentalByPlayerId[player.Id] = vehicle;

                player.SendChatMessage($"Dein Mietfahrzeug wurde gespawnt! ({DespawnSeconds}s)");
                vehicle.EngineOn = true;
                vehicle.LockState = VehicleLockState.Unlocked;
                player.SetIntoVehicle(vehicle, 1);
                
                player.Emit("rental:started", vehicle.Id, DespawnSeconds);
            });
            
            Alt.OnClient<MyPlayer, uint>("rental:expire", (player, vehId) =>
            {
                if (!player.Exists) return;

                if (!ActiveRentalByPlayerId.TryGetValue(player.Id, out var veh) || !veh.Exists)
                    return;

                if (veh.Id != vehId)
                    return;
                
                ActiveRentalByPlayerId.Remove(player.Id);

                try
                {
                    veh.Destroy(); 
                    Alt.Log($"[Rental] Vehicle {veh.Id} zerstört (Player {player.Id}).");
                }
                catch (Exception ex)
                {
                    Alt.LogError($"[Rental] Destroy() failed for Vehicle {vehId}: {ex}");
                }

                if (player.Exists)
                    player.SendChatMessage("Dein Mietfahrzeug ist abgelaufen und wurde entfernt.");
            });
        }
    }
}
