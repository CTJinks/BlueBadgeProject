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
                    PokemonList = model.PokemonList,
                    ChallengeRequest = model.ChallengeRequest,
                    ChallengesAccepted = model.ChallengesAccepted,
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
                                    PokemonList = e.PokemonList,
                                    ChallengeRequest = e.ChallengeRequest,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
