using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDrop;
public class DeliveryPilotVehicleDTOView
{
    public Guid DeliveryPilotVehicleID { get; set; }
    public int MaxDropCount { get; set; } = 10;   
    public double MaxWeight { get; set; } = 200.0;

    public double CurrentLat { get; set; } 
    public double CurrentLng { get; set; }
}
