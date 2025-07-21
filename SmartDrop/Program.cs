namespace SmartDrop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vehicles = new List<DeliveryPilotVehicleDTOView>
{
    new DeliveryPilotVehicleDTOView { DeliveryPilotVehicleID = Guid.NewGuid(), MaxDropCount = 2, MaxWeight = 50, CurrentLat = 30.0, CurrentLng = 31.0 },
    new DeliveryPilotVehicleDTOView { DeliveryPilotVehicleID = Guid.NewGuid(), MaxDropCount = 3, MaxWeight = 100, CurrentLat = 30.5, CurrentLng = 31.5 }
};

            var drops = new List<DropShipping>
{
    new DropShipping { DropShippingID = Guid.NewGuid(), Weight = 20, IsFastWay = true, DropLocationLatitude = 30.1, DropLocationLongitude = 31.1 },
    new DropShipping { DropShippingID = Guid.NewGuid(), Weight = 30, IsFastWay = false, DropLocationLatitude = 30.2, DropLocationLongitude = 31.2 },
    new DropShipping { DropShippingID = Guid.NewGuid(), Weight = 25, IsFastWay = true, DropLocationLatitude = 30.6, DropLocationLongitude = 31.6 },
    new DropShipping { DropShippingID = Guid.NewGuid(), Weight = 40, IsFastWay = false, DropLocationLatitude = 30.7, DropLocationLongitude = 31.7 },
    new DropShipping { DropShippingID = Guid.NewGuid(), Weight = 10, IsFastWay = true, DropLocationLatitude = 30.8, DropLocationLongitude = 31.8 }
};

            var assigned = RouteDropAndVehicle.dropShippings(drops, vehicles);

            foreach (var drop in assigned)
            {
                Console.WriteLine($"Drop ID: {drop.DropShippingID}  Vehicle: {(drop.DeliveryPilotVehicle.HasValue ? drop.DeliveryPilotVehicle.ToString() : "")}");
            }

        }
    }
}

