using System.Web.Mvc;
using Wasd.Models;
using System.Linq;
using Wasd.Services;
using Microsoft.AspNet.Identity;
using Wasd.Models;
using System.Collections.Generic;

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
            var groupSer = new GroupService();

            List<Group> myGroups = new List<Group>();

            var userId = User.Identity.GetUserId();

            myGroups = groupSer.listMyGroups(userId);

            return View(myGroups);
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
            var allGroupsSer = new GroupService();

            List<Group> allGroups = new List<Group>();

            allGroups = allGroupsSer.listAllGroups();

            return View("ListGroups", allGroups);
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

            string userId = User.Identity.GetUserId();

            ser.createGroup(newGroup, userId);

            return RedirectToAction("Index", "Home");
        }
    }
}