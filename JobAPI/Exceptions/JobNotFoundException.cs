namespace JobAPI.Exceptions
{
    public class JobNotFoundException : ApplicationException
    {
        public JobNotFoundException()
        {
            
        }
        public JobNotFoundException(string message) : base(message) { }
    }
}
