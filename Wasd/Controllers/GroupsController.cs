using System.Web.Mvc;
using Wasd.Models;
using System.Linq;
using Wasd.Services;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System;

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
        public ActionResult AllGroups()
        {
            var groupSer = new GroupService();

            List<Group> allGroups = new List<Group>();

            allGroups = groupSer.listAllGroups();

            return View(allGroups);
        }

        //
        // GET: /Members/
        [Authorize]
        public ActionResult Members()
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

        public ActionResult ThisGroupPosts(GroupPost groupP)
        {
            var groupSer = new GroupService();

            List<GroupPost> groupPosts = new List<GroupPost>();

            groupPosts = groupSer.getGroupPosts(groupP.groupID);

            return View(groupPosts.OrderByDescending(p => p.date).ToList());
        }

        //hópur 8, stofa m116. Hjálp með actionlink

        public ActionResult ThisGroup(int groupId)
        {
            var currUserId = User.Identity.GetUserId();
            var currUserName = User.Identity.GetUserName();

            var groupSer = new GroupService();

            GroupPost groupPost = new GroupPost();

            groupPost.groupID = groupId;
            groupPost.groupName = groupSer.getGroupById(groupId).groupName;
            groupPost.userName = currUserName;
            groupPost.userID = currUserId;

            string format = "ddd MMM d HH:mm yyyy";
            groupPost.date = DateTime.Now.ToString(format);

            if (ModelState.IsValid)
            {
                groupSer.addGroupPost(groupPost);
                return RedirectToAction("ThisGroup");
            }
            
            return View();
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

            return RedirectToAction("MyGroups", "Groups");
        }


    }
}