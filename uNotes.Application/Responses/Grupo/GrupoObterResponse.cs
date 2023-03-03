namespace uNotes.Application.Responses.Grupo
{
    public class GrupoObterResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<UsuarioGrupoResponse> Usuarios { get; set; }
    }
}
