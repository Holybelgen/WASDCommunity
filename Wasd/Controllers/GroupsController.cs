using System.Web.Mvc;
using Wasd.Models;
using System.Linq;

namespace Wasd.Controllers
{
    [Authorize]
    public class GroupsController : Controller
    {
        //
        // GET: /Groups/
        public ActionResult Groups()
        {
            return View();
        }
        //
        // GET: /MyGroups/
        public ActionResult MyGroups()
        {
            var db = new ApplicationDbContext();
            var AllGroups = db.Groups.ToList();
            return View(AllGroups);
        }
        //
        // GET: /Tournaments/
        public ActionResult Tournaments()
        {
            return View();
        }
        //
        // GET: /ScheduledMatches/
        public ActionResult ScheduledMatches()
        {
            return View();
        }
        //
        // GET: /LookingToPlay/
        public ActionResult LookingToPlay()
        {
            return View();
        }
        //
        // GET: /Members/
        public ActionResult Members()
        {
            return View();
        }
        //
        // GET: /Guides/
        public ActionResult Guides()
        {
            return View();
        }
	}
}