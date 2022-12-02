# uNotes

- Para criar as tabelas no banco, coloque sua senha do Postgres na connectionString em AppSettings.Development e inicie o projeto

Here its the database tables
**database:** 
 - Usuario
   - Id
   - Nickname
   - Login
   - Senha
   - Email
   - Avatar
   - Telefone
   - CargoId
   - DataInclusao
   - UsuarioPaiId
  
 - Cargo
   - Id
   - Nome
   - Descricao
  
 - Grupo
   - Id
   - Nome
  
 - UsuarioGrupo
   - Id
   - UsuarioId
   - GrupoId
   - DataInclusao
   - DataExclusao
  
 - Notes
   - Id
   - Titulo
   - Texto 10000
   - CriadorId
   - Estado: Enum
   - DataInclusao
   - DataAtualizacao
   - DataExclusão
   - UsuarioAtualizacaoId
   - DocumentoId
   
 - Tags
   - Id
   - UsuarioId
   - Nome
   
 - TagsNotas
   - Id
   - NotaId
   - TagId
  
 - Colaboradores
   - Id
   - UsuarioId
   - NotaId
   - DocumentoId
   - Status [Pendente, Aceito, Negado]
  
 - Documento
   - Id
   - Titulo
   - Texto 50000
   - CriadorId
   - Lixeira bit
   - DataInclusao
   - DataAtualizacao
   - UsuarioAtualizacaoId
