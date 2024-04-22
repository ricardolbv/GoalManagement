using Microsoft.Extensions.DependencyInjection;

namespace GoalManagement.Infraestructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGoalManagementInfra(this IServiceCollection services)
        {

            return services;
        }
    }
}
