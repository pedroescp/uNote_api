using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Infra.Data.Contexto;

namespace uNotes.Infra.Data.Repository
{
    public class GrupoRepository : Repository<Grupo>, IGrupoRepository
    {
        public GrupoRepository(uNotesContext context) : base(context)
        {

        }
        public IEnumerable<Grupo> ObterGrupos()
        {
            return DbSet.Include(x => x.Vinculos).ThenInclude(x => x.Usuario);
        }
    }
}
