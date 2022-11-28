﻿using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Repository
{
    public interface INotesRepository : IRepository<Notes>
    {
        IEnumerable<Notes> ObterPorUsuario(Guid usuarioId);
    }
}
