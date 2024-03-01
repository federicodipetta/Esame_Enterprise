using Libri_application.Models.Context;
using Libri_application.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libri_application.Models.Extension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddModelService(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(conf => conf.UseSqlServer(configuration.GetConnectionString("MyDbContext")));
            services.AddScoped<LibroRepository>();
            services.AddScoped<RecensioneRepository>();
            services.AddScoped<CategoriaRepository>();
            services.AddScoped<UtenteRepository>();
            services.AddScoped<AutoreRepository>();
            return services;
        }
    }
}
