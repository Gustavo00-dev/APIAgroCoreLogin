using Microsoft.Extensions.DependencyInjection;
using APIAgroCoreLogin.Repository;

namespace APIAgroCoreLogin.Configuracao
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            #region Services/Repository   
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            return services;
        }
    }
}
