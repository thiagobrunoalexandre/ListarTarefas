using Tarefas.Data.Map;
using Tarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace Tarefas.Data
{
    public class TarefasDBContex : DbContext
    {
        public TarefasDBContex(DbContextOptions<TarefasDBContex> options)
            : base(options)
        {
        }
        public DbSet<TarefaModels> tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
