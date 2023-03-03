﻿using uNotes.Application.Requests.Categorias;
using uNotes.Application.Responses.Categorias;

namespace uNotes.Application.AppService.Interface
{
    public interface ICategoriaAppService
    {
        CategoriaAdicionarRequest Adicionar(CategoriaAdicionarRequest categoria);
        string Atualizar(CategoriaAtualizarRequest categoria);
        void Remover(Guid id);
        IEnumerable<CategoriaObterResponse> ObterTodos();
        CategoriaObterResponse ObterPorId(Guid id);
    }
}