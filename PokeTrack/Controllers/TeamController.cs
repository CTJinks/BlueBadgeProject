using PokeTrack.Data;
using PokeTrack.Models.TeamModels;
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
    [RoutePrefix("api/Team")]
    public class TeamController : ApiController
    {
        private TeamService CreateTeamService()
        {
            var pokemonService = new TeamService();
            return pokemonService;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            TeamService pokemonService = CreateTeamService();
            var team = pokemonService.GetTeams();
            return Ok(team);
        }

        
        [Route("{id:int}")]
        [ResponseType(typeof(Team))]
        public IHttpActionResult Get(int id)
        {
            TeamService teamService = CreateTeamService();
            var note = teamService.GetTeamByID(id);
            return Ok(note);
        }

        [Route("{teamName:string}")]
        [ResponseType(typeof(Team))]
        public IHttpActionResult Get(string teamName)
        {
            TeamService teamService = CreateTeamService();
            var team = teamService.GetTeamByTeamName(teamName);
            return Ok(team);
        }

        public IHttpActionResult Post(TeamCreate team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTeamService();

            if (!service.CreateTeam(team))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(TeamEdit team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTeamService();

            if (!service.UpdateTeam(team))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateTeamService();

            if (!service.DeleteTeam(id))
                return InternalServerError();

            return Ok();
        }
    }
}
