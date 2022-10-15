using AutoMapper;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Usuario;
using uNotes.Application.Responses.Usuario;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.Criptografia;
using uNotes.Infra.CrossCutting.Enums;
using uNotes.Infra.CrossCutting.Notificacoes;
using uNotes.Infra.CrossCutting.UoW;

namespace uNotes.Application.AppService
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;
        private readonly IAutenticacaoService _autenticacaoService;

        public UsuarioAppService(IUsuarioService userService, 
                                 IUnitOfWork unitOfWork, 
                                 IMapper mapper, 
                                 INotificador notificador,
                                 IAutenticacaoService autenticacaoService)
        {
            _usuarioService = userService;
            _notificador = notificador;
            _autenticacaoService = autenticacaoService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public UsuarioAdicionarRequest Adicionar(UsuarioAdicionarRequest user)
        {
            _usuarioService.AdicionarUsuario(_mapper.Map<Usuario>(user));
            _unitOfWork.Commit();
            return user; 
        }

        public LoginObterResponse? Autenticar(string emailLogin, string senha)
        {
            var usuario = _usuarioService.ObterUsuarioPorLoginOuEmail(emailLogin);
            if (usuario is null)
            {
                _notificador.AdicionarNotificacao("Usuário e/ou senha inválidos");
                return null;
            }
            if (usuario.Senha != Criptografia.Encrypt(senha, TipoCriptografia.SenhaLogin))
            {
                _notificador.AdicionarNotificacao("Usuário e/ou senha inválidos");
                return null;
            }
            if (usuario.DataExclusao.HasValue)
            {
                _notificador.AdicionarNotificacao("Usuário excluido");
                return null;
            }

            var token = _autenticacaoService.GerarTokenClaims(usuario.Email);
            if (token == null)
            {
                _notificador.AdicionarNotificacao("Não foi possivel criar token");
                return null;
            }

            return new LoginObterResponse
            {
                Token = token,
                Nome = usuario.Nome,
                Login = usuario.Login,
                Email = usuario.Email,
                CargoId = usuario.CargoId
            };
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
