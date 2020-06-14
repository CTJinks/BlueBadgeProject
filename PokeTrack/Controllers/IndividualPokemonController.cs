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
using System.Web.Http.Description;

namespace PokeTrack.Controllers
{
    [Authorize]
    [RoutePrefix("api/IndividualPokemon")]
    public class IndividualPokemonController : ApiController
    {
        /// <summary>
        /// Establishes connection between User account and ApplicationUser using IndividualPokemonService. **See Line-by-line notes**
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IndividualPokemonService</returns>
        private IndividualPokemonService CreateIndividualPokemonServiceWithUserAccountID(int id)
        { 
        //this line specifies the trainer/user account for the sake of clarity
            var userAccount = id; 

        //This is the new instance of UserService 
            var userService = new UserService();

        //this is a getting method for the application UserID
            string applicationUserID = User.Identity.GetUserId();//Returns Username

        //This passes in the userAccount we want and the AppUser, and returns the user object that will be manipulated in the future
            User user = userService.GetUserAccountByID(applicationUserID, userAccount);

        //Converts the return type to a usable type
            var pokeServiceConstructor = new IndividualPokemonService(user.UserID);
            return pokeServiceConstructor;
        }

        /// <summary>
        /// Creates the instance of IndividualPokemonService
        /// </summary>
        /// <returns>IndividualPokemonService</returns>
        private IndividualPokemonService CreateIndividualPokemonService()
        {    

            var individualPokemonService = new IndividualPokemonService();
            return individualPokemonService;
        }

        /// <summary>
        /// Retrieves all instances of IndividualPokemon within the Db
        /// </summary>
        /// <returns>HttpActionResult</returns>

        [Route("")]
        public IHttpActionResult Get()
        {
            IndividualPokemonService individualPokemonService = CreateIndividualPokemonService();
            var individualPokemon = individualPokemonService.GetAllIndividualPokemon();
            return Ok(individualPokemon);
        }

        /// <summary>
        /// Retrieves a specific instance of IndividualPokemon using its assigned ID
        /// </summary>
        /// <returns>HttpActionResult</returns>
        
        [Route("{id:int}")]
        [ResponseType(typeof(IndividualPokemon))]
        public IHttpActionResult GetByID(int id)
        {
            IndividualPokemonService individualPokemonService = CreateIndividualPokemonService();
            var individualPokemon = individualPokemonService.GetIndividualPokemonByID(id);
            return Ok(individualPokemon);
        }

        /// <summary>
        /// Retrieves a specific instance of IndividualPokemon using its assigned PokemonType
        /// </summary>
        /// <returns>HttpActionResult</returns>
        [Route("{pokemonType}")]
        [ResponseType(typeof(IndividualPokemon))]
        public IHttpActionResult GetByPokemonType(string pokemonType)
        {
            IndividualPokemonService individualPokemonService = CreateIndividualPokemonService();
            var individualPokemon = individualPokemonService.GetIndividualPokemonByPokemonType(pokemonType);
            return Ok(individualPokemon);
        }

        /// <summary>
        /// Creates a new IndividualPokemon that is attached to the specified User account
        /// </summary>
        /// <param name="individualPokemon"></param>
        /// <returns>HttpActionResult</returns>
        public IHttpActionResult Post(IndividualPokemonCreate individualPokemon)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateIndividualPokemonServiceWithUserAccountID(individualPokemon.UserID);

            if (!service.CreateIndividualPokemon(individualPokemon))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Allows updates to individual properties on a specified IndividualPokemon
        /// </summary>
        /// <param name="individualPokemon"></param>
        /// <returns>HttpActionResult</returns>
        public IHttpActionResult Put(IndividualPokemonEdit individualPokemon)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateIndividualPokemonService();

            if (!service.UpdateIndividualPokemon(individualPokemon))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Deletes the specified IndividualPokemon using that IndividualPokemon's ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpActionResult</returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateIndividualPokemonService();

            if (!service.DeleteIndividualPokemon(id))
                return InternalServerError();

            return Ok();
        }
    }
}
