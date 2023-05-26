using Business.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace HeliBaja.Controllers
{
    [RoutePrefix("api/admins")]
    public class AdminController : ApiController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetAdminById(int id)
        {
            Admin admin = _adminService.GetAdminById(id);
            if (admin == null)
                return NotFound();

            return Ok(admin);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult CreateAdmin([FromBody] Admin admin)
        {
            if (admin == null)
                return BadRequest("Request is null");

            int adminId = _adminService.AddAdmin(admin);
            var payload = new { Id = adminId };
            return Ok(payload);
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult UpdateAdmin(int id, [FromBody] Admin admin)
        {
            if (admin == null)
                return BadRequest("Request is null");

            admin.Id = id;
            bool updated = _adminService.UpdateAdmin(admin);
            if (!updated)
                return BadRequest("Unable to update admin");

            return Ok(admin);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteAdmin(int id)
        {
            bool deleted = _adminService.DeleteAdmin(id);
            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}