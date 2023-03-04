using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using uNotaDocumento.Application.AppService.Interface;
using uNotes.Application.Requests.Cargo;
using uNotes.Application.Requests.Categorias;
using uNotes.Application.Requests.Documentos;
using uNotes.Application.Requests.Grupo;
using uNotes.Application.Requests.NotaDocumentos;
using uNotes.Application.Requests.Notes;
using uNotes.Application.Requests.Tag;
using uNotes.Application.Requests.TagsNotas;
using uNotes.Application.Requests.Usuario;
using uNotes.Application.Responses.Cargo;
using uNotes.Application.Responses.Categorias;
using uNotes.Application.Responses.Documentos;
using uNotes.Application.Responses.Grupo;
using uNotes.Application.Responses.Notes;
using uNotes.Application.Responses.Tag;
using uNotes.Application.Responses.TagsNotas;
using uNotes.Application.Responses.Usuario;
using uNotes.Domain.Entidades;

namespace PL.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public AutoMapperConfig(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                //Requests--
                //Usuario
                config.CreateMap<UsuarioAdicionarRequest, Usuario>().ReverseMap();
                config.CreateMap<UsuarioAtualizarRequest, Usuario>().ReverseMap();

                //Cargo
                config.CreateMap<CargoAdicionarRequest, Cargo>().ReverseMap();
                config.CreateMap<CargoAtualizarRequest, Cargo>().ReverseMap();

                // Grupo
                config.CreateMap<GrupoAdicionarRequest, Grupo>().ReverseMap();
                config.CreateMap<GrupoAtualizarRequest, Grupo>().ReverseMap();

                // UsuarioGrupo
                config.CreateMap<VincularUsuarioRequest, UsuarioGrupo>().ReverseMap();

                // Notes
                config.CreateMap<NotesAdicionarRequest, Notes>().ReverseMap();
                config.CreateMap<NotesAtualizarRequest, Notes>().ReverseMap();

                //NotaDocumento
                config.CreateMap<NotaDocumentoAdicionarRequest, NotaDocumento>().ReverseMap();
                config.CreateMap<NotaDocumentoAtualizarRequest, NotaDocumento>().ReverseMap();

                // Documentos
                config.CreateMap<DocumentoAdicionarRequest, Documento>().ReverseMap();
                config.CreateMap<DocumentoAtualizarRequest, Documento>().ReverseMap();

                //Categorias
                config.CreateMap<CategoriaAdicionarRequest, Categoria>().ReverseMap();
                config.CreateMap<CategoriaAtualizarRequest, Categoria>().ReverseMap();

                //Tag
                config.CreateMap<TagAdicionarRequest, Tag>().ReverseMap();
                config.CreateMap<TagAtualizarRequest, Tag>().ReverseMap();

                //TagsNotas
                config.CreateMap<TagsNotasAdicionarRequest, TagsNotas>().ReverseMap();
                config.CreateMap<TagsNotasAtualizarRequest, TagsNotas>().ReverseMap();

                //Responses----------------------------------------------------------

                //Usuario
                config.CreateMap<UsuarioObterResponse, Usuario>().ReverseMap();

                //Cargo
                config.CreateMap<CargoObterResponse, Cargo>().ReverseMap();

                //Categorias
                config.CreateMap<CategoriaObterResponse, Categoria>().ReverseMap();

                // Grupo
                config.CreateMap<GrupoObterResponse, Grupo>().ReverseMap()
                    .ForMember(x => x.Usuarios, c => c.MapFrom(a => a.Vinculos));

                // UsuarioGrupo
                config.CreateMap<UsuarioGrupoResponse, UsuarioGrupo>().ReverseMap()
                    .ForMember(x => x.Nome, c => c.MapFrom(a => a.Usuario.Nome));

                // Notes 
                config.CreateMap<NotesObterResponse, Notes>().ReverseMap();

                //NotaDocumento
                config.CreateMap<NotaDocumentoObterResponse, NotaDocumento>().ReverseMap();

                //Documento
                config.CreateMap<DocumentoObterResponse, Documento>().ReverseMap();

                // Tag
                config.CreateMap<TagObterResponse, Tag>().ReverseMap();

                //TagsNotas
                config.CreateMap<TagsNotasObterResponse, TagsNotas>().ReverseMap();
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
