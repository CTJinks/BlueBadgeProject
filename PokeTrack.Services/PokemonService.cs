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
        /// <summary>
        /// Creates instance of Pokemon and assigns properties to it
        /// </summary>
        /// <param name="model"></param>
        /// <returns>bool</returns>
        public bool CreatePokemon(PokemonCreate model)
        {
            var entity =
                 new Pokemon()
                 {
                     PokemonName = model.PokemonName,
                     PokemonType = model.PokemonType,
                     DietType = model.DietType,
                     CreatedUtc = DateTimeOffset.Now,
                 };
            using (var ctx = new ApplicationDbContext())
            {
                Pokemon Pokemon = ctx.PokemonDb.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        /// <summary>
        /// Retrieves all instances of Pokemon
        /// </summary>
        /// <returns>array</returns>
        public IEnumerable<PokemonListItem> GetPokemon()
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

        /// <summary>
        /// Retrieves all instances of Pokemon with the specified type
        /// </summary>
        /// <returns>array</returns>
        public IEnumerable<PokemonListItem> GetPokemonByType(string pokemonType)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .PokemonDb
                        .Where(e => e.PokemonType == pokemonType)
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

        /// <summary>
        /// Allows Application User to edit Pokemon properties individually
        /// </summary>
        /// <param name="model"></param>
        /// <returns>bool</returns>
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

        /// <summary>
        /// Deletes instance of Pokemon using the Pokemon's assigned ID
        /// </summary>
        /// <param name="pokemonID"></param>
        /// <returns>bool</returns>
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
