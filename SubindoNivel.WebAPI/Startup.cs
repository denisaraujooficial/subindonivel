using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SubindoNivel.Common.Configuration;
using SubindoNivel.Common.Services;
using SubindoNivel.IService.Services;
using SubindoNivel.Service.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SubindoNivel.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SubindoNivel.WebAPI", Version = "v1" });
            });

            LoadAssemblies();

            var assemblies = GetAssemblies();

            RegisterProjectConfigurations(services, assemblies);

            RegisterServices(services, assemblies);

            int i = 0;

            //reflaction - Adicionar dinamicamente os services
            //Interceptador
            //Banco em mem?ria
            //Criar repositorios

            //Castle
            //SimpleInjector
        }

        private static void LoadAssemblies()
        {
            var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var assembliesFiles = Directory.GetFiles(path, "SubindoNivel*.dll", SearchOption.AllDirectories);

            foreach (var assemblyFile in assembliesFiles)
            {
                var assemblyName = AssemblyName.GetAssemblyName(assemblyFile);

                Assembly.Load(assemblyName);
            }
        }

        private static void RegisterServices(IServiceCollection services, IEnumerable<System.Reflection.Assembly> assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var serviceTypes = assembly.GetTypes()
                    .Where(t => !t.IsInterface && typeof(IServiceConfiguration).IsAssignableFrom(t));

                foreach (var serviceType in serviceTypes)
                {
                    var interfaceType = serviceType.GetInterfaces()
                        .SingleOrDefault(i => typeof(IServiceConfiguration).IsAssignableFrom(i)
                            && typeof(IServiceConfiguration) != i);

                    services.AddScoped(interfaceType, serviceType);
                }
            }
        }

        private static void RegisterProjectConfigurations(IServiceCollection services, IEnumerable<System.Reflection.Assembly> assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var serviceTypes = assembly.GetTypes()
                    .Where(t => !t.IsInterface && typeof(IProjectConfiguration).IsAssignableFrom(t));

                foreach (var serviceType in serviceTypes)
                {
                    var projectConfiguration = (IProjectConfiguration)Activator.CreateInstance(serviceType);

                    projectConfiguration.Configure(services);
                }
            }
        }

        private static IEnumerable<System.Reflection.Assembly> GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("SubindoNivel"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SubindoNivel.WebAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
