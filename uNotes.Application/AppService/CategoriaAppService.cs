using AutoMapper;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Categorias;
using uNotes.Application.Responses.Categorias;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.Notificacoes;
using uNotes.Infra.CrossCutting.UoW;

namespace uNotes.Application.AppService
{
    public class CategoriaAppService : BaseAppService, ICategoriaAppService
    {
        private readonly ICategoriaService _categoriaService;
        private readonly INotificador _notificador;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaAppService(ICategoriaService categoriaService, IUnitOfWork unitOfWork, IMapper mapper, INotificador notificador)
        {
            _categoriaService = categoriaService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _notificador = notificador;
        }

        public CategoriaAdicionarRequest Adicionar(CategoriaAdicionarRequest categoria, string token)
        {
            var usuarioId = ObterInformacoesToken(token[7..]);
            if (usuarioId == null || usuarioId == Guid.Empty)
            {
                _notificador.AdicionarNotificacao("Token inválido");
                return null;
            }
            categoria.CriadorId = usuarioId;
            _categoriaService.Adicionar(_mapper.Map<Categoria>(categoria));
            _unitOfWork.Commit();
            return categoria;
        }

        public string Atualizar(CategoriaAtualizarRequest categoria)
        {
            _categoriaService.AtualizarCategoria(_mapper.Map<Categoria>(categoria));
            _unitOfWork.Commit();
            return "Categoria Atualizada com Sucesso";
        }

        public CategoriaObterResponse ObterPorId(Guid id)
        {
            return _mapper.Map<CategoriaObterResponse>(_categoriaService.ObterPorId(id));
        }

        public IEnumerable<CategoriaObterResponse> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CategoriaObterResponse>>(_categoriaService.ObterTodos());
        }

        public List<CategoriaObterResponse> ObterCategoriasPorUsuario(Guid usuarioId)
        {
            var categoriasOrdenadas = new List<CategoriaObterResponse>();
            var categorias = _mapper.Map<List<CategoriaObterResponse>>(_categoriaService.ObterCategoriasPorUsuario(usuarioId))
                                                                                                               .OrderBy(x => x.CategoriaPai).ToList();
            
            foreach (var categoria in categorias)
            {
                if(categoria.CategoriaPai == null || categoria.CategoriaPai == Guid.Empty)
                {
                    categoriasOrdenadas.Add(categoria);
                    continue;
                }

                var sair = false;
                do
                {
                    var categoriaPai = ObterCategoriaPai(categoria);
                    categoriasOrdenadas.Add(categoriaPai);
                    if (categoriaPai.CategoriaPai == null || categoriaPai.CategoriaPai == Guid.Empty || categoriaPai == null)
                        sair = true;
                } while (sair == true);

            }

            return categorias;
        }

        private CategoriaObterResponse ObterCategoriaPai(CategoriaObterResponse categoria)
        {
            if (categoria.CategoriaPai == null || categoria.CategoriaPai == Guid.Empty)
            {
                return new CategoriaObterResponse
                {
                    Id = categoria.Id,
                    Titulo = categoria.Titulo,
                    CategoriaPai = categoria.CategoriaPai,
                    Documentos = categoria.Documentos
                };
            }

            var categoriaPai = _categoriaService.ObterPorCategoriaPai(categoria.CategoriaPai.Value);
            if (categoriaPai == null)
                return null;

            return new CategoriaObterResponse
            {
                Id = categoriaPai.Id,
                Titulo = categoriaPai.Titulo,
                CategoriaPai = categoriaPai.CategoriaPai
            };
        }

        public void Remover(Guid id)
        {
            _categoriaService.Remover(id);
            _unitOfWork.Commit();
        }
    }
}
