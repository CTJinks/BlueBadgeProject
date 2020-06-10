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
        public bool CreateIndividualPokemon(IndividualPokemonCreate model)
        {
            var entity =
                 new IndividualPokemon
                 {
                   // IndividualPokemonID = model.IndividualPokemonID,
                  MoveID = model.MoveID,
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
                                    //Moves = e.Pokemon.,
                                   // UserName = e.UserName
                                }
                        );

                return query.ToArray();
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
                                    PokemonName = e.Pokemon.PokemonName,
                                    PokemonType = e.Pokemon.PokemonType,
                                    DietType = e.Pokemon.DietType,
                                   // Moves = e.Moves,
                                   // UserName = e.UserName
                                }
                        );

                return query.ToArray();
            }
        }
        //public IEnumerable<IndividualPokemonListItem> GetIndividualPokemonByPokemonType()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //                .IndividualPokemonDb
        //                .Where(e => e.Pokemon.PokemonType == e.Pokemon.PokemonType)
        //                .Select(
        //                    e =>
        //                        new IndividualPokemonListItem
        //                        {
        //                            IndividualPokemonID = e.IndividualPokemonID,
        //                            IndividualPokemonName = e.IndividualPokemonName,
        //                            PokemonName = e.PokemonName,
        //                            PokemonType = e.PokemonType,
        //                            DietType = e.DietType,
        //                            UserName =e.UserName,
        //                            Moves = e.Moves
        //                        }
        //                );

        //        return query.ToArray();
        //    }
        //}
        public bool UpdateIndividualPokemon(IndividualPokemonEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .IndividualPokemonDb
                    .Single(e => e.IndividualPokemonID == model.IndividualPokemonID);
                //entity.Moves = model.Moves;
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
