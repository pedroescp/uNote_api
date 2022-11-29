using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PL.Application.AutoMapper;
using uNotes.Application.AppService;
using uNotes.Application.AppService.Interface;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.AWS;
using uNotes.Infra.CrossCutting.AWS.Interfaces;
using uNotes.Infra.CrossCutting.Notificacoes;
using uNotes.Infra.CrossCutting.UoW;
using uNotes.Infra.CrossCutting.WebSocketService;
using uNotes.Infra.Data.Contexto;
using uNotes.Infra.Data.Repository;

namespace uNotes.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ConfiguracoesSeed>();

            services.AddScoped<INotificador, Notificador>();

            #region REPOSITORIES
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<IGrupoRepository, GrupoRepository>();
            services.AddScoped<IUsuarioGrupoRepository, UsuarioGrupoRepository>();
            services.AddScoped<INotesRepository, NotesRepository>();
            services.AddScoped<IColaboradoresRepository, ColaboradoresRepository>();
            services.AddScoped<IDocumentoRepository, DocumentoRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagsNotasRepository, TagsNotasRepository>();
            #endregion

            #region SERVICES
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ICargoService, CargoService>();
            services.AddScoped<IAutenticacaoService, AutenticacaoService>();
            services.AddScoped<IGrupoService, GrupoService>();
            services.AddScoped<IUsuarioGrupoService, UsuarioGrupoService>();
            services.AddScoped<INotesService, NotesService>();
            services.AddScoped<IColaboradoresService, ColaboradoresService>();
            services.AddScoped<IDocumentoService, DocumentoService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ITagsNotasService, TagsNotasService>();
            services.AddScoped<IWebSocketCalls, WebSocketCalls>();
            services.AddScoped<IAWSS3Service, AWSS3Service>();
            #endregion

            #region APPSERVICES
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<ICargoAppService, CargoAppService>();
            services.AddScoped<IGrupoAppService, GrupoAppService>();
            services.AddScoped<INotesAppService, NotesAppService>();
            services.AddScoped<IColaboradoresAppService, ColaboradoresAppService>();
            services.AddScoped<IDocumentoAppService, DocumentoAppService>();
            services.AddScoped<ITagAppService, TagAppService>();
            services.AddScoped<ITagsNotasAppService, TagsNotasAppService>();

            #endregion

            services.AddDbContext<uNotesContext>(options => options.UseNpgsql(connectionString, o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
            new AutoMapperConfig(services);
        }
    }
}
