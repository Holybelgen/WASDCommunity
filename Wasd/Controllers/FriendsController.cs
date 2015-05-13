using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wasd.Models;
using Wasd.Services;


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

	}
}