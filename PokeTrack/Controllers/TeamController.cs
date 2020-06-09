using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PokeTrack.Controllers
{
    [Authorize]
    public class TeamController : ApiController
    {
        private TeamService CreateTeamService()
        {
            var pokemonService = new TeamService();
            return pokemonService;
        }
        public IHttpActionResult Get()
        {
            TeamService pokemonService = CreateTeamService();
            var team = pokemonService.GetTeams();
            return Ok(team);
        }
        public IHttpActionResult Post(TeamCreate team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTeamService();

            if (!service.CreatePokemon(team))
                return InternalServerError();

            return Ok();
        }
    }
}
