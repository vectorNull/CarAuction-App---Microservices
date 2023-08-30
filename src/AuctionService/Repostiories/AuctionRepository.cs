using AuctionService.Data;
using AuctionService.DTOs;
using AuctionService.Entities;
using AuctionService.interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Repostiories;

public class AuctionRepository : IAuctionRepository
{
    private readonly AuctionDbContext _context;

    public AuctionRepository(AuctionDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Auction>> GetAllAuctionsAsync()
    {
        var auctions = await _context.Auctions
                .Include(i => i.Item)
                .OrderBy(i => i.Item.Make)
            .ToListAsync();
        
        return auctions;
    }

    public async Task<Auction> GetAuctionByIdAsync(Guid id)
    {
        var auction = await _context.Auctions
                .Include(i => i.Item)
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();
        
        return auction;
    }
   
    public void AddAuctionAsync(Auction auction)
    {
        _context.Auctions.Add(auction);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

}