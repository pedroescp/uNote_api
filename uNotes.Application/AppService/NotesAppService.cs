using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Notes;
using uNotes.Application.Responses.Notes;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.UoW;

namespace uNotes.Application.AppService
{
    public class NotesAppService : BaseAppService, INotesAppService
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

        public NotesAdicionarRequest Adicionar(NotesAdicionarRequest user, string token)
        {
            var usuarioId = ObterInformacoesToken(token);
            user.CriadorId = Guid.Parse(usuarioId);
            user.UsuarioAtualizacaoId = Guid.Parse(usuarioId);
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

        public IEnumerable<NotesObterResponse> ObterPorUsuario(Guid usuarioId)
        {
            return _mapper.Map<IEnumerable<NotesObterResponse>>(_notesService.ObterPorUsuario(usuarioId));
        }

        public string RemoverLogica(Guid id)
        {
            string removerMensagem = _notesService.RemoverLogica(id);
            _unitOfWork.Commit();
            return removerMensagem;
        }

        public IEnumerable<Notes> ObterPorUsuarioLixeira(Guid usuarioId)
        {
            return _notesService.ObterPorUsuarioLixeira(usuarioId);
        }

        public IEnumerable<Notes> ObterPorUsuarioArquivado(Guid usuarioId)
        {
            return _notesService.ObterPorUsuarioArquivado(usuarioId);
        }
    }
}
