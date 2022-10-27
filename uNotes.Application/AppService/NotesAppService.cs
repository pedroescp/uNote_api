using AutoMapper;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Notes;
using uNotes.Application.Responses.Notes;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.UoW;

namespace uNotes.Application.AppService
{
    public class NotesAppService : INotesAppService
    {
        private readonly INotesService _notesService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NotesAppService(INotesService notesService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _notesService = notesService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public NotesAdicionarRequest Adicionar(NotesAdicionarRequest user)
        {
            _notesService.Adicionar(_mapper.Map<Notes>(user));
            _unitOfWork.Commit();
            return user;
        }

        public string Atualizar(NotesAtualizarRequest user)
        {
            _notesService.AtualizarNotes(_mapper.Map<Notes>(user));
            _unitOfWork.Commit();
            return "Notes Atualizado com Sucesso";
        }

        public NotesObterResponse ObterPorId(Guid id)
        {
            return _mapper.Map<NotesObterResponse>(_notesService.ObterPorId(id));
        }

        public IEnumerable<NotesObterResponse> ObterTodos()
        {
            return _mapper.Map<IEnumerable<NotesObterResponse>>(_notesService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _notesService.Remover(id);
            _unitOfWork.Commit();
        }
    }
}
