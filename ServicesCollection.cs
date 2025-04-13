using LearningVocab.Datas;
using LearningVocab.Interface;
using LearningVocab.Repositories;
using LearningVocab.Services.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public static void AddAuthentications(this IServiceCollection services)
        {
            // Thêm Identity (nếu chưa có)
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                // Cấu hình JWT nếu bạn đang sử dụng
            })
            .AddGoogle(options =>
                {
                    options.ClientId = "2418838949-qtvhpq9adc2qp4qrmku17bief9ud21ku.apps.googleusercontent.com";
                    options.ClientSecret = "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";
                })
            .AddFacebook(options =>
                {
                    options.AppId = "978345411050437";
                    options.AppSecret = "6ae4dabe4770bebb5014d118811c6a07";
                });
        }
    }
}
