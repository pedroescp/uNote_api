using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Service
{
    public interface IUsuarioService : IService<Usuario>
    {
        void AtualizarUsuario(Usuario usuario);
    }
}
