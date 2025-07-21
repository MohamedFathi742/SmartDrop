namespace SmartDrop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vehicle = new DeliveryPilotVehicleDTOView
            {
                DeliveryPilotVehicleID = Guid.NewGuid(),
                MaxDropCount = 3,
                MaxWeight = 100.0
            };

            var drops = new List<DropShipping>
        {
            new DropShipping { DropShippingID = Guid.NewGuid(), Weight = 30, IsFastWay = true, DropLocationLatitude = 30.0, DropLocationLongitude = 31.0 },
            new DropShipping { DropShippingID = Guid.NewGuid(), Weight = 50, IsFastWay = false, DropLocationLatitude = 30.2, DropLocationLongitude = 31.2 },
            new DropShipping { DropShippingID = Guid.NewGuid(), Weight = 40, IsFastWay = true, DropLocationLatitude = 30.4, DropLocationLongitude = 31.4 },
            new DropShipping { DropShippingID = Guid.NewGuid(), Weight = 90, IsFastWay = false, DropLocationLatitude = 30.5, DropLocationLongitude = 31.5 }
        };

            var route = RouteDropAndVehicle.dropShippings(drops, vehicle, 30.0, 31.0);

            Console.WriteLine("DROPS");
            foreach (var drop in route)
            {
                Console.WriteLine($" DROP ID {drop.DropShippingID}, Weight: {drop.Weight}, IsFastWay: {drop.IsFastWay}");
            }
        }
    }
}

