using LearningVocab.Interface;
using LearningVocab.Repositories;
using LearningVocab.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace LearningVocab
{
    public static class ServicesCollection
    {
        public static void AddServicesCollection(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
