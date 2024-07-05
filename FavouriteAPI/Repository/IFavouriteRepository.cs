using FavouriteAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FavouriteAPI.Repository
{
    public interface IFavouriteRepository
    {
        int AddFavourite(Favourite favourite);
        bool DeleteFavourite(Favourite favouriteDeleteDetails);

        //Task<int> AddFavourite(Favourite favourite);
        List<Favourite> GetAllFavourites();
        List<Favourite> GetFavouriteByCategory(string category);
        List<Favourite> GetFavouriteByCompany(string company);
        Favourite GetFavouriteById(int favouriteId);
        List<Favourite> GetFavouriteByUser(string userName);
        List<Favourite> GetFavouriteByUserAndCategory(string userName, string category);
        List<Favourite> GetFavouriteByUserAndCompany(string userName, string company);
        Job GetJobById(int jobId);
        User GetUserById(int userId);
        //public Task<Job> GetJobById(int jobId);
        //public Task<User> GetUserById(int userId);
    }
}
