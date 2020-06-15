using PokeTrack.Data;
using PokeTrack.Models.IndividualPokemonMovesModels;
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
    public class IndividualPokemonMovesController : ApiController
    {
        private IndividualPokemonMovesService CreateIndividualPokemonMovesService()
        {

            var individualPokemonMovesService = new IndividualPokemonMovesService();
            return individualPokemonMovesService;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            IndividualPokemonMovesService individualPokemonMovesService = CreateIndividualPokemonMovesService();
            var individualPokemonMoves = individualPokemonMovesService.GetIndividualPokemonMoves();
            return Ok(individualPokemonMoves);
        }

        [Route("")]
        public IHttpActionResult Post(IndividualPokemonMovesCreate individualPokemonMoves)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateIndividualPokemonMovesService();

            if (!service.CreateIndividualPokemonMoves(individualPokemonMoves))
                return InternalServerError();

            return Ok();
        }

        [Route("")]
        public IHttpActionResult Put(IndividualPokemonMovesEdit individualPokemonMoves)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateIndividualPokemonMovesService();

            if (!service.UpdateIndividualPokemonMoves(individualPokemonMoves))
                return InternalServerError();

            return Ok();
        }

        [Route("")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateIndividualPokemonMovesService();

            if (!service.DeleteIndividualPokemonMoves(id))
                return InternalServerError();

            return Ok();
        }
    }
}
