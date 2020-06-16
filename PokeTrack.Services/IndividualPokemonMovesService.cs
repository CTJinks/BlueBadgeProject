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
        public bool CreateIndividualPokemonMoves(IndividualPokemonMovesCreate model)
        {
            var entity =
                 new IndividualPokemonMoves()
                 {
                     MoveID= model.MoveID,
                     IndividualPokemonID = model.IndividualPokemonID
                 };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.IndividualPokemonMovesDb.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Come back here later to address listing properties from Move and IndividualPokemon

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
                                    MoveID = e.MoveID,
                                    IndividualPokemonID = e.IndividualPokemonID


                                }
                        );

                return query.ToArray();
            }
        }
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
