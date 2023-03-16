using Newtonsoft.Json;

namespace uNotes.Application.Requests.Categorias
{
    public class CategoriaAdicionarRequest
    {
        public string Titulo { get; set; }
        public int CategoriaPai { get; set; }

        [JsonIgnore]
        public Guid CriadorId { get; set; }
    }
}
