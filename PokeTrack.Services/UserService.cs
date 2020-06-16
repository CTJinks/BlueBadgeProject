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
        
        public User GetUserAccountByID(string applicationUserID, int userAccountID)
        {
            ApplicationUser appUser = new ApplicationUser();
            var user = new User();
            using (var ctx = new ApplicationDbContext())
            {
                appUser = ctx.Users.Single((e => e.Id == applicationUserID));          
           user = appUser.UserAccounts.Single(e => e.UserID == userAccountID);
            }
            return user;

        }
       
        /// <summary>
        /// Creates new User account
        /// </summary>
        /// <param name="model"></param>
        /// <returns>bool</returns>
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

        /// <summary>
        /// Retrieves all User accounts attached to the specified Application userID
        /// </summary>
        /// <returns>all applicable Users</returns>
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
                                    UserID = e.UserID,
                                    UserName = e.UserName,
                                    
                                }
                        ); 

                return query.ToArray();
            }
        }

        /// <summary>
        /// Retrieves user by specifying the UserName
        /// </summary>
        /// <returns>User(s)</returns>
        public IEnumerable<UserListItem> GetUserByUserName(string userName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TrainerDb
                        .Where(e => e.UserName == userName)
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

        /// <summary>
        /// Allows App User to update UserName
        /// </summary>
        /// <param name="model"></param>
        /// <returns>bool</returns>
        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TrainerDb
                    .Single(e => e.UserID == e.UserID);
                entity.UserName = model.UserName;
                //entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        /// <summary>
        /// Deletes the specified user account using the ID attached to it
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool DeleteUser(User user)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TrainerDb
                    .Single(e => e.UserName == user.UserName);

                ctx.TrainerDb.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
