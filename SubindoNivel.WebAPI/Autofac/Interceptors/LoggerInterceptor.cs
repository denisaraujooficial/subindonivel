using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace SubindoNivel.WebAPI.Autofac.Interceptors
{
    public class LoggerInterceptor : IInterceptor
    {
        private readonly ILogger<LoggerInterceptor> logger;

        public LoggerInterceptor(ILogger<LoggerInterceptor> logger)
        {
            this.logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            logger.LogInformation($"MÉTODO: {invocation.Method.Name}");

            invocation.Proceed();

            logger.LogInformation($"RETORNO: {invocation.ReturnValue}");
        }
    }
}
