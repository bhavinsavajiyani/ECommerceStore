namespace EComm_Store_API.Errors
{
    public class APIValidationErrorResponse : APIErrorResponse
    {
        public APIValidationErrorResponse() : base(400)
        {
            
        }

        public IEnumerable<string> Errors { get; set; }
    }
}