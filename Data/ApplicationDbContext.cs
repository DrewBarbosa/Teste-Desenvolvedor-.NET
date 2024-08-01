using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste_Desenvolvedor_.NET.Models;

namespace Teste_Desenvolvedor_.NET.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ProcessoSeletivo> ProcessoSeletivo { get; set; }
        public DbSet<Lead> Candidato { get; set; }
        public DbSet<Oferta> Curso { get; set; }
        public DbSet<Inscricao> Inscricao { get; set; }

    }
}