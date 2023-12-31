using Contracts;
using MassTransit;

namespace AuctionService.Consumers;

public class AuctionCreatedFaultsConsumer : IConsumer<Fault<AuctionCreated>>
{
    public async Task Consume(ConsumeContext<Fault<AuctionCreated>> context)
    {
        Console.WriteLine("--> Consuming fautly creation");

        var exception = context.Message.Exceptions.First();

        if (exception.ExceptionType == "System.ArgumentException")
        {
            context.Message.Message.Model = "Foobar";
            await context.Publish(context.Message.Message);
        }
        else
        {
            Console.WriteLine("Not an Argument exception - update error dashboard somewhere");
        }
    }
}