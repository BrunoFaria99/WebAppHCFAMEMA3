using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppHCFAMEMA3.Models
{
    public class AgendOutputModel
    {
        public int IdAgendamento { get; set; }
        public string TipoAgendamento { get; set; }
        public int Prontuario { get; set; }
        public string Especialidade { get; set; }
        public string Exame { get; set; }
        public string DataAgendamento { get; set; }
        public string Recomendações { get; set; }
        public DateTime UltimoAcesso { get; set; }
    }
}
