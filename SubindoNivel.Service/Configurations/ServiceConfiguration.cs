using Microsoft.Extensions.DependencyInjection;
using SubindoNivel.Common.Configuration;

namespace SubindoNivel.Service.Configurations
{
    public class ServiceConfiguration : IProjectConfiguration
    {
        public void Configure(IServiceCollection services)
        {
            //services.AddScoped<IProdutoService, ProdutoService>();
        }
    }
}
