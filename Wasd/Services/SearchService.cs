using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Wasd.Models;

namespace Wasd.Services
{
    public class SearchService
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<ApplicationUser> searchUsers(SearchViewModel searchstring)
        {
            string searchString = searchstring.Query;

            var users = from u in db.Users
                        //where u.UserName.Contains(searchString)
                        select u;

            users = users.Where(s => s.UserName.Contains(searchString));
            return users.ToList();
        }
    }
}