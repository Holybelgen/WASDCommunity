using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wasd.Models;
using Microsoft.AspNet.Identity;

namespace Wasd.Services
{
    public class FriendService
    {
        ApplicationDbContext db = new ApplicationDbContext();

        internal void addFriend(string currUserId, string friendUserId)
        {
            var friendOf = db.FriendOf;

            //var user = getUserById(currUserId);
            //var friend = getUserById(friendUserId);
            FriendOf friendship = new FriendOf(currUserId, friendUserId);
            FriendOf friendshipReturned = new FriendOf(friendUserId, currUserId);
            //user.Friends.Add(friend);
            //friend.Friends.Add(user);

            //try
            //{
                db.FriendOf.Add(friendship);
                db.FriendOf.Add(friendshipReturned);
            //}
            //catch
            //{
            //    var ifExists = from f in db.FriendOf
            //                   where f.Equals(friendship)
            //                   select f;
                
            //}
            //FriendOf fO = new FriendOf() { getUserById(friendUserId), getUserByName(currUserId) };
            //friendOf.Add(new FriendOf () { currUserId, friendUserId });
            db.SaveChanges();
        }

        public ApplicationUser getUserByName(string name)
        {
            var user = from u in db.Users
                       where u.UserName.Equals(name)
                       select u;

            return (ApplicationUser)user;
        }

        public ApplicationUser getUserById(string Id)
        {
            var user = (from u in db.Users
                        where u.Id.Equals(Id)
                        select u).SingleOrDefault();

            return user;
        }
    }
}