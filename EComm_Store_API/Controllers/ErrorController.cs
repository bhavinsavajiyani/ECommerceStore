using EComm_Store_API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace EComm_Store_API.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseAPIController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new APIErrorResponse(code));
        }
    }
}