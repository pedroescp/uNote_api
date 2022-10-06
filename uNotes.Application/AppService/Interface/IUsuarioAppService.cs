﻿using uNotes.Application.Requests.Usuario;
using uNotes.Application.Responses.Usuario;

namespace uNotes.Application.AppService.Interface
{
    public interface IUsuarioAppService
    {
        UsuarioAdicionarRequest Adicionar(UsuarioAdicionarRequest user);
        string Atualizar(UsuarioAtualizarRequest user);
        void Remover(Guid id);
        IEnumerable<UsuarioObterResponse> ObterTodos();
        UsuarioObterResponse ObterPorId(Guid id);
    }
}