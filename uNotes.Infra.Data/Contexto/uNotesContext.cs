using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using uNotes.Domain.Entidades;
using uNotes.Infra.Data.Mappings;

namespace uNotes.Infra.Data.Contexto
{
    public class uNotesContext : DbContext
    {

        public uNotesContext(DbContextOptions<uNotesContext> options) : base(options)
        {
        }

        public uNotesContext(DbContextOptions<uNotesContext> options, IHttpContextAccessor httpContextAccessor) :
           this(options)
        {
        }

        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Cargo>? Cargos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Grupo>? Grupos { get; set; }
        public DbSet<UsuarioGrupo>? UsuariosGrupos {get; set;}
        public DbSet<Notes>? Notes { get; set; }
        public DbSet<Colaboradores>? Colaboradores { get; set; }
        public DbSet<Documento>? Documentos { get; set; }
        public DbSet<Tag>? Tags { get; set; }
        public DbSet<TagsNotas>? TagsNotas { get; set; }
        public DbSet<NotaDocumento> NotasDocumento { get; set; }
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
