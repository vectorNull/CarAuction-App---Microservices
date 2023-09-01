using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers;

public class AuctionCreatedConsumer : IConsumer<AuctionCreated>
{
    private readonly IMapper _mapper;

    public AuctionCreatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task Consume(ConsumeContext<AuctionCreated> context)
    {
        Console.WriteLine("---> Consuming AuctionCreated event: " + context.Message.Id);

        var item = _mapper.Map<Item>(context.Message);

        // testing exception handling in RabbitMQ
        if (item.Model == "foo") throw new ArgumentException("Cannot sell cars with name foo");

        await item.SaveAsync();
    }
}