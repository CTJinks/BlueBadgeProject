using PokeTrack.Data;
using PokeTrack.Models;
using PokeTrack.Models.MoveModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Services
{
    public class MoveService
    {
        public bool CreateMove(MoveCreate model)
        {
            var entity =
                 new Move()
                 {

                     MoveName = model.MoveName,
                     Damage = model.Damage,
                     CreatedUtc = DateTimeOffset.Now
                 };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.MoveDb.Add(entity);
                return ctx.SaveChanges() == 1;
            }





        }
        public IEnumerable<MoveListItem> GetMoves()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MoveDb
                        .Where(e => e.MoveID == e.MoveID)
                        .Select(
                            e =>
                                new MoveListItem
                                {

                                    MoveName = e.MoveName,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
