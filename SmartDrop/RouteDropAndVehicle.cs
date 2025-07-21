using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDrop;
public static class RouteDropAndVehicle
{
    public static List<DropShipping> dropShippings
        (
        List<DropShipping> drops,
        DeliveryPilotVehicleDTOView vehicle,
        double currentLat,
        double currentLng
        )

    { 
    
    var result=new List<DropShipping>();
        double totalWeight = 0;
        var filter = drops
            .OrderByDescending(d => d.IsFastWay)
            .ThenBy(d => Distance(currentLat, currentLng, d.DropLocationLatitude, d.DropLocationLongitude))
            .ToList();


        foreach (var item in filter)
        {

            if (result.Count>=vehicle.MaxDropCount)
            {
                break;
            }
            if (totalWeight + item.Weight <= vehicle.MaxWeight)
            {
                result.Add(item);         
                totalWeight += item.Weight;
            }
        }
        return result;
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

