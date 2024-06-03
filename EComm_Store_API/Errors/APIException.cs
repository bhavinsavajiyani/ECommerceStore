namespace EComm_Store_API.Errors
{
    public class APIException : APIErrorResponse
    {
        public APIException(int statusCode, string message = null, string details = null) : base(statusCode, message)
        {
            Details = details;
        }

        public string Details {get; set;}
    }
}