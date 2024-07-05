using FavouriteAPI.Models;

namespace FavouriteAPI.Services
{
    public interface IFavouriteService
    {
        //Task<int> AddFavourite(FavouriteDto favouriteDto);
        int Addfavourite(FavouriteDto favouritedto);
        bool DeleteFavourite(int favouriteId);
        List<Favourite> GetAllFavourites();
        List<Favourite> GetFavouriteByCategory(string category);
        List<Favourite> GetFavouriteByCompany(string company);
        List<Favourite> GetFavouriteByUser(string userName);
        List<Favourite> GetFavouriteByUserAndCategory(string userName, string category);
        List<Favourite> GetFavouriteByUserAndCompany(string userName, string company);
        //public Task<User> GetUserById(int userId);
    }
}
