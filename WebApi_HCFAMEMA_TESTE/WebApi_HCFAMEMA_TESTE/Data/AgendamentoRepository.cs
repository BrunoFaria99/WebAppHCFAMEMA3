using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_HCFAMEMA_TESTE.Models;
using WebApi_HCFAMEMA_TESTE.Data;

namespace WebApi_HCFAMEMA_TESTE.Data
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private List<Agendamento> agendamentos = new List<Agendamento>();
        private int _nextId = 11;
        public AgendamentoRepository()
        {
          agendamentos.Add(new Agendamento { IdAgendamento = 1, TipoAgendamento = "Retorno", Prontuario = 6565, Especialidade = "Ortopedia e Tralmologia", Exame = "Raio - x", DataAgendamento = "22/12/2019", Recomendações = "Favor entrar em jejum absoluto à partir das 00:00, para realização do exame." });
          agendamentos.Add(new Agendamento { IdAgendamento = 2, TipoAgendamento = "Atendimento", Prontuario = 5555, Especialidade = "Cabeça e Pescoço", Exame = "Tomografia", DataAgendamento = "22/12/2019", Recomendações = "Favor entrar em jejum absoluto à partir das 00:00, para realização do exame." });
          agendamentos.Add(new Agendamento { IdAgendamento = 3, TipoAgendamento = "Atendimento", Prontuario = 8888, Especialidade = "Oftalmo", Exame = "Oftalmologia", DataAgendamento = "22/12/2019", Recomendações = "Favor entrar em jejum absoluto à partir das 00:00, para realização do exame." });
          agendamentos.Add(new Agendamento { IdAgendamento = 4, TipoAgendamento = "Retorno", Prontuario = 9999, Especialidade = "Ortopedia e Tralmologia", Exame = "Audiometria vocal", DataAgendamento = "22/12/2019", Recomendações = "Favor entrar em jejum absoluto à partir das 00:00, para realização do exame." });
            
        }

        public Agendamento AddAgendamento(Agendamento item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.IdAgendamento = _nextId++;
            agendamentos.Add(item);
            return item;
        }

        public Agendamento GetAgendamento(int id)
        {
            return agendamentos.Find(p => p.IdAgendamento == id);
        }

        public IEnumerable<Agendamento> GetAgendamentos()
        {
            return agendamentos;
        }

        public void RemoveAgendamento(int id)
        {
            agendamentos.RemoveAll(p => p.IdAgendamento == id);
        }

        public bool UpdateAgendamento(Agendamento item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = agendamentos.FindIndex(p => p.IdAgendamento == item.IdAgendamento);

            if (index == -1)
            {
                return false;
            }
            agendamentos.RemoveAt(index);
            agendamentos.Add(item);
            return true;
        }
    }
}
