using AuctionService.DTOs;
using AuctionService.Entities;
using AuctionService.interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Controllers;

[ApiController]
[Route("api/v1/auctions")]
public class AuctionsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAuctionRepository _repository;
    private readonly IPublishEndpoint _publishEndpoint;

    public AuctionsController(IMapper mapper, IAuctionRepository repository, IPublishEndpoint publishEndpoint)
    {
        _mapper = mapper;
        _repository = repository;
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet]
    public async Task<ActionResult<List<AuctionDto>>> GetAllAuctions(string date)
    {
        var query = _repository.GetAllAuctionsAsync(date);

        if (query == null)
        {
            return NoContent();
        }

        return await query.ProjectTo<AuctionDto>(_mapper.ConfigurationProvider).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuctionDto>> GetAuctionById(Guid id)
    {
        var auction = await _repository.GetAuctionByIdAsync(id);

        if (auction == null)
        {
            return NotFound();
        }

        var auctionDto = _mapper.Map<AuctionDto>(auction);
        return Ok(auctionDto);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<AuctionDto>> CreateAuction(CreateAuctionDto createAuctionDto)
    {
        var auction = _mapper.Map<Auction>(createAuctionDto);
        
        auction.Seller = User.Identity.Name;

        _repository.AddAuctionAsync(auction);

        // Publish message
        var newAuctionDto = _mapper.Map<AuctionDto>(auction);
        await _publishEndpoint.Publish(_mapper.Map<AuctionCreated>(newAuctionDto));
        
        var result = await _repository.SaveChangesAsync();


        if (!result)
        {
            return BadRequest("Could not save changes to DB");
        }

        return CreatedAtAction(nameof(GetAuctionById), new {auction.Id}, newAuctionDto);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAuction(Guid id, UpdateAuctionDto updateAuctionDto)
    {
        var auctionToUpdate = await _repository.GetAuctionByIdAsync(id);

        if (auctionToUpdate is null)
        {
            return NotFound();
        }

        if (auctionToUpdate.Seller != User.Identity.Name) return Forbid();

        auctionToUpdate.Item.Make = updateAuctionDto.Make ?? auctionToUpdate.Item.Make;
        auctionToUpdate.Item.Model = updateAuctionDto.Model ?? auctionToUpdate.Item.Model;
        auctionToUpdate.Item.Color = updateAuctionDto.Color ?? auctionToUpdate.Item.Color;
        auctionToUpdate.Item.Mileage = updateAuctionDto.Mileage ?? auctionToUpdate.Item.Mileage;
        auctionToUpdate.Item.Year = updateAuctionDto.Year ?? auctionToUpdate.Item.Year;

        // Publish Mmessage
        await _publishEndpoint.Publish( _mapper.Map<AuctionUpdated>(auctionToUpdate));

        var result = await _repository.SaveChangesAsync();

        if (!result)
        {
            return BadRequest("Problem saving changes.");
        }

        return Ok();
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAuction(Guid id)
    {
        var auctionToDelete = await _repository.GetAuctionByIdAsync(id);

        if (auctionToDelete is null)
        {
            return NotFound();
        }

        if (auctionToDelete.Seller != User.Identity.Name) return Forbid();

        _repository.DeleteAsync(auctionToDelete);

        // Publish message
        await _publishEndpoint.Publish<AuctionDeleted>(new { Id = auctionToDelete.Id.ToString() } );
        
        var result = await _repository.SaveChangesAsync();

        if (!result)
        {
            return BadRequest("Could not update DB.");
        }

        return Ok();
    }
}