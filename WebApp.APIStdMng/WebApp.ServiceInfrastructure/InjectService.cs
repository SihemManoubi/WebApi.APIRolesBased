using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebApp.ServiceInfrastructure.IService;
using WebApp.ServiceInfrastructure.Service;

namespace WebApp.ServiceInfrastructure
{
    public static class InjectService
    {
        public static IServiceCollection AddAllService(this IServiceCollection services)
        {
            var allProviderTypes = Assembly.GetAssembly(typeof(IStudentService))
             .GetTypes().Where(t => t.Namespace != null).ToList();
            foreach (var intfc in allProviderTypes.Where(t => t.IsInterface))
            {
                var impl = allProviderTypes.FirstOrDefault(c => c.IsClass && intfc.Name.Substring(1) == c.Name);
                if (impl != null) services.AddScoped(intfc, impl);
            }

            //services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}
