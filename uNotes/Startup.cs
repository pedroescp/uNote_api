using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using uNotes.Api.Configuration;
using uNotes.Infra.CrossCutting.Constantes;
using uNotes.Infra.CrossCutting.IoC;
using uNotes.Infra.Data.Contexto;

namespace uNotes.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.RegisterServices(Configuration.GetConnectionString("DefaultConnection"));
            services.AddControllers();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "uNotes.Api.Security.Bearer",
                    ValidAudience = "uNotes.Api.Security.Bearer",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(ConstantesSistema.Seguranca.SymmetricSecurityKey))
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        return Task.CompletedTask;
                    }
                };
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api - uNotes", Version = "v1" });
            });

            services.AddCors();
            services.AddSwaggerConfig();

        }

        public void Configure(IApplicationBuilder app, ConfiguracoesSeed configSeed,IWebHostEnvironment env)
        {
            try
            {
                configSeed.SeedData().Wait();
            }
            catch (Exception)
            {

                throw;
            }
            
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api - uNotes v1");
                });
            }
            app.UseCors(x => x
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin());

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowSpecificOrigin");

            app.UseAuthentication();

            app.UseAuthorization();

            var websocketOptions = new WebSocketOptions
            {
                KeepAliveInterval = TimeSpan.FromMinutes(1)
            };

            app.UseWebSockets(websocketOptions);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
