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

        public ActionResult AddFriend(string id)
        {
            var currUserId = User.Identity.GetUserId();
            var friendUserId = id;

            var ser = new FriendService();

            ser.addFriend(currUserId, friendUserId);

            return View("Friends");
        }


	}
}