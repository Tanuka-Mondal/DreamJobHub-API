using FavouriteAPI.AOP;
using FavouriteAPI.Logging;
using FavouriteAPI.Models;
using FavouriteAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavouriteAPI.Controllers
{
    [ServiceFilter(typeof(FavouriteLogger))]
    [FavouriteExceptionHandler]
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        readonly IFavouriteService _favouriteService;
        public FavouriteController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        [HttpGet]
        [Route("getAllFavourites")]
        public ActionResult GetAllFavourites()
        {
            List<Favourite> favourites = _favouriteService.GetAllFavourites();
            return Ok(favourites);
        }

        
        [HttpPost]
        [Route("addFavourite")]
        public ActionResult AddFavourite(FavouriteDto favouritedto)
        {
            int favouriteAddResult = _favouriteService.Addfavourite(favouritedto);
            return Created("api/addjob", favouriteAddResult);
        }

        [HttpDelete]
        [Route("removeFromFavourite")]
        public ActionResult DeleteFavourite(int favouriteId)
        {
            bool favouriteDeleteResult = _favouriteService.DeleteFavourite(favouriteId);
            return Ok(favouriteDeleteResult);
        }

        [HttpGet]
        [Route("getAllFavouriteByUser/{userName}")]
        public ActionResult GetFavouriteByUser(string userName)
        {
            List<Favourite> favourites = _favouriteService.GetFavouriteByUser(userName);
            return Ok(favourites);
        }

        [HttpGet]
        [Route("getAllFavouriteByCategory/{category}")]
        public ActionResult GetFavouriteByCategory(string category)
        {
            List<Favourite> favourites = _favouriteService.GetFavouriteByCategory(category);
            return Ok(favourites);
        }

        [HttpGet]
        [Route("getAllFavouriteByCompany{company}")]
        public ActionResult GetFavouriteByCompany(string company)
        {
            List<Favourite> favourites = _favouriteService.GetFavouriteByCompany(company);
            return Ok(favourites);
        }

        [HttpGet]
        [Route("getAllFavouriteByUserAndCategory/{userName}/{category}")]
        public ActionResult GetFavouriteByUserAndCategory(string userName, string category)
        {
            List<Favourite> favourites = _favouriteService.GetFavouriteByUserAndCategory(userName, category);
            return Ok(favourites);
        }

        [HttpGet]
        [Route("getAllFavouriteByUserAndCompany/{userName}/{company}")]
        public ActionResult GetFavouriteByUserAndCompany(string userName, string company)
        {
            List<Favourite> favourites = _favouriteService.GetFavouriteByUserAndCompany(userName, company);
            return Ok(favourites);
        }
    }
}
