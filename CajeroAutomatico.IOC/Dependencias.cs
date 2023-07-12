using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CajeroAutomatico.DAL.DBContext;
using CajeroAutomatico.DAL.Repositories.Contrato;
using CajeroAutomatico.DAL.Repositories;
using CajeroAutomatico.Utils;
using CajeroAutomatico.BLL.Servicios.Contrato;
using CajeroAutomatico.BLL.Servicios;

namespace CajeroAutomatico.IOC
{
    public static class Dependencias
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configs)
        {
            services.AddDbContext<CajeroAutomaticoContext>(options => {
                options.UseSqlServer(configs.GetConnectionString("SQLConnection"));
            });
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(AutomapperProfile));
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ICuentaService, CuentaService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IMovimientoService, MovimientoService>();
            services.AddScoped<ITarjetaService, TarjetaService>();
        }
    }
}
