using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using uNotes.Domain.Entidades;
using uNotes.Infra.Data.Mappings;

namespace uNotes.Infra.Data.Contexto
{
    public class uNotesContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public uNotesContext(DbContextOptions<uNotesContext> options) : base(options)
        {
        }

        public uNotesContext(DbContextOptions<uNotesContext> options, IHttpContextAccessor httpContextAccessor) :
           this(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public uNotesContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());


            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch { throw; }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
