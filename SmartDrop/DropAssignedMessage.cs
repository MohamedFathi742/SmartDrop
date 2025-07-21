using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDrop;
public class DropAssignedMessage
{
    public Guid DropShippingId { get; set; }
    public Guid VehicleId { get; set; }
    public double Weight { get; set; }
}
