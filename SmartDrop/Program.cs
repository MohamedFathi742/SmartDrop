namespace SmartDrop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vehicles = new List<DeliveryPilotVehicleDTOView>
            {
                new DeliveryPilotVehicleDTOView
                {
                    DeliveryPilotVehicleID = Guid.NewGuid(),
                    MaxDropCount = 2,
                    MaxWeight = 50,
                    MaxLength = 100, MaxWidth = 80, MaxHeight = 70,
                    CurrentLat = 30.0, CurrentLng = 31.0
                },
                new DeliveryPilotVehicleDTOView
                {
                    DeliveryPilotVehicleID = Guid.NewGuid(),
                    MaxDropCount = 3,
                    MaxWeight = 100,
                    MaxLength = 120, MaxWidth = 100, MaxHeight = 90,
                    CurrentLat = 30.5, CurrentLng = 31.5
                }
            };

            var drops = new List<DropShipping>
            {
                new DropShipping { DropShippingID = Guid.NewGuid(), Weight = 20, IsFastWay = true,  DropLocationLatitude = 30.1, DropLocationLongitude = 31.1, Length = 50,  Width = 50, Height = 40 },
                new DropShipping { DropShippingID = Guid.NewGuid(), Weight = 30, IsFastWay = false, DropLocationLatitude = 30.2, DropLocationLongitude = 31.2, Length = 80,  Width = 70, Height = 60 },
                new DropShipping { DropShippingID = Guid.NewGuid(), Weight = 25, IsFastWay = true,  DropLocationLatitude = 30.6, DropLocationLongitude = 31.6, Length = 120, Width = 90, Height = 100 },
                new DropShipping { DropShippingID = Guid.NewGuid(), Weight = 40, IsFastWay = false, DropLocationLatitude = 30.7, DropLocationLongitude = 31.7, Length = 90,  Width = 60, Height = 70 },
                new DropShipping { DropShippingID = Guid.NewGuid(), Weight = 10, IsFastWay = true,  DropLocationLatitude = 30.8, DropLocationLongitude = 31.8, Length = 60,  Width = 50, Height = 50 }
            };

            Console.WriteLine("Assigning drops to vehicles...\n");

            var unassignedDrops = new List<DropShipping>(drops); 

            foreach (var vehicle in vehicles)
            {
                var assignedDrops = RouteDropAndVehicle.DropShippings(unassignedDrops, vehicle, vehicle.CurrentLat, vehicle.CurrentLng);

               
                foreach (var drop in assignedDrops)
                {
                    drop.DeliveryPilotVehicle = vehicle.DeliveryPilotVehicleID;
                    unassignedDrops.Remove(drop);
                }

                Console.WriteLine($" Vehicle ID: {vehicle.DeliveryPilotVehicleID}");
                if (assignedDrops.Count == 0)
                {
                    Console.WriteLine("   No suitable drops assigned.");
                }
                else
                {
                    foreach (var drop in assignedDrops)
                    {
                        Console.WriteLine($"  Drop ID: {drop.DropShippingID} | Weight: {drop.Weight}kg | Dimensions: {drop.Length}x{drop.Width}x{drop.Height} | FastWay: {drop.IsFastWay}");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine(" Unassigned Drops:");
            if (unassignedDrops.Count == 0)
            {
                Console.WriteLine("  All drops were assigned!");
            }
            else
            {
                foreach (var drop in unassignedDrops)
                {
                    Console.WriteLine($"   Drop ID: {drop.DropShippingID} | Weight: {drop.Weight}kg | Dimensions: {drop.Length}x{drop.Width}x{drop.Height}");
                }
            }

            Console.WriteLine("\nAssignment process completed.");
        }
    }

}
