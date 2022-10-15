namespace uNotes.Domain.Entidades
{
    internal class Notes : EntidadeBase
    {
        public string Titulo { get; set; }
        public string Texto { get; set; }

        public string CriadorId { get; set; }

        public string Lixeira { get; set; }
        public string Fixado  { get; set; }

    }
}
