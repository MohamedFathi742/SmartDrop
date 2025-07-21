using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDrop;
public class DropShipping
{
    public Guid DropShippingID { get; set; }
    public double Weight { get; set; }
    public bool IsFastWay { get; set; } 
    public double DropLocationLatitude { get; set; } 
    public double DropLocationLongitude { get; set; } 
    public double DestinationLocationLatitude { get; set; }
    public double DestinationLocationLongitude { get; set; }

    public Guid? DeliveryPilotVehicle { get; set; }

}
