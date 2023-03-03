using uNotes.Domain.Services;

namespace uNotes.Domain.Entidades
{
    public class Grupo : EntidadeBase
    {
        public string Nome { get; set; }
        public IEnumerable<UsuarioGrupo> Vinculos { get; set; }
        public void Atualizar(Grupo grupo)
        {
            Nome = grupo.Nome;
        }
        
    }
}
