using PokeTrack.Data;
using PokeTrack.Models.IndividualPokemonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Services
{
    public class IndividualPokemonService
    {
        public bool CreateIndividualPokemon(IndividualPokemonCreate model)
        {
            var entity =
                 new IndividualPokemon()
                 {

                 };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.IndividualPokemonDb.Add(entity);
                return ctx.SaveChanges() == 1;
            }





        }
        public IEnumerable<IndividualPokemonListItem> GetIndividualPokemon()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MoveDb
                        .Where(e => e.MoveID == e.MoveID)
                        .Select(
                            e =>
                                new IndividualPokemonListItem
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
