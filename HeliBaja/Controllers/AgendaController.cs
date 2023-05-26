using Business.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace HeliBaja.Controllers
{
    [RoutePrefix("api/agendas")]
    public class AgendaController : ApiController
    {
        private readonly IAgendaService _agendaService;

        public AgendaController(IAgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllAgendas()
        {
            IEnumerable<Agenda> agendas = _agendaService.GetAllAgendas();
            List<Agenda> agendaList = agendas.ToList();
            return Ok(agendaList);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetAgendaById(int id)
        {
            Agenda agenda = _agendaService.GetAgendaById(id);
            if (agenda == null)
                return NotFound();

            return Ok(agenda);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult CreateAgenda([FromBody] Agenda agenda)
        {
            if (agenda == null)
                return BadRequest("Request is null");

            int agendaId = _agendaService.AddAgenda(agenda);
            var payload = new { Id = agendaId };
            return Ok(payload);
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult UpdateAgenda(int id, [FromBody] Agenda agenda)
        {
            if (agenda == null)
                return BadRequest("Request is null");

            agenda.Id_Agenda = id;
            bool updated = _agendaService.UpdateAgenda(agenda);
            if (!updated)
                return BadRequest("Unable to update agenda");

            return Ok(agenda);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteAgenda(int id)
        {
            bool deleted = _agendaService.DeleteAgenda(id);
            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}