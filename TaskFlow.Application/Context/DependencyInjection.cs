using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Interfaces.Auth;
using TaskFlow.Application.Interfaces.Users;
using TaskFlow.Application.Interfaces.Utils;
using TaskFlow.Application.Mappings;
using TaskFlow.Application.Services.Auth;
using TaskFlow.Application.Services.Users;
using TaskFlow.Domain.Interfaces;

namespace TaskFlow.Application.Context
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            MapsterConfig.RegisterMappings();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
