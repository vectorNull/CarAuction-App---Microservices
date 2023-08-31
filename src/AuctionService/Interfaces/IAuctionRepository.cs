using AuctionService.Entities;

namespace AuctionService.interfaces;

public interface IAuctionRepository
{
    public IQueryable<Auction> GetAllAuctionsAsync(string date);
    public Task<Auction> GetAuctionByIdAsync(Guid id);
    public void AddAuctionAsync(Auction auction);
    public Task<bool> SaveChangesAsync();
    public void DeleteAsync(Auction auction);
}