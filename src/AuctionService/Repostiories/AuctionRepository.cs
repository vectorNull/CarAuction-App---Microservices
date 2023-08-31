using AuctionService.Data;
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


    public IQueryable<Auction> GetAllAuctionsAsync(string date)
    {
        var query = _context.Auctions.OrderBy(i => i.Item.Make).AsQueryable();

        if (!string.IsNullOrEmpty(date))
        {
            query = query.Where(x => x.UpdatedAt.CompareTo(DateTime.Parse(date).ToUniversalTime()) > 0);
        }
        
        return query;
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

    public void DeleteAsync(Auction auction)
    {
        _context.Auctions.Remove(auction);
    }

}