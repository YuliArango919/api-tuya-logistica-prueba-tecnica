﻿using Microsoft.Extensions.DependencyInjection;

namespace App.Tuya.Logistica.Api.App_Start
{
    public static class NetCoreConfig
    {
        public static void RegisterNetCoreConfig(this IServiceCollection services)
        {
            services.AddOptions();
            services.AddControllers();
            services.AddHttpClient();
        }
    }
}

