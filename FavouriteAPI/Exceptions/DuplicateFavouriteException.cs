namespace FavouriteAPI.Exceptions
{
    public class DuplicateFavouriteException : ApplicationException
    {
        public DuplicateFavouriteException()
        {

        }
        public DuplicateFavouriteException(string message) : base(message) { }

    }
}
