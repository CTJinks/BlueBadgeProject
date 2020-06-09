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
        private IndividualPokemonService CreateIndividualPokemonService()
        {

            var moveService = new IndividualPokemonService();
            return moveService;
        }
        public IHttpActionResult Get()
        {
            IndividualPokemonService moveService = CreateIndividualPokemonService();
            var moves = moveService.GetIndividualPokemon();
            return Ok(moves);
        }
        public IHttpActionResult Post(IndividualPokemonCreate individualPokemon)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateIndividualPokemonService();

            if (!service.CreateIndividualPokemon(individualPokemon))
                return InternalServerError();

            return Ok();
        }
    }
}
