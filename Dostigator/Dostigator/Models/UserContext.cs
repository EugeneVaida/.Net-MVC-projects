using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dostigator.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Aim> Aims { get; set; }
    }

    /*public class UserDbInitializer : DropCreateDatabaseAlways<UserContext>
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



            db.Aims.Add(new Aim {
                Name = "Заголовок моей 1 цели",
                Text = "Описание цели",
                Date = "12.03.2018",
                Group = "Английский",
                Img = "",
                UserId = 2

            });

            db.Aims.Add(new Aim
            {
                Name = "Заголовок моей 2 цели",
                Text = "Описание цели",
                Date = "12.03.2018",
                Group = "Английский",
                Img = "https://drscdn.500px.org/photo/250350579/q%3D80_h%3D300/v2?webp=true&sig=566cd84bd24e7b52bd0c4cbb8fd48d469f48a8001656d1fb525c787cdaf7f64f",
                UserId = 2

            });

            db.Aims.Add(new Aim
            {
                Name = "Заголовок моей 1 цели",
                Text = "Описание цели п офизике администратора",
                Date = "12.03.2018",
                Group = "Физика",
                Img = "https://drscdn.500px.org/photo/250350579/q%3D80_h%3D300/v2?webp=true&sig=566cd84bd24e7b52bd0c4cbb8fd48d469f48a8001656d1fb525c787cdaf7f64f",
                UserId = 1

            });

            base.Seed(db);
        }
    }*/
}