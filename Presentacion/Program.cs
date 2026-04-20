using CasosUso.InterfacesCU;
using LogicaAccesoDatos.EF;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosUso;
using LogicaNegocio.InterfacesRepositorios;


namespace Presentacion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IRepositorioTemas, RepositorioTemasBD>();
            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();

            builder.Services.AddScoped<IAltaTema, CUAltaTema>();
            builder.Services.AddScoped<IBajaTema, CUBajaTema>();
            builder.Services.AddScoped<IModificarTema, CUModificarTema>();
            builder.Services.AddScoped<IListadoTemas, CUListadoTemas>();
            builder.Services.AddScoped<IBuscarTemaId, CUBuscarTemaId>();
            builder.Services.AddScoped<ILogin, CULogin>();
            builder.Services.AddScoped<IListadoUsuarios, CUListadoUsuarios>();

            builder.Services.AddDbContext<LibreriaContext>();

            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Temas}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
