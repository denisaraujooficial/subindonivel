using Castle.DynamicProxy;
using Serilog;

namespace SubindoNivel.WebAPI.Interceptors
{
    public class SimpleInterceptor : IInterceptor
    {
        //private readonly ILogger logger;

        //public SimpleInterceptor(ILogger logger)
        //{
        //    this.logger = logger;
        //}

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
        }
    }
}