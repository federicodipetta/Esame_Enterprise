using Libri_application.App.Abstractions.Services;
using Libri_application.App.Extension;
using Libri_application.App.Factorys;
using Libri_application.App.Options;
using Libri_application.App.Services;
using Libri_application.LibriService.models;
using Libri_application.Models.Context;
using Libri_application.Models.Extension;
using Libri_application.Models.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Text;

namespace Libri_application.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddModelService(builder.Configuration)
                .AddApplicationService(builder.Configuration);
            
            var app = builder.Build();

            app.AddAppMiddleware();

            app.Run();
        }
    }
}
