using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;

namespace Wasd.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public List<ApplicationUser> Friends {get; set;}
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<FriendOf> FriendOf { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}