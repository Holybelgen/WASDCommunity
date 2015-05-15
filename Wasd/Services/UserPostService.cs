using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wasd.Models;
using Wasd.Services;


namespace Wasd.Services
{

    public class userPostService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<UserPost> GetNewPosts()
        {
            var posts = db.UserPosts.ToList();

            //posts.OrderByDescending(x => x.Date);

            return posts;
        }

        public List<UserPost> getPostsFromFriends(string userId)
        {
            var friendSer = new FriendService();
            List<UserPost> friendPosts = new List<UserPost>();
            
            var posts = from p in db.UserPosts
                        select p;

            if (posts.Any())
            {
                posts.ToList();
            }
            else
            {
                return friendPosts;
            }

            foreach(UserPost up in posts)
            {
                if(friendSer.isFriendOf(userId, up.userID))
                {
                    friendPosts.Add(up);
                }
            }

            return friendPosts;
        }


        public void addUserPost(UserPost userPost)
        {
            db.UserPosts.Add(userPost);
            db.SaveChanges();
        }
    }
}