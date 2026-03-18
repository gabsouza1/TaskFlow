using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskFlow.Application.Interfaces.Auth;
using TaskFlow.Application.Interfaces.Utils;
using TaskFlow.Domain.Interfaces;
using TaskFlow.Infrastructure.Repository;
using TaskFlow.Infrastructure.Security;

namespace TaskFlow.Infrastructure.Context
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITasksRepository, TaskItemRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
