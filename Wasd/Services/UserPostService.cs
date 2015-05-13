using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wasd.Models;

namespace Wasd.Services
{
    public class UserPostService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<UserPost> GetNewPosts()
        {
            var posts = db.UserPosts.ToList();

            //posts.OrderByDescending(x => x.Date);

            return posts;
        }
    }
}