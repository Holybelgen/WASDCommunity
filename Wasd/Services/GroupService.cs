using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wasd.Models;
using Wasd.Services;

namespace Wasd.Services
{
    public class GroupService
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void createGroup(Group newGroup, string userId)
        {
            var dbGroup = db.Groups;
            var dbMember = db.MemberOf;

            MemberOf membership = new MemberOf(userId, newGroup.Id);

            dbMember.Add(membership);
            dbGroup.Add(newGroup);
            db.SaveChanges();
        }

        public bool isMemberOf(string userId, string groupId)
        {
            var memberDb = db.MemberOf;

            var memberList = (from g in memberDb
                              where g.groupId.Equals(groupId)
                              select g.userId).ToList();

            if (memberList.Contains(userId))
            {
                return true;
            }
            return false;
        }

        public List<Group> listAllGroups()
        {
            var allGroups = db.Groups.ToList();

            return allGroups;
        }

        public List<Group> listMyGroups(string userId)
        {
            var dbGroup = db.Groups;
            var allGroups = dbGroup.ToList();

            List<Group> myGroups = new List<Group>();

            foreach (Group g in allGroups)
            {
                if (isMemberOf(userId, g.Id))
                {
                    myGroups.Add(g);
                }
            }

            return myGroups;
        }

        public List<ApplicationUser> getMembersOfGroup(string groupId)
        {
            var members = (from g in db.MemberOf
                           where g.groupId.Equals(groupId)
                           select g.userId).ToList();

            List<ApplicationUser> theMembers = new List<ApplicationUser>();

            var ser = new FriendService();

            foreach (string u in members)
            {
                theMembers.Add(ser.getUserById(u));
            }

            return theMembers;
        }
    }
}