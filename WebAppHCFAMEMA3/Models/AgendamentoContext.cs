using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace WebAppHCFAMEMA3.Models
{
        public class AgendamentoContext : DbContext
        {
            public AgendamentoContext(DbContextOptions<AgendamentoContext> options)
                : base(options)
            { }
            public DbSet<Agendamento> AgendamentoItens { get; set; }
        }
    
}
