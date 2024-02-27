using Libri_application.App.Abstractions.Services;
using Libri_application.App.Factorys;
using Libri_application.App.Options;
using Libri_application.App.Services;
using Libri_application.LibriService.models;
using Libri_application.Models.Context;
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

            // Add services to the container.
            builder.Services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext"));
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "LibriApplication",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });
            builder.Services.AddControllers();
            //adding services
            builder.Services.AddScoped<ILibroService, Services.LibroService>();
            builder.Services.AddScoped<IRecensioneService, RecensioneService>();
            builder.Services.AddScoped<IAutenticazioneService, AutenticazioneService>();
            builder.Services.AddScoped<IUtenteService, UtenteService>();
           //repository
            builder.Services.AddScoped<LibroRepository>();
            builder.Services.AddScoped<RecensioneRepository>();
            builder.Services.AddScoped<UtenteRepository>();
            builder.Services.AddScoped<CategoriaRepository>();

            var jwt = new JwtOption();
            builder.Configuration.GetSection("JwtAuthentication")
            .Bind(jwt);

            builder.Services.Configure<JwtOption>(builder.Configuration.GetSection("JwtAuthentication"));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            // builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(options =>
             {
                 options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                 options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
             })
                .AddJwtBearer(options =>
                {
                    string key = jwt.Key;
                    var securityKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(key)
                        );
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwt.Issuer,
                        IssuerSigningKey = securityKey
                    };
                });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var res = ResponseFactory
                            .WithError(contextFeature.Error);
                        await context.Response.WriteAsJsonAsync(
                            res
                            );
                    }
                });
            });
            app.MapControllers();

            app.Run();
        }
    }
}
