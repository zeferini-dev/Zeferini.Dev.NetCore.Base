namespace NetCore.Base.Model.Response.Errors
{
    public class ErrorsResponse
    {
        public List<ErrorResponse> Errors { get; private set; }

        public ErrorsResponse()
        {
            Errors = new List<ErrorResponse>();
        }

        public ErrorsResponse(List<ErrorResponse> errors)
        {
            Errors = errors;
        }
    }
}
