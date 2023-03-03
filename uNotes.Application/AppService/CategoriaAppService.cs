using AutoMapper;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Categorias;
using uNotes.Application.Responses.Categorias;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.UoW;

namespace uNotes.Application.AppService
{
    public class CategoriaAppService : ICategoriaAppService
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaAppService(ICategoriaService categoriaService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _categoriaService = categoriaService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public CategoriaAdicionarRequest Adicionar(CategoriaAdicionarRequest categoria)
        {
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

        public void Remover(Guid id)
        {
            _categoriaService.Remover(id);
            _unitOfWork.Commit();
        }
    }
}
