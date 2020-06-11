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
                     PokemonID = model.PokemonID,
                     PokemonName = model.PokemonName,
                     PokemonType = model.PokemonType,
                     DietType = model.DietType,
                     CreatedUtc = DateTimeOffset.Now,
                     //IndividualPokemonOfThisType = model.IndividualPokemonOfThisType

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
                                    PokemonID = e.PokemonID,
                                    PokemonName = e.PokemonName,
                                    PokemonType = e.PokemonType,
                                    DietType = e.DietType,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }

        }

        public IEnumerable<PokemonListItem> GetPokemonByType()
        {

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .PokemonDb
                        .Where(e => e.PokemonType == e.PokemonType)
                        .Select(
                            e =>
                                new PokemonListItem
                                {
                                    PokemonID = e.PokemonID,
                                    PokemonName = e.PokemonName,
                                    PokemonType = e.PokemonType,
                                    DietType = e.DietType,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }

        }
        public bool UpdatePokemon(PokemonEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PokemonDb
                    .Single(e => e.PokemonID == model.PokemonID);
                entity.PokemonName = model.PokemonName;
                entity.PokemonType = model.PokemonType;
                entity.DietType = entity.DietType;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePokemon(int pokemonID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PokemonDb
                    .Single(e => e.PokemonID == pokemonID);

                ctx.PokemonDb.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
