namespace JobAPI.Exceptions
{
    public class DuplicateJobException : ApplicationException
    {
        public DuplicateJobException()
        {
            
        }
        public DuplicateJobException(string message) : base(message) { }

    }
}
