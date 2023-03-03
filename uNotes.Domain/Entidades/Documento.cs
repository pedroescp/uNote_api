﻿namespace uNotes.Domain.Entidades
{
    public class Documento : EntidadeBase
    {
        protected Documento()
        {

        }
        public string Titulo { get; set; }
        public string? Texto { get; set; }
        public Guid CriadorId { get; set; }
        public bool Lixeira { get; set; }
        public Guid UsuarioAtualizacaoId { get; set; }
        public Guid? CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }

        public void Atualizar(Documento novoDocumento)
        {
            Titulo = novoDocumento.Titulo;
            Texto = novoDocumento.Texto;
        }
    }
}
