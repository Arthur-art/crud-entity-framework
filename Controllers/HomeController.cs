using Microsoft.AspNetCore.Mvc;

namespace CrudEntityFramework.Controllers
{
    public class HomeController : ControllerBase
    {
        [HttpGet("Running")]
        public string Index()
        {
            return "Api running!";
        }

        [HttpGet("GetHours")]
       public ActionResult getHours()
        {
            var obj = new
            {
                Data = DateTime.Now.ToLongDateString(),
                Hour = DateTime.Now.ToShortTimeString()
            };

            return Ok(obj);
        }
    }
}
