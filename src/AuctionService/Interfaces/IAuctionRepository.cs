using AuctionService.Entities;

namespace AuctionService.interfaces;

public interface IAuctionRepository
{
    public Task<IEnumerable<Auction>> GetAllAuctionsAsync();
    public Task<Auction> GetAuctionByIdAsync(Guid id);
    public void AddAuctionAsync(Auction auction);
    public Task<bool> SaveChangesAsync();
}