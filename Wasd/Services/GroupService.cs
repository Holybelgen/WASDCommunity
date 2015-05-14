using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wasd.Models;

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

        //public List<Group> listMyGroups(string userId)
        //{
        //    var dbGroup = db.Groups;
        //    return;
        //}
    }
}