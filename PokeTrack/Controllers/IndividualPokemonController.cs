using Microsoft.AspNet.Identity;
using PokeTrack.Data;
using PokeTrack.Models.IndividualPokemonModels;
using PokeTrack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PokeTrack.Controllers
{
    [Authorize]
    public class IndividualPokemonController : ApiController
    {
        private IndividualPokemonService CreateIndividualPokemonServiceWithUserAccountID(int id)
        { 
            var accountWeWant = id; //for the sake of clarity
            var userService = new UserService();
            string applicationUserID = User.Identity.GetUserId();

            User user = userService.GetUserAccountByID(applicationUserID, accountWeWant);
            var pokeService = new IndividualPokemonService(user.UserID);
            return pokeService;
        }
        private IndividualPokemonService CreateIndividualPokemonService()
        {    

            var moveService = new IndividualPokemonService();
            return moveService;
        }
        public IHttpActionResult Get()
        {
            IndividualPokemonService individualPokemonService = CreateIndividualPokemonService();
            var individualPokemon = individualPokemonService.GetAllIndividualPokemon();
            return Ok(individualPokemon);
        }
        public IHttpActionResult GetByID()
        {
            IndividualPokemonService individualPokemonService = CreateIndividualPokemonService();
            var individualPokemon = individualPokemonService.GetIndividualPokemonByID();
            return Ok(individualPokemon);
        }

        //public IHttpActionResult GetByPokemonType()
        //{
        //    IndividualPokemonService individualPokemonService = CreateIndividualPokemonService();
        //    var individualPokemon = individualPokemonService.GetIndividualPokemonByPokemonType();
        //    return Ok(individualPokemon);
        //}
        public IHttpActionResult Post(IndividualPokemonCreate individualPokemon)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateIndividualPokemonServiceWithUserAccountID(individualPokemon.UserID);

            if (!service.CreateIndividualPokemon(individualPokemon))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(IndividualPokemonEdit individualPokemon)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateIndividualPokemonService();

            if (!service.UpdateIndividualPokemon(individualPokemon))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateIndividualPokemonService();

            if (!service.DeleteIndividualPokemon(id))
                return InternalServerError();

            return Ok();
        }
    }
}
