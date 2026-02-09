using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.DALApplication.Injections;
using WebApp.ServiceInfrastructure.Common.Mappings;


namespace WebApp.ServiceInfrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(cfg => { cfg.AddExpressionMapping(); }, typeof(MappingProfile).Assembly);

            services.InjectPersistence();
            services.AddAllService();

            return services;
        }
    }
}

