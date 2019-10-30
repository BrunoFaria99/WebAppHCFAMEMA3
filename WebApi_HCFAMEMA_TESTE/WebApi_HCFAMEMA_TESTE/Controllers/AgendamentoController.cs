using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi_HCFAMEMA_TESTE.Data;
using WebApi_HCFAMEMA_TESTE.Models;

namespace WebApi_HCFAMEMA_TESTE.Controllers
{
    [Route("api/Agendamentos")]
    public class AgendamentoController : Controller
    {
        private readonly IAgendamentoRepository _repo;
        public AgendamentoController(IAgendamentoRepository agendamentoRepository)
        {
            _repo = agendamentoRepository;
        }
        public IEnumerable<Agendamento> GetAll()
        {
            return _repo.GetAgendamentos();
        }
        [HttpGet("{id}", Name = "GetProduto")]

        public IActionResult GetById(int id)
        {
            var agendamento = _repo.GetAgendamento(id);
            if (agendamento == null)
            {
                return NotFound();
            }
            return new ObjectResult(agendamento);
        }
        [HttpPost]
        public IActionResult Add([FromBody] Agendamento agendamento)
        {
            if (agendamento == null)
            {
                return BadRequest();
            }
            _repo.AddAgendamento(agendamento);
            return CreatedAtRoute("GetProduto", new { id = agendamento.IdAgendamento }, agendamento);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Agendamento agendamento)
        {
            if (agendamento == null)
            {
                return BadRequest();
            }
            agendamento.IdAgendamento = id;
            _repo.UpdateAgendamento(agendamento);
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.RemoveAgendamento(id);
        }
    }
}