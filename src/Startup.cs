using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using InventoryManagement.Models;
using InventoryManagement.Rules;
using InventoryManagement.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.Register<Func<ItemType, IUpdateRule>>(c =>
            {
                return (type) =>
                {
                    switch (type)
                    {
                        case ItemType.AGEDBRIE:
                            return new AgedBrieUpdateRule();
                        case ItemType.CHRISTMASCRACKERS:
                            return new ChristmasCrackerUpdateRule();
                        case ItemType.SOAP:
                            return new SoapUpdateRule();
                        case ItemType.FRESHITEM:
                            return new FreshItemUpdateRule();
                        case ItemType.FROZENITEM:
                            return new FrozenItemUpdateRule();
                        case ItemType.UNKNOWN:
                            throw new NotImplementedException();
                        default:
                            throw new NotImplementedException();
                    }
                };
            });
            builder.RegisterType<InventoryManagementService>().As<IInventoryManagementService>();

            AutofacContainer = builder.Build();
            return new AutofacServiceProvider(AutofacContainer);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}