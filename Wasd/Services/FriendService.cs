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

            FriendOf friendship = new FriendOf(currUserId, friendUserId);
            FriendOf friendshipReturned = new FriendOf(friendUserId, currUserId);

            if (!isFriendOf(currUserId, friendUserId))
            {
                db.FriendOf.Add(friendship);
                db.SaveChanges();
                db.FriendOf.Add(friendshipReturned);
                db.SaveChanges();
            }


            //try
            //{
            
            //}
            //catch
            //{
            //    var ifExists = from f in db.FriendOf
            //                   where f.Equals(friendship)
            //                   select f;
                
            //}
            //FriendOf fO = new FriendOf() { getUserById(friendUserId), getUserByName(currUserId) };
            //friendOf.Add(new FriendOf () { currUserId, friendUserId });
        }

        public void friendsNoMore(string userId, string friendId)
        {
            var findFriendShip = (from f in db.FriendOf
                                  where f.userId.Equals(userId)
                                  && f.friendId.Equals(friendId)
                                  select f).SingleOrDefault();

            var findFriendShipRet = (from f in db.FriendOf
                                  where f.userId.Equals(friendId)
                                  && f.friendId.Equals(userId)
                                  select f).SingleOrDefault();

            db.FriendOf.Remove(findFriendShip);
            db.SaveChanges();
            db.FriendOf.Remove(findFriendShipRet);
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

        public bool isFriendOf(string user1Id, string user2Id)
        {
            var friendships = db.FriendOf;
            var isFriend = (from f in friendships
                           where f.userId.Equals(user1Id)
                           select f.friendId).ToList();
            if(isFriend.Contains(user2Id) || user1Id == user2Id)
            {
                return true;
            }
            return false;
        }

        public List<ApplicationUser> GetFriends(string id)
        {
            try
            {
                var friendships = (from f in db.FriendOf
                                   where f.userId == id
                                   select f).ToList();
                List<ApplicationUser> friends = new List<ApplicationUser>();

                foreach (var fr in friendships)
                {
                    friends.Add(getUserById(fr.friendId));
                }

                return friends;
            }
            catch(Exception ex)
            {   
            }
            return null;
        }
    }
}