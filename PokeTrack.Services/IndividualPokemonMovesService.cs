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
        private readonly int _userID;
        public IndividualPokemonMovesService()
        {

        }
        public IndividualPokemonMovesService(int userID)
        {
            _userID = userID;

        }

//Copy/Pasted from another services page, ignore errors for now


        public bool CreateIndividualPokemonMoves(IndividualPokemonMovesCreate model)
        {
            var entity =
                 new IndividualPokemonMoves
                 {
                     // IndividualPokemonID = model.IndividualPokemonID,
                     IndividualPokemonMovesID = model.IndividualPokemonMovesID,
                     IndividualPokemon = model.IndividualPokemonMovesList
                     
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
                                    UserID = _userID,
                                    TeamName = e.Team.TeamName,
                                    IndividualPokemonMovesList = e.IndividualPokemonMovesList,
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
                                    UserID = _userID,
                                    TeamName = e.Team.TeamName,
                                    IndividualPokemonMovesList = e.IndividualPokemonMovesList
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
                entity.IndividualPokemonName = model.IndividualPokemonName;
                entity.Team.TeamName = model.TeamName;
                entity.IndividualPokemonMovesList = model.IndividualPokemonMovesList;

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
