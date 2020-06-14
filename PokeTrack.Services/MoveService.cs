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
        /// <summary>
        /// Creates an instance of Move and assigns properties
        /// </summary>
        /// <param name="model"></param>
        /// <returns>bool</returns>
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

        /// <summary>
        /// Retrieves all instances of Move
        /// </summary>
        /// <returns>array</returns>
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

        /// <summary>
        /// Retrieves specific instance of Move using the assigned name
        /// </summary>
        /// <param name="moveName"></param>
        /// <returns>MoveListItem</returns>
        public IEnumerable<MoveListItem> GetMoveByMoveName(string moveName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MoveDb
                        .Where(e => e.MoveName == moveName)
                        .Select(
                            e =>
                                new MoveListItem
                                {
                                    MoveID = e.MoveID,
                                    MoveName = e.MoveName,
                                    Damage = e.Damage,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        /// <summary>
        /// Retrieves specific instance of Move using the assigned ID
        /// </summary>
        /// <param name="moveID"></param>
        /// <returns></returns>
        public IEnumerable<MoveListItem> GetMoveByMoveID(int moveID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MoveDb
                        .Where(e => e.MoveID == moveID)
                        .Select(
                            e =>
                                new MoveListItem
                                {
                                    MoveID = e.MoveID,
                                    MoveName = e.MoveName,
                                    Damage = e.Damage,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        /// <summary>
        /// Allows Application User to edit specified Move properties individually
        /// </summary>
        /// <param name="model"></param>
        /// <returns>bool</returns>
        public bool UpdateMove(MoveEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .MoveDb
                    .Single(e => e.MoveID == model.MoveID);
                entity.MoveName = entity.MoveName;
                entity.Damage = entity.Damage;

                return ctx.SaveChanges() == 1;
            }
        }

        /// <summary>
        /// Deletes spcified Move using its assigned MoveID
        /// </summary>
        /// <param name="moveID"></param>
        /// <returns>bool</returns>
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
