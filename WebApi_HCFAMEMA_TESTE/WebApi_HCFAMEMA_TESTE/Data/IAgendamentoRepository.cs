using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_HCFAMEMA_TESTE.Models;

namespace WebApi_HCFAMEMA_TESTE.Data
{
    public interface IAgendamentoRepository
    {
        IEnumerable<Agendamento> GetAgendamentos();
        Agendamento GetAgendamento(int id);
        Agendamento AddAgendamento(Agendamento item);
        void RemoveAgendamento(int id);
        bool UpdateAgendamento(Agendamento item);

    }
}
