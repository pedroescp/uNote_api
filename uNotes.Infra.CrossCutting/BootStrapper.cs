using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PL.Application.AutoMapper;
using uNotes.Application.AppService;
using uNotes.Application.AppService.Interface;
using uNotes.Domain.Services;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.Notificacoes;
using uNotes.Infra.CrossCutting.UoW;
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

            services.AddScoped<INotificador, Notificador>();

            #region REPOSITORIES
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICargoRepository, CargoRepository>();
            #endregion

            #region SERVICES
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ICargoService, CargoService>();
            #endregion

            #region APPSERVICES
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<ICargoAppService, CargoAppService>();
            #endregion

            services.AddDbContext<uNotesContext>(options => options.UseNpgsql(connectionString, o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
            new AutoMapperConfig(services);
        }
    }
}
