using Autofac;
using SubindoNivel.Common.Configuration;
using SubindoNivel.Common.Services;
using SubindoNivel.Entity.Entities;
using SubindoNivel.IRepository.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SubindoNivel.WebAPI
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            LoadAssemblies();

            var assemblies = GetAssemblies();

            foreach (var a in assemblies)
            {
                builder.RegisterAssemblyTypes(a)
                   .AssignableTo<IServiceConfiguration>()                   
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

                builder.RegisterAssemblyTypes(a)                   
                   .AssignableTo<IRepositoryConfiguration>()
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
            }           

        }       

        private static void LoadAssemblies()
        {
            var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var assembliesFiles = Directory.GetFiles(path, "SubindoNivel*.dll", SearchOption.AllDirectories);

            foreach (var assemblyFile in assembliesFiles)
            {
                var assemblyName = System.Reflection.AssemblyName.GetAssemblyName(assemblyFile);

                System.Reflection.Assembly.Load(assemblyName);
            }
        }

        private static IEnumerable<System.Reflection.Assembly> GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("SubindoNivel"));
        }

    }
}
