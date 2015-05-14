using Microsoft.AspNet.Identity;
using Wasd.Models;

namespace Wasd.Migrations
{

    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Wasd.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Wasd.Models.ApplicationDbContext context)
        {
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("123456");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "Steve",
                    PasswordHash = password,
                });
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "Gorgon",
                    PasswordHash = password,
                });
            context.Users.AddOrUpdate(u => u.UserName,
            new ApplicationUser
                {
                UserName = "Sjomli",
                PasswordHash = password,
                 });
            context.Users.AddOrUpdate(u => u.UserName,
            new ApplicationUser
            {
                UserName = "Goggi",
                PasswordHash = password,
            });
        }

    }
}