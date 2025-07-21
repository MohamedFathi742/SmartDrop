using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDrop;
public class DropAssignedMessageHandler : IHandleMessages<DropAssignedMessage>
{
    public async Task Handle(DropAssignedMessage message)
    {
        Console.WriteLine($" Received Message: Drop {message.DropShippingId} assigned to Vehicle {message.VehicleId} | Weight: {message.Weight}");
        await Task.CompletedTask;
    }
}
