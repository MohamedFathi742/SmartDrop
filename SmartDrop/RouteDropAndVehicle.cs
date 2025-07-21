using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDrop;
public static class RouteDropAndVehicle
{
    public static List<DropShipping> dropShippings(
        List<DropShipping> drops,
        List<DeliveryPilotVehicleDTOView> vehicles)
    {
      
        var sortedDrops = drops
            .OrderByDescending(d => d.IsFastWay)
            .ToList();

        foreach (var vehicle in vehicles)
        {
            double totalWeight = 0;
            int assignedCount = 0;

          
            var availableDrops = sortedDrops
                .Where(d => d.DeliveryPilotVehicle == null)
                .OrderBy(d => Distance(vehicle.CurrentLat, vehicle.CurrentLng, d.DropLocationLatitude, d.DropLocationLongitude))
                .ToList();

            foreach (var drop in availableDrops)
            {
                if (assignedCount >= vehicle.MaxDropCount)
                    break;

                if (totalWeight + drop.Weight <= vehicle.MaxWeight)
                {
                    drop.DeliveryPilotVehicle = vehicle.DeliveryPilotVehicleID;
                    totalWeight += drop.Weight;
                    assignedCount++;
                }
            }
        }

        return drops;
    }

    private static double Distance(double lat1, double lon1, double lat2, double lon2)
    {
        double R = 6371;
        double dLat = DegreesToRadians(lat2 - lat1);
        double dLon = DegreesToRadians(lon2 - lon1);
        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        return R * c;
    }

    private static double DegreesToRadians(double deg) => deg * (Math.PI / 180);
}