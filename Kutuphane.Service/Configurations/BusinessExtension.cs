using Kutuphane.Service.Abstract;
using Kutuphane.Service.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Service.Configurations
{
    public static class BusinessExtension
    {
        public static void AddBusinessDI(this IServiceCollection services)
        {
            services.AddScoped<IYazarService, YazarService>();
            services.AddScoped<IKitapService, KitapService>();
            services.AddScoped<IYayinEviService, YayinEviService>();
            services.AddScoped<IKullaniciService, KullaniciService>();
        }
    }
}
