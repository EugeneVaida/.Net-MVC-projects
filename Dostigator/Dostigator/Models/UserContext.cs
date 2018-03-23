using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dostigator.Models
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base("DefaultConnection")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }

    public class UserDbInitializer : DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext db)
        {
            db.Roles.Add( new Role { Id = 1, Name = "admin"});
            db.Roles.Add( new Role { Id = 2, Name = "user"});
            db.Users.Add(new User
            {   
                Id = 1,
                Age = 25,
                Email = "somemail@gmail.com",
                Password = "123456",
                RoleId = 1
            }
            );

            db.Users.Add(new User
            {
                Id = 2,
                Age = 25,
                Email = "e.v.e.r.e.s.tt.1551@gmail.com",
                Password = "123456",
                RoleId = 2
            }
            );


            base.Seed(db);
        }
    }
}