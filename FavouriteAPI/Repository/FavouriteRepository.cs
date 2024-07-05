using FavouriteAPI.Context;
using FavouriteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FavouriteAPI.Repository
{
    public class FavouriteRepository : IFavouriteRepository
    {
        readonly FavouriteDbContext _favouriteDbContext;
        public FavouriteRepository(FavouriteDbContext favouriteDbContext)
        {
            _favouriteDbContext = favouriteDbContext;
        }

        public int AddFavourite(Favourite favourite)
        {
            _favouriteDbContext.Favourites.Add(favourite);
            int changes = _favouriteDbContext.SaveChanges();
            return changes;
        }

        public bool DeleteFavourite(Favourite favouriteDeleteDetails)
        {
            _favouriteDbContext.Favourites.Remove(favouriteDeleteDetails);
            int changes = _favouriteDbContext.SaveChanges();
            return changes > 0;
        }

        
        public List<Favourite> GetAllFavourites()
        {
            return _favouriteDbContext.Favourites.ToList();
        }

        public List<Favourite> GetFavouriteByCategory(string category)
        {
            return _favouriteDbContext.Favourites.Where(f => f.JobCategory == category).ToList();
        }

        public List<Favourite> GetFavouriteByCompany(string company)
        {
            return _favouriteDbContext.Favourites.Where(f => f.Company == company).ToList();
        }

        public Favourite? GetFavouriteById(int favouriteId)
        {
            return _favouriteDbContext.Favourites.Where(f => f.Id == favouriteId).FirstOrDefault();
        }

        public List<Favourite> GetFavouriteByUser(string userName)
        {
            return _favouriteDbContext.Favourites.Where(f => f.UserName == userName).ToList();
        }

        public List<Favourite> GetFavouriteByUserAndCategory(string userName, string category)
        {
            return _favouriteDbContext.Favourites.Where(f => f.UserName == userName && f.JobCategory == category).ToList();
        }

        public List<Favourite> GetFavouriteByUserAndCompany(string userName, string company)
        {
            return _favouriteDbContext.Favourites.Where(f => f.UserName == userName && f.Company == company).ToList();
        }

        public Job? GetJobById(int jobId)
        {
            return _favouriteDbContext.Jobs.Where(j => j.Id == jobId).FirstOrDefault();
        }

        public User? GetUserById(int userId)
        {
            return _favouriteDbContext.Users.Where(u => u.Id == userId).FirstOrDefault();
        }

        


    }
}
