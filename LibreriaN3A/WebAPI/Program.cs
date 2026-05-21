
using CasosUso.InterfacesCU;
using LogicaAccesoDatos.EF;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosUso;
using LogicaNegocio.ClasesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IRepositorioTemas, RepositorioTemasBD>();
            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuariosBD>();
            builder.Services.AddScoped<IRepositorio<Publicacion>, RepositorioPublicacionesBD>();

            builder.Services.AddScoped<IAltaTema, CUAltaTema>();
            builder.Services.AddScoped<IBajaTema, CUBajaTema>();
            builder.Services.AddScoped<IModificarTema, CUModificarTema>();
            builder.Services.AddScoped<IListadoTemas, CUListadoTemas>();
            builder.Services.AddScoped<IBuscarTemaId, CUBuscarTemaId>();
            builder.Services.AddScoped<ILogin, CULogin>();
            builder.Services.AddScoped<IListadoUsuarios, CUListadoUsuarios>();
            builder.Services.AddScoped<IListadoTemasConTexto, CUListadoTemasTexto>();
            builder.Services.AddScoped<IListadoPublicaciones, CUListadoPublicaciones>();
            builder.Services.AddScoped<IAltaPublicacion, CUAltaPublicacion>();
            builder.Services.AddScoped<IBuscarPublicacionId, CUBuscarPublicacionId>();           


            string conBD = builder.Configuration.GetConnectionString("MiConexion");
            builder.Services.AddDbContext<LibreriaContext>(options =>
                    options.UseSqlServer(conBD));

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
