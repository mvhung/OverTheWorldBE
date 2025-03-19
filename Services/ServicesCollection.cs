using LearningVocab.Interface;
using LearningVocab.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace LearningVocab.Services
{
    public static class ServicesCollection
    {
        public static void AddServicesCollection(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
    }
}
