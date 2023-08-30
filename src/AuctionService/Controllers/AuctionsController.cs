using AuctionService.DTOs;
using AuctionService.interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuctionService.Controllers;

[ApiController]
[Route("api/auctions")]
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
            return NoContent();
        }

        var auctionDto = _mapper.Map<AuctionDto>(auction);
        return Ok(auctionDto);
    }
}