using PokeTrack.Data;
using PokeTrack.Models.IndividualPokemonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Services
{
    public class IndividualPokemonService
    {
        private readonly int _userID;
        public IndividualPokemonService()
        {

        }
        public IndividualPokemonService(int userID)
        {
            _userID = userID;

        }

        /// <summary>
        /// Creates instance of a specified Pokemon that is also attached to a User account
        /// </summary>
        /// <param name="model"></param>
        /// <returns>bool</returns>
        public bool CreateIndividualPokemon(IndividualPokemonCreate model)
        {
            var entity =
                 new IndividualPokemon
                 {
                   // IndividualPokemonID = model.IndividualPokemonID,
                  
                  IndividualPokemonName = model.IndividualPokemonName,
                  PokemonID = model.PokemonID,
                  UserID = _userID,
                  TeamID = model.TeamID
                  
                 };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.IndividualPokemonDb.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        /// <summary>
        /// Retrieves all IndividualPokemon in IndividualPokemonDb
        /// </summary>
        /// <returns>array</returns>
        public IEnumerable<IndividualPokemonListItem> GetAllIndividualPokemon()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .IndividualPokemonDb
                        .Where(e => e.UserID == _userID)
                        .Select(
                            e =>
                                new IndividualPokemonListItem
                                {
                                    IndividualPokemonID = e.IndividualPokemonID,
                                    IndividualPokemonName = e.IndividualPokemonName,
                                    PokemonName = e.Pokemon.PokemonName,
                                    PokemonType = e.Pokemon.PokemonType,
                                    DietType = e.Pokemon.DietType,
                                }
                        );

                return query.ToArray();
            }
        }

        /// <summary>
        /// Retrieves an IndividualPokemon using its assigned ID
        /// </summary>
        /// <returns>array</returns>
        public IEnumerable<IndividualPokemonListItem> GetIndividualPokemonByID(int individualPokemonID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .IndividualPokemonDb
                        .Where(e => e.IndividualPokemonID == individualPokemonID)
                        .Select(
                            e =>
                                new IndividualPokemonListItem
                                {
                                    IndividualPokemonID = e.IndividualPokemonID,
                                    IndividualPokemonName = e.IndividualPokemonName,
                                    PokemonName = e.Pokemon.PokemonName,
                                    PokemonType = e.Pokemon.PokemonType,
                                    DietType = e.Pokemon.DietType,
                                }
                        );

                return query.ToArray();
            }
        }

        /// <summary>
        /// Retrieves an IndividualPokemon using its assigned PokemonType
        /// </summary>
        /// <param name="pokemonType"></param>
        /// <returns>array</returns>
        public IEnumerable<IndividualPokemonListItem> GetIndividualPokemonByPokemonType(string pokemonType)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .IndividualPokemonDb
                        .Where(e => e.Pokemon.PokemonType == pokemonType)
                        .Select(
                            e =>
                                new IndividualPokemonListItem
                                {
                                    IndividualPokemonID = e.IndividualPokemonID,
                                    IndividualPokemonName = e.IndividualPokemonName,
                                    PokemonName = e.Pokemon.PokemonName,
                                    PokemonType = e.Pokemon.PokemonType,
                                    DietType = e.Pokemon.DietType,
                                }
                        );

                return query.ToArray();
            }
        }

        /// <summary>
        /// Updates Name property of a specified IndividualPokemon using the assigned ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns>bool</returns>
        public bool UpdateIndividualPokemon(IndividualPokemonEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .IndividualPokemonDb
                    .Single(e => e.IndividualPokemonID == model.IndividualPokemonID);
          
                entity.IndividualPokemonName = entity.IndividualPokemonName;

                return ctx.SaveChanges() == 1;
            }
        }

        /// <summary>
        /// Deletes specified IndividualPokemon using the assigned ID
        /// </summary>
        /// <param name="individualPokemonID"></param>
        /// <returns>bool</returns>
        public bool DeleteIndividualPokemon(int individualPokemonID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .IndividualPokemonDb
                    .Single(e => e.IndividualPokemonID == individualPokemonID);

                ctx.IndividualPokemonDb.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
