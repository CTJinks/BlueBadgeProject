using PokeTrack.Data;
using PokeTrack.Models;
using PokeTrack.Models.ChallengeRequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Services
{
    public class ChallengeRequestService
    {
        public bool CreateChallengeRequest(ChallengeRequestCreate model)
        {
            var entity =
                new ChallengeRequest()
                {
                    //Address
                    RequestUser = model.RequestUser,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ChallengeDb.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ChallengeRequestListItem> GetChallengeRequests()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .ChallengeDb
                        .Where(e => e.RequestUser == e.RequestUser)
                        .Select(
                            e =>
                                new ChallengeRequestListItem
                                {
                                    RequestUser = e.RequestUser,
                                    PokemonList = e.PokemonList
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
