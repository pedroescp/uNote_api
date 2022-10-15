using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using uNotes.Application.Requests.Cargo;
using uNotes.Application.Requests.Grupo;
using uNotes.Application.Requests.Usuario;
using uNotes.Application.Responses.Cargo;
using uNotes.Application.Responses.Grupo;
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

                

                //Responses--
                //Usuario
                config.CreateMap<UsuarioObterResponse, Usuario>().ReverseMap();

                //Cargo
                config.CreateMap<CargoObterResponse, Cargo>().ReverseMap();

                // Grupo
                config.CreateMap<GrupoObterResponse, Grupo>().ReverseMap()
                    .ForMember(x => x.Usuarios, c => c.MapFrom(a => a.Vinculos));

                // UsuarioGrupo
                config.CreateMap<UsuarioGrupoResponse, UsuarioGrupo>().ReverseMap()
                    .ForMember(x => x.Nome, c => c.MapFrom(a => a.Usuario.Nome));


            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
