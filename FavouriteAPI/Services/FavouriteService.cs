using FavouriteAPI.Exceptions;
using FavouriteAPI.Models;
using FavouriteAPI.Repository;

namespace FavouriteAPI.Services
{
    public class FavouriteService : IFavouriteService
    {
        readonly IFavouriteRepository _favouriteRepository;
        public FavouriteService(IFavouriteRepository favouriteRepository)
        {
            _favouriteRepository = favouriteRepository;
        }

        public int Addfavourite(FavouriteDto favouritedto)
        {
            User user = _favouriteRepository.GetUserById(favouritedto.UserId);
            Job job = _favouriteRepository.GetJobById(favouritedto.JobId);
            Favourite favourite = new Favourite()
            {
                UserId = favouritedto.UserId,
                UserName = user.Name,
                JobId = favouritedto.JobId,
                JobTitle = job.JobTitle,
                JobCategory = job.Category,
                Company = job.CompanyName

            };
            int favouriteAddStatus =  _favouriteRepository.AddFavourite(favourite);
            return favouriteAddStatus;
        }

        public bool DeleteFavourite(int favouriteId)
        {
            Favourite favouriteDeleteDetails = _favouriteRepository.GetFavouriteById(favouriteId);
            if (favouriteDeleteDetails != null)
            {
                bool deleteResult = _favouriteRepository.DeleteFavourite(favouriteDeleteDetails);
                return deleteResult;
            }
            else
            {
                throw new FavouriteNotFoundException("Favourite doesn't exist");
            }
        }

        public List<Favourite> GetAllFavourites()
        {
            return _favouriteRepository.GetAllFavourites();
        }

        public List<Favourite> GetFavouriteByCategory(string category)
        {
            return _favouriteRepository.GetFavouriteByCategory(category);
        }

        public List<Favourite> GetFavouriteByCompany(string company)
        {
            return _favouriteRepository.GetFavouriteByCompany(company);
        }

        public List<Favourite> GetFavouriteByUser(string userName)
        {
            return _favouriteRepository.GetFavouriteByUser(userName);
        }

        public List<Favourite> GetFavouriteByUserAndCategory(string userName, string category)
        {
            return _favouriteRepository.GetFavouriteByUserAndCategory(userName, category);
        }

        public List<Favourite> GetFavouriteByUserAndCompany(string userName, string company)
        {
            return _favouriteRepository.GetFavouriteByUserAndCompany(userName, company);
        }
    }
}
