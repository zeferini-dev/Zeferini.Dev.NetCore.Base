namespace NetCore.Base
{
    public class BaseException : ArgumentException
    {
        public List<string> ErrorMessages { get; private set; }

        public BaseException(List<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}
