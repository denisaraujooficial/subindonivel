using Microsoft.Extensions.DependencyInjection;

namespace SubindoNivel.Common.Configuration
{
    public interface IProjectConfiguration
    {
        void Configure(IServiceCollection services);
    }
}
