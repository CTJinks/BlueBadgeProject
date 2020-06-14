using PokeTrack.Data;
using PokeTrack.Models.IndividualPokemonMovesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Services
{
    public class IndividualPokemonMovesService
    {
        /// <summary>
        /// Creates Instance of IndividualPokemonMoves and acts as a joining table between IndividualPokemon and Move
        /// </summary>
        /// <param name="model"></param>
        /// <returns>bool</returns>
        public bool CreateIndividualPokemonMoves(IndividualPokemonMovesCreate model)
        {
            var entity =
                 new IndividualPokemonMoves()
                 {
                     MoveID = model.MoveID,
                     IndividualPokemonID = model.IndividualPokemonID,

                 };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.IndividualPokemonMovesDb.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        /// <summary>
        /// Retrieves all instances of IndividualPokemonMoves
        /// </summary>
        /// <returns>array</returns>
        public IEnumerable<IndividualPokemonMovesListItem> GetIndividualPokemonMoves()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .IndividualPokemonMovesDb
                        .Where(e => e.IndividualPokemonMovesID == e.IndividualPokemonMovesID)
                        .Select(
                            e =>
                                new IndividualPokemonMovesListItem
                                {
                                    IndividualPokemonMovesID = e.IndividualPokemonID,
                                    MoveName = e.Move.MoveName,
                                    IndividualPokemonName = e.IndividualPokemon.IndividualPokemonName,
                                    Damage = e.Move.Damage
                                }
                        );

                return query.ToArray();
            }
        }

        /// <summary>
        /// Allows ApplicationUser to update properties of specified instance of IndividualPokemonMoves
        /// </summary>
        /// <param name="model"></param>
        /// <returns>bool</returns>
        public bool UpdateIndividualPokemonMoves(IndividualPokemonMovesEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .IndividualPokemonMovesDb
                    .Single(e => e.IndividualPokemonMovesID == model.IndividualPokemonMovesID);
                entity.MoveID = model.MoveID;
                entity.IndividualPokemonID = model.IndividualPokemonID;

                return ctx.SaveChanges() == 1;
            }
        }

        /// <summary>
        /// Deletes specific instance of IndividualPokemonMoves using the assigned ID
        /// </summary>
        /// <param name="individualPokemonMovesID"></param>
        /// <returns></returns>
        public bool DeleteIndividualPokemonMoves(int individualPokemonMovesID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .IndividualPokemonMovesDb
                    .Single(e => e.IndividualPokemonMovesID == individualPokemonMovesID);

                ctx.IndividualPokemonMovesDb.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
