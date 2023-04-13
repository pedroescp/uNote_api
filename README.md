# uNotes

## Docker
- Dentro da pasta Docker crie uma pasta chamada "data"
  - Comando: mkdir data

- Depois crie um arquivo chamado ".env" com as seguintes variáveis:
  - MINIO_ROOT_USER=nomeusuario 
  - MINIO_ROOT_PASSWORD=senhausuario

- Com o Docker Desktop aberto use o comando:
  - docker-compose up -d

## Banco de dados

- Para criar as tabelas no banco, coloque sua senha do Postgres na connectionString em AppSettings.Development e inicie o projeto
