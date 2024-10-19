namespace NetCore.Base
{
    public class RuleValidator
    {
        private readonly List<string> _errorMessages;

        private RuleValidator()
        {
            _errorMessages = new List<string>();
        }

        public static RuleValidator New()
        {
            return new RuleValidator();
        }

        public RuleValidator When(bool hasError, string errorMessage)
        {
            if (hasError)
                _errorMessages.Add(errorMessage);

            return this;
        }

        public void ThrowExceptionIfExists()
        {
            if (_errorMessages.Count != 0)
            {
                throw new BaseException(_errorMessages);
            }
        }
    }
}
