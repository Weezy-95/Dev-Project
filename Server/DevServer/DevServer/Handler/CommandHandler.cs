using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using DevServer.Entities;

namespace DevServer.Handler;

public class CommandHandler : IScript
{
    [Command("pos")]
    public void GetPositionCommand(IPlayer player)
    {
        var pos = player.Position;
        var rot = player.Rotation;

        player.SendChatMessage($"Position: X: {pos.X:F3}, Y: {pos.Y:F3}, Z: {pos.Z:F3}");
        player.SendChatMessage($"Rotation: Roll: {rot.Roll:F3}, Pitch: {rot.Pitch:F3}, Yaw: {rot.Yaw:F3}");

        Alt.Log($"[POS] {player.Name} → X: {pos.X}, Y: {pos.Y}, Z: {pos.Z} | Rot: {rot.Roll}, {rot.Pitch}, {rot.Yaw}");
    }

    [Command("veh")]
    public void CreateVehicleCommand(MyPlayer player, string vehicleName)
    {
        var position = player.Position + new Position(0, 2, 0);

        try
        {
            IVehicle vehicle = Alt.CreateVehicle(vehicleName.ToLower(), position, player.Rotation);
            vehicle.NumberplateText = "King Boco";
            vehicle.EngineOn = true;

            player.SetIntoVehicle(vehicle, 0); 

            player.SendChatMessage($"Fahrzeug '{vehicleName}' gespawnt!");
            Alt.Log($"[SPAWN] {player.Name} hat ein Fahrzeug gespawnt: {vehicleName}");
        }
        catch
        {
            player.SendChatMessage("Falscher Modellname!");
        }
    }
    
    [Command("revive")]
    public void ReviveCommand(IPlayer player)
    {
        player.Spawn(player.Position);
        player.Health = 200;
    }
}