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

        public void addGroup(Group newGroup)
        {
            var dbGroup = db.Groups;

            dbGroup.Add(newGroup);
            db.SaveChanges();
        }
    }
}