using System.Web.Mvc;

namespace Wasd.Controllers
{
    [Authorize]
    public class ClansController : Controller
    {
        //
        // GET: /Clans/
        public ActionResult Clans()
        {
            return View();
        }
	}
}