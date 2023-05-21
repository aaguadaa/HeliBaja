using Business.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace YourNamespace.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            try
            {
                List<Users> users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Manejar el error adecuadamente
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetUserById(int id)
        {
            try
            {
                Users user = _userService.GetUserById(id);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                // Manejar el error adecuadamente
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AddUser(Users user)
        {
            try
            {
                int userId = _userService.AddUser(user);
                return Ok(userId);
            }
            catch (Exception ex)
            {
                // Manejar el error adecuadamente
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateUser(Users user)
        {
            try
            {
                bool updated = _userService.UpdateUser(user);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                // Manejar el error adecuadamente
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            try
            {
                bool deleted = _userService.DeleteUser(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                // Manejar el error adecuadamente
                return InternalServerError(ex);
            }
        }

        // Resto de los métodos del controlador
    }
}