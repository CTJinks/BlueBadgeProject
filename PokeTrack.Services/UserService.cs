using PokeTrack.Data;
using PokeTrack.Models;
using PokeTrack.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Services
{
    public class UserService
    {
        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    UserName = model.UserName,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.TrainerDb.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TrainerDb
                        .Where(e => e.UserID == e.UserID)
                        .Select(
                            e =>
                                new UserListItem
                                {
                                    UserName = e.UserName,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<UserListItem> GetUserByUserName()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TrainerDb
                        .Where(e => e.UserName == e.UserName)
                        .Select(
                            e =>
                                new UserListItem
                                {
                                    UserID = e.UserID,
                                    UserName = e.UserName,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TrainerDb
                    .Single(e => e.UserID == model.UserID);
                entity.UserName = model.UserName;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUser(int userID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TrainerDb
                    .Single(e => e.UserID == userID);

                ctx.TrainerDb.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
