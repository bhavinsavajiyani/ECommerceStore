
namespace EComm_Store_API.Errors
{
    public class APIErrorResponse
    {
        public APIErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            ErrorMessage = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string ErrorMessage { get; set;}

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "You have made a Bad Request!",
                401 => "You are NOT Authorized!",
                404 => "Resource not Found!",
                500 => "Errors are a path to the dark side. Errors lead to Anger. Anger leads to hate. Hate leads to Career Change!",
                _ => null
            };
        }
    }
}