using System.Collections.Generic;
using System.Linq;
using WebAppHCFAMEMA3.Models;
using System;
using WebAppHCFAMEMA3.Services;

namespace WebAppHCFAMEMA3.AgendamentoService
{
    public class AgendamentoRepository : IRepository
    {
        private readonly List<Agendamento> agendamentos;

        public AgendamentoRepository()
        {
            this.agendamentos = new List<Agendamento>
            {
                new Agendamento{IdAgendamento= 1, TipoAgendamento= "Retorno", Prontuario= 6565 , Especialidade= "Ortopedia e Tralmologia", Exame="Raio - x" , DataAgendamento= "22/12/2019" , Recomendações= "Favor entrar em jejum absoluto à partir das 00:00, para realização do exame." },
                new Agendamento{IdAgendamento= 2, TipoAgendamento= "Atendimento", Prontuario= 5555 , Especialidade= "Cabeça e Pescoço", Exame="Tomografia" , DataAgendamento= "22/12/2019" , Recomendações= "Favor entrar em jejum absoluto à partir das 00:00, para realização do exame." },
                new Agendamento{IdAgendamento= 3, TipoAgendamento= "Atendimento", Prontuario= 8888 , Especialidade= "Oftalmo", Exame="Oftalmologia" , DataAgendamento= "22/12/2019" , Recomendações= "Favor entrar em jejum absoluto à partir das 00:00, para realização do exame." },
                new Agendamento{IdAgendamento= 4, TipoAgendamento= "Retorno", Prontuario= 9999 , Especialidade= "Ortopedia e Tralmologia", Exame="Audiometria vocal" , DataAgendamento= "22/12/2019" , Recomendações= "Favor entrar em jejum absoluto à partir das 00:00, para realização do exame." }};
        }

        public void AddAgendamento(Agendamento item)
        {
            this.agendamentos.Add(item);
        }

        public bool AgendamentoExists(int id)
        {
            return agendamentos.Any(m => m.IdAgendamento == id);
        }

        public void DeleteAgendamento(int id)
        {
            var model = this.agendamentos.Where(m => m.IdAgendamento == id).FirstOrDefault();
            this.agendamentos.Remove(model);
        }

        public Agendamento GetAgendamento(int id)
        {
            return agendamentos.Where(m => m.IdAgendamento == id).FirstOrDefault();
        }

        public List<Agendamento> GetAgendamentos()
        {
            return this.agendamentos.ToList();
        }

        public void UpdateAgendamento(Agendamento item)
        {
            var model = this.agendamentos.Where(m => m.IdAgendamento == item.IdAgendamento).FirstOrDefault();

            model.IdAgendamento = item.IdAgendamento;
            model.TipoAgendamento = item.TipoAgendamento;
            model.Prontuario = item.Prontuario;
            model.Especialidade = item.Especialidade;
            model.Exame = item.Exame;
            model.DataAgendamento = item.DataAgendamento;
            model.Recomendações = item.Recomendações;
        }
    }
}
