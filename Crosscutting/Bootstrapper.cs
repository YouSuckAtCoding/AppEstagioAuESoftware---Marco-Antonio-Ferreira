using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Data;
using Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Interfaces.Services;
using Services.Services;


namespace Crosscutting
{
    public static class Bootstrapper
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<AppEstagioAuESoftwareContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AppEstagioAuESoftwareContext")));

            services.AddTransient<IUsuarioService,   UsuarioService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IRegistrodeCidadesService, RegistrodeCidadesService>();
            services.AddTransient<IRegistrodeCidadeRepository, RegistrodeCidadesRepository>();
        }

    }
}
