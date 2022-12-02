﻿using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotes.Domain.Services
{
    public class NotesService : Service<Notes>, INotesService
    {
        private readonly INotesRepository _notesRepository;
        private readonly INotificador _notificador;
        public NotesService(INotesRepository repository, INotificador notificador) : base(repository)
        {
            _notesRepository = repository;
            _notificador = notificador;
        }

        public void AtualizarNotes(Notes notes)
        {
            var antigoNotes = _notesRepository.ObterPorId(notes.Id);
            antigoNotes.Atualizar(notes);
            return;
        }

        public IEnumerable<Notes> ObterPorUsuario(Guid usuarioId)
        {
            return _notesRepository.ObterPorUsuarioTodos(usuarioId);
        }

        public IEnumerable<Notes> ObterPorUsuarioArquivado(Guid usuarioId)
        {
            return _notesRepository.ObterPorUsuarioArquivado(usuarioId);
        }

        public IEnumerable<Notes> ObterPorUsuarioLixeira(Guid usuarioId)
        {
            return _notesRepository.ObterPorUsuarioLixeira(usuarioId);
        }

        public string RemoverLogica(Guid notaId)
        {
            var nota = _notesRepository.ObterPorId(notaId);
            if (nota == null)
                return "Nota não encontrada";
            nota.RemoverLogica();
            return "Nota removida com sucesso";
        }

        public void ArquivarLogica(Guid notaId)
        {
            var nota = _notesRepository.ObterPorId(notaId);
            if (nota == null)
            {
                _notificador.AdicionarNotificacao("Nota não encontrada");
                return;
            }
            nota.ArquivarLogica();
        }
    }
}

