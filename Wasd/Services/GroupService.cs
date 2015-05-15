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

            dbGroup.Add(newGroup);
            db.SaveChanges();

            var theGroup = getGroupByName(newGroup.groupName);

            string groupId = theGroup.Id.ToString();

            MemberOf membership = new MemberOf(userId, groupId);
            dbMember.Add(membership);
            db.SaveChanges();
        }

        public Group getGroupByName(string groupName)
        {
            var dbGroup = db.Groups;

            var theGroup = (from g in dbGroup
                            where g.groupName.Equals(groupName)
                            select g).SingleOrDefault();
            return theGroup;
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
                if (isMemberOf(userId, g.Id.ToString()))
                {
                    myGroups.Add(g);
                }
            }

            return myGroups;
        }

        public List<ApplicationUser> getMembersOfGroup(int groupId)
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

        public List<GroupPost> getGroupPosts(int groupId)
        {
            var dbGrPost = db.GroupPosts;

            var gPosts = (from gP in dbGrPost
                          where gP.groupID.Equals(groupId.ToString())
                          select gP).ToList();

            return gPosts;
        }

        public Group getGroupById(int groupId)
        {
            var group = (from g in db.Groups
                         where g.Id.Equals(groupId)
                         select g).SingleOrDefault();

            return group;
        }

        public void addGroupPost(GroupPost groupPost)
        {
            db.GroupPosts.Add(groupPost);
            db.SaveChanges();
        }
    }
}