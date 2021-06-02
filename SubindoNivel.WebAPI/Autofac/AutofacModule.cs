using Autofac;
using Autofac.Extras.DynamicProxy;
using SubindoNivel.IService.Services;
using SubindoNivel.Service.Services;
using SubindoNivel.WebAPI.Autofac.Interceptors;
using System;

namespace SubindoNivel.WebAPI.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PessoaService>()
                .As<IPessoaService>()
                .InstancePerDependency()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(LoggerInterceptor));

            builder.RegisterType<ProdutoService>()
                .As<IProdutoService>()
                .InstancePerDependency()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(LoggerInterceptor));

            //builder.Register(c => new CallLogger());
            builder.RegisterType<LoggerInterceptor>();
        }
    }
}
