using System.Collections.Generic;
using WebAppHCFAMEMA3.Models;

namespace WebAppHCFAMEMA3.Services
{
    public interface IRepository
    {
        List<Agendamento> GetAgendamentos();
        Agendamento GetAgendamento(int id);
        void AddAgendamento(Agendamento item);
        void UpdateAgendamento(Agendamento item);
        void DeleteAgendamento(int id);
        bool AgendamentoExists(int id);
    }
}