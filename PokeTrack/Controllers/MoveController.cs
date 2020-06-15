using PokeTrack.Data;
using PokeTrack.Models.MoveModels;
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
    [RoutePrefix("api/Move")]
    public class MoveController : ApiController
    {
        private MoveService CreateMoveService()
        {

            var moveService = new MoveService();
            return moveService;
        }

        
        [Route("")]
        public IHttpActionResult Get()
        {
            MoveService moveService = CreateMoveService();
            var moves = moveService.GetMoves();
            return Ok(moves);
        }

        
        [Route("{moveName}")]
        [ResponseType(typeof(Move))]
        public IHttpActionResult Get(string moveName)
        {
            MoveService moveService = CreateMoveService();
            var move = moveService.GetMoveByMoveName(moveName);
            return Ok(move);
        }

        
        [Route("{moveID:int}")]
        public IHttpActionResult Get(int id)
        {
            MoveService moveService = CreateMoveService();
            var move = moveService.GetMoveByMoveID(id);
            return Ok(move);
        }

        [Route("")]
        public IHttpActionResult Post(MoveCreate move)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMoveService();

            if (!service.CreateMove(move))
                return InternalServerError();

            return Ok();
        }

        [Route("")]
        public IHttpActionResult Put(MoveEdit move)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMoveService();

            if (!service.UpdateMove(move))
                return InternalServerError();

            return Ok();
        }

        [Route("")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateMoveService();

            if (!service.DeleteMove(id))
                return InternalServerError();

            return Ok();
        }
    }
}
