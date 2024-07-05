namespace FavouriteAPI.Exceptions
{
    public class FavouriteNotFoundException : ApplicationException
    {
        public FavouriteNotFoundException()
        {

        }
        public FavouriteNotFoundException(string message) : base(message) { }

    }
}
