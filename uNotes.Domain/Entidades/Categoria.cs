namespace uNotes.Domain.Entidades
{
    public class Categoria : EntidadeBase
    {
        protected Categoria() { }
        public Categoria(string titulo, int categoriaPai,List<Documento>? documentos)
        {
            Titulo = titulo;
            CategoriaPai = categoriaPai;
            Documentos = documentos;
        }

        public string Titulo { get; set; }
        public int CategoriaPai { get; set; }
        public List<Documento>? Documentos { get; set; }

        public void Atualizar(Categoria newCategoria)
        {
            Titulo = newCategoria.Titulo;
            CategoriaPai = newCategoria.CategoriaPai;
            Documentos = newCategoria.Documentos;
        }
    }
}
