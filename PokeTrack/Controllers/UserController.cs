using Microsoft.AspNet.Identity;
using PokeTrack.Data;
using PokeTrack.Models.UserModels;
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
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        
        private UserService CreateUserService()
        {

            var userService = new UserService();
            return userService;
        }

        
        [Route("")]
        
        public IHttpActionResult Get()
        {
            UserService userService = CreateUserService();
            var users = userService.GetUsers();
            return Ok(users);
        }

        
        [Route("{userName}")]
        [ResponseType(typeof(User))]
        public IHttpActionResult Get(string userName)
        {
            UserService userService = CreateUserService();
            var user = userService.GetUserByUserName(userName);
            return Ok(user);
        }

        [Route("")]
        public IHttpActionResult Post(UserCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.CreateUser(user))
                return InternalServerError();

            return Ok();
        }

        [Route("")]
        public IHttpActionResult Put(UserEdit user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.UpdateUser(user))
                return InternalServerError();

            return Ok();
        }

        [Route("")]
        public IHttpActionResult Delete(User user)
        {
            var service = CreateUserService();

            if (!service.DeleteUser(user))
                return InternalServerError();

            return Ok();
        }

    }
}
