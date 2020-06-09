using PokeTrack.Models.ChallengeRequestModels;
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
    public class ChallengeRequestController : ApiController
    {
        private ChallengeRequestService CreateChallengeRequestService()
        {
            var challengeRequestService = new ChallengeRequestService();
            return challengeRequestService;
        }
        public IHttpActionResult Get()
        {
            ChallengeRequestService challengeRequestService = CreateChallengeRequestService();
            var challengeRequests = challengeRequestService.GetChallengeRequests();
            return Ok(challengeRequests);
        }
        public IHttpActionResult Post(ChallengeRequestCreate challengeRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateChallengeRequestService();

            if (!service.CreateChallengeRequest(challengeRequest))
                return InternalServerError();

            return Ok();
        }
    }
}
