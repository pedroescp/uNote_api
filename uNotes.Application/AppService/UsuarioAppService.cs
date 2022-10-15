using AutoMapper;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Usuario;
using uNotes.Application.Responses.Usuario;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.UoW;

namespace uNotes.Application.AppService
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioAppService(IUsuarioService userService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _usuarioService = userService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public UsuarioAdicionarRequest Adicionar(UsuarioAdicionarRequest user)
        {
            _usuarioService.Adicionar(_mapper.Map<Usuario>(user));
            _unitOfWork.Commit();
            return user; 
        }

        public string Atualizar(UsuarioAtualizarRequest user)
        {
            _usuarioService.AtualizarUsuario(_mapper.Map<Usuario>(user));
            _unitOfWork.Commit();
            return "Usuário Atualizado com Sucesso";
        }

        public UsuarioObterResponse ObterPorId(Guid id)
        {
            return _mapper.Map<UsuarioObterResponse>(_usuarioService.ObterPorId(id));
        }

        public IEnumerable<UsuarioObterResponse> ObterTodos()
        {
            return _mapper.Map<IEnumerable<UsuarioObterResponse>>(_usuarioService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _usuarioService.Remover(id);
            _unitOfWork.Commit();
        }
    }
}
