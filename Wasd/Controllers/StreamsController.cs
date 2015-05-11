using System.Web.Mvc;

namespace Wasd.Controllers
{
    [Authorize]
    public class StreamsController : Controller
    {
        //
        // GET: /Streams/
        public ActionResult Streams()
        {
            return View();
        }
	}
}