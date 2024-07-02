using EComm_Store_API.Errors;
using EComm_Store_Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EComm_Store_API.Controllers
{
    public class BuggyController : BaseAPIController
    {
        private readonly StoreContext _storeContext;
        public BuggyController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        [HttpGet("testauth")]
        [Authorize]
        public ActionResult<string> GetSecretText()
        {
            return "Authorized Personnel Only!";
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var obj = _storeContext.Products.Find(48);

            if(obj == null)
            {
                return NotFound(new APIErrorResponse(404));
            }

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var obj = _storeContext.Products.Find(48);
            var objToReturn = obj.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new APIErrorResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}