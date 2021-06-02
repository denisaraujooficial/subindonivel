using Castle.DynamicProxy;

namespace SubindoNivel.WebAPI.Autofac.Interceptors
{
    public class LoggerInterceptor : IInterceptor
    {
        //private readonly ILogger logger;

        //public CallLogger(ILogger logger)
        //{
        //    this.logger = logger;
        //}

        public void Intercept(IInvocation invocation)
        {
            // Qualquer coisa antes de chamar o método

            invocation.Proceed();

            // Qualquer coisa depois de chamar o método
        }
    }
}
