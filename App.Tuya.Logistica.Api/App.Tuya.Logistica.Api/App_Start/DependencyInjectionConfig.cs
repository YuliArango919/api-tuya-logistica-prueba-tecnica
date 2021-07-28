using App.Tuya.Logistica.Business;
using App.Tuya.Logistica.Common.Handler;
using App.Tuya.Logistica.Data.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Tuya.Logistica.Api.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterDependencyInjectionConfig(this IServiceCollection services, IConfiguration Configuration)
        {
            //Business
            services.AddScoped(typeof(ILogisticaBusiness), typeof(LogisticaBusiness));

            //Repositories
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddScoped<ExceptionHandle>();
        }
    }
}
