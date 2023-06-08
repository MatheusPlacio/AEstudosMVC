using Data.Mapping;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MyContext : IdentityDbContext<Usuario, Funcao, string>
    {
        public DbSet<Aluguel> Alugueis { get; set; }
        public DbSet<Apartamento> Apartamentos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }
        public DbSet<HistoricoRecurso> HistoricoRecursos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<ServicoPredio> ServicoPredios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AluguelMap());
            modelBuilder.ApplyConfiguration(new ApartamentoMapping());
            modelBuilder.ApplyConfiguration(new EventoMapping());
            modelBuilder.ApplyConfiguration(new FuncaoMapping());
            modelBuilder.ApplyConfiguration(new HistoricoRecursoMapping());
            modelBuilder.ApplyConfiguration(new MesMapping());
            modelBuilder.ApplyConfiguration(new ServicoMapping());
            modelBuilder.ApplyConfiguration(new ServicoPredioMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new VeiculosMapping());
        }
    }
}
