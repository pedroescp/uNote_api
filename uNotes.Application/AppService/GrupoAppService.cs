using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Grupo;
using uNotes.Application.Requests.Usuario;
using uNotes.Application.Responses.Grupo;
using uNotes.Application.Responses.Usuario;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.UoW;

namespace uNotes.Application.AppService
{
    public class GrupoAppService : IGrupoAppService
    {
        private readonly IGrupoService _grupoService;
        private readonly IUsuarioGrupoService _usuarioGrupoService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GrupoAppService(IGrupoService grupoService, IUnitOfWork unitOfWork, IMapper mapper, IUsuarioGrupoService usuarioGrupoService)
        {
            _grupoService = grupoService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _usuarioGrupoService = usuarioGrupoService;
        }

        public GrupoAdicionarRequest Adicionar(GrupoAdicionarRequest user)
        {
            _grupoService.Adicionar(_mapper.Map<Grupo>(user));
            _unitOfWork.Commit();
            return user;
        }
        public string Atualizar(GrupoAtualizarRequest user)
        {
            _grupoService.AtualizarGrupo(_mapper.Map<Grupo>(user));
            _unitOfWork.Commit();
            return "Usuário Atualizado com Sucesso";
        }
        public GrupoObterResponse ObterPorId(Guid id)
        {
            return _mapper.Map<GrupoObterResponse>(_grupoService.ObterPorId(id));
        }
        public IEnumerable<GrupoObterResponse> ObterGrupos()
        {
            return _mapper.Map<IEnumerable<GrupoObterResponse>>(_grupoService.ObterGrupos());
        }
        public void Remover(Guid id)
        {
            _grupoService.Remover(id);
            _unitOfWork.Commit();
        }

        public string VincularUsuario(VincularUsuarioRequest vincularUsuario)
        {
            _usuarioGrupoService.Adicionar(_mapper.Map<UsuarioGrupo>(vincularUsuario));
            _unitOfWork.Commit();
            return "Usuario vinculado com sucesso";

        }
    }
}
