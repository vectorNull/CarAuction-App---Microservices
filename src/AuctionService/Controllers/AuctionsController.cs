using AuctionService.DTOs;
using AuctionService.Entities;
using AuctionService.interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuctionService.Controllers;

[ApiController]
[Route("api/v1/auctions")]
public class AuctionsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAuctionRepository _repository;

    public AuctionsController(IMapper mapper, IAuctionRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<AuctionDto>>> GetAllAuctions()
    {
        var auctions = await _repository.GetAllAuctionsAsync();

        if (auctions == null)
        {
            return NoContent();
        }

        var auctionDtos = _mapper.Map<IEnumerable<AuctionDto>>(auctions);
        return Ok(auctionDtos);
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

    [HttpPost]
    public async Task<ActionResult<AuctionDto>> CreateAuction(CreateAuctionDto createAuctionDto)
    {
        var auction = _mapper.Map<Auction>(createAuctionDto);
        // TODO: Add current user as seller
        auction.Seller = "test";

        _repository.AddAuctionAsync(auction);
        var result = await _repository.SaveChangesAsync();

        if (!result)
        {
            return BadRequest("Could not save changes to DB");
        }

        var auctionDto = _mapper.Map<AuctionDto>(auction);

        return CreatedAtAction(nameof(GetAuctionById), new {auction.Id}, auctionDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAuction(Guid id, UpdateAuctionDto updateAuctionDto)
    {
        var auctionToUpdate = await _repository.GetAuctionByIdAsync(id);

        if (auctionToUpdate is null)
        {
            return NotFound();
        }

        // TODO: Check seller == username

        auctionToUpdate.Item.Make = updateAuctionDto.Make ?? auctionToUpdate.Item.Make;
        auctionToUpdate.Item.Model = updateAuctionDto.Model ?? auctionToUpdate.Item.Model;
        auctionToUpdate.Item.Color = updateAuctionDto.Color ?? auctionToUpdate.Item.Color;
        auctionToUpdate.Item.Mileage = updateAuctionDto.Mileage ?? auctionToUpdate.Item.Mileage;
        auctionToUpdate.Item.Year = updateAuctionDto.Year ?? auctionToUpdate.Item.Year;

        var result = await _repository.SaveChangesAsync();

        if (!result)
        {
            return BadRequest("Problem saving changes.");
        }

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAuction(Guid id)
    {
        var auctionToDelete = await _repository.GetAuctionByIdAsync(id);

        if (auctionToDelete is null)
        {
            return NotFound();
        }

        // TODO: Check seller == username

        _repository.DeleteAsync(auctionToDelete);
        var result = await _repository.SaveChangesAsync();

        if (!result)
        {
            return BadRequest("Could not update DB.");
        }

        return Ok();
    }
}