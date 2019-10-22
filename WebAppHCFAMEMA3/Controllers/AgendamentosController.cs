using System;
using System.Collections.Generic;
using System.Linq;
using WebAppHCFAMEMA3.Services;
using WebAppHCFAMEMA3.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAppHCFAMEMA3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : Controller
    {
        private readonly IRepository _repo;
        
        public AgendamentosController(IRepository repository)
        {
            this._repo = repository;
        }

        // GET api/BuscaAgendamentos
        [HttpGet(Name ="BuscaAgendamentos")]
        public IActionResult Get()
        {
            var item = _repo.GetAgendamentos();

            var outputModel = ToOutputModel(item);
            return Ok(outputModel);
        }
        
        // GET api/id/BuscaAgendamento
        [HttpGet("{id}", Name ="BuscaAgendamento")]
        public IActionResult Get(int id)
        {
            var item = _repo.GetAgendamento(id);
            if(item == null)
            {
                return NotFound(); //404
            }
            var outputItem = ToOutputModel(item);
            return Ok(outputItem); //200
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]AgendInputModel inputItem)
        {
            if(inputItem == null)
            {
                return NotFound();
            }
            var item = ToDomainModel(inputItem);
            _repo.AddAgendamento(item);

            var outputItem = ToOutputModel(item);
            return CreatedAtRoute("GetAgendamento", new { id = outputItem.IdAgendamento }, outputItem);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AgendInputModel inputItem)
        {
            if (inputItem == null || id != inputItem.IdAgendamento)
            {
                return BadRequest();
            }

            if (!_repo.AgendamentoExists(id))
            {
                return NotFound();
            }

            var item = ToDomainModel(inputItem);
            _repo.UpdateAgendamento(item);

            return NoContent(); //204
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_repo.AgendamentoExists(id))
            {
                return NotFound();
            }
            _repo.DeleteAgendamento(id);

            return NoContent();
        }


        //////////////////////////////////////////
        private static Agendamento ToModel(this Agendamento agend)
        {
            return new Agendamento
            {
                IdAgendamento = agend.IdAgendamento,
                TipoAgendamento = agend.TipoAgendamento,
                Prontuario = agend.Prontuario,
                Especialidade = agend.Especialidade,
                Exame = agend.Exame,
                DataAgendamento = agend.DataAgendamento,
            };
        }
        private AgendOutputModel ToOutputModel(Agendamento model)
        {
            return new AgendOutputModel
            {
                IdAgendamento = model.IdAgendamento,
                TipoAgendamento = model.TipoAgendamento,
                Prontuario = model.Prontuario,
                Especialidade = model.Especialidade,
                Exame = model.Exame,
                DataAgendamento = model.DataAgendamento,
                UltimoAcesso = DateTime.Now
            };
        }

        private List<AgendOutputModel> ToOutputModel(List<Agendamento> model)
        {
            return model.Select(item => ToOutputModel(item)).ToList();
        }

        private AgendInputModel ToInputModel(Agendamento model)
        {
            return new AgendInputModel
            {
                IdAgendamento = model.IdAgendamento,
                TipoAgendamento = model.TipoAgendamento,
                Prontuario = model.Prontuario,
                Especialidade = model.Especialidade,
                Exame = model.Exame,
                DataAgendamento = model.DataAgendamento,
            };
        }
        private Agendamento ToDomainModel(AgendInputModel inputModel)
        {
            return new Agendamento
            {
                IdAgendamento = inputModel.IdAgendamento,
                TipoAgendamento = inputModel.TipoAgendamento,
                Prontuario = inputModel.Prontuario,
                Especialidade = inputModel.Especialidade,
                Exame = inputModel.Exame,
                DataAgendamento = inputModel.DataAgendamento,
            };
        }
    }
}
