using RelationshipWebsiteV2.Services;

namespace RelationshipWebsiteV2
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {

            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
