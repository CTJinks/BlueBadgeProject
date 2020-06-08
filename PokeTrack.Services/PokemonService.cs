using PokeTrack.Data;
using PokeTrack.Models;
using PokeTrack.Models.PokemonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Services
{
    public class PokemonService
    {
        public bool CreatePokemon(PokemonCreate model)
        {
            var entity =
                 new Pokemon()
                 {

                     PokemonName = model.PokemonName,
                     PokemonType = model.PokemonType,
                     DietType = model.DietType,
                     CreatedUtc = DateTimeOffset.Now
                 };

            using (var ctx = new ApplicationDbContext())
            {
                Pokemon Pokemon = ctx.PokemonDb.Add(entity);
                return ctx.SaveChanges() == 1;
            }





        }
        public IEnumerable<PokemonListItem> GetPokemons()
        {

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .PokemonDb
                        .Where(e => e.PokemonID == e.PokemonID)
                        .Select(
                            e =>
                                new PokemonListItem
                                {

                                    PokemonName = e.PokemonName,
                                    PokemonType = e.PokemonType,
                                    DietType = e.DietType,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }

        }
    }
}
