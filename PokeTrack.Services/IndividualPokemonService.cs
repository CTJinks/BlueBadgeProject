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
                    IndividualPokemonID = model.IndividualPokemonID,
                    PokemonID = model.PokemonID,
                    PokemonName = model.PokemonName,
                    PokemonType = model.PokemonType,
                    DietType = model.DietType,
                    Moves = model.Moves,
                    CreatedUtc = DateTimeOffset.Now,


                 };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.IndividualPokemonDb.Add(entity);
                return ctx.SaveChanges() == 1;
            }





        }
        public IEnumerable<IndividualPokemonListItem> GetIndividualPokemonByID()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .IndividualPokemonDb
                        .Where(e => e.IndividualPokemonID == e.IndividualPokemonID)
                        .Select(
                            e =>
                                new IndividualPokemonListItem
                                {
                                    IndividualPokemonID = e.IndividualPokemonID,
                                    IndividualPokemonName = e.IndividualPokemonName,
                                    PokemonName = e.PokemonName,
                                    PokemonType = e.PokemonType,
                                    DietType = e.DietType,
                                    Moves = e.Moves
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<IndividualPokemonListItem> GetIndividualPokemonByPokemonType()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .IndividualPokemonDb
                        .Where(e => e.PokemonType == e.PokemonType)
                        .Select(
                            e =>
                                new IndividualPokemonListItem
                                {
                                    IndividualPokemonID = e.IndividualPokemonID,
                                    IndividualPokemonName = e.IndividualPokemonName,
                                    PokemonName = e.PokemonName,
                                    PokemonType = e.PokemonType,
                                    DietType = e.DietType,
                                    Moves = e.Moves
                                }
                        );

                return query.ToArray();
            }
        }
        public bool UpdateIndividualPokemon(IndividualPokemonEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .IndividualPokemonDb
                    .Single(e => e.IndividualPokemonID == model.IndividualPokemonID);
                entity.Moves = model.Moves;
                entity.IndividualPokemonName = entity.IndividualPokemonName;

                return ctx.SaveChanges() == 1;
            }
        }
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
