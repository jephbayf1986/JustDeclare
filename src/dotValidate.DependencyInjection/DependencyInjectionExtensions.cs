using Microsoft.Extensions.DependencyInjection;

namespace dotValidate.DependencyInjection
{
    /// <summary>
    /// Dependency Injection Extensions for <i>dotValidate</i>/>
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Register <i>dotValidate</i>/> in your Startup class
        /// </summary>
        public static void RegisterDotValidate(this IServiceCollection services)
        {
            services.AddScoped<IValidator, Validator>();
        }
    }
}
