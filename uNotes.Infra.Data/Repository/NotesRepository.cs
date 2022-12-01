using uNotes.Domain.Entidades;
using uNotes.Domain.Enumerators;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Infra.Data.Contexto;

namespace uNotes.Infra.Data.Repository
{
    public class NotesRepository : Repository<Notes>, INotesRepository
    {
        public NotesRepository(uNotesContext context) : base(context)
        {
        }

        public IEnumerable<Notes> ObterPorUsuarioTodos(Guid usuarioId)
        {
            return DbSet.Where(x => x.CriadorId == usuarioId 
                                    && x.DataExclusao == null 
                                    && (x.Status == StatusNota.Fixado || x.Status == StatusNota.Ativo))
                        .OrderBy(x => x.DataAtualizacao)
                        .ThenBy(x => x.Status);
        }

        public IEnumerable<Notes> ObterPorUsuarioArquivado(Guid usuarioId)
        {
            return DbSet.Where(x => x.CriadorId == usuarioId
                                    && x.DataExclusao == null
                                    && x.Status == StatusNota.Arquivada)
                        .OrderBy(x => x.DataAtualizacao)
                        .ThenBy(x => x.Status);
        }

        public IEnumerable<Notes> ObterPorUsuarioLixeira(Guid usuarioId)
        {
            return DbSet.Where(x => x.CriadorId == usuarioId
                                    && x.Status == StatusNota.Lixeira)
                        .OrderBy(x => x.DataAtualizacao)
                        .ThenBy(x => x.Status);
        }

    }
}
