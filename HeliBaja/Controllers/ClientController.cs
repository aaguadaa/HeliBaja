using Business.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace HeliBaja.Controllers
{
    [RoutePrefix("client")]
    public class ClientController : ApiController
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetClientById(int id)
        {
            Clients client = _clientService.GetClientById(id);
            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult CreateClient([FromBody] Clients client)
        {
            if (client == null)
                return BadRequest("Client data is null.");

            int createdClientId = _clientService.AddClient(client);
            if (createdClientId <= 0)
                return BadRequest("Unable to create client.");

            return Ok(new { Id = createdClientId });
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult UpdateClient(int id, [FromBody] Clients client)
        {
            if (client == null)
                return BadRequest("Client data is null.");

            client.Id_Client = id;
            bool updated = _clientService.UpdateClient(client);
            if (!updated)
                return BadRequest("Unable to update client.");

            return Ok(client);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteClient(int id)
        {
            bool deleted = _clientService.DeleteClient(id);
            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}