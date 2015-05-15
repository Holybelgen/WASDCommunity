using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wasd.Models;
using Wasd.Services;
using Microsoft.AspNet.Identity;


namespace Wasd.Controllers
{
    [Authorize]
    public class FriendsController : Controller
    {
        //
        // GET: /Friends/
        public ActionResult Friends()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Friends(SearchViewModel model)
        {

            var ser = new SearchService();
            List<ApplicationUser> users = ser.searchUsers(model);

            return View("ShowResults", users);
        }

        public ActionResult AddFriend(string Id)
        {
            var currUserId = User.Identity.GetUserId();
            var friendUserId = Id;

            var ser = new FriendService();

            ser.addFriend(currUserId, friendUserId);

            return View("Friends");
        }

        public ActionResult removeFriend(string Id)
        {
            var friendSer = new FriendService();

            var currUserId = User.Identity.GetUserId();

            friendSer.friendsNoMore(Id, currUserId);

            return View("Friends");
        }

        [ChildActionOnly]
        public ActionResult ListMyFriends()
        {
            var currUserId = User.Identity.GetUserId();

            var ser = new FriendService();

            List<ApplicationUser> myFriends = new List<ApplicationUser>();

            myFriends.AddRange(ser.GetFriends(currUserId));

            return View(myFriends);
        }
	}
}