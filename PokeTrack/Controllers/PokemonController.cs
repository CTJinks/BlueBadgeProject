using PokeTrack.Data;
using PokeTrack.Models.PokemonModels;
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
    [RoutePrefix("api/Pokemon")]
    public class PokemonController : ApiController
    {
        private PokemonService CreatePokemonService()
        {
            var pokemonService = new PokemonService();
            return pokemonService;
        }

        
        [Route("")]
        public IHttpActionResult Get()
        {
            PokemonService pokemonService = CreatePokemonService();
            var pokemon = pokemonService.GetPokemon();
            return Ok(pokemon);
        }

       
        [Route("{type}")]
        [ResponseType(typeof(Pokemon))]
        public IHttpActionResult Get(string type)
        {
            PokemonService pokemonService = CreatePokemonService();
            var pokemon = pokemonService.GetPokemonByType(type);
            return Ok(pokemon);
        }

        [Route("")]
        public IHttpActionResult Post(PokemonCreate pokemon)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePokemonService();

            if (!service.CreatePokemon(pokemon))
                return InternalServerError();

            return Ok();
        }

        [Route("")]
        public IHttpActionResult Put(PokemonEdit pokemon)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePokemonService();

            if (!service.UpdatePokemon(pokemon))
                return InternalServerError();

            return Ok();
        }

        [Route("")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePokemonService();

            if (!service.DeletePokemon(id))
                return InternalServerError();

            return Ok();
        }
    }
}
