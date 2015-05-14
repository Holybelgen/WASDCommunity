using System.Web.Mvc;
using Wasd.Models;
using System.Linq;
using Wasd.Services;

namespace Wasd.Controllers
{
    [Authorize]
    public class GroupsController : Controller
    {
        //
        // GET: /Groups/
        [Authorize]
        public ActionResult Groups()
        {
            return View();
        }
        //
        // GET: /MyGroups/
        [Authorize]
        public ActionResult MyGroups()
        {
            var db = new ApplicationDbContext();
            var AllGroups = db.Groups.ToList();
            return View(AllGroups);
        }
        //
        // GET: /Tournaments/
        [Authorize]
        public ActionResult Tournaments()
        {
            return View();
        }
        //
        // GET: /ScheduledMatches/
        [Authorize]
        public ActionResult ScheduledMatches()
        {
            return View();
        }
        //
        // GET: /LookingToPlay/
        [Authorize]
        public ActionResult LookingToPlay()
        {
            return View();
        }
        //
        // GET: /Members/
        [Authorize]
        public ActionResult Members()
        {
            return View();
        }
        //
        // GET: /Guides/
        [Authorize]
        public ActionResult Guides()
        {
            return View();
        }

        [Authorize]
        public ActionResult ListGroups()
        {
            var db = new ApplicationDbContext();
            var AllGroups = db.Groups.ToList();
            return View("ListGroups", AllGroups);
        }

        public ActionResult CreateGroup()
        {
            Group newGroup = new Group();
            return View(newGroup);
        }

        [HttpPost]
        public ActionResult CreateGroup(Group newGroup)
        {
            var ser = new GroupService();

            ser.addGroup(newGroup);

            return RedirectToAction("Index", "Home");
        }
    }
}