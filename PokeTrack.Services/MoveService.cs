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
                     MoveID = model.MoveID,
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
                                    MoveID = e.MoveID,
                                    MoveName = e.MoveName,
                                    CreatedUtc = e.CreatedUtc,
                                    Damage = e.Damage
                                }
                        );

                return query.ToArray();
            }
        }
        public bool UpdateMove(MoveEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .MoveDb
                    .Single(e => e.MoveID == model.MoveID);
                entity.MoveID = model.MoveID;
                entity.MoveName = entity.MoveName;
                entity.Damage = entity.Damage;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteMove(int moveID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .MoveDb
                    .Single(e => e.MoveID == moveID);

                ctx.MoveDb.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
