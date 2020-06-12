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

namespace PokeTrack.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        //private UserService CreateUserServiceWithUserAccountID(int id)
        //{
        //    var accountWeWant = id;
        //    var userService = new UserService();
        //    string applicationUserID = User.Identity.GetUserId();
        //    User user = userService.GetUserAccountByID(applicationUserID, accountWeWant);

        //    var userIDAssignService = new UserService();
        //    return userIDAssignService;
        //}
        private UserService CreateUserService()
        {

            var userService = new UserService();
            return userService;
        }
        public IHttpActionResult Get()
        {
            UserService userService = CreateUserService();
            var users = userService.GetUsers();
            return Ok(users);
        }

        //public IHttpActionResult Get()
        //{
        //    UserService userService = CreateUserService();
        //    var user = userService.GetUserByUserName();
        //    return Ok(user);
        //}
        public IHttpActionResult Post(UserCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.CreateUser(user))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(UserEdit user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.UpdateUser(user))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(User user)
        {
            var service = CreateUserService();

            if (!service.DeleteUser(user))
                return InternalServerError();

            return Ok();
        }

    }
}
